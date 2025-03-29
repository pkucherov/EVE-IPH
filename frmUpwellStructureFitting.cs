using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmUpwellStructureFitting
    {

        [DllImport("User32", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(int hWnd, int wMsg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 2;

        private readonly List<PictureBox> SlotPictureBoxList = new List<PictureBox>();
        private readonly bool FirstLoad;
        private bool FirstModuleLoad;
        private bool UpdateChecks;

        // Public settings after intialized and returned for setting in the facilities
        public string UpwellStructureName = "";
        public bool SavedFacility;
        public bool ResetManualEntries;
        private readonly ProgramLocation SelectedStructureLocation; // To help determine where we save citadels, etc. 
        private readonly long SelectedCharacterID;
        private readonly ProductionType SelectedFacilityProductionType;
        private readonly long SelectedSolarSystemID;
        private readonly long SelectedFacilityID;
        // Save the selected Upwell Structure so we don't need to look it up
        private UpwellStructureDBData SelectedUpwellStructure;

        private readonly EVEAttributes Attributes = new EVEAttributes();
        // Stores all the stats for the selected citadel
        private StructureAttributes UpwellStructureStats = new StructureAttributes();

        private const int UsesMissilesEffectID = 101;

        private readonly List<UpwellStructureDBData> StructureDBDataList = new List<UpwellStructureDBData>(); // For storing all the types of citadel structures

        private readonly int HighSlotBaseX;
        private readonly int HighSlotBaseWidth;
        private readonly int HighSlotSpacing;
        private readonly int ServiceSlotBaseX;
        private readonly int ServiceSlotBaseWidth;
        private readonly int ServiceSlotSpacing;

        private bool NitrogenFuelBlockBPUpdated;
        private bool HeliumFuelBlockBPUpdated;
        private bool HydrogenFuelBlockBPUpdated;
        private bool OxygenFuelBlockBPUpdated;

        // Save these here incase we update the ME
        private int OriginalNitrogenFuelBlockBPME;
        private int OriginalHeliumFuelBlockBPME;
        private int OriginalHydrogenFuelBlockBPME;
        private int OriginalOxygenFuelBlockBPME;
        private int OriginalNitrogenFuelBlockBPTE;
        private int OriginalHeliumFuelBlockBPTE;
        private int OriginalHydrogenFuelBlockBPTE;
        private int OriginalOxygenFuelBlockBPTE;

        private readonly List<CheckBox> SecurityCheckBoxes;

        private frmBonusPopout frmPopout;

        private List<int> InstalledModules;

        private int ColumnClicked;
        private SortOrder ColumnSortType;
        private int ModulesColumnClicked;
        private SortOrder ModulesColumnSortType;

        // Fuel block IDs
        private enum FuelBlocks
        {
            Nitrogen = 4051,
            NitrogenBP = 4314,
            Hydrogen = 4246,
            HydrogenBP = 4316,
            Helium = 4247,
            HeliumBP = 4315,
            Oxygen = 4312,
            OxygenBP = 4313
        }

        // Used to look up modules and rigs to go into what slot
        private enum SlotSizes
        {
            LowSlot = 11,
            MediumSlot = 13,
            HighSlot = 12
        }

        public struct StructureModule
        {
            public int typeID;
            public string moduleType;
        }

        private struct UpwellStructureDBData
        {
            public string Name;
            public int TypeID;
            public int GroupID;
        }

        private enum ServiceType
        {
            Citadel = 1321,
            Resource = 1322,
            Engineering = 1415,
            MoonDrill = 1887
        }

        private enum StructureGroup
        {
            Citadel = 1657,
            Refinery = 1406,
            Engineering = 1404
        }

        // For saving and updating the selected upwell structure
        private struct StructureAttributes
        {
            public double CPU;
            public double MaxCPU;
            public double PG;
            public double MaxPG;
            public double Calibration;
            public double MaxCalibration;
            public double Capacitor;
            public double MaxCapacitor;
            public double CapacitorRechargeRate;
            public double BaseCapRechargeRate;
            public int ServiceModuleFuelBPH; // Blocks per hour
            public int OnlineFuelAmount; // Blocks to bring services online
            public double FuelBonus; // Bonus for the type of modules it supports
            public int LauncherSlots;

        }

        public frmUpwellStructureFitting(string InitUSName, long CharacterID, ProductionType ProductionTypeCode, ProgramLocation FacilityLocation, string FacilitySystem)
        {

            FirstLoad = true;

            // This call is required by the designer.
            InitializeComponent();

            // Save these varibles for later
            SelectedCharacterID = CharacterID;
            SelectedFacilityProductionType = ProductionTypeCode;
            SelectedStructureLocation = FacilityLocation;

            // Put all the slot images into an array
            {
                ref var withBlock = ref SlotPictureBoxList;
                withBlock.Add(HighSlot1);
                withBlock.Add(HighSlot2);
                withBlock.Add(HighSlot3);
                withBlock.Add(HighSlot4);
                withBlock.Add(HighSlot5);
                withBlock.Add(HighSlot6);
                withBlock.Add(HighSlot7);
                withBlock.Add(HighSlot8);

                withBlock.Add(MidSlot1);
                withBlock.Add(MidSlot2);
                withBlock.Add(MidSlot3);
                withBlock.Add(MidSlot4);
                withBlock.Add(MidSlot5);
                withBlock.Add(MidSlot6);
                withBlock.Add(MidSlot7);
                withBlock.Add(MidSlot8);

                withBlock.Add(LowSlot1);
                withBlock.Add(LowSlot2);
                withBlock.Add(LowSlot3);
                withBlock.Add(LowSlot4);
                withBlock.Add(LowSlot5);
                withBlock.Add(LowSlot6);
                withBlock.Add(LowSlot7);
                withBlock.Add(LowSlot8);

                withBlock.Add(ServiceSlot1);
                withBlock.Add(ServiceSlot2);
                withBlock.Add(ServiceSlot3);
                withBlock.Add(ServiceSlot4);
                withBlock.Add(ServiceSlot5);
                withBlock.Add(ServiceSlot6);

                withBlock.Add(RigSlot1);
                withBlock.Add(RigSlot2);
                withBlock.Add(RigSlot3);
            }

            // Save values
            HighSlotBaseX = HighSlot1.Location.X;
            HighSlotBaseWidth = HighSlot1.Width;
            HighSlotSpacing = HighSlot2.Location.X - (HighSlot1.Location.X + HighSlot1.Width);
            ServiceSlotBaseX = ServiceSlot1.Location.X;
            ServiceSlotBaseWidth = ServiceSlot1.Width;
            ServiceSlotSpacing = ServiceSlot2.Location.X - (ServiceSlot1.Location.X + ServiceSlot1.Width);

            SecurityCheckBoxes = new List<CheckBox>();
            SecurityCheckBoxes.Add(chkHighSec);
            SecurityCheckBoxes.Add(chkLowSec);
            SecurityCheckBoxes.Add(chkNullSec);

            // Get the security of the system
            string System = FacilitySystem;

            if (FacilitySystem.Contains("("))
            {
                // Reset if it has the system index
                System = FacilitySystem.Substring(0, Strings.InStr(FacilitySystem, "(") - 2);
            }

            double FacilitySystemSecurity = Public_Variables.GetSolarSystemSecurityLevel(System);
            SelectedSolarSystemID = Public_Variables.GetSolarSystemID(System);

            // Select the security check box
            if (FacilitySystemSecurity <= 0.0d)
            {
                chkNullSec.Checked = true;
            }
            else if (FacilitySystemSecurity < 0.45d)
            {
                chkLowSec.Checked = true;
            }
            else
            {
                chkHighSec.Checked = true;
            }

            // enable/ disable depending on the view
            if (SelectedStructureLocation == ProgramLocation.None)
            {
                // They aren't connected to a system
                chkHighSec.Enabled = true;
                chkLowSec.Enabled = true;
                chkNullSec.Enabled = true;
            }
            else
            {
                // They are launching from a facility to view a system, don't let them change it
                chkHighSec.Enabled = false;
                chkLowSec.Enabled = false;
                chkNullSec.Enabled = false;
            }

            {
                ref var withBlock1 = ref SettingsVariables.UserUpwellStructureSettings;
                chkItemViewTypeHigh.Checked = withBlock1.HighSlotsCheck;
                chkItemViewTypeMedium.Checked = withBlock1.MediumSlotsCheck;
                chkItemViewTypeLow.Checked = withBlock1.LowSlotsCheck;
                chkItemViewTypeServices.Checked = withBlock1.ServicesCheck;

                chkRigTypeViewReprocessing.Checked = withBlock1.ReprocessingRigsCheck;
                chkRigTypeViewEngineering.Checked = withBlock1.EngineeringRigsCheck;
                chkRigTypeViewCombat.Checked = withBlock1.CombatRigsCheck;
                chkRigTypeViewReaction.Checked = withBlock1.ReactionsRigsCheck;
                chkRigTypeViewDrilling.Checked = withBlock1.DrillingRigsCheck;

                txtItemFilter.Text = withBlock1.SearchFilterText;

                chkIncludeFuelCosts.Checked = withBlock1.IncludeFuelCostsCheck;

                switch (withBlock1.FuelBlockType ?? "")
                {
                    case var @case when @case == (rbtnHeliumFuelBlock.Text ?? ""):
                        {
                            rbtnHeliumFuelBlock.Checked = true;
                            break;
                        }
                    case var case1 when case1 == (rbtnHydrogenFuelBlock.Text ?? ""):
                        {
                            rbtnHydrogenFuelBlock.Checked = true;
                            break;
                        }
                    case var case2 when case2 == (rbtnNitrogenFuelBlock.Text ?? ""):
                        {
                            rbtnNitrogenFuelBlock.Checked = true;
                            break;
                        }
                    case var case3 when case3 == (rbtnOxygenFuelBlock.Text ?? ""):
                        {
                            rbtnOxygenFuelBlock.Checked = true;
                            break;
                        }

                    default:
                        {
                            rbtnHeliumFuelBlock.Checked = true;
                            break;
                        }
                }

                switch (withBlock1.BuyBuildBlockOption ?? "")
                {
                    case var case4 when case4 == (rbtnBuildBlocks.Text ?? ""):
                        {
                            rbtnBuildBlocks.Checked = true;
                            break;
                        }
                    case var case5 when case5 == (rbtnBuyBlocks.Text ?? ""):
                        {
                            rbtnBuyBlocks.Checked = true;
                            break;
                        }

                    default:
                        {
                            rbtnBuildBlocks.Checked = true;
                            break;
                        }
                }

                if (withBlock1.IconListView)
                {
                    rbtnViewIcons.Checked = true;
                }
                else
                {
                    rbtnListView.Checked = true;
                }

            }

            InstalledModules = new List<int>();

            // Get all data on structures for DB look ups first
            LoadStructureDBData();

            // Add all the images to the image list
            LoadFittingImages();

            // Load the facility default if saved
            LoadStructure(InitUSName);

            // Load up all the fuel block data on that tab
            LoadFuelBlockDataTab();

            NitrogenFuelBlockBPUpdated = false;
            HeliumFuelBlockBPUpdated = false;
            HydrogenFuelBlockBPUpdated = false;
            OxygenFuelBlockBPUpdated = false;

            // Set tool tips
            if (SettingsVariables.UserApplicationSettings.ShowToolTips)
            {
                {
                    var withBlock2 = MainToolTip;
                    withBlock2.SetToolTip(btnRefreshPrices, "Refreshes prices on screen (useful if update done in other parts of program)");
                    withBlock2.SetToolTip(btnSavePrices, "Saves prices entered for buying fuel blocks or materials if building");
                    withBlock2.SetToolTip(btnUpdateBuildCost, "Updated the build cost after updating a Fuel Block ME value");
                    withBlock2.SetToolTip(btnSaveFuelBlockInfo, "Saves the Fuel Block BP ME data if changed");
                    withBlock2.SetToolTip(lblFuelReductionBonus, "Fuel bonus only applies to certain services for the structure.");
                }
            }

            frmPopout = new frmBonusPopout();

            SavedFacility = false;
            ResetManualEntries = false;
            FirstLoad = false;

        }

        private void LoadStructureDBData()
        {
            string SQL;
            SQLiteDataReader rsReader;
            SQLiteCommand DBCommand;

            SQL = @"SELECT typeID, typeName, INVENTORY_GROUPS.groupID FROM INVENTORY_TYPES, INVENTORY_GROUPS WHERE INVENTORY_GROUPS.categoryID = 65 
               AND INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupid AND INVENTORY_TYPES.published = 1 
               AND INVENTORY_TYPES.groupID NOT IN (1408, 2016, 2017)";

            DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsReader = DBCommand.ExecuteReader();

            // Clear the combo
            cmbUpwellStructureName.Items.Clear();

            while (rsReader.Read())
            {
                UpwellStructureDBData TempData;

                TempData.TypeID = rsReader.GetInt32(0);
                TempData.Name = rsReader.GetString(1);
                TempData.GroupID = rsReader.GetInt32(2);

                StructureDBDataList.Add(TempData);

                // Also add each to the combo box
                cmbUpwellStructureName.Items.Add(TempData.Name);

            }

            rsReader.Close();

        }

        private void ServiceModuleListView_MouseDown(object sender, MouseEventArgs e)
        {
            // Make sure we select the image
            var Selection = FittingListViewIcons.GetItemAt(e.X, e.Y);

            if (!(Selection == null))
            {
                int ModuleTypeID = Conversions.ToInteger(Selection.ImageKey);

                if (!(Selection == null))
                {
                    pbFloat.Image = FittingImages.Images[Selection.ImageKey];
                    pbFloat.Name = Selection.Group.Name;
                    pbFloat.Tag = Selection.Group.Tag;
                    pbFloat.Text = Selection.Text;
                }
                else
                {
                    pbFloat.Image = null;
                }

                if (!(pbFloat.Image == null))
                {
                    pbFloat.Visible = true;
                    pbFloat.Location = new Point(e.X + FittingListViewIcons.Left, e.Y + FittingListViewIcons.Top);
                    // Now select the image and connect it to the mouse cursor
                    SendMessage(pbFloat.Handle.ToInt32(), WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
                else
                {
                    pbFloat.Visible = false;
                }

                pbFloat.Visible = false;

                Point SlotLocation;
                int WHAdjust = 64;
                var MP = PointToClient(MousePosition);

                // Loop through all the picture boxes and update the one they clicked over
                foreach (var Slot in SlotPictureBoxList)
                {

                    SlotLocation = Slot.Location;
                    SlotLocation.X += tabUpwellStructure.Left;
                    SlotLocation.Y += tabUpwellStructure.Top;

                    // See if they dropped the image on a fitting slot and change the selected item
                    if (MP.X > SlotLocation.X & MP.X < SlotLocation.X + WHAdjust & MP.Y > SlotLocation.Y & MP.Y < SlotLocation.Y + WHAdjust)
                    {
                        string FloatSlot = Conversions.ToString(pbFloat.Tag);

                        if (FloatSlot.Contains(Slot.Name.Substring(0, Strings.Len(Slot.Name) - 1)))
                        {

                            if (!CheckSlots(ModuleTypeID))
                            {
                                return;
                            }

                            // Set the image info
                            Slot.Image = pbFloat.Image;
                            Slot.Image.Tag = ModuleTypeID;
                            Slot.Tag = pbFloat.Name;
                            Slot.Text = pbFloat.Text;

                            // Update the slot stats
                            UpdateUpwellStructureStats();
                            // Update the launcher slots if added a launcher
                            UpdateLauncherSlots(false, ModuleTypeID);
                            // Done updating
                            break;
                        }
                    }
                }
            }
        }

        // Loads a selected image in a free slot - use for double-click on an item
        private void LoadSelectedImageInFreeSlot()
        {
            var Selection = FittingListViewIcons.SelectedItems[0];

            if (!(Selection == null))
            {
                LoadImageInFreeSlot(Conversions.ToInteger(Selection.ImageKey), Selection.Text, Conversions.ToString(Selection.Group.Tag), Selection.Group.Name);
            }

        }

        private void FittingListViewDetails_DoubleClick(object sender, EventArgs e)
        {
            var Selection = FittingListViewDetails.SelectedItems[0];

            if (!(Selection == null))
            {
                LoadImageInFreeSlot(Conversions.ToInteger(Selection.SubItems[2].Text), Selection.SubItems[0].Text, Selection.SubItems[3].Text, Selection.SubItems[1].Text);
            }
        }

        // Loads the image in the first free slot if available - use for double-click an item
        private void LoadImageInFreeSlot(int ModuleTypeID, string ModuleName, string GroupTag, string GroupName)
        {

            // Loop through all the picture boxes and add the first one that is empty
            foreach (var Slot in SlotPictureBoxList)
            {
                string FloatSlot = GroupTag;

                if (FloatSlot.Contains(Slot.Name.Substring(0, Strings.Len(Slot.Name) - 1)))
                {

                    if (!CheckSlots(ModuleTypeID))
                    {
                        return;
                    }

                    // Set the image info if nothing, then exit
                    if (Slot.Image == null)
                    {
                        Slot.Image = FittingImages.Images[ModuleTypeID.ToString()];
                        if (Slot.Image == null)
                        {
                            Slot.Image = new Bitmap(64, 64);
                            Slot.BackgroundImage = null;
                        }
                        Slot.Image.Tag = ModuleTypeID;
                        Slot.Tag = GroupName;
                        Slot.Text = ModuleName;

                        // Update the slot stats
                        UpdateUpwellStructureStats();
                        // Update the launcher slots if added a launcher
                        UpdateLauncherSlots(false, ModuleTypeID);
                        // Done updating
                        break;
                    }
                }
            }

        }

        private bool CheckSlots(int ModuleTypeID)
        {

            // Only drop if over the right slot
            if (RigFound(ModuleTypeID))
            {
                // They already used this rig, so don't allow
                return false;
            }

            if (ServiceFound(ModuleTypeID))
            {
                // Already have this service installed
                return false;
            }

            // Check launchers
            if (IsMissileLauncher(ModuleTypeID))
            {
                if (UpwellStructureStats.LauncherSlots == 0)
                {
                    // They don't have any slots left
                    return false;
                }
            }

            // Finally, look up if the item group is already used
            var CurrentRigs = GetCurrentRigList();
            SQLiteDataReader rsLoader;
            int MaxModules = 0;
            int GroupID;
            if (CurrentRigs.Count > 0)
            {
                foreach (var Rig in CurrentRigs)
                {
                    // Get the group ID of the installed RIG
                    Public_Variables.DBCommand = new SQLiteCommand("SELECT groupID FROM INVENTORY_TYPES WHERE typeID = " + Rig.ToString(), Public_Variables.EVEDB.DBREf());
                    rsLoader = Public_Variables.DBCommand.ExecuteReader();

                    if (rsLoader.Read())
                    {
                        GroupID = rsLoader.GetInt32(0);

                        // Look up the rig max modules value, then compare to the group of this rig they want to add
                        Public_Variables.DBCommand = new SQLiteCommand("SELECT value FROM TYPE_ATTRIBUTES AS TA, INVENTORY_TYPES AS IT WHERE attributeID = 1544 AND IT.typeID = TA.typeID AND TA.typeID = " + ModuleTypeID.ToString() + " AND groupID =" + GroupID.ToString(), Public_Variables.EVEDB.DBREf());
                        rsLoader = Public_Variables.DBCommand.ExecuteReader();

                        if (rsLoader.Read())
                        {
                            MaxModules = (int)Math.Round(rsLoader.GetDouble(0));
                        }

                        if (MaxModules == 1)
                        {
                            // Don't let them add another
                            rsLoader.Close();
                            return false;
                        }

                    }

                    rsLoader.Close();
                }
            }

            return true;

        }

        // Determines if the item is a missile launcher or not to adjust weapon slots
        private bool IsMissileLauncher(int TypeID)
        {
            string SQL = string.Format("SELECT * FROM type_effects WHERe typeid = {0} AND effectID = {1}", TypeID.ToString(), UsesMissilesEffectID);
            SQLiteDataReader rsReader;
            SQLiteCommand DBCommand;

            DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsReader = DBCommand.ExecuteReader();

            if (rsReader.Read())
            {
                // Found it
                rsReader.Close();
                return true;
            }
            else
            {
                rsReader.Close();
                return false;
            }

        }

        // Sees if the rig is already used or not
        private bool RigFound(int TypeID)
        {
            if (GetCurrentRigList().Contains(TypeID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private List<int> GetCurrentRigList()
        {
            var CurrentRigTypes = new List<int>();

            if (!(RigSlot1.Image == null))
            {
                CurrentRigTypes.Add(Conversions.ToInteger(RigSlot1.Image.Tag));
            }
            if (!(RigSlot2.Image == null))
            {
                CurrentRigTypes.Add(Conversions.ToInteger(RigSlot2.Image.Tag));
            }
            if (!(RigSlot3.Image == null))
            {
                CurrentRigTypes.Add(Conversions.ToInteger(RigSlot3.Image.Tag));
            }

            return CurrentRigTypes;

        }

        // See if the service is already used or not
        private bool ServiceFound(int TypeID)
        {
            var CurrentServiceTypes = new List<int>();

            if (!(ServiceSlot1.Image == null))
            {
                CurrentServiceTypes.Add(Conversions.ToInteger(ServiceSlot1.Image.Tag));
            }
            if (!(ServiceSlot2.Image == null))
            {
                CurrentServiceTypes.Add(Conversions.ToInteger(ServiceSlot2.Image.Tag));
            }
            if (!(ServiceSlot3.Image == null))
            {
                CurrentServiceTypes.Add(Conversions.ToInteger(ServiceSlot3.Image.Tag));
            }
            if (!(ServiceSlot4.Image == null))
            {
                CurrentServiceTypes.Add(Conversions.ToInteger(ServiceSlot4.Image.Tag));
            }
            if (!(ServiceSlot5.Image == null))
            {
                CurrentServiceTypes.Add(Conversions.ToInteger(ServiceSlot5.Image.Tag));
            }
            if (!(ServiceSlot6.Image == null))
            {
                CurrentServiceTypes.Add(Conversions.ToInteger(ServiceSlot6.Image.Tag));
            }

            if (CurrentServiceTypes.Contains(TypeID))
            {
                return true;
            }
            else
            {
                // ' Special case, check if they have a research lab loaded already, only allow one
                // If CurrentServiceTypes.Contains(ServiceResearchLabI) And TypeID = ServiceHyasyodaLab Or
                // CurrentServiceTypes.Contains(ServiceHyasyodaLab) And TypeID = ServiceResearchLabI Then
                // Return True
                // Else
                return false;
                // End If
            }

        }

        // Loads up the structure and modules with it
        private void LoadStructure(string SentUSName)
        {
            string SQL = "";
            SQLiteDataReader rsStructure;
            SQLiteCommand DBCommand;

            Application.UseWaitCursor = true;
            Enabled = false;

            // Load the structure first
            UpwellStructureName = SentUSName;

            // First get the data to use
            SelectedUpwellStructure = GetCitadelData(SentUSName);
            // Set the combo text
            cmbUpwellStructureName.SelectedIndexChanged -= cmbUpwellStructureName_SelectedIndexChanged;
            cmbUpwellStructureName.Text = SelectedUpwellStructure.Name;
            cmbUpwellStructureName.SelectedIndexChanged += cmbUpwellStructureName_SelectedIndexChanged;

            // Load the image
            LoadStructureRenderImage();
            // Refresh the items list
            UpdateFittingImages();
            // Set the slots
            UpdateCitadelSlots();
            // Set the stats
            LoadUpwellStuctureStats();

            // Now load up the modules if any are saved for this structure
            SQL = "SELECT INSTALLED_MODULE_ID FROM UPWELL_STRUCTURES_INSTALLED_MODULES, INVENTORY_TYPES ";
            SQL += "WHERE UPWELL_STRUCTURES_INSTALLED_MODULES.FACILITY_ID = INVENTORY_TYPES.typeID ";
            SQL += "AND FACILITY_VIEW = {0} And PRODUCTION_TYPE = {1} And CHARACTER_ID = {2} And SOLAR_SYSTEM_ID = {3} And typeName = '{4}'";

            DBCommand = new SQLiteCommand(string.Format(SQL, (int)SelectedStructureLocation, (int)SelectedFacilityProductionType, SelectedCharacterID, SelectedSolarSystemID, Public_Variables.FormatDBString(SentUSName)), Public_Variables.EVEDB.DBREf());
            rsStructure = DBCommand.ExecuteReader();

            InstalledModules = new List<int>();

            if (rsStructure.HasRows)
            {
                // Need to load each module
                while (rsStructure.Read())
                    InstalledModules.Add(rsStructure.GetInt32(0));
            }

            if (FirstModuleLoad)
            {
                // Reset this so it won't load anymore unless we save this set
                FirstModuleLoad = false;
            }

            rsStructure.Close();
            DBCommand = null;

            // Now fill the slots with the modules in the list
            foreach (var typeID in InstalledModules)
            {

                if (CheckSlots(typeID))
                {
                    SQL = "SELECT typeName, INVENTORY_TYPES.groupID, groupName, ";
                    SQL += "CASE WHEN effectID IS NULL THEN -1 ELSE effectID END AS EffID, ";
                    SQL += "CASE WHEN value IS NULL THEN -1 ELSE value END AS RIG_SIZE ";
                    SQL += "FROM INVENTORY_GROUPS, INVENTORY_TYPES ";
                    SQL += "LEFT JOIN TYPE_EFFECTS ON INVENTORY_TYPES.typeID = TYPE_EFFECTS.typeID AND effectID IN (12,13,11) ";
                    SQL += "LEFT JOIN TYPE_ATTRIBUTES ON INVENTORY_TYPES.typeID = TYPE_ATTRIBUTES.typeID ";
                    SQL += "AND attributeID = " + ((int)ItemAttributes.rigSize).ToString() + " ";
                    SQL += "WHERE INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID And ABS(categoryID) = 66 "; // Rigs are -66
                    SQL += "AND INVENTORY_TYPES.published <> 0 ";
                    SQL += "AND INVENTORY_TYPES.typeID = " + typeID.ToString();

                    DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsStructure = DBCommand.ExecuteReader();

                    if (rsStructure.Read())
                    {
                        int ModuleTypeID = typeID;
                        string ModuleName = rsStructure.GetString(0);
                        string GroupName = "";
                        string GroupTag = "";

                        int GroupID = rsStructure.GetInt32(1);
                        string ModuleGroupName = rsStructure.GetString(2);
                        int EffID = rsStructure.GetInt32(3);
                        int RigCheck = Conversions.ToInteger(rsStructure.GetValue(4));
                        bool Rig;

                        if (RigCheck == -1)
                        {
                            Rig = false;
                        }
                        else
                        {
                            Rig = true;
                        }

                        if (GroupID == (int)ServiceType.Citadel | GroupID == (int)ServiceType.Engineering | GroupID == (int)ServiceType.Resource | GroupID == (int)ServiceType.MoonDrill)
                        {
                            GroupName = "ServiceSlots";
                            GroupTag = "ServiceSlot";
                        }
                        else if (EffID == (int)SlotSizes.HighSlot)
                        {
                            GroupName = "HighSlots";
                            GroupTag = "HighSlot";
                        }
                        else if (EffID == (int)SlotSizes.MediumSlot)
                        {
                            GroupName = "MidSlots";
                            GroupTag = "MidSlot";
                        }
                        else if (EffID == (int)SlotSizes.LowSlot)
                        {
                            GroupName = "LowSlots";
                            GroupTag = "LowSlot";
                        }
                        // Rigs
                        else if (ModuleGroupName.Contains("Combat"))
                        {
                            GroupName = "CombatRigs";
                            GroupTag = "RigSlot";
                        }
                        else if (ModuleGroupName.Contains("Reprocessing") | ModuleGroupName.Contains("Grading"))
                        {
                            GroupName = "ReprocessingRigs";
                            GroupTag = "RigSlot";
                        }
                        else if (ModuleGroupName.Contains("Engineering"))
                        {
                            GroupName = "EngineeringRigs";
                            GroupTag = "RigSlot";
                        }
                        else if (ModuleGroupName.Contains("Reactor"))
                        {
                            GroupName = "ReactionRigs";
                            GroupTag = "RigSlot";
                        }
                        else if (ModuleGroupName.Contains("Drilling"))
                        {
                            GroupName = "DrillingRigs";
                            GroupTag = "RigSlot";
                        }

                        // Now add the image to an image slot
                        LoadImageInFreeSlot(ModuleTypeID, ModuleName, GroupTag, GroupName);

                    }
                }
            }

            Application.UseWaitCursor = false;
            Enabled = true;

        }

        // Strips all modules and services from the fitting
        private void StripFitting()
        {

            HighSlot1.Image = null;
            HighSlot2.Image = null;
            HighSlot3.Image = null;
            HighSlot4.Image = null;
            HighSlot5.Image = null;
            HighSlot6.Image = null;
            HighSlot7.Image = null;
            HighSlot8.Image = null;

            MidSlot1.Image = null;
            MidSlot2.Image = null;
            MidSlot3.Image = null;
            MidSlot4.Image = null;
            MidSlot5.Image = null;
            MidSlot6.Image = null;
            MidSlot7.Image = null;
            MidSlot8.Image = null;

            LowSlot1.Image = null;
            LowSlot2.Image = null;
            LowSlot3.Image = null;
            LowSlot4.Image = null;
            LowSlot5.Image = null;
            LowSlot6.Image = null;
            LowSlot7.Image = null;
            LowSlot8.Image = null;

            ServiceSlot1.Image = null;
            ServiceSlot2.Image = null;
            ServiceSlot3.Image = null;
            ServiceSlot4.Image = null;
            ServiceSlot5.Image = null;
            ServiceSlot6.Image = null;

            RigSlot1.Image = null;
            RigSlot2.Image = null;
            RigSlot3.Image = null;

            // init the upwell structure stats
            LoadUpwellStuctureStats();

        }

        // Load the image into the background
        private void LoadStructureRenderImage()
        {

            foreach (var UPWStructure in StructureDBDataList)
            {
                // Look for the name and then load the render image from the typeID (should be in images folder)
                if ((UPWStructure.Name ?? "") == (cmbUpwellStructureName.Text ?? ""))
                {
                    if (File.Exists(Path.Combine(Public_Variables.UserImagePath, UPWStructure.TypeID.ToString() + ".png")))
                    {
                        StructurePicture.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, UPWStructure.TypeID + ".png"));
                    }
                    else
                    {
                        StructurePicture.Image = null;
                    }
                    break;
                }
            }

            StructurePicture.Refresh();
            Application.DoEvents();

        }

        // Gets and returns the upwell structure data
        private UpwellStructureDBData GetCitadelData(string LookupName)
        {
            string SQL;
            SQLiteDataReader rsReader;
            SQLiteCommand DBCommand;

            SQL = "Select typeID, groupID FROM INVENTORY_TYPES ";
            SQL += "WHERE INVENTORY_TYPES.published <> 0 And typeName = '" + Public_Variables.FormatDBString(LookupName) + "'";

            DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsReader = DBCommand.ExecuteReader();

            if (rsReader.Read())
            {
                UpwellStructureDBData TempData;

                TempData.TypeID = rsReader.GetInt32(0);
                TempData.Name = LookupName;
                TempData.GroupID = rsReader.GetInt32(1);
                rsReader.Close();

                return TempData;
            }

            else
            {
                return default;
            }

        }

        // Clear and Set the slots to match the upwell structure we are using
        private void UpdateCitadelSlots()
        {
            string SQL;
            SQLiteDataReader rsReader;
            SQLiteCommand DBCommand;
            int AID;

            // Query all the stats for the selected Upwell Structure and process slots
            SQL = "Select attributeID, value ";
            SQL += "FROM TYPE_ATTRIBUTES, INVENTORY_TYPES ";
            SQL += "WHERE attributeID In (" + ((int)ItemAttributes.hiSlots).ToString() + "," + ((int)ItemAttributes.medSlots).ToString() + "," + ((int)ItemAttributes.lowSlots).ToString() + "," + ((int)ItemAttributes.serviceSlots).ToString() + "," + ((int)ItemAttributes.rigSlots).ToString() + ") ";
            SQL += "And INVENTORY_TYPES.typeID = TYPE_ATTRIBUTES.typeID And typeName = '" + Public_Variables.FormatDBString(cmbUpwellStructureName.Text) + "'";

            DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsReader = DBCommand.ExecuteReader();

            while (rsReader.Read())
            {
                AID = rsReader.GetInt32(0);
                if (AID == (int)ItemAttributes.hiSlots)
                {
                    SetHighSlots(Conversions.ToInteger(rsReader.GetValue(1)));
                }
                else if (AID == (int)ItemAttributes.medSlots)
                {
                    SetMidSlots(Conversions.ToInteger(rsReader.GetValue(1)));
                }
                else if (AID == (int)ItemAttributes.lowSlots)
                {
                    SetLowSlots(Conversions.ToInteger(rsReader.GetValue(1)));
                }
                else if (AID == (int)ItemAttributes.rigSlots)
                {
                    SetRigSlots(Conversions.ToInteger(rsReader.GetValue(1)));
                }
                else if (AID == (int)ItemAttributes.serviceSlots)
                {
                    SetServiceSlots(Conversions.ToInteger(rsReader.GetValue(1)));
                }
            }

            rsReader.Close();

        }

        // Updates the stats after a module is chosen
        private void LoadUpwellStuctureStats(bool IgnoreLabelUpdate = false)
        {
            List<AttributeRecord> Stats;
            var AttributesLookup = new EVEAttributes();

            // Get all the stats for the upwell structure 
            Stats = AttributesLookup.GetAttributes(SelectedUpwellStructure.Name);

            // Loop through and get the stuff we want, save it locally for update
            foreach (var Stat in Stats)
            {
                switch (Stat.ID)
                {
                    case (int)ItemAttributes.cpuOutput:
                        {
                            UpwellStructureStats.MaxCPU = Stat.Value;
                            UpwellStructureStats.CPU = Stat.Value;
                            break;
                        }
                    case (int)ItemAttributes.powerOutput:
                        {
                            UpwellStructureStats.MaxPG = Stat.Value;
                            UpwellStructureStats.PG = Stat.Value;
                            break;
                        }
                    case (int)ItemAttributes.upgradeCapacity: // Calibration
                        {
                            UpwellStructureStats.MaxCalibration = Stat.Value;
                            UpwellStructureStats.Calibration = Stat.Value;
                            break;
                        }
                    case (int)ItemAttributes.capacitorCapacity:
                        {
                            UpwellStructureStats.Capacitor = Stat.Value;
                            UpwellStructureStats.MaxCapacitor = Stat.Value;
                            break;
                        }
                    case (int)ItemAttributes.rechargeRate:
                        {
                            UpwellStructureStats.CapacitorRechargeRate = 100d;
                            UpwellStructureStats.BaseCapRechargeRate = Stat.Value;
                            break;
                        }
                    case (int)ItemAttributes.structureServiceRoleBonus:
                        {
                            UpwellStructureStats.FuelBonus = Stat.Value;
                            break;
                        }
                    case (int)ItemAttributes.launcherSlotsLeft:
                        {
                            if (!IgnoreLabelUpdate)
                            {
                                // Only update this if we are updating the label too
                                UpwellStructureStats.LauncherSlots = (int)Math.Round(Stat.Value);
                            }

                            break;
                        }
                }
            }

            // Fuel is always 0 to start with no limit
            UpwellStructureStats.ServiceModuleFuelBPH = 0;
            UpwellStructureStats.OnlineFuelAmount = 0;

            // Update the stats
            if (!IgnoreLabelUpdate)
            {
                UpdateUpwellStructureStatLabels();
            }

        }

        // Updates the label stats of the upwell structure to include any items selected and installed
        private void UpdateUpwellStructureStatLabels()
        {

            // Update the labels
            lblCPU.Text = Strings.FormatNumber(UpwellStructureStats.CPU) + " / " + Strings.FormatNumber(UpwellStructureStats.MaxCPU);
            if (UpwellStructureStats.CPU < 0d)
            {
                lblCPU.ForeColor = Color.Red;
            }
            else
            {
                lblCPU.ForeColor = Color.Black;
            }

            lblPowerGrid.Text = Strings.FormatNumber(UpwellStructureStats.PG) + " / " + Strings.FormatNumber(UpwellStructureStats.MaxPG);
            if (UpwellStructureStats.PG < 0d)
            {
                lblPowerGrid.ForeColor = Color.Red;
            }
            else
            {
                lblPowerGrid.ForeColor = Color.Black;
            }

            lblCalibration.Text = Strings.FormatNumber(UpwellStructureStats.Calibration) + " / " + Strings.FormatNumber(UpwellStructureStats.MaxCalibration);
            if (UpwellStructureStats.Calibration < 0d)
            {
                lblCalibration.ForeColor = Color.Red;
            }
            else
            {
                lblCalibration.ForeColor = Color.Black;
            }

            lblCapacitor.Text = Strings.FormatNumber(UpwellStructureStats.Capacitor) + " / " + Strings.FormatNumber(UpwellStructureStats.MaxCapacitor);
            if (UpwellStructureStats.Capacitor < 0d)
            {
                lblCapacitor.ForeColor = Color.Red;
            }
            else
            {
                lblCapacitor.ForeColor = Color.Black;
            }

            lblLauncherSlots.Text = "Launcher Slots: " + UpwellStructureStats.LauncherSlots.ToString();

            // Update the fuel costs label
            UpdateFuelCostLabels();

        }

        private void UpdateUpwellStructureStats()
        {
            List<StructureModule> InstalledSlots;
            List<AttributeRecord> Attributes;
            var AttribLookup = new EVEAttributes();
            int FuelBlocks;

            InstalledSlots = GetInstalledSlots();

            // Reset the totals each time before updating
            LoadUpwellStuctureStats(true);

            InstalledModules = new List<int>();

            foreach (var Item in InstalledSlots)
            {
                // Look up the attributes for each slot and update the stats we want
                Attributes = AttribLookup.GetAttributes(Item.typeID);

                // insert into the installed modules to reset new list
                InstalledModules.Add(Item.typeID);

                foreach (var Attribute in Attributes)
                {
                    switch (Attribute.ID)
                    {
                        case (int)ItemAttributes.power:
                            {
                                UpwellStructureStats.PG -= Attribute.Value;
                                break;
                            }
                        case (int)ItemAttributes.cpu:
                            {
                                UpwellStructureStats.CPU -= Attribute.Value;
                                break;
                            }
                        case (int)ItemAttributes.capacitorNeed:
                            {
                                UpwellStructureStats.Capacitor -= Attribute.Value;
                                break;
                            }
                        case (int)ItemAttributes.upgradeCost: // Calibration
                            {
                                UpwellStructureStats.Calibration -= Attribute.Value;
                                break;
                            }
                        case (int)ItemAttributes.cpuMultiplier:
                            {
                                UpwellStructureStats.MaxCPU *= Attribute.Value;
                                break;
                            }
                        case (int)ItemAttributes.powerOutputMultiplier:
                            {
                                UpwellStructureStats.MaxPG *= Attribute.Value;
                                break;
                            }
                        case (int)ItemAttributes.serviceModuleFuelAmount:
                            {
                                // Apply fuel bonus for this type of structure
                                FuelBlocks = (int)Math.Round(Attribute.Value);
                                if (FuelBonusApplies(Item.typeID))
                                {
                                    FuelBlocks = (int)Math.Round(Math.Floor(FuelBlocks * (1d + UpwellStructureStats.FuelBonus / 100d)));
                                }
                                UpwellStructureStats.ServiceModuleFuelBPH += FuelBlocks;
                                break;
                            }

                        case (int)ItemAttributes.serviceModuleFuelOnlineAmount:
                            {
                                UpwellStructureStats.OnlineFuelAmount += (int)Math.Round(Attribute.Value);
                                break;
                            }
                    }
                }
            }

            // Update the stat labels
            UpdateUpwellStructureStatLabels();

            // Update the bonuses from items installed
            UpdateUpwellStructureBonuses();

        }

        private bool FuelBonusApplies(int StructureModuleID)
        {
            string SQL;
            SQLiteDataReader rsReader;
            SQLiteCommand DBCommand;
            int GroupID;

            try
            {
                SQL = "SELECT groupID FROM INVENTORY_TYPES WHERE typeID = " + StructureModuleID;

                DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsReader = DBCommand.ExecuteReader();
                rsReader.Read();
                GroupID = rsReader.GetInt32(0);
                rsReader.Close();

                switch (SelectedUpwellStructure.GroupID)
                {
                    case (int)StructureGroup.Citadel:
                        {
                            if (GroupID == (int)ServiceType.Citadel)
                            {
                                return true;
                            }

                            break;
                        }
                    case (int)StructureGroup.Engineering:
                        {
                            if (GroupID == (int)ServiceType.Engineering)
                            {
                                return true;
                            }

                            break;
                        }
                    case (int)StructureGroup.Refinery: // no bonus for moon drill
                        {
                            if (GroupID == (int)ServiceType.Resource)
                            {
                                return true;
                            }

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;

        }

        // If true, increments the launcher slots, else decrements
        private void UpdateLauncherSlots(bool Increment, int ModuleTypeID)
        {
            // Update number of launchers
            if (IsMissileLauncher(ModuleTypeID))
            {
                if (!Increment)
                {
                    if (UpwellStructureStats.LauncherSlots > 0)
                    {
                        UpwellStructureStats.LauncherSlots -= 1;
                    }
                }

                else
                {
                    UpwellStructureStats.LauncherSlots += 1;
                }
            }

            lblLauncherSlots.Text = "Launcher Slots: " + UpwellStructureStats.LauncherSlots.ToString();

        }

        // Returns the list of moduleIDs installed in the upwell structure
        private List<StructureModule> GetInstalledSlots()
        {
            var ReturnItems = new List<StructureModule>();
            StructureModule Entry;

            // Go through all slots and return the typeIDs (saved in tag of image) for each installed item
            if (!(HighSlot1.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(HighSlot1.Image.Tag);
                Entry.moduleType = Conversions.ToString(HighSlot1.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(HighSlot2.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(HighSlot2.Image.Tag);
                Entry.moduleType = Conversions.ToString(HighSlot2.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(HighSlot3.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(HighSlot3.Image.Tag);
                Entry.moduleType = Conversions.ToString(HighSlot3.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(HighSlot4.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(HighSlot4.Image.Tag);
                Entry.moduleType = Conversions.ToString(HighSlot4.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(HighSlot5.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(HighSlot5.Image.Tag);
                Entry.moduleType = Conversions.ToString(HighSlot5.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(HighSlot6.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(HighSlot6.Image.Tag);
                Entry.moduleType = Conversions.ToString(HighSlot6.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(HighSlot7.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(HighSlot7.Image.Tag);
                Entry.moduleType = Conversions.ToString(HighSlot7.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(HighSlot8.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(HighSlot8.Image.Tag);
                Entry.moduleType = Conversions.ToString(HighSlot8.Tag);
                ReturnItems.Add(Entry);
            }

            if (!(MidSlot1.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(MidSlot1.Image.Tag);
                Entry.moduleType = Conversions.ToString(MidSlot1.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(MidSlot2.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(MidSlot2.Image.Tag);
                Entry.moduleType = Conversions.ToString(MidSlot2.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(MidSlot3.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(MidSlot3.Image.Tag);
                Entry.moduleType = Conversions.ToString(MidSlot3.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(MidSlot4.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(MidSlot4.Image.Tag);
                Entry.moduleType = Conversions.ToString(MidSlot4.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(MidSlot5.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(MidSlot5.Image.Tag);
                Entry.moduleType = Conversions.ToString(MidSlot5.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(MidSlot6.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(MidSlot6.Image.Tag);
                Entry.moduleType = Conversions.ToString(MidSlot6.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(MidSlot7.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(MidSlot7.Image.Tag);
                Entry.moduleType = Conversions.ToString(MidSlot7.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(MidSlot8.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(MidSlot8.Image.Tag);
                Entry.moduleType = Conversions.ToString(MidSlot8.Tag);
                ReturnItems.Add(Entry);
            }

            if (!(LowSlot1.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(LowSlot1.Image.Tag);
                Entry.moduleType = Conversions.ToString(LowSlot1.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(LowSlot2.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(LowSlot2.Image.Tag);
                Entry.moduleType = Conversions.ToString(LowSlot2.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(LowSlot3.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(LowSlot3.Image.Tag);
                Entry.moduleType = Conversions.ToString(LowSlot3.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(LowSlot4.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(HighSlot1.Image.Tag);
                Entry.moduleType = Conversions.ToString(HighSlot1.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(LowSlot5.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(LowSlot5.Image.Tag);
                Entry.moduleType = Conversions.ToString(LowSlot5.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(LowSlot6.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(LowSlot6.Image.Tag);
                Entry.moduleType = Conversions.ToString(LowSlot6.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(LowSlot7.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(LowSlot7.Image.Tag);
                Entry.moduleType = Conversions.ToString(LowSlot7.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(LowSlot8.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(LowSlot8.Image.Tag);
                Entry.moduleType = Conversions.ToString(LowSlot8.Tag);
                ReturnItems.Add(Entry);
            }

            // Rigs!
            if (!(RigSlot1.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(RigSlot1.Image.Tag);
                Entry.moduleType = Conversions.ToString(RigSlot1.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(RigSlot2.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(RigSlot2.Image.Tag);
                Entry.moduleType = Conversions.ToString(RigSlot2.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(RigSlot3.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(RigSlot3.Image.Tag);
                Entry.moduleType = Conversions.ToString(RigSlot3.Tag);
                ReturnItems.Add(Entry);
            }

            if (!(ServiceSlot1.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(ServiceSlot1.Image.Tag);
                Entry.moduleType = Conversions.ToString(ServiceSlot1.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(ServiceSlot2.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(ServiceSlot2.Image.Tag);
                Entry.moduleType = Conversions.ToString(ServiceSlot2.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(ServiceSlot3.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(ServiceSlot3.Image.Tag);
                Entry.moduleType = Conversions.ToString(ServiceSlot3.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(ServiceSlot4.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(ServiceSlot4.Image.Tag);
                Entry.moduleType = Conversions.ToString(ServiceSlot4.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(ServiceSlot5.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(ServiceSlot5.Image.Tag);
                Entry.moduleType = Conversions.ToString(ServiceSlot5.Tag);
                ReturnItems.Add(Entry);
            }
            if (!(ServiceSlot6.Image == null))
            {
                Entry.typeID = Conversions.ToInteger(ServiceSlot6.Image.Tag);
                Entry.moduleType = Conversions.ToString(ServiceSlot6.Tag);
                ReturnItems.Add(Entry);
            }

            return ReturnItems;

        }

        private string GetFuelCost(int NumBlocks)
        {

            // Select the type of fuel and then update the cost per hour from the text boxes
            if (rbtnBuyBlocks.Checked)
            {
                if (rbtnHeliumFuelBlock.Checked)
                {
                    return Strings.FormatNumber(NumBlocks * Conversions.ToDouble(txtHeliumFuelBlockBuyPrice.Text));
                }
                else if (rbtnHydrogenFuelBlock.Checked)
                {
                    return Strings.FormatNumber(NumBlocks * Conversions.ToDouble(txtHydrogenFuelBlockBuyPrice.Text));
                }
                else if (rbtnNitrogenFuelBlock.Checked)
                {
                    return Strings.FormatNumber(NumBlocks * Conversions.ToDouble(txtNitrogenFuelBlockBuyPrice.Text));
                }
                else if (rbtnOxygenFuelBlock.Checked)
                {
                    return Strings.FormatNumber(NumBlocks * Conversions.ToDouble(txtOxygenFuelBlockBuyPrice.Text));
                }
            }
            else if (rbtnHeliumFuelBlock.Checked)
            {
                return Strings.FormatNumber(NumBlocks * Conversions.ToDouble(lblHeliumFuelBlockBuildPrice.Text));
            }
            else if (rbtnHydrogenFuelBlock.Checked)
            {
                return Strings.FormatNumber(NumBlocks * Conversions.ToDouble(lblHydrogenFuelBlockBuildPrice.Text));
            }
            else if (rbtnNitrogenFuelBlock.Checked)
            {
                return Strings.FormatNumber(NumBlocks * Conversions.ToDouble(lblNitrogenFuelBlockBuildPrice.Text));
            }
            else if (rbtnOxygenFuelBlock.Checked)
            {
                return Strings.FormatNumber(NumBlocks * Conversions.ToDouble(lblOxygenFuelBlockBuildPrice.Text));
            }

            return "";

        }

        private void UpdateFuelCostLabels()
        {
            // If they want fuel cost
            if (chkIncludeFuelCosts.Checked)
            {
                // Select blocks and online amount (shouldn't change)
                lblServiceModuleBPH.Text = Strings.FormatNumber(UpwellStructureStats.ServiceModuleFuelBPH, 0) + " Blocks per Hour";
                lblServiceModuleOnlineAmt.Text = Strings.FormatNumber(UpwellStructureStats.OnlineFuelAmount, 0) + " Blocks";
                lblServiceModuleFCPH.Text = GetFuelCost(UpwellStructureStats.ServiceModuleFuelBPH);
                lblServiceModuleBPD.Text = Strings.FormatNumber(UpwellStructureStats.ServiceModuleFuelBPH * 24, 0) + " Blocks per Day";
                lblFuelReductionBonus.Text = "Fuel Bonus: " + Strings.FormatPercent(UpwellStructureStats.FuelBonus / 100d, 0);
            }
            else
            {
                lblServiceModuleBPH.Text = "-";
                lblServiceModuleBPD.Text = "-";
                lblServiceModuleOnlineAmt.Text = "-";
                lblServiceModuleFCPH.Text = "-";
                lblFuelReductionBonus.Text = "-";
            }
        }

        // Loads the images for fittings in the image lists
        private void LoadFittingImages()
        {
            string SQL;
            SQLiteDataReader rsReader;
            SQLiteCommand DBCommand;

            try
            {

                SQL = "SELECT typeID, typeName FROM INVENTORY_TYPES, INVENTORY_GROUPS ";
                SQL += "WHERE INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID AND ABS(categoryID) = 66 "; // I save rigs as -66
                SQL += "AND INVENTORY_TYPES.published <> 0";

                DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsReader = DBCommand.ExecuteReader();

                Image myImage;
                string typeID;
                string typeName;

                while (rsReader.Read())
                {
                    // Add to the image list, and put in view with names
                    typeID = rsReader.GetInt32(0).ToString();
                    typeName = rsReader.GetString(1);
                    if (File.Exists(Path.Combine(Public_Variables.UserImagePath, typeID + "_64.png")))
                    {
                        myImage = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, typeID + "_64.png"));

                        FittingImages.Images.Add(typeID, myImage);
                    }
                }

                rsReader.Close();
            }

            catch (Exception ex)
            {
                Application.DoEvents();
            }
        }

        private bool ModuleTypeSelected()
        {
            if (chkItemViewTypeHigh.Checked | chkItemViewTypeLow.Checked | chkItemViewTypeMedium.Checked | chkItemViewTypeServices.Checked | chkRigTypeViewCombat.Checked | chkRigTypeViewDrilling.Checked | chkRigTypeViewEngineering.Checked | chkRigTypeViewReaction.Checked | chkRigTypeViewReprocessing.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Updates all the fitting images based on the check boxes in the list view
        private void UpdateFittingImages()
        {

            // Clear current images and items
            FittingListViewIcons.BeginUpdate();
            FittingListViewDetails.BeginUpdate();
            FittingListViewIcons.Items.Clear();
            FittingListViewDetails.Items.Clear();

            if (ModuleTypeSelected())
            {

                string SQL;
                string SlotString = "";
                var SQLList = new List<string>();
                SQLiteDataReader rsReader;
                SQLiteCommand DBCommand;
                ListViewItem DVI;

                // query for all types of modules, rigs, and services to fit
                SQL = "SELECT INVENTORY_TYPES.typeID, INVENTORY_GROUPS.groupID, typeName, ";
                SQL += "CASE WHEN effectID IS NULL THEN -1 ELSE effectID END AS EffID, groupName, ";
                SQL += "CASE WHEN value IS NULL THEN -1 ELSE value END AS RIG_SIZE, ";
                SQL += "CASE WHEN (SELECT value FROM TYPE_ATTRIBUTES ";
                SQL += "WHERE typeID = INVENTORY_TYPES.typeID AND (attributeID = " + ((int)ItemAttributes.disallowInHighSec).ToString() + " OR attributeID = " + ((int)ItemAttributes.disallowInEmpireSpace).ToString() + ") ";
                SQL += ") = 1 THEN 0 ELSE 1 END AS ALLOW_IN_HS ";
                SQL += "FROM INVENTORY_GROUPS, INVENTORY_TYPES ";
                SQL += "LEFT JOIN TYPE_EFFECTS ON INVENTORY_TYPES.typeID = TYPE_EFFECTS.typeID AND effectID IN (12,13,11) ";
                SQL += "LEFT JOIN TYPE_ATTRIBUTES ON INVENTORY_TYPES.typeID = TYPE_ATTRIBUTES.typeID ";
                SQL += "AND attributeID = " + ((int)ItemAttributes.rigSize).ToString() + " ";
                SQL += "WHERE INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID And ABS(categoryID) = 66 "; // I save structure rigs as -66
                SQL += "AND INVENTORY_TYPES.published <> 0 ";

                // Add text first
                if (!string.IsNullOrEmpty(Strings.Trim(txtItemFilter.Text)))
                {
                    SQL += "And " + Public_Variables.GetSearchText(txtItemFilter.Text, "typeName") + " ";
                }

                if (chkItemViewTypeServices.Checked)
                {
                    // Add the sql
                    SQLList.Add("(INVENTORY_TYPES.groupID In (" + ((int)ServiceType.Citadel).ToString() + "," + ((int)ServiceType.Engineering).ToString() + "," + ((int)ServiceType.MoonDrill).ToString() + "," + ((int)ServiceType.Resource).ToString() + ")) ");
                }

                // Process high, medium, and low slots together
                if (chkItemViewTypeHigh.Checked)
                {
                    SlotString += ((int)SlotSizes.HighSlot).ToString() + ",";
                }

                if (chkItemViewTypeMedium.Checked)
                {
                    SlotString += ((int)SlotSizes.MediumSlot).ToString() + ",";
                }

                if (chkItemViewTypeLow.Checked)
                {
                    SlotString += ((int)SlotSizes.LowSlot).ToString() + ",";
                }

                if (!string.IsNullOrEmpty(SlotString))
                {
                    SlotString = SlotString.Substring(0, Strings.Len(SlotString) - 1);
                    SlotString = "(EffID In (" + SlotString + "))";
                    // Add the sql
                    SQLList.Add(SlotString);
                }

                if (chkRigTypeViewCombat.Checked | chkRigTypeViewEngineering.Checked | chkRigTypeViewReprocessing.Checked | chkRigTypeViewDrilling.Checked | chkRigTypeViewReaction.Checked)
                {
                    if (chkRigTypeViewCombat.Checked)
                    {
                        SQLList.Add("(groupName Like '%Combat Rig%')");
                    }

                    if (chkRigTypeViewEngineering.Checked)
                    {
                        SQLList.Add("(groupName LIKE '%Engineering Rig%')");
                    }

                    if (chkRigTypeViewReprocessing.Checked)
                    {
                        SQLList.Add("(groupName LIKE '%Resource Rig%')");
                    }

                    if (chkRigTypeViewReaction.Checked)
                    {
                        SQLList.Add("(groupName LIKE '%Reactor Rig%')");
                    }

                    if (chkRigTypeViewDrilling.Checked)
                    {
                        SQLList.Add("(groupName LIKE '%Drilling Rig%')");
                    }

                    var Attrib = new EVEAttributes();

                    // Add the check for rig size to limit, -1 is the default value
                    SQL += "AND RIG_SIZE IN (-1," + (int)Math.Round(Attrib.GetAttribute(SelectedUpwellStructure.TypeID, ItemAttributes.rigSize)) + ") ";

                }

                // Set the SQL
                if (SQLList.Count > 0)
                {
                    SQL += "AND (";
                    foreach (var entry in SQLList)
                        SQL += "(" + entry + ") OR ";
                    // Strip last OR
                    SQL = SQL.Substring(0, Strings.Len(SQL) - 4);
                    SQL += ")";
                }
                else
                {
                    return;
                }

                SQL += " ORDER BY groupName, typeName";

                DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsReader = DBCommand.ExecuteReader();

                while (rsReader.Read())
                {
                    int GID = rsReader.GetInt32(1);
                    int EID = rsReader.GetInt32(3);
                    var LVI = new ListViewItem();
                    bool AllowinHighSec;

                    if (rsReader.GetInt32(6) != 0)
                    {
                        AllowinHighSec = true;
                    }
                    else
                    {
                        AllowinHighSec = false;
                    }

                    // Only add if it can be fit to the selected upwell structure and it meets the space requirements
                    if (StructureCanFitItem(SelectedUpwellStructure.TypeID, SelectedUpwellStructure.GroupID, rsReader.GetInt32(0)) & (chkHighSec.Checked == true & AllowinHighSec | chkHighSec.Checked == false))
                    {

                        // & CStr(ItemAttributes.disallowInHighSec) & ") "
                        if (GID == (int)ServiceType.Citadel | GID == (int)ServiceType.Engineering | GID == (int)ServiceType.Resource | GID == (int)ServiceType.MoonDrill)
                        {
                            LVI.Group = FittingListViewIcons.Groups[0]; // 0 is services
                        }
                        else if (EID == (int)SlotSizes.HighSlot)
                        {
                            LVI.Group = FittingListViewIcons.Groups[1]; // 1 is high
                        }
                        else if (EID == (int)SlotSizes.MediumSlot)
                        {
                            LVI.Group = FittingListViewIcons.Groups[2]; // 2 is medium
                        }
                        else if (EID == (int)SlotSizes.LowSlot)
                        {
                            LVI.Group = FittingListViewIcons.Groups[3]; // 3 is low
                        }
                        // Rigs
                        else if (rsReader.GetString(4).Contains("Combat"))
                        {
                            LVI.Group = FittingListViewIcons.Groups[4]; // 4 is Combat rigs
                        }
                        else if (rsReader.GetString(4).Contains("Reprocessing") | rsReader.GetString(4).Contains("Grading"))
                        {
                            LVI.Group = FittingListViewIcons.Groups[5]; // 5 is Reprocessing rigs
                        }
                        else if (rsReader.GetString(4).Contains("Engineering"))
                        {
                            LVI.Group = FittingListViewIcons.Groups[6]; // 6 is Engineering rigs
                        }
                        else if (rsReader.GetString(4).Contains("Reactor"))
                        {
                            LVI.Group = FittingListViewIcons.Groups[7]; // 7 is Reaction rigs
                        }
                        else if (rsReader.GetString(4).Contains("Drilling"))
                        {
                            LVI.Group = FittingListViewIcons.Groups[8]; // 8 is Drilling rigs
                        }

                        // add the image
                        LVI.ImageKey = rsReader.GetInt32(0).ToString();
                        LVI.Text = rsReader.GetString(2);
                        FittingListViewIcons.Items.Add(LVI);

                        // Add the details list too
                        DVI = new ListViewItem(rsReader.GetString(2)); // Name
                        DVI.SubItems.Add(LVI.Group.Name); // Group name
                        DVI.SubItems.Add(LVI.ImageKey); // Module type id - Hidden
                        DVI.SubItems.Add(Conversions.ToString(LVI.Group.Tag)); // Group tag - Hidden
                        FittingListViewDetails.Items.Add(DVI);
                    }

                }

                // Sort the grid
                ListView argRefListView = FittingListViewDetails;
                int argListPrevColumnClicked = 1;
                var argListPrevColumnSortOrder = SortOrder.Ascending;
                Public_Variables.ListViewColumnSorter(1, ref argRefListView, ref argListPrevColumnClicked, ref argListPrevColumnSortOrder);

            }

            FittingListViewDetails.EndUpdate();
            FittingListViewIcons.EndUpdate();


        }

        // Reads the attributes to see if the itemID sent can be fit to the upwell structureID sent
        private bool StructureCanFitItem(int StructureTypeID, int StructureGroupID, int ItemTypeID)
        {
            string SQL;
            SQLiteDataReader rsReader;
            SQLiteCommand DBCommand;

            SQL = "SELECT value AS STRUCTURE_ID FROM TYPE_ATTRIBUTES, ATTRIBUTE_TYPES ";
            SQL += "WHERE TYPE_ATTRIBUTES.typeID = {0} AND ATTRIBUTE_TYPES.attributeID = TYPE_ATTRIBUTES.attributeID ";
            SQL += "AND (attributeName LIKE 'canFitShipType%' OR attributeName LIKE 'canFitShipGroup%')";
            // Add typeid to look up
            SQL = string.Format(SQL, ItemTypeID);

            DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsReader = DBCommand.ExecuteReader();

            while (rsReader.Read())
            {
                int IDtoCheck = Conversions.ToInteger(rsReader.GetValue(0));
                if (IDtoCheck == StructureTypeID | IDtoCheck == StructureGroupID)
                {
                    return true;
                }
            }

            // Not found
            return false;

        }

        // Moves the high slots to center based on the rig slot images
        private void ShiftHighSlotImages()
        {

            // Move the top 5 over to match the rig slot locations
            HighSlot1.Left = RigSlot2.Left;
            AlignHighSlotsfromBase();

        }

        private void ResetHighSlotImages()
        {

            // Move the top 5 back since 6 and above won't move
            HighSlot1.Left = HighSlotBaseX;
            AlignHighSlotsfromBase();

        }

        private void AlignHighSlotsfromBase()
        {
            // Aligns the high slots based on the first high slot position
            HighSlot2.Left = HighSlot1.Left + HighSlotSpacing + HighSlotBaseWidth;
            HighSlot3.Left = HighSlot1.Left - HighSlotBaseWidth - HighSlotSpacing;
            HighSlot4.Left = HighSlot2.Left + HighSlotSpacing + HighSlotBaseWidth;
            HighSlot5.Left = HighSlot3.Left - HighSlotBaseWidth - HighSlotSpacing;
        }

        // Moves the high slots to center based on the rig slot images
        private void ShiftServiceSlotImages()
        {

            // Move the top 5 over to match the rig slot locations
            ServiceSlot1.Left = RigSlot2.Left;
            AlignServiceSlotsfromBase();

        }

        private void ResetServiceSlotImages()
        {

            // Move the top 5 back since 6 and above won't move
            ServiceSlot1.Left = ServiceSlotBaseX;
            AlignServiceSlotsfromBase();

        }

        private void AlignServiceSlotsfromBase()
        {
            // Aligns the service slots based on the first high slot position
            ServiceSlot2.Left = ServiceSlot1.Left + ServiceSlotSpacing + ServiceSlotBaseWidth;
            ServiceSlot3.Left = ServiceSlot1.Left - ServiceSlotBaseWidth - ServiceSlotSpacing;
            ServiceSlot4.Left = ServiceSlot2.Left + ServiceSlotSpacing + ServiceSlotBaseWidth;
            ServiceSlot5.Left = ServiceSlot3.Left - ServiceSlotBaseWidth - ServiceSlotSpacing;
        }

        private void SetHighSlots(int Slots)
        {

            // Init slots
            HighSlot1.Visible = false;
            HighSlot2.Visible = false;
            HighSlot3.Visible = false;
            HighSlot4.Visible = false;
            HighSlot5.Visible = false;
            HighSlot6.Visible = false;
            HighSlot7.Visible = false;
            HighSlot8.Visible = false;

            HighSlot1.Image = null;
            HighSlot2.Image = null;
            HighSlot3.Image = null;
            HighSlot4.Image = null;
            HighSlot5.Image = null;
            HighSlot6.Image = null;
            HighSlot7.Image = null;
            HighSlot8.Image = null;

            for (int i = 1, loopTo = Slots; i <= loopTo; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            HighSlot1.Visible = true;
                            break;
                        }
                    case 2:
                        {
                            HighSlot2.Visible = true;
                            break;
                        }
                    case 3:
                        {
                            HighSlot3.Visible = true;
                            break;
                        }
                    case 4:
                        {
                            HighSlot4.Visible = true;
                            break;
                        }
                    case 5:
                        {
                            HighSlot5.Visible = true;
                            break;
                        }
                    case 6:
                        {
                            HighSlot6.Visible = true;
                            break;
                        }
                    case 7:
                        {
                            HighSlot7.Visible = true;
                            break;
                        }
                    case 8:
                        {
                            HighSlot8.Visible = true;
                            break;
                        }
                }
            }

            if (Slots % 2 > 0 & Slots < 6)
            {
                // Move the slots if we are on the first line
                ShiftHighSlotImages();
            }
            else
            {
                // Reset them to the base positions
                ResetHighSlotImages();
            }

        }

        private void SetMidSlots(int Slots)
        {

            // Init slots
            MidSlot1.Visible = false;
            MidSlot2.Visible = false;
            MidSlot3.Visible = false;
            MidSlot4.Visible = false;
            MidSlot5.Visible = false;
            MidSlot6.Visible = false;
            MidSlot7.Visible = false;
            MidSlot8.Visible = false;

            MidSlot1.Image = null;
            MidSlot2.Image = null;
            MidSlot3.Image = null;
            MidSlot4.Image = null;
            MidSlot5.Image = null;
            MidSlot6.Image = null;
            MidSlot7.Image = null;
            MidSlot8.Image = null;

            for (int i = 1, loopTo = Slots; i <= loopTo; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            MidSlot1.Visible = true;
                            break;
                        }
                    case 2:
                        {
                            MidSlot2.Visible = true;
                            break;
                        }
                    case 3:
                        {
                            MidSlot3.Visible = true;
                            break;
                        }
                    case 4:
                        {
                            MidSlot4.Visible = true;
                            break;
                        }
                    case 5:
                        {
                            MidSlot5.Visible = true;
                            break;
                        }
                    case 6:
                        {
                            MidSlot6.Visible = true;
                            break;
                        }
                    case 7:
                        {
                            MidSlot7.Visible = true;
                            break;
                        }
                    case 8:
                        {
                            MidSlot8.Visible = true;
                            break;
                        }
                }
            }
        }

        private void SetLowSlots(int Slots)
        {

            // Init slots
            LowSlot1.Visible = false;
            LowSlot2.Visible = false;
            LowSlot3.Visible = false;
            LowSlot4.Visible = false;
            LowSlot5.Visible = false;
            LowSlot6.Visible = false;
            LowSlot7.Visible = false;
            LowSlot8.Visible = false;

            LowSlot1.Image = null;
            LowSlot2.Image = null;
            LowSlot3.Image = null;
            LowSlot4.Image = null;
            LowSlot5.Image = null;
            LowSlot6.Image = null;
            LowSlot7.Image = null;
            LowSlot8.Image = null;

            for (int i = 1, loopTo = Slots; i <= loopTo; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            LowSlot1.Visible = true;
                            break;
                        }
                    case 2:
                        {
                            LowSlot2.Visible = true;
                            break;
                        }
                    case 3:
                        {
                            LowSlot3.Visible = true;
                            break;
                        }
                    case 4:
                        {
                            LowSlot4.Visible = true;
                            break;
                        }
                    case 5:
                        {
                            LowSlot5.Visible = true;
                            break;
                        }
                    case 6:
                        {
                            LowSlot6.Visible = true;
                            break;
                        }
                    case 7:
                        {
                            LowSlot7.Visible = true;
                            break;
                        }
                    case 8:
                        {
                            LowSlot8.Visible = true;
                            break;
                        }
                }
            }
        }

        private void SetRigSlots(int Slots)
        {

            // Init slots
            RigSlot1.Visible = false;
            RigSlot2.Visible = false;
            RigSlot3.Visible = false;

            RigSlot1.Image = null;
            RigSlot2.Image = null;
            RigSlot3.Image = null;

            for (int i = 1, loopTo = Slots; i <= loopTo; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            RigSlot1.Visible = true;
                            break;
                        }
                    case 2:
                        {
                            RigSlot2.Visible = true;
                            break;
                        }
                    case 3:
                        {
                            RigSlot3.Visible = true;
                            break;
                        }
                }
            }
        }

        private void SetServiceSlots(int Slots)
        {

            // Init slots
            ServiceSlot1.Visible = false;
            ServiceSlot2.Visible = false;
            ServiceSlot3.Visible = false;
            ServiceSlot4.Visible = false;
            ServiceSlot5.Visible = false;
            ServiceSlot6.Visible = false;

            ServiceSlot1.Image = null;
            ServiceSlot2.Image = null;
            ServiceSlot3.Image = null;
            ServiceSlot4.Image = null;
            ServiceSlot5.Image = null;
            ServiceSlot6.Image = null;

            for (int i = 1, loopTo = Slots; i <= loopTo; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            ServiceSlot1.Visible = true;
                            break;
                        }
                    case 2:
                        {
                            ServiceSlot2.Visible = true;
                            break;
                        }
                    case 3:
                        {
                            ServiceSlot3.Visible = true;
                            break;
                        }
                    case 4:
                        {
                            ServiceSlot4.Visible = true;
                            break;
                        }
                    case 5:
                        {
                            ServiceSlot5.Visible = true;
                            break;
                        }
                    case 6:
                        {
                            ServiceSlot6.Visible = true;
                            break;
                        }
                }
            }

            if (Slots % 2 > 0 & Slots < 6)
            {
                // Move the slots if we are on the first line
                ShiftServiceSlotImages();
            }
            else
            {
                // Reset them to the base positions
                ResetServiceSlotImages();
            }

        }

        private void btnSaveFitting_Click(object sender, EventArgs e)
        {

            try
            {
                var LocationList = new List<int>();
                string SQL;
                int LID;

                Public_Variables.EVEDB.BeginSQLiteTransaction();

                // See what type of character ID
                long CharID = 0L;
                if (SettingsVariables.UserApplicationSettings.SaveFacilitiesbyChar)
                {
                    CharID = SelectedCharacterID;
                }
                else
                {
                    CharID = Public_Variables.CommonSavedFacilitiesID;
                }

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
                    LocationList.Add((int)SelectedStructureLocation);
                }

                // Delete everything first, then insert the new records
                foreach (var currentLID1 in LocationList)
                {
                    LID = currentLID1;
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format(@"DELETE FROM UPWELL_STRUCTURES_INSTALLED_MODULES WHERE CHARACTER_ID = {0} 
                                                        AND PRODUCTION_TYPE = {1} AND SOLAR_SYSTEM_ID = {2} AND FACILITY_VIEW = {3} AND FACILITY_ID = {4} ", CharID, ((int)SelectedFacilityProductionType).ToString(), SelectedSolarSystemID, LID.ToString(), SelectedUpwellStructure.TypeID));
                }

                // Insert all the modules on the facility
                var Modules = new List<StructureModule>();
                Modules = GetInstalledSlots();
                foreach (var InstalledModule in Modules)
                {
                    foreach (var currentLID2 in LocationList)
                    {
                        LID = currentLID2;
                        SQL = string.Format("INSERT INTO UPWELL_STRUCTURES_INSTALLED_MODULES VALUES({0},{1},{2},{3},{4},{5})", SelectedCharacterID, ((int)SelectedFacilityProductionType).ToString(), SelectedSolarSystemID, LID.ToString(), SelectedUpwellStructure.TypeID, InstalledModule.typeID);
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    }
                }

                // If there are rigs fit to this, then delete any saved multipliers they have saved manually
                if (!(RigSlot1.Image == null) | !(RigSlot2.Image == null) | !(RigSlot3.Image == null))
                {
                    // Don't change tax value
                    SQL = "UPDATE SAVED_FACILITIES SET MATERIAL_MULTIPLIER = NULL, TIME_MULTIPLIER = NULL, COST_MULTIPLIER = NULL ";
                    SQL += "WHERE CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND SOLAR_SYSTEM_ID = {2} AND FACILITY_VIEW = {3} AND FACILITY_TYPE_ID = {4}";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format(SQL, CharID, ((int)SelectedFacilityProductionType).ToString(), SelectedSolarSystemID, ((int)SelectedStructureLocation).ToString(), ((int)FacilityTypes.UpwellStructure).ToString()));
                    // Reset the manual flags in the facility
                    ResetManualEntries = true;
                }

                Public_Variables.EVEDB.CommitSQLiteTransaction();

                // Since they saved this, go ahead and save the facility too
                SavedFacility = true;

                Interaction.MsgBox("Facility Saved", Constants.vbInformation, Application.ProductName);
            }

            catch (Exception ex)
            {
                Public_Variables.EVEDB.RollbackSQLiteTransaction();
                Interaction.MsgBox("Facility failed to save: " + ex.Message, Constants.vbExclamation, Application.ProductName);
            }

        }

        // Loads up the bonuses from the modules installed in the list
        private void UpdateUpwellStructureBonuses()
        {
            string SQL;
            double SystemSecurityBonus;
            SQLiteDataReader rsReader;
            SQLiteDataReader rsCheck;
            SQLiteCommand DBCommand;

            ListViewItem BonusList;
            lstUpwellStructureBonuses.Items.Clear(); // Clear all items each time

            if (Application.OpenForms.OfType<frmBonusPopout>().Any())
            {
                // if the form is active, clear any items first in case we want to add them later
                frmPopout.lstUpwellStructureBonuses.Items.Clear();
            }

            // Loop through each module installed and get a total of all the stats affected and how
            foreach (var InstalledModule in GetInstalledSlots())
            {
                // Only look at rig bonuses for now
                if (InstalledModule.moduleType.Contains("Rig"))
                {
                    // Get the security modifier first - set to 1 if not found
                    SQL = "SELECT value FROM TYPE_ATTRIBUTES WHERE typeID = {0} AND attributeID = ";
                    if (chkHighSec.Checked)
                    {
                        SQL += ((int)ItemAttributes.hiSecModifier).ToString() + " ";
                    }
                    else if (chkLowSec.Checked)
                    {
                        SQL += ((int)ItemAttributes.lowSecModifier).ToString() + " ";
                    }
                    else if (chkNullSec.Checked)
                    {
                        SQL += ((int)ItemAttributes.nullSecModifier).ToString() + " ";
                    }

                    DBCommand = new SQLiteCommand(string.Format(SQL, InstalledModule.typeID), Public_Variables.EVEDB.DBREf());
                    rsReader = DBCommand.ExecuteReader();

                    if (rsReader.Read())
                    {
                        // Save bonus for later application
                        SystemSecurityBonus = rsReader.GetDouble(0);
                    }
                    else
                    {
                        SystemSecurityBonus = 1d;
                    }

                    // Engineering Rigs
                    bool exitFor = false;
                    switch (InstalledModule.moduleType ?? "")
                    {
                        case "EngineeringRigs":
                            {
                                SQL = "SELECT CASE WHEN groupName IS NULL THEN categoryName ELSE groupname END AS BONUS_APPLIES_TO, ";
                                SQL += "INDUSTRY_ACTIVITIES.activityName AS ACTIVITY, ";
                                SQL += "AT.displayNameID AS BONUS_NAME, ";
                                SQL += "value / 100 * " + SystemSecurityBonus.ToString() + " AS BONUS, ";
                                SQL += "typeName AS BONUS_SOURCE ";
                                SQL += "FROM TYPE_ATTRIBUTES AS TA, ENGINEERING_RIG_BONUSES AS ERB, INVENTORY_TYPES AS IT, ATTRIBUTE_TYPES AS AT ";
                                SQL += "LEFT JOIN INVENTORY_GROUPS ON ERB.groupID = INVENTORY_GROUPS.groupID ";
                                SQL += "LEFT JOIN INVENTORY_CATEGORIES ON ERB.categoryID = INVENTORY_CATEGORIES.categoryID ";
                                SQL += "LEFT JOIN INDUSTRY_ACTIVITIES ON ERB.activityID = INDUSTRY_ACTIVITIES.activityID ";
                                SQL += "WHERE TA.attributeID = AT.attributeID AND ERB.typeID = IT.typeID AND TA.typeID = IT.typeID ";
                                SQL += "AND TA.attributeID IN (SELECT attributeID FROM ATTRIBUTE_TYPES WHERE attributeName LIKE 'attributeEngRig%') ";

                                // Only include this if it's a Thukker array, else don't limit
                                DBCommand = new SQLiteCommand("SELECT 'X' FROM INVENTORY_TYPES WHERE typeName LIKE '%Standup%-Set Thukker%' AND typeName NOT LIKE '%Blueprint' AND typeID = " + InstalledModule.typeID.ToString(), Public_Variables.EVEDB.DBREf());
                                rsCheck = DBCommand.ExecuteReader();

                                if (rsCheck.Read())
                                {
                                    SQL += "AND (ERB.groupID NOT IN (873,913) OR ERB.groupID IS NULL) ";
                                }

                                SQL += "AND BONUS <> 0 AND TA.typeID = {0} ";
                                // The rest is for thukker bonus (if it applies)
                                SQL += "UNION ";
                                SQL += "SELECT CASE WHEN groupName IS NULL THEN categoryName ELSE groupname END AS BONUS_APPLIES_TO, ";
                                SQL += "INDUSTRY_ACTIVITIES.activityName AS ACTIVITY, ";
                                SQL += "AT.displayNameID AS BONUS_NAME, ";
                                SQL += "value/ 100 * " + SystemSecurityBonus.ToString() + " AS BONUS, ";
                                SQL += "typeName AS BONUS_SOURCE ";
                                SQL += "FROM TYPE_ATTRIBUTES AS TA, ENGINEERING_RIG_BONUSES AS ERB, INVENTORY_TYPES AS IT, ATTRIBUTE_TYPES AS AT ";
                                SQL += "LEFT JOIN INVENTORY_GROUPS ON ERB.groupID = INVENTORY_GROUPS.groupID ";
                                SQL += "LEFT JOIN INVENTORY_CATEGORIES ON ERB.categoryID = INVENTORY_CATEGORIES.categoryID ";
                                SQL += "LEFT JOIN INDUSTRY_ACTIVITIES ON ERB.activityID = INDUSTRY_ACTIVITIES.activityID ";
                                SQL += "WHERE TA.attributeID = AT.attributeID AND ERB.typeID = IT.typeID AND TA.typeID = IT.typeID ";
                                SQL += "AND TA.attributeID IN (SELECT attributeID FROM ATTRIBUTE_TYPES WHERE attributeName LIKE 'attributeThukkerEngRig%' OR attributeName LIKE 'attributeEngRig%') ";
                                SQL += "AND TA.attributeID <> 2594 AND ERB.groupID IN (873,913) ";
                                break;
                            }

                        case "CombatRigs":
                            {

                                SQL = "SELECT 'Combat' AS BONUS_APPLIES_TO, ";
                                SQL += "'Combat' AS ACTIVITY, ";
                                SQL += "AT.displayNameID AS BONUS_NAME, ";
                                SQL += "value/ 100 * " + SystemSecurityBonus.ToString() + " AS BONUS, ";
                                SQL += "typeName AS BONUS_SOURCE ";
                                SQL += "FROM TYPE_ATTRIBUTES AS TA, INVENTORY_TYPES AS IT, ATTRIBUTE_TYPES AS AT ";
                                SQL += "WHERE TA.attributeID = AT.attributeID ";
                                SQL += "AND TA.typeID = IT.typeID  ";
                                SQL += "AND TA.attributeID IN (SELECT attributeID FROM ATTRIBUTE_TYPES WHERE attributeName LIKE 'structureRig%') ";
                                break;
                            }

                        case "ReprocessingRigs":
                            {

                                SQL = "SELECT 'Refining' AS BONUS_APPLIES_TO, ";
                                SQL += "'Refining' AS ACTIVITY, ";
                                SQL += "AT.displayNameID AS BONUS_NAME, ";
                                SQL += "value* " + SystemSecurityBonus.ToString() + " AS BONUS, "; // Data is stored as a decimal but others it's a full number
                                SQL += "typeName AS BONUS_SOURCE ";
                                SQL += "FROM TYPE_ATTRIBUTES AS TA, INVENTORY_TYPES AS IT, ATTRIBUTE_TYPES AS AT ";
                                SQL += "WHERE TA.attributeID = AT.attributeID ";
                                SQL += "AND TA.typeID = IT.typeID  ";
                                SQL += "AND TA.attributeID IN (SELECT attributeID FROM ATTRIBUTE_TYPES WHERE attributeName LIKE 'refiningYield%') ";
                                break;
                            }

                        case "ReactionRigs":
                            {

                                SQL = "SELECT 'Reactions' AS BONUS_APPLIES_TO, ";
                                SQL += "'Reactions' AS ACTIVITY, ";
                                SQL += "AT.displayNameID AS BONUS_NAME, ";
                                SQL += "value/ 100 * " + SystemSecurityBonus.ToString() + " AS BONUS, ";
                                SQL += "typeName AS BONUS_SOURCE ";
                                SQL += "FROM TYPE_ATTRIBUTES AS TA, INVENTORY_TYPES AS IT, ATTRIBUTE_TYPES AS AT ";
                                SQL += "WHERE TA.attributeID = AT.attributeID ";
                                SQL += "AND TA.typeID = IT.typeID  ";
                                SQL += "AND TA.attributeID IN (SELECT attributeID FROM ATTRIBUTE_TYPES WHERE attributeName LIKE 'attributeEngRig%') ";
                                break;
                            }

                        case "DrillingRigs":
                            {

                                SQL = "SELECT 'Moon Mining' AS BONUS_APPLIES_TO, ";
                                SQL += "'Moon Mining' AS ACTIVITY, ";
                                SQL += "AT.displayNameID AS BONUS_NAME, ";
                                SQL += "value/ 100 * " + SystemSecurityBonus.ToString() + " AS BONUS, ";
                                SQL += "typeName AS BONUS_SOURCE ";
                                SQL += "FROM TYPE_ATTRIBUTES AS TA, INVENTORY_TYPES AS IT, ATTRIBUTE_TYPES AS AT ";
                                SQL += "WHERE TA.attributeID = AT.attributeID ";
                                SQL += "AND TA.typeID = IT.typeID  ";
                                SQL += "AND TA.attributeID IN (SELECT attributeID FROM ATTRIBUTE_TYPES WHERE attributeName LIKE 'moonRig%') ";
                                break;
                            }

                        default:
                            {
                                exitFor = true;
                                break;
                            }
                    }

                    if (exitFor)
                    {
                        break;
                    }

                    SQL += "AND BONUS <> 0 AND TA.typeID = {0} ";

                    DBCommand = new SQLiteCommand(string.Format(SQL, InstalledModule.typeID), Public_Variables.EVEDB.DBREf());
                    rsReader = DBCommand.ExecuteReader();

                    while (rsReader.Read())
                    {
                        // Insert a row with the data pulled
                        // Columns: Bonus Applies to, Activity, Bonuses, Bonus Source
                        BonusList = new ListViewItem(rsReader.GetString(0)); // Group or Category bonus is applied
                        BonusList.SubItems.Add(rsReader.GetString(1)); // Activity
                        BonusList.SubItems.Add(rsReader.GetString(2) + ": " + Strings.FormatPercent(rsReader.GetDouble(3), 2)); // Combine bonus and bonus name
                        BonusList.SubItems.Add(rsReader.GetString(4)); // Source of bonus

                        // Make sure it's visible, then refresh the list
                        if (Application.OpenForms.OfType<frmBonusPopout>().Any())
                        {
                            // add the record to the popout list too
                            ListViewItem PopupBonusList = (ListViewItem)BonusList.Clone();
                            frmPopout.lstUpwellStructureBonuses.Items.Add(PopupBonusList);
                        }

                        // Update the final list
                        lstUpwellStructureBonuses.Items.Add(BonusList);

                    }
                }
            }

        }

        private void btnBonusPopout_Click(object sender, EventArgs e)
        {
            ListViewItem BonusList;

            if (Application.OpenForms.OfType<frmBonusPopout>().Any())
            {
                return;
            }

            frmPopout = new frmBonusPopout();

            frmPopout.lstUpwellStructureBonuses.Items.Clear();

            for (int i = 0, loopTo = lstUpwellStructureBonuses.Items.Count - 1; i <= loopTo; i++)
            {
                BonusList = new ListViewItem(lstUpwellStructureBonuses.Items[i].SubItems[0].Text);
                BonusList.SubItems.Add(lstUpwellStructureBonuses.Items[i].SubItems[1].Text);
                BonusList.SubItems.Add(lstUpwellStructureBonuses.Items[i].SubItems[2].Text);
                BonusList.SubItems.Add(lstUpwellStructureBonuses.Items[i].SubItems[3].Text);

                // Update the form list
                frmPopout.lstUpwellStructureBonuses.Items.Add(BonusList);

            }

            frmPopout.Show();

        }

        #region Fuel Settings

        private void btnRefreshPrices_Click(object sender, EventArgs e)
        {
            // Refresh all prices
            LoadFuelPrices();
        }

        private void btnSavePrices_Click(object sender, EventArgs e)
        {
            string SQL;

            try
            {

                Public_Variables.EVEDB.BeginSQLiteTransaction();
                // Buying, so save only the fuel block prices
                if (!rbtnBuildBlocks.Checked)
                {
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtHeliumFuelBlockBuyPrice.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = " + ((int)FuelBlocks.Helium).ToString();
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtHydrogenFuelBlockBuyPrice.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = " + ((int)FuelBlocks.Hydrogen).ToString();
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtNitrogenFuelBlockBuyPrice.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = " + ((int)FuelBlocks.Nitrogen).ToString();
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtNitrogenFuelBlockBuyPrice.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = " + ((int)FuelBlocks.Oxygen).ToString();
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                }
                else // Only save mats
                {
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtHeliumIsotopes.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 16274";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtHydrogenIsotopes.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 17889";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtNitrogenIsotopes.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 17888";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtOxygenIsotopes.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 17887";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtCoolant.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 9832";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtEnrichedUranium.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 44";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtHeavyWater.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 16272";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtLiquidOzone.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 16273";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtMechanicalParts.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 3689";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtOxygen.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 3683";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtRobotics.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 9848";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtStrontiumClathrates.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = 16275";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                }

                Interaction.MsgBox("Prices Saved", Constants.vbInformation, Text);
                Public_Variables.EVEDB.CommitSQLiteTransaction();

                // Refresh the prices
                LoadFuelPrices();
            }
            catch (Exception EX)
            {
                Interaction.MsgBox("Prices not saved, Error: " + EX.Message, Constants.vbExclamation, Text);
                Public_Variables.EVEDB.RollbackSQLiteTransaction();
            }

        }

        private void btnUpdateBuildCost_Click(object sender, EventArgs e)
        {
            // Refresh the price based on building the blocks with ME's entered (just do all to simplify)
            SetFuelBlockBuildcost(FuelBlocks.Helium);
            SetFuelBlockBuildcost(FuelBlocks.Hydrogen);
            SetFuelBlockBuildcost(FuelBlocks.Nitrogen);
            SetFuelBlockBuildcost(FuelBlocks.Oxygen);
        }

        private void btnSaveFuelBlockInfo_Click(object sender, EventArgs e)
        {

            // Save just the bp ME data if building
            if (rbtnBuildBlocks.Checked)
            {
                if (HeliumFuelBlockBPUpdated)
                {
                    Public_Variables.UpdateBPinDB((long)FuelBlocks.HeliumBP, Conversions.ToInteger(txtHeliumFuelBlockBPME.Text), OriginalHeliumFuelBlockBPTE, Public_Variables.BPType.Original, OriginalHeliumFuelBlockBPME, OriginalHeliumFuelBlockBPTE);
                    HeliumFuelBlockBPUpdated = false; // Saved, so updated
                }

                if (HydrogenFuelBlockBPUpdated)
                {
                    Public_Variables.UpdateBPinDB((long)FuelBlocks.HeliumBP, Conversions.ToInteger(txtHydrogenFuelBlockBPME.Text), OriginalHydrogenFuelBlockBPTE, Public_Variables.BPType.Original, OriginalHydrogenFuelBlockBPME, OriginalHydrogenFuelBlockBPTE);
                    HydrogenFuelBlockBPUpdated = false; // Saved, so updated
                }

                if (NitrogenFuelBlockBPUpdated)
                {
                    Public_Variables.UpdateBPinDB((long)FuelBlocks.HeliumBP, Conversions.ToInteger(txtNitrogenFuelBlockBPME.Text), OriginalNitrogenFuelBlockBPTE, Public_Variables.BPType.Original, OriginalNitrogenFuelBlockBPME, OriginalNitrogenFuelBlockBPTE);
                    NitrogenFuelBlockBPUpdated = false; // Saved, so updated
                }

                if (OxygenFuelBlockBPUpdated)
                {
                    Public_Variables.UpdateBPinDB((long)FuelBlocks.HeliumBP, Conversions.ToInteger(txtOxygenFuelBlockBPME.Text), OriginalOxygenFuelBlockBPTE, Public_Variables.BPType.Original, OriginalOxygenFuelBlockBPME, OriginalOxygenFuelBlockBPTE);
                    OxygenFuelBlockBPUpdated = false; // Saved, so updated
                }
            }

            Interaction.MsgBox("BP Information Saved", Constants.vbInformation, Text);

        }

        private void LoadFuelBlockDataTab()
        {

            // Dynamically load images
            LoadFuelBlockImages();
            // Load all the fuel prices
            LoadFuelPrices();
            // Load the ME's for each fuel block bp
            LoadBlockBPMEs();
            // Load the costs to build the blocks with current settings
            SetFuelBlockBuildcost(FuelBlocks.Helium);
            SetFuelBlockBuildcost(FuelBlocks.Hydrogen);
            SetFuelBlockBuildcost(FuelBlocks.Nitrogen);
            SetFuelBlockBuildcost(FuelBlocks.Oxygen);

        }

        private void LoadBlockBPMEs()
        {
            // Load the ME for the type of block that we are using for this tower
            string SQL;
            SQLiteDataReader reader;
            bool HasHelium = false;
            bool HasHydrogen = false;
            bool HasNitrogen = false;
            bool HasOxygen = false;
            string FoundME;
            int FoundTE;

            SQL = "SELECT ALL_BLUEPRINTS.BLUEPRINT_ID, ME, TE FROM OWNED_BLUEPRINTS, ALL_BLUEPRINTS ";
            SQL += "WHERE ALL_BLUEPRINTS.BLUEPRINT_ID = OWNED_BLUEPRINTS.BLUEPRINT_ID ";
            SQL += "AND ALL_BLUEPRINTS.BLUEPRINT_ID IN (" + ((int)FuelBlocks.HeliumBP).ToString() + "," + ((int)FuelBlocks.HydrogenBP).ToString() + "," + ((int)FuelBlocks.NitrogenBP).ToString() + "," + ((int)FuelBlocks.OxygenBP).ToString() + ")";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            reader = Public_Variables.DBCommand.ExecuteReader();

            while (reader.Read())
            {
                FoundME = reader.GetInt64(1).ToString();
                FoundTE = reader.GetInt32(2);

                switch (reader.GetInt64(0))
                {
                    case (long)FuelBlocks.NitrogenBP:
                        {
                            txtNitrogenFuelBlockBPME.Text = FoundME;
                            OriginalNitrogenFuelBlockBPME = Conversions.ToInteger(FoundME);
                            OriginalNitrogenFuelBlockBPTE = FoundTE;
                            HasNitrogen = true;
                            break;
                        }
                    case (long)FuelBlocks.HydrogenBP:
                        {
                            txtHydrogenFuelBlockBPME.Text = FoundME;
                            OriginalHydrogenFuelBlockBPME = Conversions.ToInteger(FoundME);
                            OriginalHydrogenFuelBlockBPTE = FoundTE;
                            HasHydrogen = true;
                            break;
                        }
                    case (long)FuelBlocks.HeliumBP:
                        {
                            txtHeliumFuelBlockBPME.Text = FoundME;
                            OriginalHeliumFuelBlockBPME = Conversions.ToInteger(FoundME);
                            OriginalHeliumFuelBlockBPTE = FoundTE;
                            HasHelium = true;
                            break;
                        }
                    case (long)FuelBlocks.OxygenBP:
                        {
                            txtOxygenFuelBlockBPME.Text = FoundME;
                            OriginalOxygenFuelBlockBPME = Conversions.ToInteger(FoundME);
                            OriginalOxygenFuelBlockBPTE = FoundTE;
                            HasOxygen = true;
                            break;
                        }
                }

                // See what they didn't have and set to 0 ME
                if (!HasNitrogen)
                {
                    txtNitrogenFuelBlockBPME.Text = "0";
                    OriginalNitrogenFuelBlockBPME = 0;
                    OriginalNitrogenFuelBlockBPTE = 0;
                }
                if (!HasHydrogen)
                {
                    txtHydrogenFuelBlockBPME.Text = "0";
                    OriginalHydrogenFuelBlockBPME = 0;
                    OriginalHydrogenFuelBlockBPTE = 0;
                }
                if (!HasHelium)
                {
                    txtHeliumFuelBlockBPME.Text = "0";
                    OriginalHeliumFuelBlockBPME = 0;
                    OriginalHeliumFuelBlockBPTE = 0;
                }
                if (!HasOxygen)
                {
                    txtOxygenFuelBlockBPME.Text = "0";
                    OriginalOxygenFuelBlockBPME = 0;
                    OriginalOxygenFuelBlockBPTE = 0;
                }

            }

        }

        private void SetFuelBlockBuildcost(FuelBlocks FuelBlock)
        {

            // Go through each fuel block and build it, then set the price. Make sure the ME's are valid first
            switch (FuelBlock)
            {
                case FuelBlocks.Helium:
                    {
                        if (!Information.IsNumeric(txtHeliumFuelBlockBPME.Text))
                        {
                            Interaction.MsgBox("Invalid Fuel Block BPO ME", Constants.vbExclamation, Application.ProductName);
                            txtHeliumFuelBlockBPME.Focus();
                            return;
                        }

                        lblHeliumFuelBlockBuildPrice.Text = GetFuelBlockBuildCost(FuelBlocks.Helium, Conversions.ToInteger(txtHeliumFuelBlockBPME.Text)).ToString();
                        break;
                    }

                case FuelBlocks.Hydrogen:
                    {
                        if (!Information.IsNumeric(txtHydrogenFuelBlockBPME.Text))
                        {
                            Interaction.MsgBox("Invalid Fuel Block BPO ME", Constants.vbExclamation, Application.ProductName);
                            txtHydrogenFuelBlockBPME.Focus();
                            return;
                        }

                        lblHydrogenFuelBlockBuildPrice.Text = GetFuelBlockBuildCost(FuelBlocks.Hydrogen, Conversions.ToInteger(txtHydrogenFuelBlockBPME.Text)).ToString();
                        break;
                    }

                case FuelBlocks.Nitrogen:
                    {
                        if (!Information.IsNumeric(txtNitrogenFuelBlockBPME.Text))
                        {
                            Interaction.MsgBox("Invalid Fuel Block BPO ME", Constants.vbExclamation, Application.ProductName);
                            txtNitrogenFuelBlockBPME.Focus();
                            return;
                        }

                        lblNitrogenFuelBlockBuildPrice.Text = GetFuelBlockBuildCost(FuelBlocks.Nitrogen, Conversions.ToInteger(txtNitrogenFuelBlockBPME.Text)).ToString();
                        break;
                    }

                case FuelBlocks.Oxygen:
                    {
                        if (!Information.IsNumeric(txtOxygenFuelBlockBPME.Text))
                        {
                            Interaction.MsgBox("Invalid Fuel Block BPO ME", Constants.vbExclamation, Application.ProductName);
                            txtOxygenFuelBlockBPME.Focus();
                            return;
                        }

                        lblOxygenFuelBlockBuildPrice.Text = GetFuelBlockBuildCost(FuelBlocks.Oxygen, Conversions.ToInteger(txtOxygenFuelBlockBPME.Text)).ToString();
                        break;
                    }

            }

        }

        private double GetFuelBlockBuildCost(FuelBlocks FuelBlock, int bpME)
        {
            var BuildFacility = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.Manufacturing);
            var ComponentFacility = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.ComponentManufacturing);
            var CapComponentFacility = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.CapitalComponentManufacturing);
            var ReactionFacility = My.MyProject.Forms.frmMain.BPTabFacility.GetFacility(ProductionType.Reactions);
            var BPID = default(int);

            switch (FuelBlock)
            {
                case FuelBlocks.Nitrogen:
                    {
                        BPID = (int)FuelBlocks.NitrogenBP;
                        break;
                    }
                case FuelBlocks.Helium:
                    {
                        BPID = (int)FuelBlocks.HeliumBP;
                        break;
                    }
                case FuelBlocks.Hydrogen:
                    {
                        BPID = (int)FuelBlocks.HydrogenBP;
                        break;
                    }
                case FuelBlocks.Oxygen:
                    {
                        BPID = (int)FuelBlocks.OxygenBP;
                        break;
                    }
            }

            // Build T1 BP for the block, standard settings with whatever is on bp tab
            List<Public_Variables.BuildBuyItem> argBuildBuyList = null;
            IndustryFacility argBPReprocessingFacility = null;
            var BlockBP = new Blueprint(BPID, 1L, bpME, 0, 1, 1, Public_Variables.SelectedCharacter, SettingsVariables.UserApplicationSettings, false, 0d, BuildFacility, ComponentFacility, CapComponentFacility, ReactionFacility, SettingsVariables.UserBPTabSettings.SellExcessBuildItems, SettingsVariables.UserBPTabSettings.BuildT2T3Materials, true, BuildBuyList: ref argBuildBuyList, BPReprocessingFacility: ref argBPReprocessingFacility);
            var TempBF = default(Public_Variables.BrokerFeeInfo);
            TempBF.IncludeFee = Public_Variables.BrokerFeeType.NoFee;
            BlockBP.BuildItems(false, TempBF, false, false, false);

            return BlockBP.GetRawItemUnitPrice();

        }

        private void LoadFuelBlockImages()
        {
            // Just load up all the images dyamically

            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, ((int)FuelBlocks.Nitrogen).ToString() + "_32.png")))
            {
                picNitrogenFuelBlock.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, ((int)FuelBlocks.Nitrogen).ToString() + "_32.png"));
            }
            else
            {
                picNitrogenFuelBlock.Image = null;
            }

            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, ((int)FuelBlocks.Oxygen).ToString() + "_32.png")))
            {
                picOxygenFuelBlock.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, ((int)FuelBlocks.Oxygen).ToString() + "_32.png"));
            }
            else
            {
                picOxygenFuelBlock.Image = null;
            }

            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, ((int)FuelBlocks.Hydrogen).ToString() + "_32.png")))
            {
                picHydrogenFuelBlock.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, ((int)FuelBlocks.Hydrogen).ToString() + "_32.png"));
            }
            else
            {
                picHydrogenFuelBlock.Image = null;
            }

            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, ((int)FuelBlocks.Helium).ToString() + "_32.png")))
            {
                picHeliumFuelBlock.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, ((int)FuelBlocks.Helium).ToString() + "_32.png"));
            }
            else
            {
                picHeliumFuelBlock.Image = null;
            }

            picNitrogenFuelBlock.Refresh();
            picOxygenFuelBlock.Refresh();
            picHydrogenFuelBlock.Refresh();
            picHeliumFuelBlock.Refresh();

            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "9832_32.png")))
            {
                picCoolant.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "9832_32.png"));
            }
            else
            {
                picCoolant.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "44_32.png")))
            {
                picEnrichedUranium.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "44_32.png"));
            }
            else
            {
                picEnrichedUranium.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "16272_32.png")))
            {
                picHeavyWater.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "16272_32.png"));
            }
            else
            {
                picHeavyWater.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "16274_32.png")))
            {
                picHeliumIsotopes.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "16274_32.png"));
            }
            else
            {
                picHeliumIsotopes.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "17889_32.png")))
            {
                picHydrogenIsotopes.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "17889_32.png"));
            }
            else
            {
                picHydrogenIsotopes.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "16273_32.png")))
            {
                picLiquidOzone.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "16273_32.png"));
            }
            else
            {
                picLiquidOzone.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "3689_32.png")))
            {
                picMechanicalParts.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "3689_32.png"));
            }
            else
            {
                picMechanicalParts.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "17888_32.png")))
            {
                picNitrogenIsotopes.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "17888_32.png"));
            }
            else
            {
                picNitrogenIsotopes.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "3683_32.png")))
            {
                picOxygen.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "3683_32.png"));
            }
            else
            {
                picOxygen.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "17887_32.png")))
            {
                picOxygenIsotopes.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "17887_32.png"));
            }
            else
            {
                picOxygenIsotopes.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "9848_32.png")))
            {
                picRobotics.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "9848_32.png"));
            }
            else
            {
                picRobotics.Image = null;
            }
            if (File.Exists(Path.Combine(Public_Variables.UserImagePath, "16275_32.png")))
            {
                picStrontiumClathrates.Image = Image.FromFile(Path.Combine(Public_Variables.UserImagePath, "16275_32.png"));
            }
            else
            {
                picStrontiumClathrates.Image = null;
            }

            picCoolant.Refresh();
            picEnrichedUranium.Refresh();
            picHeavyWater.Refresh();
            picHeliumIsotopes.Refresh();
            picHydrogenIsotopes.Refresh();
            picLiquidOzone.Refresh();
            picMechanicalParts.Refresh();
            picNitrogenIsotopes.Refresh();
            picOxygen.Refresh();
            picOxygenIsotopes.Refresh();
            picRobotics.Refresh();
            picStrontiumClathrates.Refresh();

            Application.DoEvents();

        }

        private void LoadFuelPrices()
        {
            string SQL;
            SQLiteDataReader reader;
            string Price;

            Cursor = Cursors.WaitCursor;

            SQL = "SELECT ITEM_PRICES.ITEM_ID, ITEM_PRICES.PRICE ";
            SQL += "FROM ITEM_PRICES ";
            SQL += "WHERE ITEM_PRICES.ITEM_ID IN ";
            SQL += "(9832, 44, 16272, 16274, 17889, 16273, 3689, 17888, 3683, 17887, 9848, 16275)"; // Mats
            SQL += "OR ITEM_PRICES.ITEM_ID IN (" + ((int)FuelBlocks.Nitrogen).ToString() + "," + ((int)FuelBlocks.Hydrogen).ToString() + "," + ((int)FuelBlocks.Helium).ToString() + "," + ((int)FuelBlocks.Oxygen).ToString() + ")";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            reader = Public_Variables.DBCommand.ExecuteReader();

            while (reader.Read())
            {

                Price = Strings.FormatNumber(reader.GetDouble(1), 2);

                // Update the textboxes with Prices
                switch (reader.GetInt64(0)) // Hydrogen Isotopes'
                {
                    case 17889L:
                        {
                            txtHydrogenIsotopes.Text = Price; // Oxygen Isotopes'
                            break;
                        }

                    case 17887L:
                        {
                            txtOxygenIsotopes.Text = Price; // Nitrogen Isotopes'
                            break;
                        }

                    case 17888L:
                        {
                            txtNitrogenIsotopes.Text = Price; // Helium Isotopes'
                            break;
                        }

                    case 16274L:
                        {
                            txtHeliumIsotopes.Text = Price; // Strontium Clathrates'
                            break;
                        }

                    case 16275L:
                        {
                            txtStrontiumClathrates.Text = Price; // Heavy Water'
                            break;
                        }

                    case 16272L:
                        {
                            txtHeavyWater.Text = Price; // Liquid Ozone'
                            break;
                        }

                    case 16273L:
                        {
                            txtLiquidOzone.Text = Price; // Robotics'
                            break;
                        }

                    case 9848L:
                        {
                            txtRobotics.Text = Price; // Oxygen'
                            break;
                        }

                    case 3683L:
                        {
                            txtOxygen.Text = Price; // Mechanical Parts'
                            break;
                        }

                    case 3689L:
                        {
                            txtMechanicalParts.Text = Price; // Coolant'
                            break;
                        }

                    case 9832L:
                        {
                            txtCoolant.Text = Price; // Enriched Uranium'
                            break;
                        }

                    case 44L:
                        {
                            txtEnrichedUranium.Text = Price;
                            break;
                        }
                    case (long)FuelBlocks.Nitrogen:
                        {
                            txtNitrogenFuelBlockBuyPrice.Text = Price;
                            break;
                        }
                    case (long)FuelBlocks.Hydrogen:
                        {
                            txtHydrogenFuelBlockBuyPrice.Text = Price;
                            break;
                        }
                    case (long)FuelBlocks.Helium:
                        {
                            txtHeliumFuelBlockBuyPrice.Text = Price;
                            break;
                        }
                    case (long)FuelBlocks.Oxygen:
                        {
                            txtOxygenFuelBlockBuyPrice.Text = Price;
                            break;
                        }
                }
                Application.DoEvents();
            }

            Cursor = Cursors.Default;
            txtHeliumIsotopes.Focus();

            reader.Close();
            Public_Variables.DBCommand = null;

        }

        #endregion

        #region Click Events

        private void cmbUpwellStructureName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStructure(cmbUpwellStructureName.Text);
        }

        private void chkItemViewTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void chkItemViewTypeHigh_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void chkItemViewTypeLow_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void chkItemViewTypeMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void chkItemViewTypeServices_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void chkRigTypeViewCombat_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void chkRigTypeViewReaction_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void chkRigTypeViewDrilling_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void chkRigTypeViewEngineering_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void chkRigTypeViewReprocessing_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void cmbUpwellStructureName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void MidSlot1_DoubleClick(object sender, EventArgs e)
        {
            MidSlot1.Image = null;
            MidSlot1.ResetText();
            UpdateUpwellStructureStats();
        }

        private void MidSlot2_DoubleClick(object sender, EventArgs e)
        {
            MidSlot2.Image = null;
            MidSlot2.ResetText();
            UpdateUpwellStructureStats();
        }

        private void MidSlot3_DoubleClick(object sender, EventArgs e)
        {
            MidSlot3.Image = null;
            MidSlot3.ResetText();
            UpdateUpwellStructureStats();
        }

        private void MidSlot4_DoubleClick(object sender, EventArgs e)
        {
            MidSlot4.Image = null;
            MidSlot4.ResetText();
            UpdateUpwellStructureStats();
        }

        private void MidSlot5_DoubleClick(object sender, EventArgs e)
        {
            MidSlot5.Image = null;
            MidSlot5.ResetText();
            UpdateUpwellStructureStats();
        }

        private void MidSlot6_DoubleClick(object sender, EventArgs e)
        {
            MidSlot6.Image = null;
            MidSlot6.ResetText();
            UpdateUpwellStructureStats();
        }

        private void MidSlot7_DoubleClick(object sender, EventArgs e)
        {
            MidSlot7.Image = null;
            MidSlot7.ResetText();
            UpdateUpwellStructureStats();
        }

        private void MidSlot8_DoubleClick(object sender, EventArgs e)
        {
            MidSlot8.Image = null;
            UpdateUpwellStructureStats();
        }

        private void HighSlot1_DoubleClick(object sender, EventArgs e)
        {
            if (!(HighSlot1.Image == null))
            {
                UpdateLauncherSlots(true, Conversions.ToInteger(HighSlot1.Image.Tag));
            }
            HighSlot1.Image = null;
            HighSlot1.ResetText();
            UpdateUpwellStructureStats();
        }

        private void HighSlot2_DoubleClick(object sender, EventArgs e)
        {
            if (!(HighSlot2.Image == null))
            {
                UpdateLauncherSlots(true, Conversions.ToInteger(HighSlot2.Image.Tag));
            }
            HighSlot2.Image = null;
            HighSlot2.ResetText();
            UpdateUpwellStructureStats();
        }

        private void HighSlot3_DoubleClick(object sender, EventArgs e)
        {
            if (!(HighSlot3.Image == null))
            {
                UpdateLauncherSlots(true, Conversions.ToInteger(HighSlot3.Image.Tag));
            }
            HighSlot3.Image = null;
            HighSlot3.ResetText();
            UpdateUpwellStructureStats();
        }

        private void HighSlot5_DoubleClick(object sender, EventArgs e)
        {
            if (!(HighSlot5.Image == null))
            {
                UpdateLauncherSlots(true, Conversions.ToInteger(HighSlot5.Image.Tag));
            }
            HighSlot5.Image = null;
            HighSlot5.ResetText();
            UpdateUpwellStructureStats();
        }

        private void HighSlot7_DoubleClick(object sender, EventArgs e)
        {
            if (!(HighSlot7.Image == null))
            {
                UpdateLauncherSlots(true, Conversions.ToInteger(HighSlot7.Image.Tag));
            }
            HighSlot7.Image = null;
            HighSlot7.ResetText();
            UpdateUpwellStructureStats();
        }

        private void HighSlot4_DoubleClick(object sender, EventArgs e)
        {
            if (!(HighSlot4.Image == null))
            {
                UpdateLauncherSlots(true, Conversions.ToInteger(HighSlot4.Image.Tag));
            }
            HighSlot4.Image = null;
            HighSlot4.ResetText();
            UpdateUpwellStructureStats();
        }

        private void HighSlot6_DoubleClick(object sender, EventArgs e)
        {
            if (!(HighSlot6.Image == null))
            {
                UpdateLauncherSlots(true, Conversions.ToInteger(HighSlot6.Image.Tag));
            }
            HighSlot6.Image = null;
            HighSlot6.ResetText();
            UpdateUpwellStructureStats();
        }

        private void HighSlot8_DoubleClick(object sender, EventArgs e)
        {
            if (!(HighSlot8.Image == null))
            {
                UpdateLauncherSlots(true, Conversions.ToInteger(HighSlot8.Image.Tag));
            }
            HighSlot8.Image = null;
            HighSlot8.ResetText();
            UpdateUpwellStructureStats();
        }

        private void RigSlot3_DoubleClick(object sender, EventArgs e)
        {
            RigSlot3.Image = null;
            RigSlot3.ResetText();
            UpdateUpwellStructureStats();
        }

        private void RigSlot2_DoubleClick(object sender, EventArgs e)
        {
            RigSlot2.Image = null;
            RigSlot2.ResetText();
            UpdateUpwellStructureStats();
        }

        private void RigSlot1_DoubleClick(object sender, EventArgs e)
        {
            RigSlot1.Image = null;
            RigSlot1.ResetText();
            UpdateUpwellStructureStats();
        }

        private void LowSlot1_DoubleClick(object sender, EventArgs e)
        {
            LowSlot1.Image = null;
            LowSlot1.ResetText();
            UpdateUpwellStructureStats();
        }

        private void LowSlot2_DoubleClick(object sender, EventArgs e)
        {
            LowSlot2.Image = null;
            LowSlot2.ResetText();
            UpdateUpwellStructureStats();
        }

        private void LowSlot3_DoubleClick(object sender, EventArgs e)
        {
            LowSlot3.Image = null;
            LowSlot3.ResetText();
            UpdateUpwellStructureStats();
        }

        private void LowSlot4_DoubleClick(object sender, EventArgs e)
        {
            LowSlot4.Image = null;
            LowSlot4.ResetText();
            UpdateUpwellStructureStats();
        }

        private void LowSlot5_DoubleClick(object sender, EventArgs e)
        {
            LowSlot5.Image = null;
            LowSlot5.ResetText();
            UpdateUpwellStructureStats();
        }

        private void LowSlot6_DoubleClick(object sender, EventArgs e)
        {
            LowSlot6.Image = null;
            LowSlot6.ResetText();
            UpdateUpwellStructureStats();
        }

        private void LowSlot7_DoubleClick(object sender, EventArgs e)
        {
            LowSlot7.Image = null;
            LowSlot7.ResetText();
            UpdateUpwellStructureStats();
        }

        private void LowSlot8_DoubleClick(object sender, EventArgs e)
        {
            LowSlot8.Image = null;
            LowSlot8.ResetText();
            UpdateUpwellStructureStats();
        }

        private void ServiceSlot5_DoubleClick(object sender, EventArgs e)
        {
            ServiceSlot5.Image = null;
            ServiceSlot5.ResetText();
            UpdateUpwellStructureStats();
        }

        private void ServiceSlot3_DoubleClick(object sender, EventArgs e)
        {
            ServiceSlot3.Image = null;
            ServiceSlot3.ResetText();
            UpdateUpwellStructureStats();
        }

        private void ServiceSlot1_DoubleClick(object sender, EventArgs e)
        {
            ServiceSlot1.Image = null;
            ServiceSlot1.ResetText();
            UpdateUpwellStructureStats();
        }

        private void ServiceSlot2_DoubleClick(object sender, EventArgs e)
        {
            ServiceSlot2.Image = null;
            ServiceSlot2.ResetText();
            UpdateUpwellStructureStats();
        }

        private void ServiceSlot4_DoubleClick(object sender, EventArgs e)
        {
            ServiceSlot4.Image = null;
            ServiceSlot4.ResetText();
            UpdateUpwellStructureStats();
        }

        private void ServiceSlot6_DoubleClick(object sender, EventArgs e)
        {
            ServiceSlot6.Image = null;
            ServiceSlot6.ResetText();
            UpdateUpwellStructureStats();
        }

        private void btnToggleAllPriceItems_Click(object sender, EventArgs e)
        {
            StripFitting();
        }

        private void chkIncludeFuelCosts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncludeFuelCosts.Checked)
            {
                gbIncludeFuelBlocks.Enabled = true;
            }
            else
            {
                gbIncludeFuelBlocks.Enabled = false;
            }
            UpdateFuelCostLabels();
        }

        private void btnItemFilter_Click(object sender, EventArgs e)
        {
            UpdateFittingImages();
        }

        private void btnResetItemFilter_Click(object sender, EventArgs e)
        {
            txtItemFilter.Text = "";
            UpdateFittingImages();
        }

        private void txtItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateFittingImages();
            }
        }

        private void ServiceModuleListView_ItemActivate(object sender, EventArgs e)
        {
            LoadSelectedImageInFreeSlot();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void chkHighSec_CheckedChanged(object sender, EventArgs e)
        {
            if (!UpdateChecks)
            {
                SetSpaceSecurityChecks(0);
                UpdateUpwellStructureBonuses();
            }
        }

        private void chkLowSec_CheckedChanged(object sender, EventArgs e)
        {
            if (!UpdateChecks)
            {
                SetSpaceSecurityChecks(1);
                UpdateUpwellStructureBonuses();
            }
        }

        private void chkNullSec_CheckedChanged(object sender, EventArgs e)
        {
            if (!UpdateChecks)
            {
                SetSpaceSecurityChecks(2);
                UpdateUpwellStructureBonuses();
            }
        }

        // Ensures one is at least checked
        private void SetSpaceSecurityChecks(int TriggerIndex)
        {
            int i;

            if (!FirstLoad)
            {
                // Adjust the checks depending on options
                var loopTo = SecurityCheckBoxes.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    UpdateChecks = true;
                    if (i != TriggerIndex)
                    {
                        SecurityCheckBoxes[i].Checked = false;
                    }
                    else if (i == TriggerIndex & SecurityCheckBoxes[i].Checked == false)
                    {
                        SecurityCheckBoxes[i].Checked = true; // Don't let them uncheck the value
                    }
                    UpdateChecks = false;
                }
            }
            // End If
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            UpwellStructureSettings TempSettings = default;
            var Settings = new ProgramSettings();

            TempSettings.HighSlotsCheck = chkItemViewTypeHigh.Checked;
            TempSettings.MediumSlotsCheck = chkItemViewTypeMedium.Checked;
            TempSettings.LowSlotsCheck = chkItemViewTypeLow.Checked;
            TempSettings.ServicesCheck = chkItemViewTypeServices.Checked;

            TempSettings.ReprocessingRigsCheck = chkRigTypeViewReprocessing.Checked;
            TempSettings.EngineeringRigsCheck = chkRigTypeViewEngineering.Checked;
            TempSettings.CombatRigsCheck = chkRigTypeViewCombat.Checked;
            TempSettings.ReactionsRigsCheck = chkRigTypeViewReaction.Checked;
            TempSettings.DrillingRigsCheck = chkRigTypeViewDrilling.Checked;

            TempSettings.SearchFilterText = txtItemFilter.Text;

            TempSettings.IncludeFuelCostsCheck = chkIncludeFuelCosts.Checked;

            if (rbtnHeliumFuelBlock.Checked)
            {
                TempSettings.FuelBlockType = rbtnHeliumFuelBlock.Text;
            }
            else if (rbtnHydrogenFuelBlock.Checked)
            {
                TempSettings.FuelBlockType = rbtnHydrogenFuelBlock.Text;
            }
            else if (rbtnNitrogenFuelBlock.Checked)
            {
                TempSettings.FuelBlockType = rbtnNitrogenFuelBlock.Text;
            }
            else if (rbtnOxygenFuelBlock.Checked)
            {
                TempSettings.FuelBlockType = rbtnOxygenFuelBlock.Text;
            }

            if (rbtnBuildBlocks.Checked)
            {
                TempSettings.BuyBuildBlockOption = rbtnBuildBlocks.Text;
            }
            else if (rbtnBuyBlocks.Checked)
            {
                TempSettings.BuyBuildBlockOption = rbtnBuyBlocks.Text;
            }

            if (rbtnListView.Checked)
            {
                TempSettings.IconListView = false;
            }
            else if (rbtnViewIcons.Checked)
            {
                TempSettings.IconListView = true;
            }


            TempSettings.SelectedStructureName = cmbUpwellStructureName.Text;

            // Save the data in the XML file
            Settings.SaveUpwellStructureViewerSettings(TempSettings);

            // Save the data to the local variable
            SettingsVariables.UserUpwellStructureSettings = TempSettings;

            Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);

        }

        private void rbtnHeliumFuelBlock_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFuelCostLabels();
        }

        private void rbtnHydrogenFuelBlock_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFuelCostLabels();
        }

        private void rbtnNitrogenFuelBlock_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFuelCostLabels();
        }

        private void rbtnOxygenFuelBlock_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFuelCostLabels();
        }

        private void rbtnBuyBlocks_CheckedChanged(object sender, EventArgs e)
        {

            txtNitrogenFuelBlockBuyPrice.Enabled = true;
            lblNitrogenFuelBlockBuy.Enabled = true;
            txtHydrogenFuelBlockBuyPrice.Enabled = true;
            lblHydrogenBlockBuy.Enabled = true;
            txtHeliumFuelBlockBuyPrice.Enabled = true;
            lblHeliumFuelBlockBuy.Enabled = true;
            txtOxygenFuelBlockBuyPrice.Enabled = true;
            lblOxygenFuelBlockBuy.Enabled = true;

            txtHeliumFuelBlockBPME.Enabled = false;
            lblHeliumFuelBlockBPME.Enabled = false;
            txtNitrogenFuelBlockBPME.Enabled = false;
            lblNitrogenFuelBlockBPME.Enabled = false;
            txtHydrogenFuelBlockBPME.Enabled = false;
            lblHydrogenFuelBlockBPME.Enabled = false;
            txtOxygenFuelBlockBPME.Enabled = false;
            lblOxygenFuelBlockBPME.Enabled = false;
            lblNitrogenFuelBlockBuildPrice.Enabled = false;
            lblOxygenFuelBlockBuildPrice.Enabled = false;
            lblHeliumFuelBlockBuild.Enabled = false;
            lblHydrogenFuelBlockBuildPrice.Enabled = false;
            lblNitrogenFuelBlockBuild.Enabled = false;
            lblOxygenFuelBlockBuild.Enabled = false;
            lblHeliumFuelBlockBuildPrice.Enabled = false;
            lblHydrogenFuelBlockBuild.Enabled = false;

            // Not building so disable prices
            gbFuelPrices.Enabled = false;

            // Disable the update build cost and save fuel block info buttons too
            btnUpdateBuildCost.Enabled = false;
            btnSaveFuelBlockInfo.Enabled = false;

        }

        private void rbtnBuildBlocks_CheckedChanged(object sender, EventArgs e)
        {

            txtNitrogenFuelBlockBuyPrice.Enabled = false;
            lblNitrogenFuelBlockBuy.Enabled = false;
            txtHydrogenFuelBlockBuyPrice.Enabled = false;
            lblHydrogenBlockBuy.Enabled = false;
            txtHeliumFuelBlockBuyPrice.Enabled = false;
            lblHeliumFuelBlockBuy.Enabled = false;
            txtOxygenFuelBlockBuyPrice.Enabled = false;
            lblOxygenFuelBlockBuy.Enabled = false;

            txtHeliumFuelBlockBPME.Enabled = true;
            lblHeliumFuelBlockBPME.Enabled = true;
            txtNitrogenFuelBlockBPME.Enabled = true;
            lblNitrogenFuelBlockBPME.Enabled = true;
            txtHydrogenFuelBlockBPME.Enabled = true;
            lblHydrogenFuelBlockBPME.Enabled = true;
            txtOxygenFuelBlockBPME.Enabled = true;
            lblOxygenFuelBlockBPME.Enabled = true;
            lblNitrogenFuelBlockBuildPrice.Enabled = true;
            lblOxygenFuelBlockBuildPrice.Enabled = true;
            lblHeliumFuelBlockBuild.Enabled = true;
            lblHydrogenFuelBlockBuildPrice.Enabled = true;
            lblNitrogenFuelBlockBuild.Enabled = true;
            lblOxygenFuelBlockBuild.Enabled = true;
            lblHeliumFuelBlockBuildPrice.Enabled = true;
            lblHydrogenFuelBlockBuild.Enabled = true;

            // Building so enable all prices
            gbFuelPrices.Enabled = true;

            // Building, so enable the update build cost and save fuel block info buttons
            btnUpdateBuildCost.Enabled = true;
            btnSaveFuelBlockInfo.Enabled = true;

        }

        private void ProcessKeyPress(ref KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedMETEChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void ProcessMaterialKeyDown(KeyEventArgs e, TextBox ProcessTextBox)
        {
            Public_Variables.ProcessCutCopyPasteSelect(ProcessTextBox, e);
            if (e.KeyCode == Keys.Enter)
            {
                // Set them all
                SetFuelBlockBuildcost(FuelBlocks.Helium);
                SetFuelBlockBuildcost(FuelBlocks.Hydrogen);
                SetFuelBlockBuildcost(FuelBlocks.Oxygen);
                SetFuelBlockBuildcost(FuelBlocks.Nitrogen);
            }
        }

        private void ProcessBlockBuyKeyDown(KeyEventArgs e, TextBox ProcessTextBox)
        {
            Public_Variables.ProcessCutCopyPasteSelect(ProcessTextBox, e);
            if (e.KeyCode == Keys.Enter)
            {
                UpdateFuelCostLabels();
            }
        }

        private void txtHeliumFuelBlockBPME_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtHeliumFuelBlockBPME, e);
            if (e.KeyCode == Keys.Enter)
            {
                SetFuelBlockBuildcost(FuelBlocks.Helium);
            }
        }

        private void txtHeliumFuelBlockBPME_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
            HeliumFuelBlockBPUpdated = true;
        }

        private void txtHeliumFuelBlockBPME_GotFocus(object sender, EventArgs e)
        {
            txtHeliumFuelBlockBPME.SelectAll();
        }

        private void txtHydrogenFuelBlockBPME_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtHydrogenFuelBlockBPME, e);
            if (e.KeyCode == Keys.Enter)
            {
                SetFuelBlockBuildcost(FuelBlocks.Hydrogen);
            }
        }

        private void txtHydrogenFuelBlockBPME_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
            HydrogenFuelBlockBPUpdated = true;
        }

        private void txtHydrogenFuelBlockBPME_GotFocus(object sender, EventArgs e)
        {
            txtHydrogenFuelBlockBPME.SelectAll();
        }

        private void txtNitrogenFuelBlockBPME_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtNitrogenFuelBlockBPME, e);
            if (e.KeyCode == Keys.Enter)
            {
                SetFuelBlockBuildcost(FuelBlocks.Nitrogen);
            }
        }

        private void txtNitrogenFuelBlockBPME_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
            NitrogenFuelBlockBPUpdated = true;
        }

        private void txtNitrogenFuelBlockBPME_GotFocus(object sender, EventArgs e)
        {
            txtNitrogenFuelBlockBPME.SelectAll();
        }

        private void txtOxygenFuelBlockBPME_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtOxygenFuelBlockBPME, e);
            if (e.KeyCode == Keys.Enter)
            {
                SetFuelBlockBuildcost(FuelBlocks.Oxygen);
            }
        }

        private void txtOxygenFuelBlockBPME_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
            OxygenFuelBlockBPUpdated = true;
        }

        private void txtOxygenFuelBlockBPME_GotFocus(object sender, EventArgs e)
        {
            txtOxygenFuelBlockBPME.SelectAll();
        }

        private void txtHeliumFuelBlockBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessBlockBuyKeyDown(e, txtHeliumFuelBlockBuyPrice);
        }

        private void txtHeliumFuelBlockBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtHeliumFuelBlockBuyPrice_GotFocus(object sender, EventArgs e)
        {
            txtHeliumFuelBlockBuyPrice.SelectAll();
        }

        private void txtHydrogenFuelBlockBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessBlockBuyKeyDown(e, txtHydrogenFuelBlockBuyPrice);
        }

        private void txtHydrogenFuelBlockBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtHydrogenFuelBlockBuyPrice_GotFocus(object sender, EventArgs e)
        {
            txtHydrogenFuelBlockBuyPrice.SelectAll();
        }

        private void txtNitrogenFuelBlockBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessBlockBuyKeyDown(e, txtNitrogenFuelBlockBuyPrice);
        }

        private void txtNitrogenFuelBlockBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtNitrogenFuelBlockBuyPrice_GotFocus(object sender, EventArgs e)
        {
            txtNitrogenFuelBlockBuyPrice.SelectAll();
        }

        private void txtOxygenFuelBlockBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessBlockBuyKeyDown(e, txtOxygenFuelBlockBuyPrice);
        }

        private void txtOxygenFuelBlockBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtOxygenFuelBlockBuyPrice_GotFocus(object sender, EventArgs e)
        {
            txtOxygenFuelBlockBuyPrice.SelectAll();
        }

        private void txtHeliumIsotopes_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtHeliumIsotopes);
        }

        private void txtHeliumIsotopes_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtHeliumIsotopes_GotFocus(object sender, EventArgs e)
        {
            txtHeliumIsotopes.SelectAll();
        }

        private void txtHydrogenIsotopes_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtHydrogenIsotopes);
        }

        private void txtHydrogenIsotopes_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtHydrogenIsotopes_GotFocus(object sender, EventArgs e)
        {
            txtHydrogenIsotopes.SelectAll();
        }

        private void txtHeavyWater_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtHeavyWater);
        }

        private void txtHeavyWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtHeavyWater_GotFocus(object sender, EventArgs e)
        {
            txtHeavyWater.SelectAll();
        }

        private void txtNitrogenIsotopes_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtNitrogenIsotopes);
        }

        private void txtNitrogenIsotopes_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtNitrogenIsotopes_GotFocus(object sender, EventArgs e)
        {
            txtNitrogenIsotopes.SelectAll();
        }

        private void txtOxygenIsotopes_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtOxygenIsotopes);
        }

        private void txtOxygenIsotopes_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtOxygenIsotopes_GotFocus(object sender, EventArgs e)
        {
            txtOxygenIsotopes.SelectAll();
        }

        private void txtStrontiumClathrates_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtStrontiumClathrates);
        }

        private void txtStrontiumClathrates_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtStrontiumClathrates_GotFocus(object sender, EventArgs e)
        {
            txtStrontiumClathrates.SelectAll();
        }

        private void txtMechanicalParts_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtMechanicalParts);
        }

        private void txtMechanicalParts_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtMechanicalParts_GotFocus(object sender, EventArgs e)
        {
            txtMechanicalParts.SelectAll();
        }

        private void txtRobotics_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtRobotics);
        }

        private void txtRobotics_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtRobotics_GotFocus(object sender, EventArgs e)
        {
            txtRobotics.SelectAll();
        }

        private void txtCoolant_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtCoolant);
        }

        private void txtCoolant_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtCoolant_GotFocus(object sender, EventArgs e)
        {
            txtCoolant.SelectAll();
        }

        private void txtEnrichedUranium_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtEnrichedUranium);
        }

        private void txtEnrichedUranium_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtEnrichedUranium_GotFocus(object sender, EventArgs e)
        {
            txtEnrichedUranium.SelectAll();
        }

        private void txtOxygen_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtOxygen);
        }

        private void txtOxygen_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtOxygen_GotFocus(object sender, EventArgs e)
        {
            txtOxygen.SelectAll();
        }

        private void txtLiquidOzone_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessMaterialKeyDown(e, txtLiquidOzone);
        }

        private void txtLiquidOzone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessKeyPress(ref e);
        }

        private void txtLiquidOzone_GotFocus(object sender, EventArgs e)
        {
            txtLiquidOzone.SelectAll();
        }

        private void ShowToolTipForModule(ref object SentSender)
        {
            PictureBox SO;
            SO = (PictureBox)SentSender;
            if (!string.IsNullOrEmpty(SO.Text))
            {
                MainToolTip.SetToolTip(SO, SO.Text);
            }
        }

        private void RigSlot1_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void RigSlot2_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void RigSlot3_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void MidSlot1_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void MidSlot2_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void MidSlot3_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void MidSlot4_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void MidSlot5_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void MidSlot6_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void MidSlot7_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void MidSlot8_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void ServiceSlot5_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void ServiceSlot3_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void ServiceSlot1_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void ServiceSlot2_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void ServiceSlot4_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void ServiceSlot6_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void LowSlot8_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void LowSlot7_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void LowSlot6_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void LowSlot5_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void LowSlot4_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void LowSlot3_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void LowSlot2_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void LowSlot1_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void HighSlot7_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void HighSlot8_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void HighSlot5_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void HighSlot3_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void HighSlot1_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void HighSlot2_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void HighSlot4_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void HighSlot6_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipForModule(ref sender);
        }

        private void lstUpwellStructureBonuses_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstUpwellStructureBonuses;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref ColumnClicked, ref ColumnSortType);
        }

        private void FittingListViewDetails_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView argRefListView = FittingListViewDetails;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref ModulesColumnClicked, ref ModulesColumnSortType);
        }

        private void rbtnListView_CheckedChanged(object sender, EventArgs e)
        {
            DisplayListView();
        }

        private void rbtnViewIcons_CheckedChanged(object sender, EventArgs e)
        {
            DisplayListView();
        }

        private void DisplayListView()
        {
            if (rbtnViewIcons.Checked)
            {
                FittingListViewIcons.Visible = true;
                FittingListViewDetails.Visible = false;
            }
            else
            {
                FittingListViewIcons.Visible = false;
                FittingListViewDetails.Visible = true;
            }
        }

        #endregion

    }

    public enum Services
    {
        StandupBiochemicalReactor = 45539, // Boosters
        StandupCompositeReactor = 45537, // Moon mats
        StandupHybridReactor = 45538, // T3 mats
        StandupManufacturingPlant = 35878,
        StandupCapitalShipyard = 35881,
        StandupSupercapitalShipyard = 35877,

        StandupInventionLab = 35886, // Invention
        StandupResearchLab = 35891, // Copying, ME/TE research
        StandupHyasyodaResearchLab = 45550, // Copying, ME/TE research
        StandupReprocessingFaclity = 35899
    }
}