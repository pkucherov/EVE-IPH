using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace EVE_Isk_per_Hour
{

    public partial class frmShoppingList
    {

        // Inline grid row update variables
        private struct SavedLoc
        {
            public int X;
            public int Y;
        }

        private SavedLoc SavedListClickLoc;
        private bool RefreshingGrid;
        private bool CutPasteUpdate;

        private ListViewItem CurrentRow;
        private ListViewItem PreviousRow;
        private ListViewItem NextRow;

        private ListViewItem NextCellRow;
        private ListViewItem PreviousCellRow;

        private ListViewItem.ListViewSubItem CurrentCell;
        private ListViewItem.ListViewSubItem PreviousCell;
        private ListViewItem.ListViewSubItem NextCell;

        private bool UpdateQuantity;
        private bool UpdatePrice;
        private bool DataEntered;
        private bool IgnoreFocusChange;
        private ListView SelectedGrid;

        private int ItemListColumnClicked;
        private SortOrder ItemListColumnSortOrder;
        private int BuyListColumnClicked;
        private SortOrder BuyListColumnSortOrder;
        private int BuildListColumnClicked;
        private SortOrder BuildListColumnSortOrder;

        private List<Public_Variables.ItemBuyType> ItemBuyTypeList;

        private const string BuyListLabel = "Buy List";
        private const string BuildListLabel = "Build List";
        private const string ItemsListLabel = "Item List";

        // To use for copy and pasting data from the game into IPH
        public string CopyPasteMaterialText;

        // For finding structure in import lists
        private ItemQuantityType ItemQuantityToFind;
        private BuildQuantity BuildQuantityToFind;
        private IndustryFacility FacilityToFind;

        private string BuyListHeaderCSV = "Material,Quantity,Cost Per Item,Min Sell,Max Buy,Buy Type,Total m3,Isk/m3,TotalCost";
        private string BuildListHeaderCSV = "Build Item,Quantity,ME";
        private string BuildListHeaderCSVAdd = ",TE,Facility Location,Facility Type,IncludeActivityCost,IncludeActivityTime,IncludeUsageCost,Facility Build Type";
        private string ItemsListHeaderCSV = "Item,Quantity,ME,NumBps,Build Type,Decryptor,Relic";
        private string ItemsListHeaderCSVAdd = ",Facility Type,Location,IgnoredInvention,IgnoredMinerals,IgnoredT1BaseItem,IncludeActivityCost,IncludeActivityTime,IncludeUsageCost,Facility Build Type";

        private string BuyListHeaderTXT = "Material|Quantity|Cost Per Item|Min Sell|Max Buy|Buy Type|Total m3|Isk/m3|TotalCost";
        private string BuildListHeaderTXT = "Build Item|Quantity|ME";
        private string BuildListHeaderTXTAdd = "|TE|Facility Location|Facility Type|IncludeActivityCost|IncludeActivityTime|IncludeUsageCost|Facility Build Type";
        private string ItemsListHeaderTXT = "Item|Quantity|ME|NumBps|Build Type|Decryptor|Relic";
        private string ItemsListHeaderTXTAdd = "|Facility Type|Location|IgnoredInvention|IgnoredMinerals|IgnoredT1BaseItem|IncludeActivityCost|IncludeActivityTime|IncludeUsageCost|Facility Build Type";

        private string BuyListHeaderSSV = "Material;Quantity;Cost Per Item;Min Sell;Max Buy;Buy Type;Total m3;Isk/m3;TotalCost";
        private string BuildListHeaderSSV = "Build Item;Quantity;ME";
        private string BuildListHeaderSSVAdd = ";TE;Facility Location; Facility Type;IncludeActivityCost;IncludeActivityTime;IncludeUsageCost;Facility Build Type";
        private string ItemsListHeaderSSV = "Item;Quantity;ME;NumBps;Build Type;Decryptor;Relic";
        private string ItemsListHeaderSSVAdd = ";Facility Type;Location;IgnoredInvention;IgnoredMinerals;IgnoredT1BaseItem;IncludeActivityCost;IncludeActivityTime;IncludeUsageCost;Facility Build Type";

        private bool FirstFormLoad;

        private struct ItemQuantityType
        {
            public string ItemName;
            public long ItemQuantity;
            public int ItemME;
        }

        private struct BuildQuantity
        {
            public string ItemName;
            public long ItemQuantity;
            public int ItemME;
            public int ItemTE;
            public string FacilityType;
            public ProductionType FacilityBuildType;
            public string FacilityLocation;
            public bool IncludeActivityUsage;
            public bool IncludeActivityCost;
            public bool IncludeActivityTime;
        }

        // Predicate for finding the item in full list
        private bool FindItemQuantity(ItemQuantityType Item)
        {
            if ((Item.ItemName ?? "") == (ItemQuantityToFind.ItemName ?? ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Predicate for finding the item in full list
        private bool FindBuildQuantity(BuildQuantity Item)
        {
            if ((Item.ItemName ?? "") == (BuildQuantityToFind.ItemName ?? ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private struct BPItem
        {
            // Item List Format: Item, Quantity, ME, NumBPs Build Type, Decryptor, Relic (in file, in grid it is put with item name)
            public string ItemName;
            public long ItemQuantity;
            public int ItemME;
            public int NumBPs;
            public string BuildType;
            public string Decryptor;
            public string Relic;
            public string BuildLocation;
            public string FacilityType;
            public ProductionType FacilityBuildType;
            public bool IgnoredInvention;
            public bool IgnoredMinerals;
            public bool IgnoredT1BaseItem;
            public bool IncludeActivityCost;
            public bool IncludeActivityTime;
            public bool IncludeActivityUsage;
        }

        public frmShoppingList()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

            // Item Buy List - width = 1081 (21 width for verticle scroll bar)
            lstBuy.Columns.Add("TypeID", 0, HorizontalAlignment.Left); // Hidden
            lstBuy.Columns.Add("Material", 245, HorizontalAlignment.Left);
            lstBuy.Columns.Add("Quantity", 94, HorizontalAlignment.Right); // Min 94
            lstBuy.Columns.Add("Cost per Item", 90, HorizontalAlignment.Right); // Min 90
            lstBuy.Columns.Add("Min Sell", 90, HorizontalAlignment.Right); // Min 90
            lstBuy.Columns.Add("Max Buy", 90, HorizontalAlignment.Right); // Min 90
            lstBuy.Columns.Add("Buy Type", 66, HorizontalAlignment.Right); // Min 66
            lstBuy.Columns.Add("Total m3", 100, HorizontalAlignment.Right); // Min 100
            lstBuy.Columns.Add("Isk/m3", 83, HorizontalAlignment.Right); // Min 85
            lstBuy.Columns.Add("Fees", 90, HorizontalAlignment.Right);
            lstBuy.Columns.Add("Total Cost", 112, HorizontalAlignment.Right); // Min 129

            // Built Item List for items we are building - width = 371 (21 for verticle scroll bar)
            lstBuild.Columns.Add("TypeID", 0, HorizontalAlignment.Center); // always left allignment this column for some reason, so add a dummy
            lstBuild.Columns.Add("Build Item", 237, HorizontalAlignment.Left);
            lstBuild.Columns.Add("Quantity", 80, HorizontalAlignment.Right);
            lstBuild.Columns.Add("ME", 30, HorizontalAlignment.Right);
            lstBuild.Columns.Add("TE", 0, HorizontalAlignment.Right); // Hidden
            lstBuild.Columns.Add("Facility Location", 0, HorizontalAlignment.Left); // Hidden to help build at component facility
            lstBuild.Columns.Add("Facility Type", 0, HorizontalAlignment.Left); // Hidden flag 
            lstBuild.Columns.Add("IncludeActivityCost", 0, HorizontalAlignment.Left); // Hidden flag for ignore variables
            lstBuild.Columns.Add("IncludeActivityTime", 0, HorizontalAlignment.Left); // Hidden flag for ignore variables
            lstBuild.Columns.Add("IncludeActivityUsage", 0, HorizontalAlignment.Left); // Hidden flag for ignore variables
            lstBuild.Columns.Add("BPTypeID", 0, HorizontalAlignment.Center); // Hidden for double click look up
            lstBuild.Columns.Add("Facility Build type", 0, HorizontalAlignment.Center); // Hidden for saving

            // Item List - What we are building - width = 711 (21 for verticle scroll bar)
            lstItems.Columns.Add("TypeID", 0, HorizontalAlignment.Center); // always left allignment this column for some reason, so add a dummy, store bpID here though
            lstItems.Columns.Add("Item", 225, HorizontalAlignment.Left); // 
            lstItems.Columns.Add("Quantity", 67, HorizontalAlignment.Right); // 51 min text
            lstItems.Columns.Add("ME", 30, HorizontalAlignment.Right); // 30 min text
            lstItems.Columns.Add("Num BPs", 60, HorizontalAlignment.Left); // 60 min text
            lstItems.Columns.Add("Build Type", 71, HorizontalAlignment.Left); // 71 min text
            lstItems.Columns.Add("Decryptor", 105, HorizontalAlignment.Left); // 105 min text
            lstItems.Columns.Add("Location", 132, HorizontalAlignment.Left); // 132 min text
            lstItems.Columns.Add("Facility Type", 0, HorizontalAlignment.Left); // Hidden flag
            lstItems.Columns.Add("IgnoredInvention", 0, HorizontalAlignment.Left); // Hidden flag for ignore variables
            lstItems.Columns.Add("IgnoredMinerals", 0, HorizontalAlignment.Left); // Hidden flag for ignore variables
            lstItems.Columns.Add("IgnoredT1BaseItem", 0, HorizontalAlignment.Left); // Hidden flag for ignore variables
            lstItems.Columns.Add("IncludeActivityCost", 0, HorizontalAlignment.Left); // Hidden flag for ignore variables
            lstItems.Columns.Add("IncludeActivityTime", 0, HorizontalAlignment.Left); // Hidden flag for ignore variables
            lstItems.Columns.Add("IncludeActivityUsage", 0, HorizontalAlignment.Left); // Hidden flag for ignore variables
            lstItems.Columns.Add("TE", 0, HorizontalAlignment.Right); // Hidden
            lstItems.Columns.Add("Facility Build type", 0, HorizontalAlignment.Center); // Hidden for saving

            if (SettingsVariables.UserApplicationSettings.ShowToolTips)
            {
                ttMain.SetToolTip(btnShowAssets, "Show Assets");
                ttMain.SetToolTip(chkFees, "When checked, will total all items listed in buy list as 'Buy Order'.");
                ttMain.SetToolTip(chkBuyorBuyOrder, "Tri-check, IPH will attempt to determine whether it is better to buy the item directly off of the market or to set up a buy order. Unchecked - buy order, Checked - compare order to market, Tri-check - buy market only");
                ttMain.SetToolTip(chkUsage, "Estimated Usage Fees to build the items in the Items and Components to Build Lists.");
                ttMain.SetToolTip(lblAddlCosts, "Addtional costs you want to add to this shopping list (i.e. BPC costs). This value not affected by taxes or fees.");
                ttMain.SetToolTip(chkUpdateAssetsWhenUsed, "If checked, when updating the list with scanned assets IPH will subtract all used materials from your asset list.");
                ttMain.SetToolTip(rbtnExportCSV, "Exports data in Common Separated Values with periods for decimals");
                ttMain.SetToolTip(rbtnExportSSV, "Exports data in SemiColon Separated Values with commas for decimals");
                ttMain.SetToolTip(rbtnExportDefault, "Exports data in basic space or dashes to separate data for easy readability");
                ttMain.SetToolTip(btnUpdateListwithAssets, "Update the Shopping List based on materials you have in your selected asset location(s).");
                ttMain.SetToolTip(btnShowAssets, "Open the Asset Viewer to set the default location(s) for materials to use for updating the Shopping List.");
                ttMain.SetToolTip(lblTIC, "Total of all invention materials in the buy list.");
                ttMain.SetToolTip(lblTCC, "Total of all the copy materials in the buy list.");
                ttMain.SetToolTip(rbtnExportMulitBuy, "When checked, this will copy the list into a format that will work with Multi-Buy when pressing the Copy button.");
                ttMain.SetToolTip(chkRebuildItemsfromList, "When loading a saved shopping list, if checked IPH will rebuild all items with current prices and items. Otherwise it will load exactly what is in the list with current prices.");
            }

            IgnoreFocusChange = false;

            if ((rbtnExportCSV.Text ?? "") == (SettingsVariables.UserApplicationSettings.DataExportFormat ?? ""))
            {
                rbtnExportCSV.Checked = true;
            }
            else if ((rbtnExportSSV.Text ?? "") == (SettingsVariables.UserApplicationSettings.DataExportFormat ?? ""))
            {
                rbtnExportSSV.Checked = true;
            }
            else if ((rbtnExportDefault.Text ?? "") == (SettingsVariables.UserApplicationSettings.DataExportFormat ?? ""))
            {
                rbtnExportDefault.Checked = true;
            }

            btnCopy.Enabled = false;
            btnSaveListToFile.Enabled = false;

            ItemListColumnClicked = 0;
            ItemListColumnSortOrder = SortOrder.None;
            BuyListColumnClicked = 0;
            BuyListColumnSortOrder = SortOrder.None;
            BuildListColumnClicked = 0;
            BuildListColumnSortOrder = SortOrder.None;

            CutPasteUpdate = false;

            FirstFormLoad = true;

            CopyPasteMaterialText = "";

        }

        private void frmShoppingList_Shown(object sender, EventArgs e)
        {
            // Load settings
            chkUsage.Checked = SettingsVariables.UserShoppingListSettings.Usage;
            chkFees.Checked = SettingsVariables.UserShoppingListSettings.Fees;
            chkAlwaysOnTop.Checked = SettingsVariables.UserShoppingListSettings.AlwaysonTop;
            switch (SettingsVariables.UserShoppingListSettings.CalcBuyBuyOrder)
            {
                case 2:
                    {
                        chkBuyorBuyOrder.CheckState = CheckState.Indeterminate;
                        break;
                    }
                case 1:
                    {
                        chkBuyorBuyOrder.Checked = true;
                        break;
                    }
                case 0:
                    {
                        chkBuyorBuyOrder.Checked = false;
                        break;
                    }
            }
            chkRebuildItemsfromList.Checked = SettingsVariables.UserShoppingListSettings.ReloadBPsFromFile;

            if ((rbtnExportCSV.Text ?? "") == (SettingsVariables.UserShoppingListSettings.DataExportFormat ?? ""))
            {
                rbtnExportCSV.Checked = true;
            }
            else if ((rbtnExportSSV.Text ?? "") == (SettingsVariables.UserShoppingListSettings.DataExportFormat ?? ""))
            {
                rbtnExportSSV.Checked = true;
            }
            else if ((rbtnExportDefault.Text ?? "") == (SettingsVariables.UserShoppingListSettings.DataExportFormat ?? ""))
            {
                rbtnExportDefault.Checked = true;
            }
            else if ((rbtnExportMulitBuy.Text ?? "") == (SettingsVariables.UserShoppingListSettings.DataExportFormat ?? ""))
            {
                rbtnExportMulitBuy.Checked = true;
            }
            chkUpdateAssetsWhenUsed.Checked = SettingsVariables.UserShoppingListSettings.UpdateAssetsWhenUsed;

            // Only enable the clear button when something in the list
            if (Public_Variables.TotalShoppingList.GetNumShoppingItems() > 0L)
            {
                btnClear.Enabled = true;
                gbUpdateList.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
                gbUpdateList.Enabled = false;
            }

        }

        public void RefreshLists()
        {
            RefreshingGrid = true;
            LoadBuyList();
            LoadItemList();
            LoadBuildList();
            LoadFormStats();

            // Enable the buttons if there are rows
            if (lstItems.Items.Count > 0)
            {
                btnCopy.Enabled = true;
                btnSaveListToFile.Enabled = true;
                btnClear.Enabled = true;
                gbUpdateList.Enabled = true;
            }
            else
            {
                btnCopy.Enabled = false;
                btnSaveListToFile.Enabled = false;
                btnClear.Enabled = false;
                gbUpdateList.Enabled = false;
                // No more items so clear lists
                ClearLists();
            }

            RefreshingGrid = false;
        }

        private void ClearLists()
        {
            // Reset global list
            Public_Variables.TotalShoppingList.Clear();

            lstItems.Items.Clear();
            lstBuild.Items.Clear();
            lstBuy.Items.Clear();

            lstItems.Update();
            lstBuild.Update();
            lstBuy.Update();

            lblTotalProfit.Text = "0.00 ISK";
            lblAvgIPH.Text = "0.00 ISK";

            lblTotalCost.Text = "0.00 ISK";
            lblTotalVolume.Text = "0.00 m3";
            lblTotalBuiltVolume.Text = "0.00 m3";
            lblTotalCopyCost.Text = "0.00 ISK";
            lblTotalInventionCost.Text = "0.00 ISK";

            lblUsage.Text = "0.00";
            lblFees.Text = "0.00";

            // Update the main form notice of no items
            My.MyProject.Forms.frmMain.pnlShoppingList.Text = "No Items in Shopping List";
            My.MyProject.Forms.frmMain.pnlShoppingList.ForeColor = Color.Black;

            btnCopy.Enabled = false;
            btnSaveListToFile.Enabled = false;

            Refresh();

        }

        // Loads all the main items we want to buy into the main table
        private void LoadBuyList()
        {
            ListViewItem RawmatList;
            var RawItems = new Materials();

            string SQL;
            SQLiteDataReader readerItemPrices;

            string BuyOrderText;
            double SellPrice;
            double BuyOrderPrice;
            var BuyOrderFees = default(double);
            double TotalPrice;
            string PriceType;
            string PriceSource;
            string RegionSystem;
            var StoredPrice = default(double);
            var MinSellUnitPrice = default(double);
            var MaxBuyUnitPrice = default(double);

            const string BuyOrder = "Buy Order";
            const string BuyMarket = "Buy Market";
            const string Unknown = "Unknown";

            lstBuy.Items.Clear();
            lstBuy.BeginUpdate();

            // Get the list of items
            RawItems = Public_Variables.TotalShoppingList.GetFullBuyList();

            // Reset buy type list
            ItemBuyTypeList = new List<Public_Variables.ItemBuyType>();

            // Set to 0 first
            lblTotalProfit.Text = "0.00 ISK";
            lblAvgIPH.Text = "0.00 ISK";
            lblTotalBuiltVolume.Text = "0.00 m3";
            lblTotalVolume.Text = "0.00 m3";
            lblTotalCost.Text = "0.00 ISK";

            if (!(RawItems == null))
            {
                if (!(RawItems.GetMaterialList() == null))
                {

                    // Sort the list of mats
                    RawItems.SortMaterialListByQuantity();

                    // Fill Component List
                    for (int i = 0, loopTo = RawItems.GetMaterialList().Count - 1; i <= loopTo; i++)
                    {
                        // Reset
                        BuyOrderText = Unknown;

                        RawmatList = new ListViewItem(RawItems.GetMaterialList()[i].GetMaterialTypeID().ToString()); // Hidden
                                                                                                                     // The remaining columns are subitems  
                        RawmatList.SubItems.Add(RawItems.GetMaterialList()[i].GetMaterialName());
                        RawmatList.SubItems.Add(Strings.FormatNumber(RawItems.GetMaterialList()[i].GetQuantity(), 0));
                        RawmatList.SubItems.Add(Strings.FormatNumber(RawItems.GetMaterialList()[i].GetCostPerItem(), 2)); // Cost per item (as the user has it stored)

                        // See if we want to determine if we compare prices for Buy Order / Buy Market
                        // The rules are:
                        // - If Fees is checked and CalcBuyType then calculate for buy order or buy market
                        // - If Fees is not checked, then CalcBuyType will be disabled, and the user wants to buy all from market
                        // - If Fees is checked, and CalcBuyType is not, then you want to buy all from a buy order

                        // Look up the price of buying directly off the market (min sell - no tax, no broker fee) and compare it to the price
                        // of max buy (buy order) plus the brokers fees to set up that order (no tax). Then show the value in the grid of what they should do
                        // First find out what price and type we have stored
                        SQL = "SELECT PRICE, PRICE_TYPE, PRICE_SOURCE, RegionORSystem FROM ITEM_PRICES WHERE ITEM_ID = " + RawItems.GetMaterialList()[i].GetMaterialTypeID();
                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                        readerItemPrices = Public_Variables.DBCommand.ExecuteReader();
                        readerItemPrices.Read();

                        if (readerItemPrices.HasRows)
                        {
                            // Figure out what they have stored so we know what type of price we need to get
                            StoredPrice = Conversions.ToDouble(readerItemPrices.GetValue(0));
                            PriceType = readerItemPrices.GetString(1);
                            PriceSource = readerItemPrices.GetInt32(2).ToString();
                            RegionSystem = readerItemPrices.GetInt64(3).ToString();
                        }
                        else
                        {
                            PriceType = Public_Variables.None;
                            PriceSource = "-1";
                            RegionSystem = "0";
                        }

                        readerItemPrices.Close();

                        // Load the Min Sell and Max Buy prices from cache - source is based off of update prices price selection
                        if ((PriceSource ?? "") == (((int)DataSource.CCP).ToString() ?? "") & (PriceType ?? "") != Public_Variables.None)
                        {
                            SQL = "SELECT MIN(PRICE) FROM MARKET_ORDERS WHERE TYPE_ID = " + RawItems.GetMaterialList()[i].GetMaterialTypeID();
                            SQL += " AND (REGION_ID = " + RegionSystem + " OR SOLAR_SYSTEM_ID = " + RegionSystem + ") AND IS_BUY_ORDER = 0";
                            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                            readerItemPrices = Public_Variables.DBCommand.ExecuteReader();
                            readerItemPrices.Read();

                            PriceType = GoodPriceData(ref readerItemPrices, 1, PriceType);

                            // Get the buy and sell prices
                            if ((PriceType ?? "") != Public_Variables.None)
                            {
                                MinSellUnitPrice = Conversions.ToDouble(readerItemPrices.GetValue(0));

                                SQL = "SELECT MAX(PRICE) FROM MARKET_ORDERS WHERE TYPE_ID = " + RawItems.GetMaterialList()[i].GetMaterialTypeID();
                                SQL += " AND (REGION_ID = " + RegionSystem + " OR SOLAR_SYSTEM_ID = " + RegionSystem + ") AND IS_BUY_ORDER <> 0";
                                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                                readerItemPrices = Public_Variables.DBCommand.ExecuteReader();
                                readerItemPrices.Read();

                                PriceType = GoodPriceData(ref readerItemPrices, 1, PriceType);

                                // Get the buy and sell prices
                                if ((PriceType ?? "") != Public_Variables.None)
                                {
                                    MaxBuyUnitPrice = Conversions.ToDouble(readerItemPrices.GetValue(0));
                                }
                            }
                        }
                        else
                        {
                            SQL = "SELECT sellMin, buyMax FROM ITEM_PRICES_CACHE WHERE typeID = " + RawItems.GetMaterialList()[i].GetMaterialTypeID();
                            SQL += " AND sellMin IS NOT NULL AND buyMax IS NOT NULL AND PRICE_SOURCE = " + PriceSource + " AND RegionORSystem = " + RegionSystem;

                            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                            readerItemPrices = Public_Variables.DBCommand.ExecuteReader();
                            readerItemPrices.Read();

                            PriceType = GoodPriceData(ref readerItemPrices, 2, PriceType);

                            // Get the buy and sell prices
                            if ((PriceType ?? "") != Public_Variables.None)
                            {
                                MinSellUnitPrice = Conversions.ToDouble(readerItemPrices.GetValue(0));
                                MaxBuyUnitPrice = Conversions.ToDouble(readerItemPrices.GetValue(1));
                            }
                        }

                        readerItemPrices.Close();

                        // Four cases - None or error, set to zero. If they had a user entered price, assume min sell. Otherwise, use stored values
                        if ((PriceType ?? "") == Public_Variables.None)
                        {
                            // Price isn't set yet or an error. Either way they are zero 
                            MinSellUnitPrice = 0d;
                            MaxBuyUnitPrice = 0d;
                        }

                        else if (PriceType == "User" | PriceType.Contains("sell"))
                        {
                            // The updated a price, so no matter what they intended - I'm assuming they meant minSell (50/50 chance)
                            // or they stored some sell price, so set that and compare to the stored maxbuy price
                            MinSellUnitPrice = StoredPrice;
                        }
                        else if (PriceType.Contains("buy") | PriceType.Contains("all"))
                        {
                            // They stored a buy price...so set that and we'll compare it to the stored minsell price - also use average here too
                            MaxBuyUnitPrice = StoredPrice;
                        }

                        if (chkBuyorBuyOrder.Checked & chkBuyorBuyOrder.Enabled == true & chkFees.Checked & chkBuyorBuyOrder.CheckState != CheckState.Indeterminate)
                        {
                            // Now that we have the prices, compare the two
                            if (MinSellUnitPrice != 0d & MaxBuyUnitPrice != 0d)
                            {

                                // Now look at max buy
                                TotalPrice = MaxBuyUnitPrice * RawItems.GetMaterialList()[i].GetQuantity();
                                BuyOrderFees = Public_Variables.GetSalesBrokerFee(TotalPrice, Public_Variables.GetBrokerFeeData(My.MyProject.Forms.frmMain.chkBPBrokerFees, My.MyProject.Forms.frmMain.txtBPBrokerFeeRate));
                                BuyOrderPrice = TotalPrice + BuyOrderFees;

                                // Use min sell
                                SellPrice = MinSellUnitPrice * RawItems.GetMaterialList()[i].GetQuantity();

                                if (BuyOrderPrice < SellPrice)
                                {
                                    // They should do an order
                                    BuyOrderText = BuyOrder;
                                }
                                else
                                {
                                    // Buy from the Market
                                    BuyOrderText = BuyMarket;
                                    // No fees straight off market
                                    BuyOrderFees = 0d;
                                }
                            }
                            else
                            {
                                BuyOrderText = Unknown;
                                BuyOrderFees = 0d;
                            }
                        }
                        else if (chkFees.Checked == false | chkBuyorBuyOrder.CheckState == CheckState.Indeterminate & chkBuyorBuyOrder.Enabled == true)
                        {
                            // User wants to buy all from market, don't apply broker fees
                            BuyOrderText = BuyMarket;
                        }
                        else if (chkFees.Checked == true & chkBuyorBuyOrder.Checked == false)
                        {
                            // They want a buy order for all items
                            BuyOrderText = BuyOrder;
                            if (MaxBuyUnitPrice != 0d)
                            {
                                BuyOrderFees = Public_Variables.GetSalesBrokerFee(MaxBuyUnitPrice * RawItems.GetMaterialList()[i].GetQuantity(), Public_Variables.GetBrokerFeeData(My.MyProject.Forms.frmMain.chkBPBrokerFees, My.MyProject.Forms.frmMain.txtBPBrokerFeeRate));
                            }
                            else
                            {
                                BuyOrderFees = 0d;
                            }
                        }

                        // Add the minsell/maxbuy for reference
                        RawmatList.SubItems.Add(Strings.FormatNumber(MinSellUnitPrice, 2));
                        RawmatList.SubItems.Add(Strings.FormatNumber(MaxBuyUnitPrice, 2));

                        // Finally Add the correct column value for how to buy it
                        RawmatList.SubItems.Add(BuyOrderText); // Buy or Buy Market flag

                        // Add this item to the list
                        Public_Variables.ItemBuyType Temp;
                        Temp.ItemName = RawItems.GetMaterialList()[i].GetMaterialName();
                        Temp.BuyType = BuyOrderText;
                        ItemBuyTypeList.Add(Temp);

                        RawmatList.SubItems.Add(Strings.FormatNumber(RawItems.GetMaterialList()[i].GetTotalVolume(), 2)); // Volume

                        if (RawItems.GetMaterialList()[i].GetTotalVolume() != 0d)
                        {
                            RawmatList.SubItems.Add(Strings.FormatNumber(RawItems.GetMaterialList()[i].GetTotalCost() / RawItems.GetMaterialList()[i].GetTotalVolume(), 2)); // Isk per m3
                        }
                        else
                        {
                            RawmatList.SubItems.Add("0.00");
                        } // Isk per m3

                        RawmatList.SubItems.Add(Strings.FormatNumber(BuyOrderFees, 2)); // Fees for buy orders
                        RawmatList.SubItems.Add(Strings.FormatNumber(RawItems.GetMaterialList()[i].GetTotalCost() + BuyOrderFees, 2)); // Total Cost

                        lstBuy.Items.Add(RawmatList);
                    }

                }
            }

            // Finally sort it if there is a value it's already sorted
            // Call ListViewColumnSorter(ItemListColumnClicked, CType(lstItems, ListView), ItemListColumnClicked, ItemListColumnSortOrder)

            lstBuy.EndUpdate();

        }

        // Returns price type None if not good data
        public string GoodPriceData(ref SQLiteDataReader rsPriceData, int NumFieldCheck, string DefaultData)
        {
            if (rsPriceData.HasRows)
            {
                if (NumFieldCheck == 2)
                {
                    if (rsPriceData.GetValue(0) is DBNull | rsPriceData.GetValue(1) is DBNull)
                    {
                        return Public_Variables.None;
                    }
                }
                else if (NumFieldCheck != 2)
                {
                    if (rsPriceData.GetValue(0) is DBNull)
                    {
                        return Public_Variables.None;
                    }
                }
            }
            else
            {
                return Public_Variables.None;
            }

            // All good, keep what they have
            return DefaultData;

        }

        // Loads the list of items into the items list
        private void LoadItemList()
        {
            ListViewItem lstItem;
            List<ShoppingListItem> ItemList;

            lstItems.BeginUpdate();
            lstItems.Items.Clear();

            ItemList = Public_Variables.TotalShoppingList.GetFullShoppingList();

            // Loop through the list and display all items
            for (int i = 0, loopTo = ItemList.Count - 1; i <= loopTo; i++)
            {
                {
                    var withBlock = ItemList[i];
                    lstItem = lstItems.Items.Add(withBlock.TypeID.ToString()); // Hidden
                    if (withBlock.TechLevel != 3)
                    {
                        lstItem.SubItems.Add(ItemList[i].Name);
                    }
                    else
                    {
                        lstItem.SubItems.Add(ItemList[i].Name + " (" + ItemList[i].Relic + ")");
                    } // Add relic name after the item
                    lstItem.SubItems.Add(Strings.FormatNumber(ItemList[i].Runs, 0));
                    lstItem.SubItems.Add(ItemList[i].ItemME.ToString());
                    lstItem.SubItems.Add(ItemList[i].NumBPs.ToString());
                    lstItem.SubItems.Add(ItemList[i].BuildType);
                    lstItem.SubItems.Add(ItemList[i].Decryptor);
                    lstItem.SubItems.Add(ItemList[i].ManufacturingFacility.FacilityName);
                    lstItem.SubItems.Add(((int)ItemList[i].ManufacturingFacility.FacilityType).ToString());
                    lstItem.SubItems.Add(Conversions.ToString(ItemList[i].IgnoredInvention));
                    lstItem.SubItems.Add(Conversions.ToString(ItemList[i].IgnoredMinerals));
                    lstItem.SubItems.Add(Conversions.ToString(ItemList[i].IgnoredT1BaseItem));
                    lstItem.SubItems.Add(Conversions.ToString(ItemList[i].IncludeActivityCost));
                    lstItem.SubItems.Add(Conversions.ToString(ItemList[i].IncludeActivityTime));
                    lstItem.SubItems.Add(Conversions.ToString(ItemList[i].IncludeActivityUsage));
                    lstItem.SubItems.Add(ItemList[i].ItemTE.ToString());
                    lstItem.SubItems.Add(((int)ItemList[i].ManufacturingFacility.FacilityProductionType).ToString());
                }
            }

            // Add the number of item(s) to the label on the shopping list
            int ItemCount = ItemList.Count;

            if (ItemList.Count != 1)
            {
                lblTotalItemsInList.Text = Strings.FormatNumber(ItemCount, 0) + Constants.vbCrLf + "Items in list";
            }
            else
            {
                lblTotalItemsInList.Text = "1" + Constants.vbCrLf + "Item in list";
            }

            lstItems.EndUpdate();

        }

        // Loads the list of items to build into the items list
        private void LoadBuildList()
        {
            int i;
            ListViewItem lstBuildItem;
            var BuildItems = new BuiltItemList();

            lstBuild.BeginUpdate();
            lstBuild.Items.Clear();

            // TotalShoppingList.GetFullBuildList uses BuildItem and Volume for the facility ME value
            BuildItems = Public_Variables.TotalShoppingList.GetFullBuildList();

            // Now load the grid with all the mats
            if (!(BuildItems == null))
            {
                if (!(BuildItems.GetBuiltItemList() == null))
                {
                    var loopTo = BuildItems.GetBuiltItemList().Count - 1;
                    for (i = 0; i <= loopTo; i++)
                    {

                        lstBuildItem = lstBuild.Items.Add(BuildItems.GetBuiltItemList()[i].ItemTypeID.ToString());
                        // The remaining columns are subitems  
                        lstBuildItem.SubItems.Add(BuildItems.GetBuiltItemList()[i].ItemName);
                        lstBuildItem.SubItems.Add(Strings.FormatNumber(BuildItems.GetBuiltItemList()[i].ItemQuantity, 0));
                        lstBuildItem.SubItems.Add(BuildItems.GetBuiltItemList()[i].BuildME.ToString());
                        lstBuildItem.SubItems.Add(BuildItems.GetBuiltItemList()[i].BuildTE.ToString());
                        lstBuildItem.SubItems.Add(BuildItems.GetBuiltItemList()[i].ManufacturingFacility.FacilityName);
                        lstBuildItem.SubItems.Add(((int)BuildItems.GetBuiltItemList()[i].ManufacturingFacility.FacilityType).ToString());
                        lstBuildItem.SubItems.Add(Conversions.ToString(BuildItems.GetBuiltItemList()[i].IncludeActivityCost));
                        lstBuildItem.SubItems.Add(Conversions.ToString(BuildItems.GetBuiltItemList()[i].IncludeActivityTime));
                        lstBuildItem.SubItems.Add(Conversions.ToString(BuildItems.GetBuiltItemList()[i].IncludeActivityUsage));
                        lstBuildItem.SubItems.Add(BuildItems.GetBuiltItemList()[i].BPTypeID.ToString()); // Add the bp type id here for double clicking later
                        lstBuildItem.SubItems.Add(((int)BuildItems.GetBuiltItemList()[i].ManufacturingFacility.FacilityProductionType).ToString());
                    }
                }
            }

            lstBuild.EndUpdate();

        }

        // Loads up the IPH, profit, etc
        private void LoadFormStats()
        {

            if (Public_Variables.TotalShoppingList.GetNumShoppingItems() != 0L)
            {
                if (!string.IsNullOrEmpty(Strings.Trim(txtAddlCosts.Text)))
                {
                    Public_Variables.TotalShoppingList.SetAdditionalCosts(Conversions.ToDouble(txtAddlCosts.Text));
                }

                var BFI = Public_Variables.GetBrokerFeeData(chkFees, txtBrokerFeeRate);

                Public_Variables.TotalShoppingList.SetPriceData(BFI, chkUsage.Checked, ItemBuyTypeList);

                lblTotalCost.Text = Strings.FormatNumber(Public_Variables.TotalShoppingList.GetTotalCost(), 2) + " ISK";
                lblTotalVolume.Text = Strings.FormatNumber(Public_Variables.TotalShoppingList.GetTotalVolume(), 2) + " m3";

                lblTotalProfit.Text = Strings.FormatNumber(Public_Variables.TotalShoppingList.GetTotalProfit(), 2) + " ISK";
                lblAvgIPH.Text = Strings.FormatNumber(Public_Variables.TotalShoppingList.GetTotalIPH(), 2) + " ISK";

                lblTotalBuiltVolume.Text = Strings.FormatNumber(Public_Variables.TotalShoppingList.GetBuiltItemVolume(), 2) + " m3";

                lblTotalInventionCost.Text = Strings.FormatNumber(Public_Variables.TotalShoppingList.GetTotalInventionCosts(), 2) + " ISK";
                lblTotalCopyCost.Text = Strings.FormatNumber(Public_Variables.TotalShoppingList.GetTotalCopyCosts(), 2) + " ISK";

                lblFees.Text = Strings.FormatNumber(Public_Variables.TotalShoppingList.GetTotalMaterialsBrokersFees());
                lblUsage.Text = Strings.FormatNumber(Public_Variables.TotalShoppingList.GetTotalUsage());

            }

        }

        // Update the shopping list with all items we may have. If we have components, update those and then update the number of mats accordingly in the buy list
        private void btnUpdateListwithAssets_Click(object sender, EventArgs e)
        {
            UpdateShoppingListwithAssets();
        }

        // Updates the shopping list values on screen if we are sent materials or if not, looking up in the DB
        private void UpdateShoppingListwithAssets(Materials PasteMaterialList = null)
        {
            var ProcessList = new Materials();
            var FoundBuildItem = new BuiltItem();
            string SQL;
            SQLiteDataReader readerAssets;
            long UpdatedQuantity;
            long UserQuantity;
            string CurrentItemName = "";

            Application.UseWaitCursor = true;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            string IDString = "";

            // Set the ID string we will use to update
            if (SettingsVariables.UserAssetWindowShoppingListSettings.AssetType == "Both")
            {
                IDString = Public_Variables.SelectedCharacter.ID.ToString() + "," + Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString();
            }
            else if (SettingsVariables.UserAssetWindowShoppingListSettings.AssetType == "Personal")
            {
                IDString = Public_Variables.SelectedCharacter.ID.ToString();
            }
            else if (SettingsVariables.UserAssetWindowShoppingListSettings.AssetType == "Corporation")
            {
                IDString = Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString();
            }

            // Build the where clause to look up data
            var AssetLocationFlagList = new List<string>();
            // First look up the location and flagID pairs - unique ID of asset locations
            SQL = "SELECT LocationID, FlagID FROM ASSET_LOCATIONS WHERE EnumAssetType = " + ((int)AssetWindow.ShoppingList).ToString() + " AND ID IN (" + IDString + ")";
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerAssets = Public_Variables.DBCommand.ExecuteReader();

            while (readerAssets.Read())
            {
                if (readerAssets.GetInt32(1) == -4 | readerAssets.GetInt64(0) > 1000000000000L)
                {
                    // If the flag is the base location, then we want all items at the location id
                    AssetLocationFlagList.Add("(LocationID = " + readerAssets.GetInt64(0).ToString() + ")");
                }
                else
                {
                    AssetLocationFlagList.Add("(LocationID = " + readerAssets.GetInt64(0).ToString() + " AND Flag = " + readerAssets.GetInt32(1).ToString() + ")");
                }
            }

            readerAssets.Close();

            if (AssetLocationFlagList.Count != 0 | CutPasteUpdate)
            {

                // Loop through the lists, starting with the build list first and find quantities in hanger to build
                for (int i = 0; i <= 3; i++) // 4 lists
                {
                    Application.DoEvents();
                    // TotalShoppingList.GetFullBuildList.Clone uses BuildItem and Volume for the facility ME value
                    switch (i)
                    {
                        case 0:
                            {
                                ProcessList = (Materials)Public_Variables.TotalShoppingList.GetFullBuildMaterialList().Clone();
                                break;
                            }
                        case 1:
                            {
                                ProcessList = (Materials)Public_Variables.TotalShoppingList.GetFullBuyList().Clone();
                                break;
                            }
                        case 2:
                            {
                                ProcessList = (Materials)Public_Variables.TotalShoppingList.GetFullInventionList().Clone();
                                break;
                            }
                        case 3:
                            {
                                ProcessList = (Materials)Public_Variables.TotalShoppingList.GetFullCopyList().Clone();
                                break;
                            }
                    }

                    if (!(ProcessList == null))
                    {
                        if (!(ProcessList.GetMaterialList() == null))
                        {
                            for (int j = 0, loopTo = ProcessList.GetMaterialList().Count - 1; j <= loopTo; j++)
                            {
                                Application.DoEvents();
                                UserQuantity = 0L;
                                CurrentItemName = "";

                                // Look in table or in the paste list
                                if (!CutPasteUpdate)
                                {

                                    // Look up each item in their assets in their locations stored, and sum up the quantity'
                                    // Split into groups to run (1000 identifiers max so limit to 900)
                                    int Splits = (int)Math.Round(Math.Ceiling(AssetLocationFlagList.Count / 900d));
                                    for (int k = 0, loopTo1 = Splits - 1; k <= loopTo1; k++)
                                    {
                                        Application.DoEvents();
                                        string TempAssetWhereList = "";
                                        // Build the partial asset location id/flag list
                                        for (int z = k * 900, loopTo2 = (k + 1) * 900 - 1; z <= loopTo2; z++)
                                        {
                                            if (z == AssetLocationFlagList.Count)
                                            {
                                                // exit if we get to the end of the list
                                                break;
                                            }
                                            TempAssetWhereList = TempAssetWhereList + AssetLocationFlagList[z] + " OR ";
                                        }

                                        // Strip final OR
                                        TempAssetWhereList = TempAssetWhereList.Substring(0, Strings.Len(TempAssetWhereList) - 4);

                                        SQL = "SELECT typeName, SUM(Quantity) FROM ";
                                        SQL += "ASSETS, INVENTORY_TYPES ";
                                        SQL += "WHERE (" + TempAssetWhereList + ") ";
                                        SQL += " AND INVENTORY_TYPES.typeID = ASSETS.TypeID";
                                        SQL += " AND ASSETS.TypeID = " + ProcessList.GetMaterialList()[j].GetMaterialTypeID();
                                        SQL += " AND ID IN (" + IDString + ")";

                                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                                        readerAssets = Public_Variables.DBCommand.ExecuteReader();
                                        readerAssets.Read();

                                        if (readerAssets.HasRows & !(readerAssets.GetValue(1) is DBNull))
                                        {
                                            CurrentItemName = readerAssets.GetString(0);
                                            UserQuantity = UserQuantity + Conversions.ToLong(readerAssets.GetValue(1)); // sum up
                                        }

                                    }
                                }

                                else // Look up in pasted asset list
                                {
                                    Material TempMaterial;

                                    if (!(PasteMaterialList == null))
                                    {
                                        // The names in the pasted materials won't have the runs tag for built items so remove it before searching
                                        TempMaterial = PasteMaterialList.SearchListbyName(Public_Variables.RemoveItemNameRuns(ProcessList.GetMaterialList()[j].GetMaterialName()), false);

                                        if (!(TempMaterial == null))
                                        {
                                            // Found it
                                            CurrentItemName = TempMaterial.GetMaterialName();
                                            UserQuantity = TempMaterial.GetQuantity();
                                        }
                                    }
                                    else
                                    {
                                        CurrentItemName = "";
                                        UserQuantity = 0L;
                                    }

                                }

                                if (UserQuantity != 0L & !string.IsNullOrEmpty(CurrentItemName))
                                {
                                    // Call shoppinglist update numbers with new number
                                    switch (i)
                                    {
                                        case 0:
                                            {
                                                // Need to look up the full built item data, however only by name since we don't care how it was built if they already have it
                                                // plus we don't have the ME data anyway
                                                long ListQuantity = 0L;
                                                BuiltItemList TempBuiltList;

                                                // We could have multiple items in the list (because of different MEs), so loop through all of them and get the quantities on hand
                                                TempBuiltList = Public_Variables.TotalShoppingList.GetFullBuiltItemList().FindBuiltItems(CurrentItemName);

                                                for (int k = 0, loopTo3 = TempBuiltList.GetBuiltItemList().Count - 1; k <= loopTo3; k++)
                                                {
                                                    ListQuantity = TempBuiltList.GetBuiltItemList()[k].ItemQuantity;
                                                    if (ListQuantity <= UserQuantity)
                                                    {
                                                        // We found enough already to remove all for this built item, need to keep track and update the rest
                                                        UpdatedQuantity = ListQuantity;
                                                        var tmp = TempBuiltList.GetBuiltItemList();
                                                        var argSentItem = tmp[k];
                                                        Public_Variables.TotalShoppingList.UpdateShoppingBuiltItemQuantity(ref argSentItem, 0L);
                                                        tmp[k] = argSentItem;

                                                        // If the user wants to update the DB with materials they "used" here, update
                                                        if (chkUpdateAssetsWhenUsed.Checked)
                                                        {
                                                            UpdateUsedAssets(ProcessList.GetMaterialList()[j].GetMaterialTypeID(), UserQuantity, UpdatedQuantity);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // This list has more, so just remove the difference and leave
                                                        UpdatedQuantity = ListQuantity - UserQuantity;
                                                        var tmp1 = TempBuiltList.GetBuiltItemList();
                                                        var argSentItem1 = tmp1[k];
                                                        Public_Variables.TotalShoppingList.UpdateShoppingBuiltItemQuantity(ref argSentItem1, UpdatedQuantity);
                                                        tmp1[k] = argSentItem1;
                                                        // If the user wants to update the DB with materials they "used" here, update
                                                        if (chkUpdateAssetsWhenUsed.Checked)
                                                        {
                                                            UpdateUsedAssets(ProcessList.GetMaterialList()[j].GetMaterialTypeID(), UserQuantity, UpdatedQuantity);
                                                        }

                                                        break;
                                                    }
                                                }

                                                break;
                                            }

                                        case 1:
                                        case 2:
                                        case 3:
                                            {

                                                long UsedQuantity;
                                                UsedQuantity = ProcessList.GetMaterialList()[j].GetQuantity();

                                                // See what the new value is for setting the shopping list
                                                UpdatedQuantity = ProcessList.GetMaterialList()[j].GetQuantity() - UserQuantity;

                                                if (UpdatedQuantity < 0L)
                                                {
                                                    // We have more than this item requires, so zero out the quantity in the shopping list (delete)
                                                    UpdatedQuantity = 0L;
                                                }

                                                // Invention and RE are contained in Buy mats list
                                                Public_Variables.TotalShoppingList.UpdateShoppingBuyQuantity(ProcessList.GetMaterialList()[j].GetMaterialName(), UpdatedQuantity);

                                                // If the user wants to update the DB with materials they "used" here, update
                                                if (chkUpdateAssetsWhenUsed.Checked)
                                                {
                                                    UpdateUsedAssets(ProcessList.GetMaterialList()[j].GetMaterialTypeID(), UserQuantity, UsedQuantity);
                                                }

                                                break;
                                            }

                                    }
                                }
                            }
                        }
                    }
                }

                Application.UseWaitCursor = false;
                Cursor = Cursors.Default;
                Application.DoEvents();

                // Play notification sound
                Public_Variables.PlayNotifySound();

                // Refresh the updated lists
                RefreshLists();

                // Refresh the asset list with updated assets
                // If chkUpdateAssetsWhenUsed.Checked Then
                // ' First, need to refresh assets for character and corp if used
                // If Not IsNothing(frmShoppingAssets) Then
                // If Not frmShoppingAssets.IsDisposed Then
                // If frmShoppingAssets.rbtnAllAssets.Checked = True Or frmShoppingAssets.rbtnCorpAssets.Checked = True Then
                // SelectedCharacter.GetAssets.LoadAssets(SelectedCharacter.CharacterCorporation.CorporationID,
                // SelectedCharacter.CharacterTokenData, UserApplicationSettings.LoadAssetsonStartup)
                // Else ' Just personal
                // SelectedCharacter.GetAssets.LoadAssets(SelectedCharacter.ID, SelectedCharacter.CharacterTokenData,
                // UserApplicationSettings.LoadAssetsonStartup)
                // End If
                // 'frmShoppingAssets.RefreshTree()
                // End If
                // End If

                // If Not IsNothing(frmDefaultAssets) Then
                // If Not frmDefaultAssets.IsDisposed Then
                // If frmDefaultAssets.rbtnAllAssets.Checked = True Or frmDefaultAssets.rbtnCorpAssets.Checked = True Then
                // SelectedCharacter.GetAssets.LoadAssets(SelectedCharacter.CharacterCorporation.CorporationID,
                // SelectedCharacter.CharacterTokenData, UserApplicationSettings.LoadAssetsonStartup)
                // Else ' Just personal
                // SelectedCharacter.GetAssets.LoadAssets(SelectedCharacter.ID, SelectedCharacter.CharacterTokenData,
                // UserApplicationSettings.LoadAssetsonStartup)
                // End If
                // 'frmDefaultAssets.RefreshTree()
                // End If
                // End If
                // End If
                Application.DoEvents();
            }
            else
            {
                Interaction.MsgBox("You do not have an asset location selected", Constants.vbInformation, Application.ProductName);
                Application.UseWaitCursor = false;
                Cursor = Cursors.Default;
                Application.DoEvents();
            }

        }

        // Updates the assets table reflecting that you "used" the materials already in the shopping list
        private void UpdateUsedAssets(long MaterialTypeID, long UserQuantity, long UsedQuantity)
        {
            string SQL;
            string IDString = "";
            SQLiteDataReader readerAssets;
            long UsedQuantityRemaining = 0L;
            long LocUserQuantity = 0L;
            long LocationID = 0L;

            if (SettingsVariables.UserAssetWindowShoppingListSettings.AssetType == "Both")
            {
                IDString = Public_Variables.SelectedCharacter.ID.ToString() + "," + Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString();
            }
            else if (SettingsVariables.UserAssetWindowShoppingListSettings.AssetType == "Personal")
            {
                IDString = Public_Variables.SelectedCharacter.ID.ToString();
            }
            else if (SettingsVariables.UserAssetWindowShoppingListSettings.AssetType == "Corporation")
            {
                IDString = Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString();
            }

            if (UserQuantity <= UsedQuantity)
            {
                // Need to just delete the records because we are using everything we have in all locations
                SQL = "DELETE FROM ASSETS WHERE TypeID = " + MaterialTypeID + " AND LocationID IN";
                SQL += " (SELECT LocationID FROM ASSET_LOCATIONS WHERE EnumAssetType = " + ((int)AssetWindow.ShoppingList).ToString() + " AND ID IN (" + IDString + "))";
                SQL += " AND ID IN (" + IDString + ")";

                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
            }

            else // Only using part of what we have
            {
                // Look up each item in their assets in their locations stored, and loop through them
                SQL = "SELECT Quantity, LocationID FROM ASSETS, INVENTORY_TYPES WHERE LocationID IN";
                SQL += " (SELECT LocationID FROM ASSET_LOCATIONS WHERE EnumAssetType = " + ((int)AssetWindow.ShoppingList).ToString() + " AND ID IN (" + IDString + "))";
                SQL += " AND ID IN (" + IDString + ")";
                SQL += " AND INVENTORY_TYPES.typeID = ASSETS.TypeID";
                SQL += " AND ASSETS.TypeID = " + MaterialTypeID;
                SQL += " ORDER BY Quantity DESC";

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerAssets = Public_Variables.DBCommand.ExecuteReader();

                UsedQuantityRemaining = UsedQuantity;

                while (readerAssets.Read())
                {
                    LocUserQuantity = readerAssets.GetInt64(0);
                    LocationID = readerAssets.GetInt64(1);

                    // Keep track of what we need to update - we have more than we need to build this item, so need to update that total from our summed mins
                    if (LocUserQuantity > UsedQuantityRemaining)
                    {
                        // Whatever we have in this location is greater than the quantity remaining, so update this and leave loop
                        SQL = "UPDATE ASSETS SET Quantity = " + (LocUserQuantity - UsedQuantityRemaining);
                        SQL += " WHERE TypeID = " + MaterialTypeID + " AND LocationID = " + LocationID.ToString(); // Locid set above so it's good
                        SQL += " AND ID IN (" + IDString + ")";

                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                        break;
                    }
                    else
                    {
                        // Its less than or equal to the quantity so we need to delete this location's value and update the used quantity
                        SQL = "DELETE FROM ASSETS WHERE TypeID = " + MaterialTypeID + " AND LocationID = " + LocationID.ToString();
                        SQL += " AND ID IN (" + IDString + ")";
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                        // Update used quantity
                        UsedQuantityRemaining = UsedQuantityRemaining - LocUserQuantity;

                    }

                }

            }

        }

        // Close the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmShoppingList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Hide();
        }

        // Clears the lists and variables
        private void btnClear_Click(object sender, EventArgs e)
        {

            if (Interaction.MsgBox("Delete all items in the shopping list?", (MsgBoxStyle)((int)Constants.vbYesNo + (int)Constants.vbQuestion), Application.ProductName) == Constants.vbYes)
            {
                ClearLists();
                btnClear.Enabled = false;
                gbUpdateList.Enabled = false;
                Public_Variables.PlayNotifySound();
                My.MyProject.Forms.frmMain.pnlShoppingList.Text = "No Items in Shopping List";
                My.MyProject.Forms.frmMain.pnlShoppingList.ForeColor = Color.Black;
                lblTotalItemsInList.Text = "0" + Constants.vbCrLf + "Items in list";
            }

        }

        // Save the few settings on the form to xml
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            ShoppingListSettings TempList = default;
            var TempSettings = new ProgramSettings();

            TempList.AlwaysonTop = chkAlwaysOnTop.Checked;
            if (rbtnExportDefault.Checked)
            {
                TempList.DataExportFormat = rbtnExportDefault.Text;
            }
            else if (rbtnExportCSV.Checked)
            {
                TempList.DataExportFormat = rbtnExportCSV.Text;
            }
            else if (rbtnExportSSV.Checked)
            {
                TempList.DataExportFormat = rbtnExportSSV.Text;
            }
            else if (rbtnExportMulitBuy.Checked)
            {
                TempList.DataExportFormat = rbtnExportMulitBuy.Text;
            }
            TempList.UpdateAssetsWhenUsed = chkUpdateAssetsWhenUsed.Checked;
            TempList.Usage = chkUsage.Checked;
            TempList.Fees = chkFees.Checked;

            if (chkBuyorBuyOrder.CheckState == CheckState.Indeterminate)
            {
                TempList.CalcBuyBuyOrder = 2;
            }
            else if (chkBuyorBuyOrder.Checked == true)
            {
                TempList.CalcBuyBuyOrder = 1;
            }
            else
            {
                TempList.CalcBuyBuyOrder = 0;
            }

            TempList.ReloadBPsFromFile = chkRebuildItemsfromList.Checked;

            // Save the data in the XML file
            TempSettings.SaveShoppingListSettings(TempList);

            Interaction.MsgBox("Shopping List Settings Saved", Constants.vbInformation, Application.ProductName);
            Application.UseWaitCursor = false;

        }

        // Save the lists to file 
        private void btnSaveListToFile_Click(object sender, EventArgs e)
        {
            StreamWriter MyStream;
            string FileName;
            string OutputText;
            ListViewItem ListItem;
            ListView.ListViewItemCollection Items;

            // Show the dialog
            string ExportTypeString;
            string BuyListHeader;
            string BuildListHeader;
            string ItemsListHeader;
            string Separator;

            if (rbtnExportCSV.Checked)
            {
                // Save file name with date
                FileName = "Shopping List - " + Strings.Format(DateTime.Now, "MMddyyyy") + ".csv";
                ExportTypeString = Public_Variables.CSVDataExport;
                Separator = ",";
                BuyListHeader = BuyListHeaderCSV;
                BuildListHeader = BuildListHeaderCSV + BuildListHeaderCSVAdd;
                ItemsListHeader = ItemsListHeaderCSV + ItemsListHeaderCSVAdd;
                SaveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            }
            else if (rbtnExportSSV.Checked)
            {
                // Save file name with date
                FileName = "Shopping List - " + Strings.Format(DateTime.Now, "MMddyyyy") + ".ssv";
                ExportTypeString = Public_Variables.SSVDataExport;
                Separator = ";";
                BuyListHeader = BuyListHeaderSSV;
                BuildListHeader = BuildListHeaderSSV + BuildListHeaderSSVAdd;
                ItemsListHeader = ItemsListHeaderSSV + ItemsListHeaderSSVAdd;
                SaveFileDialog.Filter = "ssv files (*.ssv*)|*.ssv*|All files (*.*)|*.*";
            }
            else
            {
                // Save file name with date
                FileName = "Shopping List - " + Strings.Format(DateTime.Now, "MMddyyyy") + ".txt";
                ExportTypeString = Public_Variables.DefaultTextDataExport;
                Separator = "|";
                BuyListHeader = BuyListHeaderTXT;
                BuildListHeader = BuildListHeaderTXT + BuildListHeaderTXTAdd;
                ItemsListHeader = ItemsListHeaderTXT + ItemsListHeaderTXTAdd;
                SaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            }

            SaveFileDialog.FilterIndex = 1;
            SaveFileDialog.RestoreDirectory = true;
            SaveFileDialog.FileName = FileName;

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MyStream = File.CreateText(SaveFileDialog.FileName);

                    if (MyStream is not null)
                    {

                        // Output the buy list first
                        Items = lstBuy.Items;

                        if (Items.Count > 0)
                        {
                            Cursor = Cursors.WaitCursor;

                            Application.DoEvents();

                            OutputText = BuyListLabel;
                            MyStream.Write(OutputText + Environment.NewLine);
                            OutputText = BuyListHeader;
                            MyStream.Write(OutputText + Environment.NewLine);

                            foreach (ListViewItem currentListItem in Items)
                            {
                                ListItem = currentListItem;
                                Application.DoEvents();

                                // Build the output text 
                                if ((ExportTypeString ?? "") == Public_Variables.SSVDataExport)
                                {
                                    // Format to EU
                                    OutputText = ListItem.SubItems[1].Text + Separator;
                                    OutputText = OutputText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[2].Text) + Separator;
                                    OutputText = OutputText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[3].Text) + Separator;
                                    OutputText = OutputText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[4].Text) + Separator;
                                    OutputText = OutputText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[5].Text) + Separator;
                                    OutputText = OutputText + ListItem.SubItems[6].Text + Separator;
                                    OutputText = OutputText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[7].Text) + Separator;
                                    OutputText = OutputText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[8].Text) + Separator;
                                    OutputText = OutputText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[9].Text);
                                }
                                else
                                {
                                    OutputText = ListItem.SubItems[1].Text + Separator;
                                    OutputText = OutputText + Strings.Format(ListItem.SubItems[2].Text, "Fixed") + Separator;
                                    OutputText = OutputText + Strings.Format(ListItem.SubItems[3].Text, "Fixed") + Separator;
                                    OutputText = OutputText + Strings.Format(ListItem.SubItems[4].Text, "Fixed") + Separator;
                                    OutputText = OutputText + Strings.Format(ListItem.SubItems[5].Text, "Fixed") + Separator;
                                    OutputText = OutputText + ListItem.SubItems[6].Text + Separator;
                                    OutputText = OutputText + Strings.Format(ListItem.SubItems[7].Text, "Fixed") + Separator;
                                    OutputText = OutputText + Strings.Format(ListItem.SubItems[8].Text, "Fixed") + Separator;
                                    OutputText = OutputText + Strings.Format(ListItem.SubItems[9].Text, "Fixed");
                                }

                                MyStream.Write(OutputText + Environment.NewLine);
                            }

                        }

                        MyStream.Write("" + Environment.NewLine);

                        // Output the build list
                        Items = lstBuild.Items;

                        if (Items.Count > 0)
                        {
                            Cursor = Cursors.WaitCursor;

                            Application.DoEvents();

                            OutputText = BuildListLabel;
                            MyStream.Write(OutputText + Environment.NewLine);
                            OutputText = BuildListHeader;
                            MyStream.Write(OutputText + Environment.NewLine);

                            foreach (ListViewItem currentListItem1 in Items)
                            {
                                ListItem = currentListItem1;
                                Application.DoEvents();

                                // Build the output text for checked items
                                OutputText = Public_Variables.RemoveItemNameRuns(ListItem.SubItems[1].Text) + Separator;
                                if ((ExportTypeString ?? "") == Public_Variables.SSVDataExport)
                                {
                                    OutputText = OutputText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[2].Text) + Separator;
                                }
                                else
                                {
                                    OutputText = OutputText + Strings.Format(ListItem.SubItems[2].Text, "Fixed") + Separator;
                                }

                                OutputText = OutputText + ListItem.SubItems[3].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[4].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[5].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[6].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[7].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[8].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[9].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[11].Text; // production type (BPTypeID is index 10)

                                MyStream.Write(OutputText + Environment.NewLine);
                            }

                        }

                        MyStream.Write("" + Environment.NewLine);

                        // Output the item list
                        Items = lstItems.Items;

                        if (Items.Count > 0)
                        {
                            Cursor = Cursors.WaitCursor;

                            Application.DoEvents();
                            string TempName = "";
                            string TempRelic = "";

                            OutputText = ItemsListLabel;
                            MyStream.Write(OutputText + Environment.NewLine);
                            OutputText = ItemsListHeader;
                            MyStream.Write(OutputText + Environment.NewLine);

                            foreach (ListViewItem currentListItem2 in Items)
                            {
                                ListItem = currentListItem2;
                                Application.DoEvents();

                                if (ListItem.SubItems[1].Text.Contains("("))
                                {
                                    TempName = ListItem.SubItems[1].Text.Substring(0, Strings.InStr(ListItem.SubItems[1].Text, "(") - 2);
                                    TempRelic = ListItem.SubItems[1].Text.Substring(Strings.InStr(ListItem.SubItems[1].Text, "("), Strings.InStr(ListItem.SubItems[1].Text, ")") - Strings.InStr(ListItem.SubItems[1].Text, "(") - 1);
                                }
                                else
                                {
                                    TempName = ListItem.SubItems[1].Text;
                                    TempRelic = "";
                                }

                                // Build the output text for checked items
                                OutputText = TempName + Separator;
                                if ((ExportTypeString ?? "") == Public_Variables.SSVDataExport)
                                {
                                    OutputText = OutputText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[2].Text) + Separator;
                                }
                                else
                                {
                                    OutputText = OutputText + Strings.Format(ListItem.SubItems[2].Text, "Fixed") + Separator;
                                }
                                OutputText = OutputText + ListItem.SubItems[3].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[4].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[5].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[6].Text + Separator;
                                OutputText = OutputText + TempRelic + Separator;
                                OutputText = OutputText + ListItem.SubItems[8].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[7].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[9].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[10].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[11].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[12].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[13].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[14].Text + Separator;
                                OutputText = OutputText + ListItem.SubItems[16].Text; // Facility build type (TE is index 15)

                                MyStream.Write(OutputText + Environment.NewLine);
                            }

                        }

                        MyStream.Flush();
                        MyStream.Close();

                        Interaction.MsgBox("Shopping List Saved", Constants.vbInformation, Application.ProductName);

                    }
                }
                catch
                {
                    Interaction.MsgBox(Information.Err().Description, Constants.vbExclamation, Application.ProductName);
                }
            }

            // Done processing 
            Cursor = Cursors.Default;
            Refresh();
            Application.DoEvents();

        }

        // Load the lists from file 
        private void btnLoadListFromFile_Click(object sender, EventArgs e)
        {

            // Logic - import the lists, rebuild all blueprints with parameters listed in the items list
            // then read through just the items and quantities and run the updates if they are not the same
            // this will allow users to make any changes and save them to be reloaded later
            StreamReader BPStream = null;
            var openFileDialog1 = new OpenFileDialog();
            string Line;
            string CurrentList = "";
            Blueprint TempBP = null;
            SQLiteDataReader readerBP;
            string SQL;

            // Import Lists
            var BuyList = new List<ItemQuantityType>();
            var BuildList = new List<BuildQuantity>();
            var ItemList = new List<BPItem>();
            ItemQuantityType TempItem;
            BuildQuantity TempBuildItem;
            BPItem TempBPItem;
            string Separator = "";

            string BuyListHeader;
            string BuildListHeader;
            string ItemsListHeader;
            string ItemsListHeaderAdd;

            // To save the old shopping list in case of an error and to reload
            ShoppingList SavedShoppingList = (ShoppingList)Public_Variables.TotalShoppingList.Clone();

            // For cloning to update
            var ClonedBuyList = new Materials();
            var ClonedBuildList = new BuiltItemList();

            // openFileDialog1.InitialDirectory = "c:\"
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|ssv files (*.ssv*)|*.ssv*|txt files (*.txt*)|*.txt*|All files (*.*)|*.*";
            if (rbtnExportSSV.Checked == true)
            {
                openFileDialog1.FileName = "*.ssv";
                Separator = ";";
                BuyListHeader = BuyListHeaderSSV;
                BuildListHeader = BuildListHeaderSSV;
                ItemsListHeader = ItemsListHeaderSSV;
                ItemsListHeaderAdd = ItemsListHeaderSSV + ItemsListHeaderSSVAdd;
            }
            else if (rbtnExportCSV.Checked == true)
            {
                openFileDialog1.FileName = "*.csv";
                Separator = ",";
                BuyListHeader = BuyListHeaderCSV;
                BuildListHeader = BuildListHeaderCSV;
                ItemsListHeader = ItemsListHeaderCSV;
                ItemsListHeaderAdd = ItemsListHeaderCSV + ItemsListHeaderCSVAdd;
            }
            else
            {
                openFileDialog1.FileName = "*.txt";
                Separator = "|";
                BuyListHeader = BuyListHeaderTXT;
                BuildListHeader = BuildListHeaderTXT;
                ItemsListHeader = ItemsListHeaderTXT;
                ItemsListHeaderAdd = ItemsListHeaderTXT + ItemsListHeaderTXTAdd;
            }

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BPStream = new StreamReader(openFileDialog1.FileName);

                    if (BPStream is not null)
                    {
                        Application.UseWaitCursor = true;

                        // Clear the old list - adding to an existing list is a bit of work, so just make this a requirement
                        ClearLists();

                        // Read the file line by line here, start with headers
                        Line = BPStream.ReadLine();

                        while (Line is not null)
                        {
                            Application.DoEvents();

                            // If you save a CSV in Excel, it'll put in extra commas - check and remove
                            if (Line.Contains(BuyListLabel))
                            {
                                CurrentList = BuyListLabel;
                                Line = Line.Replace(",", "");
                            }
                            else if (Line.Contains(BuildListLabel))
                            {
                                CurrentList = BuildListLabel;
                                Line = Line.Replace(",", "");
                            }
                            else if (Line.Contains(ItemsListLabel))
                            {
                                CurrentList = ItemsListLabel;
                                Line = Line.Replace(",", "");
                            }

                            // If the line has records, import it into the correct lists
                            if (Line.Contains(Separator) & !(Line.Contains(BuyListHeader) | Line.Contains(BuildListHeader) | Line.Contains(ItemsListHeader) | Line.Contains(ItemsListHeaderAdd)))
                            {
                                // Parse the line
                                string[] Record;

                                // Set the split records
                                if (Separator == ";")
                                {
                                    // To properly process, need to replace swap all the commas and periods
                                    // For R.A.M.'s, special processing
                                    if (Line.Substring(0, 6) == "R.A.M.")
                                    {
                                        Line = "R.A.M." + Line.Substring(6).Replace(".", ""); // Just replace the periods as they are commas for numbers, which aren't needed, after the R.A.M.
                                    }
                                    else if (Line.Substring(0, 4) == "R.Db")
                                    {
                                        Line = "R.Db" + Line.Substring(3).Replace(".", ""); // Just replace the periods as they are commas for numbers, which aren't needed, after the R.Db
                                    }
                                    else
                                    {
                                        Line = Line.Replace(".", "");
                                    } // Just replace the periods as they are commas for numbers, which aren't needed
                                    Line = Line.Replace(",", ".");
                                    Record = Line.Split(new char[] { ';' });
                                }
                                else if (Separator == ",")
                                {
                                    Record = Line.Split(new char[] { ',' });
                                }
                                else
                                {
                                    Record = Line.Split(new char[] { '|' });
                                }

                                // Make sure the record has a name
                                if (!string.IsNullOrEmpty(Strings.Trim(Record[0])))
                                {
                                    // Import the current list
                                    switch (CurrentList ?? "")
                                    {
                                        case BuyListLabel:
                                            {
                                                // Buy List Format: Material, Quantity, Cost Per Item, Buy Type, Total m3, Isk/m3, TotalCost
                                                // Add just the name and quantity to the list for checking later
                                                TempItem = new ItemQuantityType();
                                                TempItem.ItemName = Record[0];
                                                if (string.IsNullOrEmpty(Strings.Trim(Record[1])))
                                                {
                                                    TempItem.ItemQuantity = 1L; // Blank is one item (unpackaged)
                                                }
                                                else
                                                {
                                                    TempItem.ItemQuantity = Conversions.ToLong(Record[1]);
                                                }
                                                BuyList.Add(TempItem);
                                                break;
                                            }
                                        case BuildListLabel:
                                            {
                                                // Build List Format: Build Item, Quantity, ME, added later (TE, Facility Location, Facility Type)
                                                // Add just the name and quantity to the list for checking later
                                                TempBuildItem = new BuildQuantity();
                                                TempBuildItem.ItemName = Record[0];
                                                if (string.IsNullOrEmpty(Strings.Trim(Record[1])))
                                                {
                                                    TempBuildItem.ItemQuantity = 1L; // Blank is one item (unpackaged)
                                                }
                                                else
                                                {
                                                    TempBuildItem.ItemQuantity = Conversions.ToLong(Record[1]);
                                                }
                                                TempBuildItem.ItemME = Conversions.ToInteger(Record[2]);

                                                if (Record.Count() > 3)
                                                {
                                                    TempBuildItem.ItemTE = Conversions.ToInteger(Record[3]);
                                                    TempBuildItem.FacilityLocation = Record[4];
                                                    TempBuildItem.FacilityType = Record[5];
                                                    TempBuildItem.FacilityBuildType = (ProductionType)Conversions.ToInteger(Record[9]);
                                                    TempBuildItem.IncludeActivityCost = Conversions.ToBoolean(Record[6]);
                                                    TempBuildItem.IncludeActivityTime = Conversions.ToBoolean(Record[7]);
                                                    TempBuildItem.IncludeActivityUsage = Conversions.ToBoolean(Record[8]);
                                                }
                                                else
                                                {
                                                    TempBuildItem.ItemTE = 0;
                                                    TempBuildItem.FacilityLocation = "";
                                                    TempBuildItem.FacilityType = "";
                                                    TempBuildItem.FacilityBuildType = ProductionType.None;
                                                    TempBuildItem.IncludeActivityCost = true;
                                                    TempBuildItem.IncludeActivityTime = true;
                                                    TempBuildItem.IncludeActivityUsage = true;
                                                }

                                                BuildList.Add(TempBuildItem);
                                                break;
                                            }

                                        case ItemsListLabel:
                                            {
                                                // Item List Format: Item, Quantity, ME, NumBps, Build Type, Decryptor, Relic, 
                                                // Facility Type, Location, IgnoredInvention, IgnoredMinerals, IgnoredT1BaseItem, 
                                                // IncludeActivityCost, IncludeActivityTime, IncludeUsageCost

                                                // Save all the fields
                                                TempItem = new ItemQuantityType();
                                                TempBPItem.ItemName = Record[0];
                                                if (string.IsNullOrEmpty(Strings.Trim(Record[1])))
                                                {
                                                    TempBPItem.ItemQuantity = 1L; // Blank is one item (unpackaged)
                                                }
                                                else
                                                {
                                                    TempBPItem.ItemQuantity = Conversions.ToLong(Record[1]);
                                                }
                                                TempBPItem.ItemME = Conversions.ToInteger(Record[2]);
                                                TempBPItem.NumBPs = Conversions.ToInteger(Record[3]);
                                                TempBPItem.BuildType = Record[4];
                                                TempBPItem.Decryptor = Record[5];
                                                TempBPItem.Relic = Record[6];

                                                // Facility stuff
                                                TempBPItem.FacilityType = Record[7];
                                                TempBPItem.FacilityBuildType = (ProductionType)Conversions.ToInteger(Record[15]);
                                                TempBPItem.BuildLocation = Record[8];
                                                TempBPItem.IgnoredInvention = Conversions.ToBoolean(Record[9]);
                                                TempBPItem.IgnoredMinerals = Conversions.ToBoolean(Record[10]);
                                                TempBPItem.IgnoredT1BaseItem = Conversions.ToBoolean(Record[11]);
                                                TempBPItem.IncludeActivityCost = Conversions.ToBoolean(Record[12]);
                                                TempBPItem.IncludeActivityTime = Conversions.ToBoolean(Record[13]);
                                                TempBPItem.IncludeActivityUsage = Conversions.ToBoolean(Record[14]);

                                                ItemList.Add(TempBPItem);
                                                break;
                                            }
                                    }
                                }
                            }

                            Line = BPStream.ReadLine(); // Read next line

                        }

                        // We need to build the blueprints and adjust the final lists unless they want it to go right into as is
                        for (int i = 0, loopTo = ItemList.Count - 1; i <= loopTo; i++)
                        {
                            // Get the decryptor
                            var TempDecryptor = new Decryptor();
                            bool BuildBuy;
                            var InventionDecryptors = new DecryptorList();

                            var TempBuildFacility = new IndustryFacility();
                            var TempCompFacility = new IndustryFacility();
                            var TempCapCompFacility = new IndustryFacility();
                            var TempReactionFacility = new IndustryFacility();

                            TempDecryptor = InventionDecryptors.GetDecryptor(ItemList[i].Decryptor);

                            if (ItemList[i].BuildType == "Build/Buy")
                            {
                                BuildBuy = true;
                            }
                            else
                            {
                                BuildBuy = false;
                            }

                            // Load the default facility type in the DB based on what they save, don't do anything special
                            if (!string.IsNullOrEmpty(ItemList[i].BuildLocation))
                            {
                                TempBuildFacility = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ItemList[i].FacilityBuildType);
                            }
                            else
                            {
                                // Can't do anything else with this
                                throw new Exception("No Facility Name in File");
                            }

                            // Set the component facilities 
                            TempCompFacility = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.ComponentManufacturing);
                            TempCapCompFacility = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.CapitalComponentManufacturing);
                            TempReactionFacility = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.Reactions);

                            // Look up BP data
                            SQL = "SELECT BLUEPRINT_ID, TECH_LEVEL, ITEM_GROUP_ID, ITEM_CATEGORY_ID FROM ALL_BLUEPRINTS WHERE ITEM_NAME = '" + Public_Variables.FormatDBString(ItemList[i].ItemName) + "'";

                            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                            readerBP = Public_Variables.DBCommand.ExecuteReader();
                            readerBP.Read();

                            // Build the Item - use everything we can from file import
                            List<Public_Variables.BuildBuyItem> argBuildBuyList = null;
                            IndustryFacility argBPReprocessingFacility = null;
                            TempBP = new Blueprint(readerBP.GetInt32(0), ItemList[i].ItemQuantity, ItemList[i].ItemME, 0, ItemList[i].NumBPs, 1, Public_Variables.SelectedCharacter, SettingsVariables.UserApplicationSettings, BuildBuy, 0d, TempBuildFacility, TempCompFacility, TempCapCompFacility, TempReactionFacility, SettingsVariables.UserBPTabSettings.SellExcessBuildItems, SettingsVariables.UserBPTabSettings.BuildT2T3Materials, true, BuildBuyList: ref argBuildBuyList, BPReprocessingFacility: ref argBPReprocessingFacility);

                            // See if we invent, use selected BP facilities for invention
                            if (readerBP.GetInt32(1) != 1 & !ItemList[i].IgnoredInvention)
                            {
                                int MaximumLaboratoryLines = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3406L) + Public_Variables.SelectedCharacter.Skills.GetSkillLevel(24624L) + 1;
                                var TIF = new IndustryFacility();
                                if (readerBP.GetInt32(1) == 2)
                                {
                                    TIF = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.Invention);
                                }
                                else
                                {
                                    // T3
                                    TIF = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.T3Invention);
                                }
                                TempBP.InventBlueprint(MaximumLaboratoryLines, TempDecryptor, TIF, My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.Copying), Public_Variables.GetInventItemTypeID(Conversions.ToLong(readerBP.GetValue(0)), ItemList[i].Relic));
                            }

                            // Build the item and get the list of materials
                            TempBP.BuildItems(My.MyProject.Forms.frmMain.chkBPTaxes.Checked, Public_Variables.GetBrokerFeeData(My.MyProject.Forms.frmMain.chkBPBrokerFees, My.MyProject.Forms.frmMain.txtBPBrokerFeeRate), false, ItemList[i].IgnoredMinerals, ItemList[i].IgnoredT1BaseItem);

                            // Now that all the lists are loaded, load what we need 
                            if (chkRebuildItemsfromList.Checked == false)
                            {
                                var NewBPRawMats = new Materials();
                                var NewBPComponentMats = new Materials();
                                var NewBPInventionMats = new Materials();
                                var NewBPCopyMats = new Materials();
                                var NewBPBuildList = new BuiltItemList();

                                // Need to only load the items that were in the original list - adjust the mats in each bp list
                                for (int j = 0, loopTo1 = BuyList.Count - 1; j <= loopTo1; j++)
                                {
                                    // See if the buy list items are in the list
                                    var FoundMat = TempBP.GetRawMaterials().SearchListbyName(BuyList[j].ItemName);
                                    if (!(FoundMat == null))
                                    {
                                        // Found so add to temp lists
                                        FoundMat.SetQuantity(BuyList[j].ItemQuantity);
                                        NewBPRawMats.InsertMaterial(FoundMat);
                                    }

                                    // Component mats list
                                    FoundMat = TempBP.GetComponentMaterials().SearchListbyName(BuyList[j].ItemName);
                                    if (!(FoundMat == null))
                                    {
                                        // Found so add to temp lists
                                        FoundMat.SetQuantity(BuyList[j].ItemQuantity);
                                        NewBPComponentMats.InsertMaterial(FoundMat);
                                    }

                                    // Look at the Invention lists and copy lists
                                    FoundMat = TempBP.GetInventionMaterials().SearchListbyName(BuyList[j].ItemName);
                                    if (!(FoundMat == null))
                                    {
                                        // Found so add to temp lists
                                        FoundMat.SetQuantity(BuyList[j].ItemQuantity);
                                        NewBPInventionMats.InsertMaterial(FoundMat);
                                    }

                                    FoundMat = TempBP.GetCopyMaterials().SearchListbyName(BuyList[j].ItemName);
                                    if (!(FoundMat == null))
                                    {
                                        // Found so add to temp lists
                                        FoundMat.SetQuantity(BuyList[j].ItemQuantity);
                                        NewBPCopyMats.InsertMaterial(FoundMat);
                                    }
                                }

                                // Now look at the Build list
                                for (int j = 0, loopTo2 = BuildList.Count - 1; j <= loopTo2; j++)
                                {
                                    // See if the buy list items are in the list
                                    var FoundItems = TempBP.GetComponentsList().FindBuiltItems(BuildList[j].ItemName);
                                    if (!(FoundItems == null))
                                    {
                                        // Found so add to temp lists
                                        for (int k = 0, loopTo3 = FoundItems.GetBuiltItemList().Count - 1; k <= loopTo3; k++)
                                        {
                                            FoundItems.GetBuiltItemList()[k].ItemQuantity = BuildList[j].ItemQuantity;
                                            NewBPBuildList.AddBuiltItem(FoundItems.GetBuiltItemList()[k]);
                                        }

                                    }
                                }

                                // Reset lists based on what was in the file before adding to shopping list
                                TempBP.RawMaterials = NewBPRawMats;
                                TempBP.ComponentMaterials = NewBPComponentMats;
                                TempBP.BuiltComponentList = NewBPBuildList;
                                TempBP.CopyMaterials = NewBPCopyMats;
                                TempBP.InventionMaterials = NewBPInventionMats;

                            }

                            // Add to shopping list but use BP tab settings
                            Public_Variables.AddToShoppingList(TempBP, BuildBuy, My.MyProject.Forms.frmMain.rbtnBPRawmatCopy.Checked, TempBuildFacility, ItemList[i].IgnoredInvention, ItemList[i].IgnoredMinerals, ItemList[i].IgnoredT1BaseItem);
                            readerBP.Close();

                        }

                        Application.UseWaitCursor = false;
                        // Now load all the lists
                        RefreshLists();

                        // Mark as items in list
                        My.MyProject.Forms.frmMain.pnlShoppingList.Text = "Items in Shopping List";
                        My.MyProject.Forms.frmMain.pnlShoppingList.ForeColor = Color.Red;

                        Interaction.MsgBox("Shopping List Loaded", Constants.vbInformation, Application.ProductName);

                    }
                }

                catch (Exception Ex)
                {
                    // Error'd so restore old shopping list
                    Public_Variables.TotalShoppingList = (ShoppingList)SavedShoppingList.Clone();
                    Application.UseWaitCursor = false;
                    MessageBox.Show("Cannot load shopping list - Error: " + Ex.Message);
                }
                finally
                {
                    // Check this again, since we need to make sure we didn't throw an exception on open.
                    if (BPStream is not null)
                    {
                        BPStream.Close();
                    }
                }
            }

            Application.UseWaitCursor = false;
            Application.DoEvents();

        }

        private bool FindFacility(IndustryFacility SentFacility)
        {
            if ((FacilityToFind.FacilityName ?? "") == (SentFacility.FacilityName ?? "") & FacilityToFind.FacilityProductionType == SentFacility.FacilityProductionType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Copy's data shown and exports it to clipboard
        private void btnCopy_Click(object sender, EventArgs e)
        {
            var ClipboardData = new DataObject();
            string[] MatList;
            string[] BuildList;
            string[] ItemList;

            int i;

            // Get the order of the list of items that they set up by clicking on the columns - They could sort on any column so focus on unique columns to sort
            MatList = new string[lstBuy.Items.Count];
            BuildList = new string[lstBuild.Items.Count];
            ItemList = new string[lstItems.Items.Count];

            i = 0;
            // Material sort order - Just Name
            foreach (ListViewItem item in lstBuy.Items)
            {
                MatList[i] = item.SubItems[1].Text;
                i += 1;
            }

            i = 0;
            // Build item sort order - Name, Quantity, and ME
            foreach (ListViewItem item in lstBuild.Items)
            {
                BuildList[i] = item.SubItems[1].Text + "|" + item.SubItems[2].Text + "|" + item.SubItems[3].Text;
                i += 1;
            }

            i = 0;
            // List Item sort order Name, Quantity, ME, Num BPs, Build Type, Decryptor, Location
            foreach (ListViewItem item in lstItems.Items)
            {
                ItemList[i] = item.SubItems[1].Text + "|" + item.SubItems[2].Text + "|" + item.SubItems[3].Text + "|" + item.SubItems[4].Text + "|" + item.SubItems[5].Text + "|" + item.SubItems[6].Text + "|" + item.SubItems[7].Text;
                i += 1;
            }

            string ExportTypeString;

            if (rbtnExportCSV.Checked)
            {
                ExportTypeString = Public_Variables.CSVDataExport;
            }
            else if (rbtnExportSSV.Checked)
            {
                ExportTypeString = Public_Variables.SSVDataExport;
            }
            else if (rbtnExportMulitBuy.Checked)
            {
                ExportTypeString = Public_Variables.MultiBuyDataExport;
            }
            else
            {
                ExportTypeString = Public_Variables.DefaultTextDataExport;
            }

            // Paste to clipboard
            Public_Variables.CopyTextToClipboard(Public_Variables.TotalShoppingList.GetClipboardList(ExportTypeString, true, MatList, ItemList, BuildList, SettingsVariables.UserApplicationSettings.IncludeInGameLinksinCopyText));

        }

        private void btnShowAssets_Click(object sender, EventArgs e)
        {
            // Make sure it's not disposed
            if (Public_Variables.frmShoppingAssets == null)
            {
                // Make new form
                Public_Variables.frmShoppingAssets = new frmAssetsViewer(AssetWindow.ShoppingList);
            }
            else if (Public_Variables.frmShoppingAssets.IsDisposed)
            {
                // Make new form
                Public_Variables.frmShoppingAssets = new frmAssetsViewer(AssetWindow.ShoppingList);
            }

            // Now open the Asset List
            Public_Variables.frmShoppingAssets.Show();
            Public_Variables.frmShoppingAssets.Focus();

            Application.DoEvents();

        }

        private void chkFees_CheckedChanged(object sender, EventArgs e)
        {
            if (!Public_Variables.FirstLoad)
            {
                if (chkFees.Checked == false)
                {
                    // Disable calc buy order type - since they aren't going to apply fees, we can't calculate it
                    chkBuyorBuyOrder.Enabled = false;
                }
                else
                {
                    chkBuyorBuyOrder.Enabled = true;
                }
                // Reload the list
                LoadBuyList();
                LoadFormStats();
            }
        }

        private void chkBuyorBuyOrder_Click(object sender, EventArgs e)
        {
            if (!Public_Variables.FirstLoad)
            {
                // Reload the list
                LoadBuyList();
                LoadFormStats();
            }
        }

        private void chkUsage_CheckedChanged(object sender, EventArgs e)
        {
            if (!Public_Variables.FirstLoad)
            {
                LoadFormStats();
            }
        }

        private void txtAddlCosts_GotFocus(object sender, EventArgs e)
        {
            txtAddlCosts.SelectAll();
        }

        private void txtAddlCosts_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtAddlCosts, e);
            if (AddlCostsValidEntry())
            {
                if (e.KeyCode == Keys.Enter)
                {
                    LoadFormStats();
                    txtAddlCosts.Focus();
                }
            }
        }

        private void txtAddlCosts_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedPriceChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtAddlCosts_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Strings.Trim(txtAddlCosts.Text)))
            {
                txtAddlCosts.Text = "0.00";
                LoadFormStats();
            }
            else if (Information.IsNumeric(txtAddlCosts.Text))
            {
                txtAddlCosts.Text = Strings.FormatNumber(txtAddlCosts.Text, 2);
                LoadFormStats();
            }
            else
            {
                Interaction.MsgBox("Invalid Additional Costs Entry", Constants.vbExclamation, Application.ProductName);
                txtAddlCosts.Focus();
            }
        }

        private bool AddlCostsValidEntry()
        {
            if (string.IsNullOrEmpty(Strings.Trim(txtAddlCosts.Text)))
            {
                // Reset to 0
                txtAddlCosts.Text = "0.00";
            }

            if (Information.IsNumeric(txtAddlCosts.Text))
            {
                return true;
            }
            else
            {
                Interaction.MsgBox("Invalid Additional Costs Entry", Constants.vbExclamation, Application.ProductName);
                txtAddlCosts.Focus();
                return false;
            }
        }

        private void chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlwaysOnTop.Checked)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        private void btnCopyPasteAssets_Click(object sender, EventArgs e)
        {
            var f1 = new frmCopyandPaste(Public_Variables.CopyPasteWindowType.Materials, Public_Variables.CopyPasteWindowLocation.Assets);

            f1.ShowDialog();

            // Update with new materials
            if (!string.IsNullOrEmpty(CopyPasteMaterialText))
            {
                CutPasteUpdate = true;
                UpdateShoppingListwithAssets(Public_Variables.ImportCopyPasteText(CopyPasteMaterialText));
                // Refresh lists
                RefreshLists();
            }

            // Clear what they entered
            CopyPasteMaterialText = "";

            CutPasteUpdate = false;

            f1.Dispose();

        }

        private void lstBuild_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView argRefListView = lstBuild;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref BuildListColumnClicked, ref BuildListColumnSortOrder);
        }

        // Don't allow the first column to show with resize
        private void lstBuild_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 0 | e.ColumnIndex > 4)
            {
                e.Cancel = true;
                e.NewWidth = lstItems.Columns[e.ColumnIndex].Width;
            }
        }

        // Double Click build and load the blueprint for the component they clicked
        private void lstBuild_DoubleClick(object sender, EventArgs e)
        {
            SQLiteDataReader rsBPLookup;
            string SQL;

            if (lstBuild.SelectedItems.Count != 0)
            {
                SQL = "SELECT BLUEPRINT_ID, PORTION_SIZE FROM ALL_BLUEPRINTS WHERE ITEM_ID = " + lstBuild.SelectedItems[0].SubItems[0].Text;

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsBPLookup = Public_Variables.DBCommand.ExecuteReader();
                rsBPLookup.Read();

                int Runs = (int)Math.Round(Math.Ceiling(Conversions.ToInteger(lstBuild.SelectedItems[0].SubItems[2].Text) / (double)rsBPLookup.GetInt64(1)));

                Public_Variables.BrokerFeeInfo BFI;
                BFI.IncludeFee = (Public_Variables.BrokerFeeType)SettingsVariables.UserBPTabSettings.IncludeFees;
                BFI.FixedRate = SettingsVariables.UserBPTabSettings.BrokerFeeRate;

                My.MyProject.Forms.frmMain.LoadBPfromEvent(rsBPLookup.GetInt64(0), "Raw", Public_Variables.None, Public_Variables.SentFromLocation.ShoppingList, null, null, null, null, null, SettingsVariables.UserBPTabSettings.IncludeTaxes, BFI, lstBuild.SelectedItems[0].SubItems[3].Text, lstBuild.SelectedItems[0].SubItems[4].Text, Runs.ToString(), "1", SettingsVariables.UserBPTabSettings.LaboratoryLines.ToString(), "1", txtAddlCosts.Text, false); // Any buildable component here is one 1 bp

                rsBPLookup.Close();
            }

        }

        private void lstItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView argRefListView = lstItems;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref ItemListColumnClicked, ref ItemListColumnSortOrder);
        }

        // Turn off resizing for the last 4 columns
        private void lstItems_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex >= 8 | e.ColumnIndex == 0)
            {
                e.Cancel = true;
                e.NewWidth = lstItems.Columns[e.ColumnIndex].Width;
            }
        }

        // Double Click build and load the blueprint for the item they clicked
        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            string InputDecryptor = "";
            string InputRelic = "";
            string Inputs = Public_Variables.None;
            Material TempMaterial = null;
            SQLiteDataReader rsBPLookup;
            string SQL;

            // Check Decryptor
            if (!string.IsNullOrEmpty(lstItems.SelectedItems[0].SubItems[5].Text))
            {
                InputDecryptor = lstItems.SelectedItems[0].SubItems[6].Text;
            }

            // Check for relic
            if (lstItems.SelectedItems[0].SubItems[1].Text.Contains("("))
            {
                {
                    var withBlock = lstItems.SelectedItems[0].SubItems[1];
                    InputRelic = withBlock.Text.Substring(Strings.InStr(withBlock.Text, "("), Strings.InStr(withBlock.Text, ")") - Strings.InStr(withBlock.Text, "(") - 1);
                }
            }

            if (!string.IsNullOrEmpty(InputDecryptor) & !string.IsNullOrEmpty(InputRelic))
            {
                Inputs = InputDecryptor + "|" + InputRelic;
            }
            else if (!string.IsNullOrEmpty(InputRelic))
            {
                Inputs = InputRelic;
            }
            else if (!string.IsNullOrEmpty(InputDecryptor))
            {
                Inputs = InputDecryptor;
            }
            else
            {
                Inputs = "";
            }

            SQL = "SELECT BLUEPRINT_ID FROM ALL_BLUEPRINTS WHERE ITEM_ID = " + lstItems.SelectedItems[0].SubItems[0].Text;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsBPLookup = Public_Variables.DBCommand.ExecuteReader();
            rsBPLookup.Read();

            Public_Variables.BrokerFeeInfo BFI;
            BFI.IncludeFee = (Public_Variables.BrokerFeeType)SettingsVariables.UserBPTabSettings.IncludeFees;
            BFI.FixedRate = SettingsVariables.UserBPTabSettings.BrokerFeeRate;

            // Get the decryptor or relic used from the item
            My.MyProject.Forms.frmMain.LoadBPfromEvent(Conversions.ToLong(rsBPLookup.GetValue(0)), lstItems.SelectedItems[0].SubItems[5].Text, Inputs, Public_Variables.SentFromLocation.ShoppingList, null, null, null, null, null, SettingsVariables.UserBPTabSettings.IncludeTaxes, BFI, lstItems.SelectedItems[0].SubItems[3].Text, lstItems.SelectedItems[0].SubItems[15].Text, lstItems.SelectedItems[0].SubItems[2].Text, "1", SettingsVariables.UserBPTabSettings.LaboratoryLines.ToString(), lstItems.SelectedItems[0].SubItems[4].Text, txtAddlCosts.Text, false);
        }

        private void lstBuy_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView argRefListView = lstBuy;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref BuyListColumnClicked, ref BuyListColumnSortOrder);
        }

        private void lstBuild_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteBuilds();
            }
        }

        // Don't allow resizing of the first oclumn (hidden)
        private void lstBuy_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Cancel = true;
                e.NewWidth = lstItems.Columns[e.ColumnIndex].Width;
            }
        }

        private void lstBuy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteMaterials();
            }
        }

        private void lstItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteItems();
            }
        }

        // Add or take away tax from the total items from total and refresh prices
        private void chkTotalItemTax_CheckedChanged(object sender, EventArgs e)
        {
            if (!Public_Variables.FirstLoad)
            {
                LoadFormStats();
            }
        }

        // Add or take away brokers fees from the total items from total and refresh prices
        private void chkTotalItemFees_CheckedChanged(object sender, EventArgs e)
        {
            if (!Public_Variables.FirstLoad)
            {
                LoadFormStats();
            }
        }

        #region Delete list items

        // Checks to see if we have any items left and resets the lists and panel on frmmain and refreshes the lists
        private void ReloadListsafterDelete()
        {

            // Just deleted, so notify
            Public_Variables.PlayNotifySound();

            // Check the total items in the list, if we delete all the materials, we aren't building anything anymore
            if (Public_Variables.TotalShoppingList.GetFullBuyList() == null | Public_Variables.TotalShoppingList.GetNumShoppingItems() == 0L)
            {
                ClearLists();
            }

            // Refresh grids
            RefreshLists();

            Application.DoEvents();

        }

        private void DeleteItemStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (lstItems.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }

            // Change the name of the strip to allow for multiple mat selection
            if (lstItems.SelectedItems.Count > 1)
            {
                DeleteItem.Text = "Delete Items";
            }
            else
            {
                DeleteItem.Text = "Delete Item";
            }

        }

        private void DeleteMaterialStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (lstBuy.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }

            // Change the name of the strip to allow for multiple mat selection
            if (lstBuy.SelectedItems.Count > 1)
            {
                DeleteMaterial.Text = "Delete Materials";
            }
            else
            {
                DeleteMaterial.Text = "Delete Material";
            }

        }

        private void DeleteBuildStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (lstBuild.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }

            // Change the name of the strip to allow for multiple mat selection
            if (lstBuild.SelectedItems.Count > 1)
            {
                DeleteMaterial.Text = "Delete Build Items";
            }
            else
            {
                DeleteMaterial.Text = "Delete Build Item";
            }

        }

        private void DeleteItemStrip_Click(object sender, EventArgs e)
        {
            DeleteItems();
        }

        private void DeleteMaterialStrip_Click(object sender, EventArgs e)
        {
            DeleteMaterials();
        }

        private void DeleteBuildStrip_Click(object sender, EventArgs e)
        {
            DeleteBuilds();
        }

        private void DeleteItems()
        {
            var ShopListItem = new ShoppingListItem();
            string SelectedItem;

            if (lstItems.SelectedItems.Count > 0)
            {
                for (int i = 0, loopTo = lstItems.SelectedItems.Count - 1; i <= loopTo; i++)
                {

                    SelectedItem = lstItems.SelectedItems[i].SubItems[1].Text;

                    if (!string.IsNullOrEmpty(SelectedItem))
                    {
                        // Get the name, build type, and ME, and meta of the item selected
                        if (SelectedItem.Contains("("))
                        {
                            // Strip off the relic from the name
                            ShopListItem.Name = SelectedItem.Substring(0, Strings.InStr(SelectedItem, "(") - 2);
                            ShopListItem.Relic = SelectedItem.Substring(Strings.InStr(SelectedItem, "("), Strings.InStr(SelectedItem, ")") - Strings.InStr(SelectedItem, "(") - 1);
                        }
                        else
                        {
                            ShopListItem.Name = SelectedItem;
                            ShopListItem.Relic = "";
                        }
                        ShopListItem.Runs = Conversions.ToLong(lstItems.SelectedItems[i].SubItems[2].Text);
                        ShopListItem.ItemME = Conversions.ToInteger(lstItems.SelectedItems[i].SubItems[3].Text);
                        ShopListItem.ItemTE = Conversions.ToInteger(Conversions.ToBoolean(lstItems.SelectedItems[i].SubItems[12].Text));
                        ShopListItem.NumBPs = Conversions.ToInteger(lstItems.SelectedItems[i].SubItems[4].Text);
                        ShopListItem.BuildType = lstItems.SelectedItems[i].SubItems[5].Text;
                        ShopListItem.Decryptor = lstItems.SelectedItems[i].SubItems[6].Text;
                        ShopListItem.ManufacturingFacility.FacilityName = lstItems.SelectedItems[i].SubItems[7].Text;

                        // Remove it from shopping list
                        Public_Variables.TotalShoppingList.UpdateShoppingItemQuantity(ShopListItem, 0L);

                    }
                }

                // Just updated, so notify
                Public_Variables.PlayNotifySound();
                RefreshLists();

            }
        }

        private void DeleteMaterials()
        {
            if (lstBuy.SelectedItems.Count > 0)
            {
                for (int i = 0, loopTo = lstBuy.SelectedItems.Count - 1; i <= loopTo; i++)
                    // Remove it
                    Public_Variables.TotalShoppingList.UpdateShoppingBuyQuantity(lstBuy.SelectedItems[i].SubItems[1].Text, 0L);

                // Just updated, so notify
                Public_Variables.PlayNotifySound();
                RefreshLists();

            }
        }

        private void DeleteBuilds()
        {
            var TempBuiltItem = new BuiltItem();
            int i;

            if (lstBuild.SelectedItems.Count > 0)
            {
                var loopTo = lstBuild.SelectedItems.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    TempBuiltItem.ItemTypeID = Conversions.ToLong(lstBuild.SelectedItems[i].SubItems[0].Text);
                    TempBuiltItem.ItemName = lstBuild.SelectedItems[i].SubItems[1].Text;
                    TempBuiltItem.ItemQuantity = Conversions.ToLong(lstBuild.SelectedItems[i].SubItems[2].Text);
                    TempBuiltItem.BuildME = Conversions.ToInteger(lstBuild.SelectedItems[i].SubItems[3].Text);
                    TempBuiltItem.ManufacturingFacility.FacilityName = lstBuild.SelectedItems[i].SubItems[5].Text;

                    // Remove it from shopping list, sending the grid quantity
                    Public_Variables.TotalShoppingList.UpdateShoppingBuiltItemQuantity(ref TempBuiltItem, 0L);
                }

            }

            // Just updated, so notify
            Public_Variables.PlayNotifySound();
            RefreshLists();

        }

        #endregion

        #region InlineListUpdate

        // Determines where to show the text box when clicking on the list sent
        private void ListClicked(ListView ListRef, object sender, MouseEventArgs e)
        {
            int iSubIndex = 0;

            // Hide the text box when a new line is selected
            txtListEdit.Hide();

            CurrentRow = ListRef.GetItemAt(e.X, e.Y); // which listviewitem was clicked
            SelectedGrid = ListRef;

            if (CurrentRow is null)
            {
                return;
            }

            CurrentCell = CurrentRow.GetSubItemAt(e.X, e.Y);  // which subitem was clicked

            // See which column has been clicked
            iSubIndex = CurrentRow.SubItems.IndexOf(CurrentCell);

            // Determine where the previous and next item boxes will be based on what they clicked - used in tab event handling as well
            SetNextandPreviousCells(ListRef);

            // Look at the buy list for price and quantity
            if ((ListRef.Name ?? "") == (lstBuy.Name ?? ""))
            {
                // Set the columns that can be edited, just Quantity and Price
                switch (iSubIndex)
                {
                    case 1:
                        {
                            // Item - only showing box
                            UpdateQuantity = false;
                            UpdatePrice = false;
                            ShowUpdateTextBox(ListRef, HorizontalAlignment.Left);
                            break;
                        }
                    case 2:
                        {
                            UpdateQuantity = true;
                            UpdatePrice = false;
                            ShowUpdateTextBox(ListRef);
                            break;
                        }
                    case 3:
                        {
                            UpdateQuantity = false;
                            UpdatePrice = true;
                            ShowUpdateTextBox(ListRef);
                            break;
                        }

                    default:
                        {
                            UpdateQuantity = false;
                            UpdatePrice = false;
                            break;
                        }
                }
            }

            // Set the columns that can be edited, just Price
            else if (iSubIndex == 2) // Just Quantity updates in the other two grids
            {
                UpdateQuantity = true;
                UpdatePrice = false;
                ShowUpdateTextBox(ListRef);
            }
            else if (iSubIndex == 1)
            {
                // Show the item box for copy/paste purposes
                UpdateQuantity = false;
                UpdatePrice = false;
                ShowUpdateTextBox(ListRef, HorizontalAlignment.Left);
            }
            else
            {
                UpdateQuantity = false;
                UpdatePrice = false;
            }

        }

        // Shows the text box on the grid where clicked if enabled
        private void ShowUpdateTextBox(ListView ListRef, HorizontalAlignment TextAlignment = HorizontalAlignment.Right)
        {
            int lLeft = 0;
            int lWidth = 0;

            // Get size of column and location
            lLeft = CurrentCell.Bounds.Left + 2;
            lWidth = CurrentCell.Bounds.Width;

            // Save the center location of the edit box
            SavedListClickLoc.X = CurrentCell.Bounds.Left + (int)Math.Round(CurrentCell.Bounds.Width / 2d);
            SavedListClickLoc.Y = CurrentCell.Bounds.Top + (int)Math.Round(CurrentCell.Bounds.Height / 2d);

            {
                var withBlock = txtListEdit;
                withBlock.Hide();
                withBlock.SetBounds(lLeft + ListRef.Left, CurrentCell.Bounds.Top + ListRef.Top, lWidth, CurrentCell.Bounds.Height);
                withBlock.Text = CurrentCell.Text;
                withBlock.Show();
                withBlock.TextAlign = TextAlignment;
                withBlock.Focus();
            }

        }

        // Determines where the previous and next item boxes will be based on what they clicked - used in tab event handling
        private void SetNextandPreviousCells(ListView ListRef, string CellType = "")
        {
            int iSubIndex = 0;

            // Normal Row
            if (CellType == "Next")
            {
                CurrentRow = NextCellRow;
            }
            else if (CellType == "Previous")
            {
                CurrentRow = PreviousCellRow;
            }

            // Get index of column
            iSubIndex = CurrentRow.SubItems.IndexOf(CurrentCell);

            // Get next and previous rows. If at end, wrap to top. If at top, wrap to bottom
            if (ListRef.Items.Count == 1)
            {
                NextRow = CurrentRow;
                PreviousRow = CurrentRow;
            }
            else if (CurrentRow.Index != ListRef.Items.Count - 1 & CurrentRow.Index != 0)
            {
                // Not the last line, so set the next and previous
                NextRow = ListRef.Items[CurrentRow.Index + 1];
                PreviousRow = ListRef.Items[CurrentRow.Index - 1];
            }
            else if (CurrentRow.Index == 0)
            {
                NextRow = ListRef.Items[CurrentRow.Index + 1];
                // Wrap to bottom
                PreviousRow = ListRef.Items[ListRef.Items.Count - 1];
            }
            else if (CurrentRow.Index == ListRef.Items.Count - 1)
            {
                // Need to wrap up to top
                NextRow = ListRef.Items[0];
                PreviousRow = ListRef.Items[CurrentRow.Index - 1];
            }

            // Check for buy list
            if ((ListRef.Name ?? "") == (lstBuy.Name ?? ""))
            {

                // The next row must be a Quantity or Price box on the next row 
                // or a previous Quantity or Price box on the previous row
                switch (iSubIndex)
                {
                    case 1: // Just item
                        {
                            NextCell = CurrentRow.SubItems[2]; // Current row Quantity box
                            NextCellRow = CurrentRow;
                            PreviousCell = PreviousRow.SubItems[3]; // Previous row Price box
                            PreviousCellRow = PreviousRow;

                            UpdateQuantity = false;
                            UpdatePrice = false;
                            break;
                        }
                    case 2: // Quantity
                        {
                            NextCell = CurrentRow.SubItems[3]; // Current row Price box
                            NextCellRow = CurrentRow;
                            PreviousCell = CurrentRow.SubItems[1]; // Current row Item box
                            PreviousCellRow = CurrentRow;

                            UpdateQuantity = true;
                            UpdatePrice = false;
                            break;
                        }
                    case 3: // Price
                        {
                            NextCell = NextRow.SubItems[1]; // Next row Item box
                            NextCellRow = NextRow;
                            PreviousCell = CurrentRow.SubItems[2]; // Current row Quantity box
                            PreviousCellRow = CurrentRow;

                            UpdateQuantity = false;
                            UpdatePrice = true;
                            break;
                        }

                    default:
                        {
                            NextCell = null;
                            PreviousCell = null;
                            CurrentCell = null;
                            break;
                        }
                }
            }

            // Set the next and previous quantity boxes
            else if (iSubIndex == 1) // For quantity updates only
            {
                NextCell = CurrentRow.SubItems[2]; // Next quantity box
                NextCellRow = CurrentRow;
                PreviousCell = PreviousRow.SubItems[2]; // Previous quantity box
                PreviousCellRow = PreviousRow;

                UpdateQuantity = true;
                UpdatePrice = false;
            }
            else if (iSubIndex == 2)
            {
                NextCell = NextRow.SubItems[1]; // Next name box
                NextCellRow = NextRow;
                PreviousCell = CurrentRow.SubItems[1]; // Previous name box
                PreviousCellRow = CurrentRow;

                UpdateQuantity = false;
                UpdatePrice = false;
            }
            else
            {
                NextCell = null;
                PreviousCell = null;
                CurrentCell = null;
            }

        }

        // For updating the items in the list by clicking on them
        private void ProcessKeyDownUpdateEdit(Keys SentKey, ListView ListRef)
        {
            int QuantityValue = 0;
            double PriceValue = 0d;
            string SQL;

            // Change blank entry to 0
            if (string.IsNullOrEmpty(Strings.Trim(txtListEdit.Text)))
            {
                txtListEdit.Text = "0";
            }

            // If they hit enter or tab away, mark the BP as owned in the DB with the values entered
            if ((SentKey == Keys.Enter | SentKey == Keys.ShiftKey | SentKey == Keys.Tab) & DataEntered)
            {

                // Check the input first
                if (!Information.IsNumeric(txtListEdit.Text) & UpdateQuantity)
                {
                    Interaction.MsgBox("Invalid Quantity Value", Constants.vbExclamation);
                    return;
                }

                if (!Information.IsNumeric(txtListEdit.Text) & UpdatePrice)
                {
                    Interaction.MsgBox("Invalid Price Value", Constants.vbExclamation);
                    return;
                }

                // Save the data depending on what we are updating
                if (UpdateQuantity)
                {
                    QuantityValue = Conversions.ToInteger(txtListEdit.Text);
                }

                if (UpdatePrice)
                {
                    PriceValue = Conversions.ToDouble(txtListEdit.Text);
                }

                // Update the quantity data in all three grids
                if (UpdateQuantity)
                {

                    // Adjust the mats to what they enter - if it said 100, and they enter 90, then adjust to 90
                    if ((ListRef.Name ?? "") == (lstBuy.Name ?? "")) // The materials we buy to build items 
                    {
                        // Check the numbers, if the same then don't update
                        if (QuantityValue == Conversions.ToInteger(CurrentRow.SubItems[2].Text) & PriceValue == Conversions.ToDouble(CurrentRow.SubItems[3].Text))
                        {
                            // Skip down
                            goto Tabs;
                        }

                        // Save the mats they probably have on hand to make this change - calc from value in grid vs. value entered
                        long OnHandQuantity = Conversions.ToLong(CurrentRow.SubItems[2].Text) - QuantityValue;
                        var OnHandMaterial = new Material(0L, CurrentRow.SubItems[1].Text, "", OnHandQuantity, 0d, 0d, "", "");
                        Public_Variables.TotalShoppingList.OnHandMatList.InsertMaterial(OnHandMaterial);

                        // Update the buy list
                        Public_Variables.TotalShoppingList.UpdateShoppingBuyQuantity(CurrentRow.SubItems[1].Text, QuantityValue);
                    }

                    else if ((ListRef.Name ?? "") == (lstBuild.Name ?? "")) // The components we are building to make the item
                    {
                        // Check the numbers, if the same then don't update
                        if (QuantityValue == Conversions.ToInteger(CurrentRow.SubItems[2].Text))
                        {
                            // Skip down
                            goto Tabs;
                        }

                        var TempBuiltItem = new BuiltItem();
                        TempBuiltItem.ItemTypeID = Conversions.ToLong(CurrentRow.SubItems[0].Text);
                        TempBuiltItem.ItemName = CurrentRow.SubItems[1].Text;
                        TempBuiltItem.ItemQuantity = Conversions.ToLong(CurrentRow.SubItems[2].Text);
                        TempBuiltItem.BuildME = Conversions.ToInteger(CurrentRow.SubItems[3].Text);
                        TempBuiltItem.ManufacturingFacility.FacilityName = CurrentRow.SubItems[5].Text;

                        // Save the built components they probably have on hand to make this change - calc from value in grid vs. value entered
                        long OnHandQuantity = Conversions.ToLong(CurrentRow.SubItems[2].Text) - QuantityValue;
                        var OnHandMaterial = new Material(0L, CurrentRow.SubItems[1].Text, "", OnHandQuantity, 0d, 0d, "", "");
                        Public_Variables.TotalShoppingList.OnHandComponentList.InsertMaterial(OnHandMaterial);

                        // Update the build list
                        Public_Variables.TotalShoppingList.UpdateShoppingBuiltItemQuantity(ref TempBuiltItem, QuantityValue);
                    }

                    else if ((ListRef.Name ?? "") == (lstItems.Name ?? "")) // The items we are building
                    {
                        // Check the numbers, if the same then don't update
                        if (QuantityValue == Conversions.ToInteger(CurrentRow.SubItems[2].Text))
                        {
                            // Skip down
                            goto Tabs;
                        }

                        var ShopListItem = new ShoppingListItem();
                        string TempName = CurrentRow.SubItems[1].Text;
                        if (TempName.Contains("("))
                        {
                            ShopListItem.Name = TempName.Substring(0, Strings.InStr(TempName, "(") - 2);
                            ShopListItem.Relic = TempName.Substring(Strings.InStr(TempName, "("), Strings.InStr(TempName, ")") - Strings.InStr(TempName, "(") - 1);
                        }
                        else
                        {
                            ShopListItem.Name = TempName;
                            ShopListItem.Relic = "";
                        }
                        ShopListItem.Runs = Conversions.ToLong(CurrentRow.SubItems[2].Text);
                        ShopListItem.ItemME = Conversions.ToInteger(CurrentRow.SubItems[3].Text);
                        ShopListItem.ItemTE = Conversions.ToInteger(CurrentRow.SubItems[15].Text);
                        ShopListItem.NumBPs = Conversions.ToInteger(CurrentRow.SubItems[4].Text);
                        ShopListItem.BuildType = CurrentRow.SubItems[5].Text;
                        ShopListItem.Decryptor = CurrentRow.SubItems[6].Text;
                        ShopListItem.InventedRunsPerBP = (int)Math.Round(Math.Ceiling(ShopListItem.Runs / (double)ShopListItem.NumBPs));
                        ShopListItem.ManufacturingFacility.FacilityName = CurrentRow.SubItems[7].Text;

                        // Update the full shopping list
                        Public_Variables.TotalShoppingList.UpdateShoppingItemQuantity(ShopListItem, QuantityValue);

                    }
                }

                else if ((ListRef.Name ?? "") == (lstBuy.Name ?? "") & UpdatePrice) // Price update on the lstBuy screen
                {
                    // Update the price in the database
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtListEdit.Text).ToString() + ", PRICE_TYPE = 'User' WHERE ITEM_ID = " + CurrentRow.SubItems[0].Text;
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                    // Change the value in the price grid, but don't update the grid
                    CurrentRow.SubItems[2].Text = Strings.FormatNumber(txtListEdit.Text, 2);

                    // Update the Prices
                    Public_Variables.UpdateProgramPrices();
                    Focus();
                }

                else
                {
                    goto Tabs;
                }

                RefreshLists();

                // Just updated, so notify
                Public_Variables.PlayNotifySound();

                // Reset text they entered if tabbed
                if (SentKey == Keys.ShiftKey | SentKey == Keys.Tab)
                {
                    txtListEdit.Text = "";
                }

                // Data updated, so reset
                DataEntered = false;

                if (SentKey == Keys.Enter)
                {
                    // Just refresh and select the current row
                    CurrentRow.Selected = true;
                    txtListEdit.Visible = false;
                }

            }

        Tabs:
            ;

            // If they hit tab, then tab to the next cell
            if (SentKey == Keys.Tab)
            {
                if (CurrentRow.Index == -1)
                {
                    // Reset the current row based on the original click
                    CurrentRow = ListRef.GetItemAt(SavedListClickLoc.X, SavedListClickLoc.Y);
                    CurrentCell = CurrentRow.GetSubItemAt(SavedListClickLoc.X, SavedListClickLoc.Y);
                    // Reset the next and previous cells
                    SetNextandPreviousCells(ListRef);
                }

                CurrentCell = NextCell;

                // Reset these each time
                SetNextandPreviousCells(ListRef, "Next");
                if (CurrentRow.Index == 0)
                {
                    // Scroll to top
                    ListRef.Items[0].Selected = true;
                    ListRef.EnsureVisible(0);
                    ListRef.Update();
                }
                else
                {
                    // Make sure the row is visible
                    ListRef.EnsureVisible(CurrentRow.Index);
                }

                // Show the text box
                if (CurrentRow.SubItems.IndexOf(CurrentCell) == 1)
                {
                    ShowUpdateTextBox(ListRef, HorizontalAlignment.Left);
                }
                else
                {
                    ShowUpdateTextBox(ListRef);
                }

            }

            // If shift+tab, then go to the previous cell 
            if (SentKey == Keys.ShiftKey)
            {
                if (CurrentRow.Index == -1)
                {
                    // Reset the current row based on the original click
                    CurrentRow = ListRef.GetItemAt(SavedListClickLoc.X, SavedListClickLoc.Y);
                    CurrentCell = CurrentRow.GetSubItemAt(SavedListClickLoc.X, SavedListClickLoc.Y);
                    // Reset the next and previous cells
                    SetNextandPreviousCells(ListRef);
                }

                CurrentCell = PreviousCell;
                // Reset these each time
                SetNextandPreviousCells(ListRef, "Previous");
                if (CurrentRow.Index == ListRef.Items.Count - 1)
                {
                    // Scroll to bottom
                    ListRef.Items[ListRef.Items.Count - 1].Selected = true;
                    ListRef.EnsureVisible(ListRef.Items.Count - 1);
                    ListRef.Update();
                }
                else
                {
                    // Make sure the row is visible
                    ListRef.EnsureVisible(CurrentRow.Index);
                }

                // Show the text box
                if (CurrentRow.SubItems.IndexOf(CurrentCell) == 1)
                {
                    ShowUpdateTextBox(ListRef, HorizontalAlignment.Left);
                }
                else
                {
                    ShowUpdateTextBox(ListRef);
                }

            }

        }

        // Processes the tab function in the text box for the grid. This overrides the default tabbing between controls
        protected override bool ProcessTabKey(bool TabForward)
        {
            var ac = ActiveControl;

            if (TabForward)
            {
                if (ReferenceEquals(ac, txtListEdit))
                {
                    ProcessKeyDownUpdateEdit(Keys.Tab, SelectedGrid);
                    return true;
                }
            }
            else if (ReferenceEquals(ac, txtListEdit))
            {
                // This is Shift + Tab but just send Shift for ease of processing
                ProcessKeyDownUpdateEdit(Keys.ShiftKey, SelectedGrid);
                return true;
            }

            return base.ProcessTabKey(TabForward);

        }

        private void txtListEdit_GotFocus(object sender, EventArgs e)
        {
            txtListEdit.SelectAll();
        }

        private void txtListEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (!DataEntered) // If data already entered, then they didn't do it through paste
            {
                DataEntered = Public_Variables.ProcessCutCopyPasteSelect(txtListEdit, e);
            }

            if (e.KeyCode == Keys.Enter)
            {
                IgnoreFocusChange = true;
                ProcessKeyDownUpdateEdit(Keys.Enter, SelectedGrid);
                IgnoreFocusChange = false;
            }
        }

        private void txtListEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (UpdateQuantity)
                {
                    if (Public_Variables.allowedRunschars.IndexOf(e.KeyChar) == -1)
                    {
                        // Invalid Character
                        e.Handled = true;
                    }
                    else
                    {
                        DataEntered = true;
                    }
                }
                else if (UpdatePrice)
                {
                    if (Public_Variables.allowedPriceChars.IndexOf(e.KeyChar) == -1)
                    {
                        // Invalid Character
                        e.Handled = true;
                    }
                    else
                    {
                        DataEntered = true;
                    }
                }

            }

        }

        private void txtListEdit_LostFocus(object sender, EventArgs e)
        {
            if (!RefreshingGrid & DataEntered & !IgnoreFocusChange)
            {
                ProcessKeyDownUpdateEdit(Keys.Enter, SelectedGrid);
            }
            txtListEdit.Visible = false;
        }

        // Grid clicks
        private void lstBuild_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right & !(My.MyProject.Computer.Keyboard.ShiftKeyDown | My.MyProject.Computer.Keyboard.CtrlKeyDown))
            {
                ListClicked(lstBuild, sender, e);
            }
        }

        private void lstBuy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right & !(My.MyProject.Computer.Keyboard.ShiftKeyDown | My.MyProject.Computer.Keyboard.CtrlKeyDown))
            {
                ListClicked(lstBuy, sender, e);
            }
        }

        private void lstItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right & !(My.MyProject.Computer.Keyboard.ShiftKeyDown | My.MyProject.Computer.Keyboard.CtrlKeyDown))
            {
                ListClicked(lstItems, sender, e);
            }
        }

        // Detects Scroll event and hides boxes
        private void lstBuild_ProcMsg(Message m)
        {
            txtListEdit.Hide();
        }

        // Detects Scroll event and hides boxes
        private void lstBuy_ProcMsg(Message m)
        {
            txtListEdit.Hide();
        }

        // Detects Scroll event and hides boxes
        private void lstItems_ProcMsg(Message m)
        {
            txtListEdit.Hide();
        }

        private void chkFees_Click(object sender, EventArgs e)
        {
            if (chkFees.Checked & chkFees.CheckState == CheckState.Indeterminate) // Show rate box
            {
                txtBrokerFeeRate.Visible = true;
                lblFeeRate.Visible = true;
            }
            else
            {
                txtBrokerFeeRate.Visible = false;
                lblFeeRate.Visible = false;
            }
        }

        private void txtBrokerFeeRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBrokerFeeRate.Text = Public_Variables.GetFormattedPercentEntry(txtBrokerFeeRate);
            }
        }

        private void txtBrokerFeeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers, decimal, percent or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedPercentChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtBrokerFeeRate_GotFocus(object sender, EventArgs e)
        {
            txtBrokerFeeRate.SelectAll();
        }

        private void txtBrokerFeeRate_LostFocus(object sender, EventArgs e)
        {
            txtBrokerFeeRate.Text = Public_Variables.GetFormattedPercentEntry(txtBrokerFeeRate);
        }

        #endregion

    }

    public class EVEPraisal
    {
        [JsonProperty("appraisal")]
        public eveappraisal appraisal;
    }

    public class eveappraisal
    {
        [JsonProperty("created")]
        public double created;
        [JsonProperty("id")]
        public string id;
        [JsonProperty("items")]
        public List<eprasialItems> items;
        [JsonProperty("market_name")]
        public string market_name;
        [JsonProperty("raw")]
        public string raw;
    }

    public class eprasialItems
    {
        [JsonProperty("appraisal")]
        public eveappraisal appraisal;
        [JsonProperty("method")]
        public string @method;
        [JsonProperty("route")]
        public string route;
        [JsonProperty("status")]
        public string status;
        [JsonProperty("tags")]
        public List<string> tags;
    }

    public class EAItem
    {
        public string market_name;
        public List<typeIDs> items;
    }

    public class typeIDs
    {
        public int type_id;
    }
}