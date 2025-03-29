using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class ManufacturingFacility
    {

        private IndustryFacility SelectedFacility; // This is the active facility for the control, if not loaded will use the default
        private ProgramLocation SelectedLocation;
        private long SelectedCharacterID;
        private ProductionType SelectedProductionType;
        private Form SelectedControlForm; // Where the control lives

        private int SelectedBPTech;
        private int SelectedBPID;
        private int SelectedBPGroupID;
        private int SelectedBPCategoryID;

        // To check if we are loading and stop click events when changing values
        private bool LoadingActivities;
        private bool LoadingFacilityTypes;
        private bool LoadingRegions;
        private bool LoadingSystems;
        private bool LoadingFacilities;
        private bool ChangingUsageChecks;
        private bool UpdatingFWComboText;

        // To save previous values for checking and loading
        private ProductionType PreviousProductionType;
        private FacilityTypes PreviousFacilityType;
        private string PreviousRegion;
        private string PreviousSystem;
        private string PreviousEquipment;
        private string PreviousActivity;

        // Loaded variables
        private bool FacilityRegionsLoaded;
        private bool FacilitySystemsLoaded;
        private bool FacilityLoaded;

        private bool UpdatingManualBoxes;

        // Save these options here in the facility and allow functions to get the values publically
        private bool FacilityIncludeCopyCost;
        private bool FacilityIncludeCopyTime;
        private bool FacilityIncludeInventionCost;
        private bool FacilityIncludeInventionTime;

        // All locally saved facility variables will be here
        private IndustryFacility SelectedManufacturingFacility = new IndustryFacility();
        private IndustryFacility SelectedComponentManufacturingFacility = new IndustryFacility();
        private IndustryFacility SelectedCapitalComponentManufacturingFacility = new IndustryFacility();
        private IndustryFacility SelectedCapitalManufacturingFacility = new IndustryFacility();
        private IndustryFacility SelectedSuperManufacturingFacility = new IndustryFacility();
        private IndustryFacility SelectedT3CruiserManufacturingFacility = new IndustryFacility();
        private IndustryFacility SelectedT3DestroyerManufacturingFacility = new IndustryFacility();
        private IndustryFacility SelectedSubsystemManufacturingFacility = new IndustryFacility();
        private IndustryFacility SelectedBoosterManufacturingFacility = new IndustryFacility();
        private IndustryFacility SelectedInventionFacility = new IndustryFacility();
        private IndustryFacility SelectedT3InventionFacility = new IndustryFacility();
        private IndustryFacility SelectedCopyFacility = new IndustryFacility();
        private IndustryFacility SelectedReactionsFacility = new IndustryFacility();

        private IndustryFacility SelectedReprocessingFacility = new IndustryFacility();

        private IndustryFacility DefaultManufacturingFacility = new IndustryFacility();
        private IndustryFacility DefaultComponentManufacturingFacility = new IndustryFacility();
        private IndustryFacility DefaultCapitalComponentManufacturingFacility = new IndustryFacility();
        private IndustryFacility DefaultCapitalManufacturingFacility = new IndustryFacility();
        private IndustryFacility DefaultSuperManufacturingFacility = new IndustryFacility();
        private IndustryFacility DefaultT3CruiserManufacturingFacility = new IndustryFacility();
        private IndustryFacility DefaultT3DestroyerManufacturingFacility = new IndustryFacility();
        private IndustryFacility DefaultSubsystemManufacturingFacility = new IndustryFacility();
        private IndustryFacility DefaultBoosterManufacturingFacility = new IndustryFacility();
        private IndustryFacility DefaultInventionFacility = new IndustryFacility();
        private IndustryFacility DefaultT3InventionFacility = new IndustryFacility();
        private IndustryFacility DefaultCopyFacility = new IndustryFacility();
        private IndustryFacility DefaultReactionsFacility = new IndustryFacility();
        private IndustryFacility DefaultRefiningFacility = new IndustryFacility();

        // Constant activities
        public const string ActivityManufacturing = "Manufacturing";
        public const string ActivityComponentManufacturing = "Component Manufacturing";
        public const string ActivityCapComponentManufacturing = "Cap Component Manufacturing";
        public const string ActivityCopying = "Copying";
        public const string ActivityInvention = "Invention";
        public const string ActivityReactions = "Reactions";
        public const string ActivityReprocessing = "Reprocessing";

        // For verifying activity and facility type combos selected something
        private const string InitialTypeComboText = "Select Type";
        private const string InitialActivityComboText = "Select Activity";
        private const string InitialRegionComboText = "Select Region";
        private const string InitialSolarSystemComboText = "Select System";
        private const string InitialFacilityComboText = "Select Facility";

        public const string StationFacility = "Station";
        public const string StructureFacility = "Structure";

        private List<int> FactionCitadelList = new List<int>();

        private Color FacilityLabelDefaultColor = SystemColors.Highlight;
        private Color FacilityLabelNonDefaultColor = SystemColors.ButtonShadow;

        private enum StationServices
        {
            ReprocessingPlant = 5,
            Factory = 14,
            Laboratory = 15
        }

        public ManufacturingFacility()
        {
            Public_Variables.FirstLoad = true;

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

            // Hide everything until constructed with the options sent
            cmbFacilityActivities.Visible = false;
            lblFacilityActivity.Visible = false;
            lblFacilityUsage.Visible = false;
            chkFacilityToggle.Visible = false;
            lblFacilityFWUpgrade.Visible = false;
            cmbFacilityFWUpgrade.Visible = false;
            txtFacilityManualCost.Visible = false;
            lblFacilityManualCost.Visible = false;
            btnFacilityFitting.Visible = false;
            txtFacilityManualTax.Visible = false;
            lblFacilityManualTax.Visible = false;
            btnFacilitySave.Visible = false;
            txtFacilityManualTE.Visible = false;
            txtFacilityManualME.Visible = false;
            lblFacilityManualTE.Visible = false;
            lblFacilityManualME.Visible = false;
            lblInclude.Visible = false;
            chkFacilityIncludeUsage.Visible = false;
            chkFacilityIncludeTime.Visible = false;
            lblFacilityDefault.Visible = false;
            chkFacilityIncludeCost.Visible = false;
            cmbFacility.Visible = false;
            cmbFacilitySystem.Visible = false;
            cmbFacilityRegion.Visible = false;
            lblFacilityLocation.Visible = false;
            lblFacilityType.Visible = false;
            cmbFacilityType.Visible = false;
            cmbLargeShips.Visible = false;
            lblLargeShips.Visible = false;
            cmbFuelBlocks.Visible = false;
            lblFuelBlocks.Visible = false;
            cmbModules.Visible = false;
            lblModules.Visible = false;

            UpdatingManualBoxes = false;

            // For checking facilities later - will remove if we can get locations from ESI
            FactionCitadelList.Add(47512); // Moreau Fortizar
            FactionCitadelList.Add(47513); // Draccous Fortizar
            FactionCitadelList.Add(47514); // Horizion Fortizar
            FactionCitadelList.Add(47515); // Marginis Fortizar
            FactionCitadelList.Add(47516); // Prometheus Fortizar

            Public_Variables.FirstLoad = false;

            SelectedFacility = new IndustryFacility();

        }

        // Before any controls are shown, the control needs to be initilaized by sending the view type.
        public void InitializeControl(long SentSelectedCharacterID, ProgramLocation FormLocation, ProductionType InitialProductionType, ref Form ControlForm)
        {
            const int SolarSystemWidthBP = 142;
            const int SolarSystemWidthCalc = 157;

            const int RegionWidthBP = 130;
            const int RegionWidthCalc = 133;

            const int FacilityArrayWidthBP = 274;
            const int FacilityArrayWidthCalc = 295;

            const int LeftObjectLocation = 3;
            const int LeftLabelLocation = 1;

            const int DefaultLabelWidthBP = 48;
            const int DefaultLabelHeightBP = 34;

            // Save for later
            SelectedLocation = FormLocation;
            SelectedProductionType = InitialProductionType;
            SelectedCharacterID = SentSelectedCharacterID;
            SelectedControlForm = ControlForm;

            // Move and show the selected controls depending on the view sent
            switch (FormLocation)
            {
                case ProgramLocation.BlueprintTab:
                    {
                        lblFacilityActivity.Top = 1;
                        lblFacilityActivity.Left = LeftLabelLocation;
                        lblFacilityActivity.Visible = true;

                        cmbFacilityActivities.Top = lblFacilityActivity.Top + lblFacilityActivity.Height + 1;
                        cmbFacilityActivities.Left = LeftObjectLocation;
                        cmbFacilityActivities.Visible = true;
                        cmbFacilityActivities.Text = InitialActivityComboText;

                        lblFacilityType.Top = 1;
                        lblFacilityType.Left = cmbFacilityActivities.Left + cmbFacilityActivities.Width;
                        lblFacilityType.Visible = true;

                        cmbFacilityType.Top = cmbFacilityActivities.Top;
                        cmbFacilityType.Left = cmbFacilityActivities.Left + cmbFacilityActivities.Width + 2;
                        cmbFacilityType.Visible = true;
                        cmbFacilityType.Text = InitialTypeComboText;

                        lblFacilityDefault.Height = DefaultLabelHeightBP;
                        lblFacilityDefault.Width = DefaultLabelWidthBP;
                        lblFacilityDefault.SendToBack();
                        lblFacilityDefault.Top = lblFacilityType.Top + 5;
                        lblFacilityDefault.Left = cmbFacilityType.Left + cmbFacilityType.Width - 2;
                        lblFacilityDefault.Visible = true;

                        lblFacilityLocation.Top = cmbFacilityActivities.Top + cmbFacilityActivities.Height + 3;
                        lblFacilityLocation.Left = LeftLabelLocation;
                        lblFacilityLocation.Visible = true;

                        chkFacilityIncludeUsage.Top = lblFacilityLocation.Top - 1;
                        chkFacilityIncludeUsage.Left = lblFacilityLocation.Left + lblFacilityLocation.Width + 27;
                        chkFacilityIncludeUsage.Text = "Usage:";
                        chkFacilityIncludeUsage.Visible = true;

                        lblFacilityUsage.Top = chkFacilityIncludeUsage.Top - 1;
                        lblFacilityUsage.Left = chkFacilityIncludeUsage.Left + chkFacilityIncludeUsage.Width - 4;
                        lblFacilityUsage.Width = SolarSystemWidthBP;
                        lblFacilityUsage.Visible = true;

                        cmbFacilityRegion.Top = lblFacilityLocation.Top + lblFacilityLocation.Height + 3;
                        cmbFacilityRegion.Left = LeftObjectLocation;
                        cmbFacilityRegion.Width = RegionWidthBP;
                        cmbFacilityRegion.Text = InitialRegionComboText;
                        cmbFacilityRegion.Visible = true;

                        cmbFacilitySystem.Top = cmbFacilityRegion.Top;
                        cmbFacilitySystem.Left = cmbFacilityRegion.Left + cmbFacilityRegion.Width + 2;
                        cmbFacilitySystem.Width = SolarSystemWidthBP;
                        cmbFacilitySystem.Text = InitialSolarSystemComboText;
                        cmbFacilitySystem.Visible = true;

                        cmbFacility.Top = cmbFacilityRegion.Top + cmbFacilityRegion.Height + 1;
                        cmbFacility.Left = LeftObjectLocation;
                        cmbFacility.Width = FacilityArrayWidthBP;
                        cmbFacility.Text = InitialFacilityComboText;
                        cmbFacility.Visible = true;

                        btnFacilitySave.Top = cmbFacility.Top + cmbFacility.Height;
                        btnFacilitySave.Left = cmbFacility.Left + cmbFacility.Width - btnFacilitySave.Width + 1;
                        btnFacilitySave.Visible = true;
                        btnFacilitySave.Enabled = false;

                        btnFacilityFitting.Top = btnFacilitySave.Top;
                        btnFacilityFitting.Left = btnFacilitySave.Left - (btnFacilityFitting.Width + 2);
                        btnFacilityFitting.Visible = false;
                        btnFacilityFitting.Enabled = false;

                        LoadManualBoxes(InitialProductionType, FormLocation);

                        // Set initial settings to load 
                        if (SelectedBPID == 0)
                        {
                            SelectedBPCategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                            SelectedBPGroupID = (int)Public_Variables.ItemIDs.FrigateGroupID;
                            SelectedBPTech = (int)Public_Variables.BPTechLevel.T1;
                        }
                        else
                        {
                            // Set based on BP
                            SQLiteDataReader rsBP;
                            Public_Variables.DBCommand = new SQLiteCommand(string.Format("SELECT ITEM_GROUP_ID, ITEM_CATEGORY_ID, TECH_LEVEL FROM ALL_BLUEPRINTS_FACT WHERE BLUEPRINT_ID = {0}", SelectedBPID), Public_Variables.EVEDB.DBREf());
                            rsBP = Public_Variables.DBCommand.ExecuteReader();
                            rsBP.Read();
                            SelectedBPGroupID = rsBP.GetInt32(0);
                            SelectedBPCategoryID = rsBP.GetInt32(1);
                            SelectedBPTech = rsBP.GetInt32(2);
                            rsBP.Close();
                        }

                        break;
                    }

                case ProgramLocation.ManufacturingTab:
                    {

                        cmbFacilityActivities.Visible = false;

                        lblFacilityType.Top = 5;
                        lblFacilityType.Left = 0;
                        lblFacilityType.Visible = true;

                        cmbFacilityType.Top = lblFacilityType.Top - 2;
                        cmbFacilityType.Left = lblFacilityType.Width + 2;
                        cmbFacilityType.Visible = true;
                        cmbFacilityType.Text = InitialTypeComboText;

                        chkFacilityToggle.Top = lblFacilityType.Top - 2;
                        chkFacilityToggle.Left = cmbFacilityType.Left + cmbFacilityType.Width + 5;

                        chkFacilityIncludeUsage.Visible = true;
                        chkFacilityIncludeUsage.Left = chkFacilityToggle.Left;
                        chkFacilityIncludeUsage.Top = chkFacilityToggle.Top + chkFacilityToggle.Height - 1;

                        chkFacilityIncludeUsage.Text = "Include Usage";
                        chkFacilityIncludeTime.Visible = false;
                        chkFacilityIncludeCost.Visible = false;
                        lblInclude.Visible = false;

                        switch (InitialProductionType)
                        {
                            case ProductionType.CapitalComponentManufacturing:
                            case ProductionType.ComponentManufacturing:
                                {
                                    chkFacilityToggle.Visible = true;
                                    chkFacilityToggle.Text = "Cap Parts";
                                    if (InitialProductionType == ProductionType.CapitalComponentManufacturing)
                                    {
                                        chkFacilityToggle.Checked = true;
                                    }

                                    break;
                                }
                            case ProductionType.T3DestroyerManufacturing:
                            case ProductionType.T3CruiserManufacturing:
                                {
                                    chkFacilityToggle.Visible = true;
                                    chkFacilityToggle.Text = "Destroyers";
                                    if (InitialProductionType == ProductionType.T3DestroyerManufacturing)
                                    {
                                        chkFacilityToggle.Checked = true;
                                    }

                                    break;
                                }
                            case ProductionType.Invention:
                            case ProductionType.T3Invention:
                            case ProductionType.Copying:
                                {
                                    chkFacilityIncludeUsage.Text = "Usage";
                                    lblInclude.Top = lblFacilityType.Top;
                                    lblInclude.Left = chkFacilityIncludeUsage.Left - 2;
                                    lblInclude.Visible = true;
                                    chkFacilityIncludeCost.Top = chkFacilityIncludeUsage.Top;
                                    chkFacilityIncludeCost.Left = chkFacilityIncludeUsage.Left + chkFacilityIncludeUsage.Width;
                                    chkFacilityIncludeCost.Visible = true;
                                    chkFacilityIncludeTime.Top = chkFacilityIncludeUsage.Top;
                                    chkFacilityIncludeTime.Left = chkFacilityIncludeCost.Left + chkFacilityIncludeCost.Width;
                                    chkFacilityIncludeTime.Visible = true;
                                    break;
                                }

                            default:
                                {
                                    chkFacilityToggle.Visible = false;
                                    break;
                                }
                        }

                        lblFacilityLocation.Visible = true;
                        lblFacilityLocation.Left = 0;
                        lblFacilityLocation.Top = chkFacilityIncludeUsage.Top + 2;

                        cmbFacilityRegion.Left = LeftObjectLocation;
                        cmbFacilityRegion.Top = lblFacilityLocation.Top + lblFacilityLocation.Height + 2;
                        cmbFacilityRegion.Text = InitialRegionComboText;
                        cmbFacilityRegion.Width = RegionWidthCalc;
                        cmbFacilityRegion.Visible = true;

                        cmbFacilitySystem.Top = cmbFacilityRegion.Top;
                        cmbFacilitySystem.Left = chkFacilityIncludeUsage.Left;
                        cmbFacilitySystem.Width = SolarSystemWidthCalc;
                        cmbFacilitySystem.Text = InitialSolarSystemComboText;
                        cmbFacilitySystem.Visible = true;

                        cmbFacility.Top = cmbFacilityRegion.Top + cmbFacilityRegion.Height + 1;
                        cmbFacility.Left = LeftObjectLocation;
                        cmbFacility.Width = FacilityArrayWidthCalc;
                        cmbFacility.Text = InitialFacilityComboText;
                        cmbFacility.Visible = true;

                        lblFacilityDefault.Visible = true;
                        lblFacilityDefault.Top = chkFacilityToggle.Top;
                        lblFacilityDefault.Left = cmbFacility.Left + cmbFacility.Width - lblFacilityDefault.Width;
                        lblFacilityDefault.SendToBack();

                        btnFacilitySave.Top = cmbFacility.Top + cmbFacility.Height + 3;
                        btnFacilitySave.Left = cmbFacility.Left + cmbFacility.Width - btnFacilitySave.Width + 1;
                        btnFacilitySave.Visible = true;
                        btnFacilitySave.Enabled = false;

                        btnFacilityFitting.Top = btnFacilitySave.Top;
                        btnFacilityFitting.Left = btnFacilitySave.Left - (btnFacilityFitting.Width + 2);
                        btnFacilityFitting.Visible = false;
                        btnFacilityFitting.Enabled = false;

                        LoadManualBoxes(InitialProductionType, FormLocation);

                        // Position these but they will be shown later
                        lblModules.Top = cmbFacility.Top;
                        lblModules.Left = 0;
                        lblModules.Visible = false;
                        lblModules.SendToBack();

                        cmbModules.Top = lblModules.Top + lblModules.Height - 3;
                        cmbModules.Left = cmbFacilityRegion.Left;
                        cmbModules.Visible = false;

                        cmbFuelBlocks.Top = cmbModules.Top;
                        cmbFuelBlocks.Left = cmbModules.Left + cmbModules.Width + 2;
                        cmbFuelBlocks.Visible = false;

                        cmbLargeShips.Top = cmbModules.Top + cmbModules.Height + 1;
                        cmbLargeShips.Left = cmbModules.Left + cmbModules.Width + 2;
                        cmbLargeShips.Visible = false;

                        lblFuelBlocks.Top = cmbFuelBlocks.Top - lblFuelBlocks.Height - 1;
                        lblFuelBlocks.Left = cmbFuelBlocks.Left - 2;
                        lblFuelBlocks.Visible = false;

                        lblLargeShips.Left = lblModules.Left;
                        lblLargeShips.Top = lblFacilityFWUpgrade.Top;
                        lblLargeShips.Visible = false;

                        // Set the initial group/category IDs
                        // also set the activity combo text to show what type of activity this facility is, even if not visible
                        string argActivityComboText = cmbFacilityActivities.Text;
                        GetFacilityBPItemData(InitialProductionType, ref SelectedBPGroupID, ref SelectedBPCategoryID, ref SelectedBPTech, ref argActivityComboText);
                        cmbFacilityActivities.Text = argActivityComboText;
                        break;
                    }

                case ProgramLocation.MiningTab:
                case ProgramLocation.ReprocessingPlant:
                case ProgramLocation.SovBelts:
                case ProgramLocation.IceBelts:
                    {
                        cmbFacilityActivities.Visible = false;

                        lblFacilityType.Top = 5;
                        lblFacilityType.Left = 0;
                        lblFacilityType.Visible = true;

                        cmbFacilityType.Top = lblFacilityType.Top - 2;
                        cmbFacilityType.Left = lblFacilityType.Width + 2;
                        cmbFacilityType.Visible = true;
                        cmbFacilityType.Text = InitialTypeComboText;

                        chkFacilityToggle.Top = lblFacilityType.Top - 2;
                        chkFacilityToggle.Left = cmbFacilityType.Left + cmbFacilityType.Width + 5;

                        // Usage will be the facility tax for refining
                        chkFacilityIncludeUsage.Visible = true;
                        chkFacilityIncludeUsage.Left = chkFacilityToggle.Left;
                        chkFacilityIncludeUsage.Top = chkFacilityToggle.Top + chkFacilityToggle.Height - 1;

                        chkFacilityIncludeUsage.Text = "Include Reprocessing Tax";
                        chkFacilityIncludeTime.Visible = false;
                        chkFacilityIncludeCost.Visible = false;

                        lblFacilityUsage.Top = chkFacilityIncludeUsage.Top - 1;
                        lblFacilityUsage.Left = chkFacilityIncludeUsage.Left + chkFacilityIncludeUsage.Width;
                        lblFacilityUsage.Width = cmbFacilitySystem.Width - chkFacilityIncludeUsage.Width;
                        lblFacilityUsage.Visible = false;
                        lblFacilityUsage.Enabled = false;

                        chkFacilityToggle.Visible = false;

                        lblFacilityLocation.Visible = true;
                        lblFacilityLocation.Left = 0;
                        lblFacilityLocation.Top = chkFacilityIncludeUsage.Top + 2;

                        cmbFacilityRegion.Left = LeftObjectLocation;
                        cmbFacilityRegion.Top = lblFacilityLocation.Top + lblFacilityLocation.Height + 2;
                        cmbFacilityRegion.Text = InitialRegionComboText;
                        cmbFacilityRegion.Width = RegionWidthCalc;
                        cmbFacilityRegion.Visible = true;

                        cmbFacilitySystem.Top = cmbFacilityRegion.Top;
                        cmbFacilitySystem.Left = chkFacilityIncludeUsage.Left;
                        cmbFacilitySystem.Width = SolarSystemWidthCalc;
                        cmbFacilitySystem.Text = InitialSolarSystemComboText;
                        cmbFacilitySystem.Visible = true;

                        cmbFacility.Top = cmbFacilityRegion.Top + cmbFacilityRegion.Height + 1;
                        cmbFacility.Left = LeftObjectLocation;
                        cmbFacility.Width = FacilityArrayWidthCalc;
                        cmbFacility.Text = InitialFacilityComboText;
                        cmbFacility.Visible = true;

                        lblFacilityDefault.Visible = true;
                        lblFacilityDefault.Top = chkFacilityToggle.Top;
                        lblFacilityDefault.Left = cmbFacility.Left + cmbFacility.Width - lblFacilityDefault.Width;
                        lblFacilityDefault.SendToBack();

                        btnFacilitySave.Top = cmbFacility.Top + cmbFacility.Height + 2;
                        btnFacilitySave.Left = cmbFacility.Left + cmbFacility.Width - btnFacilitySave.Width + 1;
                        btnFacilitySave.Visible = true;
                        btnFacilitySave.Enabled = false;

                        btnFacilityFitting.Top = btnFacilitySave.Top;
                        btnFacilityFitting.Left = btnFacilitySave.Left - (btnFacilityFitting.Width + 2);
                        btnFacilityFitting.Visible = false;
                        btnFacilityFitting.Enabled = false;

                        LoadManualBoxes(InitialProductionType, FormLocation);

                        // Never will be visible for refining
                        lblFacilityManualCost.Visible = false;
                        txtFacilityManualCost.Visible = false;
                        txtFacilityManualTE.Visible = false;
                        lblFacilityManualTE.Visible = false;
                        cmbFacilityFWUpgrade.Visible = false;
                        lblFacilityFWUpgrade.Visible = false;
                        lblModules.Visible = false;
                        cmbModules.Visible = false;
                        cmbFuelBlocks.Visible = false;
                        cmbLargeShips.Visible = false;
                        lblFuelBlocks.Visible = false;
                        lblLargeShips.Visible = false;

                        // Set the initial group/category IDs
                        // also set the activity combo text to show what type of activity this facility is, even if not visible
                        string argActivityComboText1 = cmbFacilityActivities.Text;
                        GetFacilityBPItemData(InitialProductionType, ref SelectedBPGroupID, ref SelectedBPCategoryID, ref SelectedBPTech, ref argActivityComboText1);
                        cmbFacilityActivities.Text = argActivityComboText1;
                        break;
                    }

                default:
                    {
                        // Leave, no valid option sent
                        return;
                    }
            }

            // Load the defaults
            InitializeFacilities(FormLocation, InitialProductionType);

        }

        // Loads all the facilities for the view type sent to include defaults
        public void InitializeFacilities(ProgramLocation FacilityLocation, ProductionType InitialProductionType = ProductionType.Manufacturing, bool RefreshSelectedOnly = false)
        {

            if (FacilityLocation == ProgramLocation.BlueprintTab & !RefreshSelectedOnly)
            {
                // Load all the facilities for  tab - always start with manufacturing
                SelectedFacility.InitalizeFacility(ProductionType.Manufacturing, FacilityLocation);
                SelectedManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.ComponentManufacturing, FacilityLocation);
                SelectedComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.CapitalComponentManufacturing, FacilityLocation);
                SelectedCapitalComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultCapitalComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.CapitalManufacturing, FacilityLocation);
                SelectedCapitalManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultCapitalManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.SuperManufacturing, FacilityLocation);
                SelectedSuperManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultSuperManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.T3CruiserManufacturing, FacilityLocation);
                SelectedT3CruiserManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultT3CruiserManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.SubsystemManufacturing, FacilityLocation);
                SelectedSubsystemManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultSubsystemManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.BoosterManufacturing, FacilityLocation);
                SelectedBoosterManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultBoosterManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.Copying, FacilityLocation);
                SelectedCopyFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultCopyFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.Invention, FacilityLocation);
                SelectedInventionFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultInventionFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.Reactions, FacilityLocation);
                SelectedReactionsFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultReactionsFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.T3Invention, FacilityLocation);
                SelectedT3InventionFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultT3InventionFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.T3DestroyerManufacturing, FacilityLocation);
                SelectedT3DestroyerManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultT3DestroyerManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                SelectedFacility.InitalizeFacility(ProductionType.Reprocessing, FacilityLocation);
                // Set the refining rates for the reprocessing facility so these are set on first load
                SetRefiningRates(ref SelectedFacility);
                SelectedReprocessingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultRefiningFacility = (IndustryFacility)SelectedFacility.Clone();
            }

            else if (FacilityLocation == ProgramLocation.ManufacturingTab | RefreshSelectedOnly)
            {

                // Select what facility to load based on the industry type
                SelectedFacility.InitalizeFacility(InitialProductionType, FacilityLocation);

                SetSelectedFacility(InitialProductionType, FacilityLocation);
            }

            else if (FacilityLocation == ProgramLocation.MiningTab | FacilityLocation == ProgramLocation.ReprocessingPlant | FacilityLocation == ProgramLocation.SovBelts | FacilityLocation == ProgramLocation.IceBelts)
            {

                SelectedFacility.InitalizeFacility(ProductionType.Reprocessing, FacilityLocation);
                // Set the refining rates for the reprocessing facility so these are set on first load
                SetRefiningRates(ref SelectedFacility);
                SelectedReprocessingFacility = (IndustryFacility)SelectedFacility.Clone();
                DefaultRefiningFacility = (IndustryFacility)SelectedFacility.Clone();
            }
            else
            {
                // Leave, no valid option sent
                return;
            }

            // Reset these
            // To save previous values for checking and loading
            PreviousProductionType = ProductionType.None;
            PreviousFacilityType = FacilityTypes.None;
            PreviousRegion = "";
            PreviousSystem = "";
            PreviousEquipment = "";
            PreviousActivity = "";

            // Loaded variables
            FacilityRegionsLoaded = false;
            FacilitySystemsLoaded = false;
            FacilityLoaded = false;

            LoadingActivities = false;
            LoadingFacilityTypes = false;
            LoadingRegions = false;
            LoadingSystems = false;
            LoadingFacilities = false;
            ChangingUsageChecks = false;
            UpdatingFWComboText = false;

            // Load the selected facility with set bp
            LoadFacility(SelectedBPID, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech, true);

        }

        public void SetSelectedFacility(ProductionType BuildType, ProgramLocation FacilityLocation, bool LoadDualFacilities = true)
        {

            // Now save the default and selected facility to the appropriate variable
            switch (BuildType)
            {
                case ProductionType.Manufacturing:
                    {
                        SelectedManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
                case ProductionType.CapitalComponentManufacturing:
                    {
                        SelectedCapitalComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultCapitalComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        if (LoadDualFacilities)
                        {
                            // Load component too so we can click back and forth
                            SelectedFacility.InitalizeFacility(ProductionType.ComponentManufacturing, FacilityLocation);
                            SelectedComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            DefaultComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        }

                        break;
                    }
                case ProductionType.ComponentManufacturing:
                    {
                        SelectedComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        if (LoadDualFacilities)
                        {
                            // Load cap component too so we can click back and forth
                            SelectedFacility.InitalizeFacility(ProductionType.CapitalComponentManufacturing, FacilityLocation);
                            SelectedCapitalComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            DefaultCapitalComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        }

                        break;
                    }
                case ProductionType.CapitalManufacturing:
                    {
                        SelectedCapitalManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultCapitalManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
                case ProductionType.SuperManufacturing:
                    {
                        SelectedSuperManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultSuperManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
                case ProductionType.T3CruiserManufacturing:
                    {
                        SelectedT3CruiserManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultT3CruiserManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        if (LoadDualFacilities)
                        {
                            // Load T3 destroyers too so we can click back and forth
                            SelectedFacility.InitalizeFacility(ProductionType.T3DestroyerManufacturing, FacilityLocation);
                            SelectedT3DestroyerManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            DefaultT3DestroyerManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        }

                        break;
                    }
                case ProductionType.SubsystemManufacturing:
                    {
                        SelectedSubsystemManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultSubsystemManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
                case ProductionType.BoosterManufacturing:
                    {
                        SelectedBoosterManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultBoosterManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
                case ProductionType.Copying:
                    {
                        SelectedCopyFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultCopyFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
                case ProductionType.Invention:
                    {
                        SelectedInventionFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultInventionFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
                case ProductionType.Reactions:
                    {
                        SelectedReactionsFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultReactionsFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
                case ProductionType.T3Invention:
                    {
                        SelectedT3InventionFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultT3InventionFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
                case ProductionType.T3DestroyerManufacturing:
                    {
                        SelectedT3DestroyerManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultT3DestroyerManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        if (LoadDualFacilities)
                        {
                            // Load T3 cruisers too so we can click back and forth
                            SelectedFacility.InitalizeFacility(ProductionType.T3CruiserManufacturing, FacilityLocation);
                            SelectedT3CruiserManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            DefaultT3CruiserManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                        }

                        break;
                    }
                case ProductionType.Reprocessing:
                    {
                        SelectedReprocessingFacility = (IndustryFacility)SelectedFacility.Clone();
                        DefaultRefiningFacility = (IndustryFacility)SelectedFacility.Clone();
                        break;
                    }
            }

        }

        // Loads the class facility and objects
        public void LoadFacility(int ItemBPID, int ItemGroupID, int ItemCategoryID, int BlueprintTech, bool LoadDefault = false, bool ActivityComboSelect = false, bool RefreshBP = true, BuildMatType BuildT2T3Type = BuildMatType.AdvMaterials)
        {

            // Save these for later use
            SelectedBPID = ItemBPID;
            SelectedBPCategoryID = ItemCategoryID;
            SelectedBPGroupID = ItemGroupID;
            SelectedBPTech = BlueprintTech;

            // Process the activities combo if showing full controls
            if (SelectedLocation == ProgramLocation.BlueprintTab)
            {
                if (!ActivityComboSelect) // only load if from the activities combo
                {
                    LoadFacilityActivities(ItemGroupID, ItemCategoryID, BlueprintTech, SelectedBPID, BuildT2T3Type);
                }
                PreviousActivity = cmbFacilityActivities.Text;
            }

            // Get the production type, based on activity selected
            SelectedProductionType = GetProductionType(ItemGroupID, ItemCategoryID, cmbFacilityActivities.Text);

            // Reload the manual text boxes based on the production type
            LoadManualBoxes(SelectedProductionType, SelectedLocation);

            Application.DoEvents();

            // Look up Facility - activity set to facility inside
            SelectedFacility = SelectFacility(SelectedProductionType, LoadDefault);

            // Facility Type combo, load it if they want to change
            LoadFacilityTypes(SelectedProductionType, SelectedFacility.Activity);

            // Enable the type of facility and set
            LoadingFacilityTypes = true;
            cmbFacilityType.Enabled = true;
            cmbFacilityType.Text = GetFacilityNamefromCode(SelectedFacility.FacilityType);
            LoadingFacilityTypes = false;

            if (SelectedFacility.FacilityType == FacilityTypes.None)
            {
                // Just hide the boxes and exit
                SetFacilityBonusBoxes(false);
                SelectedFacility.FullyLoaded = true; // Even with none, it's loaded
                SetNoFacility();
                return; // Leave, all loaded
            }

            // Region name Combo
            LoadingRegions = true;
            cmbFacilityRegion.Enabled = true;
            cmbFacilityRegion.Text = SelectedFacility.RegionName;
            LoadingRegions = false;

            // Systems combo
            LoadingSystems = true;
            cmbFacilitySystem.Enabled = true;
            cmbFacilitySystem.Text = SelectedFacility.SolarSystemName;
            LoadingSystems = false;

            // Facility/Array combo
            LoadingFacilities = true;
            cmbFacility.Enabled = true;
            bool AutoLoad = false;
            LoadFacilities(false, ref SelectedFacility.Activity, ref AutoLoad, SelectedFacility.FacilityName);
            LoadingFacilities = false;

            // Usage checks
            ChangingUsageChecks = true;

            chkFacilityIncludeUsage.Checked = SelectedFacility.IncludeActivityUsage;
            chkFacilityIncludeCost.Checked = SelectedFacility.IncludeActivityCost;
            chkFacilityIncludeTime.Checked = SelectedFacility.IncludeActivityTime;

            chkFacilityConvertToOre.Checked = SelectedFacility.ConvertToOre;

            ChangingUsageChecks = false;

            // Finally show the results and save the facility locally
            if (!AutoLoad)
            {
                LoadingFacilities = true;
                {
                    ref var withBlock = ref SelectedFacility;
                    cmbFacility.Text = withBlock.FacilityName;
                    DisplayFacilityBonus(withBlock.FacilityProductionType, ItemGroupID, ItemCategoryID, SelectedFacility.Activity, GetFacilityTypeCode(cmbFacilityType.Text), cmbFacility.Text);
                }
                LoadingFacilities = false;
            }

            // Call ResetComboLoadVariables(False, False, False)

            // All data loaded
            SelectedFacility.FullyLoaded = true;

            // Facility is loaded, so save it to default and dynamic variable
            if (LoadDefault)
            {
                SetSelectedFacility(SelectedProductionType, SelectedLocation, false);
            }
            SetFacility(SelectedFacility, SelectedProductionType, false, false);

            // Refresh the blueprint if it's the bp tab
            if (RefreshBP)
            {
                UpdateBlueprint();
            }

        }

        // Loads the facility manual boxes depending on the type of facility
        private void LoadManualBoxes(ProductionType PT, ProgramLocation SentFrom)
        {
            const int LeftLabelLocation = 1;
            int Spacer = 0;

            if (SentFrom == ProgramLocation.BlueprintTab)
            {
                Spacer = 1;
            }

            // Load all the manual labels and text
            lblFacilityManualME.Top = btnFacilitySave.Top + 4;
            lblFacilityManualME.Left = LeftLabelLocation;
            txtFacilityManualME.Top = btnFacilitySave.Top + 1;
            txtFacilityManualME.Left = lblFacilityManualME.Left + lblFacilityManualME.Width;

            lblFacilityManualCost.Top = lblFacilityManualME.Top + lblFacilityManualME.Height + 8;
            lblFacilityManualCost.Left = LeftLabelLocation;
            lblFacilityManualCost.Text = "Cost:";
            txtFacilityManualCost.Top = txtFacilityManualME.Top + txtFacilityManualME.Height + 2;
            txtFacilityManualCost.Left = lblFacilityManualCost.Left + lblFacilityManualCost.Width;

            // Reset manual ME so it aligns with cost box
            txtFacilityManualME.Left = txtFacilityManualCost.Left;

            lblFacilityManualTE.Top = lblFacilityManualME.Top;
            lblFacilityManualTE.Left = txtFacilityManualME.Left + txtFacilityManualME.Width + 3;
            txtFacilityManualTE.Top = txtFacilityManualME.Top;
            txtFacilityManualTE.Left = lblFacilityManualTE.Left + lblFacilityManualTE.Width;

            lblFacilityManualTax.Top = lblFacilityManualCost.Top;
            lblFacilityManualTax.Left = txtFacilityManualCost.Left + txtFacilityManualCost.Width + 3;
            lblFacilityManualTax.Text = "Tax:";
            txtFacilityManualTax.Top = txtFacilityManualCost.Top;
            txtFacilityManualTax.Left = lblFacilityManualTax.Left + lblFacilityManualTax.Width;
            txtFacilityManualTE.Left = txtFacilityManualTax.Left;

            // FW Boxes - visible is set if the system is FW system - doesn't affect reprocessing so don't load for those
            cmbFacilityFWUpgrade.Top = btnFacilitySave.Top + btnFacilitySave.Height + 1;
            cmbFacilityFWUpgrade.Left = cmbFacility.Left + cmbFacility.Width - cmbFacilityFWUpgrade.Width;
            cmbFacilityFWUpgrade.Visible = false;

            lblFacilityFWUpgrade.Top = cmbFacilityFWUpgrade.Top + 2;
            lblFacilityFWUpgrade.Left = cmbFacilityFWUpgrade.Left - lblFacilityFWUpgrade.Width + 2;
            lblFacilityFWUpgrade.Visible = false;
            lblFacilityFWUpgrade.SendToBack();

            chkFacilityConvertToOre.Visible = false;
            btnConversiontoOreSettings.Visible = false;

            if (PT == ProductionType.Reprocessing)
            {
                int AdjustmentSpace;
                if (SelectedLocation == ProgramLocation.BlueprintTab)
                {
                    lblFacilityManualME.Text = "Ore Eff:";
                    AdjustmentSpace = 0;
                }
                else
                {
                    lblFacilityManualME.Text = "Base Efficiency:";
                    AdjustmentSpace = -2;
                }

                txtFacilityManualME.Left = lblFacilityManualME.Left + lblFacilityManualME.Width; // Reset this
                mainToolTip.SetToolTip(lblFacilityManualME, "This is the facilities base refining rate.");

                // Move the tax box up to match the TE box positions
                lblFacilityManualTax.Top = lblFacilityManualME.Top;
                lblFacilityManualTax.Left = txtFacilityManualME.Left + txtFacilityManualME.Width + 3 + AdjustmentSpace;
                txtFacilityManualTax.Top = txtFacilityManualME.Top;
                txtFacilityManualTax.Left = lblFacilityManualTax.Left + lblFacilityManualTax.Width + AdjustmentSpace;

                // Add reprocessing check and settings button if on BP tab and a refinery
                if (SelectedLocation == ProgramLocation.BlueprintTab)
                {
                    // Move the TE box under the ME box for Ore/Ice rates
                    lblFacilityManualTE.Top = lblFacilityManualME.Top + lblFacilityManualME.Height + 8;
                    lblFacilityManualTE.Left = LeftLabelLocation;
                    lblFacilityManualTE.Text = "Ice Eff:";
                    txtFacilityManualTE.Top = txtFacilityManualME.Top + txtFacilityManualME.Height + 2;
                    txtFacilityManualTE.Left = txtFacilityManualME.Left;

                    btnConversiontoOreSettings.Top = btnFacilitySave.Top + btnFacilitySave.Height + 1;
                    btnConversiontoOreSettings.Left = btnFacilitySave.Left - 16;
                    btnConversiontoOreSettings.Visible = true;

                    chkFacilityConvertToOre.Top = txtFacilityManualME.Top + txtFacilityManualME.Height + 6;
                    chkFacilityConvertToOre.Left = btnConversiontoOreSettings.Left - chkFacilityConvertToOre.Width + 5;
                    chkFacilityConvertToOre.Visible = true;

                    // Reset the left position of the tax box based on the check box for conversion
                    txtFacilityManualTax.Left = chkFacilityConvertToOre.Left;
                    lblFacilityManualTax.Left = txtFacilityManualTax.Left - lblFacilityManualTax.Width;
                }

                lblFacilityManualME.Visible = true;
                txtFacilityManualME.Visible = true;
                lblFacilityManualTE.Visible = true;
                txtFacilityManualTE.Visible = true;
                lblFacilityManualCost.Visible = false;
                txtFacilityManualCost.Visible = false;
                lblFacilityManualTax.Visible = true;
                txtFacilityManualTax.Visible = true;
            }

            else
            {
                lblFacilityManualME.Text = "ME:";
                mainToolTip.SetToolTip(lblFacilityManualME, "");
                lblFacilityManualTE.Text = "TE:";
                mainToolTip.SetToolTip(lblFacilityManualTE, "");

                lblFacilityManualME.Visible = true;
                txtFacilityManualME.Visible = true;
                lblFacilityManualCost.Visible = true;
                txtFacilityManualCost.Visible = true;
                lblFacilityManualTE.Visible = true;
                txtFacilityManualTE.Visible = true;
                lblFacilityManualTax.Visible = true;
                txtFacilityManualTax.Visible = true;
            }

        }

        // Loads the facility activity combo - checks group and category ID's if it has components to set component activities
        public void LoadFacilityActivities(int BPGroupID, int BPCategoryID, int BlueprintTech, int BPID, BuildMatType BuildMatTypeSelection)
        {

            LoadingActivities = true;
            bool HasComponents = false;
            string ActivityText = cmbFacilityActivities.Text; // Save what is selected first
            cmbFacilityActivities.BeginUpdate();

            // If it's a reaction, only load that activity and manufacturing for fuel blocks
            if (Public_Variables.IsReaction(BPGroupID) | BPCategoryID == (int)Public_Variables.ItemIDs.BoosterCategoryID)
            {
                cmbFacilityActivities.Items.Clear();
                cmbFacilityActivities.Items.Add(ActivityReactions);
                cmbFacilityActivities.Items.Add(ActivityManufacturing);
                // Add reprocessing due to minerals
                cmbFacilityActivities.Items.Add(ActivityReprocessing);

                // Start with reactions for a new facility because its a call to load not from combo
                cmbFacilityActivities.Text = ActivityReactions;

                cmbFacilityActivities.EndUpdate();
                LoadingActivities = false;
                return;
            }
            else
            {
                switch (BlueprintTech)
                {
                    case (int)Public_Variables.BPTechLevel.T1:
                        {
                            // Just manufacturing (add components later if there are any)
                            cmbFacilityActivities.Items.Clear();
                            cmbFacilityActivities.Items.Add(ActivityManufacturing);
                            break;
                        }

                    case (int)Public_Variables.BPTechLevel.T2:
                        {
                            // Add only T2 activities to equipment
                            cmbFacilityActivities.Items.Clear();
                            cmbFacilityActivities.Items.Add(ActivityManufacturing);
                            cmbFacilityActivities.Items.Add(ActivityCopying);
                            cmbFacilityActivities.Items.Add(ActivityInvention);
                            break;
                        }

                    case (int)Public_Variables.BPTechLevel.T3:
                        {
                            // Add only T3 activities to eqipment
                            cmbFacilityActivities.Items.Clear();
                            cmbFacilityActivities.Items.Add(ActivityManufacturing);
                            cmbFacilityActivities.Items.Add(ActivityInvention);
                            break;
                        }

                }
            }

            string SQL;
            SQLiteDataReader readerBP;

            // See if this has buildable components
            SQL = "SELECT DISTINCT 'X' FROM ALL_BLUEPRINTS ";
            SQL += "WHERE ITEM_ID IN (SELECT MATERIAL_ID FROM ALL_BLUEPRINT_MATERIALS WHERE BLUEPRINT_ID = {0})";
            Public_Variables.DBCommand = new SQLiteCommand(string.Format(SQL, BPID), Public_Variables.EVEDB.DBREf());
            readerBP = Public_Variables.DBCommand.ExecuteReader();

            if (readerBP.Read())
            {
                HasComponents = true;
            }
            else
            {
                HasComponents = false;
            }

            readerBP.Close();

            // Add components as a manufacturing facility option if this bp has any
            if (HasComponents)
            {
                switch (BPGroupID)
                {
                    case (int)Public_Variables.ItemIDs.TitanGroupID:
                    case (int)Public_Variables.ItemIDs.DreadnoughtGroupID:
                    case (int)Public_Variables.ItemIDs.CarrierGroupID:
                    case (int)Public_Variables.ItemIDs.SupercarrierGroupID:
                    case (int)Public_Variables.ItemIDs.CapitalIndustrialShipGroupID:
                    case (int)Public_Variables.ItemIDs.IndustrialCommandShipGroupID:
                    case (int)Public_Variables.ItemIDs.FreighterGroupID:
                    case (int)Public_Variables.ItemIDs.JumpFreighterGroupID:
                    case (int)Public_Variables.ItemIDs.FAXGroupID:
                        {
                            cmbFacilityActivities.Items.Add(ActivityCapComponentManufacturing);
                            if (BPGroupID == (int)Public_Variables.ItemIDs.JumpFreighterGroupID)
                            {
                                // Need to add both cap and components
                                cmbFacilityActivities.Items.Add(ActivityComponentManufacturing);
                            }

                            break;
                        }

                    default:
                        {
                            // Iif it's not a T2 component, then load the component manufacturing activity else it will get a reaction load below
                            if (!(BPCategoryID == (int)Public_Variables.ItemIDs.ComponentCategoryID | BPGroupID == (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID))
                            {
                                // Just regular
                                cmbFacilityActivities.Items.Add(ActivityComponentManufacturing);
                            }

                            break;
                        }
                }

                // If they want to drill down on reactions, add the reactions facility option
                if (Public_Variables.BPHasProcRawMats(BPID, BuildMatTypeSelection))
                {
                    cmbFacilityActivities.Items.Add(ActivityReactions);
                }

            }

            // If we are on the blueprint tab, then add reprocessing activity because everything can have minerals or the components do
            if (SelectedLocation == ProgramLocation.BlueprintTab)
            {
                cmbFacilityActivities.Items.Add(ActivityReprocessing);
            }

            cmbFacilityActivities.EndUpdate();

            // Set default activity text if it's not in the list
            if (!cmbFacilityActivities.Items.Contains(ActivityText))
            {
                cmbFacilityActivities.Text = ActivityManufacturing;
            }
            else
            {
                cmbFacilityActivities.Text = ActivityText;
            }

            LoadingActivities = false;

        }
        private void cmbFacilityActivities_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!LoadingActivities & !Public_Variables.FirstLoad)
            {
                SelectedProductionType = GetProductionType(SelectedBPGroupID, SelectedBPCategoryID, cmbFacilityActivities.Text);

                // If they switch the activity and it changed from the previous, then load the selected facility for this activity
                if (SelectedProductionType != PreviousProductionType)
                {
                    PreviousProductionType = SelectedProductionType;

                    // Load the facility for this activity and flag that it was loaded from this combo
                    LoadFacility(SelectedBPID, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech, false, true, false);

                    // Reset all previous to current list, since all the combos should be loaded
                    PreviousFacilityType = GetFacilityTypeCode(cmbFacilityType.Text);
                    PreviousEquipment = cmbFacility.Text;
                    PreviousRegion = cmbFacilityRegion.Text;
                    PreviousSystem = cmbFacilitySystem.Text;
                }

                if ((cmbFacilityActivities.Text ?? "") == ActivityReprocessing & SelectedLocation == ProgramLocation.BlueprintTab)
                {
                }
                // Show the combos for mineral conversion

                else
                {

                }

                // Make sure the usage is updated
                My.MyProject.Forms.frmMain.UpdateBPPriceLabels();

                cmbFacilityType.Focus();

            }
        }
        private void cmbFacilityActivities_DropDown(object sender, EventArgs e)
        {
            PreviousActivity = cmbFacilityActivities.Text;
        }
        private void cmbFacilityActivities_GotFocus(object sender, EventArgs e)
        {
            cmbFacilityActivities.SelectAll();
        }
        private void cmbFacilityActivities_LostFocus(object sender, EventArgs e)
        {
            cmbFacilityActivities.SelectionLength = 0;
        }
        private void cmbFacilityActivities_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // Loads the facility types in the sent combo
        public void LoadFacilityTypes(ProductionType FacilityProductionType, string FacilityActivity)
        {
            string Station = GetFacilityNamefromCode(FacilityTypes.Station);
            string UpwellStructure = GetFacilityNamefromCode(FacilityTypes.UpwellStructure);
            string NoneFacility = GetFacilityNamefromCode(FacilityTypes.None);

            LoadingFacilityTypes = true;
            LoadingRegions = true;
            LoadingSystems = true;
            LoadingFacilities = true;

            // Clear the types each time for a fresh set of options
            cmbFacilityType.Items.Clear();

            // Load the facility type options
            switch (FacilityActivity ?? "")
            {
                // Load up None for Invention/RE, Copy - they could buy the BP or T2 BPO
                case ActivityCopying:
                case ActivityInvention:
                    {
                        switch (FacilityProductionType)
                        {
                            case ProductionType.T3Invention:
                                {
                                    if (!string.IsNullOrEmpty(UpwellStructure))
                                        cmbFacilityType.Items.Add(UpwellStructure);
                                    if (!string.IsNullOrEmpty(NoneFacility))
                                        cmbFacilityType.Items.Add(NoneFacility);
                                    break;
                                }

                            default:
                                {
                                    if (!string.IsNullOrEmpty(Station))
                                        cmbFacilityType.Items.Add(Station);
                                    if (!string.IsNullOrEmpty(UpwellStructure))
                                        cmbFacilityType.Items.Add(UpwellStructure);
                                    if (!string.IsNullOrEmpty(NoneFacility))
                                        cmbFacilityType.Items.Add(NoneFacility);
                                    break;
                                }
                        }

                        break;
                    }
                case ActivityManufacturing:
                    {
                        switch (FacilityProductionType)
                        {
                            case ProductionType.SuperManufacturing:
                            case ProductionType.SubsystemManufacturing:
                            case ProductionType.T3CruiserManufacturing:
                            case ProductionType.T3DestroyerManufacturing:
                                {
                                    if (!string.IsNullOrEmpty(UpwellStructure))
                                        cmbFacilityType.Items.Add(UpwellStructure);
                                    break;
                                }

                            default:
                                {
                                    // Add all
                                    if (!string.IsNullOrEmpty(Station))
                                        cmbFacilityType.Items.Add(Station);
                                    if (!string.IsNullOrEmpty(UpwellStructure))
                                        cmbFacilityType.Items.Add(UpwellStructure);
                                    break;
                                }
                        }

                        break;
                    }
                case ActivityComponentManufacturing:
                case ActivityCapComponentManufacturing:
                    {
                        // Can do these anywhere
                        if (!string.IsNullOrEmpty(Station))
                            cmbFacilityType.Items.Add(Station);
                        if (!string.IsNullOrEmpty(UpwellStructure))
                            cmbFacilityType.Items.Add(UpwellStructure);
                        break;
                    }
                case ActivityReactions:
                    {
                        // Only in upwells
                        if (!string.IsNullOrEmpty(UpwellStructure))
                            cmbFacilityType.Items.Add(UpwellStructure);
                        break;
                    }
                case ActivityReprocessing:
                    {
                        // Can do these anywhere
                        if (!string.IsNullOrEmpty(Station))
                            cmbFacilityType.Items.Add(Station);
                        if (!string.IsNullOrEmpty(UpwellStructure))
                            cmbFacilityType.Items.Add(UpwellStructure);
                        break;
                    }
            }

            // Only reset if they changed it
            if (FacilityProductionType != PreviousProductionType | (FacilityActivity ?? "") != (PreviousActivity ?? ""))
            {
                // Reset all other dropdowns
                cmbFacilityType.Text = InitialTypeComboText;
                cmbFacilityRegion.Items.Clear();
                cmbFacilityRegion.Text = InitialRegionComboText;
                cmbFacilityRegion.Enabled = false;
                cmbFacilitySystem.Items.Clear();
                cmbFacilitySystem.Text = InitialSolarSystemComboText;
                cmbFacilitySystem.Enabled = false;
                cmbFacility.Items.Clear();
                cmbFacility.Text = InitialFacilityComboText;
                // Reset the facility so it can load later
                PreviousEquipment = InitialFacilityComboText;
                cmbFacility.Enabled = false;
                chkFacilityIncludeUsage.Enabled = false;
                chkFacilityIncludeCost.Enabled = false;
                chkFacilityIncludeTime.Enabled = false;

                PreviousProductionType = FacilityProductionType;
                PreviousActivity = FacilityActivity;

                SetFacilityBonusBoxes(false);

            }

            // Enable the facility type combo
            cmbFacilityType.Enabled = true;

            // Make sure default is not shown yet
            lblFacilityDefault.Visible = false;
            btnFacilitySave.Enabled = false;

            LoadingFacilityTypes = false;
            LoadingRegions = false;
            LoadingSystems = false;
            LoadingFacilities = false;

            ResetComboLoadVariables(false, false, false);

        }
        private void cmbFacilityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Don't do anything if it's the same as the old type
            if (PreviousFacilityType != GetFacilityTypeCode(cmbFacilityType.Text))
            {
                // Might not want to set a facility for copy or invention - "None" is an option for these two activities
                if (!LoadingFacilityTypes & !Public_Variables.FirstLoad & GetFacilityTypeCode(cmbFacilityType.Text) != FacilityTypes.None)
                {

                    string argFacilityActivity = cmbFacilityActivities.Text;
                    LoadFacilityRegions(SelectedBPGroupID, SelectedBPCategoryID, true, ref argFacilityActivity);
                    cmbFacilityActivities.Text = argFacilityActivity;
                    cmbFacilityRegion.Focus();
                }

                else if (GetFacilityTypeCode(cmbFacilityType.Text) == FacilityTypes.None) // Invention or Copy facility - set to none
                {

                    SetNoFacility();

                    // Allow this to be saved as a default though
                    btnFacilitySave.Enabled = true;
                    // changed so not the default
                    SetDefaultVisuals(false);
                    // Save the facility locally
                    DisplayFacilityBonus(SelectedProductionType, SelectedBPGroupID, SelectedBPCategoryID, cmbFacilityActivities.Text, GetFacilityTypeCode(cmbFacilityType.Text), cmbFacility.Text);
                }

                // Anytime this changes, set all the other ME/TE boxes to not viewed
                SetFacilityBonusBoxes(false);
                SelectedFacility.FullyLoaded = false;
                PreviousFacilityType = GetFacilityTypeCode(cmbFacilityType.Text);
                // Reset the previous records
                PreviousEquipment = "";
                PreviousRegion = "";
                PreviousSystem = "";

            }

            SetResetRefresh();

        }
        private void cmbFacilityType_DropDown(object sender, EventArgs e)
        {
            PreviousFacilityType = GetFacilityTypeCode(cmbFacilityType.Text);
        }
        private void cmbFacilityType_GotFocus(object sender, EventArgs e)
        {
            cmbFacilityType.SelectAll();
        }
        private void cmbFacilityType_LostFocus(object sender, EventArgs e)
        {
            cmbFacilityType.SelectionLength = 0;
            if (string.IsNullOrEmpty(Strings.Trim(cmbFacilityType.Text)))
            {
                cmbFacilityType.Text = GetFacilityNamefromCode(PreviousFacilityType);
            }
        }
        private void cmbFacilityType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // Based on the selections, load the region combo
        public void LoadFacilityRegions(int ItemGroupID, int ItemCategoryID, bool NewFacility, ref string FacilityActivity)
        {
            string SQL = "";

            LoadingRegions = true;
            LoadingSystems = true;
            LoadingFacilities = true;

            cmbFacilityRegion.Items.Clear();

            // Load regions from the facilities table - only load regions for our activity type and item group/category
            switch (cmbFacilityType.Text ?? "")
            {

                case StationFacility:
                    {

                        // Load the Stations in system for the activity we are doing
                        SQL = "SELECT DISTINCT regionName AS REGION_NAME FROM STATIONS, STATION_SERVICES, REGIONS ";
                        SQL += "WHERE STATIONS.STATION_ID = STATION_SERVICES.STATION_ID ";
                        SQL += "AND STATIONS.REGION_ID = REGIONS.regionID ";
                        SQL += "AND regionName NOT IN ('A821-A','J7HZ-F','PR-01','UUA-F4') AND regionName NOT LIKE 'ADR%' ";

                        switch (FacilityActivity ?? "")
                        {
                            case ActivityManufacturing:
                            case ActivityComponentManufacturing:
                            case ActivityCapComponentManufacturing:
                                {
                                    SQL += "AND SERVICE_ID = " + ((int)StationServices.Factory).ToString();
                                    break;
                                }
                            case ActivityCopying:
                            case ActivityInvention:
                                {
                                    SQL += "AND SERVICE_ID = " + ((int)StationServices.Laboratory).ToString();
                                    break;
                                }
                            case ActivityReprocessing:
                                {
                                    SQL += "AND SERVICE_ID = " + ((int)StationServices.ReprocessingPlant).ToString();
                                    break;
                                }
                        }

                        break;
                    }

                case StructureFacility:
                    {
                        // For Upwell Structures, load all regions as options, but adding only one wormhole region option and don't show Jove regions
                        SQL = "SELECT DISTINCT CASE WHEN (REGIONS.regionID >=11000000 and REGIONS.regionid <=11000030) THEN 'Wormhole Space' ELSE regionName END AS REGION_NAME ";
                        SQL += "FROM REGIONS, SOLAR_SYSTEMS ";
                        SQL += "WHERE SOLAR_SYSTEMS.regionID = REGIONS.regionID ";
                        SQL += "AND (factionID <> 500005 OR factionID IS NULL) ";
                        SQL += "AND regionName NOT IN ('A821-A','J7HZ-F','PR-01','UUA-F4') AND regionName NOT LIKE 'ADR%' ";

                        // Make sure the region listed has at least one system not in the disallowed anchoring lists
                        // Upwell Structures can be anchored almost anywhere except starter systems, trade hubs, and shattered wormholes (including Thera)
                        // Check both disallowable anchor tables
                        SQL += "AND (solarSystemID NOT IN (SELECT SOLAR_SYSTEM_ID FROM MAP_DISALLOWED_ANCHOR_CATEGORIES WHERE CATEGORY_ID = 65) AND ";
                        SQL += "solarSystemID NOT IN (SELECT SOLAR_SYSTEM_ID FROM MAP_DISALLOWED_ANCHOR_GROUPS WHERE GROUP_ID = 65)) ";

                        // For supers, only show null regions where you can have sov (no factionID excludes NPC null, etc)
                        if (ItemGroupID == (int)Public_Variables.ItemIDs.SupercarrierGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.TitanGroupID)
                        {
                            SQL += " AND security <= 0.0 AND factionID IS NULL AND regionName <> 'Wormhole Space' ";
                        }
                        else if (ItemGroupID == (int)Public_Variables.ItemIDs.DreadnoughtGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.CarrierGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.CapitalIndustrialShipGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.FAXGroupID | Public_Variables.IsReaction(ItemGroupID))
                        {
                            // For caps and reactions, only show low sec
                            SQL += " AND security < .45";
                        }

                        break;
                    }

            }

            SQL += " GROUP BY REGION_NAME ";

            SQLiteDataReader rsLoader;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsLoader = Public_Variables.DBCommand.ExecuteReader();

            while (rsLoader.Read())
                cmbFacilityRegion.Items.Add(rsLoader.GetString(0));

            rsLoader.Close();

            // Enable the region combo
            cmbFacilityRegion.Enabled = true;

            // Only turn off everything if it's set to select region
            if (NewFacility)
            {
                cmbFacilitySystem.Items.Clear();
                cmbFacilitySystem.Text = InitialSolarSystemComboText;
                cmbFacilitySystem.Enabled = false;
                cmbFacility.Items.Clear();
                cmbFacility.Text = InitialFacilityComboText;
                // Reset the facility so it can load later
                PreviousEquipment = InitialFacilityComboText;
                cmbFacility.Enabled = false;
                // Make sure default is not checked yet
                SetDefaultVisuals(false);
                btnFacilitySave.Enabled = false;
                btnFacilityFitting.Visible = false;
                chkFacilityIncludeUsage.Enabled = false;
                chkFacilityIncludeCost.Enabled = false;
                chkFacilityIncludeTime.Enabled = false;

                SetFacilityBonusBoxes(false);
            }

            // Only reset the region if the current selected region is not in list, also if it is in list, enable solarsystem
            if (!cmbFacilityRegion.Items.Contains(cmbFacilityRegion.Text))
            {
                cmbFacilityRegion.Text = "Select Region";
            }
            else
            {
                cmbFacilitySystem.Enabled = true;
            }

            LoadingRegions = false;
            LoadingSystems = false;
            LoadingFacilities = false;

            ResetComboLoadVariables(true, false, false);

        }
        private void cmbFacilityRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!LoadingRegions & !Public_Variables.FirstLoad & (PreviousRegion ?? "") != (cmbFacilityRegion.Text ?? ""))
            {
                string argFacilityActivity = cmbFacilityActivities.Text;
                LoadFacilitySystems(SelectedBPGroupID, SelectedBPCategoryID, true, ref argFacilityActivity);
                cmbFacilityActivities.Text = argFacilityActivity;
                cmbFacilitySystem.Focus();
                SetFacilityBonusBoxes(false);
                SelectedFacility.FullyLoaded = false;
                PreviousRegion = cmbFacilityRegion.Text;
            }

            SetResetRefresh();

        }
        private void cmbFacilityRegion_DropDown(object sender, EventArgs e)
        {
            // If you drop down, don't show the text window
            cmbFacilityRegion.AutoCompleteMode = AutoCompleteMode.None;

            if (!Public_Variables.FirstLoad & !FacilityRegionsLoaded)
            {
                PreviousRegion = cmbFacilityRegion.Text;
                // Save the current
                PreviousRegion = cmbFacilityRegion.Text;

                string argFacilityActivity = cmbFacilityActivities.Text;
                LoadFacilityRegions(SelectedBPGroupID, SelectedBPCategoryID, false, ref argFacilityActivity);
                cmbFacilityActivities.Text = argFacilityActivity;

            }
        }
        private void cmbFacilityRegion_GotFocus(object sender, EventArgs e)
        {
            cmbFacilityRegion.SelectAll();
        }
        private void cmbFacilityRegion_LostFocus(object sender, EventArgs e)
        {
            cmbFacilitySystem.SelectionLength = 0;
            if (string.IsNullOrEmpty(Strings.Trim(cmbFacilityRegion.Text)))
            {
                cmbFacilityRegion.Text = PreviousRegion;
            }
            // Look up entered item to make sure it's in the list, if not, then auto select
            // If Not cmbFacilityRegion.Items.Contains(cmbFacilityRegion.Text) Then
            // If SelectedFacility.RegionName <> InitialRegionComboText Then
            // cmbFacilityRegion.Text = SelectedFacility.RegionName
            // Else
            // ' Select the first thing 
            // cmbFacilityRegion.Text = cmbFacilityRegion.Items(0).ToString
            // End If
            // Else
            // If Not LoadingRegions And Not FirstLoad And PreviousRegion <> cmbFacilityRegion.Text Then
            // ' Need to load up the rest of the combos
            // Call LoadFacilitySystems(SelectedBPGroupID, SelectedBPCategoryID, True, cmbFacilityActivities.Text)
            // End If
            // End If
        }
        private void cmbFacilityRegion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // Based on the selections, load the systems combo
        public void LoadFacilitySystems(int ItemGroupID, int ItemCategoryID, bool NewFacility, ref string FacilityActivity)
        {
            string SQL = "";

            LoadingSystems = true;
            LoadingFacilities = true;

            cmbFacilitySystem.Items.Clear();

            switch (cmbFacilityType.Text ?? "")
            {

                case StationFacility:
                    {
                        if ((FacilityActivity ?? "") != ActivityReprocessing)
                        {
                            string ServiceIDSQL = "";
                            // Load the Stations in system for the activity we are doing
                            SQL = "SELECT DISTINCT solarSystemName AS SSN, CASE WHEN COST_INDEX IS NOT NULL THEN COST_INDEX ELSE 0 END AS CI ";
                            SQL += "FROM STATION_SERVICES, SOLAR_SYSTEMS, STATIONS ";
                            SQL += "LEFT JOIN INDUSTRY_SYSTEMS_COST_INDICIES ON INDUSTRY_SYSTEMS_COST_INDICIES.SOLAR_SYSTEM_ID = STATIONS.SOLAR_SYSTEM_ID ";
                            switch (FacilityActivity ?? "")
                            {
                                case ActivityManufacturing:
                                case ActivityComponentManufacturing:
                                case ActivityCapComponentManufacturing:
                                    {
                                        SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Manufacturing).ToString();
                                        ServiceIDSQL = " AND SERVICE_ID = " + ((int)StationServices.Factory).ToString();
                                        break;
                                    }
                                case ActivityCopying:
                                    {
                                        SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Copying).ToString();
                                        ServiceIDSQL = " AND SERVICE_ID = " + ((int)StationServices.Laboratory).ToString();
                                        break;
                                    }
                                case ActivityInvention:
                                    {
                                        SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Invention).ToString();
                                        ServiceIDSQL = " AND SERVICE_ID = " + ((int)StationServices.Laboratory).ToString();
                                        break;
                                    }
                                case ActivityReactions: // Shouldn't return anything until you can do reactions in stations
                                    {
                                        SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Reactions).ToString();
                                        ServiceIDSQL = " AND SERVICE_ID = " + ((int)StationServices.Factory).ToString();
                                        break;
                                    }
                            }
                            SQL += " WHERE STATIONS.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID ";
                            SQL += " AND STATIONS.STATION_ID = STATION_SERVICES.STATION_ID ";
                            SQL += " AND REGION_ID = " + Public_Variables.GetRegionID(cmbFacilityRegion.Text).ToString() + " ";
                            SQL += ServiceIDSQL;
                        }
                        else
                        {
                            // Refining doesn't have a cost index so just build a different query
                            SQL = "SELECT DISTINCT solarSystemName AS SSN, 0 AS CI ";
                            SQL += "FROM STATION_SERVICES, SOLAR_SYSTEMS, STATIONS ";
                            SQL += "WHERE STATIONS.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID ";
                            SQL += "AND STATIONS.STATION_ID = STATION_SERVICES.STATION_ID ";
                            SQL += "AND SERVICE_ID = " + ((int)StationServices.ReprocessingPlant).ToString() + " ";
                            SQL += "AND REGION_ID = " + Public_Variables.GetRegionID(cmbFacilityRegion.Text).ToString();
                        }

                        break;
                    }

                case StructureFacility:
                    {
                        if ((FacilityActivity ?? "") != ActivityReprocessing)
                        {
                            SQL = "SELECT DISTINCT solarSystemName AS SSN, CASE WHEN COST_INDEX IS NOT NULL THEN COST_INDEX ELSE 0 END AS CI ";
                            SQL += "FROM REGIONS, SOLAR_SYSTEMS ";
                            SQL += "LEFT JOIN INDUSTRY_SYSTEMS_COST_INDICIES ON solarSystemID = SOLAR_SYSTEM_ID ";

                            switch (FacilityActivity ?? "")
                            {
                                case ActivityManufacturing:
                                case ActivityComponentManufacturing:
                                case ActivityCapComponentManufacturing:
                                    {
                                        SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Manufacturing).ToString() + " ";
                                        break;
                                    }
                                case ActivityCopying:
                                    {
                                        SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Copying).ToString() + " ";
                                        break;
                                    }
                                case ActivityInvention:
                                    {
                                        SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Invention).ToString() + " ";
                                        break;
                                    }
                                case ActivityReactions:
                                    {
                                        SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Reactions).ToString() + " ";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            // Refining doesn't have a cost index so just build a different query
                            SQL = "SELECT DISTINCT solarSystemName AS SSN, 0 AS CI ";
                            SQL += "FROM REGIONS, SOLAR_SYSTEMS ";
                        }

                        SQL += "WHERE SOLAR_SYSTEMS.regionID = REGIONS.regionID ";

                        // Upwell Structures can be anchored almost anywhere except starter systems, trade hubs, and shattered wormholes (including Thera)
                        // Check both disallowable anchor tables
                        SQL += "AND (solarSystemID NOT IN (SELECT SOLAR_SYSTEM_ID FROM MAP_DISALLOWED_ANCHOR_CATEGORIES WHERE CATEGORY_ID = 65) AND ";
                        SQL += "solarSystemID NOT IN (SELECT SOLAR_SYSTEM_ID FROM MAP_DISALLOWED_ANCHOR_GROUPS WHERE GROUP_ID = 65)) ";

                        if (cmbFacilityRegion.Text == "Wormhole Space")
                        {
                            SQL += "AND SOLAR_SYSTEMS.regionID >=11000000 and SOLAR_SYSTEMS.regionid <=11000030 ";
                        }
                        else
                        {
                            // For an upwell, load all systems that have records linked
                            SQL += "AND regionName = '" + Public_Variables.FormatDBString(cmbFacilityRegion.Text) + "' ";
                        }

                        // For supers, only show null regions where you can have sov (no factionID excludes NPC null, etc)
                        if (ItemGroupID == (int)Public_Variables.ItemIDs.SupercarrierGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.TitanGroupID)
                        {
                            SQL += "AND security <= 0.0 AND factionID IS NULL AND regionName <> 'Wormhole Space' ";
                        }
                        else if ((ItemGroupID == (int)Public_Variables.ItemIDs.DreadnoughtGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.CarrierGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.CapitalIndustrialShipGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.FAXGroupID | Public_Variables.IsReaction(ItemGroupID)) & (FacilityActivity ?? "") == ActivityManufacturing | (FacilityActivity ?? "") == ActivityReactions)
                        {
                            // For caps and reactions, only show low sec
                            SQL += "AND security < .45 ";
                        }

                        break;
                    }

            }

            SQL += " GROUP BY SSN, CI";

            SQLiteDataReader rsLoader;
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsLoader = Public_Variables.DBCommand.ExecuteReader();

            while (rsLoader.Read())
            {
                if ((FacilityActivity ?? "") != ActivityReprocessing)
                {
                    cmbFacilitySystem.Items.Add(rsLoader.GetString(0) + " (" + Strings.FormatNumber(rsLoader.GetDouble(1), 3) + ")");
                }
                else
                {
                    cmbFacilitySystem.Items.Add(rsLoader.GetString(0));
                }
            }

            rsLoader.Close();

            // Enable the system combo
            cmbFacilitySystem.Enabled = true;

            // Only turn off everything if it's set to select a system
            if (NewFacility)
            {
                cmbFacility.Items.Clear();
                cmbFacility.Text = InitialFacilityComboText;
                // Reset the facility so it can load later
                PreviousEquipment = InitialFacilityComboText;
                cmbFacility.Enabled = false;
                // Make sure default is not checked yet
                SetDefaultVisuals(false);
                btnFacilitySave.Enabled = false;
                chkFacilityIncludeUsage.Enabled = false;
                chkFacilityIncludeCost.Enabled = false;
                chkFacilityIncludeTime.Enabled = false;

                SetFacilityBonusBoxes(false);
            }

            // Only reset the system if the current selected system is not in list, also if it is in list, enable facilty
            if (!cmbFacilitySystem.Items.Contains(cmbFacilitySystem.Text))
            {
                cmbFacilitySystem.Text = InitialSolarSystemComboText;
            }
            else
            {
                cmbFacility.Enabled = true;
            }

            LoadingSystems = false;
            LoadingFacilities = false;

            ResetComboLoadVariables(false, true, false);

        }
        private void cmbFacilitySystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OverrideFacilityName = "";
            bool Autoload = false;

            cmbFacilitySystem.SelectionLength = 0;

            if (!LoadingSystems & !Public_Variables.FirstLoad & (PreviousSystem ?? "") != (cmbFacilitySystem.Text ?? ""))
            {

                SetFacilityBonusBoxes(false);

                // Load the facilities
                string argFacilityActivity = cmbFacilityActivities.Text;
                LoadFacilities(false, ref argFacilityActivity, ref Autoload, OverrideFacilityName);
                cmbFacilityActivities.Text = argFacilityActivity;

                if (Autoload)
                {
                    SelectedFacility.FullyLoaded = true;
                    // Facility is loaded, so save it to default and dynamic variable
                    SetFacility(SelectedFacility, SelectedProductionType, false, false);
                    UpdateBlueprint();
                }
                else
                {
                    SetFacilityBonusBoxes(false);
                    SelectedFacility.FullyLoaded = false;
                }

                cmbFacility.Focus();

                PreviousSystem = cmbFacilitySystem.Text;
            }

            SetResetRefresh();

        }
        private void cmbFacilitySystem_DropDown(object sender, EventArgs e)
        {
            // If you drop down, don't show the text window
            cmbFacilitySystem.AutoCompleteMode = AutoCompleteMode.None;

            if (!FacilitySystemsLoaded & !Public_Variables.FirstLoad)
            {
                PreviousSystem = cmbFacilitySystem.Text;
                string argFacilityActivity = cmbFacilityActivities.Text;
                LoadFacilitySystems(SelectedBPGroupID, SelectedBPCategoryID, false, ref argFacilityActivity);
                cmbFacilityActivities.Text = argFacilityActivity;
            }
        }
        private void cmbFacilitySystem_GotFocus(object sender, EventArgs e)
        {
            cmbFacilitySystem.SelectAll();
        }
        private void cmbFacilitySystem_LostFocus(object sender, EventArgs e)
        {
            cmbFacilitySystem.SelectionLength = 0;
            if (string.IsNullOrEmpty(Strings.Trim(cmbFacilitySystem.Text)))
            {
                cmbFacilitySystem.Text = PreviousSystem;
            }
        }
        private void cmbFacilitySystem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // Based on the selections, load the facilities/arrays combo - an itemcategory or itemgroup id of -1 means to ignore it when filling arrays
        private void LoadFacilities(bool NewFacility, ref string FacilityActivity, ref bool AutoLoadFacility, string OverrideFacilityName = "")
        {
            string SQL = "";
            LoadingFacilities = true;

            string SystemName;
            if (cmbFacilitySystem.Text.Contains("("))
            {
                SystemName = cmbFacilitySystem.Text.Substring(0, Strings.InStr(cmbFacilitySystem.Text, "(") - 2);
            }
            else
            {
                SystemName = cmbFacilitySystem.Text;
            }

            var LocalFacilityType = GetFacilityTypeCode(cmbFacilityType.Text);

            if ((FacilityActivity ?? "") == ActivityReactions & LocalFacilityType == FacilityTypes.Station)
            {
                // Need to force it to use the upwell structure since we can only do reactions there
                LocalFacilityType = FacilityTypes.UpwellStructure;
                AutoLoadFacility = true;
            }

            switch (LocalFacilityType)
            {

                case FacilityTypes.Station:
                    {
                        // Load the Stations in system for the activity we are doing
                        SQL = "SELECT STATION_NAME AS FACILITY_NAME, STATIONS.STATION_ID FROM STATIONS, STATION_SERVICES ";
                        SQL += "WHERE STATIONS.STATION_ID = STATION_SERVICES.STATION_ID ";

                        switch (FacilityActivity ?? "")
                        {
                            case ActivityManufacturing:
                            case ActivityComponentManufacturing:
                            case ActivityCapComponentManufacturing:
                                {
                                    SQL += "AND SERVICE_ID = " + ((int)StationServices.Factory).ToString();
                                    break;
                                }
                            case ActivityCopying:
                            case ActivityInvention:
                                {
                                    SQL += "AND SERVICE_ID = " + ((int)StationServices.Laboratory).ToString();
                                    break;
                                }
                            case ActivityReprocessing:
                                {
                                    SQL += "AND SERVICE_ID = " + ((int)StationServices.ReprocessingPlant).ToString();
                                    break;
                                }
                        }

                        SQL += " AND REGION_ID = " + Public_Variables.GetRegionID(cmbFacilityRegion.Text).ToString();
                        SQL += " AND SOLAR_SYSTEM_ID = " + Public_Variables.GetSolarSystemID(SystemName).ToString();
                        break;
                    }

                case FacilityTypes.UpwellStructure:
                    {
                        // Load all the upwell structures based on the production type
                        SQL = "SELECT typeName as FACILITY_NAME, typeID FROM INVENTORY_TYPES, INVENTORY_GROUPS ";
                        SQL += "WHERE INVENTORY_GROUPS.categoryID = 65 ";
                        SQL += "AND INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupid ";
                        SQL += "AND INVENTORY_TYPES.published = 1 ";
                        SQL += "AND (typeID IN (SELECT value AS UPWELL_STRUCTURE_ID ";
                        SQL += "FROM TYPE_ATTRIBUTES, ATTRIBUTE_TYPES ";
                        SQL += "WHERE ATTRIBUTE_TYPES.attributeID = TYPE_ATTRIBUTES.attributeID ";
                        SQL += "AND attributeName Like 'canFitShipType%' ";
                        SQL += "AND TYPE_ATTRIBUTES.typeID = {0}) ";
                        SQL += "OR INVENTORY_TYPES.groupID In (Select value As UPWELL_STRUCTURE_ID ";
                        SQL += "FROM TYPE_ATTRIBUTES, ATTRIBUTE_TYPES ";
                        SQL += "WHERE ATTRIBUTE_TYPES.attributeID = TYPE_ATTRIBUTES.attributeID ";
                        SQL += "AND attributeName LIKE 'canFitShipGroup%' ";
                        SQL += "AND TYPE_ATTRIBUTES.typeID = {0})) ";

                        // Check for production types so that we don't show facilities that can't use services for that type (i.e. capital building)
                        switch (SelectedProductionType)
                        {
                            case ProductionType.BoosterManufacturing:
                                {
                                    SQL = string.Format(SQL, (int)Services.StandupBiochemicalReactor);
                                    break;
                                }
                            case ProductionType.CapitalManufacturing:
                                {
                                    SQL = string.Format(SQL, (int)Services.StandupCapitalShipyard);
                                    break;
                                }
                            case ProductionType.SuperManufacturing:
                                {
                                    SQL = string.Format(SQL, (int)Services.StandupSupercapitalShipyard);
                                    break;
                                }
                            case ProductionType.Copying:
                                {
                                    SQL = string.Format(SQL, (int)Services.StandupResearchLab);
                                    break;
                                }
                            case ProductionType.Invention:
                            case ProductionType.T3Invention:
                                {
                                    SQL = string.Format(SQL, (int)Services.StandupInventionLab);
                                    break;
                                }
                            case ProductionType.Reactions:
                                {
                                    SQL = string.Format(SQL, (int)Services.StandupCompositeReactor);
                                    break;
                                }
                            case ProductionType.Reprocessing:
                                {
                                    SQL = string.Format(SQL, (int)Services.StandupReprocessingFaclity); // All others get manufacturing
                                    break;
                                }

                            default:
                                {
                                    SQL = string.Format(SQL, (int)Services.StandupManufacturingPlant);
                                    break;
                                }
                        }

                        break;
                    }

            }

            // This is helpful if we auto-load (Capital array before super capital, equipment array before rapid equipment) to choose the one more likely
            SQL += " ORDER BY FACILITY_NAME";

            SQLiteDataReader rsLoader;
            SQLiteDataReader rsCheck;
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsLoader = Public_Variables.DBCommand.ExecuteReader();

            cmbFacility.Enabled = true;
            cmbFacility.Items.Clear();

            string AutoLoadName = "";
            int i = 0;

            while (rsLoader.Read())
            {
                if (FactionCitadelList.Contains(rsLoader.GetInt32(1)))
                {
                    // These are only in nullsec space (if we can look up in ESI then later maybe)
                    SQL = "SELECT security, factionID FROM REGIONS, SOLAR_SYSTEMS WHERE REGIONS.regionID = SOLAR_SYSTEMS.regionID ";
                    SQL += "AND factionID IS NULL AND regionName NOT LIKE '%-R%' "; // -R region names are wormhole regions
                    SQL += "AND security <= 0.0 AND SOLAR_SYSTEMS.solarSystemName = '" + SystemName + "'";

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsCheck = Public_Variables.DBCommand.ExecuteReader();

                    if (rsCheck.Read())
                    {
                        // no sov and it's nullsec, so add it
                        cmbFacility.Items.Add(rsLoader.GetString(0));
                    }
                    rsCheck.Close();
                }
                else
                {
                    cmbFacility.Items.Add(rsLoader.GetString(0));
                }

                i += 1; // get the count
                        // Load the first one - auto choose subsystem array over advanced medium array unless already selected
                if (string.IsNullOrEmpty(AutoLoadName) | rsLoader.GetString(0) == "Subsystem Assembly Array" & string.IsNullOrEmpty(OverrideFacilityName))
                {
                    AutoLoadName = rsLoader.GetString(0);
                }
            }

            rsLoader.Close();

            // Always load the facility if there is only one and we have a reference to auto load or we are loading a specific facility
            if (i == 1 & !(AutoLoadFacility == null) | cmbFacility.Items.Contains(OverrideFacilityName) | cmbFacility.Items.Contains(cmbFacility.Text) | OverrideFacilityName == "CalcBase")
            {
                // Check the override, if they want to use a rapid assembly it will override here, otherwise the other facility types should handle it (e.g. super, cap, etc)
                if (!string.IsNullOrEmpty(OverrideFacilityName) & cmbFacility.Items.Contains(OverrideFacilityName))
                {
                    cmbFacility.Text = OverrideFacilityName;
                }
                else if (cmbFacility.Items.Contains(cmbFacility.Text))
                {
                    // Leave it as is
                    Application.DoEvents();
                }
                else
                {
                    cmbFacility.Text = AutoLoadName;
                }

                AutoLoadFacility = true;
                // Display bonuses - Need to load everything since the array won't change to cause it to reload
                DisplayFacilityBonus(SelectedProductionType, SelectedBPGroupID, SelectedBPCategoryID, cmbFacilityActivities.Text, GetFacilityTypeCode(cmbFacilityType.Text), cmbFacility.Text);
            }
            else
            {
                if (!cmbFacility.Items.Contains(cmbFacility.Text))
                {
                    // Only load if the item isn't in the combo
                    switch (GetFacilityTypeCode(cmbFacilityType.Text))
                    {
                        case FacilityTypes.Station:
                            {
                                cmbFacility.Text = "Select Station";
                                break;
                            }
                        case FacilityTypes.UpwellStructure:
                            {
                                cmbFacility.Text = "Select Upwell Structure";
                                break;
                            }
                    }

                    // Make sure default is turned off since we still have to load the array
                    btnFacilitySave.Enabled = false;
                    SetDefaultVisuals(false);
                    chkFacilityIncludeUsage.Enabled = false; // Don't enable the usage either
                    chkFacilityIncludeCost.Enabled = false;
                    chkFacilityIncludeTime.Enabled = false;
                }
                else
                {
                    // Since this is a different system but facility is loaded, enable save
                    btnFacilitySave.Enabled = true;
                    SetDefaultVisuals(false);
                    chkFacilityIncludeUsage.Enabled = true;
                    chkFacilityIncludeCost.Enabled = true;
                    chkFacilityIncludeTime.Enabled = true;
                }

                AutoLoadFacility = false;

            }

            if (NewFacility)
            {
                // Make sure default is not checked yet
                SetDefaultVisuals(false);
                btnFacilitySave.Enabled = false;
                SetFacilityBonusBoxes(true, FacilityActivity);
            }

            // Users might select the facility drop down first, so reload all others
            ResetComboLoadVariables(false, false, true);

            LoadingFacilities = false;

            rsLoader.Close();
            rsLoader = null;
            Public_Variables.DBCommand = null;

        }
        private void cmbFacilityorArray_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!LoadingFacilities & !Public_Variables.FirstLoad & (PreviousEquipment ?? "") != (cmbFacility.Text ?? ""))
            {
                DisplayFacilityBonus(SelectedProductionType, SelectedBPGroupID, SelectedBPCategoryID, cmbFacilityActivities.Text, GetFacilityTypeCode(cmbFacilityType.Text), cmbFacility.Text);

                PreviousEquipment = cmbFacility.Text;
                UpdateBlueprint();
            }

            SetResetRefresh();

        }
        private void cmbFacilityorArray_DropDown(object sender, EventArgs e)
        {
            // If you drop down, don't show the text window
            cmbFacility.AutoCompleteMode = AutoCompleteMode.None;

            if (!FacilityLoaded & !Public_Variables.FirstLoad)
            {
                PreviousEquipment = cmbFacility.Text;
                string argFacilityActivity = cmbFacilityActivities.Text;
                bool argAutoLoadFacility = false;
                LoadFacilities(false, ref argFacilityActivity, ref argAutoLoadFacility, "");
                cmbFacilityActivities.Text = argFacilityActivity;
            }
        }
        private void cmbFacilityorArray_GotFocus(object sender, EventArgs e)
        {
            cmbFacility.SelectAll();
        }
        private void cmbFacilityorArray_LostFocus(object sender, EventArgs e)
        {
            cmbFacility.SelectionLength = 0;
            if (string.IsNullOrEmpty(Strings.Trim(cmbFacility.Text)))
            {
                cmbFacility.Text = PreviousEquipment;
            }
        }
        private void cmbFacilityorArray_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void lblFacilityDefault_DoubleClick(object sender, EventArgs e)
        {
            // Load the default facility for the selected activity if it's not already the default
            if (lblFacilityDefault.ForeColor == SystemColors.ButtonShadow)
            {
                LoadingActivities = true; // Don't trigger a combo load yet
                var SelectedFacility = new IndustryFacility();
                string SelectedActivity = "";
                int BPID = 0;
                int ItemGroupID = 0;
                int ItemCategoryID = 0;
                int TechLevel = 0;
                string Activity = "";
                var OriginalProductionType = SelectedProductionType;

                SelectedFacility = SelectFacility(OriginalProductionType, true);

                if (!(Public_Variables.SelectedBlueprint == null))
                {
                    {
                        ref var withBlock = ref Public_Variables.SelectedBlueprint;
                        BPID = withBlock.GetBPID();
                        ItemGroupID = withBlock.GetItemGroupID();
                        ItemCategoryID = withBlock.GetItemCategoryID();
                        TechLevel = withBlock.GetTechLevel();
                    }
                }
                else if (SelectedLocation == ProgramLocation.ManufacturingTab)
                {
                    BPID = 0; // this only matters for the activity combo
                              // For the manufacturing tab, we manually put in the IDs, so get the data first
                    GetFacilityBPItemData(OriginalProductionType, ref ItemGroupID, ref ItemCategoryID, ref TechLevel, ref Activity);
                }

                // Load up the default based on the BPID - assume we selected from combo to bypass loading activities again
                LoadFacility(BPID, ItemGroupID, ItemCategoryID, TechLevel, true, true);

                // If ReactionTypes.Contains(SelectedBlueprint.GetItemGroup) And OriginalProductionType = ProductionType.Manufacturing Then
                // ' Need to make sure the default of the manufacturing facility is loaded and not reactions
                // ' Use the Fuelblock blueprint data
                // Call LoadFacility(4314, 1136, 4, 1, True)
                // End If

                // Set the default based on the checkbox 
                SetFacility(SelectedFacility, OriginalProductionType, false, false);

                LoadingActivities = false;
            }
        }

        // Displays the bonus for the facility selected in the facility or array combo
        private void DisplayFacilityBonus(ProductionType BuildType, int ItemGroupID, int ItemCategoryID, string Activity, FacilityTypes FacilityType, string FacilityName)
        {
            string SQL = "";
            SQLiteDataReader rsLoader;

            long FacilityID;
            double DFMaterialMultiplier = 0d;
            double DFTimeMultiplier = 0d;
            double DFCostMultiplier = 0d;
            double DFTax = 0d;
            double SavedMaterialMultiplier = -1;
            double SavedTimeMultiplier = -1;
            double SavedCostMultiplier = -1;
            double SavedTax = -1;

            double StructureModifier = 0d;
            var TempDefaultFacility = new IndustryFacility();

            string CostText;
            string TaxText;
            string MMText;
            string TMText;

            // Get the facility ID first
            // Not in there for either character or default, so use the defaults
            if (FacilityType == FacilityTypes.Station)
            {
                // Load the Stations in system for the activity we are doing
                SQL = "SELECT STATION_ID FROM STATIONS WHERE STATION_NAME ='" + Public_Variables.FormatDBString(FacilityName) + "' ";
            }
            else if (FacilityType == FacilityTypes.UpwellStructure)
            {
                SQL = "SELECT UPWELL_STRUCTURE_TYPE_ID FROM UPWELL_STRUCTURES WHERE UPWELL_STRUCTURE_NAME = '" + Public_Variables.FormatDBString(FacilityName) + "' ";
            }

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsLoader = Public_Variables.DBCommand.ExecuteReader();
            rsLoader.Read();

            if (rsLoader.HasRows)
            {
                FacilityID = rsLoader.GetInt64(0);
            }
            else
            {
                FacilityID = -1;
            }

            rsLoader.Close();

            string CharID = "";

            // See what type of character ID
            if (SettingsVariables.UserApplicationSettings.SaveFacilitiesbyChar)
            {
                CharID = Public_Variables.SelectedCharacter.ID.ToString();
            }
            else
            {
                CharID = Public_Variables.CommonSavedFacilitiesID.ToString();
            }

            // Process system if needed
            string SystemName;
            if (cmbFacilitySystem.Text.Contains("("))
            {
                SystemName = cmbFacilitySystem.Text.Substring(0, Strings.InStr(cmbFacilitySystem.Text, "(") - 2);
            }
            else
            {
                SystemName = cmbFacilitySystem.Text;
            }

            long SystemID = Public_Variables.GetSolarSystemID(SystemName);

            if (FacilityType != FacilityTypes.None)
            {

                // First, see if this facility is a saved facility, and use the values saved in the table
                SQL = "SELECT FACILITY_ID, FACILITY_TAX, MATERIAL_MULTIPLIER, TIME_MULTIPLIER, COST_MULTIPLIER ";
                SQL += "FROM SAVED_FACILITIES ";
                SQL += "WHERE CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND FACILITY_TYPE = {2} AND FACILITY_VIEW = {3} ";
                SQL += "AND REGION_ID = " + Public_Variables.GetRegionID(cmbFacilityRegion.Text).ToString() + " ";
                SQL += "AND SOLAR_SYSTEM_ID = " + SystemID.ToString() + " ";
                SQL += "AND FACILITY_ID = {4}";

                // First look up the character to see if it's saved there first (initially only do one set of facilities then allow by character via a setting)
                Public_Variables.DBCommand = new SQLiteCommand(string.Format(SQL, CharID, ((int)BuildType).ToString(), ((int)FacilityType).ToString(), ((int)SelectedLocation).ToString(), FacilityID.ToString()), Public_Variables.EVEDB.DBREf());
                rsLoader = Public_Variables.DBCommand.ExecuteReader();
                rsLoader.Read();

                if (!rsLoader.HasRows)
                {
                    // Need to look up the default - CharID = 0
                    rsLoader.Close();
                    Public_Variables.DBCommand = new SQLiteCommand(string.Format(SQL, "0", ((int)BuildType).ToString(), ((int)FacilityType).ToString(), ((int)SelectedLocation).ToString(), FacilityID.ToString()), Public_Variables.EVEDB.DBREf());
                    rsLoader = Public_Variables.DBCommand.ExecuteReader();
                    rsLoader.Read();
                }

                // Load values from the saved facility
                if (rsLoader.HasRows)
                {

                    // Save the values from the saved information - saved facility values
                    if (!(rsLoader.GetValue(1) is DBNull))
                    {
                        SavedTax = rsLoader.GetDouble(1);
                    }

                    if (!(rsLoader.GetValue(2) is DBNull))
                    {
                        SavedMaterialMultiplier = rsLoader.GetDouble(2);
                    }

                    if (!(rsLoader.GetValue(3) is DBNull))
                    {
                        SavedTimeMultiplier = rsLoader.GetDouble(3);
                    }

                    if (!(rsLoader.GetValue(4) is DBNull))
                    {
                        SavedCostMultiplier = rsLoader.GetDouble(4);
                    }
                }

                rsLoader.Close();

                if (FacilityID != -1)
                {
                    // Pull default data for ME/TE/CE
                    switch (FacilityType)
                    {
                        case FacilityTypes.Station:
                            {
                                if (BuildType == ProductionType.Reprocessing)
                                {
                                    // Get Refine rate and tax for station
                                    SelectedFacility.BaseTax = SelectedFacility.CalculateStationReprocessingTaxRate(SelectedCharacterID, FacilityID, ref SelectedFacility.BaseME);
                                }
                                else
                                {
                                    SelectedFacility.BaseTax = SettingsVariables.UserApplicationSettings.StationTaxRate;
                                    SelectedFacility.BaseCost = 1d;

                                    // Special case to update for Fulcrum if the BP is a sub-cap Angel or Gurista ship
                                    if (Public_Variables.GetFulcrumBonusFlagforItem(FacilityID, SelectedBPID))
                                    {
                                        // Override the ME and TE bonus for fulcrum on this bp
                                        SelectedFacility.BaseME = 0.94d;
                                        SelectedFacility.BaseTE = 0.3d;
                                    }
                                    else
                                    {
                                        // For production in stations, they are always 1
                                        SelectedFacility.BaseME = 1d;
                                        SelectedFacility.BaseTE = 1d;
                                    }
                                }

                                break;
                            }

                        case FacilityTypes.UpwellStructure:
                            {

                                // Get the base facilility multipler - reprocessing is always base modified by the structure multiplier - REPLACE WITH ATTRIBUTES!
                                SQL = "SELECT CASE WHEN ACTIVITY_ID = -2 THEN " + Public_Variables.BaseRefineRate.ToString() + " * (1 + MATERIAL_MULTIPLIER) ELSE MATERIAL_MULTIPLIER END,";
                                SQL += "TIME_MULTIPLIER, COST_MULTIPLIER FROM UPWELL_STRUCTURES WHERE UPWELL_STRUCTURE_NAME = '" + Public_Variables.FormatDBString(FacilityName) + "' ";

                                switch (Activity ?? "")
                                {
                                    case ActivityManufacturing:
                                    case ActivityComponentManufacturing:
                                    case ActivityCapComponentManufacturing:
                                        {
                                            SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Manufacturing).ToString() + " ";
                                            break;
                                        }
                                    case ActivityCopying:
                                        {
                                            SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Copying).ToString() + " ";
                                            break;
                                        }
                                    case ActivityInvention:
                                        {
                                            SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Invention).ToString() + " ";
                                            break;
                                        }
                                    case ActivityReactions:
                                        {
                                            SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Reactions).ToString() + " ";
                                            break;
                                        }
                                    case ActivityReprocessing:
                                        {
                                            SQL += "AND ACTIVITY_ID = " + ((int)IndustryActivities.Reprocessing).ToString() + " ";
                                            break;
                                        }
                                }

                                SQLiteDataReader rsStats;
                                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                                rsStats = Public_Variables.DBCommand.ExecuteReader();
                                rsStats.Read();

                                // Set base multipliers 
                                SelectedFacility.BaseME = rsStats.GetDouble(0);
                                SelectedFacility.BaseTE = rsStats.GetDouble(1);
                                SelectedFacility.BaseCost = rsStats.GetDouble(2);
                                SelectedFacility.BaseTax = SettingsVariables.UserApplicationSettings.StructureTaxRate;

                                rsStats.Close();
                                break;
                            }

                    }
                }
                else
                {
                    // Set the facility to none if not found
                    FacilityType = FacilityTypes.None;
                }

            }

            // None selected or not found
            if (FacilityType == FacilityTypes.None)
            {
                var Defaults = new ProgramSettings();
                FacilityName = Public_Variables.None;
                FacilityID = 0L;
                SelectedFacility.BaseME = Defaults.FacilityDefaultMM;
                SelectedFacility.BaseTE = Defaults.FacilityDefaultTM;
                SelectedFacility.BaseCost = Defaults.FacilityDefaultCM;
                SelectedFacility.BaseTax = Defaults.FacilityDefaultTax;
            }

            // Now that we have everything, load the full facility into the appropriate selected facility to use later
            {
                ref var withBlock = ref SelectedFacility;

                DFMaterialMultiplier = withBlock.BaseME;
                DFTimeMultiplier = withBlock.BaseTE;
                DFCostMultiplier = withBlock.BaseCost;
                DFTax = withBlock.BaseTax;

                withBlock.ActivityCostPerSecond = 0d;
                switch (Activity ?? "")
                {
                    case ActivityManufacturing:
                    case ActivityComponentManufacturing:
                    case ActivityCapComponentManufacturing:
                        {
                            withBlock.ActivityID = (int)IndustryActivities.Manufacturing;
                            break;
                        }
                    case ActivityCopying:
                        {
                            withBlock.ActivityID = (int)IndustryActivities.Copying;
                            break;
                        }
                    case ActivityInvention:
                        {
                            withBlock.ActivityID = (int)IndustryActivities.Invention;
                            break;
                        }
                    case ActivityReactions:
                        {
                            withBlock.ActivityID = (int)IndustryActivities.Reactions;
                            break;
                        }
                    case ActivityReprocessing:
                        {
                            withBlock.ActivityID = (int)IndustryActivities.Reprocessing;
                            break;
                        }
                }

                withBlock.Activity = Activity;
                withBlock.FacilityID = FacilityID;
                withBlock.FacilityName = FacilityName;
                withBlock.FacilityType = FacilityType;
                withBlock.RegionName = cmbFacilityRegion.Text;
                withBlock.SolarSystemName = cmbFacilitySystem.Text;
                withBlock.SolarSystemID = SystemID;
                withBlock.FacilityProductionType = BuildType;

                // First, if this is a citadel, then look up any saved modules and adjust the MM/TM/CM
                if (FacilityType == FacilityTypes.UpwellStructure)
                {
                    // Refresh the installed rig list
                    withBlock.UpdateProductionFittingInformation(Conversions.ToLong(CharID));

                    DFMaterialMultiplier *= 1d - withBlock.GetFacilityBonusMulitiplier(IndustryFacility.ModifierType.MaterialModifier, withBlock.ActivityID, ItemGroupID, ItemCategoryID);
                    DFTimeMultiplier *= 1d - withBlock.GetFacilityBonusMulitiplier(IndustryFacility.ModifierType.TimeModifier, withBlock.ActivityID, ItemGroupID, ItemCategoryID);
                    DFCostMultiplier *= 1d - withBlock.GetFacilityBonusMulitiplier(IndustryFacility.ModifierType.CostModifier, withBlock.ActivityID, ItemGroupID, ItemCategoryID);
                }

                // Set the final rates on what we calculated or saved
                if (SavedTax == -1)
                {
                    withBlock.TaxRate = DFTax;
                }
                else
                {
                    withBlock.TaxRate = SavedTax;
                }

                if (SavedMaterialMultiplier == -1)
                {
                    withBlock.MaterialMultiplier = DFMaterialMultiplier;
                }
                else
                {
                    withBlock.MaterialMultiplier = SavedMaterialMultiplier;
                }

                if (SavedTimeMultiplier == -1)
                {
                    withBlock.TimeMultiplier = DFTimeMultiplier;
                }
                else
                {
                    withBlock.TimeMultiplier = SavedTimeMultiplier;
                }

                if (SavedCostMultiplier == -1)
                {
                    withBlock.CostMultiplier = DFCostMultiplier;
                }
                else
                {
                    withBlock.CostMultiplier = SavedCostMultiplier;
                }

                if (FacilityType != FacilityTypes.None)
                {
                    // Quick look up for the solarsystemid and region id
                    SQL = "SELECT security, regionID FROM SOLAR_SYSTEMS WHERE solarSystemID = " + SystemID.ToString();

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsLoader = Public_Variables.DBCommand.ExecuteReader();
                    rsLoader.Read();

                    withBlock.SolarSystemID = SystemID;
                    withBlock.SolarSystemSecurity = rsLoader.GetDouble(0);
                    withBlock.RegionID = rsLoader.GetInt64(1);
                    rsLoader.Close();

                    // Now look up the cost index 
                    SQL = "SELECT COST_INDEX FROM INDUSTRY_SYSTEMS_COST_INDICIES ";
                    SQL += "WHERE INDUSTRY_SYSTEMS_COST_INDICIES.SOLAR_SYSTEM_ID = " + withBlock.SolarSystemID + " ";
                    SQL += "AND INDUSTRY_SYSTEMS_COST_INDICIES.ACTIVITY_ID = " + withBlock.ActivityID + " ";

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsLoader = Public_Variables.DBCommand.ExecuteReader();

                    if (rsLoader.Read())
                    {
                        withBlock.CostIndex = rsLoader.GetDouble(0);
                    }
                    else
                    {
                        withBlock.CostIndex = 0d;
                    }

                    rsLoader.Close();
                }
                else
                {
                    withBlock.SolarSystemID = 0L;
                    withBlock.RegionID = 0L;
                    withBlock.CostIndex = 0d;
                }

                // Always display the bonus, not the multiplier
                if ((Activity ?? "") == ActivityReprocessing)
                {
                    // Reset the refine rates first, then refresh
                    SetRefiningRates(ref SelectedFacility);
                    // This is just the calculated value since it's really not a multiplier - get full value
                    if (SelectedLocation == ProgramLocation.BlueprintTab)
                    {
                        MMText = Strings.FormatPercent(withBlock.OreFacilityRefineRate, 2);
                        TMText = Strings.FormatPercent(withBlock.IceFacilityRefineRate, 2);
                    }
                    else
                    {
                        MMText = Strings.FormatPercent(withBlock.MaterialMultiplier, 2); // For non-BP reprocessing facilties, show the base rate only
                        TMText = Strings.FormatPercent(1d - withBlock.TimeMultiplier, 2);
                    }
                }
                else
                {
                    MMText = Strings.FormatPercent(1d - SelectedFacility.MaterialMultiplier, 2);
                    TMText = Strings.FormatPercent(1d - SelectedFacility.TimeMultiplier, 2);
                }

                CostText = Strings.FormatPercent(1d - SelectedFacility.CostMultiplier, 2);
                TaxText = Strings.FormatPercent(SelectedFacility.TaxRate, 2);
            }

            if (FacilityType == FacilityTypes.UpwellStructure)
            {
                if (SelectedProductionType == ProductionType.Reprocessing)
                {
                    txtFacilityManualME.Enabled = false; // Disable the updating of base refining efficiency
                    txtFacilityManualTE.Enabled = false;
                }
                else
                {
                    txtFacilityManualME.Enabled = true;
                    txtFacilityManualTE.Enabled = true;
                }
                txtFacilityManualTax.Enabled = true;
                txtFacilityManualCost.Enabled = true;
            }
            else // Disable for non-upwell
            {
                txtFacilityManualME.Enabled = false;
                txtFacilityManualTE.Enabled = false;
                txtFacilityManualTax.Enabled = false;
                txtFacilityManualCost.Enabled = false;
            }

            // Set the values
            UpdatingManualBoxes = true;
            txtFacilityManualME.Text = MMText;
            txtFacilityManualTE.Text = TMText;
            txtFacilityManualTax.Text = TaxText;
            txtFacilityManualCost.Text = CostText;
            UpdatingManualBoxes = false;

            // Show the boxes
            SetFacilityBonusBoxes(true, Activity);

            // Make sure the usage check is now enabled and update the box if a value exists
            if (FacilityType != FacilityTypes.None)
            {
                chkFacilityIncludeUsage.Enabled = true;
                chkFacilityIncludeCost.Enabled = true;
                chkFacilityIncludeTime.Enabled = true;
                lblFacilityUsage.Text = Strings.FormatNumber(SelectedFacility.FacilityUsage, 2);
            }

            if (FacilityType == FacilityTypes.UpwellStructure)
            {
                // Enable fitting
                btnFacilityFitting.Enabled = true;
                btnFacilityFitting.Visible = true;
            }
            else
            {
                btnFacilityFitting.Enabled = false;
                btnFacilityFitting.Visible = false;
            }

            // Enable the FW settings 
            SetFWUpgradeControls(SelectedFacility.SolarSystemName);

            if (SelectedLocation == ProgramLocation.BlueprintTab)
            {
                CostIndexUpdateText();
            }

            // Update the refining rates for refinery facilities
            if (SelectedProductionType == ProductionType.Reprocessing)
            {
                if (!Public_Variables.FirstLoad)
                {
                    switch (SelectedLocation)
                    {
                        case ProgramLocation.MiningTab:
                            {
                                ((frmMain)SelectedControlForm).RefreshMiningTabRefiningRates();
                                break;
                            }
                        case ProgramLocation.ReprocessingPlant:
                            {
                                ((frmReprocessingPlant)SelectedControlForm).RefreshRefiningRates();
                                break;
                            }
                            // Case ProgramLocation.SovBelts
                            // Call CType(SelectedControlForm, frmIndustryBeltFlip).LoadAllTables()
                            // Case ProgramLocation.IceBelts
                            // Call CType(SelectedControlForm, frmIceBeltFlip).RefreshGrids()
                    }
                }
            }

            // Loaded up, let them save it
            btnFacilitySave.Visible = true;
            PreviousEquipment = cmbFacility.Text;
            // Fully loaded
            SelectedFacility.FullyLoaded = true;

            // Facility is loaded, so save it to default and dynamic variable
            SetFacility(SelectedFacility, BuildType, false, false);

            Application.DoEvents();

        }

        // Sets the sent facility To the one we are selecting And sets the Default 
        private void SetFacility(IndustryFacility SentFacility, ProductionType BuildType, bool CompareIncludeCostCheck, bool CompareIncludeTimeCheck)
        {

            // For checking change from stations on tab
            var PreviousFacility = new IndustryFacility();

            switch (BuildType)
            {
                case ProductionType.Manufacturing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedManufacturingFacility.Clone();
                        SelectedManufacturingFacility = (IndustryFacility)SentFacility.Clone();
                        if (SelectedManufacturingFacility.IsEqual(DefaultManufacturingFacility))
                        {
                            SelectedManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.BoosterManufacturing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedBoosterManufacturingFacility.Clone();
                        SelectedBoosterManufacturingFacility = SentFacility;
                        if (SelectedBoosterManufacturingFacility.IsEqual(DefaultBoosterManufacturingFacility))
                        {
                            SelectedBoosterManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedBoosterManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.CapitalManufacturing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedCapitalManufacturingFacility.Clone();
                        SelectedCapitalManufacturingFacility = SentFacility;
                        if (SelectedCapitalManufacturingFacility.IsEqual(DefaultCapitalManufacturingFacility))
                        {
                            SelectedCapitalManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedCapitalManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.SuperManufacturing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedSuperManufacturingFacility.Clone();
                        SelectedSuperManufacturingFacility = SentFacility;
                        if (SelectedSuperManufacturingFacility.IsEqual(DefaultSuperManufacturingFacility))
                        {
                            SelectedSuperManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedSuperManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.T3CruiserManufacturing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedT3CruiserManufacturingFacility.Clone();
                        SelectedT3CruiserManufacturingFacility = SentFacility;
                        if (SelectedT3CruiserManufacturingFacility.IsEqual(DefaultT3CruiserManufacturingFacility))
                        {
                            SelectedT3CruiserManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedT3CruiserManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.T3DestroyerManufacturing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedT3DestroyerManufacturingFacility.Clone();
                        SelectedT3DestroyerManufacturingFacility = SentFacility;
                        if (SelectedT3DestroyerManufacturingFacility.IsEqual(DefaultT3DestroyerManufacturingFacility))
                        {
                            SelectedT3DestroyerManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedT3DestroyerManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.SubsystemManufacturing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedSubsystemManufacturingFacility.Clone();
                        SelectedSubsystemManufacturingFacility = SentFacility;
                        if (SelectedSubsystemManufacturingFacility.IsEqual(DefaultSubsystemManufacturingFacility))
                        {
                            SelectedSubsystemManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedSubsystemManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.ComponentManufacturing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedComponentManufacturingFacility.Clone();
                        SelectedComponentManufacturingFacility = SentFacility;
                        if (SelectedComponentManufacturingFacility.IsEqual(DefaultComponentManufacturingFacility))
                        {
                            SelectedComponentManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedComponentManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.CapitalComponentManufacturing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedCapitalComponentManufacturingFacility.Clone();
                        SelectedCapitalComponentManufacturingFacility = SentFacility;
                        if (SelectedCapitalComponentManufacturingFacility.IsEqual(DefaultCapitalComponentManufacturingFacility))
                        {
                            SelectedCapitalComponentManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedCapitalComponentManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.Invention:
                    {
                        PreviousFacility = (IndustryFacility)SelectedInventionFacility.Clone();
                        SelectedInventionFacility = SentFacility;
                        if (SelectedInventionFacility.IsEqual(DefaultInventionFacility, CompareIncludeCostCheck, CompareIncludeTimeCheck))
                        {
                            SelectedInventionFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedInventionFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.T3Invention:
                    {
                        PreviousFacility = (IndustryFacility)SelectedT3InventionFacility.Clone();
                        SelectedT3InventionFacility = SentFacility;
                        if (SelectedT3InventionFacility.IsEqual(DefaultT3InventionFacility, CompareIncludeCostCheck, CompareIncludeTimeCheck))
                        {
                            SelectedT3InventionFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedT3InventionFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.Copying:
                    {
                        PreviousFacility = (IndustryFacility)SelectedCopyFacility.Clone();
                        SelectedCopyFacility = SentFacility;
                        if (SelectedCopyFacility.IsEqual(DefaultCopyFacility, CompareIncludeCostCheck, CompareIncludeTimeCheck))
                        {
                            SelectedCopyFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedCopyFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.Reactions:
                    {
                        PreviousFacility = (IndustryFacility)SelectedReactionsFacility.Clone();
                        SelectedReactionsFacility = SentFacility;
                        if (SelectedReactionsFacility.IsEqual(DefaultReactionsFacility))
                        {
                            SelectedReactionsFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedReactionsFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
                case ProductionType.Reprocessing:
                    {
                        PreviousFacility = (IndustryFacility)SelectedReprocessingFacility.Clone();
                        SelectedReprocessingFacility = SentFacility;
                        if (SelectedReprocessingFacility.IsEqual(DefaultRefiningFacility))
                        {
                            SelectedReprocessingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedReprocessingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }

                default:
                    {
                        PreviousFacility = (IndustryFacility)SelectedManufacturingFacility.Clone();
                        SelectedManufacturingFacility = SentFacility;
                        if (SelectedManufacturingFacility.IsEqual(DefaultManufacturingFacility))
                        {
                            SelectedManufacturingFacility.IsDefault = true;
                            SentFacility.IsDefault = true;
                        }
                        else
                        {
                            SelectedManufacturingFacility.IsDefault = false;
                            SentFacility.IsDefault = false;
                        }

                        break;
                    }
            }

            // Set the default 
            SetDefaultVisuals(SentFacility.IsDefault);

            // Save the selected facility locally
            SelectedFacility = (IndustryFacility)SentFacility.Clone();

        }

        private void chkFacilityIncludeUsage_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChangingUsageChecks)
            {

                SelectedFacility.IncludeActivityUsage = chkFacilityIncludeUsage.Checked;

                // Facility is loaded, so save it to default and dynamic variable
                SetFacility(SelectedFacility, SelectedProductionType, false, false);

                // See if we update the price labels on the BP tab
                RefreshMainBP();

                lblFacilityUsage.Text = Strings.FormatNumber(GetSelectedFacility().FacilityUsage, 2);

            }

            SetResetRefresh();

        }

        private void chkFacilityIncludeCost_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChangingUsageChecks)
            {
                if (chkFacilityIncludeCost.Checked == true & SelectedFacility.IncludeActivityCost == false | chkFacilityIncludeCost.Checked == false & SelectedFacility.IncludeActivityCost == true)
                {
                    // Different than what was set, so set default visuals to false
                    SetDefaultVisuals(false);
                    SelectedFacility.IncludeActivityCost = chkFacilityIncludeCost.Checked;
                    // Now set the facility
                    SetFacility(SelectedFacility, SelectedFacility.FacilityProductionType, true, true);
                }
                else
                {
                    // Same as what was set so set to true
                    SetDefaultVisuals(true);
                }
            }

            SetResetRefresh();

        }

        private void chkFacilityIncludeTime_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChangingUsageChecks)
            {
                if (chkFacilityIncludeTime.Checked == true & SelectedFacility.IncludeActivityTime == false | chkFacilityIncludeTime.Checked == false & SelectedFacility.IncludeActivityTime == true)
                {
                    // Different than what was set, so set default visuals to false
                    SetDefaultVisuals(false);
                    SelectedFacility.IncludeActivityTime = chkFacilityIncludeTime.Checked;
                    // Now set the facility
                    SetFacility(SelectedFacility, SelectedFacility.FacilityProductionType, true, true);
                }
                else
                {
                    // Same as what was set so set to true
                    SetDefaultVisuals(true);
                }
            }

            SetResetRefresh();

        }

        private void btnFacilityFitting_Click(object sender, EventArgs e)
        {
            var StructureViewer = new frmUpwellStructureFitting(cmbFacility.Text, SelectedCharacterID, SelectedProductionType, SelectedLocation, SelectedFacility.SolarSystemName);
            StructureViewer.ShowDialog();

            // After showing, select the name of the citadel chosen and then dispose
            cmbFacility.Text = StructureViewer.UpwellStructureName;

            StructureViewer.Dispose();

            // If we updated the facility, save it first before loading as it may not have been saved yet
            if (StructureViewer.SavedFacility)
            {
                // Reset any manual settings
                SelectedFacility.ResetManualToggles();
                // Save it here too but don't show the dialog
                SaveSelectedFacility(true);
            }

            // Reload the facility each time we return - use initialize and just load the one we changed
            if (SelectedFacility.IsDefault)
            {
                // If they saved fittings for the default, reset the default values
                InitializeFacilities(SelectedLocation, SelectedProductionType, true);
            }
            else
            {
                // If it's not the default, just load the facility so we get the changes from the fitting
                LoadFacility(SelectedBPID, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech);
            }

            if (StructureViewer.ResetManualEntries)
            {
                {
                    ref var withBlock = ref SelectedFacility;
                    withBlock.ManualCost = false;
                    withBlock.ManualME = false;
                    withBlock.ManualTax = false;
                    withBlock.ManualTE = false;
                }
            }

            SetResetRefresh();

        }

        private void btnFacilitySave_MouseHover(object sender, EventArgs e)
        {
            if (txtFacilityManualTax.Focused)
            {
                btnFacilityFitting.Focus();
            }
        }

        private void btnFacilitySave_MouseLeave(object sender, EventArgs e)
        {
            // MouseOverSave = False
        }

        private void btnFacilitySave_Click(object sender, EventArgs e)
        {
            SaveSelectedFacility(false);
        }

        private void SaveSelectedFacility(bool SupressSaveMessage)
        {
            if (SelectedFacility.FullyLoaded)
            {
                if (SelectedFacility.SaveFacility(SelectedCharacterID, SelectedLocation, SupressSaveMessage))
                {
                    // Just saved, so must be the default
                    SetDefaultVisuals(true);
                }
                else
                {
                    SetDefaultVisuals(false);
                    return;
                }

                // Need to update the local default copy of the facility first
                switch (SelectedFacility.FacilityProductionType)
                {
                    case ProductionType.BoosterManufacturing:
                        {
                            DefaultBoosterManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.CapitalComponentManufacturing:
                        {
                            DefaultCapitalComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.CapitalManufacturing:
                        {
                            DefaultCapitalManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.ComponentManufacturing:
                        {
                            DefaultComponentManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.Copying:
                        {
                            DefaultCopyFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.Invention:
                        {
                            DefaultInventionFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.Manufacturing:
                        {
                            DefaultManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.Reactions:
                        {
                            DefaultReactionsFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.SubsystemManufacturing:
                        {
                            DefaultSubsystemManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.SuperManufacturing:
                        {
                            DefaultSuperManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.T3CruiserManufacturing:
                        {
                            DefaultT3CruiserManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.T3DestroyerManufacturing:
                        {
                            DefaultT3DestroyerManufacturingFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.T3Invention:
                        {
                            DefaultT3InventionFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                    case ProductionType.Reprocessing:
                        {
                            DefaultRefiningFacility = (IndustryFacility)SelectedFacility.Clone();
                            break;
                        }
                }

                // Now set the facility
                SetFacility(SelectedFacility, SelectedFacility.FacilityProductionType, true, true);

            }

            // Update the blueprint if we can after a save
            UpdateBlueprint();

        }

        // Load the facility for the check - either components or cap components OR T3 destroyers or T3 cruisers (only need to do this with limited controls)
        private void chkFacilityToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (!Public_Variables.FirstLoad)
            {
                switch (SelectedProductionType)
                {
                    case ProductionType.CapitalComponentManufacturing:
                    case ProductionType.ComponentManufacturing:
                        {
                            if (chkFacilityToggle.Checked)
                            {
                                SelectedProductionType = ProductionType.CapitalComponentManufacturing;
                                SelectedBPCategoryID = (int)Public_Variables.ItemIDs.CapitalComponentGroupID;
                                SelectedBPGroupID = (int)Public_Variables.ItemIDs.None;
                                SelectedBPTech = (int)Public_Variables.BPTechLevel.T1;
                                cmbFacilityActivities.Text = ActivityCapComponentManufacturing;
                                LoadFacility(SelectedBPID, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech);
                            }
                            else
                            {
                                SelectedProductionType = ProductionType.ComponentManufacturing;
                                SelectedBPCategoryID = (int)Public_Variables.ItemIDs.ComponentCategoryID;
                                SelectedBPGroupID = (int)Public_Variables.ItemIDs.None;
                                SelectedBPTech = (int)Public_Variables.BPTechLevel.T1;
                                cmbFacilityActivities.Text = ActivityComponentManufacturing;
                                LoadFacility(SelectedBPID, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech);
                            }

                            break;
                        }
                    case ProductionType.T3DestroyerManufacturing:
                    case ProductionType.T3CruiserManufacturing:
                        {
                            if (chkFacilityToggle.Checked)
                            {
                                SelectedBPCategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                                SelectedBPGroupID = (int)Public_Variables.ItemIDs.TacticalDestroyerGroupID;
                                SelectedBPTech = (int)Public_Variables.BPTechLevel.T3;
                                cmbFacilityActivities.Text = ActivityManufacturing;
                                LoadFacility(SelectedBPID, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech);
                            }
                            else
                            {
                                SelectedBPCategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                                SelectedBPGroupID = (int)Public_Variables.ItemIDs.StrategicCruiserGroupID;
                                SelectedBPTech = (int)Public_Variables.BPTechLevel.T3;
                                cmbFacilityActivities.Text = ActivityManufacturing;
                                LoadFacility(SelectedBPID, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech);
                            }

                            break;
                        }
                }
            }
        }

        #region Support Functions

        // Returns references to the GroupID, CategoryID, TechLevel, and Activity Combo Text when sent the production type
        private void GetFacilityBPItemData(ProductionType SentProductionType, ref int GroupID, ref int CategoryID, ref int TechLevel, ref string ActivityComboText)
        {
            switch (SentProductionType)
            {
                case ProductionType.Manufacturing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.FrigateGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T2;
                        ActivityComboText = ActivityManufacturing;
                        break;
                    }
                case ProductionType.CapitalComponentManufacturing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.CapitalComponentGroupID;
                        GroupID = (int)Public_Variables.ItemIDs.None;
                        TechLevel = (int)Public_Variables.BPTechLevel.T1;
                        ActivityComboText = ActivityCapComponentManufacturing;
                        break;
                    }
                case ProductionType.ComponentManufacturing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.ComponentCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.None;
                        TechLevel = (int)Public_Variables.BPTechLevel.T1;
                        ActivityComboText = ActivityComponentManufacturing;
                        break;
                    }
                case ProductionType.CapitalManufacturing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.CarrierGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T1;
                        ActivityComboText = ActivityManufacturing;
                        break;
                    }
                case ProductionType.SuperManufacturing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.SupercarrierGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T1;
                        ActivityComboText = ActivityManufacturing;
                        break;
                    }
                case ProductionType.T3CruiserManufacturing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.StrategicCruiserGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T3;
                        ActivityComboText = ActivityManufacturing;
                        break;
                    }
                case ProductionType.SubsystemManufacturing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.SubsystemCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.None;
                        TechLevel = (int)Public_Variables.BPTechLevel.T3;
                        ActivityComboText = ActivityManufacturing;
                        break;
                    }
                case ProductionType.BoosterManufacturing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.BoosterCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.BoosterGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T1;
                        ActivityComboText = ActivityManufacturing;
                        break;
                    }
                case ProductionType.Copying:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.FrigateGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T2;
                        ActivityComboText = ActivityCopying;
                        break;
                    }
                case ProductionType.Invention:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.FrigateGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T2;
                        ActivityComboText = ActivityInvention;
                        break;
                    }
                case ProductionType.Reactions:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.None;
                        GroupID = (int)Public_Variables.ItemIDs.ReactionPolymersGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T1;
                        ActivityComboText = ActivityReactions;
                        break;
                    }
                case ProductionType.T3Invention:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.TacticalDestroyerGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T3;
                        ActivityComboText = ActivityInvention;
                        break;
                    }
                case ProductionType.T3DestroyerManufacturing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.ShipCategoryID;
                        GroupID = (int)Public_Variables.ItemIDs.TacticalDestroyerGroupID;
                        TechLevel = (int)Public_Variables.BPTechLevel.T3;
                        ActivityComboText = ActivityManufacturing;
                        break;
                    }
                case ProductionType.Reprocessing:
                    {
                        CategoryID = (int)Public_Variables.ItemIDs.AsteroidsCategoryID;
                        GroupID = 0;
                        TechLevel = 0;
                        ActivityComboText = ActivityReprocessing;
                        break;
                    }
            }

        }

        // Selects the facility and returns it and sets the activity on the facility found
        private IndustryFacility SelectFacility(ProductionType BuildType, bool IsDefault)
        {

            string FacilityActivity = "";
            var ReturnFacility = new IndustryFacility();

            if (IsDefault)
            {
                switch (BuildType)
                {
                    case ProductionType.Manufacturing:
                        {
                            ReturnFacility = (IndustryFacility)DefaultManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.SuperManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)DefaultSuperManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.CapitalManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)DefaultCapitalManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.BoosterManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)DefaultBoosterManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.T3CruiserManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)DefaultT3CruiserManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.T3DestroyerManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)DefaultT3DestroyerManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.SubsystemManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)DefaultSubsystemManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.Invention:
                        {
                            ReturnFacility = (IndustryFacility)DefaultInventionFacility.Clone();
                            FacilityActivity = ActivityInvention;
                            break;
                        }
                    case ProductionType.T3Invention:
                        {
                            ReturnFacility = (IndustryFacility)DefaultT3InventionFacility.Clone();
                            FacilityActivity = ActivityInvention;
                            break;
                        }
                    case ProductionType.Copying:
                        {
                            FacilityActivity = ActivityCopying;
                            ReturnFacility = (IndustryFacility)DefaultCopyFacility.Clone();
                            break;
                        }
                    case ProductionType.Reactions:
                        {
                            FacilityActivity = ActivityReactions;
                            ReturnFacility = (IndustryFacility)DefaultReactionsFacility.Clone();
                            break;
                        }
                    case ProductionType.ComponentManufacturing:
                        {
                            FacilityActivity = ActivityComponentManufacturing;
                            ReturnFacility = (IndustryFacility)DefaultComponentManufacturingFacility.Clone();
                            break;
                        }
                    case ProductionType.CapitalComponentManufacturing:
                        {
                            FacilityActivity = ActivityCapComponentManufacturing;
                            ReturnFacility = (IndustryFacility)DefaultCapitalComponentManufacturingFacility.Clone();
                            break;
                        }
                    case ProductionType.Reprocessing:
                        {
                            FacilityActivity = ActivityReprocessing;
                            ReturnFacility = (IndustryFacility)DefaultRefiningFacility.Clone();
                            break;
                        }
                }
            }
            else
            {
                switch (BuildType)
                {
                    case ProductionType.Manufacturing:
                        {
                            ReturnFacility = (IndustryFacility)SelectedManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.SuperManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)SelectedSuperManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.CapitalManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)SelectedCapitalManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.BoosterManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)SelectedBoosterManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.T3CruiserManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)SelectedT3CruiserManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.T3DestroyerManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)SelectedT3DestroyerManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.SubsystemManufacturing:
                        {
                            ReturnFacility = (IndustryFacility)SelectedSubsystemManufacturingFacility.Clone();
                            FacilityActivity = ActivityManufacturing;
                            break;
                        }
                    case ProductionType.Invention:
                        {
                            FacilityActivity = ActivityInvention;
                            ReturnFacility = (IndustryFacility)SelectedInventionFacility.Clone();
                            break;
                        }
                    case ProductionType.T3Invention:
                        {
                            FacilityActivity = ActivityInvention;
                            ReturnFacility = (IndustryFacility)SelectedT3InventionFacility.Clone();
                            break;
                        }
                    case ProductionType.Copying:
                        {
                            FacilityActivity = ActivityCopying;
                            ReturnFacility = (IndustryFacility)SelectedCopyFacility.Clone();
                            break;
                        }
                    case ProductionType.Reactions:
                        {
                            FacilityActivity = ActivityReactions;
                            ReturnFacility = (IndustryFacility)SelectedReactionsFacility.Clone();
                            break;
                        }
                    case ProductionType.ComponentManufacturing:
                        {
                            FacilityActivity = ActivityComponentManufacturing;
                            ReturnFacility = (IndustryFacility)SelectedComponentManufacturingFacility.Clone();
                            break;
                        }
                    case ProductionType.CapitalComponentManufacturing:
                        {
                            FacilityActivity = ActivityCapComponentManufacturing;
                            ReturnFacility = (IndustryFacility)SelectedCapitalComponentManufacturingFacility.Clone();
                            break;
                        }
                    case ProductionType.Reprocessing:
                        {
                            FacilityActivity = ActivityReprocessing;
                            ReturnFacility = (IndustryFacility)SelectedReprocessingFacility.Clone();
                            break;
                        }
                }
            }

            // Set the activity text here
            ReturnFacility.Activity = FacilityActivity;

            return ReturnFacility;

        }

        // Sets all the combos to unenabled and base text to show no facility for stuff like Invention, Copy and RE where they might buy the item
        private void SetNoFacility()
        {
            cmbFacilityRegion.Items.Clear();
            cmbFacilityRegion.Text = "Select Region";
            cmbFacilityRegion.Enabled = false;
            cmbFacilitySystem.Items.Clear();
            cmbFacilitySystem.Text = InitialSolarSystemComboText;
            cmbFacilitySystem.Enabled = false;
            cmbFacility.Items.Clear();
            cmbFacility.Text = InitialFacilityComboText;
            chkFacilityIncludeUsage.Enabled = false;

            if (!(chkFacilityIncludeCost == null))
            {
                chkFacilityIncludeCost.Enabled = false;
            }
            if (!(chkFacilityIncludeTime == null))
            {
                chkFacilityIncludeTime.Enabled = false;
            }
            cmbFacility.Enabled = false;
            if (!(chkFacilityToggle == null))
            {
                chkFacilityToggle.Enabled = false;
            }
        }

        // Sets the visual data for default facility
        private void SetDefaultVisuals(bool isDefault)
        {
            if (isDefault == true)
            {
                lblFacilityDefault.ForeColor = FacilityLabelDefaultColor;
                lblFacilityDefault.Visible = true;
                ResetToolTipforDefaultFacilityLabel(false);
                btnFacilitySave.Enabled = false; // don't enable since it's already the default, it's pointless to save it
            }
            else
            {
                lblFacilityDefault.ForeColor = FacilityLabelNonDefaultColor;
                lblFacilityDefault.Visible = true;
                ResetToolTipforDefaultFacilityLabel(true);
                if (SelectedFacility.FullyLoaded)
                {
                    btnFacilitySave.Enabled = true;
                }
            }
        }

        // Translates the string facility type into the enum code
        private FacilityTypes GetFacilityTypeCode(string FacilityType)
        {
            SQLiteDataReader rsLookup;
            var ReturnType = FacilityTypes.None;

            Public_Variables.DBCommand = new SQLiteCommand("SELECT FACILITY_TYPE_ID FROM FACILITY_TYPES WHERE FACILITY_TYPE_NAME = '" + FacilityType + "'", Public_Variables.EVEDB.DBREf());
            rsLookup = Public_Variables.DBCommand.ExecuteReader();
            if (rsLookup.Read())
            {
                ReturnType = (FacilityTypes)rsLookup.GetInt32(0);
            }

            rsLookup.Close();

            return ReturnType;

        }

        // Translates facility code into name
        private string GetFacilityNamefromCode(FacilityTypes FacilityType)
        {
            SQLiteDataReader rsLookup;
            string ReturnName = "";

            Public_Variables.DBCommand = new SQLiteCommand("SELECT FACILITY_TYPE_NAME FROM FACILITY_TYPES WHERE FACILITY_TYPE_ID = " + (int)FacilityType, Public_Variables.EVEDB.DBREf());
            rsLookup = Public_Variables.DBCommand.ExecuteReader();
            if (rsLookup.Read())
            {
                ReturnName = rsLookup.GetString(0);
            }

            rsLookup.Close();

            return ReturnName;

        }

        // Hides all the facility bonus boxes and such
        private void SetFacilityBonusBoxes(bool Value, string Activity = "")
        {

            if ((Activity ?? "") == ActivityReprocessing)
            {
                // Only two boxes shown for refining
                txtFacilityManualME.Visible = Value;
                if (SelectedLocation == ProgramLocation.BlueprintTab)
                {
                    txtFacilityManualTE.Visible = Value;
                }
                else
                {
                    txtFacilityManualTE.Visible = false;
                }
                txtFacilityManualTax.Visible = Value;
                txtFacilityManualCost.Visible = false;

                lblFacilityManualME.Visible = Value;
                lblFacilityManualTE.Visible = Value;
                lblFacilityManualTax.Visible = Value;
                lblFacilityManualCost.Visible = false;
            }
            else
            {
                txtFacilityManualME.Visible = Value;
                txtFacilityManualTE.Visible = Value;
                txtFacilityManualTax.Visible = Value;
                txtFacilityManualCost.Visible = Value;

                lblFacilityManualME.Visible = Value;
                lblFacilityManualTE.Visible = Value;
                lblFacilityManualTax.Visible = Value;
                lblFacilityManualCost.Visible = Value;
            }

            // only set these false when this is called, it will load if needed elsewhere
            lblFacilityFWUpgrade.Visible = false;
            cmbFacilityFWUpgrade.Visible = false;

            // Clear the usage until these are set
            if (!(lblFacilityUsage == null))
            {
                lblFacilityUsage.Text = "";
            }

        }

        // Resets all combo boxes toggles that might need to be updated 
        private void ResetComboLoadVariables(bool RegionsValue, bool SystemsValue, bool FacilitiesValue)
        {

            FacilityRegionsLoaded = RegionsValue;
            FacilitySystemsLoaded = SystemsValue;
            FacilityLoaded = FacilitiesValue;

        }

        // Sets the tool tip text for default facility labels if they can double click to reload
        private void ResetToolTipforDefaultFacilityLabel(bool ShowTip)
        {
            if (!(mainToolTip == null))
            {
                if (ShowTip & SettingsVariables.UserApplicationSettings.ShowToolTips)
                {
                    mainToolTip.SetToolTip(lblFacilityDefault, "Double-Click to reload default facility");
                }
                else
                {
                    mainToolTip.SetToolTip(lblFacilityDefault, "");
                }
            }
        }

        // Returns the type of production done for the activity and bp data sent
        public ProductionType GetProductionType(int BPGroupID, int BPCategoryID, string SelectedActivity)
        {
            var SelectedIndyType = default(ProductionType);

            FacilityTypes FacilityType;
            string BaseActivity;

            // Select the facility type from the combo or default
            if ((cmbFacilityType.Text ?? "") == InitialTypeComboText)
            {
                FacilityType = FacilityTypes.Station;
            }
            else
            {
                FacilityType = GetFacilityTypeCode(cmbFacilityType.Text);
            }

            // Select the activity type from combo or default
            if ((SelectedActivity ?? "") == InitialActivityComboText)
            {
                // Use the manufacturing activity for these
                BaseActivity = ActivityManufacturing;
            }
            else
            {
                BaseActivity = SelectedActivity;
            }

            switch (BaseActivity ?? "")
            {
                // TODO look into making these a lookup with the facility type if there are category or groupid's in the tables for them. 
                case ActivityManufacturing:
                    {
                        // Need to load selected manufacturing facility
                        switch (BPGroupID)
                        {
                            case (int)Public_Variables.ItemIDs.SupercarrierGroupID:
                            case (int)Public_Variables.ItemIDs.TitanGroupID:
                                {
                                    SelectedIndyType = ProductionType.SuperManufacturing;
                                    break;
                                }
                            case (int)Public_Variables.ItemIDs.BoosterGroupID:
                                {
                                    SelectedIndyType = ProductionType.BoosterManufacturing;
                                    break;
                                }
                            case (int)Public_Variables.ItemIDs.CarrierGroupID:
                            case (int)Public_Variables.ItemIDs.DreadnoughtGroupID:
                            case (int)Public_Variables.ItemIDs.CapitalIndustrialShipGroupID:
                            case (int)Public_Variables.ItemIDs.FAXGroupID:
                                {
                                    SelectedIndyType = ProductionType.CapitalManufacturing;
                                    break;
                                }
                            case (int)Public_Variables.ItemIDs.StrategicCruiserGroupID:
                                {
                                    SelectedIndyType = ProductionType.T3CruiserManufacturing;
                                    break;
                                }
                            case (int)Public_Variables.ItemIDs.TacticalDestroyerGroupID:
                                {
                                    SelectedIndyType = ProductionType.T3DestroyerManufacturing;
                                    break;
                                }
                            case (int)Public_Variables.ItemIDs.ProtectiveComponentGroupID:
                                {
                                    SelectedIndyType = ProductionType.ComponentManufacturing;
                                    break;
                                }

                            default:
                                {
                                    SelectedIndyType = ProductionType.Manufacturing;

                                    if (BPCategoryID == (int)Public_Variables.ItemIDs.SubsystemCategoryID)
                                    {
                                        SelectedIndyType = ProductionType.SubsystemManufacturing;
                                    }
                                    else if (BPCategoryID == (int)Public_Variables.ItemIDs.ComponentCategoryID)
                                    {
                                        // Add category for component
                                        if (BPGroupID == (int)Public_Variables.ItemIDs.CapitalComponentGroupID | BPGroupID == (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID)
                                        {
                                            SelectedIndyType = ProductionType.CapitalComponentManufacturing; // These all use cap components
                                        }
                                        else
                                        {
                                            SelectedIndyType = ProductionType.ComponentManufacturing;
                                        }
                                    }

                                    break;
                                }
                        }

                        break;
                    }
                case ActivityComponentManufacturing:
                    {
                        SelectedIndyType = ProductionType.ComponentManufacturing;
                        break;
                    }
                case ActivityCapComponentManufacturing:
                    {
                        SelectedIndyType = ProductionType.CapitalComponentManufacturing;
                        break;
                    }
                case ActivityCopying:
                    {
                        SelectedIndyType = ProductionType.Copying;
                        break;
                    }
                case ActivityInvention:
                    {
                        if (BPCategoryID == (int)Public_Variables.ItemIDs.SubsystemCategoryID | BPGroupID == (int)Public_Variables.ItemIDs.StrategicCruiserGroupID | BPGroupID == (int)Public_Variables.ItemIDs.TacticalDestroyerGroupID)
                        {
                            // Need to invent this at a station
                            SelectedIndyType = ProductionType.T3Invention;
                        }
                        else
                        {
                            SelectedIndyType = ProductionType.Invention;
                        }

                        break;
                    }
                case ActivityReactions:
                    {
                        SelectedIndyType = ProductionType.Reactions;
                        break;
                    }
                case ActivityReprocessing:
                    {
                        SelectedIndyType = ProductionType.Reprocessing;
                        break;
                    }
            }

            return SelectedIndyType;

        }

        // Loads up all the usage for all facilities on this bp into a form
        private void lblFacilityUsage_DoubleClick(object sender, EventArgs e)
        {
            var f1 = new frmUsageViewer();
            UsageSplit RawCostSplit;

            // Fill up the array to display only if on the bp tab
            if (!(Public_Variables.SelectedBlueprint == null) & SelectedLocation == ProgramLocation.BlueprintTab)
            {

                // Manufacturing Facility usage
                RawCostSplit.UsageName = "Manufacturing Facility Usage";
                if (!Public_Variables.ReactionTypes.Contains(Public_Variables.SelectedBlueprint.GetItemData().GroupName))
                {
                    RawCostSplit.UsageValue = GetSelectedManufacturingFacility(Public_Variables.SelectedBlueprint.GetItemGroupID(), Public_Variables.SelectedBlueprint.GetItemCategoryID()).FacilityUsage;
                }
                else
                {
                    // Add fuel block usage
                    RawCostSplit.UsageValue = SelectedManufacturingFacility.FacilityUsage;
                }
                f1.UsageSplits.Add(RawCostSplit);

                if (Public_Variables.SelectedBlueprint.HasComponents() & Public_Variables.SelectedBlueprint.GetItemCategoryID() != (int)Public_Variables.ItemIDs.ComponentCategoryID & Public_Variables.SelectedBlueprint.GetItemGroupID() != (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID & !Public_Variables.ReactionTypes.Contains(Public_Variables.SelectedBlueprint.GetItemData().GroupName))
                {
                    // Component Facility Usage
                    RawCostSplit.UsageName = "Component Facility Usage";
                    RawCostSplit.UsageValue = SelectedComponentManufacturingFacility.FacilityUsage;
                    f1.UsageSplits.Add(RawCostSplit);

                    // Capital Component Facility Usage
                    switch (Public_Variables.SelectedBlueprint.GetItemGroupID())
                    {
                        case (int)Public_Variables.ItemIDs.TitanGroupID:
                        case (int)Public_Variables.ItemIDs.SupercarrierGroupID:
                        case (int)Public_Variables.ItemIDs.CarrierGroupID:
                        case (int)Public_Variables.ItemIDs.DreadnoughtGroupID:
                        case (int)Public_Variables.ItemIDs.JumpFreighterGroupID:
                        case (int)Public_Variables.ItemIDs.FreighterGroupID:
                        case (int)Public_Variables.ItemIDs.IndustrialCommandShipGroupID:
                        case (int)Public_Variables.ItemIDs.CapitalIndustrialShipGroupID:
                        case (int)Public_Variables.ItemIDs.FAXGroupID:
                            {
                                // Only add cap component usage for ships that use them
                                RawCostSplit.UsageName = "Capital Component Facility Usage";
                                RawCostSplit.UsageValue = SelectedCapitalComponentManufacturingFacility.FacilityUsage;
                                f1.UsageSplits.Add(RawCostSplit);
                                break;
                            }
                    }
                }
                else if (Public_Variables.SelectedBlueprint.GetItemCategoryID() == (int)Public_Variables.ItemIDs.ComponentCategoryID | Public_Variables.SelectedBlueprint.GetItemGroupID() == (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID | Public_Variables.ReactionTypes.Contains(Public_Variables.SelectedBlueprint.GetItemData().GroupName))
                {
                    // Load reactions usage
                    RawCostSplit.UsageName = "Reaction Facility Usage";
                    RawCostSplit.UsageValue = SelectedReactionsFacility.FacilityUsage;
                    f1.UsageSplits.Add(RawCostSplit);
                }

                if (Public_Variables.SelectedBlueprint.GetTechLevel() != (int)Public_Variables.BPTechLevel.T1)
                {
                    // Invention Facility
                    RawCostSplit.UsageName = "Invention Usage";
                    RawCostSplit.UsageValue = SelectedInventionFacility.FacilityUsage;
                    f1.UsageSplits.Add(RawCostSplit);
                }

                if (Public_Variables.SelectedBlueprint.GetTechLevel() == (int)Public_Variables.BPTechLevel.T2)
                {
                    // Copy Facility
                    RawCostSplit.UsageName = "Copy Usage";
                    RawCostSplit.UsageValue = SelectedCopyFacility.FacilityUsage;
                    f1.UsageSplits.Add(RawCostSplit);
                }

                // Reprocessing usage
                if (SelectedReprocessingFacility.ConvertToOre)
                {
                    RawCostSplit.UsageName = "Reprocessing Usage";
                    RawCostSplit.UsageValue = SelectedReprocessingFacility.FacilityUsage;
                    f1.UsageSplits.Add(RawCostSplit);
                }

                f1.Show();
            }
        }

        // Updates the cost index text box on the bp tab
        private void CostIndexUpdateText()
        {

            if (SelectedLocation == ProgramLocation.BlueprintTab & !Public_Variables.FirstLoad)
            {
                string System = "";
                int Start = 0;
                string IndexValue = "0";

                try
                {
                    System = cmbFacilitySystem.Text;
                    Start = Strings.InStr(System, "(");
                    if (System.Contains("("))
                    {
                        IndexValue = System.Substring(Start, Strings.InStr(System, ")") - (Start + 1));

                        if (!Information.IsNumeric(IndexValue))
                        {
                            // Write the values to error log for now
                            Public_Variables.WriteMsgToLog("CostIndexUpdateText Error: System = " + System + ", Start = " + Start.ToString() + " Index Value = " + IndexValue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Public_Variables.WriteMsgToLog("CostIndexUpdateText Error: System = " + System + ", Start = " + Start.ToString() + " Index Value = " + IndexValue + " Facility System Text:" + cmbFacilitySystem.Text + " Error Message:" + ex.Message);
                }

                My.MyProject.Forms.frmMain.txtBPUpdateCostIndex.Text = Strings.FormatPercent(IndexValue, 2);

            }

        }

        // Updates the blueprint on the bp tab if it's that facility
        private void UpdateBlueprint()
        {
            // Load the bp on bp tab
            if (!(Public_Variables.SelectedBlueprint == null) & SelectedLocation == ProgramLocation.BlueprintTab)
            {
                {
                    ref var withBlock = ref Public_Variables.SelectedBlueprint;
                    My.MyProject.Forms.frmMain.UpdateBPGrids(withBlock.GetTypeID(), withBlock.GetTechLevel(), false, withBlock.GetItemGroupID(), withBlock.GetItemCategoryID(), Public_Variables.SentFromLocation.BlueprintTab);
                }
            }
        }

        private void SetResetRefresh()
        {
            if (SelectedLocation == ProgramLocation.ManufacturingTab & !Public_Variables.FirstLoad)
            {
                My.MyProject.Forms.frmMain.ResetRefresh();
            }
        }

        #endregion

        #region Faction Warfare Functions

        private int GetFWUpgradeLevel(string SolarSystemName)
        {

            if (!Public_Variables.FirstLoad & (cmbFacilitySystem.Text ?? "") != InitialSolarSystemComboText)
            {
                int FWUpgradeLevel;

                SQLiteDataReader rsFW;
                long SSID;

                // Format system name
                if (SolarSystemName.Contains("("))
                {
                    SolarSystemName = SolarSystemName.Substring(0, Strings.InStr(SolarSystemName, "(") - 2);
                }

                string SQL = "SELECT factionWarzone, solarSystemID FROM SOLAR_SYSTEMS WHERE solarSystemName = '" + Public_Variables.FormatDBString(SolarSystemName) + "'";
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsFW = Public_Variables.DBCommand.ExecuteReader();

                bool Warzone;
                if (rsFW.Read())
                {
                    Warzone = Conversions.ToBoolean(rsFW.GetInt32(0));
                    SSID = rsFW.GetInt64(1);
                }
                else
                {
                    Warzone = false;
                }

                rsFW.Close();

                if (Warzone)
                {
                    if (!(cmbFacilityFWUpgrade == null))
                    {
                        switch (cmbFacilityFWUpgrade.Text ?? "")
                        {
                            case "Level 1":
                                {
                                    FWUpgradeLevel = 1;
                                    break;
                                }
                            case "Level 2":
                                {
                                    FWUpgradeLevel = 2;
                                    break;
                                }
                            case "Level 3":
                                {
                                    FWUpgradeLevel = 3;
                                    break;
                                }
                            case "Level 4":
                                {
                                    FWUpgradeLevel = 4;
                                    break;
                                }
                            case "Level 5":
                                {
                                    FWUpgradeLevel = 5;
                                    break;
                                }

                            default:
                                {
                                    FWUpgradeLevel = 0;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        FWUpgradeLevel = 0;
                    }
                }
                else
                {
                    FWUpgradeLevel = -1;
                }

                return FWUpgradeLevel;
            }

            return -1;

        }

        // Enables the controls for FW settings on the bp tab
        private void SetFWUpgradeControls(string SolarSystemName)
        {
            // Load the faction warfare upgrade
            SQLiteDataReader rsFW;
            var SSID = default(long);
            bool Warzone = false;

            // Format system name
            if (SolarSystemName.Contains("("))
            {
                SolarSystemName = SolarSystemName.Substring(0, Strings.InStr(SolarSystemName, "(") - 2);
            }

            string SQL = "SELECT factionWarzone, solarSystemID FROM SOLAR_SYSTEMS WHERE solarSystemName = '" + Public_Variables.FormatDBString(SolarSystemName) + "'";
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsFW = Public_Variables.DBCommand.ExecuteReader();

            if (rsFW.Read())
            {
                Warzone = Conversions.ToBoolean(rsFW.GetInt32(0));
                SSID = rsFW.GetInt64(1);
            }
            else
            {
                Warzone = false;
            }

            rsFW.Close();
            UpdatingFWComboText = true;

            if (Warzone & SelectedFacility.FacilityProductionType != ProductionType.Reprocessing)
            {
                lblFacilityFWUpgrade.Enabled = true;
                lblFacilityFWUpgrade.Visible = true;
                cmbFacilityFWUpgrade.Enabled = true;
                cmbFacilityFWUpgrade.Visible = true;
                // look up level
                SQLiteDataReader rsFWLevel;
                SQL = "SELECT UPGRADE_LEVEL FROM FW_SYSTEM_UPGRADES WHERE SOLAR_SYSTEM_ID = " + SSID.ToString();
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsFWLevel = Public_Variables.DBCommand.ExecuteReader();
                rsFWLevel.Read();

                if (rsFWLevel.HasRows)
                {
                    if (rsFWLevel.GetInt32(0) == 0)
                    {
                        cmbFacilityFWUpgrade.Text = Public_Variables.None;
                    }
                    else
                    {
                        cmbFacilityFWUpgrade.Text = "Level " + rsFWLevel.GetInt32(0).ToString();
                    }
                }
                else
                {
                    cmbFacilityFWUpgrade.Text = Public_Variables.None;
                }

                rsFWLevel.Close();
            }
            else
            {
                lblFacilityFWUpgrade.Enabled = false;
                lblFacilityFWUpgrade.Visible = false;
                cmbFacilityFWUpgrade.Enabled = false;
                cmbFacilityFWUpgrade.Visible = false;
                cmbFacilityFWUpgrade.Text = Public_Variables.None;
                SelectedFacility.FWUpgradeLevel = -1;
            }

            UpdatingFWComboText = false;

        }

        private void cmbFWUpgrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Public_Variables.FirstLoad & !UpdatingFWComboText)
            {
                // Set the selected level
                SelectedFacility.FWUpgradeLevel = GetFWUpgradeLevel(cmbFacilitySystem.Text);
                // Facility is loaded, so save it to default and dynamic variable
                SetFacility(SelectedFacility, SelectedProductionType, false, false);
                // Let them save the change
                SetDefaultVisuals(false);
                // If this changed, we need to update the usage
                RefreshMainBP(true);
            }

            SetResetRefresh();

        }

        private void cmbFWUpgrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #endregion

        #region Public Functions

        // Resets the char id of the facility
        public void ResetSelectedCharacterID(long NewCharacterID)
        {
            SelectedCharacterID = NewCharacterID;
        }

        // Loads the facility sent into the type of the facility
        public void UpdateFacility(IndustryFacility UpdatedFacility)
        {

            switch (UpdatedFacility.FacilityProductionType)
            {
                case ProductionType.BoosterManufacturing:
                    {
                        SelectedBoosterManufacturingFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.CapitalComponentManufacturing:
                    {
                        SelectedCapitalComponentManufacturingFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.CapitalManufacturing:
                    {
                        SelectedCapitalManufacturingFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.ComponentManufacturing:
                    {
                        SelectedComponentManufacturingFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.Copying:
                    {
                        SelectedCopyFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.Invention:
                    {
                        SelectedInventionFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.Manufacturing:
                    {
                        SelectedManufacturingFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.Reactions:
                    {
                        SelectedReactionsFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.SubsystemManufacturing:
                    {
                        SelectedSubsystemManufacturingFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.SuperManufacturing:
                    {
                        SelectedSuperManufacturingFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.T3CruiserManufacturing:
                    {
                        SelectedT3CruiserManufacturingFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.T3DestroyerManufacturing:
                    {
                        SelectedT3DestroyerManufacturingFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
                case ProductionType.T3Invention:
                    {
                        SelectedT3InventionFacility = (IndustryFacility)UpdatedFacility.Clone();
                        break;
                    }
            }

        }

        // Returns the facilty for the production type sent
        public IndustryFacility GetFacility(ProductionType BuildType)
        {

            // Select based on input type. If not fully loaded, then load the default and also load the default facility in the facility controls
            switch (BuildType)
            {
                case ProductionType.BoosterManufacturing:
                    {
                        if (SelectedBoosterManufacturingFacility.FullyLoaded)
                        {
                            return SelectedBoosterManufacturingFacility;
                        }
                        else
                        {
                            return DefaultBoosterManufacturingFacility;
                        }
                    }
                case ProductionType.CapitalComponentManufacturing:
                    {
                        if (SelectedCapitalComponentManufacturingFacility.FullyLoaded)
                        {
                            return SelectedCapitalComponentManufacturingFacility;
                        }
                        else
                        {
                            return DefaultCapitalComponentManufacturingFacility;
                        }
                    }
                case ProductionType.CapitalManufacturing:
                    {
                        if (SelectedCapitalManufacturingFacility.FullyLoaded)
                        {
                            return SelectedCapitalManufacturingFacility;
                        }
                        else
                        {
                            return DefaultCapitalManufacturingFacility;
                        }
                    }
                case ProductionType.ComponentManufacturing:
                    {
                        if (SelectedComponentManufacturingFacility.FullyLoaded)
                        {
                            return SelectedComponentManufacturingFacility;
                        }
                        else
                        {
                            return DefaultComponentManufacturingFacility;
                        }
                    }
                case ProductionType.Copying:
                    {
                        if (SelectedCopyFacility.FullyLoaded)
                        {
                            return SelectedCopyFacility;
                        }
                        else
                        {
                            return DefaultCopyFacility;
                        }
                    }
                case ProductionType.Invention:
                    {
                        if (SelectedInventionFacility.FullyLoaded)
                        {
                            return SelectedInventionFacility;
                        }
                        else
                        {
                            return DefaultInventionFacility;
                        }
                    }
                case ProductionType.Manufacturing:
                    {
                        if (SelectedManufacturingFacility.FullyLoaded)
                        {
                            return SelectedManufacturingFacility;
                        }
                        else
                        {
                            return DefaultManufacturingFacility;
                        }
                    }
                case ProductionType.Reactions:
                    {
                        if (SelectedReactionsFacility.FullyLoaded)
                        {
                            return SelectedReactionsFacility;
                        }
                        else
                        {
                            return DefaultReactionsFacility;
                        }
                    }
                case ProductionType.SubsystemManufacturing:
                    {
                        if (SelectedSubsystemManufacturingFacility.FullyLoaded)
                        {
                            return SelectedSubsystemManufacturingFacility;
                        }
                        else
                        {
                            return DefaultSubsystemManufacturingFacility;
                        }
                    }
                case ProductionType.SuperManufacturing:
                    {
                        if (SelectedSuperManufacturingFacility.FullyLoaded)
                        {
                            return SelectedSuperManufacturingFacility;
                        }
                        else
                        {
                            return DefaultSuperManufacturingFacility;
                        }
                    }
                case ProductionType.T3CruiserManufacturing:
                    {
                        if (SelectedT3CruiserManufacturingFacility.FullyLoaded)
                        {
                            return SelectedT3CruiserManufacturingFacility;
                        }
                        else
                        {
                            return DefaultT3CruiserManufacturingFacility;
                        }
                    }
                case ProductionType.T3DestroyerManufacturing:
                    {
                        if (SelectedT3DestroyerManufacturingFacility.FullyLoaded)
                        {
                            return SelectedT3DestroyerManufacturingFacility;
                        }
                        else
                        {
                            return DefaultT3DestroyerManufacturingFacility;
                        }
                    }
                case ProductionType.T3Invention:
                    {
                        if (SelectedT3InventionFacility.FullyLoaded)
                        {
                            return SelectedT3InventionFacility;
                        }
                        else
                        {
                            return DefaultT3InventionFacility;
                        }
                    }
                case ProductionType.Reprocessing:
                    {
                        if (SelectedReprocessingFacility.FullyLoaded)
                        {
                            return SelectedReprocessingFacility;
                        }
                        else
                        {
                            return DefaultRefiningFacility;
                        }
                    }

                default:
                    {
                        return null;
                    }
            }

            return null;

        }

        // Gets the facility for manufacturing based on the bp data on initialization or sent bp data
        public IndustryFacility GetSelectedManufacturingFacility(int BPGroupID, int BPCategoryID, string OverrideActivity = "")
        {
            int TempGroupID;
            int TempCategoryID;
            string SelectedActivity;

            // If either one of the numbers are 0, then use the init data
            if (BPGroupID == 0 | BPCategoryID == 0)
            {
                TempGroupID = SelectedBPGroupID;
                TempCategoryID = SelectedBPCategoryID;
            }
            else
            {
                TempGroupID = BPGroupID;
                TempCategoryID = BPCategoryID;
            }

            if (!string.IsNullOrEmpty(OverrideActivity))
            {
                SelectedActivity = OverrideActivity;
            }
            else
            {
                // default setting, if the bp is a reaction, then return the reaction facility not manufacturing
                SelectedActivity = ActivityManufacturing;

                // Look up the groups for reactions
                if ((SelectedActivity ?? "") == ActivityManufacturing)
                {
                    SQLiteDataReader rsCheck;
                    Public_Variables.DBCommand = new SQLiteCommand("SELECT DISTINCT ITEM_GROUP_ID FROM ALL_BLUEPRINTS WHERE BLUEPRINT_ID IN (SELECT typeID FROM INVENTORY_TYPES WHERE typeName LIKE '%Reaction Formula%')", Public_Variables.EVEDB.DBREf());
                    rsCheck = Public_Variables.DBCommand.ExecuteReader();

                    while (rsCheck.Read())
                    {
                        if (rsCheck.GetInt32(0) == BPGroupID)
                        {
                            SelectedActivity = ActivityReactions;
                        }
                    }
                    rsCheck.Close();
                }
            }

            // Determine the production type and then pull the correct facility for manufacturing only based on the category and group id not the activity selected
            var PT = GetProductionType(TempGroupID, TempCategoryID, SelectedActivity);

            return GetFacility(PT);

        }

        // Gets the facility for invention based on the bp data on initialization or sent bp data
        public IndustryFacility GetSelectedInventionFacility(int BPGroupID = 0, int BPCategoryID = 0)
        {
            int TempGroupID;
            int TempCategoryID;

            // If either one of the numbers are 0, then use the init data
            if (BPGroupID == 0 | BPCategoryID == 0)
            {
                TempGroupID = SelectedBPGroupID;
                TempCategoryID = SelectedBPCategoryID;
            }
            else
            {
                TempGroupID = BPGroupID;
                TempCategoryID = BPCategoryID;
            }

            // Determine the production type and then pull the correct facility for manufacturing only based on the category and group id not the activity selected
            var PT = GetProductionType(TempGroupID, TempCategoryID, ActivityInvention);

            return GetFacility(PT);

        }

        // Just return the current facility selected
        public IndustryFacility GetSelectedFacility()
        {
            return SelectedFacility;
        }

        public void UpdateRefineYieldLabel(double NewValue)
        {
            if (SelectedProductionType == ProductionType.Reprocessing)
            {
                txtFacilityManualME.Text = Strings.FormatPercent(NewValue, 2);
            }
        }

        // Returns if the facility is fully loaded or not
        public bool FullyLoaded()
        {
            return SelectedFacility.FullyLoaded;
        }

        // Returns the current selected facility production type
        public ProductionType GetCurrentFacilityProductionType()
        {
            return SelectedFacility.FacilityProductionType;
        }

        // Updates the usage value   
        public void UpdateUsage(string ToolTipText)
        {
            lblFacilityUsage.Text = Strings.FormatNumber(SelectedFacility.FacilityUsage);
            mainToolTip.SetToolTip(lblFacilityUsage, ToolTipText);
        }

        // Sets all the refine rates for the three different types of refinables for the selected facility
        private void SetRefiningRates(ref IndustryFacility ReprocessingFacility)
        {
            if (ReprocessingFacility.FacilityProductionType == ProductionType.Reprocessing)
            {
                double DefaultRefineRate = ReprocessingFacility.MaterialMultiplier;
                ReprocessingFacility.OreFacilityRefineRate = GetRefineRate(RefineMaterialType.Ore, DefaultRefineRate);
                ReprocessingFacility.MoonOreFacilityRefineRate = GetRefineRate(RefineMaterialType.MoonOre, DefaultRefineRate);
                ReprocessingFacility.IceFacilityRefineRate = GetRefineRate(RefineMaterialType.Ice, DefaultRefineRate);
                ReprocessingFacility.ScrapmetalRefineRate = GetRefineRate(RefineMaterialType.Scrapmetal, DefaultRefineRate);
            }
        }

        // Looks up any modules installed on the selected facility and returns the refining rate
        private double GetRefineRate(RefineMaterialType RefineType, double DefaultValue)
        {
            double RefineValue = DefaultValue;

            // Process all but scrapmetal to account for rigs/etc.
            if (SelectedProductionType == ProductionType.Reprocessing & SelectedFacility.FacilityType == FacilityTypes.UpwellStructure)
            {
                if (RefineType != RefineMaterialType.Scrapmetal)
                {
                    var ItemGroupID = default(int);
                    int ItemCategoryID = 25;

                    switch (RefineType)
                    {
                        case RefineMaterialType.Ore:
                            {
                                ItemGroupID = (int)Public_Variables.ItemIDs.Arkonor;
                                break;
                            }
                        case RefineMaterialType.Ice:
                            {
                                ItemGroupID = (int)Public_Variables.ItemIDs.IceGroupID;
                                break;
                            }
                        case RefineMaterialType.MoonOre:
                            {
                                ItemGroupID = (int)Public_Variables.ItemIDs.CommonMoonAsteroids;
                                break;
                            }
                    }

                    {
                        ref var withBlock = ref SelectedFacility;
                        double BonusValue = withBlock.GetFacilityBonusMulitiplier(IndustryFacility.ModifierType.ReprocessingRate, withBlock.ActivityID, ItemGroupID, ItemCategoryID);
                        if (BonusValue > 0d)
                        {
                            RefineValue = BonusValue * 100d * (withBlock.MaterialMultiplier / Public_Variables.BaseRefineRate);
                        }
                    }
                }
                else
                {
                    // Scrapmetal is pretty basic - just return the base ME as 50% for all structures and we will adjust outside of object for scrapmetal
                    RefineValue = Public_Variables.BaseRefineRate;
                }
            }

            return RefineValue;

        }

        public void SetIgnoreInvention(bool Ignore, ProductionType InventionType, bool UsageCheckValue)
        {

            if (Ignore)
            {
                // Remove copy and invention activities
                cmbFacilityActivities.Items.Remove(ActivityInvention);
                cmbFacilityActivities.Items.Remove(ActivityCopying);
            }
            else
            {
                // Add the copy and invention activities
                if (!cmbFacilityActivities.Items.Contains(ActivityInvention))
                {
                    cmbFacilityActivities.Items.Add(ActivityInvention);
                }
                if (!cmbFacilityActivities.Items.Contains(ActivityCopying))
                {
                    cmbFacilityActivities.Items.Add(ActivityCopying);
                }
            }

            // Set the usage
            ChangingUsageChecks = true;
            chkFacilityIncludeUsage.Checked = UsageCheckValue;
            ChangingUsageChecks = false;

        }

        private void txtFacilityManualME_KeyPress(object sender, KeyPressEventArgs e)
        {
            SelectedFacility.ManualME = true;
            SetResetRefresh();
            e.Handled = ProcessKeyPressInput(e);
        }

        private void txtFacilityManualME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetManualTextBoxValue(BoxType._ME);
                UpdateBlueprint();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnFacilitySave.Enabled = true;
            }
        }

        private void txtFacilityManualME_GotFocus(object sender, EventArgs e)
        {
            txtFacilityManualCost.SelectAll();
        }

        private void txtFacilityManualME_LostFocus(object sender, EventArgs e)
        {
            if (SelectedFacility.ManualME)
            {
                SetManualTextBoxValue(BoxType._ME);
                UpdateBlueprint();
            }
        }

        private void txtFacilityManualTE_KeyPress(object sender, KeyPressEventArgs e)
        {
            SelectedFacility.ManualTE = true;
            SetResetRefresh();
            e.Handled = ProcessKeyPressInput(e);
        }

        private void txtFacilityManualTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetManualTextBoxValue(BoxType._TE);
                UpdateBlueprint();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnFacilitySave.Enabled = true;
            }
        }

        private void txtFacilityManualTE_GotFocus(object sender, EventArgs e)
        {
            txtFacilityManualTE.SelectAll();
        }

        private void txtFacilityManualTE_LostFocus(object sender, EventArgs e)
        {
            if (SelectedFacility.ManualTE)
            {
                SetManualTextBoxValue(BoxType._TE);
                UpdateBlueprint();
            }
        }

        private void txtFacilityManualCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            SelectedFacility.ManualCost = true;
            e.Handled = ProcessKeyPressInput(e);
        }

        private void txtFacilityManualCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetManualTextBoxValue(BoxType._Cost);
                UpdateBlueprint();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnFacilitySave.Enabled = true;
            }
        }

        private void txtFacilityManualCost_GotFocus(object sender, EventArgs e)
        {
            txtFacilityManualCost.SelectAll();
        }

        private void txtFacilityManualCost_LostFocus(object sender, EventArgs e)
        {
            if (SelectedFacility.ManualCost)
            {
                SetManualTextBoxValue(BoxType._Cost);
                UpdateBlueprint();
            }
        }

        private void txtFacilityManualTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            SelectedFacility.ManualTax = true;
            SetResetRefresh();
            e.Handled = ProcessKeyPressInput(e);
        }

        private void txtFacilityManualTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetManualTextBoxValue(BoxType._Tax);
                UpdateBlueprint();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnFacilitySave.Enabled = true;
            }
        }

        private void txtFacilityManualTax_GotFocus(object sender, EventArgs e)
        {
            txtFacilityManualTax.SelectAll();
        }

        private void txtFacilityManualTax_LostFocus(object sender, EventArgs e)
        {
            if (SelectedFacility.ManualTax)
            {
                SetManualTextBoxValue(BoxType._Tax);
                UpdateBlueprint();
            }
        }

        private double FormatManualEntry(string Entry)
        {
            string EntryText;

            if (Entry.Contains("%"))
            {
                // Strip the percent first
                EntryText = Entry.Substring(0, Strings.Len(Entry) - 1);
            }
            else
            {
                EntryText = Entry;
            }

            if (Information.IsNumeric(EntryText))
            {
                return Conversions.ToDouble(EntryText) / 100d;
            }
            else
            {
                return 0d;
            }

        }

        private void SetManualTextBoxValue(BoxType Box)
        {

            if (!Public_Variables.FirstLoad & !(SelectedFacility == null) & !UpdatingManualBoxes)
            {
                // Format for text box
                UpdatingManualBoxes = true;
                btnFacilitySave.Enabled = true;

                switch (Box)
                {
                    case BoxType._ME:
                        {
                            if (SelectedFacility.FacilityProductionType == ProductionType.Reprocessing & SelectedLocation == ProgramLocation.BlueprintTab)
                            {
                                // For reprocessing, just set it to what they put in as it's the rate they refine
                                // This is the ore rate but for others, save it as the base refine rate
                                SelectedFacility.OreFacilityRefineRate = FormatManualEntry(txtFacilityManualME.Text);
                                GetFacility(SelectedFacility.FacilityProductionType).OreFacilityRefineRate = SelectedFacility.OreFacilityRefineRate;
                                txtFacilityManualME.Text = Strings.FormatPercent(SelectedFacility.OreFacilityRefineRate, 2);
                            }
                            else
                            {
                                SelectedFacility.MaterialMultiplier = 1d - FormatManualEntry(txtFacilityManualME.Text);
                                GetFacility(SelectedFacility.FacilityProductionType).MaterialMultiplier = SelectedFacility.MaterialMultiplier;
                                txtFacilityManualME.Text = Strings.FormatPercent(1d - SelectedFacility.MaterialMultiplier, 2);
                                GetFacility(SelectedFacility.FacilityProductionType).ManualME = true;
                            }

                            break;
                        }
                    case BoxType._TE:
                        {
                            if (SelectedFacility.FacilityProductionType == ProductionType.Reprocessing & SelectedLocation == ProgramLocation.BlueprintTab)
                            {
                                // For reprocessing, just set it to what they put in as it's the rate they refine
                                // This is the ice rate
                                SelectedFacility.IceFacilityRefineRate = FormatManualEntry(txtFacilityManualTE.Text);
                                GetFacility(SelectedFacility.FacilityProductionType).TimeMultiplier = SelectedFacility.IceFacilityRefineRate;
                                txtFacilityManualTE.Text = Strings.FormatPercent(SelectedFacility.IceFacilityRefineRate, 2);
                            }
                            else
                            {
                                SelectedFacility.TimeMultiplier = 1d - FormatManualEntry(txtFacilityManualTE.Text);
                                GetFacility(SelectedFacility.FacilityProductionType).TimeMultiplier = SelectedFacility.TimeMultiplier;
                                txtFacilityManualTE.Text = Strings.FormatPercent(1d - SelectedFacility.TimeMultiplier, 2);
                                GetFacility(SelectedFacility.FacilityProductionType).ManualTE = true;
                            }

                            break;
                        }
                    case BoxType._Cost:
                        {
                            SelectedFacility.CostMultiplier = 1d - FormatManualEntry(txtFacilityManualCost.Text);
                            GetFacility(SelectedFacility.FacilityProductionType).CostMultiplier = SelectedFacility.CostMultiplier;
                            txtFacilityManualCost.Text = Strings.FormatPercent(1d - SelectedFacility.CostMultiplier, 2);
                            GetFacility(SelectedFacility.FacilityProductionType).ManualCost = true;
                            break;
                        }
                    case BoxType._Tax:
                        {
                            SelectedFacility.TaxRate = FormatManualEntry(txtFacilityManualTax.Text);
                            GetFacility(SelectedFacility.FacilityProductionType).TaxRate = SelectedFacility.TaxRate;
                            txtFacilityManualTax.Text = Strings.FormatPercent(SelectedFacility.TaxRate, 2);
                            GetFacility(SelectedFacility.FacilityProductionType).ManualTax = true;
                            break;
                        }
                }

                // No longer a default
                SetDefaultVisuals(false);

                UpdatingManualBoxes = false;

            }

        }

        private enum BoxType
        {
            _ME = 0,
            _TE = 1,
            _Cost = 2,
            _Tax = 3
        }

        private bool ProcessKeyPressInput(KeyPressEventArgs e)
        {
            bool EnableButton = true;
            bool ReturnValue = false;

            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedNegativePercentChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    ReturnValue = true;
                    EnableButton = false;
                }
            }

            // If we set this to true, then we changed input and it's not default anymore
            SetDefaultVisuals(!EnableButton);

            SetResetRefresh();

            return ReturnValue;

        }

        private void POSCombos_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetResetRefresh();

        }

        private void RefreshMainBP(bool UpdateUsageLabel = false)
        {
            // See if we update the price labels on the BP tab
            if (!(Public_Variables.SelectedBlueprint == null) & SelectedLocation == ProgramLocation.BlueprintTab)
            {
                My.MyProject.Forms.frmMain.RefreshBP();
                if (UpdateUsageLabel)
                {
                    UpdateUsage("");
                }
            }
        }

        private void btnConversiontoOreSettings_Click(object sender, EventArgs e)
        {
            if (Public_Variables.frmConversionOptions == null)
            {
                // Make new form
                Public_Variables.frmConversionOptions = new frmConversiontoOreSettings();
            }

            if (Public_Variables.frmConversionOptions.IsDisposed)
            {
                // Make new form
                Public_Variables.frmConversionOptions = new frmConversiontoOreSettings();
            }

            // Save where this form is from
            Public_Variables.frmConversionOptions.SelectedLocation = SelectedLocation;

            // Now open the form
            Public_Variables.frmConversionOptions.Show();
            Public_Variables.frmConversionOptions.Focus();

            Application.DoEvents();

        }

        private void chkFacilityConvertToOre_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChangingUsageChecks)
            {
                SelectedFacility.ConvertToOre = chkFacilityConvertToOre.Checked;
                // Facility is loaded, so save it to default and dynamic variable
                SetFacility(SelectedFacility, SelectedProductionType, false, false);
                RefreshMainBP();
                // Update usage after completed building the bp
                lblFacilityUsage.Text = Strings.FormatNumber(GetSelectedFacility().FacilityUsage, 2);
            }
        }

        #endregion

    }

    public enum ProgramLocation
    {
        None = -1,
        BlueprintTab = 0,
        ManufacturingTab = 1,
        MiningTab = 2,
        ReprocessingPlant = 3,
        SovBelts = 4,
        IceBelts = 5
    }

    // Types of actual activities that you can conduct in a facility
    public enum IndustryActivities
    {
        None = 0,
        Manufacturing = 1,
        ResearchingTechnology = 2,
        ResearchingTimeLevel = 3,
        ResearchingMaterialLevel = 4,
        Copying = 5,
        Duplicating = 6,
        Invention = 8,
        Reactions = 11,
        MoonDrilling = -1,
        Reprocessing = -2
    }

    // These are the different types of industry fuction we will distinguish between facilities since they all have special restrictions
    public enum ProductionType
    {
        None = 0,
        Manufacturing = 1,
        ComponentManufacturing = 2,
        CapitalComponentManufacturing = 3,
        CapitalManufacturing = 4,
        SuperManufacturing = 5,
        T3CruiserManufacturing = 6,
        SubsystemManufacturing = 7,
        BoosterManufacturing = 8,
        Copying = 9,
        Invention = 10,
        Reactions = 11,
        T3Invention = 12,
        T3DestroyerManufacturing = 13,

        // New types
        Reprocessing = 17

    }

    public enum RefineMaterialType
    {
        Ore = 1,
        Ice = 2,
        MoonOre = 3,
        Scrapmetal = 4
    }

    public enum FacilityTypes
    {
        None = -1,
        Station = 0,
        UpwellStructure = 3
    }

    // Industry facility class, move to private use if possible
    public class IndustryFacility : ICloneable
    {

        // For industry Facilities
        public long FacilityID; // ID Of the facility
        public string FacilityName; // Station/Outpost Name or the Array name
        public FacilityTypes FacilityType; // Station, Upwell Structure
        public ProductionType FacilityProductionType; // What we are doing at this facility
        public int ActivityID; // Activity code of the facility
        public string Activity; // String value of the activity
        public string RegionName; // Region of this facility
        public long RegionID;
        public string SolarSystemName; // System where this is located
        public long SolarSystemID;
        public double SolarSystemSecurity;
        public int FWUpgradeLevel; // Level of the FW upgrade for this system (if applies)
        public double CostIndex; // Cost index for the system and activity from ESI
        public double ActivityCostPerSecond; // The cost to conduct the activity for this facility per second - my setting for ECs
        public bool IsDefault;
        public bool IncludeActivityCost; // This is the total cost of materials to do the activiy
        public bool IncludeActivityTime; // This is the time for doing the activity
        public bool IncludeActivityUsage; // This is the cost of using the facility only

        public double FacilityUsage; // The usage charged by this facility, set after bp has run
        public string UsageToolTipText; // The text to display for the usage label

        // Nullable fields
        public double TaxRate; // The tax rate
        public double MaterialMultiplier; // The bonus material percentage or refining rate for materials used in this facility
        public double TimeMultiplier; // The bonus to time to conduct an activity in this facility
        public double CostMultiplier; // The bonus to cost to conduct an activity in this facility
        public bool ManualME; // To check for manual entries if different
        public bool ManualTE; // To check for manual entries if different
        public bool ManualCost; // To check for manual entries if different
        public bool ManualTax; // To check for manual entries if different
        public double BaseTax; // Base tax rate from default
        public double BaseME; // The ME bonus from default
        public double BaseTE; // The TE bonus from default
        public double BaseCost; // The Cost bonus from default

        public bool FullyLoaded; // This facility was fully loaded in all parts
        private ProgramLocation ControlLocation; // Where in the program is this facility
        public bool ConvertToOre; // if convert to ore option is selected

        // For all the fitting data
        private List<FittingBonusInfo> FittingBonuses;

        // Default multiplier rates if we can't find them
        public const double DefaultTaxRate = 0d;
        public const double DefaultMaterialMultiplier = 1d;
        public const double DefaultTimeMultiplier = 1d;
        public const double DefaultCostMultiplier = 1d;

        // Refine rates for the facility
        public double OreFacilityRefineRate;
        public double MoonOreFacilityRefineRate;
        public double IceFacilityRefineRate;
        public double ScrapmetalRefineRate;

        private List<int> ThukkerRigIDs;

        private struct FittingBonusInfo
        {
            public int RigID;
            public int AttributeID;
            public object CategoryID;
            public object GroupID;
            public int ActivityID;
            public double Bonus;
        }

        private struct Attributebonus
        {
            public int AttributeID;
            public double Bonus;
        }

        public enum ModifierType
        {
            MaterialModifier = 0,
            TimeModifier = 1,
            CostModifier = 2,
            ReprocessingRate = 3
        }

        private FittingBonusInfo BonusDataToFind;

        public IndustryFacility()
        {

            FacilityID = 0L;
            FacilityName = Public_Variables.None;
            FacilityType = FacilityTypes.None;
            FacilityProductionType = ProductionType.None;
            ActivityID = 0;
            Activity = "";
            RegionName = Public_Variables.None;
            RegionID = 0L;
            SolarSystemName = Public_Variables.None;
            SolarSystemID = 0L;
            SolarSystemSecurity = 0d;
            FWUpgradeLevel = -1;
            CostIndex = 0d;
            ActivityCostPerSecond = 0d;
            IsDefault = false;
            IncludeActivityCost = false;
            IncludeActivityTime = false;
            IncludeActivityUsage = false;

            TaxRate = 0d;
            MaterialMultiplier = 0d;
            TimeMultiplier = 0d;
            CostMultiplier = 0d;
            ManualTax = false;
            ManualME = false;
            ManualTE = false;
            ManualCost = false;
            BaseME = 0d;
            BaseTE = 0d;
            BaseCost = 0d;
            BaseTax = 0d;

            OreFacilityRefineRate = 0d;
            MoonOreFacilityRefineRate = 0d;
            IceFacilityRefineRate = 0d;
            ScrapmetalRefineRate = 0d;

            ControlLocation = default;
            ConvertToOre = false;
            FullyLoaded = false;

            ThukkerRigIDs = new List<int>();
            FittingBonuses = new List<FittingBonusInfo>();

        }

        // For doing a deep copy of Materials
        public object Clone()
        {
            var CopyOfMe = new IndustryFacility();

            CopyOfMe.FacilityID = FacilityID;
            CopyOfMe.FacilityName = FacilityName;
            CopyOfMe.FacilityType = FacilityType;
            CopyOfMe.FacilityProductionType = FacilityProductionType;
            CopyOfMe.ActivityID = ActivityID;
            CopyOfMe.Activity = Activity;
            CopyOfMe.RegionName = RegionName;
            CopyOfMe.RegionID = RegionID;
            CopyOfMe.SolarSystemName = SolarSystemName;
            CopyOfMe.SolarSystemID = SolarSystemID;
            CopyOfMe.SolarSystemSecurity = SolarSystemSecurity;
            CopyOfMe.FWUpgradeLevel = FWUpgradeLevel;
            CopyOfMe.CostIndex = CostIndex;
            CopyOfMe.ActivityCostPerSecond = ActivityCostPerSecond;
            CopyOfMe.IsDefault = IsDefault;
            CopyOfMe.IncludeActivityCost = IncludeActivityCost;
            CopyOfMe.IncludeActivityTime = IncludeActivityTime;
            CopyOfMe.IncludeActivityUsage = IncludeActivityUsage;
            CopyOfMe.FacilityUsage = FacilityUsage;
            CopyOfMe.UsageToolTipText = UsageToolTipText;
            CopyOfMe.TaxRate = TaxRate;
            CopyOfMe.MaterialMultiplier = MaterialMultiplier;
            CopyOfMe.TimeMultiplier = TimeMultiplier;
            CopyOfMe.CostMultiplier = CostMultiplier;
            CopyOfMe.ManualME = ManualME;
            CopyOfMe.ManualTE = ManualTE;
            CopyOfMe.ManualCost = ManualCost;
            CopyOfMe.ManualTax = ManualTax;
            CopyOfMe.BaseME = BaseME;
            CopyOfMe.BaseTE = BaseTE;
            CopyOfMe.BaseCost = BaseCost;
            CopyOfMe.BaseTax = BaseTax;
            CopyOfMe.OreFacilityRefineRate = OreFacilityRefineRate;
            CopyOfMe.MoonOreFacilityRefineRate = MoonOreFacilityRefineRate;
            CopyOfMe.IceFacilityRefineRate = IceFacilityRefineRate;
            CopyOfMe.ScrapmetalRefineRate = ScrapmetalRefineRate;
            CopyOfMe.FullyLoaded = FullyLoaded;
            CopyOfMe.ControlLocation = ControlLocation;
            CopyOfMe.ConvertToOre = ConvertToOre;
            CopyOfMe.FittingBonuses = FittingBonuses;
            CopyOfMe.ThukkerRigIDs = ThukkerRigIDs;

            return CopyOfMe;

        }

        // Load up the facility data from the table as default
        public void InitalizeFacility(ProductionType InitialProductionType, ProgramLocation FacilityLocation)
        {
            string SQL = "";
            SQLiteDataReader rsLoader;

            // Load these for later use
            ThukkerRigIDs = new List<int>();

            Public_Variables.DBCommand = new SQLiteCommand("SELECT typeID FROM INVENTORY_TYPES WHERE typeName LIKE 'Standup %Thukker%' AND groupID <> 1708", Public_Variables.EVEDB.DBREf());
            rsLoader = Public_Variables.DBCommand.ExecuteReader();

            while (rsLoader.Read())
                ThukkerRigIDs.Add(rsLoader.GetInt32(0));

            rsLoader.Close();

            // Save the reference to the program location
            ControlLocation = FacilityLocation;

            // Look up all the data in two queries - first base data and try to get the multipliers and cost data - it should only be there for saved outposts (which are being removed)
            SQL = "SELECT SF.FACILITY_ID, SF.FACILITY_TYPE, ";
            SQL += "FACILITY_PRODUCTION_TYPES.ACTIVITY_ID, INDUSTRY_ACTIVITIES.activityName, ";
            SQL += "REGIONS.regionName, REGIONS.regionID, SOLAR_SYSTEMS.solarSystemName, SOLAR_SYSTEMS.solarSystemID, ";
            SQL += "CASE WHEN UPGRADE_LEVEL IS NULL THEN 0 ELSE UPGRADE_LEVEL END AS FW_UPGRADE_LEVEL, SF.ACTIVITY_COST_PER_SECOND, ";
            SQL += "CASE WHEN COST_INDEX IS NULL THEN 0 ELSE COST_INDEX END AS COST_INDEX,";
            SQL += "SF.INCLUDE_ACTIVITY_COST, SF.INCLUDE_ACTIVITY_TIME, SF.INCLUDE_ACTIVITY_USAGE, ";
            SQL += "SF.FACILITY_TAX, SF.MATERIAL_MULTIPLIER, SF.TIME_MULTIPLIER, SF.COST_MULTIPLIER, security, CONVERT_TO_ORE ";
            SQL += "FROM SAVED_FACILITIES AS SF, FACILITY_PRODUCTION_TYPES, REGIONS, SOLAR_SYSTEMS, FACILITY_TYPES, INDUSTRY_ACTIVITIES ";
            SQL += "LEFT JOIN FW_SYSTEM_UPGRADES ON FW_SYSTEM_UPGRADES.SOLAR_SYSTEM_ID = SF.SOLAR_SYSTEM_ID ";
            SQL += "LEFT JOIN INDUSTRY_SYSTEMS_COST_INDICIES ";
            SQL += "ON INDUSTRY_SYSTEMS_COST_INDICIES.SOLAR_SYSTEM_ID = SF.SOLAR_SYSTEM_ID ";
            SQL += "AND INDUSTRY_SYSTEMS_COST_INDICIES.ACTIVITY_ID = FACILITY_PRODUCTION_TYPES.ACTIVITY_ID ";
            SQL += "WHERE SF.PRODUCTION_TYPE = FACILITY_PRODUCTION_TYPES.PRODUCTION_TYPE ";
            SQL += "AND SF.REGION_ID = REGIONS.regionID ";
            SQL += "AND SF.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID ";
            SQL += "AND SF.FACILITY_TYPE = FACILITY_TYPES.FACILITY_TYPE_ID ";
            SQL += "AND FACILITY_PRODUCTION_TYPES.ACTIVITY_ID = INDUSTRY_ACTIVITIES.activityID ";
            SQL += string.Format("AND SF.PRODUCTION_TYPE = {0} AND SF.FACILITY_VIEW = {1} ", ((int)InitialProductionType).ToString(), ((int)FacilityLocation).ToString());

            string SQLCharID = "AND CHARACTER_ID = {0}";
            string CharID = "";

            // See what type of character ID
            if (SettingsVariables.UserApplicationSettings.SaveFacilitiesbyChar)
            {
                CharID = Public_Variables.SelectedCharacter.ID.ToString();
            }
            else
            {
                CharID = Public_Variables.CommonSavedFacilitiesID.ToString();
            }

            // First look up the character to see if it's saved there first (initially only do one set of facilities then allow by character via a setting)
            Public_Variables.DBCommand = new SQLiteCommand(SQL + string.Format(SQLCharID, CharID), Public_Variables.EVEDB.DBREf());
            rsLoader = Public_Variables.DBCommand.ExecuteReader();
            rsLoader.Read();

            if (!rsLoader.HasRows)
            {
                // Need to look up the default
                rsLoader.Close();
                Public_Variables.DBCommand = new SQLiteCommand(SQL + string.Format(SQLCharID, "0"), Public_Variables.EVEDB.DBREf());
                rsLoader = Public_Variables.DBCommand.ExecuteReader();
                rsLoader.Read();
            }

            // Should have data one way or another now
            if (rsLoader.HasRows)
            {
                {
                    ref var withBlock = ref rsLoader;
                    FacilityID = withBlock.GetInt32(0);
                    FacilityType = (FacilityTypes)withBlock.GetInt32(1); // Station, Upwell Structure, etc.
                    FacilityProductionType = InitialProductionType;
                    ActivityID = withBlock.GetInt32(2);
                    Activity = withBlock.GetString(3);
                    RegionName = withBlock.GetString(4);
                    RegionID = withBlock.GetInt64(5);
                    // Paste the cost index to the solar system name
                    CostIndex = withBlock.GetFloat(10);
                    if (InitialProductionType != ProductionType.Reprocessing)
                    {
                        SolarSystemName = withBlock.GetString(6) + " (" + Strings.FormatNumber(CostIndex, 4) + ")";
                    }
                    else
                    {
                        SolarSystemName = withBlock.GetString(6);
                    }
                    SolarSystemID = withBlock.GetInt64(7);
                    SolarSystemSecurity = withBlock.GetDouble(18);
                    FWUpgradeLevel = withBlock.GetInt32(8);
                    ActivityCostPerSecond = withBlock.GetFloat(9);
                    ConvertToOre = Conversions.ToBoolean(withBlock.GetInt32(19));

                    IncludeActivityCost = Conversions.ToBoolean(withBlock.GetInt32(11));
                    IncludeActivityTime = Conversions.ToBoolean(withBlock.GetInt32(12));
                    IncludeActivityUsage = Conversions.ToBoolean(withBlock.GetInt32(13));

                    // Refresh the rigs installed for this facility and information to apply the bonuses
                    UpdateProductionFittingInformation(Conversions.ToLong(CharID));

                    // Save these values for later lookup - use -1 for null indicator - these are what they saved manually - can't save a value for a station
                    if (withBlock.GetValue(14) is DBNull | FacilityType == FacilityTypes.Station)
                    {
                        TaxRate = -1;
                    }
                    else
                    {
                        TaxRate = withBlock.GetDouble(14);
                    }

                    if (withBlock.GetValue(15) is DBNull | FacilityType == FacilityTypes.Station)
                    {
                        MaterialMultiplier = -1;
                    }
                    else
                    {
                        MaterialMultiplier = withBlock.GetDouble(15);
                    }

                    if (withBlock.GetValue(16) is DBNull | FacilityType == FacilityTypes.Station)
                    {
                        TimeMultiplier = -1;
                    }
                    else
                    {
                        TimeMultiplier = withBlock.GetDouble(16);
                    }

                    if (withBlock.GetValue(17) is DBNull | FacilityType == FacilityTypes.Station)
                    {
                        CostMultiplier = -1;
                    }
                    else
                    {
                        CostMultiplier = withBlock.GetDouble(17);
                    }

                    // Now, depending on type, look up the name, cost index, tax, and multipliers from the stations table (this is mainly for speed)
                    if (FacilityType == FacilityTypes.Station) // Stations
                    {
                        if (InitialProductionType == ProductionType.Reprocessing)
                        {
                            SQL = "SELECT STATION_NAME, REPROCESSING_TAX_RATE, REPROCESSING_EFFICIENCY, 0, 0 ";
                        }
                        else
                        {
                            SQL = "SELECT STATION_NAME," + SettingsVariables.UserApplicationSettings.StationTaxRate.ToString() + ", 1, 1, 1 ";
                        }
                        SQL += "FROM STATIONS WHERE STATION_ID = " + FacilityID.ToString() + " ";
                    }
                    else if (FacilityType == FacilityTypes.UpwellStructure)
                    {
                        SQL = "SELECT DISTINCT UPWELL_STRUCTURE_NAME, " + SettingsVariables.UserApplicationSettings.StructureTaxRate.ToString() + " AS FACILITY_TAX, ";
                        SQL += "CASE WHEN ACTIVITY_ID = -2 THEN " + Public_Variables.BaseRefineRate.ToString() + " * (1 + MATERIAL_MULTIPLIER) ELSE MATERIAL_MULTIPLIER END, TIME_MULTIPLIER, COST_MULTIPLIER ";
                        SQL += "FROM UPWELL_STRUCTURES WHERE UPWELL_STRUCTURE_TYPE_ID = " + FacilityID.ToString() + " ";
                        SQL += "AND ACTIVITY_ID = " + ActivityID.ToString() + " ";
                    }

                    rsLoader.Close();
                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsLoader = Public_Variables.DBCommand.ExecuteReader();
                    rsLoader.Read();

                    if (rsLoader.HasRows)
                    {
                        FacilityName = rsLoader.GetString(0); // Need to deal with the case of all on calc base facility

                        if (rsLoader.GetValue(2) is DBNull & MaterialMultiplier == -1)
                        {
                            MaterialMultiplier = DefaultMaterialMultiplier;
                        }
                        else if (MaterialMultiplier == -1)
                        {
                            MaterialMultiplier = rsLoader.GetDouble(2);
                        }

                        BaseME = rsLoader.GetDouble(2);

                        if (rsLoader.GetValue(3) is DBNull & TimeMultiplier == -1)
                        {
                            TimeMultiplier = DefaultTimeMultiplier;
                        }
                        else if (TimeMultiplier == -1)
                        {
                            TimeMultiplier = rsLoader.GetDouble(3);
                        }

                        BaseTE = rsLoader.GetDouble(3);

                        if (rsLoader.GetValue(4) is DBNull & CostMultiplier == -1)
                        {
                            CostMultiplier = DefaultCostMultiplier;
                        }
                        else if (CostMultiplier == -1)
                        {
                            CostMultiplier = rsLoader.GetDouble(4);
                        }

                        BaseCost = rsLoader.GetDouble(4);

                        // For the remaining values, if they saved a value manually, then use that, else use what was queried and if null, use the default
                        if (rsLoader.GetValue(1) is DBNull & TaxRate == -1)
                        {
                            // Nothing in DB and they didn't save anything, so use the default rate
                            TaxRate = DefaultTaxRate;
                        }
                        else if (TaxRate == -1)
                        {
                            // Nothing from saved facilties, so use what is in SDE unless it's 
                            if (InitialProductionType == ProductionType.Reprocessing & FacilityType == FacilityTypes.Station)
                            {
                                // Calculate it for reprocessing in stations - structures are always 0 unless saved otherwise
                                double argEfficiencyRate = (double)default;
                                TaxRate = CalculateStationReprocessingTaxRate(Conversions.ToLong(CharID), FacilityID, ref argEfficiencyRate);
                            }
                            else
                            {
                                TaxRate = rsLoader.GetDouble(1);
                            }
                        }


                        BaseTax = TaxRate;
                    }
                    else
                    {
                        // Something went wrong
                        Interaction.MsgBox("The facility failed To load", Constants.vbCritical, Application.ProductName);
                        goto ExitBlock;
                    }

                    FullyLoaded = true;

                    IsDefault = true; // Always loading default with initialize

                }
            }

            else
            {
                // Something went wrong
                Interaction.MsgBox("The facility failed To load", Constants.vbCritical, Application.ProductName);
                goto ExitBlock;
            }

        ExitBlock:
            try
            {
                rsLoader.Close();
            }
            catch (Exception)
            {

            }
        }

        public double CalculateStationReprocessingTaxRate(long CharacterID, long SentFacilityID, ref double EfficiencyRate)
        {
            double Standing = 0d;
            double CalcTax = 0d;
            double UnadjustedCorpStanding = 0d;

            string SQL = "";
            SQLiteDataReader rsStats;

            SQL = "SELECT REPROCESSING_TAX_RATE, CASE WHEN STANDING IS NULL THEN 0 ELSE STANDING END, REPROCESSING_EFFICIENCY FROM STATIONS ";
            SQL += "LEFT JOIN CHARACTER_STANDINGS ON STATIONS.CORPORATION_ID = CHARACTER_STANDINGS.NPC_TYPE_ID And CHARACTER_STANDINGS.CHARACTER_ID = {0} WHERE STATION_ID = {1}";

            Public_Variables.DBCommand = new SQLiteCommand(string.Format(SQL, CharacterID, SentFacilityID), Public_Variables.EVEDB.DBREf());
            rsStats = Public_Variables.DBCommand.ExecuteReader();
            rsStats.Read();

            UnadjustedCorpStanding = rsStats.GetDouble(1);
            EfficiencyRate = rsStats.GetDouble(2);

            // Refinery Tax rate will be based on standings with station corp
            // Effective Standing = Unadjusted Standing + (10 - Unadjusted Standing) * 4% * Connections Skill Level
            Standing = UnadjustedCorpStanding + (10d - UnadjustedCorpStanding) * (0.04d * Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3359L));
            // Rate = StationBaseTaxRate * (1-(.75 * CorpStanding)/5) - Note: Corp Standing affected by Connections
            CalcTax = rsStats.GetDouble(0) * (1d - 0.75d * Standing / 5d);

            if (CalcTax < 0d)
            {
                CalcTax = 0d;
            }

            rsStats.Close();

            return CalcTax;

        }

        public void ResetManualToggles()
        {
            ManualME = false;
            ManualTE = false;
            ManualCost = false;
        }

        public bool SaveFacility(long CharacterID, ProgramLocation Location, bool SupressNotice)
        {
            string SQL;
            string TempSQL;
            SQLiteDataReader rsCheck;
            bool ManualEntries = false;
            var LocationList = new List<int>();
            var LID = default(int);

            try
            {

                if (SettingsVariables.UserApplicationSettings.ShareSavedFacilities)
                {
                    // Need to get each location for saving
                    foreach (int currentLID in Enum.GetValues(typeof(ProgramLocation)))
                    {
                        LID = currentLID;
                        LocationList.Add(LID);
                    }
                }
                else
                {
                    // Just use the one sent
                    LocationList.Add((int)Location);
                }

                foreach (var currentLID1 in LocationList)
                {
                    LID = currentLID1;
                    // See if the record exists - only save one set of facilities for now
                    SQL = string.Format("SELECT 'X' FROM SAVED_FACILITIES WHERE PRODUCTION_TYPE = {0} AND FACILITY_VIEW = {1} AND CHARACTER_ID = {2}", (int)FacilityProductionType, LID, CharacterID);
                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsCheck = Public_Variables.DBCommand.ExecuteReader();

                    if (rsCheck.Read())
                    {
                        // Need to update
                        TempSQL = "UPDATE SAVED_FACILITIES ";
                        TempSQL += "SET FACILITY_ID = {0}, ";
                        TempSQL += "FACILITY_TYPE = {1}, ";
                        TempSQL += "REGION_ID = {2}, ";
                        TempSQL += "SOLAR_SYSTEM_ID = {3}, ";
                        TempSQL += "ACTIVITY_COST_PER_SECOND = {4}, ";
                        TempSQL += "INCLUDE_ACTIVITY_COST = {5}, ";
                        TempSQL += "INCLUDE_ACTIVITY_TIME = {6}, ";
                        TempSQL += "INCLUDE_ACTIVITY_USAGE = {7}, ";
                        TempSQL += "CONVERT_TO_ORE = {8},";
                        TempSQL += "FACILITY_TYPE_ID = {11},";

                        if (FacilityType == FacilityTypes.UpwellStructure)
                        {
                            // if what they have now is different from what they started with, then they made a change
                            // for upwell structures, the base is updated when they make changes to the facility fitting
                            // If ManualTax Then - Tax is always manual so just save what was set earlier. 
                            TempSQL += "FACILITY_TAX = " + TaxRate.ToString() + ", ";
                            ManualEntries = false; // Tax rate won't affect any of the multiplers so don't reset with rigs
                                                   // Else
                                                   // TempSQL &= "FACILITY_TAX = NULL, "
                                                   // End If

                            if (ManualME)
                            {
                                TempSQL += "MATERIAL_MULTIPLIER = " + MaterialMultiplier.ToString() + ", ";
                                ManualEntries = true;
                            }
                            else
                            {
                                TempSQL += "MATERIAL_MULTIPLIER = NULL, ";
                            }

                            if (ManualTE)
                            {
                                TempSQL += "TIME_MULTIPLIER = " + TimeMultiplier.ToString() + ", ";
                                ManualEntries = true;
                            }
                            else
                            {
                                TempSQL += "TIME_MULTIPLIER = NULL, ";
                            }
                            if (ManualCost)
                            {
                                TempSQL += "COST_MULTIPLIER = " + CostMultiplier.ToString() + " ";
                                ManualEntries = true;
                            }
                            else
                            {
                                TempSQL += "COST_MULTIPLIER = NULL ";
                            }
                        }
                        else
                        {
                            TempSQL += "MATERIAL_MULTIPLIER = NULL, ";
                            TempSQL += "TIME_MULTIPLIER = NULL, ";
                            TempSQL += "COST_MULTIPLIER = NULL, ";
                            TempSQL += "FACILITY_TAX = NULL ";
                        }

                        TempSQL += "WHERE PRODUCTION_TYPE = {9} AND CHARACTER_ID = {10} ";
                        TempSQL += "AND FACILITY_VIEW = " + LID.ToString();

                        SQL = string.Format(TempSQL, FacilityID, (int)FacilityType, RegionID, SolarSystemID, ActivityCostPerSecond, Conversions.ToInteger(IncludeActivityCost), Conversions.ToInteger(IncludeActivityTime), Conversions.ToInteger(IncludeActivityUsage), ConvertToOre, (int)FacilityProductionType, CharacterID, ((int)FacilityType).ToString());
                    }

                    else
                    {
                        string MEValue = "NULL";
                        string TEValue = "NULL";
                        string CostValue = "NULL";
                        string TaxValue = "NULL";

                        if (FacilityType == FacilityTypes.UpwellStructure)
                        {
                            // if what they have now is different from what they started with, then they made a change
                            // for upwell structures, the base is updated when they make changes to the facility fitting
                            if (ManualTax)
                            {
                                TaxValue = TaxRate.ToString();
                                ManualEntries = false; // Tax rate won't affect any of the multiplers so don't reset rigs
                            }

                            if (ManualME)
                            {
                                MEValue = MaterialMultiplier.ToString();
                                ManualEntries = true;
                            }

                            if (ManualTE)
                            {
                                TEValue = TimeMultiplier.ToString();
                                ManualEntries = true;
                            }
                            if (ManualCost)
                            {
                                CostValue = CostMultiplier.ToString();
                                ManualEntries = true;
                            }
                        }

                        // Insert
                        SQL = string.Format("INSERT INTO SAVED_FACILITIES VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16});", CharacterID, (int)FacilityProductionType, LID, FacilityID, ((int)FacilityType).ToString(), ((int)FacilityType).ToString(), RegionID, SolarSystemID, ActivityCostPerSecond, Conversions.ToInteger(IncludeActivityCost), Conversions.ToInteger(IncludeActivityTime), Conversions.ToInteger(IncludeActivityUsage), TaxValue, MEValue, TEValue, CostValue, ConvertToOre);

                    }

                    // Save it
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    rsCheck.Close();
                }

                // If they save a structure with manual values, then delete any fittings they may have saved for this structure
                if (FacilityType == FacilityTypes.UpwellStructure)
                {
                    if (ManualEntries)
                    {
                        SQL = "DELETE FROM UPWELL_STRUCTURES_INSTALLED_MODULES WHERE CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND SOLAR_SYSTEM_ID = {2} AND FACILITY_VIEW = {3} AND FACILITY_ID = {4}";
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format(SQL, CharacterID, (int)FacilityProductionType, SolarSystemID, LID, FacilityID));
                    }
                }

                // Update FW upgrade
                if (FWUpgradeLevel != -1)
                {
                    // See if we update or insert
                    SQL = "SELECT * FROM FW_SYSTEM_UPGRADES WHERE SOLAR_SYSTEM_ID = " + SolarSystemID.ToString() + " ";

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsCheck = Public_Variables.DBCommand.ExecuteReader();
                    rsCheck.Read();

                    if (rsCheck.HasRows)
                    {
                        SQL = "UPDATE FW_SYSTEM_UPGRADES SET UPGRADE_LEVEL = " + FWUpgradeLevel.ToString();
                        SQL += " WHERE SOLAR_SYSTEM_ID = " + SolarSystemID;
                    }
                    else
                    {
                        SQL = "INSERT INTO FW_SYSTEM_UPGRADES VALUES (" + SolarSystemID + "," + FWUpgradeLevel.ToString() + ")";
                    }

                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    rsCheck.Close();
                }

                // If this is an upwell, and we are saving multiple structures (shared) then we need to update all the shared structure modules as well
                if (FacilityType == FacilityTypes.UpwellStructure & SettingsVariables.UserApplicationSettings.ShareSavedFacilities)
                {
                    var InstalledModules = new List<int>();
                    // Look up all the installed modules for the location sent
                    SQL = string.Format("SELECT INSTALLED_MODULE_ID FROM UPWELL_STRUCTURES_INSTALLED_MODULES WHERE PRODUCTION_TYPE = {0} AND FACILITY_VIEW = {1} AND CHARACTER_ID = {2} AND FACILITY_ID = {3} AND SOLAR_SYSTEM_ID = {4}", (int)FacilityProductionType, ((int)Location).ToString(), CharacterID, FacilityID, SolarSystemID);
                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsCheck = Public_Variables.DBCommand.ExecuteReader();

                    while (rsCheck.Read())
                        InstalledModules.Add(rsCheck.GetInt32(0));

                    rsCheck.Close();

                    if (InstalledModules.Count > 0)
                    {
                        // Delete all in there first for this location ID
                        Public_Variables.EVEDB.BeginSQLiteTransaction();
                        SQL = "DELETE FROM UPWELL_STRUCTURES_INSTALLED_MODULES WHERE CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND SOLAR_SYSTEM_ID = {2} AND FACILITY_ID = {3}";
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format(SQL, CharacterID, ((int)FacilityProductionType).ToString(), SolarSystemID, FacilityID));

                        // Now insert all the modules installed on this structure for sharing
                        foreach (var ModID in InstalledModules)
                        {
                            foreach (var currentLID2 in LocationList)
                            {
                                LID = currentLID2;
                                SQL = string.Format("INSERT INTO UPWELL_STRUCTURES_INSTALLED_MODULES VALUES({0},{1},{2},{3},{4},{5})", CharacterID, ((int)FacilityProductionType).ToString(), SolarSystemID, LID.ToString(), FacilityID, ModID);
                                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                            }
                        }
                        Public_Variables.EVEDB.CommitSQLiteTransaction();
                    }
                }

                // Refresh the main facilites if sharing facility saves
                if (SettingsVariables.UserApplicationSettings.ShareSavedFacilities)
                {
                    // Refresh the facilities - except the one I just saved it on
                    if (FacilityProductionType == ProductionType.Reprocessing)
                    {
                        if (Location == ProgramLocation.ReprocessingPlant | Location == ProgramLocation.SovBelts | Location == ProgramLocation.IceBelts)
                        {
                            // If any of these checked, need to refresh the bp, mining, and manufacturing tabs - the others will load when opened
                            My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.BlueprintTab, FacilityProductionType);
                            My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.MiningTab, FacilityProductionType);
                            My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.ManufacturingTab, FacilityProductionType);
                        }
                        else if (Location == ProgramLocation.BlueprintTab)
                        {
                            My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.MiningTab, FacilityProductionType);
                            My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.ManufacturingTab, FacilityProductionType);
                        }
                        else if (Location == ProgramLocation.MiningTab)
                        {
                            My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.BlueprintTab, FacilityProductionType);
                            My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.ManufacturingTab, FacilityProductionType);
                        }
                        else if (Location == ProgramLocation.ManufacturingTab)
                        {
                            My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.BlueprintTab, FacilityProductionType);
                            My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.MiningTab, FacilityProductionType);
                        }
                        if (Location != ProgramLocation.ReprocessingPlant & Public_Variables.ReprocessingPlantOpen)
                        {
                            ((frmReprocessingPlant)Application.OpenForms["frmReprocessingPlant"]).InitializeReprocessingFacility();
                        }
                    }

                    // If Location <> ProgramLocation.IceBelts And IceBeltFlipOpen And FacilityProductionType = ProductionType.Reprocessing Then
                    // Call CType(Application.OpenForms.Item("frmIceBeltFlip"), frmIceBeltFlip).InitializeReprocessingFacility()
                    // End If

                    // If Location <> ProgramLocation.SovBelts And OreBeltFlipOpen And FacilityProductionType = ProductionType.Reprocessing Then
                    // Call CType(Application.OpenForms.Item("frmIndustryBeltFlip"), frmIndustryBeltFlip).InitializeReprocessingFacility()
                    // End If
                    // Non-reprocessing is just limited to bp and manufacturing tab
                    else if (Location == ProgramLocation.BlueprintTab)
                    {
                        My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.ManufacturingTab, FacilityProductionType);
                    }
                    else
                    {
                        My.MyProject.Forms.frmMain.LoadFacilities(ProgramLocation.BlueprintTab, FacilityProductionType);
                    }
                }

                if (!SupressNotice)
                {
                    Interaction.MsgBox("Facility Saved", Constants.vbInformation, Application.ProductName);
                }

                return true;
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("Facility Failed to Save", Constants.vbExclamation, Application.ProductName);
                return false;
            }

        }

        // Compares the sent facility To the current one And returns a Boolean On equivlancy
        public bool IsEqual(IndustryFacility CompareFacility, bool CompareCostCheck = false, bool CompareTimeCheck = false)
        {

            if (CompareFacility.FacilityType != FacilityType)
            {
                return false;
            }
            else if (CompareFacility.FacilityProductionType != FacilityProductionType)
            {
                return false;
            }
            else if ((CompareFacility.FacilityName ?? "") != (FacilityName ?? ""))
            {
                return false;
            }
            else if ((CompareFacility.RegionName ?? "") != (RegionName ?? ""))
            {
                return false;
            }
            else if (CompareFacility.RegionID != RegionID)
            {
                return false;
            }
            else if ((CompareFacility.SolarSystemName ?? "") != (SolarSystemName ?? ""))
            {
                return false;
            }
            else if (CompareFacility.SolarSystemID != SolarSystemID)
            {
                return false;
            }
            // ElseIf .FWUpgradeLevel <> FWUpgradeLevel Then
            // Return False
            else if (CompareFacility.TaxRate != TaxRate)
            {
                return false;
            }
            else if (CompareFacility.MaterialMultiplier != MaterialMultiplier)
            {
                return false;
            }
            else if (CompareFacility.TimeMultiplier != TimeMultiplier)
            {
                return false;
            }
            else if (CompareFacility.CostMultiplier != CostMultiplier)
            {
                return false;
            }
            else if (CompareFacility.IncludeActivityCost != IncludeActivityCost & CompareCostCheck)
            {
                return false;
            }
            else if (CompareFacility.IncludeActivityTime != IncludeActivityTime & CompareTimeCheck)
            {
                return false;
            }
            else if (CompareFacility.IncludeActivityUsage != IncludeActivityUsage)
            {
                return false;
            }
            else if (CompareFacility.ConvertToOre != ConvertToOre & FacilityProductionType == ProductionType.Reprocessing)
            {
                return false;
            }

            return true;

        }

        public string GetFacilityTypeDescription()
        {
            switch (FacilityType)
            {
                case FacilityTypes.Station:
                    {
                        return ManufacturingFacility.StationFacility;
                    }
                case FacilityTypes.UpwellStructure:
                    {
                        return ManufacturingFacility.StructureFacility;
                    }
                case FacilityTypes.None:
                    {
                        return Public_Variables.None;
                    }

                default:
                    {
                        return Public_Variables.None;
                    }
            }
        }

        // Refreshes the MM/TM/CM bonuses for all three for the information sent if it's a structure
        public void RefreshMMTMCMBonuses(int ItemGroupID, int ItemCategoryID)
        {
            if (FacilityType != FacilityTypes.Station)
            {
                // Cost
                if (!ManualCost)
                {
                    CostMultiplier = BaseCost * (1d - GetFacilityBonusMulitiplier(ModifierType.CostModifier, ActivityID, ItemGroupID, ItemCategoryID));
                }

                // Material
                if (!ManualME)
                {
                    MaterialMultiplier = BaseME * (1d - GetFacilityBonusMulitiplier(ModifierType.MaterialModifier, ActivityID, ItemGroupID, ItemCategoryID));
                }

                // Time
                if (!ManualTE)
                {
                    TimeMultiplier = BaseTE * (1d - GetFacilityBonusMulitiplier(ModifierType.TimeModifier, ActivityID, ItemGroupID, ItemCategoryID));
                }
            }
        }

        // Predicate for searching fitting bonuses 
        private bool FindStructureBonus(FittingBonusInfo Item)
        {
            // SQL &= "AND ((categoryID = {5} AND groupID IS NULL) OR (categoryID IS NULL AND groupID = {6}))"
            {
                ref var withBlock = ref BonusDataToFind;
                if (withBlock.ActivityID == Item.ActivityID & withBlock.AttributeID == Item.AttributeID)
                {
                    if (Item.GroupID == null)
                    {
                        if (Conversions.ToInteger(withBlock.CategoryID) == Conversions.ToInteger(Item.CategoryID))
                        {
                            return true;
                        }
                    }
                    // Groupid
                    else if (Conversions.ToInteger(withBlock.GroupID) == Conversions.ToInteger(Item.GroupID))
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public double GetFacilityBonusMulitiplier(ModifierType BonusType, int ActivityID, int ItemGroupID, int ItemCategoryID)
        {
            FittingBonusInfo FoundData;
            int CategoryID;
            int GroupID;

            switch (ActivityID)
            {
                case (int)IndustryActivities.Copying:
                case (int)IndustryActivities.Invention:
                case (int)IndustryActivities.ResearchingTimeLevel:
                case (int)IndustryActivities.ResearchingMaterialLevel:
                    {
                        CategoryID = 9;
                        GroupID = default;
                        break;
                    }

                default:
                    {
                        CategoryID = ItemCategoryID;
                        GroupID = ItemGroupID;
                        break;
                    }
            }

            // Set the base lookup data
            BonusDataToFind.ActivityID = ActivityID;
            if (!(ItemCategoryID == null))
            {
                BonusDataToFind.CategoryID = CategoryID;
            }
            else
            {
                BonusDataToFind.CategoryID = null;
            }
            if (!(ItemGroupID == null))
            {
                BonusDataToFind.GroupID = GroupID;
            }
            else
            {
                BonusDataToFind.GroupID = null;
            }

            switch (BonusType)
            {
                case ModifierType.MaterialModifier:
                    {
                        // Look up thukker first if it's in the correct groupids
                        if (!(ItemGroupID == null))
                        {
                            if (ItemGroupID == (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.CapitalComponentGroupID)
                            {
                                // Look for thukker bonus
                                BonusDataToFind.AttributeID = (int)ItemAttributes.attributeThukkerEngRigMatBonus;
                                FoundData = FittingBonuses.Find(FindStructureBonus);

                                if (FoundData.Bonus > 0d)
                                {
                                    // Found the tukker bonus and it's in the groups we are looking at
                                    if (ThukkerRigIDs.Contains(FoundData.RigID))
                                    {
                                        return FoundData.Bonus;
                                    }
                                }
                            }

                            // Just look up the normal Material bonus
                            BonusDataToFind.AttributeID = (int)ItemAttributes.attributeEngRigMatBonus;

                        }

                        break;
                    }
                case ModifierType.TimeModifier:
                    {
                        BonusDataToFind.AttributeID = (int)ItemAttributes.attributeEngRigTimeBonus;
                        break;
                    }
                case ModifierType.CostModifier:
                    {
                        BonusDataToFind.AttributeID = (int)ItemAttributes.attributeEngRigCostBonus;
                        break;
                    }
                case ModifierType.ReprocessingRate:
                    {
                        BonusDataToFind.AttributeID = (int)ItemAttributes.refiningYieldMultiplier;
                        break;
                    }

                default:
                    {
                        return 0d;
                    }
            }

            FoundData = FittingBonuses.Find(FindStructureBonus);

            return FoundData.Bonus;

        }

        // Updates the fitting bonuses for the facility if upwell and saves that list locally to the facility for searching later
        public void UpdateProductionFittingInformation(long CharacterID)
        {
            var RigBonuses = new List<Attributebonus>();
            string SQL;
            SQLiteDataReader rsLookup1;
            SQLiteDataReader rsLookup2;
            int RigID;
            FittingBonusInfo Info;

            if (FacilityType == FacilityTypes.UpwellStructure)
            {
                // Reset the list
                FittingBonuses = new List<FittingBonusInfo>();

                // Get all the rigs and category/group combos installed on the facility
                SQL = "SELECT DISTINCT INSTALLED_MODULE_ID FROM UPWELL_STRUCTURES_INSTALLED_MODULES AS USIM, ENGINEERING_RIG_BONUSES AS ERB WHERE ERB.typeID = USIM.INSTALLED_MODULE_ID  ";
                SQL += "AND CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND SOLAR_SYSTEM_ID = {2} AND FACILITY_VIEW = {3} AND FACILITY_ID = {4}";
                Public_Variables.DBCommand = new SQLiteCommand(string.Format(SQL, CharacterID, ((int)FacilityProductionType).ToString(), SolarSystemID.ToString(), ((int)ControlLocation).ToString(), FacilityID.ToString()), Public_Variables.EVEDB.DBREf());
                rsLookup1 = Public_Variables.DBCommand.ExecuteReader();

                while (rsLookup1.Read())
                {
                    RigID = rsLookup1.GetInt32(0);
                    // Get the bonues that apply for each rig
                    RigBonuses = GetRigBonuses(RigID, SolarSystemID);

                    // Now lookup all category/group combos and apply all bonuses to it
                    Public_Variables.DBCommand = new SQLiteCommand("SELECT groupID, categoryID, activityID FROM ENGINEERING_RIG_BONUSES WHERE typeID =" + RigID.ToString(), Public_Variables.EVEDB.DBREf());
                    rsLookup2 = Public_Variables.DBCommand.ExecuteReader();

                    while (rsLookup2.Read())
                    {
                        foreach (var BonusData in RigBonuses)
                        {
                            Info.RigID = RigID;
                            Info.AttributeID = BonusData.AttributeID;
                            Info.Bonus = BonusData.Bonus;
                            if (!(rsLookup2.GetValue(0) is DBNull))
                            {
                                Info.GroupID = rsLookup2.GetValue(0);
                            }
                            else
                            {
                                Info.GroupID = null;
                            }
                            if (!(rsLookup2.GetValue(1) is DBNull))
                            {
                                Info.CategoryID = rsLookup2.GetValue(1);
                            }
                            else
                            {
                                Info.CategoryID = null;
                            }

                            Info.ActivityID = rsLookup2.GetInt32(2);

                            // Insert the fitting bonus
                            FittingBonuses.Add(Info);
                        }
                    }
                    rsLookup2.Close();
                }

                rsLookup1.Close();
            }

        }

        // Returns the Structure modifier based on installed rigs for the sent type
        public double GetStructureModifier(ModifierType SentModifier, double BaseValue, long _SystemID, string _Activity, long _FacilityID, int _ItemGroupID, int _ItemCategoryID, long CharacterID, ProgramLocation Location)
        {
            SQLiteDataReader rsLoader;
            var InstalledModules = new List<int>(); // Reset

            double MM = 1d;
            double TM = 1d;
            double CM = 1d;
            double RefineValue = 0d;

            InstalledModules = GetInstalledModules(_Activity, _FacilityID, _ItemGroupID, _ItemCategoryID, _SystemID, CharacterID, Location);

            if (InstalledModules.Count != 0)
            {
                // Get a list of the IDs that we want to use the thukker mat bonus on
                var ThukkerRigIDs = new List<int>();
                int AttributeID = 0;

                Public_Variables.DBCommand = new SQLiteCommand("SELECT typeID FROM INVENTORY_TYPES WHERE typeName LIKE 'Standup %Thukker%' AND groupID <> 1708", Public_Variables.EVEDB.DBREf());
                rsLoader = Public_Variables.DBCommand.ExecuteReader();

                while (rsLoader.Read())
                    ThukkerRigIDs.Add(rsLoader.GetInt32(0));

                rsLoader.Close();

                // Now, adjust the MM, TM, CM based on modules installed
                foreach (var RigID in InstalledModules)
                {
                    // Look up the bonus while adjusting for the type of space we are in
                    List<Attributebonus> RigBonuses;
                    RigBonuses = GetRigBonuses(RigID, _SystemID);

                    // Adjust MM, TM, CM by attribute and set the base to this as well, override whatever they had before
                    foreach (var Rig in RigBonuses)
                    {
                        switch (Rig.AttributeID)
                        {
                            case (int)ItemAttributes.attributeEngRigCostBonus:
                                {
                                    // Cost
                                    CM *= 1d - Rig.Bonus;
                                    break;
                                }
                            case (int)ItemAttributes.attributeEngRigMatBonus:
                            case (int)ItemAttributes.RefRigMatBonus:
                            case (int)ItemAttributes.attributeThukkerEngRigMatBonus:
                                {
                                    // ME - Thukker only applies to cap components and advanced versions, else use the regular bonus
                                    if (ThukkerRigIDs.Contains(RigID) & AttributeID == (int)ItemAttributes.attributeThukkerEngRigMatBonus & (_ItemGroupID == (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID | _ItemGroupID == (int)Public_Variables.ItemIDs.CapitalComponentGroupID) | !ThukkerRigIDs.Contains(RigID) & AttributeID != (int)ItemAttributes.attributeThukkerEngRigMatBonus)

                                    {
                                        MM *= 1d - Rig.Bonus;
                                    }

                                    break;
                                }
                            case (int)ItemAttributes.attributeEngRigTimeBonus:
                            case (int)ItemAttributes.RefRigTimeBonus:
                                {
                                    // TE
                                    TM *= 1d - Rig.Bonus;
                                    break;
                                }
                            case (int)ItemAttributes.refiningYieldMultiplier:
                                {
                                    RefineValue = Rig.Bonus * 100d * (MaterialMultiplier / Public_Variables.BaseRefineRate); // Calculate new base refine amount (the structure modifier is multiplied to 50% base)
                                    break;
                                }
                        }
                    }
                }
                rsLoader.Close();
            }

            switch (SentModifier)
            {
                case ModifierType.MaterialModifier:
                    {
                        return BaseValue * MM;
                    }
                case ModifierType.TimeModifier:
                    {
                        return BaseValue * TM;
                    }
                case ModifierType.CostModifier:
                    {
                        return BaseValue * CM;
                    }
                case ModifierType.ReprocessingRate:
                    {
                        return RefineValue;
                    }

                default:
                    {
                        return BaseValue;
                    }
            }

        }

        // Returns an array of rigs installed on the facility for info sent
        private List<int> GetInstalledModules(string Activity, long FacilityID, int ItemGroupID, int ItemCategoryID, long SystemID, long SelectedCharacterID, ProgramLocation SelectedLocation)
        {
            var InstalledModules = new List<int>();

            // Save the current data - this will work for reactions since the groupID is the same for the item being made for lookup
            int TempBPGroupID = ItemGroupID;
            int TempBPCategoryID = ItemCategoryID;

            // Check the activity and adjust the bp data if needed for components to query the bonuses they saved
            if ((Activity ?? "") == ManufacturingFacility.ActivityComponentManufacturing | (Activity ?? "") == ManufacturingFacility.ActivityCapComponentManufacturing)
            {
                switch (ItemGroupID)
                {
                    case (int)Public_Variables.ItemIDs.TitanGroupID:
                    case (int)Public_Variables.ItemIDs.SupercarrierGroupID:
                    case (int)Public_Variables.ItemIDs.DreadnoughtGroupID:
                    case (int)Public_Variables.ItemIDs.CarrierGroupID:
                    case (int)Public_Variables.ItemIDs.CapitalIndustrialShipGroupID:
                    case (int)Public_Variables.ItemIDs.IndustrialCommandShipGroupID:
                    case (int)Public_Variables.ItemIDs.FreighterGroupID:
                    case (int)Public_Variables.ItemIDs.JumpFreighterGroupID:
                    case (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID:
                    case (int)Public_Variables.ItemIDs.CapitalComponentGroupID:
                    case (int)Public_Variables.ItemIDs.FAXGroupID:
                        {
                            TempBPGroupID = (int)Public_Variables.ItemIDs.CapitalComponentGroupID;
                            TempBPCategoryID = (int)Public_Variables.ItemIDs.ComponentCategoryID;
                            break;
                        }

                    default:
                        {
                            TempBPGroupID = (int)Public_Variables.ItemIDs.ConstructionComponentsGroupID;
                            TempBPCategoryID = (int)Public_Variables.ItemIDs.ComponentCategoryID;
                            break;
                        }
                }
            }
            else if ((Activity ?? "") == ManufacturingFacility.ActivityCopying | (Activity ?? "") == ManufacturingFacility.ActivityInvention)
            {
                TempBPCategoryID = (int)Public_Variables.ItemIDs.BlueprintCategoryID;
                TempBPGroupID = (int)Public_Variables.ItemIDs.FrigateBlueprintGroupID;
            }
            else if ((Activity ?? "") == ManufacturingFacility.ActivityReprocessing)
            {
                switch (ItemGroupID)
                {
                    case (int)Public_Variables.ItemIDs.IceGroupID: // Ice
                        {
                            TempBPGroupID = ItemGroupID;
                            break;
                        }
                    case (int)Public_Variables.ItemIDs.CommonMoonAsteroids:
                    case (int)Public_Variables.ItemIDs.ExceptionalMoonAsteroids:
                    case (int)Public_Variables.ItemIDs.RareMoonAsteroids:
                    case (int)Public_Variables.ItemIDs.UbiquitousMoonAsteroids:
                    case (int)Public_Variables.ItemIDs.UncommonMoonAsteroids: // Moon ores
                        {
                            TempBPGroupID = (int)Public_Variables.ItemIDs.CommonMoonAsteroids;
                            break;
                        }
                    case (int)Public_Variables.ItemIDs.Arkonor:
                    case (int)Public_Variables.ItemIDs.Bistot:
                    case (int)Public_Variables.ItemIDs.Crokite:
                    case (int)Public_Variables.ItemIDs.DarkOchre:
                    case (int)Public_Variables.ItemIDs.Gneiss:
                    case (int)Public_Variables.ItemIDs.Hedbergite:
                    case (int)Public_Variables.ItemIDs.Hemorphite:
                    case (int)Public_Variables.ItemIDs.Jaspet:
                    case (int)Public_Variables.ItemIDs.Kernite:
                    case (int)Public_Variables.ItemIDs.Mercoxit:
                    case (int)Public_Variables.ItemIDs.Omber:
                    case (int)Public_Variables.ItemIDs.Plagioclase:
                    case (int)Public_Variables.ItemIDs.Pyroxeres:
                    case (int)Public_Variables.ItemIDs.Scordite:
                    case (int)Public_Variables.ItemIDs.Spodumain:
                    case (int)Public_Variables.ItemIDs.Veldspar:
                        {
                            TempBPGroupID = (int)Public_Variables.ItemIDs.Arkonor; // this is the default for all ores
                            break;
                        }
                }
                TempBPCategoryID = (int)Public_Variables.ItemIDs.AsteroidsCategoryID;
            }

            string SQL = "";
            SQLiteDataReader rsLoader;

            SQL = "SELECT INSTALLED_MODULE_ID FROM UPWELL_STRUCTURES_INSTALLED_MODULES, ENGINEERING_RIG_BONUSES ";
            SQL += "WHERE CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND SOLAR_SYSTEM_ID = {2} AND FACILITY_VIEW = {3} AND FACILITY_ID = {4} ";
            SQL += "AND UPWELL_STRUCTURES_INSTALLED_MODULES.INSTALLED_MODULE_ID = ENGINEERING_RIG_BONUSES.typeID AND activityId = {7} ";
            SQL += "AND ((categoryID = {5} AND groupID IS NULL) OR (categoryID IS NULL AND groupID = {6}))";
            Public_Variables.DBCommand = new SQLiteCommand(string.Format(SQL, SelectedCharacterID, ((int)FacilityProductionType).ToString(), SystemID.ToString(), ((int)SelectedLocation).ToString(), FacilityID.ToString(), TempBPCategoryID.ToString(), TempBPGroupID.ToString(), ActivityID.ToString()), Public_Variables.EVEDB.DBREf());
            rsLoader = Public_Variables.DBCommand.ExecuteReader();

            while (rsLoader.Read())
                InstalledModules.Add(rsLoader.GetInt32(0));
            rsLoader.Close();

            return InstalledModules;

        }

        // Returns the attribute and bonus for the rig ID and system security sent by reference
        private List<Attributebonus> GetRigBonuses(int RigID, long SystemID)
        {
            string SQL = "";
            SQLiteDataReader rsLoader;
            Attributebonus TempAttribute;
            ItemAttributes SecModifier;
            var AttributeData = new List<Attributebonus>();

            // Get the system security first
            double security = Public_Variables.GetSolarSystemSecurityLevel(SystemID);

            if (!(security == null))
            {
                if (security <= 0.0d)
                {
                    SecModifier = ItemAttributes.nullSecModifier;
                }
                else if (security < 0.45d)
                {
                    SecModifier = ItemAttributes.lowSecModifier;
                }
                else
                {
                    SecModifier = ItemAttributes.hiSecModifier;
                }
            }
            else
            {
                // Just assume null
                SecModifier = ItemAttributes.nullSecModifier;
            }

            // Look up the bonus while adjusting for the type of space we are in
            SQL = "SELECT attributeID, ABS(value * (SELECT value FROM TYPE_ATTRIBUTES WHERE TYPEID = {0} AND attributeID = {1})/100) AS BONUS ";
            SQL += "FROM TYPE_ATTRIBUTES WHERE attributeID IN (2593,2594,2595,2713,2714,2653,717) ";
            SQL += "AND value <> 0 AND TYPEID = {0}";
            SQL = string.Format(SQL, RigID, (int)SecModifier);
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsLoader = Public_Variables.DBCommand.ExecuteReader();

            while (rsLoader.Read())
            {
                TempAttribute.AttributeID = rsLoader.GetInt32(0);
                TempAttribute.Bonus = rsLoader.GetDouble(1);
                AttributeData.Add(TempAttribute);
            }

            rsLoader.Close();

            return AttributeData;

        }

    }
}