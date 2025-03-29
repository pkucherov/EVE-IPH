using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class EVEAssets
    {

        private List<EVEAsset> AssetList;
        private List<EVEAsset> SelectedAssetList;
        private Public_Variables.ScanType AssetType;
        private DateTime CacheDate;
        private long ItemIDToFind;

        protected Public_Variables.LocationInfo LocationToFind;

        private List<LocationName> LocationNames;
        private List<string> AddedNodes;
        private int UnknownLocationCounter;
        private long LocationIDToFind;

        private const string IgnoreFlag = Public_Variables.None;
        private const string ShipHangar = "Ship Hangar";
        private const string UnknownLocation = "Unknown Location";
        private const string QuantitySpacer = " - ";
        private const string CorpDelivery = "Corporation Market Deliveries / Returns";

        public class LocationName
        {
            public long ID;
            public string Name;
        }

        public EVEAssets(Public_Variables.ScanType InitalAssetType = Public_Variables.ScanType.Personal)
        {

            AssetType = InitalAssetType;
            AssetList = new List<EVEAsset>();
            CacheDate = Public_Variables.NoDate;
        }

        public void LoadAssets(long ID, SavedTokenData CharacterTokenData, bool RefreshAssets)
        {
            string SQL;
            SQLiteDataReader readerAssets;
            SQLiteDataReader readerData;
            var TempAsset = new EVEAsset();
            var Assets = new List<EVEAsset>();

            // Update asset data first
            UpdateAssets(ID, CharacterTokenData, AssetType, RefreshAssets);

            // Set the cache date, since we may not update the assets
            if (AssetType == Public_Variables.ScanType.Personal)
            {
                SQL = "SELECT ASSETS_CACHE_DATE FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID = " + ID.ToString();
            }
            else
            {
                SQL = "SELECT ASSETS_CACHE_DATE FROM ESI_CORPORATION_DATA WHERE CORPORATION_ID = " + ID.ToString();
            }
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerData = Public_Variables.DBCommand.ExecuteReader();

            if (readerData.Read())
            {
                if (readerData.GetValue(0) is DBNull)
                {
                    CacheDate = Public_Variables.NoDate;
                }
                else
                {
                    CacheDate = Conversions.ToDate(readerData.GetString(0));
                }
            }
            else
            {
                CacheDate = Public_Variables.NoDate;
            }

            LocationNames = new List<LocationName>();
            UnknownLocationCounter = 0;

            // Load the assets - corp or personal
            SQL = "SELECT ID, ItemID, LocationID, TypeID, Assets.Quantity, Flag, IsSingleton, ";
            SQL += "CASE WHEN BP_TYPE Is NULL THEN 0 ELSE BP_TYPE END AS BPType FROM ASSETS ";
            SQL += "LEFT JOIN ALL_OWNED_BLUEPRINTS ON ID = OWNER_ID And ItemID = ITEM_ID ";
            SQL += "WHERE ID = " + ID;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerAssets = Public_Variables.DBCommand.ExecuteReader();

            while (readerAssets.Read())
            {
                TempAsset = new EVEAsset();
                TempAsset.ItemID = readerAssets.GetInt64(1);
                TempAsset.LocationID = readerAssets.GetInt64(2);
                TempAsset.TypeID = readerAssets.GetInt64(3);
                TempAsset.Quantity = readerAssets.GetInt64(4);
                TempAsset.FlagID = readerAssets.GetInt32(5);
                TempAsset.IsSingleton = Conversions.ToBoolean(readerAssets.GetInt32(6));
                TempAsset.BPType = (Public_Variables.BPType)readerAssets.GetInt32(7);

                // Get the location name, update flagID (ref) and set flag text (ref)
                TempAsset.LocationName = GetAssetLocationAndFlagInfo(TempAsset.LocationID, ref TempAsset.FlagID, ref TempAsset.FlagText, CharacterTokenData);

                // Look up the type name
                SQL = "SELECT typeName, groupName, categoryName ";
                SQL += "FROM INVENTORY_TYPES, INVENTORY_GROUPS, INVENTORY_CATEGORIES WHERE typeID = " + TempAsset.TypeID + " ";
                SQL += "And INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID ";
                SQL += "And INVENTORY_GROUPS.categoryID = INVENTORY_CATEGORIES.categoryID";

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerData = Public_Variables.DBCommand.ExecuteReader();

                try
                {
                    if (readerData.Read())
                    {
                        // Found it
                        if (!(readerData.GetValue(0) is DBNull))
                        {
                            TempAsset.TypeName = readerData.GetString(0);
                        }
                        else
                        {
                            TempAsset.TypeName = "Unknown Item";
                        }

                        if (!(readerData.GetValue(1) is DBNull))
                        {
                            TempAsset.TypeGroup = readerData.GetString(1);
                        }
                        else
                        {
                            TempAsset.TypeGroup = "Unknown Group";
                        }

                        if (!(readerData.GetValue(2) is DBNull))
                        {
                            TempAsset.TypeCategory = readerData.GetString(2);
                        }
                        else
                        {
                            TempAsset.TypeCategory = "Unknown Category";
                        }
                    }
                    else
                    {
                        TempAsset.TypeName = "Unknown Item";
                        TempAsset.TypeGroup = "Unknown Group";
                        TempAsset.TypeCategory = "Unknown Category";
                    }
                }
                catch (Exception ex)
                {

                    TempAsset.TypeName = "Unknown Item";
                    TempAsset.TypeGroup = "Unknown Group";
                    TempAsset.TypeCategory = "Unknown Category";

                }

                readerData.Close();

                // Insert asset
                Assets.Add(TempAsset);

            }

            readerAssets.Close();

            AssetList = Assets;

        }

        public void UpdateAssets(long ID, SavedTokenData CharacterTokenData, Public_Variables.ScanType AssetType, bool UpdateAssets)
        {
            var Assets = new List<ESIAsset>();
            var AssetIDs = new List<double>(); // For getting names
            string SQL = "";

            var ESIData = new ESI();
            var CB = new CacheBox();

            CacheDateType CDType;

            if (AssetType == Public_Variables.ScanType.Personal)
            {
                CDType = CacheDateType.PersonalAssets;
            }
            else
            {
                CDType = CacheDateType.CorporateAssets;
            }

            // Look up the assets cache date first      
            if (CB.DataUpdateable(CDType, ID))
            {
                Assets = ESIData.GetAssets(ID, CharacterTokenData, AssetType, ref CacheDate);

                // Insert the records into the DB
                if (!(Assets == null))
                {
                    if (Assets.Count > 0)
                    {
                        Public_Variables.EVEDB.BeginSQLiteTransaction();

                        // Clear the current assets in the database
                        SQL = "DELETE FROM ASSETS WHERE ID = " + ID.ToString();
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                        int FlagID = 0;
                        SQLiteDataReader rsLookup;

                        for (int i = 0, loopTo = Assets.Count - 1; i <= loopTo; i++)
                        {
                            // Get the flagID for this location
                            Public_Variables.DBCommand = new SQLiteCommand("SELECT flagID FROM INVENTORY_FLAGS WHERE flagName = '" + Assets[i].location_flag + "'", Public_Variables.EVEDB.DBREf());
                            rsLookup = Public_Variables.DBCommand.ExecuteReader();
                            if (rsLookup.Read())
                            {
                                FlagID = rsLookup.GetInt32(0);
                            }
                            else
                            {
                                FlagID = 0;
                            }
                            rsLookup.Close();

                            // Insert it
                            if (Assets[i].location_id != ID) // Don't add assets that are on the character
                            {
                                SQL = "INSERT INTO ASSETS (ID, ItemID, LocationID, TypeID, Quantity, Flag, IsSingleton) VALUES ";
                                SQL += "(" + ID.ToString() + "," + Assets[i].item_id.ToString() + "," + Assets[i].location_id.ToString() + ",";
                                SQL += Assets[i].type_id.ToString() + "," + Assets[i].quantity.ToString() + "," + FlagID.ToString() + ",";
                                SQL += Conversions.ToInteger(Assets[i].is_singleton) + ")";

                                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                            }

                            // Save the ID for looking up the names
                            AssetIDs.Add(Assets[i].item_id);

                        }

                        // Update all the asset flags to negative values if they are base nodes
                        SQL = string.Format("UPDATE ASSETS SET Flag = CASE WHEN Flag > 0 THEN (Flag * -1) ELSE -2 END WHERE ID = {0} AND LocationID NOT IN (SELECT ItemID FROM ASSETS WHERE ID = {0})", ID);
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                        // ' Finally, get all the names and update the Assets table
                        // Dim AssetItemNames As New List(Of ESICharacterAssetName)
                        // AssetItemNames = ESIData.GetAssetNames(AssetIDs, ID, CharacterTokenData, AssetType, CacheDate)

                        // ' Update the names in the asset table for each itemID
                        // For Each item In AssetItemNames
                        // If item.name <> None Then
                        // Call EVEDB.ExecuteNonQuerySQL("UPDATE ASSETS SET ItemName='" & FormatDBString(item.name) & "' WHERE ItemID=" & CStr(item.item_id))
                        // End If
                        // Next

                        // Update cache date since it's all set now
                        CB.UpdateCacheDate(CDType, CacheDate, ID);

                        Public_Variables.EVEDB.CommitSQLiteTransaction();
                        Public_Variables.DBCommand = null;
                    }
                }
            }

        }

        public List<EVEAsset> GetAssetList()
        {
            return AssetList;
        }

        private string GetAssetLocationAndFlagInfo(long LocationID, ref int FlagID, ref string FlagText, SavedTokenData CharacterTokenData)
        {
            string SQL;
            SQLiteDataReader readerData;
            string LocationName = "";

            // Look up the location name, first start with stations, then systems
            if (LocationID != 0L)
            {

                // See if it's a station
                if (LocationID >= Public_Variables.MinStationID & LocationID < Public_Variables.MaxStationID)
                {

                    SQL = "SELECT STATION_NAME FROM STATIONS WHERE STATION_ID = " + LocationID.ToString();
                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerData = Public_Variables.DBCommand.ExecuteReader();

                    if (readerData.Read())
                    {
                        // Found it
                        LocationName = readerData.GetString(0);
                    }
                    else
                    {
                        // Unknown
                        LocationName = UnknownLocation;
                    }
                    readerData.Close();
                }

                else if (LocationID >= 30000000L & LocationID < 40000000L) // See if it's a solar system
                {
                    SQL = "SELECT solarSystemName FROM SOLAR_SYSTEMS WHERE solarSystemID = " + LocationID.ToString();

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerData = Public_Variables.DBCommand.ExecuteReader();

                    if (readerData.Read())
                    {
                        // Found it
                        LocationName = readerData.GetString(0);
                    }
                    else
                    {
                        // Unknown
                        LocationName = UnknownLocation;
                    }

                    // See if it has a flag assigned, if 0 then set it to 500 (my own code for space)
                    if (FlagID == 0)
                    {
                        FlagID = -1 * Public_Variables.SpaceFlagCode; // negative for base item
                    }

                    readerData.Close();
                }
                else
                {
                    // See if it's connected to another record, which will have a name look up
                    SQL = "SELECT locationID FROM ASSETS WHERE itemID = " + LocationID.ToString();

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerData = Public_Variables.DBCommand.ExecuteReader();
                    readerData.Read();

                    if (readerData.HasRows)
                    {
                        // Call this function again to get the location name
                        LocationName = GetAssetLocationAndFlagInfo(readerData.GetInt64(0), ref FlagID, ref FlagText, CharacterTokenData);
                        readerData.Close();
                    }
                    else
                    {
                        // See if it's a upwell structure that they have access to
                        LocationName FoundLocation;
                        // See if we looked it up first before downloading
                        LocationIDToFind = LocationID;
                        FoundLocation = LocationNames.Find(FindLocation);

                        if (FoundLocation is not null)
                        {
                            LocationName = FoundLocation.Name;
                        }
                        else
                        {
                            // Get the location name for the location if we don't have it yet
                            var SP = new StructureProcessor();
                            var LocationData = SP.GetStationInformation(LocationID, CharacterTokenData, true);

                            if (!string.IsNullOrEmpty(LocationData.Name))
                            {
                                LocationName = LocationData.Name;
                            }

                            if (string.IsNullOrEmpty(LocationName))
                            {
                                UnknownLocationCounter += 1;
                                // Not found, so add a counter to it to deliniate unknown locations
                                LocationName = UnknownLocation + " " + UnknownLocationCounter.ToString();
                            }

                            // Insert location into our list
                            var CN = new LocationName();
                            CN.ID = LocationID;
                            CN.Name = LocationName;
                            LocationNames.Add(CN);

                        }
                    }
                }
            }
            else
            {
                LocationName = UnknownLocation;
            }

            // Look up the flag text
            SQL = "SELECT FlagText FROM INVENTORY_FLAGS WHERE FlagID = " + Math.Abs(FlagID).ToString(); // FlagID can be negative

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerData = Public_Variables.DBCommand.ExecuteReader();

            if (readerData.Read())
            {
                // Found it
                FlagText = Conversions.ToString(readerData.GetValue(0));
            }
            else
            {
                FlagText = "Unknown";
            }

            readerData.Close();

            if (FlagText == "Space" | FlagText == "Ship Offline")
            {
                LocationName = LocationName + " (In Solar System)";
            }

            return LocationName;

        }

        // Gets the Tree base node for all assets - the list of checked nodes passed
        public TreeNode GetAssetTreeAnchorNode(SortType SortOption, List<long> SearchItemList, string NodeName, long AccountID, List<Public_Variables.LocationInfo> SavedLocations, ref bool OnlyBPCs)
        {
            var Tree = new TreeView();
            var AnchorNode = new TreeNode();
            var BaseLocationNode = new TreeNode();
            var SubNode = new TreeNode();
            var FlagSubNode = new TreeNode();
            var TempNode = new TreeNode();
            string TempNodeName;

            bool SelectedItems;
            Public_Variables.LocationInfo TempLocationInfo;
            var BaseAssets = new List<EVEAsset>();
            var LocationList = new List<string>();

            Tree.Update();
            Tree.Nodes.Clear();

            // If no assets, just update and leave
            if (AssetList.Count == 0)
            {
                AnchorNode = Tree.Nodes.Add("No " + NodeName + " Loaded");
                Tree.EndUpdate();
                return AnchorNode;
            }
            AddedNodes = new List<string>();
            // Add the base node
            AnchorNode = Tree.Nodes.Add(NodeName);
            AddedNodes.Add(NodeName);
            TempLocationInfo = new Public_Variables.LocationInfo();
            TempLocationInfo.AccountID = AccountID;
            TempLocationInfo.LocationID = -1;
            TempLocationInfo.FlagID = 0;
            AnchorNode.Tag = TempLocationInfo; // Base node

            Tree.CheckBoxes = true;

            // Only build this if we are looking for Build mat types
            if (SearchItemList.Count != 0)
            {
                SelectedItems = true;

                // Build the asset list based only on these mats - Need to take the list of mats we have, then search all
                // assets to find those item ID's that we want only
                // Search built asset list for only base assets
                SelectedAssetList = new List<EVEAsset>();
                SelectedAssetList = BuildMaterialAssetList(SearchItemList, ref OnlyBPCs);
                // Get the base assets that have items we want somewhere down the tree
                BaseAssets = SelectedAssetList.FindAll(FindBaseAsset);
            }

            else // Get all items
            {
                SelectedItems = false;
                // Get just base assets
                BaseAssets = AssetList.FindAll(FindBaseAsset);
            }

            // Loop through each node and add all the items in it
            foreach (var TempAsset in BaseAssets)
            {

                // If we know the location and the node is a base node, then process
                if ((TempAsset.LocationName ?? "") != UnknownLocation & TempAsset.FlagID <= 0)
                {

                    // See if we have added the location
                    if (!LocationList.Contains(TempAsset.LocationName))
                    {

                        // Add the base location to the list
                        LocationList.Add(TempAsset.LocationName);
                        BaseLocationNode = AnchorNode.Nodes.Add(TempAsset.LocationName);
                        AddedNodes.Add(TempAsset.LocationName);
                        BaseLocationNode.Name = TempAsset.LocationName;

                        // Also save the LocationID in the tag of the node for use searching later
                        TempLocationInfo = new Public_Variables.LocationInfo();
                        TempLocationInfo.AccountID = AccountID;
                        TempLocationInfo.LocationID = TempAsset.LocationID;
                        TempLocationInfo.FlagID = TempAsset.FlagID;
                        BaseLocationNode.Tag = TempLocationInfo;

                        BaseLocationNode.Checked = GetNodeCheckValue(ref SavedLocations, TempLocationInfo);

                    }

                    // Find the first node that is the same as the location added above - make sure we are adding to the right node
                    BaseLocationNode = AnchorNode.Nodes.Find(TempAsset.LocationName, true)[0];

                    // Add the subnode to the tree without the name yet, wait for the search for children before marking
                    if (TempAsset.TypeCategory == "Ship" & AssetType == Public_Variables.ScanType.Corporation & TempAsset.FlagText != "Ship Offline" | (TempAsset.FlagText ?? "") == CorpDelivery)
                    {

                        // Check corp deliveries first since a ship could be a delivery
                        if ((TempAsset.FlagText ?? "") == CorpDelivery)
                        {
                            TempNodeName = CorpDelivery;
                        }
                        else
                        {
                            TempNodeName = ShipHangar;
                        }

                        // Add a new sub node if not in the tree
                        if (BaseLocationNode.Nodes.Find(TempNodeName, true).Count() == 0)
                        {
                            TempNode = BaseLocationNode.Nodes.Add(TempNodeName);
                            AddedNodes.Add(TempNodeName);
                            TempNode.Name = TempNodeName;
                            // Since I add a ship hanger (for personal assets) or a corp delivery hanger (corp assets) need to set the location id's in the tree
                            // to compensate. So store the negative of the location. Ie, it'll be a station for these so store the negative of the station ID
                            TempLocationInfo = new Public_Variables.LocationInfo();
                            TempLocationInfo.AccountID = AccountID;
                            TempLocationInfo.LocationID = -1 * TempAsset.LocationID;
                            TempLocationInfo.FlagID = TempAsset.FlagID;
                            TempNode.Tag = TempLocationInfo;
                            TempNode.Checked = GetNodeCheckValue(ref SavedLocations, TempLocationInfo);
                        }

                        // Find the corp delivery or ship hanger node to add to
                        TempNode = BaseLocationNode.Nodes.Find(TempNodeName, true)[0];
                        SubNode = TempNode.Nodes.Add("");
                    }

                    else
                    {
                        SubNode = BaseLocationNode.Nodes.Add("");
                    }

                    // The location of the subnode is in the asset we are looking at
                    TempLocationInfo = new Public_Variables.LocationInfo();
                    TempLocationInfo.AccountID = AccountID;
                    TempLocationInfo.LocationID = TempAsset.ItemID;
                    TempLocationInfo.FlagID = TempAsset.FlagID;
                    SubNode.Tag = TempLocationInfo;
                    SubNode.Checked = GetNodeCheckValue(ref SavedLocations, TempLocationInfo);
                    SubNode.ImageIndex = Math.Abs(TempAsset.FlagID);

                    // See if the node has children and add
                    SetSubTreeNode(ref SubNode, TempAsset, SortOption, SelectedItems, AccountID, SavedLocations);

                    // Update the Node Text
                    if (SubNode.GetNodeCount(true) != 0)
                    {
                        // Has children so don't display the quantity
                        SubNode.Text = GetItemNodeText(TempAsset, true);
                    }
                    else
                    {
                        SubNode.Text = GetItemNodeText(TempAsset, false);
                    }
                    AddedNodes.Add(SubNode.Text);
                }
            }

            // Finally sort the tree
            if (SortOption == SortType.Name)
            {
                Tree.TreeViewNodeSorter = new NodeNameSorter();
            }
            else if (SortOption == SortType.Quantity)
            {
                Tree.TreeViewNodeSorter = new NodeQuantitySorter();
            }
            else
            {
                Tree.TreeViewNodeSorter = new NodeNameSorter();
            }

            Tree.EndUpdate();

            return AnchorNode;

        }

        // Gets subnodes of the Parent ID
        private void SetSubTreeNode(ref TreeNode BaseNode, EVEAsset ParentAsset, SortType SortOption, bool SelectedItems, long AccountID, List<Public_Variables.LocationInfo> SavedLocations)
        {
            var CategoryNode = new TreeNode();
            var SubNode = new TreeNode();

            var TempNode = new TreeNode();
            string CategoryFlagName;
            var FlagIDList = new List<long>();
            var FoundAssets = new List<EVEAsset>();
            Public_Variables.LocationInfo TempLocationInfo;

            // Search for each item sent, may not be in list
            ItemIDToFind = ParentAsset.ItemID;
            if (!SelectedItems)
            {
                FoundAssets = AssetList.FindAll(FindAsset);
            }
            else // just selected assets
            {
                FoundAssets = SelectedAssetList.FindAll(FindAsset);
            }

            if (FoundAssets.Count != 0)
            {

                // Loop through all assets and add the nodes
                foreach (var TempAsset in FoundAssets)
                {

                    // Get flag name first - this is the category we are adding
                    if (TempAsset.FlagText == "Hangar")
                    {
                        // First corp hanger flag is called hanger, not Access Group, so change it
                        CategoryFlagName = "Corp Hangar 1";
                    }
                    else
                    {
                        CategoryFlagName = TempAsset.FlagText;
                    }

                    if ((CategoryFlagName ?? "") != IgnoreFlag)
                    {
                        // If we haven't added it yet
                        if (!FlagIDList.Contains(TempAsset.FlagID))
                        {
                            // Add the flag to the list
                            FlagIDList.Add(TempAsset.FlagID);

                            // Add the flag as a base node
                            CategoryNode = BaseNode.Nodes.Add(CategoryFlagName);
                            AddedNodes.Add(CategoryFlagName);
                            CategoryNode.Name = CategoryFlagName;
                            // Save the location this node is part
                            TempLocationInfo = new Public_Variables.LocationInfo();
                            TempLocationInfo.AccountID = AccountID;
                            TempLocationInfo.LocationID = ParentAsset.ItemID;
                            TempLocationInfo.FlagID = TempAsset.FlagID;
                            CategoryNode.Tag = TempLocationInfo;
                            CategoryNode.Checked = GetNodeCheckValue(ref SavedLocations, TempLocationInfo);
                        }

                        // Find the first node that is the same as the location added above - make sure we are adding to the right node
                        CategoryNode = BaseNode.Nodes.Find(CategoryFlagName, true)[0];

                        // Add the subnode without text
                        SubNode = CategoryNode.Nodes.Add("");

                        // Check for sub nodes of the found asset
                        SetSubTreeNode(ref SubNode, TempAsset, SortOption, SelectedItems, AccountID, SavedLocations);

                        // Add the item at this base location (ie mineral in hanger)
                        if (CategoryFlagName.Contains("power slot"))
                        {
                            // If the parent node is a slot, then the item will be the only one in it - leave off quantity
                            SubNode.Text = GetItemNodeText(TempAsset, true);
                        }
                        else if (SubNode.Nodes.Count != 0)
                        {
                            // This has items under it so just show the name
                            SubNode.Text = GetItemNodeText(TempAsset, true);
                        }
                        else
                        {
                            // Base items
                            SubNode.Text = GetItemNodeText(TempAsset, false);
                        }
                        AddedNodes.Add(SubNode.Text);
                    }
                    else
                    {

                        // Add the item at this base location (ie mineral in hanger)
                        SubNode = BaseNode.Nodes.Add(GetItemNodeText(TempAsset, false));
                        AddedNodes.Add(GetItemNodeText(TempAsset, false));
                        // Check for sub nodes of the found asset
                        SetSubTreeNode(ref SubNode, TempAsset, SortOption, SelectedItems, AccountID, SavedLocations);
                    }

                    // Location of the subnode is under the category node
                    TempLocationInfo = new Public_Variables.LocationInfo();
                    TempLocationInfo.AccountID = AccountID;
                    TempLocationInfo.LocationID = TempAsset.ItemID;
                    TempLocationInfo.FlagID = TempAsset.FlagID;
                    SubNode.Tag = TempLocationInfo;
                    SubNode.Checked = GetNodeCheckValue(ref SavedLocations, TempLocationInfo);
                }
            }

        }

        // Searches the set of settings for the location pair passed to see if it is in the location or not
        private bool GetNodeCheckValue(ref List<Public_Variables.LocationInfo> SavedLocations, Public_Variables.LocationInfo SearchLocationInfo)
        {
            var FindLocation = new Public_Variables.LocationInfo();

            // See if it's one we check
            LocationToFind = SearchLocationInfo;
            FindLocation = SavedLocations.Find(FindLocationID);

            if (FindLocation is not null)
            {
                // We found it, so check the current item
                return true;
            }
            else
            {
                return false;
            }

        }

        // Searches the item and if a blueprint, formats the name else returns the name
        private string GetItemNodeText(EVEAsset SentAsset, bool ParentNode)
        {
            string ItemName = "";

            if (SentAsset.TypeCategory == "Blueprint")
            {
                // Add onto the name what type of BP it is -1 is original, -2 is copy - if the bp is packaged, singleton = 0 and is a bpo
                if (SentAsset.BPType == Public_Variables.BPType.Original)
                {
                    ItemName = SentAsset.TypeName + " (Original)";
                }
                else
                {
                    ItemName = SentAsset.TypeName + " (Copy)";
                }
            }
            else
            {
                ItemName = SentAsset.TypeName;
            }

            // Add the quantity if it's not a parent node with children
            if (!ParentNode)
            {
                return ItemName + QuantitySpacer + Strings.FormatNumber(SentAsset.Quantity, 0);
            }
            else
            {
                return ItemName;
            }

        }

        // Predicate for finding the asset with the set itemid
        private bool FindAsset(EVEAsset SearchItem)
        {

            if (SearchItem.LocationID == ItemIDToFind)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Predicate for finding the asset with the set itemid
        private bool FindAssetbyItemID(EVEAsset SearchItem)
        {

            if (SearchItem.ItemID == ItemIDToFind)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Predicate for finding the location in the list of location pairs 
        private bool FindLocationID(Public_Variables.LocationInfo SearchItem)
        {

            if (LocationToFind.AccountID == SearchItem.AccountID & LocationToFind.LocationID == SearchItem.LocationID & LocationToFind.FlagID == SearchItem.FlagID)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Predicate for finding an assite by typeID
        private bool FindAssetbyTypeID(EVEAsset SearchItem)
        {

            if (SearchItem.TypeID == ItemIDToFind)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Predicate for finding the asset with the set itemid
        private bool FindBaseAsset(EVEAsset SearchItem)
        {

            // Everything negative is going to be a base node to search
            if (SearchItem.FlagID < 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Builds an asset list of only those assets that are in our list or linked to those in the list
        private List<EVEAsset> BuildMaterialAssetList(List<long> SentList, ref bool OnlyBPCs)
        {
            var BuildMatAssetList = new List<EVEAsset>();
            var FoundAssets = new List<EVEAsset>();
            var FindAssets = new List<EVEAsset>();
            var LocationAssets = new List<EVEAsset>();

            // Search all the assets for each itemID in the list
            foreach (var TypeID in SentList)
            {
                // Find it in Assets
                ItemIDToFind = TypeID;
                FindAssets = AssetList.FindAll(FindAssetbyTypeID);

                // Add them all to the base list
                foreach (var Asset in FindAssets)
                {
                    if (!FoundAssets.Contains(Asset))
                    {
                        // If it's a blueprint, see if we are only looking at BPCs
                        if (Asset.TypeCategory == "Blueprint" & Asset.BPType == Public_Variables.BPType.Copy & OnlyBPCs | !OnlyBPCs | Asset.TypeCategory != "Blueprint")
                        {
                            FoundAssets.Add(Asset);
                        }
                    }
                }
            }

            // Now we should have a base list of assets, we need to figure out where they all are
            foreach (var Asset in FoundAssets)
            {
                // Get the tree for this asset - including the asset
                LocationAssets = FindAssetTree(Asset);

                // Add the entire tree of asset nodes
                foreach (var LocAsset in LocationAssets)
                {
                    if (!BuildMatAssetList.Contains(LocAsset))
                    {
                        BuildMatAssetList.Add(LocAsset);
                    }
                }
            }

            return BuildMatAssetList;

        }

        // Searches the tree for an asset and returns the list of assets found 
        public List<EVEAsset> FindAssetTree(EVEAsset SearchAsset)
        {
            var TreeAssets = new List<EVEAsset>();
            var FindAssets = new List<EVEAsset>();
            var RecursiveAssets = new List<EVEAsset>();

            // Look up asset by location, then based on the location found, look up the tree for a connected asset
            // Assets are connected: LocationID -> ItemID. If no records found for where Asset.LocationID = DB.ItemID, then we are at top
            ItemIDToFind = SearchAsset.LocationID;
            FindAssets = AssetList.FindAll(FindAssetbyItemID);

            if (FindAssets.Count != 0)
            {
                // Need to run this function on every asset found
                foreach (var Asset in FindAssets)
                {
                    RecursiveAssets = FindAssetTree(Asset);
                    // Add them to tree
                    if (RecursiveAssets.Count != 0)
                    {
                        foreach (var RecursiveAsset in RecursiveAssets)
                        {
                            if (!TreeAssets.Contains(RecursiveAsset))
                            {
                                TreeAssets.Add(RecursiveAsset);
                            }
                        }
                    }
                }
            }

            // Make sure the asset sent is in the tree too
            if (!TreeAssets.Contains(SearchAsset))
            {
                TreeAssets.Add(SearchAsset);
            }

            // We are done, return the list
            return TreeAssets;

        }

        private class NodeNameSorter : IComparer
        {

            // Compare the length of the strings, or the strings 
            // themselves, if they are the same length. 
            public int Compare(object x, object y)
            {
                TreeNode tx = (TreeNode)x;
                TreeNode ty = (TreeNode)y;
                long Qx;
                long Qy;

                // Get the quantity for the nodes
                Qx = GetNodeQuantity(ref tx);
                Qy = GetNodeQuantity(ref ty);

                if (tx.Text.Contains("R.Db") | ty.Text.Contains("R.Db"))
                {
                    Application.DoEvents();
                }

                if (Qx == 0L & Qy == 0L)
                {
                    // Sort by name
                    return string.Compare(tx.Text, ty.Text);
                }
                else if (Qx == 0L | Qy == 0L)
                {
                    // Sort assending, since a zero quantity is a base item and should go to the top
                    return Qx.CompareTo(Qy);
                }
                else
                {
                    return string.Compare(tx.Text, ty.Text);
                }

            }

        }

        private class NodeQuantitySorter : IComparer
        {

            // Compare the length of the strings, or the strings 
            // themselves, if they are the same length. 
            public int Compare(object x, object y)
            {
                TreeNode tx = (TreeNode)x;
                TreeNode ty = (TreeNode)y;
                long Qx;
                long Qy;

                // Get the quantity for the nodes
                Qx = GetNodeQuantity(ref tx);
                Qy = GetNodeQuantity(ref ty);

                if (Qx == 0L & Qy == 0L)
                {
                    // Sort by name!
                    return string.Compare(tx.Text, ty.Text);
                }
                else if (Qx == 0L | Qy == 0L)
                {
                    // Sort assending, since a zero quanity is a base item and should go to the top
                    return Qx.CompareTo(Qy);
                }
                else
                {
                    // Sort descending
                    return Qy.CompareTo(Qx);
                }

            }

        }

        private static long GetNodeQuantity(ref TreeNode SentTreeNode)
        {
            long NodeQuantity = 0L;

            // Get the quantity from the first string
            if (Strings.InStr(SentTreeNode.Text, QuantitySpacer) != 0)
            {
                // We can get the quantity - only find the last spacer at the end since the name can have dashes too
                if (Information.IsNumeric(SentTreeNode.Text.Substring(SentTreeNode.Text.LastIndexOf(QuantitySpacer) + Strings.Len(QuantitySpacer) - 1)))
                {
                    NodeQuantity = Conversions.ToLong(SentTreeNode.Text.Substring(SentTreeNode.Text.LastIndexOf(QuantitySpacer) + Strings.Len(QuantitySpacer) - 1));
                }
            }

            return NodeQuantity;

        }

        // For sorting assets by name

        public class AssetNameComparer : IComparer<EVEAsset>
        {

            public int Compare(EVEAsset p1, EVEAsset p2)
            {
                // Sort by name alphabetically
                return p1.TypeName.CompareTo(p2.TypeName);
            }

        }

        // For sorting assets by quantity

        public class AssetQuantityComparer : IComparer<EVEAsset>
        {

            public int Compare(EVEAsset p1, EVEAsset p2)
            {
                // Sort by quantity decending
                return p2.Quantity.CompareTo(p1.Quantity);
            }

        }

        // For sorting assets by item group

        public class AssetGroupComparer : IComparer<EVEAsset>
        {

            public int Compare(EVEAsset p1, EVEAsset p2)
            {
                // Sort by group name alphabetically
                return p1.TypeGroup.CompareTo(p2.TypeGroup);
            }

        }

        // For sorting assets by flag id

        public class AssetFlagComparer : IComparer<EVEAsset>
        {

            public int Compare(EVEAsset p1, EVEAsset p2)
            {
                // Sort by flagid
                return p1.FlagID.CompareTo(p2.FlagID);
            }

        }

        public long GetAssetCount()
        {
            return AssetList.Count;
        }

        // Predicate for finding an local location name
        private bool FindLocation(LocationName Item)
        {
            if (Item.ID == LocationIDToFind)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Gets the user's saved location IDs from the table
        public List<Public_Variables.LocationInfo> GetAssetLocationIDs(AssetWindow Location, long ID, Corporation CharacterCorporation)
        {
            Public_Variables.LocationInfo TempLocation;
            var ReturnLocations = new List<Public_Variables.LocationInfo>();
            string SQL;
            SQLiteDataReader readerLocations;

            // Since a lot of locations will bog down the settings loading, load locations from a table
            SQL = "SELECT ID, LocationID, FlagID FROM ASSET_LOCATIONS WHERE EnumAssetType = " + ((int)Location).ToString();
            SQL += " AND ID IN (" + ID.ToString() + "," + CharacterCorporation.CorporationID.ToString() + ")";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerLocations = Public_Variables.DBCommand.ExecuteReader();

            while (readerLocations.Read())
            {
                TempLocation = new Public_Variables.LocationInfo();
                TempLocation.AccountID = readerLocations.GetInt64(0);
                TempLocation.LocationID = readerLocations.GetInt64(1);
                TempLocation.FlagID = readerLocations.GetInt32(2);

                ReturnLocations.Add(TempLocation);
            }

            readerLocations.Close();

            return ReturnLocations;

        }

        public DateTime CachedUntil
        {
            get
            {
                return CacheDate;
            }
        }

    }

    public class EVEAsset
    {
        public long LocationID; // Can be a station, system, or another item id
        public string LocationName; // Station or system name
        public long ItemID;
        public long TypeID;
        public string TypeName;
        public string TypeGroup;
        public string TypeCategory;
        public long Quantity;
        public int FlagID;
        public string FlagText; // Name of flag
        public bool IsSingleton; // True is unpacked (not stackable), False is packed (stackable)
        public Public_Variables.BPType BPType; // if it's a blueprint, then will look up the data for the character for all blueprints and set

        public EVEAsset()
        {
            ItemID = 0L;
            LocationID = 0L;
            LocationName = "";
            TypeID = 0L;
            TypeName = "";
            TypeGroup = "";
            Quantity = 0L;
            FlagID = 0;
            FlagText = "";
            IsSingleton = true;
            BPType = 0;
        }

    }

    public enum SortType
    {
        Name = 1,
        Quantity = 2
    }

    public enum AssetTypes
    {
        All = 1,
        Selected = 2
    }
}