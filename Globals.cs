using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    // Place to store all public variables and functions
    public static class Public_Variables
    {
        // DB name and version
        public const string SDEVersion = "March 12, 2024 Release";
        public const string VersionNumber = "5.0.*";

        public static bool TestingVersion; // This flag will test the test downloads from the server for an update
        public static bool Developer; // This is if I'm developing something and only want me to see it instead of public release

        public static CultureInfo LocalCulture;

        public static DBConnection EVEDB;
        public static SQLiteCommand DBCommand;
        // For checking the DB to see if it's ok to write
        public static object DBLock = new object();

        public static Character SelectedCharacter = new Character();
        public static Blueprint SelectedBlueprint;

        public const string DummyClient = "";
        public const int DefaultCharacterCode = -1; // To indicate the default character
        public const long DummyCharacterID = -1L;
        public const long DummyCorporationID = -1L;

        public const int CommonSavedFacilitiesID = -2;
        public const int CommonLoadBPsID = -2;

        // Variable to hold error tracking data when the error is hard to find - used for debugging only but mostly this is set to empty string
        public static string ErrorTracker;
        public static ESIErrorProcessor ESIErrorHandler;

        public static bool DefaultCharSelected;
        public static bool FirstLoad; // If the program just opened
        public static bool SkillsUpdated; // To track if skills where updated in the skill override screen
        public static bool ManufacturingTabColumnsChanged; // To track if thy changed columns

        // File Paths
        public static string DynamicFilePath = ""; // Where the update and settings files are stored that we can write, create, delete, etc.
        public static string DBFilePath = ""; // Where the DB is stored for updates

        public const string PatchNotesURL = "https://raw.githubusercontent.com/EVEIPH/LatestFiles/master/Patch%20Notes.txt";
        public const string XMLUpdateFileURL = "https://raw.githubusercontent.com/EVEIPH/LatestFiles/master/LatestVersionIPH.xml";
        public const string XMLUpdateTestFileURL = "https://github.com/EVEIPH/LatestFiles/raw/master/LatestVersionIPH_Test.xml";

        public const string DynamicAppDataPath = "EVE IPH";
        public const string UserImagePath = "EVEIPH Images";
        public const string UpdatePath = "EVE IPH Updates";
        public const string SettingsFolder = "Settings"; // For saving all settings

        public const string SQLiteDBFileName = "EVEIPH DB.sqlite";

        public static List<string> ReactionTypes = new List<string>(new string[] { "Composite", "Intermediate Materials", "Hybrid Polymers" });

        // For updates
        public const string UpdaterFileName = "EVEIPH Updater.exe";
        public const string SQLiteDLLUpdater = "EVEIPH SQLite DLL Updater.exe";
        public const string XMLUpdaterFileName = "EVEIPH_Updater.exe"; // For use in the XML files to remove spaces from row names
        public const string XMLLatestVersionFileName = "LatestVersionIPH.xml";
        public const string XMLLatestVersionTest = "LatestVersionIPH Test.xml";

        // Only request ESI scopes I need - if I add a scope, the user will need to re-authorize for the new scopes.
        public static string ESIScopesString = "";

        public const long TheForgeTypeID = 10000002L;
        public const string JitaPerimeter = "Jita/Perimeter";

        public const string USER_BLUEPRINTS = "(SELECT ALL_BLUEPRINTS.BLUEPRINT_ID AS BP_ID, ALL_BLUEPRINTS.BLUEPRINT_GROUP, ALL_BLUEPRINTS.BLUEPRINT_NAME, " + "ITEM_GROUP_ID, ITEM_GROUP, ITEM_CATEGORY_ID, CASE WHEN ITEM_GROUP LIKE 'Rig%' THEN 'Rig' ELSE ITEM_CATEGORY END AS ITEM_CATEGORY, " + "ALL_BLUEPRINTS.ITEM_ID, ITEM_NAME," + "CASE WHEN OBP.ME IS NOT NULL THEN OBP.ME ELSE 0 END AS ME," + "CASE WHEN OBP.TE IS NOT NULL THEN OBP.TE ELSE 0 END AS TE," + "CASE WHEN USER_ID IS NOT NULL THEN USER_ID ELSE 0 END AS USER_ID, ITEM_TYPE," + "CASE WHEN ALL_BLUEPRINTS.RACE_ID IS NOT NULL THEN ALL_BLUEPRINTS.RACE_ID ELSE 0 END AS RACE_ID," + "CASE WHEN OBP.OWNED IS NOT NULL THEN OBP.OWNED ELSE 0 END AS OWNED," + "CASE WHEN OBP.SCANNED IS NOT NULL THEN OBP.SCANNED ELSE 0 END AS SCANNED," + "CASE WHEN OBP.BP_TYPE IS NOT NULL THEN OBP.BP_TYPE ELSE 0 END AS BP_TYPE," + "CASE WHEN OBP.ITEM_ID IS NOT NULL THEN OBP.ITEM_ID ELSE 0 END AS UNIQUE_BP_ITEM_ID, " + "CASE WHEN OBP.FAVORITE IS NOT NULL THEN OBP.FAVORITE " + "ELSE CASE WHEN ALL_BLUEPRINTS.FAVORITE IS NOT NULL THEN ALL_BLUEPRINTS.FAVORITE ELSE 0 END END AS FAVORITE, " + "IT.VOLUME, IT.MARKETGROUPID, " + "CASE WHEN OBP.ADDITIONAL_COSTS IS NOT NULL THEN OBP.ADDITIONAL_COSTS ELSE 0 END AS ADDITIONAL_COSTS, " + "CASE WHEN OBP.LOCATION_ID IS NOT NULL THEN OBP.LOCATION_ID ELSE 0 END AS LOCATION_ID, " + "CASE WHEN OBP.QUANTITY IS NOT NULL THEN OBP.QUANTITY ELSE 0 END AS QUANTITY, " + "CASE WHEN OBP.FLAG_ID IS NOT NULL THEN OBP.FLAG_ID ELSE 0 END AS FLAG_ID, " + "CASE WHEN OBP.RUNS IS NOT NULL THEN OBP.RUNS ELSE 0 END AS RUNS, " + "IGNORE, ALL_BLUEPRINTS.TECH_LEVEL, SIZE_GROUP, " + "CASE WHEN IT2.MARKETGROUPID IS NULL THEN 0 ELSE 1 END AS NPC_BPO " + "FROM ALL_BLUEPRINTS LEFT OUTER JOIN " + "(SELECT * FROM OWNED_BLUEPRINTS) AS OBP " + "ON ALL_BLUEPRINTS.BLUEPRINT_ID = OBP.BLUEPRINT_ID " + "AND (OBP.USER_ID = @USERBP_USERID OR OBP.USER_ID = @USERBP_CORPID), " + "INVENTORY_TYPES AS IT, INVENTORY_TYPES AS IT2 " + "WHERE ALL_BLUEPRINTS.ITEM_ID = IT.TYPEID AND ALL_BLUEPRINTS.BLUEPRINT_ID = IT2.TYPEID) AS X ";



























        // Shopping List
        public static ShoppingList TotalShoppingList = new ShoppingList();

        // For a new shopping list, so we can upate it when it's open
        public static frmShoppingList frmShop = new frmShoppingList();
        public static frmConversiontoOreSettings frmConversionOptions;
        public static string CopyPasteRefineryMaterialText;

        // Same with assets
        public static frmAssetsViewer frmDefaultAssets;
        public static frmAssetsViewer frmShoppingAssets;
        public static frmAssetsViewer frmRefineryAssets;
        public static frmViewSavedStructures frmViewStructures = new frmViewSavedStructures();
        public static frmReprocessingPlant frmRepoPlant;

        // The only allowed characters for text entry
        public const string allowedPriceChars = "0123456789.,";
        public const string allowedMETEChars = "0123456789.";
        public const string allowedRunschars = "0123456789";
        public const string allowedDecimalChars = "0123456789.-";
        public const string allowedPercentChars = "0123456789.%";
        public const string allowedNegativePercentChars = "0123456789.%-";

        public const string SQLiteDateFormat = "yyyy-MM-dd HH:mm:ss";

        public static DateTime IndustryNoCompletedDate = DateTime.Parse("2001-01-01");

        public const double DataCoreRedeemCost = 10000.0d;

        public static bool FirstIndustryJobsViewerLoad;

        public const int SpaceFlagCode = 500;

        // For update prices, to cancel update
        public static bool CancelUpdatePrices;
        public static bool CancelManufacturingTabCalc;
        public static bool CancelThreading;

        // Column processing
        public const int NumManufacturingTabColumns = 110;
        public const int NumIndustryJobColumns = 21;

        public const double BaseRefineRate = 0.5d;

        public static DateTime NoDate = DateTime.Parse("1900-01-01");
        public static DateTime NoExpiry = DateTime.Parse("2200-01-01");

        // For T3 Relics
        public const string IntactRelic = "Intact";
        public const string MalfunctioningRelic = "Malfunctioning";
        public const string WreckedRelic = "Wrecked";

        public const int MineralGroupID = 18;

        // T2 BPC base ME/TE
        public const int BaseT2T3ME = 2;
        public const int BaseT2T3TE = 4;

        // For industry tab loading
        public const string BPTab = "BP";
        public const string CalcTab = "Calc";

        // For update prices
        public const string DefaultSystemPriceCombo = "Select System";
        public const string DefaultRegionPriceCombo = "Select Region";

        public const string AllSystems = "All Systems";

        // For unhandled exceptions
        public static string frmErrorText = "";
        public static string ErrorTest = "";

        public static int PriceQueryCount; // This will track the number of times the user queries EVE Central - used to warn them for over pinging
        public static bool CalcHistoryRegionLoaded;
        public static bool ShownPriceUpdateError; // Only want to show them the error once

        public const string BPO = "BPO";
        public const string BPC = "BPC";
        public const string InventedBPC = "Invented BPC";
        public const string UnownedBP = "Unowned";

        public const string Yes = "Yes";
        public const string No = "No";
        public const string Unknown = "Unknown";
        public const string Unlimited = "Unlimited";
        public const string Male = "male";

        public static IndustryFacility NoFacility = new IndustryFacility();

        public const string None = "None"; // For decryptors and facilities

        public static List<string> MiningUpgradesCollection = new List<string>();

        public static bool CancelESISSOLogin;

        public static List<long> NoPOSCategoryIDs; // For facilities

        // Mining Ship Name constants
        public const string Procurer = "Procurer";
        public const string Retriever = "Retriever";
        public const string Covetor = "Covetor";
        public const string Skiff = "Skiff";
        public const string Mackinaw = "Mackinaw";
        public const string Hulk = "Hulk";
        public const string Venture = "Venture";
        public const string Prospect = "Prospect";
        public const string Endurance = "Endurance";
        public const string Rorqual = "Rorqual";
        public const string Porpoise = "Porpoise";
        public const string Orca = "Orca";
        public const string Drake = "Drake";
        public const string Gnosis = "Gnosis";
        public const string Rokh = "Rokh";

        // For exporting Data
        public const string DefaultTextDataExport = "Default";
        public const string CSVDataExport = "CSV";
        public const string SSVDataExport = "SSV";
        public const string MultiBuyDataExport = "Multibuy";

        public static bool SetTaxFeeChecks;
        public static List<long> LocationIDs = new List<long>();

        public static long MaxStationID = 67000000L;
        public static long MinStationID = 60000000L;

        // Opened forms from menu
        public static bool ReprocessingPlantOpen;
        public static bool OreBeltFlipOpen;
        public static bool IceBeltFlipOpen;

        // Limits for Market History endpoint
        public const int MaxMarketHistoryCallsPerMinute = 300;
        public static int MarketHistoryCallsPerMinute = 0;
        public static DateTime LastMarketHistoryUpdate = NoDate;

        public static bool PriceUpdateDown = false;

        // For scanning assets
        public enum ScanType
        {
            Personal = 0,
            Corporation = 1
        }

        // BP Types: -1 is original, -2 is copy from API, others are built for IPH
        public enum BPType
        {
            NotOwned = 0,
            // These are assumed owned, since they are marked or loaded from API
            Original = -1,
            Copy = -2,
            InventedBPC = -3
        }

        // For scanning assets
        public enum SkillType
        {
            BPReqSkills = 1,
            BPComponentSkills = 2,
            REReqSkills = 3,
            InventionReqSkills = 4
        }

        public enum MaterialType
        {
            BaseMats = 0,
            ExtraMats = 1
        }

        public enum BPTechLevel
        {
            T1 = 1,
            T2 = 2,
            T3 = 3
        }

        public enum BeltType
        {
            Small = 1,
            Medium = 2,
            Large = 3,
            Enormous = 4,
            Colossal = 5
        }

        public enum ItemSize
        {
            Small = 1,
            Medium = 2,
            Large = 3,
            ExtraLarge = 4
        }

        public enum SentFromLocation
        {
            None = 0,
            BlueprintTab = 1,
            ManufacturingTab = 2,
            History = 3,
            ShoppingList = 4
        }

        public enum CopyPasteWindowType
        {
            Materials = 1,
            Blueprints = 2
        }

        public enum CopyPasteWindowLocation
        {
            Assets = 1,
            RefineMaterials = 2
        }

        // To play ding sound without box
        public static void PlayNotifySound()
        {
            if (!SettingsVariables.UserApplicationSettings.DisableSound)
            {
                My.MyProject.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk);
            }
        }

        public class LocationInfo
        {
            public long AccountID;
            public long LocationID;
            public int FlagID; // ID in the INVENTORY_FLAGS Table
        }

        // For error processing
        public struct MyError
        {
            public string Description;
            public int Number;
        }

        public struct BrokerFeeInfo
        {
            public BrokerFeeType IncludeFee;
            public double FixedRate;
        }

        public enum BrokerFeeType
        {
            NoFee = 0,
            Fee = 1,
            SpecialFee = 2
        }

        // For importing blueprints via cut/paste
        public struct CopyPasteBlueprint
        {
            public string Name;
            public long Quantity;
            public string Group;
            public string Category;
            public bool Copy;
            public int ML;
            public int PL;
            public int Runs;
        }

        // For shopping list
        public struct ItemBuyType
        {
            public string ItemName;
            public string BuyType;
        }

        // For updating the splash screen with what is going on
        private delegate void ProgressSetter(string progress);

        public static void SetProgress(string progress)
        {
            // Get a reference to the application's splash screen.
            SplashScreen splash = (SplashScreen)My.MyProject.Application.SplashScreen;

            // Invoke the splach screen's SetProgress method on the thread that owns it.
            splash.Invoke(new ProgressSetter(splash.SetProgress), progress);
        }

        // Takes a string value percent and returns a double
        public static double CpctD(string PercentValue)
        {
            string PercentNumber = PercentValue.Replace("%", "");

            if (Information.IsNumeric(PercentNumber) & !PercentNumber.Contains("E"))
            {
                return Conversions.ToDouble(PercentNumber) / 100d;
            }
            else
            {
                return 0d;
            }

        }

        public struct BuildBuyItem
        {
            public long ItemID;
            public bool BuildItem; // True, we build it regardless, False we do not regardless. If not in list, we don't do anything differently
        }

        // Returns the ReactionGroupID number if sent is a reaction, else -1
        public static int ReactionGroupID(int CheckID)
        {
            switch (CheckID)
            {
                case (int)ItemIDs.ReactionBiochemicalsGroupID:
                case (int)ItemIDs.ReactionCompositesGroupID:
                case (int)ItemIDs.ReactionPolymersGroupID:
                case (int)ItemIDs.ReactionsIntermediateGroupID:
                case (int)ItemIDs.ReactionMolecularForgedGroupID:
                    {
                        return CheckID;
                    }

                default:
                    {
                        return -1;
                    }
            }
        }

        public static bool IsReaction(int ItemGroupID)
        {
            if (ReactionGroupID(ItemGroupID) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public enum ItemIDs
        {
            None = 0,

            // These are all the capital ships that use capital parts
            CapitalIndustrialShipGroupID = 883,
            CarrierGroupID = 547,
            DreadnoughtGroupID = 485,
            FreighterGroupID = 513,
            IndustrialCommandShipGroupID = 941,
            JumpFreighterGroupID = 902,
            SupercarrierGroupID = 659,
            FAXGroupID = 1538,
            TitanGroupID = 30,
            BoosterGroupID = 303,
            BoosterCategoryID = 20,

            // T3 items
            StrategicCruiserGroupID = 963,
            TacticalDestroyerGroupID = 1305,
            SubsystemCategoryID = 32,

            // T3 Bps for facility updates
            StrategicCruiserBPGroupID = 996,
            TacticalDestroyerBPGroupID = 1309,
            SubsystemBPGroupID = 973,

            ShipCategoryID = 6, // for loading invention and copying and basic t1
            FrigateGroupID = 25,

            // Reactions
            ReactionsIntermediateGroupID = 428,
            ReactionCompositesGroupID = 429,
            ReactionPolymersGroupID = 974,
            ReactionBiochemicalsGroupID = 712,
            ReactionMolecularForgedGroupID = 4096,

            ConstructionComponentsGroupID = 334, // Use this for all non-capital components
            ComponentCategoryID = 17,
            CapitalComponentGroupID = 873,
            AdvCapitalComponentGroupID = 913,
            ProtectiveComponentGroupID = -3, // My manual group ID until they fix it in the SDE

            BlueprintCategoryID = 9,
            FrigateBlueprintGroupID = 105,

            AsteroidsCategoryID = 25, // category for asteroids,ice,moons = 25
                                      // Ice group id = 465
            IceGroupID = 465,

            // Groupids for moon ores - 1884, 1920, 1921, 1922, 1923
            CommonMoonAsteroids = 1920,
            ExceptionalMoonAsteroids = 1923,
            RareMoonAsteroids = 1922,
            UbiquitousMoonAsteroids = 1884,
            UncommonMoonAsteroids = 1921,

            // Groupid's for asteroid types - regular ore
            Arkonor = 450,
            Bistot = 451,
            Crokite = 452,
            DarkOchre = 453,
            Gneiss = 467,
            Hedbergite = 454,
            Hemorphite = 455,
            Jaspet = 456,
            Kernite = 457,
            Mercoxit = 468,
            Omber = 469,
            Plagioclase = 458,
            Pyroxeres = 459,
            Scordite = 460,
            Spodumain = 461,
            Veldspar = 462

        }

        #region Taxes/Fees

        public static double AdjustPriceforTaxesandFees(double OriginalPrice, bool SetTax, BrokerFeeInfo BrokerFeeData)
        {
            if (OriginalPrice <= 0d)
            {
                return 0d;
            }

            double NewPrice = 0d;

            // Apply taxes and fees
            if (SetTax)
            {
                NewPrice = OriginalPrice - GetSalesTax(OriginalPrice) - GetSalesBrokerFee(OriginalPrice, BrokerFeeData);
            }
            else
            {
                NewPrice = OriginalPrice - GetSalesBrokerFee(OriginalPrice, BrokerFeeData);
            }

            return NewPrice;

        }

        // Returns the tax on an item price only
        public static double GetSalesTax(double ItemMarketCost)
        {
            int Accounting = SelectedCharacter.Skills.GetSkillLevel(16622L);
            // Each level of accounting reduces tax by 11%, Max/Base Sales Tax: 8%, Min Sales Tax: 3.6%
            // Latest info: https://www.eveonline.com/news/view/restructuring-taxes-after-relief
            return (SettingsVariables.UserApplicationSettings.BaseSalesTaxRate - Accounting * 0.11d * SettingsVariables.UserApplicationSettings.BaseSalesTaxRate) / 100d * ItemMarketCost;
        }

        // Returns the tax on setting up a sell order for an item price only
        public static double GetSalesBrokerFee(double ItemMarketCost, BrokerFeeInfo BrokerFee)
        {
            int BrokerRelations = SelectedCharacter.Skills.GetSkillLevel(3446L);
            double TempFee;

            if (BrokerFee.IncludeFee == BrokerFeeType.Fee)
            {
                // 3%-(0.3%*BrokerRelationsLevel)-(0.03%*FactionStanding)-(0.02%*CorpStanding) - uses unmodified standings
                // Base broker fee = 3%, Min broker fees: 1.0%
                // Latest info: https://www.eveonline.com/news/view/restructuring-taxes-after-relief
                // and https://www.eveonline.com/de/news/view/viridian-expansion-notes
                double BrokerTax = SettingsVariables.UserApplicationSettings.BaseBrokerFeeRate - 0.3d * BrokerRelations - 0.03d * SettingsVariables.UserApplicationSettings.BrokerFactionStanding - 0.02d * SettingsVariables.UserApplicationSettings.BrokerCorpStanding;
                TempFee = BrokerTax / 100d * ItemMarketCost;
            }
            else if (BrokerFee.IncludeFee == BrokerFeeType.SpecialFee)
            {
                // use a flat rate to set the fee - Since they are setting this, assume they are in an Upwell and add in the SCC fixed rate fee added in Viridian
                TempFee = BrokerFee.FixedRate * ItemMarketCost + SettingsVariables.UserApplicationSettings.SCCBrokerFeeSurcharge * ItemMarketCost;
            }
            else
            {
                return 0d;
            }

            if (TempFee < 100d)
            {
                return 100d;
            }
            else
            {
                return TempFee;
            }

        }

        // Get Broker Fee data
        public static BrokerFeeInfo GetBrokerFeeData(CheckBox BrokerCheck, TextBox SpecialRateBox)
        {
            var TempBF = default(BrokerFeeInfo);
            if (BrokerCheck.CheckState == CheckState.Indeterminate)
            {
                // Get the special fee
                TempBF.FixedRate = FormatManualPercentEntry(SpecialRateBox.Text);
                TempBF.IncludeFee = BrokerFeeType.SpecialFee;
            }
            else if (BrokerCheck.CheckState == CheckState.Checked)
            {
                TempBF.IncludeFee = BrokerFeeType.Fee;
            }
            else
            {
                TempBF.IncludeFee = BrokerFeeType.NoFee;
            }

            return TempBF;

        }

        #endregion

        #region Character Loading

        // Loads the character for the program
        public static void LoadCharacter(bool RefreshAssets, bool RefreshBPs)
        {
            if (!SelectedCharacter.LoadDefaultCharacter(RefreshBPs, RefreshAssets))
            {

                // Didn't find a default character. Either we don't have one selected or there are no characters in the DB yet
                var CMDCount = new SQLiteCommand("SELECT COUNT(*) FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> " + DummyCharacterID.ToString(), EVEDB.DBREf());

                if (Conversions.ToInteger(CMDCount.ExecuteScalar()) == 0)
                {
                    // No characters loaded yet so load dummy for all
                    SelectedCharacter.LoadDummyCharacter(true);
                }
                else
                {
                    // Have a set of chars, need to set a default, open that form
                    var f2 = new frmSetCharacterDefault();
                    f2.ShowDialog();
                }
            }

        }

        // Loads a default character from name sent
        public static void LoadCharacter(string CharacterName, bool PlaySound = true)
        {

            // Load only if a new character
            if ((SelectedCharacter.Name ?? "") != (CharacterName ?? ""))
            {
                // Update them all to 0 first
                EVEDB.ExecuteNonQuerySQL("UPDATE ESI_CHARACTER_DATA SET IS_DEFAULT = 0");
                EVEDB.ExecuteNonQuerySQL("UPDATE ESI_CHARACTER_DATA SET IS_DEFAULT = " + DefaultCharacterCode.ToString() + " WHERE CHARACTER_NAME = '" + FormatDBString(CharacterName) + "'");

                // Load the character as default for program and reload additional API data
                SelectedCharacter.LoadDefaultCharacter(SettingsVariables.UserApplicationSettings.LoadAssetsonStartup, SettingsVariables.UserApplicationSettings.LoadBPsonStartup);
                if (PlaySound)
                {
                    PlayNotifySound();
                }
            }

        }

        #endregion

        #region Time Functions

        // Converts a time in d h m s to a long of seconds - 3d 12h 2m 33s or 1 Day 12:23:33
        public static long ConvertDHMSTimetoSeconds(string SentTime)
        {
            long Days = 0L;
            int Hours = 0;
            int Minutes = 0;
            int Seconds = 0;

            string StringMarker = "";

            SentTime = Strings.Trim(SentTime);

            if (SentTime.Contains("Day ") | SentTime.Contains("Days ") | SentTime.Contains(":"))
            {
                // Time in 2 Days 12:23:05 format
                if (SentTime.Contains("Days"))
                {
                    StringMarker = "Days ";
                }
                else if (SentTime.Contains("Day"))
                {
                    StringMarker = "Day ";
                }
                else
                {
                    StringMarker = "";
                }

                if (!string.IsNullOrEmpty(StringMarker))
                {
                    // Get the days
                    Days = Conversions.ToInteger(SentTime.Substring(0, SentTime.IndexOf(StringMarker)));
                    // Reset the string
                    SentTime = Strings.Trim(SentTime.Substring(SentTime.IndexOf(StringMarker) + Strings.Len(StringMarker)));
                }

                // Now parse the times
                Hours = Conversions.ToInteger(SentTime.Substring(0, SentTime.IndexOf(":")));
                SentTime = Strings.Trim(SentTime.Substring(SentTime.IndexOf(":") + 1));
                Minutes = Conversions.ToInteger(SentTime.Substring(0, SentTime.IndexOf(":")));
                SentTime = Strings.Trim(SentTime.Substring(SentTime.IndexOf(":") + 1));
                Seconds = Conversions.ToInteger(SentTime);
            }
            else
            {

                if (SentTime.Contains("d "))
                {
                    StringMarker = "d ";

                    // Get the days
                    Days = Conversions.ToInteger(SentTime.Substring(0, SentTime.IndexOf(StringMarker)));
                    // Reset the string
                    SentTime = Strings.Trim(SentTime.Substring(SentTime.IndexOf(StringMarker) + Strings.Len(StringMarker)));
                }

                if (SentTime.Contains("h "))
                {
                    // Get the days
                    Hours = Conversions.ToInteger(SentTime.Substring(0, SentTime.IndexOf("h")));
                    // Reset the string
                    SentTime = Strings.Trim(SentTime.Substring(SentTime.IndexOf("h") + 1));
                }

                if (SentTime.Contains("m "))
                {
                    // Get the days
                    Minutes = Conversions.ToInteger(SentTime.Substring(0, SentTime.IndexOf("m")));
                    // Reset the string
                    SentTime = Strings.Trim(SentTime.Substring(SentTime.IndexOf("m") + 1));
                }

                if (SentTime.Contains("s"))
                {
                    // Get the days
                    Seconds = Conversions.ToInteger(SentTime.Substring(0, SentTime.IndexOf("s")));
                }
            }

            return Days * 24L * 60L * 60L + Hours * 60 * 60 + Minutes * 60 + Seconds;

        }

        // Formats seconds into a time for display with days, hours, min, sec
        public static string FormatTimeToComplete(long TimeinSeconds)
        {
            string FinalTime = "";
            long Days;
            long Hours;
            long Minutes;
            long Seconds;

            Seconds = TimeinSeconds;
            Days = (long)Math.Round(Math.Floor(Seconds / (double)(24 * 60 * 60)));
            Seconds = Seconds - Days * 24L * 60L * 60L;
            Hours = (long)Math.Round(Math.Floor(Seconds / (double)(60 * 60)));
            Seconds = Seconds - Hours * 60L * 60L;
            Minutes = (long)Math.Round(Math.Floor(Seconds / 60d));
            Seconds = Seconds - Minutes * 60L;

            if (Days != 0L)
            {
                FinalTime = Days.ToString() + "d " + Hours.ToString() + "h " + Minutes.ToString() + "m " + Seconds.ToString() + "s";
            }
            else if (Days == 0L & Hours != 0L)
            {
                FinalTime = Hours.ToString() + "h " + Minutes.ToString() + "m " + Seconds.ToString() + "s";
            }
            else if (Days == 0L & Hours == 0L & Minutes != 0L)
            {
                FinalTime = Minutes.ToString() + "m " + Seconds.ToString() + "s";
            }
            else if (Days == 0L & Hours == 0L & Minutes == 0L & Seconds != 0L)
            {
                FinalTime = Seconds.ToString() + "s";
            }

            return FinalTime;

        }

        // Takes a time in seconds and converts it to a string display of Days HH:MM:SS
        public static string FormatIPHTime(double SentTimeString)
        {
            long Seconds;
            int Minutes;
            int Hours;
            int Days;
            string TimeString = "";

            Seconds = (long)Math.Round(SentTimeString);

            // Calcuate Days
            Days = (int)(Seconds / 86400L);
            Seconds = Seconds % 86400L;
            // Calculate Hours and remaining Seconds
            Hours = (int)(Seconds / 3600L);
            Seconds = Seconds % 3600L;
            // Calculate Minutes and remaining Seconds
            Minutes = (int)(Seconds / 60L);
            Seconds = Seconds % 60L;

            // Add Days on if needed
            if (Days != 0)
            {
                TimeString = Days.ToString() + " Days ";
            }

            return TimeString + Strings.Format(Hours, "00") + ":" + Strings.Format(Minutes, "00") + ":" + Strings.Format(Seconds, "00");

        }

        // Takes a date/time like "1d 22h 38m 46s" and converts it to seconds
        public static long FormatStringdate(string SentTimeString)
        {
            var Days = default(int);
            var Hours = default(int);
            var Minutes = default(int);
            var Seconds = default(int);

            string[] strArr;
            int count;
            try
            {

                if (string.IsNullOrEmpty(SentTimeString))
                {
                    throw new ArgumentException();
                }

                // Break up the string sections
                strArr = SentTimeString.Split(new char[] { ' ' });

                for (count = strArr.Count() - 1; count >= 0; count -= 1)
                {
                    // Loop from seconds to the days
                    if (strArr[count].Substring(strArr[count].Length - 1) == "s")
                    {
                        if (!Information.IsNumeric(strArr[count].Substring(0, Strings.InStr(strArr[count], "s") - 1)))
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            Seconds = Conversions.ToInteger(strArr[count].Substring(0, Strings.InStr(strArr[count], "s") - 1));
                        }
                    }

                    if (strArr[count].Substring(strArr[count].Length - 1) == "m")
                    {
                        if (!Information.IsNumeric(strArr[count].Substring(0, Strings.InStr(strArr[count], "m") - 1)))
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            Seconds = Conversions.ToInteger(strArr[count].Substring(0, Strings.InStr(strArr[count], "m") - 1));
                        }
                    }

                    if (strArr[count].Substring(strArr[count].Length - 1) == "h")
                    {
                        if (!Information.IsNumeric(strArr[count].Substring(0, Strings.InStr(strArr[count], "h") - 1)))
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            Seconds = Conversions.ToInteger(strArr[count].Substring(0, Strings.InStr(strArr[count], "h") - 1));
                        }
                    }

                    if (strArr[count].Substring(strArr[count].Length - 1) == "d")
                    {
                        if (!Information.IsNumeric(strArr[count].Substring(0, Strings.InStr(strArr[count], "d") - 1)))
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            Seconds = Conversions.ToInteger(strArr[count].Substring(0, Strings.InStr(strArr[count], "d") - 1));
                        }
                    }

                }

                return Seconds + 60 * Minutes + 360 * Hours + 360 * 24 * Days;
            }
            catch
            {
                return -1;
            }

        }

        // Takes a date/time like "1d 22h 38m 6s" and sees if it is a date/time
        public static bool IsStringdate(string SentTimeString)
        {
            string[] strArr;
            int count;

            if (string.IsNullOrEmpty(SentTimeString))
            {
                return false;
            }

            // Make sure the sent string has no extra spaces that create a blank array entry
            SentTimeString = Strings.Trim(SentTimeString);

            // Break up the string sections
            strArr = SentTimeString.Split(new char[] { ' ' });

            for (count = strArr.Count() - 1; count >= 0; count -= 1)
            {
                // Loop from seconds to the days
                switch (strArr[count].Substring(strArr[count].Length - 1) ?? "")
                {
                    case "s":
                        {
                            if (!Information.IsNumeric(strArr[count].Substring(0, Strings.InStr(strArr[count], "s") - 1)))
                            {
                                return false;
                            }

                            break;
                        }
                    case "m":
                        {
                            if (!Information.IsNumeric(strArr[count].Substring(0, Strings.InStr(strArr[count], "m") - 1)))
                            {
                                return false;
                            }

                            break;
                        }
                    case "h":
                        {
                            if (!Information.IsNumeric(strArr[count].Substring(0, Strings.InStr(strArr[count], "h") - 1)))
                            {
                                return false;
                            }

                            break;
                        }
                    case "d":
                        {
                            if (!Information.IsNumeric(strArr[count].Substring(0, Strings.InStr(strArr[count], "d") - 1)))
                            {
                                return false;
                            }

                            break;
                        }

                    default:
                        {
                            return false;
                        }
                }

            }

            return true;

        }

        #endregion

        // Checks entry of percentage chars in keypress
        public static bool CheckPercentCharEntry(KeyPressEventArgs ke, TextBox box)
        {
            string Istr = box.Text;

            // Only allow numbers or backspace
            if (ke.KeyChar != ControlChars.Back)
            {
                if (allowedNegativePercentChars.IndexOf(ke.KeyChar) == -1)
                {
                    // Invalid Character
                    return true;
                }
                else if (Strings.Asc(ke.KeyChar) == 45 & Istr.Contains("-") | Strings.Asc(ke.KeyChar) == 37 & Istr.Contains("%") | Strings.Asc(ke.KeyChar) == 46 & Istr.Contains(".")) // If the dash, percent, or period is pressed again, don't accept
                {
                    return true;
                }
            }

            return false;

        }

        // Formats the manual entry of a percent in a string
        public static double FormatManualPercentEntry(string Entry)
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

        // Returns the sent text box text as a percent in string format
        public static string GetFormattedPercentEntry(TextBox RefTextbox)
        {
            return Strings.FormatPercent(FormatManualPercentEntry(RefTextbox.Text), 1);
        }

        public static BPType GetBPType(object BPTypeValue)
        {

            if (BPTypeValue == null)
            {
                return BPType.NotOwned;
            }

            if (BPTypeValue is DBNull)
            {
                return BPType.NotOwned;
            }

            if (BPTypeValue.GetType().Name == "String")
            {
                switch (Conversions.ToString(BPTypeValue) ?? "")
                {
                    case BPO:
                        {
                            return BPType.Original;
                        }
                    case BPC:
                        {
                            return BPType.Copy;
                        }
                    case InventedBPC:
                        {
                            return BPType.InventedBPC;
                        }
                    case UnownedBP:
                        {
                            return BPType.NotOwned;
                        }
                }
            }
            else
            {
                switch (Conversions.ToInteger(BPTypeValue))
                {
                    case (int)BPType.Original:
                        {
                            return BPType.Original;
                        }
                    case (int)BPType.Copy:
                        {
                            return BPType.Copy;
                        }
                    case (int)BPType.InventedBPC:
                        {
                            return BPType.InventedBPC;
                        }
                    case (int)BPType.NotOwned:
                        {
                            return BPType.NotOwned;
                        }
                }
            }

            return BPType.NotOwned;

        }

        public static string GetBPTypeString(object BPTypeValue)
        {

            if (BPTypeValue == null)
            {
                return UnownedBP;
            }

            if (BPTypeValue is DBNull)
            {
                return UnownedBP;
            }

            switch (Conversions.ToInteger(BPTypeValue))
            {
                case (int)BPType.Original:
                    {
                        return BPO;
                    }
                case (int)BPType.Copy:
                    {
                        return BPC;
                    }
                case (int)BPType.InventedBPC:
                    {
                        return InventedBPC;
                    }
                case (int)BPType.NotOwned:
                    {
                        return UnownedBP;
                    }
            }

            return UnownedBP;

        }

        // Function takes a recordset reference and processes it to return the cache date from the query
        // Assumes the first field is the cache date
        public static DateTime ProcessCacheDate(ref SQLiteDataReader rsCache)
        {
            DateTime CacheDate;

            try
            {
                if (rsCache.Read())
                {
                    if (!(rsCache.GetValue(0) is DBNull))
                    {
                        if (string.IsNullOrEmpty(rsCache.GetString(0)))
                        {
                            CacheDate = NoDate;
                        }
                        else
                        {
                            CacheDate = Conversions.ToDate(rsCache.GetString(0));
                        }
                    }
                    else
                    {
                        CacheDate = NoDate;
                    }
                }
                else
                {
                    CacheDate = NoDate;
                }
            }
            catch (Exception ex)
            {
                CacheDate = NoDate;
            }

            return CacheDate;

        }

        // Returns the price of the typeID sent in item_prices
        public static double GetItemPrice(long TypeID)
        {
            SQLiteDataReader readerCost;
            string SQL;
            double ItemPrice = 0d;

            // Look up the cost for the material
            SQL = "SELECT PRICE FROM ITEM_PRICES WHERE ITEM_ID =" + TypeID;

            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            readerCost = DBCommand.ExecuteReader();

            if (readerCost.Read())
            {
                ItemPrice = readerCost.GetDouble(0);
            }

            readerCost.Close();

            return ItemPrice;

        }

        // Sorts the reference listview and column
        /// <summary>
    /// 
    /// </summary>
    /// <param name="ColumnIndex"></param>
    /// <param name="RefListView"></param>
    /// <param name="ListPrevColumnClicked"></param>
    /// <param name="ListPrevColumnSortOrder"></param>
    /// <param name="UseSentSortType"></param>
        public static void ListViewColumnSorter(int ColumnIndex, ref ListView RefListView, ref int ListPrevColumnClicked, ref SortOrder ListPrevColumnSortOrder, bool UseSentSortType = false)
        {
            SortOrder SortType;

            Application.UseWaitCursor = true;
            Application.DoEvents();

            // Figure out sort order
            if (!UseSentSortType)
            {
                if (ColumnIndex == ListPrevColumnClicked)
                {
                    if (ListPrevColumnSortOrder == SortOrder.Ascending)
                    {
                        SortType = SortOrder.Descending;
                    }
                    else
                    {
                        SortType = SortOrder.Ascending;
                    }
                }
                else if (ListPrevColumnSortOrder != SortOrder.None)
                {
                    // Swap sort type
                    if (ListPrevColumnSortOrder == SortOrder.Ascending)
                    {
                        SortType = SortOrder.Descending;
                    }
                    else
                    {
                        SortType = SortOrder.Ascending;
                    }
                }
                else
                {
                    SortType = SortOrder.Ascending;
                }
            }
            else
            {
                SortType = ListPrevColumnSortOrder;
            }

            // Perform the sort with these new sort options.
            if (ColumnIndex > RefListView.Columns.Count - 1)
            {
                ColumnIndex = 0;
            }

            RefListView.ListViewItemSorter = new ListViewItemComparer(ColumnIndex, SortType);
            RefListView.Sort();

            // Save the values for next check
            ListPrevColumnClicked = ColumnIndex;
            ListPrevColumnSortOrder = SortType;

            Application.UseWaitCursor = false;
            Application.DoEvents();

        }

        // Takes text from copy and paste from game and parses it, returns nothing if not, list of parsed materials if successful
        public static Materials ImportCopyPasteText(string SentText)
        {
            string SQL;
            SQLiteDataReader readerItem;
            Material TempMaterial;
            var CopyPasteMaterials = new Materials();
            long TempQuantity;
            string[] ItemLines = null;
            string[] ItemColumns = null;

            string TempString = "";
            string TempNumber = "";

            // Format of imported text for items will always be: Name, Quantity, Group, Category, Size, Slot, Volume, Meta Level, Tech Level, Est. Price
            // Users can remove columns but the general rule is Name and quantity first, they can separate lines by three ways
            if (SentText.Contains(Constants.vbCrLf))
            {
                ItemLines = SentText.Split(new char[] { Conversions.ToChar(Constants.vbCrLf) }, StringSplitOptions.RemoveEmptyEntries); // Get all the item lines
            }
            else if (SentText.Contains(Constants.vbCr))
            {
                ItemLines = SentText.Split(new char[] { Conversions.ToChar(Constants.vbCr) }, StringSplitOptions.RemoveEmptyEntries); // Get all the item lines
            }
            else if (SentText.Contains(Constants.vbLf))
            {
                ItemLines = SentText.Split(new char[] { Conversions.ToChar(Constants.vbLf) }, StringSplitOptions.RemoveEmptyEntries); // Get all the item lines
            }
            else
            {
                // Add a vbcrlf to the end and then split - only one line
                SentText += Constants.vbCrLf;
                ItemLines = SentText.Split(new char[] { Conversions.ToChar(Constants.vbCrLf) }, StringSplitOptions.RemoveEmptyEntries);
            }

            // Loop through the lines
            if (!(ItemLines == null))
            {
                for (int i = 0, loopTo = ItemLines.Count() - 1; i <= loopTo; i++)
                {

                    // Clean up the item line if it has spare lf's or cr's
                    ItemLines[i] = ItemLines[i].Replace(Constants.vbCr, "");
                    ItemLines[i] = ItemLines[i].Replace(Constants.vbLf, "");
                    ItemLines[i] = ItemLines[i].Replace(Constants.vbCrLf, "");

                    // How they split out the columns can be done with Tab, Semicolon, Space or in a final case, comma (because numbers will likely have commas)
                    if (ItemLines[i].Contains(Constants.vbTab))
                    {
                        ItemColumns = ItemLines[i].Split(new char[] { Conversions.ToChar(Constants.vbTab) }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else if (ItemLines[i].Contains(";"))
                    {
                        ItemColumns = ItemLines[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else if (ItemLines[i].Contains(" "))
                    {
                        ItemColumns = ItemLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        // After importing a space, make sure we have a full name and then a number before processing. 
                        // For example, Capital Armor Plates 33 would be a 4 index array but we want to combine the first 3
                        TempString = "";
                        TempNumber = "";

                        for (int j = 0, loopTo1 = ItemColumns.Count() - 1; j <= loopTo1; j++)
                        {
                            if (!Information.IsNumeric(ItemColumns[j]))
                            {
                                TempString = TempString + ItemColumns[j] + " ";
                            }
                            else
                            {
                                TempNumber = TempNumber + ItemColumns[j];
                            }
                        }

                        // Now reset the Item columns
                        ItemColumns = new string[2];
                        ItemColumns[0] = Strings.Trim(TempString);
                        ItemColumns[1] = Strings.Trim(TempNumber);
                    }

                    else if (ItemLines[i].Contains(",")) // Keep this to final case
                    {
                        ItemColumns = ItemLines[i].Split(new char[] { ',' });
                    }
                    else
                    {
                        goto SkipItem;
                        // Dim itemcolumns As String() = ItemLines(i).Split(New String() {"   "}, StringSplitOptions.RemoveEmptyEntries)
                    } // Don't process

                    // If the item has a comma after it, strip it off
                    if (ItemColumns[0].Substring(Strings.Len(ItemColumns[0]) - 1, 1) == ",")
                    {
                        ItemColumns[0] = ItemColumns[0].Substring(0, Strings.Len(ItemColumns[0]) - 1);
                    }

                    SQL = "SELECT typeID FROM INVENTORY_TYPES WHERE typeName = '" + FormatDBString(ItemColumns[0]) + "'";

                    DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
                    readerItem = DBCommand.ExecuteReader();
                    readerItem.Read();

                    if (readerItem.HasRows)
                    {
                        // If the itemcolumns doesn't have a number, add it
                        if (ItemColumns.Count() == 1)
                        {
                            TempString = ItemColumns[0];
                            ItemColumns = new string[2];
                            ItemColumns[0] = TempString;
                            ItemColumns[1] = "";
                        }

                        ItemColumns[0] = Strings.Trim(ItemColumns[0]);
                        ItemColumns[1] = Strings.Trim(ItemColumns[1]);

                        // Format number first if needed
                        if (ItemColumns[1].Contains("."))
                        {
                            // EU number format - quantity is always an integer (27.070)
                            ItemColumns[1] = ItemColumns[1].Replace(".", ",");
                        }

                        // The next item in the list will be the quantity, if not it might be a can or something, so skip it
                        if (Information.IsNumeric(ItemColumns[1]) | string.IsNullOrEmpty(ItemColumns[1])) // Unpackaged items are 1
                        {
                            if (string.IsNullOrEmpty(ItemColumns[1]))
                            {
                                TempQuantity = 1L;
                            }
                            else
                            {
                                TempQuantity = Conversions.ToLong(ItemColumns[1]);
                            }
                            TempMaterial = new Material(Conversions.ToLong(readerItem.GetValue(0)), ItemColumns[0], "", TempQuantity, 0d, 0d, "", "");
                            CopyPasteMaterials.InsertMaterial(TempMaterial);
                        }
                    }
                    readerItem.Close();
                SkipItem:
                    ;

                    readerItem = null;

                }
            }

            return CopyPasteMaterials;

        }

        public static string UpdateItemNamewithRuns(string ItemName, long Runs)
        {
            // Update built item name with runs we did to get this quantity
            // Reset item name for found item
            if (ItemName.Contains("("))
            {
                ItemName = Strings.Trim(ItemName.Substring(0, Strings.InStr(ItemName, "(") - 1));
            }

            return ItemName + " (Runs: " + Strings.FormatNumber(Runs, 0) + ")";

        }

        // Strips off the Runs if it is on the name
        public static string RemoveItemNameRuns(string ItemName)
        {
            if (ItemName.Contains("(Runs:"))
            {
                return Strings.Trim(ItemName.Substring(0, Strings.InStr(ItemName, "(") - 2));
            }
            else
            {
                return ItemName;
            }
        }

        public static long GetBPUserID(long SentUserID)
        {
            long BPUserID;

            if (SettingsVariables.UserApplicationSettings.LoadBPsbyChar)
            {
                // Use the ID sent
                BPUserID = SentUserID;
            }
            else
            {
                BPUserID = CommonLoadBPsID;
            }

            return BPUserID;

        }

        // Imports sent blueprint to shopping list
        public static void AddToShoppingList(Blueprint SentBlueprint, bool BuildBuy, bool CopyRawMats, IndustryFacility SLFacility, bool IgnoreInvention, bool IgnoreMinerals, bool IgnoreT1ITem, bool CopyInventionMatsOnly = false)
        {
            var TempMats = new Materials();
            var ShoppingItem = new ShoppingListItem();
            var ShoppingBuildList = new BuiltItemList();
            var ShoppingBuyList = new Materials();

            if (CopyRawMats | BuildBuy == true) // Either just raw or build buy selected
            {
                // Add the item and the materials for the item
                if (!(SentBlueprint.GetRawMaterials() == null))
                {
                    ShoppingItem.BlueprintTypeID = SentBlueprint.GetTypeID();
                    ShoppingItem.TypeID = SentBlueprint.GetItemID();
                    ShoppingItem.Name = SentBlueprint.GetItemData().GetMaterialName();
                    ShoppingItem.Runs = SentBlueprint.GetItemData().GetQuantity();
                    ShoppingItem.ItemME = SentBlueprint.GetME();
                    ShoppingItem.ItemTE = SentBlueprint.GetTE();
                    ShoppingItem.PortionSize = SentBlueprint.GetPortionSize();

                    ShoppingItem.ManufacturingFacility = SentBlueprint.GetManufacturingFacility();
                    ShoppingItem.ComponentManufacturingFacility = SentBlueprint.GetComponentManufacturingFacility();
                    ShoppingItem.ReactionFacility = SentBlueprint.GetReactionFacility();

                    if (BuildBuy)
                    {
                        ShoppingItem.BuildType = "Build/Buy";
                    }
                    else
                    {
                        // Just insert the materials in components since we are building all
                        ShoppingItem.BuildType = "Raw Mats";
                    }

                    if (!CopyInventionMatsOnly)
                    {
                        ShoppingBuyList = (Materials)SentBlueprint.GetRawMaterials().Clone(); // Need a deep copy because we might insert later
                        ShoppingBuildList = (BuiltItemList)SentBlueprint.BuiltComponentList.Clone();
                    }

                    // Total up all usage
                    ShoppingItem.TotalUsage = SentBlueprint.GetManufacturingFacilityUsage() + SentBlueprint.GetComponentFacilityUsage() + SentBlueprint.GetCapComponentFacilityUsage() + SentBlueprint.GetInventionUsage() + SentBlueprint.GetCopyUsage() + SentBlueprint.GetReactionFacilityUsage();

                    // Get the build time
                    ShoppingItem.TotalBuildTime = SentBlueprint.GetTotalProductionTime();

                    // All blueprint build types we want to save the base materials to build the bp
                    ShoppingItem.BPMaterialList = (Materials)SentBlueprint.GetComponentMaterials().Clone();
                    ShoppingItem.BPBuiltItems = (BuiltItemList)SentBlueprint.GetComponentsList().Clone();

                }
            }

            // Add the component items and mats to the list and that's it. They are building the end item, nothing else
            else if (!(SentBlueprint.GetComponentMaterials() == null))
            {
                ShoppingItem.BlueprintTypeID = SentBlueprint.GetTypeID();
                ShoppingItem.TypeID = SentBlueprint.GetItemID();
                ShoppingItem.Name = SentBlueprint.GetItemData().GetMaterialName();
                ShoppingItem.Runs = SentBlueprint.GetItemData().GetQuantity();
                ShoppingItem.ItemME = SentBlueprint.GetME();
                ShoppingItem.ItemTE = SentBlueprint.GetTE();
                ShoppingItem.ManufacturingFacility = SentBlueprint.GetManufacturingFacility();
                ShoppingItem.ComponentManufacturingFacility = SentBlueprint.GetComponentManufacturingFacility();
                ShoppingItem.ReactionFacility = SentBlueprint.GetReactionFacility();
                ShoppingItem.PortionSize = SentBlueprint.GetPortionSize();
                ShoppingItem.BuildType = "Components";

                if (!CopyInventionMatsOnly)
                {
                    ShoppingBuyList = (Materials)SentBlueprint.GetComponentMaterials().Clone(); // Need a deep copy because we might insert later
                    ShoppingBuildList = null;
                }

                // Total up all usage but not component usage
                ShoppingItem.TotalUsage = SentBlueprint.GetManufacturingFacilityUsage() + SentBlueprint.GetInventionUsage() + SentBlueprint.GetCopyUsage();

                // Get the build time
                ShoppingItem.TotalBuildTime = SentBlueprint.GetProductionTime();

                // Make sure all items in the buy list are not set to build
                for (int i = 0, loopTo = ShoppingBuyList.GetMaterialList().Count - 1; i <= loopTo; i++)
                    ShoppingBuyList.GetMaterialList()[i].SetBuildItem(false);

                // All blueprint build types we want to save the base materials to build it, here we want just what's in the buy list since we aren't building
                ShoppingItem.BPMaterialList = (Materials)ShoppingBuyList.Clone();
                ShoppingItem.BPBuiltItems = null; // no building here

            }

            if (SentBlueprint.GetTechLevel() == (int)BPTechLevel.T2 | SentBlueprint.GetTechLevel() == (int)BPTechLevel.T3)
            {
                if (SettingsVariables.UserApplicationSettings.ShopListIncludeInventMats == true | CopyInventionMatsOnly)
                {
                    // Save the list of invention materials
                    ShoppingItem.InventionMaterials = (Materials)SentBlueprint.GetInventionMaterials().Clone();

                    // Now insert into main buy List 
                    ShoppingBuyList.InsertMaterialList(ShoppingItem.InventionMaterials.GetMaterialList());

                    // Remove the data interface though, we will assume they don't want to buy this but this will get listed in the copy output (sent above)
                    ShoppingBuyList.RemoveMaterial(SentBlueprint.GetInventionMaterials().SearchListbyName("Data Interface"));

                    // Remove the usage as well
                    ShoppingBuyList.RemoveMaterial(SentBlueprint.GetInventionMaterials().SearchListbyName("Invention Usage"));

                }

                if (SettingsVariables.UserApplicationSettings.ShopListIncludeCopyMats == true | CopyInventionMatsOnly)
                {
                    // Save the list of copy materials
                    ShoppingItem.CopyMaterials = (Materials)SentBlueprint.GetCopyMaterials().Clone();

                    // Now insert these into main buy list
                    ShoppingBuyList.InsertMaterialList(ShoppingItem.CopyMaterials.GetMaterialList());

                    // Remove Usage
                    ShoppingBuyList.RemoveMaterial(SentBlueprint.GetInventionMaterials().SearchListbyName("Copy Usage"));
                }

                // How many runs do we need to invent this?
                ShoppingItem.AvgInvRunsforSuccess = 1d / SentBlueprint.GetInventionChance();
                ShoppingItem.InventedRunsPerBP = SentBlueprint.GetSingleInventedBPCRuns();
                ShoppingItem.InventionJobs = SentBlueprint.GetInventionJobs();

                // Decryptor if used
                ShoppingItem.Decryptor = SentBlueprint.GetDecryptor().Name;
                ShoppingItem.Relic = SentBlueprint.GetRelic();

            }

            // Volume of the item(s)
            ShoppingItem.BuildVolume = SentBlueprint.GetTotalItemVolume();

            // Ignore flags
            ShoppingItem.IgnoredInvention = IgnoreInvention;
            ShoppingItem.IgnoredMinerals = IgnoreMinerals;
            ShoppingItem.IgnoredT1BaseItem = IgnoreT1ITem;

            // Number of bps used
            ShoppingItem.NumBPs = SentBlueprint.GetUsedNumBPs();

            // Finally set techlevel

            ShoppingItem.TechLevel = SentBlueprint.GetTechLevel();

            // Add the market cost
            ShoppingItem.TotalItemMarketCost = SentBlueprint.GetItemMarketPrice();

            // Add the final item and mark as items in list
            TotalShoppingList.InsertShoppingItem(ShoppingItem, ShoppingBuildList, ShoppingBuyList);

        }

        // Enables Cut, Copy, Paste, and Select all from shortcut key entry for the sent text box
        public static bool ProcessCutCopyPasteSelect(TextBox SentBox, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A && e.Control == true) // Select All
            {
                SentBox.SelectAll();
            }
            else if (e.KeyCode == Keys.X && e.Control == true) // Cut
            {
                SentBox.Cut();
            }
            else if (e.KeyCode == Keys.C && e.Control == true) // Copy
            {
                SentBox.Copy();
            }
            else if (e.KeyCode == Keys.V && e.Control == true) // Paste
            {
                SentBox.Paste();
                return true;
            }

            return false;

        }

        public static bool BPHasProcRawMats(int BPID, BuildMatType MatType)
        {
            string SQL;
            SQLiteDataReader readerBP;

            if (MatType == BuildMatType.AdvMaterials)
            {
                // Don't process for advanced since they don't want to drill down for reactions, etc.
                return false;
            }

            SQL = "SELECT 'X' FROM ALL_BLUEPRINT_MATERIALS_FACT WHERE PRODUCT_ID IN ";
            SQL += "(SELECT ITEM_ID FROM ALL_BLUEPRINTS_FACT WHERE ITEM_ID IN ";
            SQL += "(SELECT MATERIAL_ID FROM ALL_BLUEPRINT_MATERIALS_FACT WHERE BLUEPRINT_ID = {0})) ";

            if (MatType == BuildMatType.ProcessedMaterials)
            {
                SQL += "AND MATERIAL_GROUP_ID IN (429,712)";
            }
            else if (MatType == BuildMatType.RawMaterials)
            {
                SQL += "AND MATERIAL_GROUP_ID IN (428,429,711,712,974)";
            }

            try
            {
                DBCommand = new SQLiteCommand(string.Format(SQL, BPID), EVEDB.DBREf());
                readerBP = DBCommand.ExecuteReader();

                if (readerBP.Read())
                {
                    readerBP.Close();
                    return true;
                }

                readerBP.Close();
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        // After a price update in any location that updates prices, we want to refresh all the prices and grids on every tab 
        public static void UpdateProgramPrices(bool RefreshUpdatePriceList = true)
        {

            // Update the Update Prices tab
            if (RefreshUpdatePriceList)
            {
                My.MyProject.Forms.frmMain.UpdatePriceList();
            }

            // Update the shopping list
            UpdateShoppingListPrices();

            // Reset manufacturing calc button
            My.MyProject.Forms.frmMain.ResetRefresh();

            // Refresh the BP Tab if there is a blueprint selected
            if (!(SelectedBlueprint == null))
            {
                My.MyProject.Forms.frmMain.RefreshBP(true);
            }

            // Refresh the Mining Tab
            if (My.MyProject.Forms.frmMain.lstMineGrid.Items.Count > 0)
            {
                My.MyProject.Forms.frmMain.LoadMiningGrid();
            }

            // Refresh the prices in manual update for minerals
            My.MyProject.Forms.frmManualPriceUpdate.LoadMineralPrices();

            // Manual update of moon materials
            My.MyProject.Forms.frmManualPriceUpdate.LoadMoonPrices();

            // Reload the prices on the reprocessing plant if open
            if (Application.OpenForms.OfType<frmReprocessingPlant>().Any())
            {
                frmRepoPlant.RefreshMaterialList();
            }

            // Refill the search grid on manual updates
            if (!string.IsNullOrEmpty(Strings.Trim(My.MyProject.Forms.frmManualPriceUpdate.lblLSelectedItem.Text)))
            {
                My.MyProject.Forms.frmManualPriceUpdate.FillSearchGrid(My.MyProject.Forms.frmManualPriceUpdate.lblSelectedItem.Text);
            }

        }

        // Function to get the regionID from the name sent
        public static int GetRegionID(string RegionName)
        {
            SQLiteDataReader readerRegion;
            int ReturnID;

            // Get the region ID
            DBCommand = new SQLiteCommand("SELECT regionID FROM REGIONS WHERE regionName ='" + FormatDBString(RegionName) + "'", EVEDB.DBREf());
            readerRegion = DBCommand.ExecuteReader();

            if (readerRegion.Read())
            {
                ReturnID = readerRegion.GetInt32(0);
            }
            else
            {
                ReturnID = 0;
            }

            readerRegion.Close();

            return ReturnID;

        }

        // Function to get the regionID from systemid sent
        public static int GetRegionID(int solarSystemID)
        {
            SQLiteDataReader readerRegion;
            int ReturnID;

            // Get the region ID
            DBCommand = new SQLiteCommand("SELECT regionID FROM SOLAR_SYSTEMS WHERE solarSystemID = " + solarSystemID.ToString(), EVEDB.DBREf());
            readerRegion = DBCommand.ExecuteReader();

            if (readerRegion.Read())
            {
                ReturnID = readerRegion.GetInt32(0);
            }
            else
            {
                ReturnID = 0;
            }

            readerRegion.Close();

            return ReturnID;

        }

        // Sets the default character to the character name sent
        public static void SetDefaultCharacter(string CharacterName)
        {
            // If we get here, just clear out the old default and set the new one
            LoadCharacter(CharacterName, false);
            // Refresh all screens
            if (Application.OpenForms.OfType<frmMain>().Any())
            {
                My.MyProject.Forms.frmMain.ResetTabs();
            }

            // Reset any of the characterids
            My.MyProject.Forms.frmMain.ResetCharacterIDonFacilties();

            DefaultCharSelected = true;
            Interaction.MsgBox(CharacterName + " selected as Default Character", Constants.vbInformation, Application.ProductName);

        }

        // Function to get the regionID from the name sent
        public static string GetRegionName(int RegionID)
        {
            SQLiteDataReader readerRegion;
            string ReturnName;

            // Get the region ID
            DBCommand = new SQLiteCommand("SELECT regionName FROM REGIONS WHERE regionID = " + RegionID.ToString(), EVEDB.DBREf());
            readerRegion = DBCommand.ExecuteReader();

            if (readerRegion.Read())
            {
                ReturnName = readerRegion.GetString(0);
            }
            else
            {
                ReturnName = "";
            }

            readerRegion.Close();

            return ReturnName;

        }

        // Returns the SQL for getting item price typeids = and empty string if nothing selected
        public static string GetItemPriceGroupListSQL(CheckBox AdvancedComponents, CheckBox AdvancedMats, CheckBox AdvancedProtectiveTechnology, CheckBox AncientRelics, CheckBox BoosterMats, CheckBox Boosters, CheckBox BPCs, CheckBox CapitalShipComponents, CheckBox CapT2ShipComponents, CheckBox Celestials, CheckBox Charges, CheckBox Datacores, CheckBox Decryptors, CheckBox Deployables, CheckBox Drones, CheckBox FactionMaterials, CheckBox FuelBlocks, CheckBox Gas, CheckBox IceProducts, CheckBox Implants, CheckBox Minerals, CheckBox Misc, CheckBox Modules, CheckBox MolecularForgedMaterials, CheckBox MolecularForgingTools, CheckBox NamedComponents, CheckBox Planetary, CheckBox Polymers, CheckBox ProcessedMats, CheckBox ProtectiveComponents, CheckBox RAM, CheckBox RawMaterials, CheckBox RawMoonMats, CheckBox RDb, CheckBox Rigs, CheckBox Salvage, CheckBox Ships, CheckBox StructureComponents, CheckBox StructureModules, CheckBox StructureRigs, CheckBox Structures, CheckBox SubsystemComponents, CheckBox Subsystems, ComboBox ChargeTypes, ComboBox ShipTypes, CheckBox PricesT1, bool PriceCheckT1Enabled, CheckBox PricesT2, bool PriceCheckT2Enabled, CheckBox PricesT3, bool PriceCheckT3Enabled, CheckBox PricesT4, bool PriceCheckT4Enabled, CheckBox PricesT5, bool PriceCheckT5Enabled, CheckBox PricesT6, bool PriceCheckT6Enabled, CheckBox NoBuildItems)
        {

            string SQL = "";
            string TechSQL = "";
            bool ItemChecked = false;
            bool TechChecked = false;

            // Materials & Research Equipment Grid
            // Materials First
            if (AdvancedProtectiveTechnology.Checked)
            {
                SQL += "ITEM_GROUP = 'Advanced Protective Technology' OR ";
                ItemChecked = true;
            }
            if (FactionMaterials.Checked)
            {
                SQL += "(ITEM_GROUP IN ('Materials and Compounds','Artifacts and Prototypes','Rogue Drone Components') OR ITEM_GROUP LIKE 'Decryptors -%') OR ";
                ItemChecked = true;
            }
            if (Gas.Checked)
            {
                SQL += "ITEM_GROUP IN ('Harvestable Cloud','Compressed Gas') OR ";
                ItemChecked = true;
            }
            if (IceProducts.Checked)
            {
                SQL += "ITEM_GROUP = 'Ice Product' OR ";
                ItemChecked = true;
            }
            if (Minerals.Checked)
            {
                SQL += "ITEM_GROUP = 'Mineral' OR ";
                ItemChecked = true;
            }
            if (MolecularForgingTools.Checked)
            {
                SQL += "ITEM_GROUP = 'Molecular-Forging Tools' OR ";
                ItemChecked = true;
            }
            if (NamedComponents.Checked)
            {
                SQL += "ITEM_GROUP = 'Named Components' OR ";
                ItemChecked = true;
            }
            if (Planetary.Checked)
            {
                SQL += "ITEM_CATEGORY LIKE 'Planetary%' OR ";
                ItemChecked = true;
            }

            // Raw Materials (Ores)
            if (RawMaterials.Checked)
            {
                SQL += "(ITEM_CATEGORY = 'Asteroid' OR ITEM_GROUP = 'Abyssal Materials') OR ";
                ItemChecked = true;
            }

            // Reaction Materials
            if (AdvancedMats.Checked)
            {
                SQL += "ITEM_GROUP = 'Composite' OR ";
                ItemChecked = true;
            }
            if (BoosterMats.Checked)
            {
                SQL += "ITEM_GROUP = 'Biochemical Material' OR ";
                ItemChecked = true;
            }
            if (MolecularForgedMaterials.Checked)
            {
                SQL += "ITEM_GROUP = 'Molecular-Forged Materials' OR ";
                ItemChecked = true;
            }
            if (Polymers.Checked)
            {
                SQL += "ITEM_GROUP = 'Hybrid Polymers' OR ";
                ItemChecked = true;
            }
            if (ProcessedMats.Checked)
            {
                SQL += "ITEM_GROUP = 'Intermediate Materials' OR ";
                ItemChecked = true;
            }
            if (RawMoonMats.Checked)
            {
                SQL += "ITEM_GROUP = 'Moon Materials' OR ";
                ItemChecked = true;
            }

            if (Salvage.Checked)
            {
                SQL += "ITEM_GROUP IN ('Salvaged Materials','Ancient Salvage') OR ";
                ItemChecked = true;
            }

            // Research Equipment
            if (AncientRelics.Checked)
            {
                SQL += "ITEM_CATEGORY = 'Ancient Relics' OR ";
                ItemChecked = true;
            }
            if (Datacores.Checked)
            {
                SQL += "ITEM_GROUP = 'Datacores' OR ";
                ItemChecked = true;
            }
            if (Decryptors.Checked)
            {
                SQL += "ITEM_CATEGORY = 'Decryptors' OR ";
                ItemChecked = true;
            }
            if (RDb.Checked)
            {
                SQL += "ITEM_NAME LIKE 'R.Db%' OR ";
                ItemChecked = true;
            }

            // Misc and Blueprints
            if (BPCs.Checked)
            {
                SQL += "ITEM_CATEGORY = 'Blueprint' OR ";
                ItemChecked = true;
            }
            if (Misc.Checked) // Commodities = Shattered Villard Wheel
            {
                SQL += "ITEM_GROUP IN ('General','Livestock','Radioactive','Biohazard','Commodities','Empire Insignia Drops','Criminal Tags','Miscellaneous','Unknown Components','Lease') OR ";
                ItemChecked = true;
            }

            // Other Manufacturables
            if (CapT2ShipComponents.Checked)
            {
                SQL += "ITEM_GROUP = 'Advanced Capital Construction Components' OR ";
                ItemChecked = true;
            }
            if (AdvancedComponents.Checked)
            {
                SQL += "ITEM_GROUP = 'Construction Components' OR ";
                ItemChecked = true;
            }
            if (FuelBlocks.Checked)
            {
                SQL += "ITEM_GROUP = 'Fuel Block' OR ";
                ItemChecked = true;
            }
            if (ProtectiveComponents.Checked)
            {
                SQL += "ITEM_GROUP = 'Protective Components' OR ";
                ItemChecked = true;
            }
            if (RAM.Checked)
            {
                SQL += "ITEM_NAME LIKE 'R.A.M.%' OR ";
                ItemChecked = true;
            }
            if (NoBuildItems.Checked)
            {
                SQL += "MANUFACTURE = -1 OR ";
                ItemChecked = true;
            }
            if (CapitalShipComponents.Checked)
            {
                SQL += "ITEM_GROUP = 'Capital Construction Components' OR ";
                ItemChecked = true;
            }
            if (StructureComponents.Checked)
            {
                SQL += "ITEM_GROUP = 'Structure Components' OR ";
                ItemChecked = true;
            }
            if (SubsystemComponents.Checked)
            {
                SQL += "ITEM_GROUP = 'Hybrid Tech Components' OR ";
                ItemChecked = true;
            }
            if (Boosters.Checked)
            {
                SQL += "ITEM_GROUP = 'Booster' OR ";
                ItemChecked = true;
            }

            // All other manufactured items
            if (Implants.Checked)
            {
                SQL += "(ITEM_GROUP = 'Cyberimplant' OR (ITEM_CATEGORY = 'Implant' AND ITEM_GROUP <> 'Booster')) OR ";
                ItemChecked = true;
            }
            if (Deployables.Checked)
            {
                SQL += "ITEM_CATEGORY = 'Deployable' OR ";
                ItemChecked = true;
            }
            if (StructureModules.Checked)
            {
                SQL += "(ITEM_CATEGORY = 'Structure Module' AND ITEM_GROUP NOT LIKE '%Rig%') OR ";
                ItemChecked = true;
            }
            if (Celestials.Checked)
            {
                SQL += "(ITEM_CATEGORY IN ('Celestial','Orbitals','Sovereignty Structures','Station','Accessories','Infrastructure Upgrades')  AND ITEM_GROUP NOT IN ('Harvestable Cloud','Compressed Gas')) OR ";
                ItemChecked = true;
            }

            // Manufactured Items
            if (Ships.Checked | Modules.Checked | Drones.Checked | Rigs.Checked | Subsystems.Checked | Structures.Checked | Charges.Checked | StructureRigs.Checked)
            {

                // If they choose a tech level, then build this part of the SQL query
                if (PriceCheckT1Enabled)
                {
                    if (PricesT1.Checked)
                    {
                        // Add to SQL query for tech level
                        TechSQL = TechSQL + "ITEM_TYPE = 1 OR ";
                        TechChecked = true;
                    }
                }

                if (PriceCheckT2Enabled)
                {
                    if (PricesT2.Checked)
                    {
                        // Add to SQL query for tech level
                        TechSQL = TechSQL + "ITEM_TYPE = 2 OR ";
                        TechChecked = true;
                    }
                }

                if (PriceCheckT3Enabled)
                {
                    if (PricesT3.Checked)
                    {
                        // Add to SQL query for tech level
                        TechSQL = TechSQL + "ITEM_TYPE = 14 OR ";
                        TechChecked = true;
                    }
                }

                // Add the Pirate, Storyline, Navy search string
                // Storyline
                if (PriceCheckT4Enabled)
                {
                    if (PricesT4.Checked)
                    {
                        // Add to SQL query for tech level
                        TechSQL = TechSQL + "ITEM_TYPE = 3 OR ";
                        TechChecked = true;
                    }
                }

                // Navy
                if (PriceCheckT5Enabled)
                {
                    if (PricesT5.Checked)
                    {
                        // Add to SQL query for tech level
                        TechSQL = TechSQL + "ITEM_TYPE = 16 OR ";
                        TechChecked = true;
                    }
                }

                // Pirate
                if (PriceCheckT6Enabled)
                {
                    if (PricesT6.Checked)
                    {
                        // Add to SQL query for tech level
                        TechSQL = TechSQL + "ITEM_TYPE = 15 OR ";
                        TechChecked = true;
                    }
                }

                if (!TechChecked & !ItemChecked)
                {
                    // There isn't an item checked before this and these items all require tech, so exit
                    return "";
                }

                // Format TechSQL - Add on Meta codes - 21,22,23,24 are T3
                if (!string.IsNullOrEmpty(TechSQL))
                {
                    TechSQL = "(" + TechSQL.Substring(0, TechSQL.Length - 3) + "OR ITEM_TYPE IN (21,22,23,24)) ";
                }

                // Build Tech 1,2,3 Manufactured Items
                if (Charges.Checked)
                {
                    SQL += "(ITEM_CATEGORY = 'Charge' AND " + TechSQL;
                    if (ChargeTypes.Text != "All Charge Types")
                    {
                        SQL += " AND ITEM_GROUP = '" + ChargeTypes.Text + "'";
                    }
                    SQL += ") OR ";
                }
                if (Drones.Checked)
                {
                    SQL += "(ITEM_CATEGORY IN ('Drone', 'Fighter') AND " + TechSQL + ") OR ";
                }
                if (Modules.Checked) // Not rigs but Modules
                {
                    SQL += "(ITEM_CATEGORY = 'Module' AND ITEM_GROUP NOT LIKE 'Rig%' AND " + TechSQL + ") OR ";
                }
                if (Ships.Checked)
                {
                    SQL += "(ITEM_CATEGORY = 'Ship' AND " + TechSQL;
                    if (ShipTypes.Text != "All Ship Types")
                    {
                        SQL += " AND ITEM_GROUP = '" + ShipTypes.Text + "'";
                    }
                    SQL += ") OR ";
                }
                if (Subsystems.Checked)
                {
                    SQL += "(ITEM_CATEGORY = 'Subsystem' AND " + TechSQL + ") OR ";
                }
                if (StructureRigs.Checked)
                {
                    SQL += "(ITEM_CATEGORY = 'Structure Rigs' AND " + TechSQL + ") OR ";
                }
                if (Rigs.Checked) // Rigs
                {
                    SQL += "((ITEM_CATEGORY = 'Module' AND ITEM_GROUP LIKE 'Rig%' AND " + TechSQL + ") OR (ITEM_CATEGORY = 'Structure Module' AND ITEM_GROUP LIKE '%Rig%')) OR ";
                }
                if (Structures.Checked)
                {
                    SQL += "((ITEM_CATEGORY IN ('Starbase','Structure') AND " + TechSQL + ") OR ITEM_GROUP = 'Station Components') OR ";
                }
            }

            // Take off last OR and add the final )
            SQL = SQL.Substring(0, SQL.Length - 4);

            return SQL;

        }

        public static int GetSolarSystemID(string SystemName)
        {
            // Look up Solar System ID
            SQLiteDataReader rsSystem;
            int SSID;

            DBCommand = new SQLiteCommand("SELECT solarSystemID FROM SOLAR_SYSTEMS WHERE solarSystemName = '" + SystemName + "'", EVEDB.DBREf());
            rsSystem = DBCommand.ExecuteReader();

            if (rsSystem.Read())
            {
                SSID = rsSystem.GetInt32(0);
            }
            else
            {
                SSID = 0;
            }

            rsSystem.Close();

            return SSID;

        }

        public static string GetSolarSystemName(long SystemID)
        {
            // Look up Solar System Name
            SQLiteDataReader rsSystem;
            string SSName;

            DBCommand = new SQLiteCommand("SELECT solarSystemName FROM SOLAR_SYSTEMS WHERE solarSystemID = " + SystemID.ToString(), EVEDB.DBREf());
            rsSystem = DBCommand.ExecuteReader();

            if (rsSystem.Read())
            {
                SSName = rsSystem.GetString(0);
            }
            else
            {
                SSName = "";
            }

            rsSystem.Close();

            return SSName;

        }

        public static double GetSolarSystemSecurityLevel(string SystemName)
        {
            // Look up Solar System ID
            SQLiteDataReader rsSystem;
            double security;

            DBCommand = new SQLiteCommand("SELECT SECURITY FROM SOLAR_SYSTEMS WHERE solarSystemName = '" + FormatDBString(SystemName) + "'", EVEDB.DBREf());
            rsSystem = DBCommand.ExecuteReader();

            if (rsSystem.Read())
            {
                security = rsSystem.GetDouble(0);
            }
            else
            {
                security = (double)default;
            }

            rsSystem.Close();

            return security;

        }

        public static double GetSolarSystemSecurityLevel(long SystemID)
        {
            // Look up Solar System ID
            SQLiteDataReader rsSystem;
            double security;

            DBCommand = new SQLiteCommand("SELECT SECURITY FROM SOLAR_SYSTEMS WHERE solarSystemID = " + SystemID.ToString(), EVEDB.DBREf());
            rsSystem = DBCommand.ExecuteReader();

            if (rsSystem.Read())
            {
                security = rsSystem.GetDouble(0);
            }
            else
            {
                security = (double)default;
            }

            rsSystem.Close();

            return security;

        }

        public static int GetActivityID(string ActivityName)
        {
            // Look up the Activity ID for the ID sent
            SQLiteDataReader rsSystem;
            int AID;

            DBCommand = new SQLiteCommand("SELECT activityID FROM INDUSTRY_ACTIVITIES WHERE UPPER(activityName) = '" + Strings.UCase(ActivityName) + "'", EVEDB.DBREf());
            rsSystem = DBCommand.ExecuteReader();

            if (rsSystem.Read())
            {
                AID = rsSystem.GetInt32(0);
            }
            else
            {
                AID = 0;
            }

            rsSystem.Close();

            return AID;

        }

        public static string GetActivityName(int ActivityID)
        {
            // Look up the Activity Name for the ID sent
            SQLiteDataReader rsSystem;
            string AName;

            DBCommand = new SQLiteCommand("SELECT activityName FROM INDUSTRY_ACTIVITIES WHERE activityID = " + ActivityID.ToString(), EVEDB.DBREf());
            rsSystem = DBCommand.ExecuteReader();

            if (rsSystem.Read())
            {
                AName = rsSystem.GetString(0);
            }
            else
            {
                AName = "";
            }

            rsSystem.Close();

            return AName;

        }

        // Loads a referenced combobox with regions
        public static void LoadRegionCombo(ref ComboBox RegionCombo, string DefaultRegionName)
        {
            string SQL = "";
            SQLiteDataReader rsData;

            SQL = "SELECT regionName FROM REGIONS WHERE (regionName NOT LIKE '%-R%' OR regionName = 'G-R00031' ) AND regionName NOT LIKE 'VR-%' ";
            SQL += "AND regionName NOT IN ('A821-A','J7HZ-F','PR-01','UUA-F4') AND regionName NOT LIKE 'ADR%' GROUP BY regionName ";
            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            rsData = DBCommand.ExecuteReader();
            RegionCombo.BeginUpdate();
            RegionCombo.Items.Clear();
            while (rsData.Read())
                RegionCombo.Items.Add(rsData.GetString(0));
            RegionCombo.EndUpdate();
            RegionCombo.Text = DefaultRegionName;

            rsData.Close();

        }

        // Limits the referenced text box between 0 and 10/20 on text
        public static void VerifyMETEEntry(ref TextBox METETextBox, string Type)
        {
            if (!string.IsNullOrEmpty(Strings.Trim(METETextBox.Text)))
            {
                if (Type == "ME")
                {
                    if (!Information.IsNumeric(METETextBox))
                    {
                        if (Conversions.ToInteger(METETextBox.Text) < 0)
                        {
                            METETextBox.Text = "0";
                        }
                        else if (Conversions.ToInteger(METETextBox.Text) > 10)
                        {
                            METETextBox.Text = "10";
                        }
                    }
                    else
                    {
                        METETextBox.Text = "";
                    }
                }
                else if (!Information.IsNumeric(METETextBox))
                {
                    if (Conversions.ToInteger(METETextBox.Text) < 0)
                    {
                        METETextBox.Text = "0";
                    }
                    else if (Conversions.ToInteger(METETextBox.Text) > 20)
                    {
                        METETextBox.Text = "20";
                    }
                }
                else
                {
                    METETextBox.Text = "";
                }
            }
        }

        // Updates the value in the progressbar for a smooth progress - total hack from this: http://stackoverflow.com/questions/977278/how-can-i-make-the-progress-bar-update-fast-enough/1214147#1214147
        public static void IncrementToolStripProgressBar(ref ToolStripProgressBar PG)
        {
            if (PG.Value <= PG.Maximum - 1)
            {
                PG.Value = PG.Value + 1;
                PG.Value = PG.Value - 1;
                PG.Value = PG.Value + 1;
            }
        }

        // Updates the value in the progressbar for a smooth progress - total hack from this: http://stackoverflow.com/questions/977278/how-can-i-make-the-progress-bar-update-fast-enough/1214147#1214147
        public static void IncrementProgressBar(ref ProgressBar PG)
        {
            if (PG.Value <= PG.Maximum - 1)
            {
                PG.Value = PG.Value + 1;
                PG.Value = PG.Value - 1;
                PG.Value = PG.Value + 1;
            }
        }

        // Check for Fulcrum bonus - if it's an angel or gurista's subcap and they are using Fulcrum station, return true
        public static bool GetFulcrumBonusFlagforItem(long FacilityID, long BlueprintID)
        {

            if (FacilityID == 60015187L)
            {
                SQLiteDataReader rsShip;
                string SQL;

                // Get the ItemID from the BP ID
                long ItemID = 0L;
                DBCommand = new SQLiteCommand("SELECT ITEM_ID FROM ALL_BLUEPRINTS_FACT WHERE BLUEPRINT_ID = " + BlueprintID.ToString(), EVEDB.DBREf());
                rsShip = DBCommand.ExecuteReader();
                if (rsShip.Read())
                {
                    ItemID = rsShip.GetInt64(0);
                }

                SQL = "SELECT 'X' FROM INVENTORY_GROUPS, INVENTORY_TYPES WHERE typeID = {0} AND INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID ";
                SQL += "AND categoryID = 6 AND factionID IN (500010,500011) AND INVENTORY_GROUPS.groupID NOT IN (883, 547, 485, 1538, 513, 902, 30) "; // No caps

                DBCommand = new SQLiteCommand(string.Format(SQL, ItemID), EVEDB.DBREf());
                rsShip = DBCommand.ExecuteReader();

                if (rsShip.HasRows)
                {
                    rsShip.Close();
                    return true;
                }
                rsShip.Close();
            }

            return false;

        }

        // Checks for program updates
        public static void CheckForUpdates(bool ShowFinalMessage, Icon ProgramIcon)
        {
            DialogResult Response;
            // Program Updater
            var Updater = new ProgramUpdater();
            UpdateCheckResult UpdateCode;

            // 1 = Update Available, 0 No Update Available, -1 an error occured and msg box already shown
            UpdateCode = Updater.IsProgramUpdatable();

            switch (UpdateCode)
            {
                case UpdateCheckResult.UpdateAvailable:
                    {

                        Response = TopMostMessageBox.Show("Update Available - Do you want to update now?", Application.ProductName, MessageBoxButtons.YesNo, ProgramIcon);

                        if (Response == DialogResult.Yes)
                        {
                            // Run the updater
                            Updater.RunUpdate();
                        }

                        break;
                    }
                case UpdateCheckResult.UpToDate:
                    {
                        if (ShowFinalMessage)
                        {
                            Interaction.MsgBox("No updates available.", Constants.vbInformation, Application.ProductName);
                        }

                        break;
                    }
                case UpdateCheckResult.UpdateError:
                    {
                        Interaction.MsgBox("Unable to run update at this time. Please try again later.", Constants.vbInformation, Application.ProductName);
                        break;
                    }
            }

            // Clean up files used to check
            Updater.CleanUpFiles();

        }

        // Converts a US Decimal to a EU Decimal
        public static string ConvertUStoEUDecimal(string USFormattedValue)
        {
            string TempString;

            TempString = USFormattedValue;

            // First replace any periods with pipes
            TempString = TempString.Replace(".", "|");

            // Now change the commas to periods
            TempString = TempString.Replace(",", ".");

            // Now change the pipes to commas
            TempString = TempString.Replace("|", ",");

            // Last update, re-set the names for R.A.M.s and R.Dbs back
            TempString = TempString.Replace("R,A,M,", "R.A.M.");
            TempString = TempString.Replace("R,Db", "R.Db");

            return TempString;

        }

        public static string ConvertEUDecimaltoUSDecimal(string EUFormatedValue)
        {
            string TempValue = EUFormatedValue;

            // EU string can be 1.000.000,00 or 1000000,00
            if (EUFormatedValue.Contains(","))
            {
                // This is the EU decimal so change to US version
                TempValue = EUFormatedValue.Replace(",", ".");
            }

            return TempValue;

        }

        public static string ConvertPriceHistoryEUDecimal(string HistoryValue)
        {
            string TempValue = HistoryValue;

            if (Strings.Len(HistoryValue) > 2)
            {
                if (HistoryValue.Substring(Strings.Len(HistoryValue) - 3, 1) == ",")
                {
                    // EU value, so convert remove the decimals
                    TempValue = HistoryValue.Replace(".", "");
                    TempValue = TempValue.Replace(",", ".");
                }
                // Both formats need commas removed if there are any
                TempValue = TempValue.Replace(",", "");
            }

            return TempValue;

        }

        // MD5 Hash - specify the path to a file and this routine will calculate your hash
        public static string MD5CalcFile(string filepath)
        {

            // Open file (as read-only) - If it's not there, return ""
            if (File.Exists(filepath))
            {
                using (var reader = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    using (var md5 = new MD5CryptoServiceProvider())
                    {

                        // hash contents of this stream
                        byte[] hash = md5.ComputeHash(reader);
                        var sb = new System.Text.StringBuilder(hash.Length * 2);

                        for (int i = 0, loopTo = hash.Length - 1; i <= loopTo; i++)
                            sb.Append(hash[i].ToString("X2"));

                        return sb.ToString().ToLower();

                    }
                }
            }

            // Something went wrong
            return "";

        }

        // SHA Hash
        public static string HashSHA(string InputString)
        {
            try
            {
                var sha512 = SHA512.Create();
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(InputString);
                byte[] hash = sha512.ComputeHash(bytes);
                var stringBuilder = new System.Text.StringBuilder();

                for (int i = 0, loopTo = hash.Length - 1; i <= loopTo; i++)
                    stringBuilder.Append(hash[i].ToString("X2"));

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        // Writes a sent message to a log file
        public static void WriteMsgToLog(string ErrorMsg)
        {
            string FilePath = Path.Combine(DynamicFilePath, "EVEIPH.log");
            string[] AllText;

            if (!File.Exists(FilePath))
            {
                var sw = File.CreateText(FilePath);
                sw.Close();
            }

            // This is an easier way to get all of the strings in the file.
            AllText = File.ReadAllLines(FilePath);
            // This will append the string to the end of the file.
            My.MyProject.Computer.FileSystem.WriteAllText(FilePath, Conversions.ToString(DateTime.Now) + ", " + ErrorMsg + Environment.NewLine + Environment.NewLine + "---" + Environment.NewLine, true);

        }

        // Function will take a string and return it in a DB friendly format - ie if it has single quotes in the string
        public static string FormatDBString(string inStrVar)
        {
            // Anything with quote mark in name it won't correctly load - need to replace with double quotes
            if (Strings.InStr(inStrVar, "'") != 0)
            {
                inStrVar = Strings.Replace(inStrVar, "'", "''");
            }
            return inStrVar;
        }

        // Formats the value sent to what we want to insert into the table field
        public static string BuildInsertFieldString(object inValue)
        {
            object CheckNullValue;
            string OutputString;

            // See if it is null first
            CheckNullValue = CheckNull(inValue);

            if (Conversions.ToString(CheckNullValue) != "null")
            {
                // Not null, so format
                if (inValue.GetType().Name == "DateTime")
                {
                    OutputString = "'" + Strings.Format(inValue, SQLiteDateFormat) + "'";
                }
                else if (inValue.GetType().Name != "String")
                {
                    // Just a value, so no quotes needed
                    OutputString = Conversions.ToString(inValue);
                }
                else
                {
                    // String, so check for appostrophes and add quotes
                    OutputString = "'" + FormatDBString(Conversions.ToString(inValue)) + "'";
                }
            }
            else
            {
                OutputString = "NULL";
            }

            return OutputString;

        }

        // Returns the ore processing skill level from the objects on the tab for the ore name sent 
        public static int GetFormOreProcessingSkill(string OreName, Label[] Labels, ComboBox[] Combos)
        {
            int i;
            string CurrentProcessingLabel;

            var loopTo = Combos.Count() - 1;
            for (i = 1; i <= loopTo; i++)
            {
                CurrentProcessingLabel = Labels[i].Text;

                if (Combos[i].Enabled == true & Conversions.ToBoolean(Strings.InStr(GetOreProcessingSkillName(OreName), CurrentProcessingLabel)))
                {
                    // Found it, return value
                    return Conversions.ToInteger(Combos[i].Text);
                }
            }

            return 0;

        }

        public static string GetOreProcessingSkillName(string OreName)
        {
            SQLiteDataReader rsCheck;
            string SQL;
            string FoundOreName = "";

            SQL = "SELECT value FROM TYPE_ATTRIBUTES AS TA, INVENTORY_TYPES AS IT WHERE TA.typeID = IT.typeID AND attributeID = " + ((int)ItemAttributes.reprocessingSkillType).ToString();
            SQL += " AND typeName = '" + OreName + "'";
            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            rsCheck = DBCommand.ExecuteReader();

            if (rsCheck.Read())
            {
                FoundOreName = GetTypeName((int)Math.Round(rsCheck.GetDouble(0)));
            }

            rsCheck.Close();

            return FoundOreName;

        }

        private static object CheckNull(object inVariable)
        {
            if (inVariable == null)
            {
                return "null";
            }
            else if (DBNull.Value.Equals(inVariable))
            {
                return "null";
            }
            else
            {
                return inVariable;
            }
        }

        public static int FormatNullInteger(object inVariable)
        {
            if (Conversions.ToString(CheckNull(inVariable)) == "null")
            {
                return 0;
            }
            else
            {
                return Conversions.ToInteger(inVariable);
            }
        }

        public static long FormatNullLong(object inVariable)
        {
            if (Conversions.ToString(CheckNull(inVariable)) == "null")
            {
                return 0L;
            }
            else
            {
                return Conversions.ToLong(inVariable);
            }
        }

        public static double FormatNullDouble(object inVariable)
        {
            if (Conversions.ToString(CheckNull(inVariable)) == "null")
            {
                return 0d;
            }
            else
            {
                return Conversions.ToDouble(inVariable);
            }
        }

        public static DateTime FormatNullDate(object inVariable)
        {
            if (Conversions.ToString(CheckNull(inVariable)) == "null")
            {
                return NoDate;
            }
            else
            {
                return Conversions.ToDate(inVariable);
            }
        }

        public static string FormatNullString(object inVariable)
        {
            if (Conversions.ToString(CheckNull(inVariable)) == "null")
            {
                return "";
            }
            else
            {
                return Conversions.ToString(inVariable);
            }
        }

        // Finds the T1 material for a T2 blueprint
        public static Material GetT1Material(long BlueprintID)
        {
            string SQL;
            SQLiteDataReader readerLookup;
            Material TempMat;
            long T1BPID = 0L;

            // Look up the blueprint we used to invent from the sent blueprint ID
            SQL = "Select blueprintTypeID from INDUSTRY_ACTIVITY_PRODUCTS WHERE productTypeID = " + BlueprintID + " And activityID = 8";

            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            readerLookup = DBCommand.ExecuteReader();

            if (readerLookup.Read())
            {
                T1BPID = readerLookup.GetInt64(0);
                readerLookup.Close();

                // Select all materials now
                SQL = "Select ITEM_ID, ITEM_NAME, ITEM_GROUP FROM ALL_BLUEPRINTS WHERE BLUEPRINT_ID =" + T1BPID;

                DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
                readerLookup = DBCommand.ExecuteReader();

                readerLookup.Read();
                TempMat = new Material(readerLookup.GetInt64(0), readerLookup.GetString(1), readerLookup.GetString(2), 1L, 1d, 0d, "0", "0");
                readerLookup.Close();
            }

            else
            {
                readerLookup.Close();
                return null;
            }

            return TempMat;

        }

        // Takes the BP ID and relic name (if sent) and returns the TypeID for the item to invent that BP
        public static long GetInventItemTypeID(long BlueprintTypeID, string RelicName)
        {
            string SQL;
            SQLiteDataReader rsCheck;
            long InventItemTypeID = 0L;

            // What is the item we are using to invent?
            SQL = "SELECT blueprintTypeID from INDUSTRY_ACTIVITY_PRODUCTS, INVENTORY_TYPES WHERE productTypeID = " + BlueprintTypeID + " ";
            SQL += "AND typeID = blueprintTypeID And activityID = 8";

            if (!string.IsNullOrEmpty(RelicName))
            {
                // Need to add the relic variant to the query for just one item
                SQL += " And typeName Like '%" + RelicName + "%'";
            }

            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            rsCheck = DBCommand.ExecuteReader();

            if (rsCheck.Read())
            {
                InventItemTypeID = rsCheck.GetInt64(0);
            }

            rsCheck.Close();

            return InventItemTypeID;

        }

        // Returns the text race for the ID sent
        public static string GetRace(int RaceID)
        {
            SQLiteDataReader rsLookup;

            DBCommand = new SQLiteCommand("SELECT RACE FROM RACE_IDS WHERE ID = " + RaceID.ToString(), EVEDB.DBREf());
            rsLookup = DBCommand.ExecuteReader();

            if (rsLookup.Read())
            {
                return rsLookup.GetString(0);
            }
            else
            {
                return "";
            }
        }

        // Updates the shopping list with new prices
        public static void UpdateShoppingListPrices()
        {
            // Update the shopping list if there is anything there
            if (TotalShoppingList.GetNumShoppingItems() != 0L)
            {
                TotalShoppingList.UpdateListPrices();
                // Refresh the lists
                frmShop.RefreshLists();
            }
        }

        // Deletes all the public structures from the stations table
        public static void ResetPublicStructureData()
        {
            string SQL = "DELETE FROM STATIONS WHERE STATION_ID > 70000000 AND MANUAL_ENTRY = 0";
            EVEDB.ExecuteNonQuerySQL(SQL);
        }

        // Try to catch exceptions when the clipboard errors for whatever reason
        public static void CopyTextToClipboard(string TextToCopy)
        {
            var ClipboardData = new DataObject();

            try // Try to catch exceptions when the clipboard errors for whatever reason: 
            {
                ClipboardData.SetData(DataFormats.Text, TextToCopy);
                Clipboard.SetDataObject(ClipboardData, true);
            }
            catch (Exception ex)
            {
                // One error could be: Requested Clipboard operation did not succeed.
                Interaction.MsgBox("Copy to Clipboard Failed: " + ex.Message + " Source: " + ex.Source, Constants.vbCritical, Application.ProductName);
            }

        }

        public static string GetBlueprintSQLWhereQuery(bool AmmoCharges, bool Drones, bool Modules, bool Ships, bool Subsystems, bool Boosters, bool Components, bool Misc, bool Deployables, bool Celestials, bool Structures, bool StructureRigs, bool StructureModules, bool Reactions, bool Rigs)
        {

            string ReturnClause = "";

            if (AmmoCharges)
            {
                ReturnClause += "ITEM_CATEGORY = 'Charge'";
            }
            else if (Drones)
            {
                ReturnClause += "ITEM_CATEGORY in ('Drone', 'Fighter')";
            }
            else if (Modules)
            {
                ReturnClause += "(ITEM_CATEGORY ='Module' AND ITEM_GROUP NOT LIKE 'Rig%')";
            }
            else if (Ships)
            {
                ReturnClause += "ITEM_CATEGORY = 'Ship'";
            }
            else if (Subsystems)
            {
                ReturnClause += "ITEM_CATEGORY = 'Subsystem'";
            }
            else if (Boosters)
            {
                ReturnClause += "ITEM_CATEGORY = 'Implant'";
            }
            else if (Components)
            {
                ReturnClause += "(ITEM_GROUP LIKE '%Components%' AND ITEM_GROUP <> 'Station Components')";
            }
            else if (Misc)
            {
                ReturnClause += "ITEM_GROUP IN ('Tool','Data Interfaces','Cyberimplant','Fuel Block')";
            }
            else if (Deployables)
            {
                ReturnClause += "ITEM_CATEGORY = 'Deployable'";
            }
            else if (Celestials)
            {
                ReturnClause += "ITEM_CATEGORY IN ('Celestial','Orbitals','Sovereignty Structures', 'Station', 'Accessories', 'Infrastructure Upgrades') ";
            }
            else if (Structures)
            {
                ReturnClause += "(ITEM_CATEGORY IN ('Starbase','Structure') OR ITEM_GROUP = 'Station Components')";
            }
            else if (StructureRigs)
            {
                ReturnClause += "ITEM_CATEGORY = 'Structure Rigs' ";
            }
            else if (StructureModules)
            {
                ReturnClause += "(ITEM_CATEGORY = 'Structure Module' AND ITEM_GROUP NOT LIKE '%Rig%')";
            }
            else if (Reactions)
            {
                ReturnClause += "BLUEPRINT_GROUP LIKE '%Reaction Formulas'";
            }
            else if (Rigs)
            {
                ReturnClause += "(BLUEPRINT_GROUP = 'Rig Blueprint' OR (ITEM_CATEGORY = 'Structure Module' AND ITEM_GROUP LIKE '%Rig%'))";
            }

            return ReturnClause;

        }

        // Deletes all data related to blueprints for the selected character and corporation they are part
        public static void ResetAllBPData()
        {
            string SQL;

            string CorpID = SelectedCharacter.CharacterCorporation.CorporationID.ToString();
            string IDList = "(" + CorpID + SelectedCharacter.ID.ToString() + "," + "," + CommonLoadBPsID.ToString() + ",0)";

            EVEDB.BeginSQLiteTransaction();

            SQL = "DELETE FROM OWNED_BLUEPRINTS WHERE USER_ID IN (" + SelectedCharacter.ID.ToString() + "," + CorpID + "," + CommonLoadBPsID.ToString() + ",0)";
            EVEDB.ExecuteNonQuerySQL(SQL);

            SQL = "UPDATE ESI_CHARACTER_DATA SET BLUEPRINTS_CACHE_DATE = '1900-01-01 00:00:00' WHERE CHARACTER_ID IN (" + SelectedCharacter.ID.ToString() + "," + CommonLoadBPsID.ToString() + ",0)";
            EVEDB.ExecuteNonQuerySQL(SQL);

            SQL = "UPDATE ESI_CORPORATION_DATA SET BLUEPRINTS_CACHE_DATE = '1900-01-01 00:00:00' WHERE CORPORATION_ID = " + CorpID;
            EVEDB.ExecuteNonQuerySQL(SQL);

            EVEDB.CommitSQLiteTransaction();

            Interaction.MsgBox("Blueprints reset", Constants.vbInformation, Application.ProductName);

        }

        // Sets an existing bp in the DB to the ME/TE or adds it if not in DB as a new owned blueprint - this is always due to user input, not API
        public static BPType UpdateBPinDB(long BPID, int bpME, int bpTE, BPType SentBPType, int OriginalME, int OriginalTE, bool Favorite = false, bool Ignore = false, double AdditionalCosts = 0d, bool RemoveAll = false)
        {
            string SQL;
            SQLiteDataReader readerBP;
            SQLiteDataReader rsMaxRuns;
            string TempFavorite;
            string TempIgnore;
            string TempOwned;
            BPType UpdatedBPType;
            string BPName = "";
            int BPGroup = 0;
            int UserRuns;

            if (SentBPType == BPType.NotOwned & (bpME != OriginalME | bpTE != OriginalTE))
            {
                // Can't update the ME/TE and not saved as owned
                UpdatedBPType = BPType.Copy; // save all as copy
            }
            else
            {
                UpdatedBPType = SentBPType;
            }

            if (UpdatedBPType == BPType.Original)
            {
                UserRuns = -1;
            }
            else
            {
                DBCommand = new SQLiteCommand("SELECT MAX_PRODUCTION_LIMIT FROM ALL_BLUEPRINTS WHERE BLUEPRINT_ID = " + BPID.ToString(), EVEDB.DBREf());
                rsMaxRuns = DBCommand.ExecuteReader();
                if (rsMaxRuns.Read())
                {
                    UserRuns = rsMaxRuns.GetInt32(0);
                }
                else
                {
                    UserRuns = 0;
                }
                rsMaxRuns.Close();
            }

            // Look BP Name and group up
            DBCommand = new SQLiteCommand("SELECT typeName, groupID FROM INVENTORY_TYPES WHERE typeID = " + BPID.ToString(), EVEDB.DBREf());
            readerBP = DBCommand.ExecuteReader();
            if (readerBP.Read())
            {
                BPName = readerBP.GetString(0);
                BPGroup = readerBP.GetInt32(1);
            }
            readerBP.Close();

            // See what ID we use for character bps
            long CharID = 0L;
            if (SettingsVariables.UserApplicationSettings.LoadBPsbyChar)
            {
                // Use the ID sent
                CharID = SelectedCharacter.ID;
            }
            else
            {
                CharID = CommonLoadBPsID;
            }

            EVEDB.BeginSQLiteTransaction();

            // If they are setting to not owned, not updating the ME/TE and not saving favorite or ignore, then remove the bp
            if (UpdatedBPType == BPType.NotOwned & Favorite == false & Ignore == false | RemoveAll)
            {

                // Look up the BP first to see if it is scanned
                SQL = "SELECT 'X' FROM OWNED_BLUEPRINTS ";
                SQL += "WHERE (USER_ID =" + CharID.ToString() + " Or USER_ID =" + SelectedCharacter.CharacterCorporation.CorporationID + ") ";
                SQL += "AND BLUEPRINT_ID =" + BPID.ToString() + " AND SCANNED <> 0";

                DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
                readerBP = DBCommand.ExecuteReader();
                readerBP.Read();

                // If Found then update then just reset the owned flag - might be scanned
                if (readerBP.HasRows)
                {
                    // Update it
                    SQL = "UPDATE OWNED_BLUEPRINTS Set OWNED = 0, ME = 0, TE = 0, FAVORITE = 0, BP_TYPE = 0 ";
                    SQL += "WHERE (USER_ID =" + CharID.ToString() + " Or USER_ID =" + SelectedCharacter.CharacterCorporation.CorporationID + ") ";
                    SQL += "And BLUEPRINT_ID =" + BPID.ToString();
                    EVEDB.ExecuteNonQuerySQL(SQL);
                }
                else
                {
                    // Just delete the record since it's not scanned
                    SQL = "DELETE FROM OWNED_BLUEPRINTS WHERE USER_ID=" + CharID + " And BLUEPRINT_ID=" + BPID;
                    EVEDB.ExecuteNonQuerySQL(SQL);
                }

                // Update the bp ignore flag (note for all accounts on this pc)
                SQL = "UPDATE ALL_BLUEPRINTS_FACT SET IGNORE = 0 WHERE BLUEPRINT_ID = " + BPID.ToString();
                EVEDB.ExecuteNonQuerySQL(SQL);
            }

            else
            {

                // Set the flags
                if (!Favorite)
                {
                    TempFavorite = "0";
                }
                else
                {
                    TempFavorite = "1";
                }

                if (!Ignore)
                {
                    TempIgnore = "0";
                }
                else
                {
                    TempIgnore = "1";
                }

                // Set the owned flag, only mark this BP as owned if it's not the unowned type
                if (UpdatedBPType == BPType.NotOwned)
                {
                    TempOwned = "0"; // User updated, not owned
                }
                else
                {
                    TempOwned = "-1";
                } // User updated, user owned (not API)

                // For reactions, always set bpME and bpTE to zero because they can't be researched
                if (BPGroup == 1888 | BPGroup == 1889 | BPGroup == 1890 | BPGroup == 4097)
                {
                    bpME = 0;
                    bpTE = 0;
                }

                // See if the BP is in the DB
                SQL = "SELECT TE FROM OWNED_BLUEPRINTS WHERE (USER_ID =" + CharID.ToString() + " OR USER_ID =" + SelectedCharacter.CharacterCorporation.CorporationID + ") ";
                SQL += "AND BLUEPRINT_ID =" + BPID.ToString();

                DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
                readerBP = DBCommand.ExecuteReader();
                readerBP.Read();

                if (!readerBP.HasRows)
                {
                    // No record, So add it and mark as owned (code 2) - save the scanned data if it was scanned - no item id or location id (from API), so set to 0 on manual saves
                    SQL = "INSERT INTO OWNED_BLUEPRINTS (USER_ID, ITEM_ID, LOCATION_ID, BLUEPRINT_ID, BLUEPRINT_NAME, QUANTITY, FLAG_ID, ";
                    SQL += "ME, TE, RUNS, BP_TYPE, OWNED, SCANNED, FAVORITE, ADDITIONAL_COSTS) ";
                    SQL += "VALUES (" + CharID + ",0,0," + BPID + ",'" + FormatDBString(BPName) + "',1,0,";
                    SQL += bpME.ToString() + "," + bpTE.ToString() + "," + UserRuns.ToString() + "," + ((int)UpdatedBPType).ToString() + "," + TempOwned + ",0," + TempFavorite + "," + AdditionalCosts.ToString() + ")";
                    EVEDB.ExecuteNonQuerySQL(SQL);
                }

                else
                {
                    // Update it
                    SQL = "UPDATE OWNED_BLUEPRINTS SET ME = " + bpME.ToString() + ", TE = " + bpTE.ToString() + ", OWNED = " + TempOwned + ", FAVORITE = " + TempFavorite;
                    SQL += ", ADDITIONAL_COSTS = " + AdditionalCosts.ToString() + ", BP_TYPE = " + ((int)UpdatedBPType).ToString() + ", RUNS = " + UserRuns.ToString() + " ";
                    SQL += "WHERE (USER_ID =" + CharID.ToString() + " OR USER_ID =" + SelectedCharacter.CharacterCorporation.CorporationID + ") ";
                    SQL += "AND BLUEPRINT_ID =" + BPID.ToString();
                    EVEDB.ExecuteNonQuerySQL(SQL);
                }

                // Update the bp ignore flag (note for all accounts on this pc)
                SQL = "UPDATE ALL_BLUEPRINTS_FACT SET IGNORE = " + TempIgnore + " WHERE BLUEPRINT_ID = " + BPID.ToString();
                EVEDB.ExecuteNonQuerySQL(SQL);

            }

            readerBP.Close();

            EVEDB.CommitSQLiteTransaction();

            return UpdatedBPType;

        }

        // Downloads the sent file from server and saves it to the root directory as the sent file name
        public static string DownloadFileFromServer(string DownloadURL, string FileName)
        {
            // Creating the request And getting the response
            HttpWebResponse Response;
            HttpWebRequest Request;

            // For reading in chunks of data
            var readBytes = new byte[4096];
            // Create directory if it doesn't exist already
            if (!Directory.Exists(Path.GetDirectoryName(FileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FileName));
            }
            var writeStream = new FileStream(FileName, FileMode.Create);
            int bytesread;

            try // Checks if the file exist
            {
                Request = (HttpWebRequest)WebRequest.Create(DownloadURL);
                Request.Proxy = GetProxyData();
                Request.Credentials = CredentialCache.DefaultCredentials; // Added 9/27 to attempt to fix error: (407) Proxy Authentication Required.
                Request.Timeout = 50000;
                Response = (HttpWebResponse)Request.GetResponse();
            }
            catch (Exception ex)
            {
                // Show error and exit
                // Close the streams
                writeStream.Close();
                Interaction.MsgBox("An error occurred while downloading update file: " + ex.Message, Constants.vbCritical, Application.ProductName);
                return "";
            }

            // Loop through and get the file in chunks, save out
            do
            {
                bytesread = Response.GetResponseStream().Read(readBytes, 0, 4096);

                // No more bytes to read
                if (bytesread == 0)
                    break;

                writeStream.Write(readBytes, 0, bytesread);
            }
            while (true);

            // Close the streams
            Response.GetResponseStream().Close();
            writeStream.Close();

            // Finally, check if the file is xml or text and adjust the lf to crlf (git saves as unix or lf only)
            if (FileName.Contains(".txt")) // Or FileName.Contains(".xml") Then
            {
                string FileText = File.ReadAllText(FileName);
                FileText = FileText.Replace("\n", Constants.vbCrLf);
                // Write the file back out if it's been updated
                File.WriteAllText(FileName, FileText);
            }

            return FileName;

        }

        public static WebProxy GetProxyData()
        {
            WebProxy ReturnProxy;

            if (!string.IsNullOrEmpty(SettingsVariables.UserApplicationSettings.ProxyAddress))
            {
                if (SettingsVariables.UserApplicationSettings.ProxyPort != 0)
                {
                    ReturnProxy = new WebProxy(SettingsVariables.UserApplicationSettings.ProxyAddress, SettingsVariables.UserApplicationSettings.ProxyPort);
                }
                else
                {
                    ReturnProxy = new WebProxy(SettingsVariables.UserApplicationSettings.ProxyAddress);
                }

                ReturnProxy = new WebProxy(SettingsVariables.UserApplicationSettings.ProxyAddress, SettingsVariables.UserApplicationSettings.ProxyPort);
                ReturnProxy.Credentials = CredentialCache.DefaultCredentials;

                return ReturnProxy;
            }
            else
            {
                return null;
            }

        }

        // Looks up the relic based on the decryptor used and the runs sent on the bp the relic created
        public static string GetRelicfromInputs(Decryptor DecryptorUsed, long BPID, int BPRuns)
        {

            int BaseRuns = BPRuns - DecryptorUsed.RunMod; // Adjust runs for look up
            string SQL;
            SQLiteDataReader readerBP;
            string ReturnString;

            SQL = "SELECT typeName, quantity FROM INVENTORY_TYPES, INDUSTRY_ACTIVITY_PRODUCTS ";
            SQL += "WHERE typeID = blueprintTypeID AND activityID = 8 AND productTypeID = " + BPID.ToString() + " AND quantity <= " + BaseRuns;

            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            readerBP = DBCommand.ExecuteReader();

            if (readerBP.Read())
            {
                ReturnString = readerBP.GetString(0);
            }
            else
            {
                ReturnString = "";
            }

            readerBP.Close();

            return ReturnString;

        }

        // Parses the data and builds an AND qualifier for searching text data - adds data for two fields sent
        public static string GetSearchText(string SearchText, string Field1, string Field2 = "")
        {
            string ReturnString = "";
            string LikePhrase = " LIKE ";
            string NOTLikePhrase = " NOT LIKE ";

            string[] SearchItems = null;
            string[] NotSearchItems = null;
            string SearchItemList = "";
            string NotSearchItemList = "";

            string SearchClause = "";
            string NotSearchClause = "";

            if (string.IsNullOrEmpty(Strings.Trim(SearchText)) | string.IsNullOrEmpty(Field1))
            {
                return "";
            }

            // Options
            // 1 - 'mining crystal not rig, jaspet' - want mining crystals but not the mercoxit mining crystal rig or jaspet mining crystals
            // 2 - 'Hulk, Mackinaw, Skiff' - want only these three
            // 3 - 'NOT Hulk, Mackinaw, Skiff' - don't want these three but all others

            // See if it has not and if larger than three characters, allow it to be set - test 'bob NOT '
            if (Strings.UCase(SearchText).Contains("NOT ") & Strings.Trim(SearchText).Length > 4)
            {
                // Find where the NOT is in the string
                int NotLocation = Strings.InStr(Strings.UCase(SearchText), "NOT ");

                // If it's at the beginning, then the rest is a not phrase
                if (NotLocation == 0)
                {
                    // Strip off the not and add
                    SearchText = Strings.Trim(SearchText.Substring(4));
                    NotSearchItemList = Strings.Trim(SearchText);
                }
                else
                {
                    // split and Strip off the NOT at the beginning 
                    SearchItemList = FormatDBString(SearchText.Substring(0, NotLocation - 1));
                    NotSearchItemList = FormatDBString(SearchText.Substring(NotLocation + 3));
                }
            }
            else
            {
                // Just search for the terms
                SearchItemList = FormatDBString(SearchText);
            }

            // Parse by comma then loop through items to build clauses
            if (!string.IsNullOrEmpty(SearchItemList))
            {
                SearchItems = SearchItemList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (!string.IsNullOrEmpty(NotSearchItemList))
            {
                NotSearchItems = NotSearchItemList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            // Build the like search items
            if (!(SearchItems == null))
            {
                for (int i = 0, loopTo = SearchItems.Count() - 1; i <= loopTo; i++)
                {
                    SearchClause = SearchClause + "(" + Field1 + LikePhrase + "'%" + Strings.Trim(SearchItems[i]) + "%' ";
                    if (!string.IsNullOrEmpty(Field2))
                    {
                        SearchClause = SearchClause + "OR " + Field2 + LikePhrase + "'%" + Strings.Trim(SearchItems[i]) + "%') OR ";
                    }
                    else
                    {
                        SearchClause = SearchClause + ") OR ";
                    }
                }

                // Clean up the clause
                SearchClause = "(" + SearchClause.Substring(0, SearchClause.Length - 4) + ")"; // Strip off the and

            }

            // Do the other phrase if needed
            if (!(NotSearchItems == null))
            {
                for (int i = 0, loopTo1 = NotSearchItems.Count() - 1; i <= loopTo1; i++)
                {
                    NotSearchClause = NotSearchClause + "(" + Field1 + " " + NOTLikePhrase + "'%" + Strings.Trim(NotSearchItems[i]) + "%' ";
                    if (!string.IsNullOrEmpty(Field2))
                    {
                        NotSearchClause = NotSearchClause + "AND " + Field2 + " " + NOTLikePhrase + "'%" + Strings.Trim(NotSearchItems[i]) + "%') AND ";
                    }
                    else
                    {
                        NotSearchClause = NotSearchClause + ") AND ";
                    }
                }

                // Clean up clause
                NotSearchClause = "(" + NotSearchClause.Substring(0, NotSearchClause.Length - 5) + ")"; // Strip off the and

            }

            if (!string.IsNullOrEmpty(SearchClause) & !string.IsNullOrEmpty(NotSearchClause))
            {
                ReturnString = "(" + SearchClause + " AND " + NotSearchClause + ")";
            }
            else if (!string.IsNullOrEmpty(SearchClause))
            {
                ReturnString = SearchClause;
            }
            else
            {
                ReturnString = NotSearchClause;
            }

            return ReturnString;

        }

        // Gets the typeName from inventory types for the typeID sent
        public static string GetTypeName(int TypeID)
        {
            string SQL;
            SQLiteDataReader readerIT;
            string ReturnString;

            SQL = "SELECT typeName FROM INVENTORY_TYPES WHERE typeID = " + TypeID.ToString();

            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            readerIT = DBCommand.ExecuteReader();

            if (readerIT.Read())
            {
                ReturnString = readerIT.GetString(0);
            }
            else
            {
                ReturnString = "";
            }

            readerIT.Close();

            return ReturnString;

        }

        // Gets the groupName from inventory groups for the groupID sent
        public static string GetGroupName(int groupID)
        {
            string SQL;
            SQLiteDataReader readerIT;
            string ReturnString;

            SQL = "SELECT groupName FROM INVENTORY_CATEGORIES WHERE groupID = " + groupID.ToString();

            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            readerIT = DBCommand.ExecuteReader();

            if (readerIT.Read())
            {
                ReturnString = readerIT.GetString(0);
            }
            else
            {
                ReturnString = "";
            }

            readerIT.Close();

            return ReturnString;

        }

        // Gets the categoryName from inventory categories for the categoryID sent
        public static string GetCategoryName(int categoryID)
        {
            string SQL;
            SQLiteDataReader readerIT;
            string ReturnString;

            SQL = "SELECT categoryName FROM INVENTORY_CATEGORIES WHERE categoryID = " + categoryID.ToString();

            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            readerIT = DBCommand.ExecuteReader();

            if (readerIT.Read())
            {
                ReturnString = readerIT.GetString(0);
            }
            else
            {
                ReturnString = "";
            }

            readerIT.Close();

            return ReturnString;

        }

        // Gets the typeid from inventory types for the typename sent
        public static long GetTypeID(string TypeName)
        {
            string SQL;
            SQLiteDataReader readerIT;
            long ReturnID;

            SQL = "SELECT typeID FROM INVENTORY_TYPES WHERE typeName = '" + FormatDBString(TypeName) + "'";

            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            readerIT = DBCommand.ExecuteReader();

            if (readerIT.Read())
            {
                ReturnID = readerIT.GetInt64(0);
            }
            else
            {
                ReturnID = 0L;
            }

            readerIT.Close();

            return ReturnID;

        }

        // Looks up the typeid for the mining bonus for different attributes related to mining and returns the value for everything except ships (those are invTraits)
        public static double GetMiningBonus(int TypeID)
        {
            string SQL;
            SQLiteDataReader readerBonus;
            double ReturnBonus;

            // It's a module - compressionQuantityNeeded and mining amounts
            SQL = "SELECT TYPE_ATTRIBUTES.attributeID, value AS Bonus ";
            SQL += "FROM TYPE_ATTRIBUTES, INVENTORY_TYPES, INVENTORY_GROUPS ";
            SQL += "WHERE TYPE_ATTRIBUTES.typeid = INVENTORY_TYPES.typeid ";
            SQL += "AND INVENTORY_TYPES.groupid = INVENTORY_GROUPS.groupid ";
            SQL += "AND TYPE_ATTRIBUTES.attributeid IN (434,77,1938,207,2458,428,1941,379,780,885) ";
            SQL += "AND INVENTORY_TYPES.groupID Not In (1,1218) And categoryID <> 6 ";
            SQL += "AND TYPE_ATTRIBUTES.typeID = " + TypeID.ToString();

            DBCommand = new SQLiteCommand(SQL, EVEDB.DBREf());
            readerBonus = DBCommand.ExecuteReader();

            if (readerBonus.Read())
            {
                ReturnBonus = readerBonus.GetDouble(0);
            }
            else
            {
                ReturnBonus = 0d;
            }

            readerBonus.Close();

            return ReturnBonus;

        }

        // Downloads the JSON file sent and saves it to the location, then imports it into a string to return
        public static string GetJSONFile(string URL, string UpdateType, bool IgnoreExceptions = false, int RecursiveCalls = 0)
        {
            HttpWebRequest request;
            HttpWebResponse response = null;
            StreamReader reader;

            string Output = "";

            if (CancelUpdatePrices)
            {
                return "";
            }

            try
            {
                var Start = DateTime.Now;
                var myUri = new Uri(URL);
                // /market/<regionID:integerType>/history/
                // Create the web request  
                request = (HttpWebRequest)WebRequest.Create(myUri);
                // Settings for speed
                request.Method = "GET";
                request.Proxy = GetProxyData();
                request.PreAuthenticate = true;
                request.Timeout = 10000;
                request.UnsafeAuthenticatedConnectionSharing = true;

                // Get response  
                response = (HttpWebResponse)request.GetResponse();
                long ContentLength = Conversions.ToLong(request.GetResponse().Headers[HttpResponseHeader.ContentLength]);

                // Get the response stream into a reader  
                reader = new StreamReader(response.GetResponseStream());

                // Read the data
                Output = Strings.Trim(reader.ReadToEnd());
                if ((Output.Substring(Strings.Len(Output) - 1, 1) ?? "") == Constants.vbLf)
                {
                    Output = Output.Substring(0, Strings.Len(Output) - 1);
                }

                // See if it downloaded a full file
                if (Strings.Len(Output) != ContentLength & ContentLength != 0L | Output.Substring(Strings.Len(Output) - 1, 1) != "]" & ContentLength == 0L)
                {
                    Application.DoEvents();
                    // Re-run this function - limit to 5 calls
                    if (RecursiveCalls <= 5)
                    {
                        int NumCalls = RecursiveCalls + 1;
                        Output = GetJSONFile(URL, UpdateType, IgnoreExceptions, NumCalls);
                    }
                }

                reader.Close();
                response.Close();
                request = null;
            }

            catch (Exception ex)
            {
                if (!IgnoreExceptions)
                {
                    Interaction.MsgBox("Unable to download data for " + UpdateType + Constants.vbCrLf + "Error: " + ex.Message, Constants.vbInformation, Application.ProductName);
                    if (UpdateType == "Fuzzwork Market Prices" | UpdateType == "EVE Marketer Prices")
                    {
                        // Don't error again
                        PriceUpdateDown = true;
                    }
                    Output = "";
                }

                if (ex.Message.Contains("An established connection was aborted by the software in your host machine") | ex.Message.Contains("An existing connection was forcibly closed by the remote host.") | ex.Message.Contains("503") & !IgnoreExceptions)

                // Or ex.Message.Contains("The operation has timed out")
                {
                    // Re-run this function - limit to 10 calls if not part of the first load of the program
                    if (RecursiveCalls <= 10 & !FirstLoad)
                    {
                        int NumCalls = RecursiveCalls + 1;
                        Output = GetJSONFile(URL, UpdateType, IgnoreExceptions, NumCalls);
                    }
                }
            }
            finally
            {
                if (response is not null)
                    response.Close();
            }

            return Output;

        }

        public class TypeIDRegion
        {
            public string RegionString;
            public List<string> TypeIDs;

            public TypeIDRegion()
            {
                RegionString = "";
                TypeIDs = new List<string>();
            }
        }

        public struct SystemRegion
        {
            public string SystemID; // could be empty string
            public string RegionID;
        }

    }
}