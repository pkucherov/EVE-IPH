using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{
    public partial class frmSelectManufacturingTabColumns
    {

        private int MaxColumnNumber;
        private int SelectedIndex;
        private bool ToggleAll;

        public frmSelectManufacturingTabColumns()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            MaxColumnNumber = 1;
            SelectedIndex = 0;
            ToggleAll = false;

        }

        private void SetMaxColumnNumber(int InNumber)
        {
            if (InNumber > MaxColumnNumber)
            {
                MaxColumnNumber = InNumber;
            }
        }

        // Load all the current checks
        private void frmSelectIndustryJobColumns_Shown(object sender, EventArgs e)
        {
            ShowList();
        }

        private void UpdateListCheck(int ColumnValue, int Index)
        {
            if (ColumnValue != 0)
            {
                chkLstBoxColumns.SetItemChecked(Index, true);
                SetMaxColumnNumber(ColumnValue);
            }
            else
            {
                chkLstBoxColumns.SetItemChecked(Index, false);
            }
        }

        private void ShowList()
        {
            {
                ref var withBlock = ref SettingsVariables.UserManufacturingTabColumnSettings;
                UpdateListCheck(withBlock.ItemCategory, 0);
                UpdateListCheck(withBlock.ItemGroup, 1);
                UpdateListCheck(withBlock.ItemName, 2);
                UpdateListCheck(withBlock.Owned, 3);
                UpdateListCheck(withBlock.Tech, 4);
                UpdateListCheck(withBlock.BPME, 5);
                UpdateListCheck(withBlock.BPTE, 6);
                UpdateListCheck(withBlock.Inputs, 7);
                UpdateListCheck(withBlock.Compared, 8);
                UpdateListCheck(withBlock.TotalRuns, 9);
                UpdateListCheck(withBlock.SingleInventedBPCRuns, 10);
                UpdateListCheck(withBlock.ProductionLines, 11);
                UpdateListCheck(withBlock.LaboratoryLines, 12);
                UpdateListCheck(withBlock.TotalInventionCost, 13);
                UpdateListCheck(withBlock.TotalCopyCost, 14);
                UpdateListCheck(withBlock.Taxes, 15);
                UpdateListCheck(withBlock.BrokerFees, 16);
                UpdateListCheck(withBlock.BPProductionTime, 17);
                UpdateListCheck(withBlock.TotalProductionTime, 18);
                UpdateListCheck(withBlock.CopyTime, 19);
                UpdateListCheck(withBlock.InventionTime, 20);
                UpdateListCheck(withBlock.ItemMarketPrice, 21);
                UpdateListCheck(withBlock.Profit, 22);
                UpdateListCheck(withBlock.ProfitPercentage, 23);
                UpdateListCheck(withBlock.IskperHour, 24);
                UpdateListCheck(withBlock.SVR, 25);
                UpdateListCheck(withBlock.SVRxIPH, 26);
                UpdateListCheck(withBlock.PriceTrend, 27);
                UpdateListCheck(withBlock.TotalItemsSold, 28);
                UpdateListCheck(withBlock.TotalOrdersFilled, 29);
                UpdateListCheck(withBlock.AvgItemsperOrder, 30);
                UpdateListCheck(withBlock.CurrentSellOrders, 31);
                UpdateListCheck(withBlock.CurrentBuyOrders, 32);
                UpdateListCheck(withBlock.ItemsinProduction, 33);
                UpdateListCheck(withBlock.ItemsinStock, 34);
                UpdateListCheck(withBlock.MaterialCost, 35);
                UpdateListCheck(withBlock.TotalCost, 36);
                UpdateListCheck(withBlock.BaseJobCost, 37);
                UpdateListCheck(withBlock.NumBPs, 38);
                UpdateListCheck(withBlock.InventionChance, 39);
                UpdateListCheck(withBlock.BPType, 40);
                UpdateListCheck(withBlock.Race, 41);
                UpdateListCheck(withBlock.VolumeperItem, 42);
                UpdateListCheck(withBlock.TotalVolume, 43);
                UpdateListCheck(withBlock.SellExcess, 44);
                UpdateListCheck(withBlock.ROI, 45);
                UpdateListCheck(withBlock.PortionSize, 46);
                UpdateListCheck(withBlock.ManufacturingJobFee, 47);
                UpdateListCheck(withBlock.ManufacturingFacilityName, 48);
                UpdateListCheck(withBlock.ManufacturingFacilitySystem, 49);
                UpdateListCheck(withBlock.ManufacturingFacilityRegion, 50);
                UpdateListCheck(withBlock.ManufacturingFacilitySystemIndex, 51);
                UpdateListCheck(withBlock.ManufacturingFacilityTax, 52);
                UpdateListCheck(withBlock.ManufacturingFacilityMEBonus, 53);
                UpdateListCheck(withBlock.ManufacturingFacilityTEBonus, 54);
                UpdateListCheck(withBlock.ManufacturingFacilityUsage, 55);
                UpdateListCheck(withBlock.ManufacturingFacilityFWSystemLevel, 56);
                UpdateListCheck(withBlock.ComponentFacilityName, 57);
                UpdateListCheck(withBlock.ComponentFacilitySystem, 58);
                UpdateListCheck(withBlock.ComponentFacilityRegion, 59);
                UpdateListCheck(withBlock.ComponentFacilitySystemIndex, 60);
                UpdateListCheck(withBlock.ComponentFacilityTax, 61);
                UpdateListCheck(withBlock.ComponentFacilityMEBonus, 62);
                UpdateListCheck(withBlock.ComponentFacilityTEBonus, 63);
                UpdateListCheck(withBlock.ComponentFacilityUsage, 64);
                UpdateListCheck(withBlock.ComponentFacilityFWSystemLevel, 65);
                UpdateListCheck(withBlock.CapComponentFacilityName, 66);
                UpdateListCheck(withBlock.CapComponentFacilitySystem, 67);
                UpdateListCheck(withBlock.CapComponentFacilityRegion, 68);
                UpdateListCheck(withBlock.CapComponentFacilitySystemIndex, 69);
                UpdateListCheck(withBlock.CapComponentFacilityTax, 70);
                UpdateListCheck(withBlock.CapComponentFacilityMEBonus, 71);
                UpdateListCheck(withBlock.CapComponentFacilityTEBonus, 72);
                UpdateListCheck(withBlock.CapComponentFacilityUsage, 73);
                UpdateListCheck(withBlock.CapComponentFacilityFWSystemLevel, 74);
                UpdateListCheck(withBlock.CopyingFacilityName, 75);
                UpdateListCheck(withBlock.CopyingFacilitySystem, 76);
                UpdateListCheck(withBlock.CopyingFacilityRegion, 77);
                UpdateListCheck(withBlock.CopyingFacilitySystemIndex, 78);
                UpdateListCheck(withBlock.CopyingFacilityTax, 79);
                UpdateListCheck(withBlock.CopyingFacilityMEBonus, 80);
                UpdateListCheck(withBlock.CopyingFacilityTEBonus, 81);
                UpdateListCheck(withBlock.CopyingFacilityUsage, 82);
                UpdateListCheck(withBlock.CopyingFacilityFWSystemLevel, 83);
                UpdateListCheck(withBlock.InventionFacilityName, 84);
                UpdateListCheck(withBlock.InventionFacilitySystem, 85);
                UpdateListCheck(withBlock.InventionFacilityRegion, 86);
                UpdateListCheck(withBlock.InventionFacilitySystemIndex, 87);
                UpdateListCheck(withBlock.InventionFacilityTax, 88);
                UpdateListCheck(withBlock.InventionFacilityMEBonus, 89);
                UpdateListCheck(withBlock.InventionFacilityTEBonus, 90);
                UpdateListCheck(withBlock.InventionFacilityUsage, 91);
                UpdateListCheck(withBlock.InventionFacilityFWSystemLevel, 92);
                UpdateListCheck(withBlock.ReactionFacilityName, 93);
                UpdateListCheck(withBlock.ReactionFacilitySystem, 94);
                UpdateListCheck(withBlock.ReactionFacilityRegion, 95);
                UpdateListCheck(withBlock.ReactionFacilitySystemIndex, 96);
                UpdateListCheck(withBlock.ReactionFacilityTax, 97);
                UpdateListCheck(withBlock.ReactionFacilityMEBonus, 98);
                UpdateListCheck(withBlock.ReactionFacilityTEBonus, 99);
                UpdateListCheck(withBlock.ReactionFacilityUsage, 100);
                UpdateListCheck(withBlock.ReactionFacilityFWSystemLevel, 101);
                UpdateListCheck(withBlock.ReprocessingFacilityName, 102);
                UpdateListCheck(withBlock.ReprocessingFacilitySystem, 103);
                UpdateListCheck(withBlock.ReprocessingFacilityRegion, 104);
                UpdateListCheck(withBlock.ReprocessingFacilityTax, 105);
                UpdateListCheck(withBlock.ReprocessingFacilityUsage, 106);
                UpdateListCheck(withBlock.ReprocessingFacilityOreRefineRate, 107);
                UpdateListCheck(withBlock.ReprocessingFacilityIceRefineRate, 108);
                UpdateListCheck(withBlock.ReprocessingFacilityMoonRefineRate, 109);

                chkLstBoxColumns.Update();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {

            if (chkLstBoxColumns.CheckedItems.Count == 0)
            {
                Interaction.MsgBox("You must select at least one Column", Constants.vbExclamation, Application.ProductName);
                return;
            }

            // Save the local settings and the user settings
            SaveLocalColumnSettings();

            // Save the data in the XML file
            SettingsVariables.AllSettings.SaveManufacturingTabColumnSettings(SettingsVariables.UserManufacturingTabColumnSettings);

            Interaction.MsgBox("Columns Saved", Constants.vbInformation, Application.ProductName);
            Public_Variables.ManufacturingTabColumnsChanged = true;

            Hide();

        }

        // Processes the column order
        private int GetColumnNumber(CheckState ChkState, int CurrentValue)
        {
            int NewValue;

            // Change to max column order + 1 if checked and not already set
            if (CurrentValue == 0 & ChkState == CheckState.Checked)
            {
                NewValue = MaxColumnNumber + 1;
                MaxColumnNumber += 1;
            }
            else if (ChkState == CheckState.Unchecked)
            {
                NewValue = 0;
            }
            else
            {
                NewValue = CurrentValue;
            }

            return NewValue;

        }

        // Save the items as viewed or not and order them from the last column
        public void SaveLocalColumnSettings()
        {
            var ColumnPositions = new string[111];
            var TempColumns = new string[111];
            int ColumnCount = 0;
            int i = 1;
            int j = 1;

            {
                ref var withBlock = ref SettingsVariables.UserManufacturingTabColumnSettings;
                // First add any new check boxes that weren't checked before
                withBlock.ItemCategory = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(0), withBlock.ItemCategory);
                withBlock.ItemGroup = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(1), withBlock.ItemGroup);
                withBlock.ItemName = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(2), withBlock.ItemName);
                withBlock.Owned = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(3), withBlock.Owned);
                withBlock.Tech = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(4), withBlock.Tech);
                withBlock.BPME = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(5), withBlock.BPME);
                withBlock.BPTE = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(6), withBlock.BPTE);
                withBlock.Inputs = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(7), withBlock.Inputs);
                withBlock.Compared = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(8), withBlock.Compared);
                withBlock.TotalRuns = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(9), withBlock.TotalRuns);
                withBlock.SingleInventedBPCRuns = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(10), withBlock.SingleInventedBPCRuns);
                withBlock.ProductionLines = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(11), withBlock.ProductionLines);
                withBlock.LaboratoryLines = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(12), withBlock.LaboratoryLines);
                withBlock.TotalInventionCost = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(13), withBlock.TotalInventionCost);
                withBlock.TotalCopyCost = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(14), withBlock.TotalCopyCost);
                withBlock.Taxes = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(15), withBlock.Taxes);
                withBlock.BrokerFees = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(16), withBlock.BrokerFees);
                withBlock.BPProductionTime = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(17), withBlock.BPProductionTime);
                withBlock.TotalProductionTime = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(18), withBlock.TotalProductionTime);
                withBlock.CopyTime = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(19), withBlock.CopyTime);
                withBlock.InventionTime = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(20), withBlock.InventionTime);
                withBlock.ItemMarketPrice = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(21), withBlock.ItemMarketPrice);
                withBlock.Profit = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(22), withBlock.Profit);
                withBlock.ProfitPercentage = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(23), withBlock.ProfitPercentage);
                withBlock.IskperHour = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(24), withBlock.IskperHour);
                withBlock.SVR = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(25), withBlock.SVR);
                withBlock.SVRxIPH = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(26), withBlock.SVRxIPH);
                withBlock.PriceTrend = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(27), withBlock.PriceTrend);
                withBlock.TotalItemsSold = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(28), withBlock.TotalItemsSold);
                withBlock.TotalOrdersFilled = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(29), withBlock.TotalOrdersFilled);
                withBlock.AvgItemsperOrder = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(30), withBlock.AvgItemsperOrder);
                withBlock.CurrentSellOrders = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(31), withBlock.CurrentSellOrders);
                withBlock.CurrentBuyOrders = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(32), withBlock.CurrentBuyOrders);
                withBlock.ItemsinProduction = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(33), withBlock.ItemsinProduction);
                withBlock.ItemsinStock = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(34), withBlock.ItemsinStock);
                withBlock.MaterialCost = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(35), withBlock.MaterialCost);
                withBlock.TotalCost = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(36), withBlock.TotalCost);
                withBlock.BaseJobCost = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(37), withBlock.BaseJobCost);
                withBlock.NumBPs = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(38), withBlock.NumBPs);
                withBlock.InventionChance = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(39), withBlock.InventionChance);
                withBlock.BPType = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(40), withBlock.BPType);
                withBlock.Race = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(41), withBlock.Race);
                withBlock.VolumeperItem = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(42), withBlock.VolumeperItem);
                withBlock.TotalVolume = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(43), withBlock.TotalVolume);
                withBlock.SellExcess = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(44), withBlock.SellExcess);
                withBlock.ROI = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(45), withBlock.ROI);
                withBlock.PortionSize = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(46), withBlock.PortionSize);
                withBlock.ManufacturingJobFee = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(47), withBlock.ManufacturingJobFee);
                withBlock.ManufacturingFacilityName = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(48), withBlock.ManufacturingFacilityName);
                withBlock.ManufacturingFacilitySystem = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(49), withBlock.ManufacturingFacilitySystem);
                withBlock.ManufacturingFacilityRegion = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(50), withBlock.ManufacturingFacilityRegion);
                withBlock.ManufacturingFacilitySystemIndex = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(51), withBlock.ManufacturingFacilitySystemIndex);
                withBlock.ManufacturingFacilityTax = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(52), withBlock.ManufacturingFacilityTax);
                withBlock.ManufacturingFacilityMEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(53), withBlock.ManufacturingFacilityMEBonus);
                withBlock.ManufacturingFacilityTEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(54), withBlock.ManufacturingFacilityTEBonus);
                withBlock.ManufacturingFacilityUsage = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(55), withBlock.ManufacturingFacilityUsage);
                withBlock.ManufacturingFacilityFWSystemLevel = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(56), withBlock.ManufacturingFacilityFWSystemLevel);
                withBlock.ComponentFacilityName = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(57), withBlock.ComponentFacilityName);
                withBlock.ComponentFacilitySystem = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(58), withBlock.ComponentFacilitySystem);
                withBlock.ComponentFacilityRegion = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(59), withBlock.ComponentFacilityRegion);
                withBlock.ComponentFacilitySystemIndex = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(60), withBlock.ComponentFacilitySystemIndex);
                withBlock.ComponentFacilityTax = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(61), withBlock.ComponentFacilityTax);
                withBlock.ComponentFacilityMEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(62), withBlock.ComponentFacilityMEBonus);
                withBlock.ComponentFacilityTEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(63), withBlock.ComponentFacilityTEBonus);
                withBlock.ComponentFacilityUsage = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(64), withBlock.ComponentFacilityUsage);
                withBlock.ComponentFacilityFWSystemLevel = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(65), withBlock.ComponentFacilityFWSystemLevel);
                withBlock.CapComponentFacilityName = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(66), withBlock.CapComponentFacilityName);
                withBlock.CapComponentFacilitySystem = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(67), withBlock.CapComponentFacilitySystem);
                withBlock.CapComponentFacilityRegion = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(68), withBlock.CapComponentFacilityRegion);
                withBlock.CapComponentFacilitySystemIndex = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(69), withBlock.CapComponentFacilitySystemIndex);
                withBlock.CapComponentFacilityTax = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(70), withBlock.CapComponentFacilityTax);
                withBlock.CapComponentFacilityMEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(71), withBlock.CapComponentFacilityMEBonus);
                withBlock.CapComponentFacilityTEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(72), withBlock.CapComponentFacilityTEBonus);
                withBlock.CapComponentFacilityUsage = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(73), withBlock.CapComponentFacilityUsage);
                withBlock.CapComponentFacilityFWSystemLevel = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(74), withBlock.CapComponentFacilityFWSystemLevel);
                withBlock.CopyingFacilityName = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(75), withBlock.CopyingFacilityName);
                withBlock.CopyingFacilitySystem = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(76), withBlock.CopyingFacilitySystem);
                withBlock.CopyingFacilityRegion = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(77), withBlock.CopyingFacilityRegion);
                withBlock.CopyingFacilitySystemIndex = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(78), withBlock.CopyingFacilitySystemIndex);
                withBlock.CopyingFacilityTax = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(79), withBlock.CopyingFacilityTax);
                withBlock.CopyingFacilityMEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(80), withBlock.CopyingFacilityMEBonus);
                withBlock.CopyingFacilityTEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(81), withBlock.CopyingFacilityTEBonus);
                withBlock.CopyingFacilityUsage = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(82), withBlock.CopyingFacilityUsage);
                withBlock.CopyingFacilityFWSystemLevel = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(83), withBlock.CopyingFacilityFWSystemLevel);
                withBlock.InventionFacilityName = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(84), withBlock.InventionFacilityName);
                withBlock.InventionFacilitySystem = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(85), withBlock.InventionFacilitySystem);
                withBlock.InventionFacilityRegion = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(86), withBlock.InventionFacilityRegion);
                withBlock.InventionFacilitySystemIndex = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(87), withBlock.InventionFacilitySystemIndex);
                withBlock.InventionFacilityTax = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(88), withBlock.InventionFacilityTax);
                withBlock.InventionFacilityMEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(89), withBlock.InventionFacilityMEBonus);
                withBlock.InventionFacilityTEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(90), withBlock.InventionFacilityTEBonus);
                withBlock.InventionFacilityUsage = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(91), withBlock.InventionFacilityUsage);
                withBlock.InventionFacilityFWSystemLevel = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(92), withBlock.InventionFacilityFWSystemLevel);
                withBlock.ReactionFacilityName = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(93), withBlock.ReactionFacilityName);
                withBlock.ReactionFacilitySystem = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(94), withBlock.ReactionFacilitySystem);
                withBlock.ReactionFacilityRegion = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(95), withBlock.ReactionFacilityRegion);
                withBlock.ReactionFacilitySystemIndex = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(96), withBlock.ReactionFacilitySystemIndex);
                withBlock.ReactionFacilityTax = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(97), withBlock.ReactionFacilityTax);
                withBlock.ReactionFacilityMEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(98), withBlock.ReactionFacilityMEBonus);
                withBlock.ReactionFacilityTEBonus = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(99), withBlock.ReactionFacilityTEBonus);
                withBlock.ReactionFacilityUsage = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(100), withBlock.ReactionFacilityUsage);
                withBlock.ReactionFacilityFWSystemLevel = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(101), withBlock.ReactionFacilityFWSystemLevel);
                withBlock.ReprocessingFacilityName = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(102), withBlock.ReprocessingFacilityName);
                withBlock.ReprocessingFacilitySystem = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(103), withBlock.ReprocessingFacilitySystem);
                withBlock.ReprocessingFacilityRegion = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(104), withBlock.ReprocessingFacilityRegion);
                withBlock.ReprocessingFacilityTax = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(105), withBlock.ReprocessingFacilityTax);
                withBlock.ReprocessingFacilityUsage = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(106), withBlock.ReprocessingFacilityUsage);
                withBlock.ReprocessingFacilityOreRefineRate = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(107), withBlock.ReprocessingFacilityOreRefineRate);
                withBlock.ReprocessingFacilityIceRefineRate = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(108), withBlock.ReprocessingFacilityIceRefineRate);
                withBlock.ReprocessingFacilityMoonRefineRate = GetColumnNumber(chkLstBoxColumns.GetItemCheckState(109), withBlock.ReprocessingFacilityMoonRefineRate);

                // Now in case something was removed, we want to update the indicies
                {
                    ref var withBlock1 = ref SettingsVariables.UserManufacturingTabColumnSettings;
                    var loopTo = ColumnPositions.Count() - 1;
                    for (i = 0; i <= loopTo; i++)
                        ColumnPositions[i] = "";

                    {
                        ref var withBlock2 = ref SettingsVariables.UserManufacturingTabColumnSettings;
                        ColumnPositions[withBlock2.ItemCategory] = ProgramSettings.ItemCategoryColumnName;
                        ColumnPositions[withBlock2.ItemGroup] = ProgramSettings.ItemGroupColumnName;
                        ColumnPositions[withBlock2.ItemName] = ProgramSettings.ItemNameColumnName;
                        ColumnPositions[withBlock2.Owned] = ProgramSettings.OwnedColumnName;
                        ColumnPositions[withBlock2.Tech] = ProgramSettings.TechColumnName;
                        ColumnPositions[withBlock2.BPME] = ProgramSettings.BPMEColumnName;
                        ColumnPositions[withBlock2.BPTE] = ProgramSettings.BPTEColumnName;
                        ColumnPositions[withBlock2.Inputs] = ProgramSettings.InputsColumnName;
                        ColumnPositions[withBlock2.Compared] = ProgramSettings.ComparedColumnName;
                        ColumnPositions[withBlock2.TotalRuns] = ProgramSettings.TotalRunsColumnName;
                        ColumnPositions[withBlock2.SingleInventedBPCRuns] = ProgramSettings.SingleInventedBPCRunsColumnName;
                        ColumnPositions[withBlock2.ProductionLines] = ProgramSettings.ProductionLinesColumnName;
                        ColumnPositions[withBlock2.LaboratoryLines] = ProgramSettings.LaboratoryLinesColumnName;
                        ColumnPositions[withBlock2.TotalInventionCost] = ProgramSettings.TotalInventionCostColumnName;
                        ColumnPositions[withBlock2.TotalCopyCost] = ProgramSettings.TotalCopyCostColumnName;
                        ColumnPositions[withBlock2.Taxes] = ProgramSettings.TaxesColumnName;
                        ColumnPositions[withBlock2.BrokerFees] = ProgramSettings.BrokerFeesColumnName;
                        ColumnPositions[withBlock2.BPProductionTime] = ProgramSettings.BPProductionTimeColumnName;
                        ColumnPositions[withBlock2.TotalProductionTime] = ProgramSettings.TotalProductionTimeColumnName;
                        ColumnPositions[withBlock2.CopyTime] = ProgramSettings.CopyTimeColumnName;
                        ColumnPositions[withBlock2.InventionTime] = ProgramSettings.InventionTimeColumnName;
                        ColumnPositions[withBlock2.ItemMarketPrice] = ProgramSettings.ItemMarketPriceColumnName;
                        ColumnPositions[withBlock2.Profit] = ProgramSettings.ProfitColumnName;
                        ColumnPositions[withBlock2.ProfitPercentage] = ProgramSettings.ProfitPercentageColumnName;
                        ColumnPositions[withBlock2.IskperHour] = ProgramSettings.IskperHourColumnName;
                        ColumnPositions[withBlock2.SVR] = ProgramSettings.SVRColumnName;
                        ColumnPositions[withBlock2.SVRxIPH] = ProgramSettings.SVRxIPHColumnName;
                        ColumnPositions[withBlock2.PriceTrend] = ProgramSettings.PriceTrendColumnName;
                        ColumnPositions[withBlock2.TotalItemsSold] = ProgramSettings.TotalItemsSoldColumnName;
                        ColumnPositions[withBlock2.TotalOrdersFilled] = ProgramSettings.TotalOrdersFilledColumnName;
                        ColumnPositions[withBlock2.AvgItemsperOrder] = ProgramSettings.AvgItemsperOrderColumnName;
                        ColumnPositions[withBlock2.CurrentSellOrders] = ProgramSettings.CurrentSellOrdersColumnName;
                        ColumnPositions[withBlock2.CurrentBuyOrders] = ProgramSettings.CurrentBuyOrdersColumnName;
                        ColumnPositions[withBlock2.ItemsinProduction] = ProgramSettings.ItemsinProductionColumnName;
                        ColumnPositions[withBlock2.ItemsinStock] = ProgramSettings.ItemsinStockColumnName;
                        ColumnPositions[withBlock2.MaterialCost] = ProgramSettings.MaterialCostColumnName;
                        ColumnPositions[withBlock2.TotalCost] = ProgramSettings.TotalCostColumnName;
                        ColumnPositions[withBlock2.BaseJobCost] = ProgramSettings.BaseJobCostColumnName;
                        ColumnPositions[withBlock2.NumBPs] = ProgramSettings.NumBPsColumnName;
                        ColumnPositions[withBlock2.InventionChance] = ProgramSettings.InventionChanceColumnName;
                        ColumnPositions[withBlock2.BPType] = ProgramSettings.BPTypeColumnName;
                        ColumnPositions[withBlock2.Race] = ProgramSettings.RaceColumnName;
                        ColumnPositions[withBlock2.VolumeperItem] = ProgramSettings.VolumeperItemColumnName;
                        ColumnPositions[withBlock2.TotalVolume] = ProgramSettings.TotalVolumeColumnName;
                        ColumnPositions[withBlock2.SellExcess] = ProgramSettings.SellExcessColumnName;
                        ColumnPositions[withBlock2.ROI] = ProgramSettings.ROIColumnName;
                        ColumnPositions[withBlock2.PortionSize] = ProgramSettings.PortionSizeColumnName;
                        ColumnPositions[withBlock2.ManufacturingJobFee] = ProgramSettings.ManufacturingJobFeeColumnName;
                        ColumnPositions[withBlock2.ManufacturingFacilityName] = ProgramSettings.ManufacturingFacilityNameColumnName;
                        ColumnPositions[withBlock2.ManufacturingFacilitySystem] = ProgramSettings.ManufacturingFacilitySystemColumnName;
                        ColumnPositions[withBlock2.ManufacturingFacilityRegion] = ProgramSettings.ManufacturingFacilityRegionColumnName;
                        ColumnPositions[withBlock2.ManufacturingFacilitySystemIndex] = ProgramSettings.ManufacturingFacilitySystemIndexColumnName;
                        ColumnPositions[withBlock2.ManufacturingFacilityTax] = ProgramSettings.ManufacturingFacilityTaxColumnName;
                        ColumnPositions[withBlock2.ManufacturingFacilityMEBonus] = ProgramSettings.ManufacturingFacilityMEBonusColumnName;
                        ColumnPositions[withBlock2.ManufacturingFacilityTEBonus] = ProgramSettings.ManufacturingFacilityTEBonusColumnName;
                        ColumnPositions[withBlock2.ManufacturingFacilityUsage] = ProgramSettings.ManufacturingFacilityUsageColumnName;
                        ColumnPositions[withBlock2.ManufacturingFacilityFWSystemLevel] = ProgramSettings.ManufacturingFacilityFWSystemLevelColumnName;
                        ColumnPositions[withBlock2.ComponentFacilityName] = ProgramSettings.ComponentFacilityNameColumnName;
                        ColumnPositions[withBlock2.ComponentFacilitySystem] = ProgramSettings.ComponentFacilitySystemColumnName;
                        ColumnPositions[withBlock2.ComponentFacilityRegion] = ProgramSettings.ComponentFacilityRegionColumnName;
                        ColumnPositions[withBlock2.ComponentFacilitySystemIndex] = ProgramSettings.ComponentFacilitySystemIndexColumnName;
                        ColumnPositions[withBlock2.ComponentFacilityTax] = ProgramSettings.ComponentFacilityTaxColumnName;
                        ColumnPositions[withBlock2.ComponentFacilityMEBonus] = ProgramSettings.ComponentFacilityMEBonusColumnName;
                        ColumnPositions[withBlock2.ComponentFacilityTEBonus] = ProgramSettings.ComponentFacilityTEBonusColumnName;
                        ColumnPositions[withBlock2.ComponentFacilityUsage] = ProgramSettings.ComponentFacilityUsageColumnName;
                        ColumnPositions[withBlock2.ComponentFacilityFWSystemLevel] = ProgramSettings.ComponentFacilityFWSystemLevelColumnName;
                        ColumnPositions[withBlock2.CapComponentFacilityName] = ProgramSettings.CapComponentFacilityNameColumnName;
                        ColumnPositions[withBlock2.CapComponentFacilitySystem] = ProgramSettings.CapComponentFacilitySystemColumnName;
                        ColumnPositions[withBlock2.CapComponentFacilityRegion] = ProgramSettings.CapComponentFacilityRegionColumnName;
                        ColumnPositions[withBlock2.CapComponentFacilitySystemIndex] = ProgramSettings.CapComponentFacilitySystemIndexColumnName;
                        ColumnPositions[withBlock2.CapComponentFacilityTax] = ProgramSettings.CapComponentFacilityTaxColumnName;
                        ColumnPositions[withBlock2.CapComponentFacilityMEBonus] = ProgramSettings.CapComponentFacilityMEBonusColumnName;
                        ColumnPositions[withBlock2.CapComponentFacilityTEBonus] = ProgramSettings.CapComponentFacilityTEBonusColumnName;
                        ColumnPositions[withBlock2.CapComponentFacilityUsage] = ProgramSettings.CapComponentFacilityUsageColumnName;
                        ColumnPositions[withBlock2.CapComponentFacilityFWSystemLevel] = ProgramSettings.CapComponentFacilityFWSystemLevelColumnName;
                        ColumnPositions[withBlock2.CopyingFacilityName] = ProgramSettings.CopyingFacilityNameColumnName;
                        ColumnPositions[withBlock2.CopyingFacilitySystem] = ProgramSettings.CopyingFacilitySystemColumnName;
                        ColumnPositions[withBlock2.CopyingFacilityRegion] = ProgramSettings.CopyingFacilityRegionColumnName;
                        ColumnPositions[withBlock2.CopyingFacilitySystemIndex] = ProgramSettings.CopyingFacilitySystemIndexColumnName;
                        ColumnPositions[withBlock2.CopyingFacilityTax] = ProgramSettings.CopyingFacilityTaxColumnName;
                        ColumnPositions[withBlock2.CopyingFacilityMEBonus] = ProgramSettings.CopyingFacilityMEBonusColumnName;
                        ColumnPositions[withBlock2.CopyingFacilityTEBonus] = ProgramSettings.CopyingFacilityTEBonusColumnName;
                        ColumnPositions[withBlock2.CopyingFacilityUsage] = ProgramSettings.CopyingFacilityUsageColumnName;
                        ColumnPositions[withBlock2.CopyingFacilityFWSystemLevel] = ProgramSettings.CopyingFacilityFWSystemLevelColumnName;
                        ColumnPositions[withBlock2.InventionFacilityName] = ProgramSettings.InventionFacilityNameColumnName;
                        ColumnPositions[withBlock2.InventionFacilitySystem] = ProgramSettings.InventionFacilitySystemColumnName;
                        ColumnPositions[withBlock2.InventionFacilityRegion] = ProgramSettings.InventionFacilityRegionColumnName;
                        ColumnPositions[withBlock2.InventionFacilitySystemIndex] = ProgramSettings.InventionFacilitySystemIndexColumnName;
                        ColumnPositions[withBlock2.InventionFacilityTax] = ProgramSettings.InventionFacilityTaxColumnName;
                        ColumnPositions[withBlock2.InventionFacilityMEBonus] = ProgramSettings.InventionFacilityMEBonusColumnName;
                        ColumnPositions[withBlock2.InventionFacilityTEBonus] = ProgramSettings.InventionFacilityTEBonusColumnName;
                        ColumnPositions[withBlock2.InventionFacilityUsage] = ProgramSettings.InventionFacilityUsageColumnName;
                        ColumnPositions[withBlock2.InventionFacilityFWSystemLevel] = ProgramSettings.InventionFacilityFWSystemLevelColumnName;
                        ColumnPositions[withBlock2.ReactionFacilityName] = ProgramSettings.ReactionFacilityNameColumnName;
                        ColumnPositions[withBlock2.ReactionFacilitySystem] = ProgramSettings.ReactionFacilitySystemColumnName;
                        ColumnPositions[withBlock2.ReactionFacilityRegion] = ProgramSettings.ReactionFacilityRegionColumnName;
                        ColumnPositions[withBlock2.ReactionFacilitySystemIndex] = ProgramSettings.ReactionFacilitySystemIndexColumnName;
                        ColumnPositions[withBlock2.ReactionFacilityTax] = ProgramSettings.ReactionFacilityTaxColumnName;
                        ColumnPositions[withBlock2.ReactionFacilityMEBonus] = ProgramSettings.ReactionFacilityMEBonusColumnName;
                        ColumnPositions[withBlock2.ReactionFacilityTEBonus] = ProgramSettings.ReactionFacilityTEBonusColumnName;
                        ColumnPositions[withBlock2.ReactionFacilityUsage] = ProgramSettings.ReactionFacilityUsageColumnName;
                        ColumnPositions[withBlock2.ReactionFacilityFWSystemLevel] = ProgramSettings.ReactionFacilityFWSystemLevelColumnName;
                        ColumnPositions[withBlock2.ReprocessingFacilityName] = ProgramSettings.ReprocessingFacilityNameColumnName;
                        ColumnPositions[withBlock2.ReprocessingFacilitySystem] = ProgramSettings.ReprocessingFacilitySystemColumnName;
                        ColumnPositions[withBlock2.ReprocessingFacilityRegion] = ProgramSettings.ReprocessingFacilityRegionColumnName;
                        ColumnPositions[withBlock2.ReprocessingFacilityTax] = ProgramSettings.ReprocessingFacilityTaxColumnName;
                        ColumnPositions[withBlock2.ReprocessingFacilityUsage] = ProgramSettings.ReprocessingFacilityUsageColumnName;
                        ColumnPositions[withBlock2.ReprocessingFacilityOreRefineRate] = ProgramSettings.ReprocessingFacilityOreRefineRateColumnName;
                        ColumnPositions[withBlock2.ReprocessingFacilityIceRefineRate] = ProgramSettings.ReprocessingFacilityIceRefineRateColumnName;
                        ColumnPositions[withBlock2.ReprocessingFacilityMoonRefineRate] = ProgramSettings.ReprocessingFacilityMoonRefineRateColumnName;
                    }

                    // Reset the first column is empty
                    ColumnPositions[0] = "ListID";

                    // Now get the total number of columns in the list we want to see
                    var loopTo1 = ColumnPositions.Count() - 1;
                    for (i = 1; i <= loopTo1; i++)
                    {
                        if (!string.IsNullOrEmpty(ColumnPositions[i]))
                        {
                            ColumnCount += 1;
                        }
                    }

                    // Init temp
                    var loopTo2 = TempColumns.Count() - 1;
                    for (i = 0; i <= loopTo2; i++)
                        TempColumns[i] = "";

                    // Now loop through the columns and update the positions
                    var loopTo3 = ColumnPositions.Count() - 1;
                    for (i = 1; i <= loopTo3; i++)
                    {
                        if (!string.IsNullOrEmpty(ColumnPositions[i]))
                        {
                            TempColumns[j] = ColumnPositions[i];
                            j += 1;
                        }
                        else if (i == SettingsVariables.UserManufacturingTabColumnSettings.OrderByColumn)
                        {
                            // They removed the column they sorted, so default to the first column since you must have 1
                            SettingsVariables.UserManufacturingTabColumnSettings.OrderByColumn = 1;
                        }
                    }

                    ColumnPositions = TempColumns;

                    // Finally save the columns based on the current order
                    {
                        ref var withBlock3 = ref SettingsVariables.UserManufacturingTabColumnSettings;
                        var loopTo4 = ColumnPositions.Count() - 1;
                        for (i = 1; i <= loopTo4; i++)
                        {
                            switch (ColumnPositions[i] ?? "")
                            {
                                case ProgramSettings.ItemCategoryColumnName:
                                    {
                                        withBlock3.ItemCategory = i;
                                        break;
                                    }
                                case ProgramSettings.ItemGroupColumnName:
                                    {
                                        withBlock3.ItemGroup = i;
                                        break;
                                    }
                                case ProgramSettings.ItemNameColumnName:
                                    {
                                        withBlock3.ItemName = i;
                                        break;
                                    }
                                case ProgramSettings.OwnedColumnName:
                                    {
                                        withBlock3.Owned = i;
                                        break;
                                    }
                                case ProgramSettings.TechColumnName:
                                    {
                                        withBlock3.Tech = i;
                                        break;
                                    }
                                case ProgramSettings.BPMEColumnName:
                                    {
                                        withBlock3.BPME = i;
                                        break;
                                    }
                                case ProgramSettings.BPTEColumnName:
                                    {
                                        withBlock3.BPTE = i;
                                        break;
                                    }
                                case ProgramSettings.InputsColumnName:
                                    {
                                        withBlock3.Inputs = i;
                                        break;
                                    }
                                case ProgramSettings.ComparedColumnName:
                                    {
                                        withBlock3.Compared = i;
                                        break;
                                    }
                                case ProgramSettings.TotalRunsColumnName:
                                    {
                                        withBlock3.TotalRuns = i;
                                        break;
                                    }
                                case ProgramSettings.SingleInventedBPCRunsColumnName:
                                    {
                                        withBlock3.SingleInventedBPCRuns = i;
                                        break;
                                    }
                                case ProgramSettings.ProductionLinesColumnName:
                                    {
                                        withBlock3.ProductionLines = i;
                                        break;
                                    }
                                case ProgramSettings.LaboratoryLinesColumnName:
                                    {
                                        withBlock3.LaboratoryLines = i;
                                        break;
                                    }
                                case ProgramSettings.TotalInventionCostColumnName:
                                    {
                                        withBlock3.TotalInventionCost = i;
                                        break;
                                    }
                                case ProgramSettings.TotalCopyCostColumnName:
                                    {
                                        withBlock3.TotalCopyCost = i;
                                        break;
                                    }
                                case ProgramSettings.TaxesColumnName:
                                    {
                                        withBlock3.Taxes = i;
                                        break;
                                    }
                                case ProgramSettings.BrokerFeesColumnName:
                                    {
                                        withBlock3.BrokerFees = i;
                                        break;
                                    }
                                case ProgramSettings.BPProductionTimeColumnName:
                                    {
                                        withBlock3.BPProductionTime = i;
                                        break;
                                    }
                                case ProgramSettings.TotalProductionTimeColumnName:
                                    {
                                        withBlock3.TotalProductionTime = i;
                                        break;
                                    }
                                case ProgramSettings.CopyTimeColumnName:
                                    {
                                        withBlock3.CopyTime = i;
                                        break;
                                    }
                                case ProgramSettings.InventionTimeColumnName:
                                    {
                                        withBlock3.InventionTime = i;
                                        break;
                                    }
                                case ProgramSettings.ItemMarketPriceColumnName:
                                    {
                                        withBlock3.ItemMarketPrice = i;
                                        break;
                                    }
                                case ProgramSettings.ProfitColumnName:
                                    {
                                        withBlock3.Profit = i;
                                        break;
                                    }
                                case ProgramSettings.ProfitPercentageColumnName:
                                    {
                                        withBlock3.ProfitPercentage = i;
                                        break;
                                    }
                                case ProgramSettings.IskperHourColumnName:
                                    {
                                        withBlock3.IskperHour = i;
                                        break;
                                    }
                                case ProgramSettings.SVRColumnName:
                                    {
                                        withBlock3.SVR = i;
                                        break;
                                    }
                                case ProgramSettings.SVRxIPHColumnName:
                                    {
                                        withBlock3.SVRxIPH = i;
                                        break;
                                    }
                                case ProgramSettings.PriceTrendColumnName:
                                    {
                                        withBlock3.PriceTrend = i;
                                        break;
                                    }
                                case ProgramSettings.TotalItemsSoldColumnName:
                                    {
                                        withBlock3.TotalItemsSold = i;
                                        break;
                                    }
                                case ProgramSettings.TotalOrdersFilledColumnName:
                                    {
                                        withBlock3.TotalOrdersFilled = i;
                                        break;
                                    }
                                case ProgramSettings.AvgItemsperOrderColumnName:
                                    {
                                        withBlock3.AvgItemsperOrder = i;
                                        break;
                                    }
                                case ProgramSettings.CurrentSellOrdersColumnName:
                                    {
                                        withBlock3.CurrentSellOrders = i;
                                        break;
                                    }
                                case ProgramSettings.CurrentBuyOrdersColumnName:
                                    {
                                        withBlock3.CurrentBuyOrders = i;
                                        break;
                                    }
                                case ProgramSettings.ItemsinProductionColumnName:
                                    {
                                        withBlock3.ItemsinProduction = i;
                                        break;
                                    }
                                case ProgramSettings.ItemsinStockColumnName:
                                    {
                                        withBlock3.ItemsinStock = i;
                                        break;
                                    }
                                case ProgramSettings.MaterialCostColumnName:
                                    {
                                        withBlock3.MaterialCost = i;
                                        break;
                                    }
                                case ProgramSettings.TotalCostColumnName:
                                    {
                                        withBlock3.TotalCost = i;
                                        break;
                                    }
                                case ProgramSettings.BaseJobCostColumnName:
                                    {
                                        withBlock3.BaseJobCost = i;
                                        break;
                                    }
                                case ProgramSettings.NumBPsColumnName:
                                    {
                                        withBlock3.NumBPs = i;
                                        break;
                                    }
                                case ProgramSettings.InventionChanceColumnName:
                                    {
                                        withBlock3.InventionChance = i;
                                        break;
                                    }
                                case ProgramSettings.BPTypeColumnName:
                                    {
                                        withBlock3.BPType = i;
                                        break;
                                    }
                                case ProgramSettings.RaceColumnName:
                                    {
                                        withBlock3.Race = i;
                                        break;
                                    }
                                case ProgramSettings.VolumeperItemColumnName:
                                    {
                                        withBlock3.VolumeperItem = i;
                                        break;
                                    }
                                case ProgramSettings.TotalVolumeColumnName:
                                    {
                                        withBlock3.TotalVolume = i;
                                        break;
                                    }
                                case ProgramSettings.SellExcessColumnName:
                                    {
                                        withBlock3.SellExcess = i;
                                        break;
                                    }
                                case ProgramSettings.ROIColumnName:
                                    {
                                        withBlock3.ROI = i;
                                        break;
                                    }
                                case ProgramSettings.PortionSizeColumnName:
                                    {
                                        withBlock3.PortionSize = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingJobFeeColumnName:
                                    {
                                        withBlock3.ManufacturingJobFee = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingFacilityNameColumnName:
                                    {
                                        withBlock3.ManufacturingFacilityName = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingFacilitySystemColumnName:
                                    {
                                        withBlock3.ManufacturingFacilitySystem = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingFacilityRegionColumnName:
                                    {
                                        withBlock3.ManufacturingFacilityRegion = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingFacilitySystemIndexColumnName:
                                    {
                                        withBlock3.ManufacturingFacilitySystemIndex = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingFacilityTaxColumnName:
                                    {
                                        withBlock3.ManufacturingFacilityTax = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingFacilityMEBonusColumnName:
                                    {
                                        withBlock3.ManufacturingFacilityMEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingFacilityTEBonusColumnName:
                                    {
                                        withBlock3.ManufacturingFacilityTEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingFacilityUsageColumnName:
                                    {
                                        withBlock3.ManufacturingFacilityUsage = i;
                                        break;
                                    }
                                case ProgramSettings.ManufacturingFacilityFWSystemLevelColumnName:
                                    {
                                        withBlock3.ManufacturingFacilityFWSystemLevel = i;
                                        break;
                                    }
                                case ProgramSettings.ComponentFacilityNameColumnName:
                                    {
                                        withBlock3.ComponentFacilityName = i;
                                        break;
                                    }
                                case ProgramSettings.ComponentFacilitySystemColumnName:
                                    {
                                        withBlock3.ComponentFacilitySystem = i;
                                        break;
                                    }
                                case ProgramSettings.ComponentFacilityRegionColumnName:
                                    {
                                        withBlock3.ComponentFacilityRegion = i;
                                        break;
                                    }
                                case ProgramSettings.ComponentFacilitySystemIndexColumnName:
                                    {
                                        withBlock3.ComponentFacilitySystemIndex = i;
                                        break;
                                    }
                                case ProgramSettings.ComponentFacilityTaxColumnName:
                                    {
                                        withBlock3.ComponentFacilityTax = i;
                                        break;
                                    }
                                case ProgramSettings.ComponentFacilityMEBonusColumnName:
                                    {
                                        withBlock3.ComponentFacilityMEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.ComponentFacilityTEBonusColumnName:
                                    {
                                        withBlock3.ComponentFacilityTEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.ComponentFacilityUsageColumnName:
                                    {
                                        withBlock3.ComponentFacilityUsage = i;
                                        break;
                                    }
                                case ProgramSettings.ComponentFacilityFWSystemLevelColumnName:
                                    {
                                        withBlock3.ComponentFacilityFWSystemLevel = i;
                                        break;
                                    }
                                case ProgramSettings.CapComponentFacilityNameColumnName:
                                    {
                                        withBlock3.CapComponentFacilityName = i;
                                        break;
                                    }
                                case ProgramSettings.CapComponentFacilitySystemColumnName:
                                    {
                                        withBlock3.CapComponentFacilitySystem = i;
                                        break;
                                    }
                                case ProgramSettings.CapComponentFacilityRegionColumnName:
                                    {
                                        withBlock3.CapComponentFacilityRegion = i;
                                        break;
                                    }
                                case ProgramSettings.CapComponentFacilitySystemIndexColumnName:
                                    {
                                        withBlock3.CapComponentFacilitySystemIndex = i;
                                        break;
                                    }
                                case ProgramSettings.CapComponentFacilityTaxColumnName:
                                    {
                                        withBlock3.CapComponentFacilityTax = i;
                                        break;
                                    }
                                case ProgramSettings.CapComponentFacilityMEBonusColumnName:
                                    {
                                        withBlock3.CapComponentFacilityMEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.CapComponentFacilityTEBonusColumnName:
                                    {
                                        withBlock3.CapComponentFacilityTEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.CapComponentFacilityUsageColumnName:
                                    {
                                        withBlock3.CapComponentFacilityUsage = i;
                                        break;
                                    }
                                case ProgramSettings.CapComponentFacilityFWSystemLevelColumnName:
                                    {
                                        withBlock3.CapComponentFacilityFWSystemLevel = i;
                                        break;
                                    }
                                case ProgramSettings.CopyingFacilityNameColumnName:
                                    {
                                        withBlock3.CopyingFacilityName = i;
                                        break;
                                    }
                                case ProgramSettings.CopyingFacilitySystemColumnName:
                                    {
                                        withBlock3.CopyingFacilitySystem = i;
                                        break;
                                    }
                                case ProgramSettings.CopyingFacilityRegionColumnName:
                                    {
                                        withBlock3.CopyingFacilityRegion = i;
                                        break;
                                    }
                                case ProgramSettings.CopyingFacilitySystemIndexColumnName:
                                    {
                                        withBlock3.CopyingFacilitySystemIndex = i;
                                        break;
                                    }
                                case ProgramSettings.CopyingFacilityTaxColumnName:
                                    {
                                        withBlock3.CopyingFacilityTax = i;
                                        break;
                                    }
                                case ProgramSettings.CopyingFacilityMEBonusColumnName:
                                    {
                                        withBlock3.CopyingFacilityMEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.CopyingFacilityTEBonusColumnName:
                                    {
                                        withBlock3.CopyingFacilityTEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.CopyingFacilityUsageColumnName:
                                    {
                                        withBlock3.CopyingFacilityUsage = i;
                                        break;
                                    }
                                case ProgramSettings.CopyingFacilityFWSystemLevelColumnName:
                                    {
                                        withBlock3.CopyingFacilityFWSystemLevel = i;
                                        break;
                                    }
                                case ProgramSettings.InventionFacilityNameColumnName:
                                    {
                                        withBlock3.InventionFacilityName = i;
                                        break;
                                    }
                                case ProgramSettings.InventionFacilitySystemColumnName:
                                    {
                                        withBlock3.InventionFacilitySystem = i;
                                        break;
                                    }
                                case ProgramSettings.InventionFacilityRegionColumnName:
                                    {
                                        withBlock3.InventionFacilityRegion = i;
                                        break;
                                    }
                                case ProgramSettings.InventionFacilitySystemIndexColumnName:
                                    {
                                        withBlock3.InventionFacilitySystemIndex = i;
                                        break;
                                    }
                                case ProgramSettings.InventionFacilityTaxColumnName:
                                    {
                                        withBlock3.InventionFacilityTax = i;
                                        break;
                                    }
                                case ProgramSettings.InventionFacilityMEBonusColumnName:
                                    {
                                        withBlock3.InventionFacilityMEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.InventionFacilityTEBonusColumnName:
                                    {
                                        withBlock3.InventionFacilityTEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.InventionFacilityUsageColumnName:
                                    {
                                        withBlock3.InventionFacilityUsage = i;
                                        break;
                                    }
                                case ProgramSettings.InventionFacilityFWSystemLevelColumnName:
                                    {
                                        withBlock3.InventionFacilityFWSystemLevel = i;
                                        break;
                                    }
                                case ProgramSettings.ReactionFacilityNameColumnName:
                                    {
                                        withBlock3.ReactionFacilityName = i;
                                        break;
                                    }
                                case ProgramSettings.ReactionFacilitySystemColumnName:
                                    {
                                        withBlock3.ReactionFacilitySystem = i;
                                        break;
                                    }
                                case ProgramSettings.ReactionFacilityRegionColumnName:
                                    {
                                        withBlock3.ReactionFacilityRegion = i;
                                        break;
                                    }
                                case ProgramSettings.ReactionFacilitySystemIndexColumnName:
                                    {
                                        withBlock3.ReactionFacilitySystemIndex = i;
                                        break;
                                    }
                                case ProgramSettings.ReactionFacilityTaxColumnName:
                                    {
                                        withBlock3.ReactionFacilityTax = i;
                                        break;
                                    }
                                case ProgramSettings.ReactionFacilityMEBonusColumnName:
                                    {
                                        withBlock3.ReactionFacilityMEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.ReactionFacilityTEBonusColumnName:
                                    {
                                        withBlock3.ReactionFacilityTEBonus = i;
                                        break;
                                    }
                                case ProgramSettings.ReactionFacilityUsageColumnName:
                                    {
                                        withBlock3.ReactionFacilityUsage = i;
                                        break;
                                    }
                                case ProgramSettings.ReactionFacilityFWSystemLevelColumnName:
                                    {
                                        withBlock3.ReactionFacilityFWSystemLevel = i;
                                        break;
                                    }
                                case ProgramSettings.ReprocessingFacilityNameColumnName:
                                    {
                                        withBlock3.ReprocessingFacilityName = i;
                                        break;
                                    }
                                case ProgramSettings.ReprocessingFacilitySystemColumnName:
                                    {
                                        withBlock3.ReprocessingFacilitySystem = i;
                                        break;
                                    }
                                case ProgramSettings.ReprocessingFacilityRegionColumnName:
                                    {
                                        withBlock3.ReprocessingFacilityRegion = i;
                                        break;
                                    }
                                case ProgramSettings.ReprocessingFacilityTaxColumnName:
                                    {
                                        withBlock3.ReprocessingFacilityTax = i;
                                        break;
                                    }
                                case ProgramSettings.ReprocessingFacilityUsageColumnName:
                                    {
                                        withBlock3.ReprocessingFacilityUsage = i;
                                        break;
                                    }
                                case ProgramSettings.ReprocessingFacilityOreRefineRateColumnName:
                                    {
                                        withBlock3.ReprocessingFacilityOreRefineRate = i;
                                        break;
                                    }
                                case ProgramSettings.ReprocessingFacilityIceRefineRateColumnName:
                                    {
                                        withBlock3.ReprocessingFacilityIceRefineRate = i;
                                        break;
                                    }
                                case ProgramSettings.ReprocessingFacilityMoonRefineRateColumnName:
                                    {
                                        withBlock3.ReprocessingFacilityMoonRefineRate = i;
                                        break;
                                    }
                            }
                        }
                    }
                }
            }

        }

        private void chkLstBoxColumns_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SelectedIndex != chkLstBoxColumns.SelectedIndex)
            {
                SelectedIndex = chkLstBoxColumns.SelectedIndex;

                if (chkLstBoxColumns.GetItemChecked(chkLstBoxColumns.SelectedIndex))
                {
                    // Uncheckit
                    chkLstBoxColumns.SetItemChecked(chkLstBoxColumns.SelectedIndex, false);
                }
                else
                {
                    // Checkit
                    chkLstBoxColumns.SetItemChecked(chkLstBoxColumns.SelectedIndex, true);
                }

            }

        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            SettingsVariables.UserManufacturingTabColumnSettings = SettingsVariables.AllSettings.SetDefaultManufacturingTabColumnSettings();
            ShowList();
            chkLstBoxColumns.Update();
        }

        private void btnToggleAll_Click(object sender, EventArgs e)
        {
            CheckState CheckValue;

            if (ToggleAll)
            {
                CheckValue = CheckState.Unchecked;
                ToggleAll = false;
            }
            else
            {
                CheckValue = CheckState.Checked;
                ToggleAll = true;
            }

            for (int idx = 0, loopTo = chkLstBoxColumns.Items.Count - 1; idx <= loopTo; idx++)
                chkLstBoxColumns.SetItemCheckState(idx, CheckValue);

        }
    }
}