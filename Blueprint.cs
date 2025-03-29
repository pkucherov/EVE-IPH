using System;
using System.Collections.Generic;

// Class for Blueprint functions
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class Blueprint
    {

        // Base variables
        private int BlueprintID;
        private bool BaseBP; // for knowing the base bp opposed to component bps
        private string BlueprintName;
        private int BlueprintGroupID;
        private long ItemID;
        private string ItemName;
        private int ItemCategoryID;
        private string ItemGroup;
        private int ItemGroupID;
        private int TechLevel;
        private long PortionSize; // Number of items produced by one run of blueprint
        private long BaseProductionTime; // In seconds
        private int MaxProductionLimit;
        private int ItemType;
        private int BlueprintRace;
        private double ItemVolume; // Volume of produced item (1 item only)

        // If we compare the components for building or buying
        private bool BuildBuy;
        private bool HasBuildableComponents = false;
        private double AdditionalCosts;

        // Helps determine if this is a component that might need special processing
        private long BBItemtoFind;
        private List<Public_Variables.BuildBuyItem> BBList = new List<Public_Variables.BuildBuyItem>();
        private bool NewBPRequest;

        // Taxes/Fees
        // •	Buy - When you buy something off the market (Buy from someone’s Sell Order – So Minimum Sell), you don’t pay taxes or broker fees
        // o	No Tax, No Broker Fee
        // •	Sell Order - When you set up a sell order, you pay broker fees up front and taxes for items when sold. (This will be min sell usually)
        // o	Tax, Broker Fee
        // •	Buy Order - When you set up buy order, you pay broker fees up front but no tax when someone sells to you. (This is max buy usually).
        // o	No Tax, Broker Fee
        // •	Sell - When you Sell to a buy order (simple sell), you only pay taxes. (This will be Max buy)
        // o 	Tax, No Broker Fee

        private double Taxes; // See Above - Sell Order or Sell
        private double DisplayTaxes; // Public updatable number for display updates, for easy updates when clicked
        private double BrokerFees; // See above - Sell Order or Buy Order
        private double DisplayBrokerFees; // Public updatable number for display updates, for easy updates when clicked

        // New cost variables
        private double EIV; // Estimated Item Value - Total per material used * average price 
        private double BaseCopyJobCost; // Total job cost for copying (need to use the BPC job cost)
        private double BaseInventionJobCost; // Total job cost for invention (need to use the BPC job cost)

        // Base Fees for activity
        private double JobFee;
        private double AlphaCloneTax;
        private double TotalUsage;

        // How much it costs to use each facility to manufacture items and parts
        private double ManufacturingFacilityUsage;
        private bool IncludeManufacturingUsage;
        private double ReprocessingUsage;
        private double ComponentFacilityUsage;
        private double CapComponentFacilityUsage;
        private double ReactionFacilityUsage; // This stores the main reaction usage if the reaction is a composite and has other reactions
        private double TotalReactionFacilityUsage; // Total of all reaction facilities usage for totaling all reactions below a composite or collection of composites

        // Variables for calcuations
        private double BPProductionTime; // Production Time for 1 Run of Blueprint 
        private double TotalProductionTime; // Production Time for 1 run of BP plus any components (this is to compare buying components vs. making them)
        private int iME; // ME of Blueprint
        private int iTE; // TE of Blueprint
        private long UserRuns; // Number of runs for blueprint the user selects
        private int NumberofBlueprints; // Number of blueprints that the user is running
        private int NumberofProductionLines; // Number of production lines the user is using
        private int NumberofLaboratoryLines; // Number of laboratory lines the user is using
        private List<double> ComponentProductionTimes = new List<double>(); // A list of production times for components in this BP

        // Character skills we are making this blueprint with
        private Character BPCharacter; // The character for this BP
        private int IndustrySkill; // Industry skill level of character
        private int AdvancedIndustrySkill; // Old Production Efficiency skill, now reduces TE on building, reactions, researching
        private int ScienceSkill;
        private double AIImplantValue; // Advanced Industry Implant on character
        private double CopyImplantValue; // Copy implant value for this character

        private int CharAdvIndustialShipConstruction; // Industry skill for advanced indy ships (T2)
        private int CharAdvCapitalShipConstruction; // Industry skill for advanced Cap ships (T2) - Lancers

        private const int AdvISCSkill = 3396;
        private const int AdvCSCSkill = 77725;

        // Can do variables
        private bool CanInventRE; // if the sent character for the blueprint can invent it from a T1 or artifact
        private bool CanBuildBP; // if the user can build this BP
        private bool CanBuildAll; // if the user can build this BP and all components

        // Material lists
        public Materials RawMaterials; // The list of All Raw materials for this item including the raw mats to make the buildable components in info list
        public Materials ComponentMaterials; // List of all the required materials to make the item as shown in info list
        public BuiltItemList BuiltComponentList; // Saving all the materials for each built component
        private Materials BPRawMats; // Saves all the raw materials on the bp that are not built

        // Skills required to make it
        private EVESkillList ReqBuildSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels); // Just this BP
        private EVESkillList ReqBuildComponentSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels); // All the skills to build just the components

        // Invention variables
        private int MaxRunsPerBP; // The max runs for a copy or invented bpc. Zero is unlimited runs
        private EVESkillList ReqInventionSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels); // For inventing this BP
        private EVESkillList ReqCopySkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels); // For copying the BPC
        public Materials InventionMaterials;
        public Materials CopyMaterials; // Some copies require items
        private double InventionChance;
        private Decryptor InventionDecryptor = new Decryptor();
        private string Relic; // Name of relic
        private int TotalInventedRuns; // Number of runs all the invention jobs will produce
        private int SingleInventedBPCRuns; // The runs on one bp invented
        private int NumInventionJobs; // Number of invention jobs we will do
        private double PerInventionRunCost; // The cost per invention run based on the probability of success

        private double TotalCopyCost; // Total Cost of the BPCs for the T2 item - for copy materials for things like data sheets, etc when needed, and get enough successful inventions for these runs
        private double CopyCost; // Cost for the runs given
        private double CopyTime; // Total time in seconds to copy the BPCs needed for the T2 item
        private double CopyUsage; // Total Cost to make a copy

        private bool IncludeCopyTime;
        private bool IncludeCopyCosts;
        private bool IncludeCopyUsage;

        private double InventionCost; // Cost for the runs given 
        private double InventionTime; // Total time in seconds to invent this bp
        private double InventionUsage; // Total cost to do this activity in a facility

        private bool IncludeInventionCosts;
        private bool IncludeInventionTime;
        private bool IncludeInventionUsage; // just the facility usage, not the full cost use for both T2 and T3

        private double AdvManufacturingSkillLevelBonus; // The total TE reduction from skills required to invent and build this item (T2/T3)

        private long InventionBPCTypeID; // BP used to invent the BP we are building

        // Price Variables
        private double ItemMarketCost; // Market cost of item 
        private double TotalRawCost;
        private double TotalComponentCost;
        private double TotalRawProfit;
        private double TotalComponentProfit;
        private double TotalRawProfitPercent;
        private double TotalComponentProfitPercent;
        private double TotalIPHRaw;
        private double TotalIPHComponent;

        // Save all the settings here, which has all the standings, fees, etc in it
        private ApplicationSettings BPUserSettings;

        private BuildMatType T2T3MaterialType; // How do we build T2 and T3 items for components that are reactions and how deep they want to go

        private bool SellExcessItems;
        private double SellExcessAmount;
        private Materials ExcessMaterials; // This contains all materials for the entire blueprint as a reference
        private Materials BPExcessMaterials; // Just the excess for the bp
        private Materials UsedExcessMaterials; // List of materials updated by using from full excess list for updating BP list

        // What facility are they using to produce?
        private IndustryFacility MainManufacturingFacility;
        private IndustryFacility ComponentManufacturingFacility;
        private IndustryFacility CapitalComponentManufacturingFacility; // For all capital parts
        private IndustryFacility ReactionFacility;
        private IndustryFacility CopyFacility;
        private IndustryFacility InventionFacility;
        private IndustryFacility ReprocessingFacility;

        private ConversionToOreSettings OreConversionSettings;

        // This is to save the entire chain of blueprints on each line we have used and runs for each one
        private List<List<int>> ProductionChain;

        private double FWManufacturingCostBonus;
        private double FWCopyingCostBonus;
        private double FWInventionCostBonus;

        private List<int> ReactionBPGroups = new List<int>(new int[] { 1888, 1889, 1890, 4097 });

        private bool FulcrumBonusesApply;

        // BP Constructor
        public Blueprint(long BPBlueprintID, long BPRuns, int BPME, int BPTE, int NumBlueprints, int NumProductionLines, Character UserCharacter, ApplicationSettings UserSettings, bool BPBuildBuy, double UserAddlCosts, IndustryFacility BPProductionFacility, IndustryFacility BPComponentProductionFacility, IndustryFacility BPCapComponentProductionFacility, IndustryFacility BPReactionFacility, bool BPSellExcessItems, BuildMatType BuildT2T3MaterialType, bool OriginalBlueprint, [Optional] ref List<Public_Variables.BuildBuyItem> BuildBuyList, [Optional] ref IndustryFacility BPReprocessingFacility, ConversionToOreSettings CompressedOreSettings = default)
        {

            SQLiteDataReader readerBP;
            string SQL = "";

            SQL = "SELECT BLUEPRINT_ID, BLUEPRINT_GROUP_ID, ITEM_ID, ITEM_GROUP_ID, ITEM_CATEGORY_ID, ";
            SQL += "TECH_LEVEL, PORTION_SIZE, BASE_PRODUCTION_TIME, MAX_PRODUCTION_LIMIT, ITEM_TYPE, RACE_ID, packagedVolume ";
            SQL += "FROM ALL_BLUEPRINTS_FACT INNER JOIN INVENTORY_TYPES ON ALL_BLUEPRINTS_FACT.ITEM_ID = INVENTORY_TYPES.typeID ";
            SQL += "WHERE BLUEPRINT_ID =" + BPBlueprintID;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerBP = Public_Variables.DBCommand.ExecuteReader();

            if (readerBP.Read())
            {
                // Set the variables
                BlueprintID = readerBP.GetInt32(0);
                BlueprintName = Public_Variables.GetTypeName(readerBP.GetInt32(0));
                BlueprintGroupID = readerBP.GetInt32(1);
                ItemID = readerBP.GetInt64(2);
                ItemName = Public_Variables.GetTypeName(readerBP.GetInt32(2));
                ItemGroupID = readerBP.GetInt32(3);
                ItemCategoryID = readerBP.GetInt32(4);
                TechLevel = readerBP.GetInt32(5);
                PortionSize = readerBP.GetInt64(6);
                BaseProductionTime = readerBP.GetInt64(7);
                MaxProductionLimit = readerBP.GetInt32(8);
                ItemType = readerBP.GetInt32(9);

                if (!readerBP.IsDBNull(10))
                {
                    BlueprintRace = readerBP.GetInt32(10);
                }
                else
                {
                    BlueprintRace = 0;
                }
                if (!readerBP.IsDBNull(11))
                {
                    ItemVolume = readerBP.GetDouble(11) * PortionSize; // Ammo, blocks, bombs, etc have more items per run
                }
                else
                {
                    ItemVolume = 10d;
                }
            }
            else
            {
                return;
            }

            readerBP.Close();

            // Settings
            BPUserSettings = UserSettings;
            BaseBP = OriginalBlueprint;
            T2T3MaterialType = BuildT2T3MaterialType;

            RawMaterials = new Materials();
            ComponentMaterials = new Materials();
            InventionMaterials = new Materials();
            CopyMaterials = new Materials();

            TotalCopyCost = 0d;
            CopyTime = 0d;
            InventionTime = 0d;

            ManufacturingFacilityUsage = 0d;
            ComponentFacilityUsage = 0d;
            CapComponentFacilityUsage = 0d;
            ReactionFacilityUsage = 0d;
            TotalReactionFacilityUsage = 0d;
            ReprocessingUsage = 0d;

            CopyUsage = 0d;
            InventionUsage = 0d;

            EIV = 0d;
            JobFee = 0d;
            AlphaCloneTax = 0d;
            TotalUsage = 0d;

            InventionDecryptor = DecryptorVariables.NoDecryptor;
            Relic = "";
            TotalInventedRuns = 0;

            NumInventionJobs = 0;

            // Do build/buy 
            BuildBuy = BPBuildBuy;
            if (!(BuildBuyList == null))
            {
                BBList = BuildBuyList;
                NewBPRequest = false;
            }
            else
            {
                NewBPRequest = true;
            }

            SellExcessItems = BPSellExcessItems;
            SellExcessAmount = 0d;
            BPExcessMaterials = new Materials();
            ExcessMaterials = new Materials();
            UsedExcessMaterials = new Materials();

            iME = BPME;
            iTE = BPTE;

            Taxes = 0d;
            BrokerFees = 0d;

            // If they send zero lines, then set to the user skills
            if (NumProductionLines == 0) // 3387 mass production and 24625 is adv mass production
            {
                NumberofProductionLines = BPCharacter.Skills.GetSkillLevel(3387L) + BPCharacter.Skills.GetSkillLevel(24625L) + 1;
            }
            else
            {
                NumberofProductionLines = NumProductionLines;
            }

            UserRuns = BPRuns;
            NumberofBlueprints = NumBlueprints;
            AdditionalCosts = UserAddlCosts;

            // If TechLevel > 1 Then
            // UserRuns = CInt(Math.Ceiling(BPRuns / PortionSize))
            // Else
            UserRuns = BPRuns;
            // End If

            BPCharacter = UserCharacter;

            // Set the skills to use for this blueprint - changed to type ID's due to name changes (1/29/2014)
            if (Public_Variables.IsReaction(ItemGroupID))
            {
                // Advanced industry only affects manufacturing and research times
                AdvancedIndustrySkill = 0;
            }
            else
            {
                AdvancedIndustrySkill = BPCharacter.Skills.GetSkillLevel(3388L);
            }

            IndustrySkill = BPCharacter.Skills.GetSkillLevel(3380L);
            ScienceSkill = BPCharacter.Skills.GetSkillLevel(3402L);

            // Add production implant from settings
            AIImplantValue = 1d - UserSettings.ManufacturingImplantValue;

            // Production facilities
            MainManufacturingFacility = BPProductionFacility;
            ComponentManufacturingFacility = BPComponentProductionFacility;
            CapitalComponentManufacturingFacility = BPCapComponentProductionFacility;
            ReactionFacility = BPReactionFacility;

            OreConversionSettings = CompressedOreSettings;
            ReprocessingFacility = BPReprocessingFacility;

            FulcrumBonusesApply = Public_Variables.GetFulcrumBonusFlagforItem(MainManufacturingFacility.FacilityID, BlueprintID);

            // See if we want to include the costs
            IncludeManufacturingUsage = BPProductionFacility.IncludeActivityUsage;

            // Set the faction warfare bonus for the usage calculations
            switch (MainManufacturingFacility.FWUpgradeLevel)
            {
                case 1:
                    {
                        FWManufacturingCostBonus = 0.9d;
                        break;
                    }
                case 2:
                    {
                        FWManufacturingCostBonus = 0.8d;
                        break;
                    }
                case 3:
                    {
                        FWManufacturingCostBonus = 0.7d;
                        break;
                    }
                case 4:
                    {
                        FWManufacturingCostBonus = 0.6d;
                        break;
                    }
                case 5:
                    {
                        FWManufacturingCostBonus = 0.5d;
                        break;
                    }

                default:
                    {
                        FWManufacturingCostBonus = 1d;
                        break;
                    }
            }

            // Set the flag if the user sent to this blueprint can invent it
            CanInventRE = false; // Can invent T1 BP to this T2 BP
            CanBuildBP = true; // Can build BP (assume we can until we change it)
            CanBuildAll = true; // Can build all components (assume we can until we change it)

            HasBuildableComponents = false;

            // Full cost of items is portion size (ammo, bombs, etc) times runs times cost
            ItemMarketCost = Public_Variables.GetItemPrice(ItemID) * UserRuns * PortionSize;

            BuiltComponentList = new BuiltItemList();
            BPRawMats = new Materials();

            // Set the invention variables to default
            IncludeInventionCosts = false;
            IncludeInventionTime = false;
            IncludeInventionUsage = false;

            IncludeCopyCosts = false;
            IncludeCopyTime = false;
            IncludeCopyUsage = false;

            InventionChance = 0d;

            TotalInventedRuns = 0;
            SingleInventedBPCRuns = 0;
            NumInventionJobs = 0;

            TotalCopyCost = 0d;
            CopyTime = 0d;
            CopyUsage = 0d;

            InventionTime = 0d;
            InventionUsage = 0d;

            InventionDecryptor = DecryptorVariables.NoDecryptor;
            Relic = "";

            // 3406 laboratory operation and 24624 is adv laboratory operation
            NumberofLaboratoryLines = 0;

            // Save copy and invention facility
            CopyFacility = Public_Variables.NoFacility;
            InventionFacility = Public_Variables.NoFacility;

            // Invention variable inputs - The BPC or Relic first
            InventionBPCTypeID = 0L;

            // Set the Decryptor data
            InventionDecryptor = DecryptorVariables.NoDecryptor;

            // Implement passing in the runs per copy later based on user, right now though this is unlimited
            MaxRunsPerBP = 0;

            ProductionChain = new List<List<int>>();

        }

        public int InventBlueprint(int NumLaboratoryLines, Decryptor BPDecryptor, IndustryFacility BPInventionFacility, IndustryFacility BPCopyFacility, long InventionItemTypeID)
        {

            // 3406 laboratory operation and 24624 is adv laboratory operation
            NumberofLaboratoryLines = NumLaboratoryLines;

            // Save copy and invention facility
            CopyFacility = BPCopyFacility;
            InventionFacility = BPInventionFacility;

            // Refresh the data on these for blueprints - categoryID = 9
            CopyFacility.RefreshMMTMCMBonuses(0, 9);
            InventionFacility.RefreshMMTMCMBonuses(0, 9);

            // Set the FW bonus levels
            switch (CopyFacility.FWUpgradeLevel)
            {
                case 1:
                    {
                        FWCopyingCostBonus = 0.9d;
                        break;
                    }
                case 2:
                    {
                        FWCopyingCostBonus = 0.8d;
                        break;
                    }
                case 3:
                    {
                        FWCopyingCostBonus = 0.7d;
                        break;
                    }
                case 4:
                    {
                        FWCopyingCostBonus = 0.6d;
                        break;
                    }
                case 5:
                    {
                        FWCopyingCostBonus = 0.5d;
                        break;
                    }

                default:
                    {
                        FWCopyingCostBonus = 1d;
                        break;
                    }
            }

            switch (InventionFacility.FWUpgradeLevel)
            {
                case 1:
                    {
                        FWInventionCostBonus = 0.9d;
                        break;
                    }
                case 2:
                    {
                        FWInventionCostBonus = 0.8d;
                        break;
                    }
                case 3:
                    {
                        FWInventionCostBonus = 0.7d;
                        break;
                    }
                case 4:
                    {
                        FWInventionCostBonus = 0.6d;
                        break;
                    }
                case 5:
                    {
                        FWInventionCostBonus = 0.5d;
                        break;
                    }

                default:
                    {
                        FWInventionCostBonus = 1d;
                        break;
                    }
            }

            // Invention variable inputs - The BPC or Relic first
            InventionBPCTypeID = InventionItemTypeID;

            // Set the Decryptor data
            InventionDecryptor = BPDecryptor;

            // Invention and Copy costs/times are set after getting the full base job materials
            IncludeInventionCosts = InventionFacility.IncludeActivityCost;
            IncludeInventionTime = InventionFacility.IncludeActivityTime;
            IncludeInventionUsage = InventionFacility.IncludeActivityUsage;

            IncludeCopyCosts = CopyFacility.IncludeActivityCost;
            IncludeCopyTime = CopyFacility.IncludeActivityTime;
            IncludeCopyUsage = CopyFacility.IncludeActivityUsage;

            // Set the T2/T3 skills to invent from the T1 version
            SetInventionSkills();

            // Set the T2/T3 skills to copy from the T1 BPC
            SetCopySkills();

            // Set the invention flag
            CanInventRE = UserHasReqSkills(BPCharacter.Skills, ReqInventionSkills);

            // Use typical invention costs to invent this
            int InventedBPs = InventREBlueprint(!CanInventRE);

            // Save the max runs per invented bpc
            MaxRunsPerBP = SingleInventedBPCRuns;

            // Reset the number of bps needed based on the runs we have
            NumberofBlueprints = (int)Math.Round(Math.Ceiling(UserRuns / (double)MaxRunsPerBP));

            return InventedBPs;

        }

        // Base build function that takes a look at the number of blueprints the user wants to use and then builts each blueprint batch
        public void BuildItems(bool SetTaxes, Public_Variables.BrokerFeeInfo BrokerFeeData, bool SetProductionCosts, bool IgnoreMinerals, bool IgnoreT1Item)
        {

            // Need to check for the number of BPs sent and run multiple Sessions if necessary. Also, look at the number of lines per batch
            if (NumberofBlueprints == 1)
            {
                // Just run the normal function and it will set everything
                BuildItem(SetTaxes, BrokerFeeData, SetProductionCosts, IgnoreMinerals, IgnoreT1Item, ref ExcessMaterials);
            }
            else // Multi bps
            {
                Blueprint BatchBlueprint;
                Blueprint ComponentBlueprint;

                int RunsPerLine;
                int ExtraRuns;
                int AdjRunsperBP;

                var BatchList = new List<int>();
                int Batches;

                if (UserRuns < NumberofBlueprints)
                {
                    // Can't run more bps than runs, so reset to the runs - 1 bp per run
                    NumberofBlueprints = (int)UserRuns;
                }

                // For bps with unlimited runs, assume that the most efficient is to run max runs on each line in one batch, 
                // so reset if bps are greater than lines
                if (MaxRunsPerBP == 0)
                {
                    if (NumberofBlueprints > NumberofProductionLines)
                    {
                        // We can't run more bps than the lines entered, so reset this
                        NumberofBlueprints = NumberofProductionLines;
                    }
                    Batches = 1;
                }
                else
                {
                    // How many batches do we run in the production chain?
                    Batches = (int)Math.Round(Math.Ceiling(UserRuns / (double)(MaxRunsPerBP * NumberofProductionLines)));
                }

                // Set the minimum per bp, shouldn't go over the runs per bp since the user sends in the total numbps they need
                RunsPerLine = (int)Math.Round(Math.Floor(UserRuns / (double)NumberofBlueprints));
                ExtraRuns = (int)(UserRuns - RunsPerLine * NumberofBlueprints);

                // To track how many runs we have used in the batch setup
                long RunTracker = 0L;

                // Fill a list of runs per bp
                for (int i = 0, loopTo = Batches - 1; i <= loopTo; i++)
                {
                    for (int j = 0, loopTo1 = NumberofProductionLines - 1; j <= loopTo1; j++)
                    {
                        // As we add the runs, adjust with extra runs proportionally until they are gone
                        if (ExtraRuns != 0)
                        {
                            // Since it's a fraction of a total batch run, this will always just be one until gone 
                            AdjRunsperBP = RunsPerLine + 1;
                            ExtraRuns = ExtraRuns - 1; // Adjust extra
                        }
                        else
                        {
                            // No extra runs, so just add the original runs now
                            AdjRunsperBP = RunsPerLine;
                        }

                        BatchList.Add(AdjRunsperBP);

                        // If we have used up all the runs, then exit the loop
                        RunTracker += AdjRunsperBP;
                        if (RunTracker == UserRuns)
                        {
                            break;
                        }

                        if (AdjRunsperBP == MaxRunsPerBP)
                        {
                            // Reset the adjusteded runs per bp to match invented amount, or if zero let it keep summing up for T1
                            AdjRunsperBP = 0;
                        }

                    }

                    // Add the above batchlist to the chain
                    ProductionChain.Add(BatchList);
                    // Reset the batch list
                    BatchList = new List<int>();

                }

                // First get the BP's that are components of the main item we are building for future calculations
                SQLiteDataReader rsBPComps;
                var BPComponentIDs = new List<int>();
                Public_Variables.DBCommand = new SQLiteCommand(string.Format(@"SELECT MATERIAL_ID FROM ALL_BLUEPRINT_MATERIALS_FACT WHERE BLUEPRINT_ID={0} AND ACTIVITY IN (1,11) 
                                                         AND CONSUME = 1 AND MATERIAL_ID IN (SELECT ITEM_ID FROM ALL_BLUEPRINTS_FACT)", BlueprintID), Public_Variables.EVEDB.DBREf());
                rsBPComps = Public_Variables.DBCommand.ExecuteReader();

                while (rsBPComps.Read())
                    // These are the only items that are built from the base BP
                    BPComponentIDs.Add(rsBPComps.GetInt32(0));

                var BatchExcessMats = new Materials(); // Excess with first bp

                rsBPComps.Close();

                // Now we just build each BP for the runs in the batch and total up all the variables - apply additional costs per batch
                // Need to revisit for efficiency - will run one batch for each unique runs in the production chain and muliply by number of unique run batches
                for (int i = 0, loopTo2 = ProductionChain.Count - 1; i <= loopTo2; i++)
                {
                    for (int j = 0, loopTo3 = ProductionChain[i].Count - 1; j <= loopTo3; j++)
                    {
                        Application.DoEvents();

                        IndustryFacility argBPReprocessingFacility = null;
                        BatchBlueprint = new Blueprint(BlueprintID, ProductionChain[i][j], iME, iTE, 1, NumberofProductionLines, BPCharacter, BPUserSettings, BuildBuy, AdditionalCosts / ProductionChain.Count, MainManufacturingFacility, ComponentManufacturingFacility, CapitalComponentManufacturingFacility, ReactionFacility, SellExcessItems, T2T3MaterialType, true, ref BBList, BPReprocessingFacility: ref argBPReprocessingFacility);

                        Materials argExcessBuildMaterials = null;
                        BatchBlueprint.BuildItem(SetTaxes, BrokerFeeData, SetProductionCosts, IgnoreMinerals, IgnoreT1Item, ref argExcessBuildMaterials);

                        // Sum up all the stuff that is batch dependent

                        // Save all the variables
                        if (BatchBlueprint.HasBuildableComponents & HasBuildableComponents == false)
                        {
                            HasBuildableComponents = true;
                        }

                        // Assumption is that we can build the bp
                        if (!BatchBlueprint.CanBuildBP & CanBuildBP == true)
                        {
                            CanBuildBP = false;
                        }

                        if (!BatchBlueprint.CanBuildAll & CanBuildAll == true)
                        {
                            CanBuildAll = false;
                        }

                        // Material lists - don't copy the raw mats yet, will be rebuilt below
                        if (!(BatchBlueprint.GetComponentMaterials().GetMaterialList() == null))
                        {
                            for (int k = 0, loopTo4 = BatchBlueprint.GetComponentMaterials().GetMaterialList().Count - 1; k <= loopTo4; k++)
                            {
                                // Only add materials we are not building, built materials will get added below
                                if (BatchBlueprint.GetComponentMaterials().GetMaterialList()[k].GetBuildItem() == false)
                                {
                                    ComponentMaterials.InsertMaterial(BatchBlueprint.GetComponentMaterials().GetMaterialList()[k]);
                                }
                            }
                        }

                        // Add all new components to the blueprint list to rebuild later
                        foreach (var BI in BatchBlueprint.GetComponentsList().GetBuiltItemList())
                        {
                            // Only add components from the build that are part of the main BP, any additional components will be added below
                            if (BPComponentIDs.Contains((int)BI.ItemTypeID))
                            {
                                BuiltComponentList.AddBuiltItem(BI);
                            }
                        }

                        // Save the raw mats on the bp only
                        if (!(BatchBlueprint.GetBPRawMaterials().GetMaterialList() == null))
                        {
                            BPRawMats.InsertMaterialList(BatchBlueprint.GetBPRawMaterials().GetMaterialList());
                        }

                        // If we build this blueprint, add on the skills required
                        if (BatchBlueprint.ReqBuildSkills.NumSkills() != 0)
                        {
                            ReqBuildSkills.InsertSkills(BatchBlueprint.ReqBuildSkills, true);
                        }

                        // Don't add this, it's only the largest time from the batch session and then multiply it later
                        if (BatchBlueprint.GetProductionTime() > BPProductionTime)
                        {
                            BPProductionTime = BatchBlueprint.GetProductionTime();
                        }

                        Taxes += BatchBlueprint.GetSalesTaxes();
                        BrokerFees += BatchBlueprint.GetSalesBrokerFees();

                        // New cost variables
                        EIV += BatchBlueprint.GetEstimatedItemValue();

                        // Base Fees for activity
                        JobFee += BatchBlueprint.GetJobFee();

                        switch (BatchBlueprint.GetItemGroupID())
                        {
                            case var @case when @case == Public_Variables.ReactionGroupID(BatchBlueprint.GetItemGroupID()):
                                {
                                    ReactionFacilityUsage += BatchBlueprint.GetReactionFacilityUsage();
                                    break;
                                }

                            default:
                                {
                                    // How much it costs to use each facility to manufacture items 
                                    ManufacturingFacilityUsage += BatchBlueprint.GetManufacturingFacilityUsage();
                                    break;
                                }

                        }
                    }
                }

                // Finally we need to calculate each component again as 1 bp and 1 batch so that the numbers line up
                // We assume that we will build all the components first before doing Sessions - this makes shopping list updates easier
                // Will revisit but the number of components is set by the blueprint

                // First copy in all the raw mats from the blueprint
                for (int i = 0, loopTo5 = BPRawMats.GetMaterialList().Count - 1; i <= loopTo5; i++)
                    RawMaterials.InsertMaterial(BPRawMats.GetMaterialList()[i]);

                // Reset the production times
                ComponentProductionTimes = new List<double>();

                BuiltItemList TempBuiltComponents = (BuiltItemList)BuiltComponentList.Clone();

                // Now build the components as x runs, with 1 bp, that are connected to the main blueprint
                var OwnedBP = default(bool);
                for (int i = 0, loopTo6 = TempBuiltComponents.GetBuiltItemList().Count - 1; i <= loopTo6; i++)
                {
                    IndustryFacility TempComponentFacility;
                    SQLiteDataReader rsCheck;
                    string SQL;
                    string CategoryID = "";
                    int GroupID = 0;
                    double OneItemMarketPrice = 0d;
                    int PortionSize = 1;

                    {
                        var withBlock = TempBuiltComponents.GetBuiltItemList()[i];
                        Application.DoEvents();

                        SQL = "SELECT ALL_BLUEPRINTS_FACT.ITEM_GROUP_ID, ALL_BLUEPRINTS_FACT.ITEM_CATEGORY_ID, ITEM_PRICES_FACT.PRICE, PORTION_SIZE ";
                        SQL += "FROM ALL_BLUEPRINTS_FACT, ITEM_PRICES_FACT WHERE ALL_BLUEPRINTS_FACT.ITEM_ID = ITEM_PRICES_FACT.ITEM_ID ";
                        SQL += "AND ALL_BLUEPRINTS_FACT.ITEM_ID = " + withBlock.ItemTypeID;

                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                        rsCheck = Public_Variables.DBCommand.ExecuteReader();

                        if (rsCheck.Read())
                        {
                            GroupID = rsCheck.GetInt32(0);
                            CategoryID = rsCheck.GetInt32(1).ToString();
                            OneItemMarketPrice = rsCheck.GetDouble(2);
                            PortionSize = rsCheck.GetInt32(3);
                        }

                        rsCheck.Close();

                        // Build the T1 component
                        if (GroupID == (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID | GroupID == (int)Public_Variables.ItemIDs.CapitalComponentGroupID)
                        {
                            // Use capital component facility
                            TempComponentFacility = CapitalComponentManufacturingFacility;
                        }
                        else if (IsT1BaseItemforT2(Conversions.ToInteger(CategoryID)))
                        {
                            // Want to build this in the manufacturing facility we are using for base T1 items used in T2
                            TempComponentFacility = MainManufacturingFacility;
                        }
                        // ElseIf GroupID = ItemIDs.ReactionBiochemicalsGroupID Or GroupID = ItemIDs.ReactionCompositesGroupID Or GroupID = ItemIDs.ReactionPolymersGroupID Or GroupID = ItemIDs.ReactionsIntermediateGroupID Then
                        // TempComponentFacility = ReactionFacility
                        else // Components
                        {
                            TempComponentFacility = ComponentManufacturingFacility;
                        }

                        // Set the quantity to what was used - save the old required quantity for component list
                        long ComponentQuantity = withBlock.ItemQuantity;
                        long BuildQuantity = (int)Math.Round(Math.Ceiling(withBlock.UsedQuantity));

                        IndustryFacility argBPReprocessingFacility1 = null;
                        ComponentBlueprint = new Blueprint(withBlock.BPTypeID, BuildQuantity, withBlock.BuildME, withBlock.BuildTE, 1, NumberofProductionLines, BPCharacter, BPUserSettings, BuildBuy, 0d, TempComponentFacility, ComponentManufacturingFacility, CapitalComponentManufacturingFacility, ReactionFacility, SellExcessItems, T2T3MaterialType, true, ref BBList, BPReprocessingFacility: ref argBPReprocessingFacility1);

                        ComponentBlueprint.BuildItem(SetTaxes, BrokerFeeData, SetProductionCosts, IgnoreMinerals, IgnoreT1Item, ref ExcessMaterials);

                        // ' Update the BuiltComponetList quantity with what the build quantity needs are
                        // For Each Mat In ComponentBlueprint.UsedExcessMaterials.GetMaterialList
                        // For Each BC In BuiltComponentList.GetBuiltItemList
                        // If BC.ItemTypeID = Mat.GetMaterialTypeID Then
                        // ' Update the built item
                        // BC.ItemQuantity = BC.ItemQuantity + Mat.GetQuantity
                        // BC.BPRuns = CLng(Math.Ceiling(BC.ItemQuantity / BC.PortionSize))
                        // Exit For
                        // End If
                        // Next
                        // Next

                        long ExtraItems;
                        Material ExtraMaterial = null;

                        // Also, if this built item is more than we need for the main blueprint, add it to excess
                        if (ComponentQuantity < ComponentBlueprint.PortionSize * ComponentBlueprint.GetUserRuns())
                        {
                            ExtraItems = ComponentBlueprint.PortionSize * ComponentBlueprint.GetUserRuns() - ComponentQuantity;
                            ExtraMaterial = new Material(withBlock.ItemTypeID, Public_Variables.RemoveItemNameRuns(withBlock.ItemName), CategoryID, ExtraItems, withBlock.ItemVolume, 0d, withBlock.BuildME.ToString(), withBlock.BuildTE.ToString());
                            ExcessMaterials.InsertMaterial(ExtraMaterial);
                        }

                        // Reset the component's material list for shopping list functionality
                        withBlock.BuildMaterials = ComponentBlueprint.RawMaterials;

                        // Add any built components to the list as well
                        foreach (var BI in ComponentBlueprint.BuiltComponentList.GetBuiltItemList())
                            BuiltComponentList.AddBuiltItem(BI);

                        // Set the variables
                        withBlock.ManufacturingFacility = ComponentBlueprint.MainManufacturingFacility;
                        withBlock.IncludeActivityCost = ComponentBlueprint.MainManufacturingFacility.IncludeActivityCost;
                        withBlock.IncludeActivityTime = ComponentBlueprint.MainManufacturingFacility.IncludeActivityTime;
                        withBlock.IncludeActivityUsage = ComponentBlueprint.MainManufacturingFacility.IncludeActivityUsage;

                        double ItemPrice = 0d;

                        GetMETEforBP(ComponentBlueprint.BlueprintID, ComponentBlueprint.TechLevel, ComponentBlueprint.ItemGroupID, ref BPUserSettings.DefaultBPME, ref BPUserSettings.DefaultBPTE, ref OwnedBP);

                        // Reset item name
                        if (withBlock.ItemName.Contains("("))
                        {
                            withBlock.ItemName = Strings.Trim(withBlock.ItemName.Substring(0, Strings.InStr(withBlock.ItemName, "(") - 1));
                        }

                        // Figure out if we build or buy
                        bool BuildFlag = GetBuildFlag(ComponentBlueprint, OneItemMarketPrice, BuildQuantity, OwnedBP, SetTaxes, BrokerFeeData);

                        if (BuildBuy & BuildFlag)
                        {
                            // Market cost is greater than build cost, so set the mat cost to the build cost - or just building (not build/buy)
                            ItemPrice = ComponentBlueprint.GetRawMaterials().GetTotalMaterialsCost() / withBlock.ItemQuantity;
                            // Adjust the runs of this BP in the name for built bps
                            withBlock.ItemName = Public_Variables.UpdateItemNamewithRuns(withBlock.ItemName, ComponentBlueprint.GetUserRuns());
                        }
                        else
                        {
                            // Buying item
                            ItemPrice = OneItemMarketPrice;
                            BuildFlag = false;
                        }

                        // If we build this blueprint, add on the skills required
                        if (ComponentBlueprint.ReqBuildSkills.NumSkills() != 0)
                        {
                            ReqBuildComponentSkills.InsertSkills(ComponentBlueprint.ReqBuildSkills, true);
                        }

                        // Add the built material to the component list now - this way we only add one blueprint produced material - use saved component quantity
                        var TempMat = new Material(withBlock.ItemTypeID, withBlock.ItemName, ComponentBlueprint.GetItemData().GroupName, withBlock.ItemQuantity, withBlock.ItemVolume, ItemPrice, withBlock.BuildME.ToString(), withBlock.BuildTE.ToString(), BuildFlag);
                        ComponentMaterials.InsertMaterial(TempMat);

                        // Building, so add the raw materials to the raw mats list
                        RawMaterials.InsertMaterialList(ComponentBlueprint.GetRawMaterials().GetMaterialList());
                    }

                    // Add the production time of this component to the total production time
                    ComponentProductionTimes.Add(ComponentBlueprint.GetProductionTime());

                    // Get the usage
                    switch (GroupID)
                    {
                        case (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID:
                        case (int)Public_Variables.ItemIDs.CapitalComponentGroupID:
                            {
                                CapComponentFacilityUsage += ComponentBlueprint.GetManufacturingFacilityUsage();
                                break;
                            }
                        case var case1 when case1 == Public_Variables.ReactionGroupID(GroupID):
                            {
                                TotalReactionFacilityUsage += ComponentBlueprint.GetReactionFacilityUsage();
                                break;
                            }

                        default:
                            {
                                if (ReactionBPGroups.Contains(BlueprintGroupID))
                                {
                                    // Save the manufacturing cost for fuel blocks
                                    ManufacturingFacilityUsage += ComponentBlueprint.GetManufacturingFacilityUsage();
                                }
                                else
                                {
                                    ComponentFacilityUsage += ComponentBlueprint.GetManufacturingFacilityUsage();
                                }

                                break;
                            }
                    }
                }

                // Add any items that are not built but could be to the raw list
                for (int j = 0, loopTo7 = ComponentMaterials.GetMaterialList().Count - 1; j <= loopTo7; j++)
                {
                    if (ComponentMaterials.GetMaterialList()[j].GetBuildItem() == false & ComponentMaterials.GetMaterialList()[j].GetItemME() != "-" & BuildBuy)
                    {
                        RawMaterials.InsertMaterial(ComponentMaterials.GetMaterialList()[j]);
                    }
                }

                // Update the bp production time to equal the longest runs per line times the number of batches - add in copy and invention time if we invented (totaled up in invention function)
                BPProductionTime = BPProductionTime * Batches + CopyTime + InventionTime;

                // Set the total production time by adding just the components (invention and copy already included in bp production time
                if (!(ComponentProductionTimes == null))
                {
                    TotalProductionTime = BPProductionTime + GetComponentProductionTime(ComponentProductionTimes);
                }

                // Finally recalculate our prices
                SetPriceData(SetTaxes, BrokerFeeData);

            }

            var ReturnedExcess = new Materials();
            ReprocessingUsage = 0d;

            // If the BP has a reprocessing facility, see if we want to convert minerals/ice to ore and then run this
            if (!(ReprocessingFacility == null))
            {
                if (ReprocessingFacility.ConvertToOre)
                {
                    var ReplaceMinerals = new ConvertToOre(ref ReprocessingFacility, SettingsVariables.UserConversiontoOreSettings);
                    RawMaterials = ReplaceMinerals.GetOresfromMinerals(RawMaterials, ref ReturnedExcess, ref ReprocessingUsage);
                    // Add the excess minerals to the main excess function
                    ExcessMaterials.InsertMaterialList(ReturnedExcess.GetMaterialList());
                    // Adjust the price data again to handle the update to excess prices and reprocessing usage
                    SetPriceData(SetTaxes, BrokerFeeData);
                }
            }

        }

        // Sets the material versions for our blueprint
        private void BuildItem(bool SetTaxes, Public_Variables.BrokerFeeInfo BrokerFeeData, bool SetProductionCosts, bool IgnoreMinerals, bool IgnoreT1Item, [Optional] ref Materials ExcessBuildMaterials)
        {
            // Database stuff
            string SQL;
            string SQLAdd = "";
            SQLiteDataReader readerBP;
            SQLiteDataReader readerME;

            var TempME = default(int);
            var TempTE = default(int);
            bool OwnedBP = false;

            // Recursion variables
            Blueprint ComponentBlueprint = null;
            var TempSkills = new EVESkillList(BPUserSettings.UseActiveSkillLevels);

            // The current material we are working with
            Material CurrentMaterial;
            long CurrentMatQuantity;
            int CurrentMaterialGroupID;
            int CurrentMaterialCategoryID;

            // The quantity that we want to use to build this item (may be different than quantity need if portionsize <> runs)
            long BuildQuantity = 0L;
            long ComponentBPPortionSize = 1L;

            // Temp Materials for passing
            var TempMaterials = new Materials();
            int TempNumBPs = 1;

            double SingleRunBuildCost = -1;
            var SavedExcessMaterialList = new Materials();
            var SavedBPExcessMaterialList = new Materials();
            var SavedUpdateBPExcessMaterialList = new Materials();
            Material LookupMaterial;
            Material UsedExcessMaterial = null;
            long ExtraItems;
            double SellExcessAmount = 0d;
            long AdjCurrentMatQuantity = 0L;
            Material ExtraMaterial = null;
            Material RefUsedMat = null;

            bool UsesReactions = false;
            bool IgnoreBuild = false;

            // Select all materials to buid this BP
            SQL = "SELECT ABM.BLUEPRINT_ID, MATERIAL_ID, QUANTITY, MATERIAL, MATERIAL_GROUP_ID, MATERIAL_CATEGORY_ID,  ";
            SQL += "ACTIVITY, MATERIAL_VOLUME, PRICE, ADJUSTED_PRICE, PORTION_SIZE, groupName ";
            SQL += "FROM ALL_BLUEPRINT_MATERIALS_FACT AS ABM, INVENTORY_TYPES, INVENTORY_GROUPS ";
            SQL += "LEFT OUTER JOIN ITEM_PRICES_FACT ON ABM.MATERIAL_ID = ITEM_PRICES_FACT.ITEM_ID ";
            SQL += "LEFT OUTER JOIN ALL_BLUEPRINTS_FACT ON ALL_BLUEPRINTS_FACT.ITEM_ID = ABM.MATERIAL_ID ";
            SQL += "WHERE ABM.BLUEPRINT_ID =" + BlueprintID.ToString() + " And ACTIVITY IN (1,11) ";
            SQL += "AND MATERIAL_ID = INVENTORY_TYPES.typeID AND INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerBP = Public_Variables.DBCommand.ExecuteReader();

            // For each material in the blueprint, calculate the total mats
            // and load them into the list
            while (readerBP.Read())
            {
                CurrentMaterialGroupID = readerBP.GetInt32(4);
                CurrentMaterialCategoryID = readerBP.GetInt32(5);

                // Adjust the number of runs I need for the main item based on what I have in the excess mats
                var TempMat = new Material(ItemID, ItemName, ItemGroupID.ToString(), UserRuns * PortionSize, ItemVolume, 0d, "", "");
                long TempRuns = TempMat.GetQuantity();

                UserRuns = (long)Math.Round(Math.Ceiling(TempRuns / (double)PortionSize));

                if (CurrentMaterialCategoryID == 16)
                {
                    // It's a skill, so just add it to the main list of BP skills
                    ReqBuildSkills.InsertSkill(readerBP.GetInt64(1), readerBP.GetInt32(2), readerBP.GetInt32(2), readerBP.GetInt32(2), 0L, false, 0, "", null, true);
                }

                else if (AddMaterial(CurrentMaterialCategoryID, CurrentMaterialGroupID, IgnoreMinerals, IgnoreT1Item))
                {

                    // Save a copy of the excess materials lists in case we need to replace it if we don't decide to build this component
                    if (!(ExcessBuildMaterials == null))
                    {
                        if (ExcessBuildMaterials.GetMaterialList().Count != 0)
                        {
                            SavedExcessMaterialList = (Materials)ExcessBuildMaterials.Clone();
                        }
                    }

                    if (!(BPExcessMaterials == null))
                    {
                        if (BPExcessMaterials.GetMaterialList().Count != 0)
                        {
                            SavedBPExcessMaterialList = (Materials)BPExcessMaterials.Clone();
                        }
                    }

                    // Set the current material - adjust with portion size though if sent
                    CurrentMaterial = new Material(readerBP.GetInt64(1), readerBP.GetString(3), readerBP.GetString(11), readerBP.GetInt64(2), readerBP.GetDouble(7), readerBP.IsDBNull(8) ? 0d : readerBP.GetDouble(8), "", "");

                    // Refresh the facility bonuses before we start calculations of ME/TE
                    MainManufacturingFacility.RefreshMMTMCMBonuses(ItemGroupID, ItemCategoryID);

                    // Save the base costs - before applying ME - if value is null (no price record) then set to 0
                    EIV += CurrentMaterial.GetQuantity() * (readerBP.GetValue(9) is DBNull ? 0d : readerBP.GetDouble(9));

                    // Set the quantity: required = max(runs,ceil(round(runs * baseQuantity * materialModifier,2))
                    CurrentMatQuantity = (long)Math.Round(Math.Max(UserRuns, Math.Ceiling(Math.Round(UserRuns * CurrentMaterial.GetQuantity() * SetBPMaterialModifier(ref MainManufacturingFacility), 2))));
                    // Update the quantity - just add the negative percent of the ME modifier to 1 and multiply
                    CurrentMaterial.SetQuantity(CurrentMatQuantity);

                    // Before going any further, see if we have this material in excess materials and if so, adjust the quantity that we will need to build
                    if (ExcessBuildMaterials == null)
                    {
                        AdjCurrentMatQuantity = CurrentMatQuantity;
                    }
                    else
                    {
                        AdjCurrentMatQuantity = GetAdjustedQuantity(ref ExcessBuildMaterials, CurrentMaterial.GetMaterialTypeID(), CurrentMatQuantity, ref RefUsedMat);
                    }

                    if (AdjCurrentMatQuantity == 0L)
                    {
                        // If original blueprint and the component was already built, need to build it with the original mat quantity 
                        // but Not add any materials to the list after completed so it shows the item needing to be built
                        if (BaseBP)
                        {
                            // Add to main list 
                            // Set the name of the material to include the build runs if built
                            if (BuildBuy)
                            {
                                if (RefUsedMat.GetBuildItem())
                                {
                                    RefUsedMat.SetName(Public_Variables.UpdateItemNamewithRuns(RefUsedMat.GetMaterialName(), RefUsedMat.GetQuantity()));
                                    // also, since this was already built in a component, we can't charge the cost to the main list
                                    // so it matches up with the build buy costs, reset cost to 0
                                    ComponentMaterials.InsertMaterial(RefUsedMat, 0d);
                                }
                                else
                                {
                                    // Buying, so add to raw mat list too
                                    // (if it's built already, the raw mats will already be in the list)
                                    RawMaterials.InsertMaterial(RefUsedMat);
                                }
                            }
                            else
                            {
                                ComponentMaterials.InsertMaterial(RefUsedMat);
                            }
                        }
                        goto SkipProcessing;
                    }

                    if (!(readerBP.GetValue(10) is DBNull))
                    {
                        ComponentBPPortionSize = readerBP.GetInt32(10);
                        // Divide by the portion size if this item has one (component buildable) for the build quantity
                        BuildQuantity = (long)Math.Round(Math.Ceiling(AdjCurrentMatQuantity / (double)ComponentBPPortionSize));
                    }
                    else
                    {
                        BuildQuantity = AdjCurrentMatQuantity;
                        ComponentBPPortionSize = 1L;
                    }

                    IgnoreBuild = false;

                    // For molecular forged materials, these are reactions but are like advanced T2 components, so don't build them if advanced selected to match other components
                    if (T2T3MaterialType == BuildMatType.AdvMaterials & CurrentMaterialGroupID == (int)Public_Variables.ItemIDs.ReactionMolecularForgedGroupID)
                    {
                        IgnoreBuild = true;
                    }

                    // For R.A.M.s and Fuel Blocks
                    if (CurrentMaterialGroupID == 1136 & BPUserSettings.AlwaysBuyFuelBlocks | CurrentMaterialGroupID == 332 & BPUserSettings.AlwaysBuyRAMs)
                    {
                        IgnoreBuild = true;
                    }

                    // If this is an advanced composite reaction, and the advanced option is selected, then don't build anything and add as raw material
                    if ((ItemGroupID == (int)Public_Variables.ItemIDs.ReactionCompositesGroupID | ItemGroupID == (int)Public_Variables.ItemIDs.ReactionMolecularForgedGroupID) & T2T3MaterialType == BuildMatType.AdvMaterials)
                    {
                        IgnoreBuild = true;
                    }
                    else if ((BlueprintName.Contains("Standard") | BlueprintName.Contains("Synth")) & T2T3MaterialType == BuildMatType.ProcessedMaterials & CurrentMaterialGroupID != (int)Public_Variables.ItemIDs.ReactionBiochemicalsGroupID)
                    {
                        IgnoreBuild = true;
                    }
                    else if ((BlueprintName.Contains("Improved") | BlueprintName.Contains("Strong")) & T2T3MaterialType != BuildMatType.RawMaterials & CurrentMaterialGroupID != (int)Public_Variables.ItemIDs.ReactionBiochemicalsGroupID)
                    {
                        IgnoreBuild = true;
                    }

                    UsesReactions = false;

                    // See what material type this is and if we want to build it (reactions)
                    switch (CurrentMaterialGroupID)
                    {
                        case (int)Public_Variables.ItemIDs.ReactionCompositesGroupID:
                        case (int)Public_Variables.ItemIDs.ReactionMolecularForgedGroupID:
                            {
                                if (T2T3MaterialType == BuildMatType.ProcessedMaterials | T2T3MaterialType == BuildMatType.RawMaterials)
                                {
                                    UsesReactions = true;
                                }

                                break;
                            }
                        case (int)Public_Variables.ItemIDs.ReactionsIntermediateGroupID:
                        case (int)Public_Variables.ItemIDs.ReactionPolymersGroupID:
                            {
                                if (T2T3MaterialType == BuildMatType.RawMaterials) // Or (ItemGroupID = ItemIDs.ReactionCompositesGroupID And T2T3MaterialType = BuildMatType.AdvMaterials) Then
                                {
                                    UsesReactions = true;
                                }

                                break;
                            }
                        case (int)Public_Variables.ItemIDs.ReactionBiochemicalsGroupID:
                            {
                                // Special processing for boosters
                                if (CurrentMaterial.GetMaterialName().Contains("Improved") | CurrentMaterial.GetMaterialName().Contains("Strong"))
                                {
                                    // This has intermediate material types
                                    UsesReactions = true;
                                }
                                else if ((CurrentMaterial.GetMaterialName().Contains("Standard") | CurrentMaterial.GetMaterialName().Contains("Synth")) & T2T3MaterialType == BuildMatType.ProcessedMaterials)
                                {
                                    UsesReactions = true;
                                }
                                else if (T2T3MaterialType == BuildMatType.RawMaterials) // Only builds one level
                                {
                                    UsesReactions = true;
                                }

                                break;
                            }
                    }

                    if (!UsesReactions)
                    {
                        SQLAdd = " AND BLUEPRINT_GROUP_ID NOT IN (1888,1889,1890,4097)";
                    }
                    else
                    {
                        SQLAdd = "";
                    }

                    // If it has a value in the main bp table, then the item can be built from it's own BP - do a check if they want to use reactions to drill down to raw mats
                    SQL = "SELECT BLUEPRINT_ID, TECH_LEVEL, ITEM_GROUP_ID FROM ALL_BLUEPRINTS_FACT WHERE ITEM_ID =" + CurrentMaterial.GetMaterialTypeID() + SQLAdd;
                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerME = Public_Variables.DBCommand.ExecuteReader();

                    if (readerME.Read() & !IgnoreBuild)
                    {
                        // We can build it from another BP 
                        HasBuildableComponents = true;

                        // Look up the ME/TE and owned data for the bp
                        GetMETEforBP(readerME.GetInt32(0), readerME.GetInt32(1), readerME.GetInt32(2), ref TempME, ref TempTE, ref OwnedBP);

                        // Update the current material's ME
                        CurrentMaterial.SetItemME(TempME.ToString());

                        IndustryFacility TempComponentFacility;

                        // Build the T1/Reaction component
                        switch (CurrentMaterialGroupID)
                        {
                            case (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID:
                            case (int)Public_Variables.ItemIDs.CapitalComponentGroupID:
                                {
                                    // Use capital component facility
                                    TempComponentFacility = CapitalComponentManufacturingFacility;
                                    break;
                                }
                            case var @case when @case == Public_Variables.ReactionGroupID(CurrentMaterialGroupID):
                                {
                                    TempComponentFacility = ReactionFacility;
                                    break;
                                }

                            default:
                                {
                                    if (IsT1BaseItemforT2(CurrentMaterialCategoryID))
                                    {
                                        // Want to build this in the manufacturing facility we are using for base T1 items used in T2
                                        TempComponentFacility = MainManufacturingFacility;
                                    }
                                    else
                                    {
                                        // Components
                                        TempComponentFacility = ComponentManufacturingFacility;
                                    }

                                    break;
                                }
                        }

                        // For now only assume 1 bp and 1 line to build it - Later this section will have to be updated to use the remaining lines or maybe lines = numbps
                        IndustryFacility argBPReprocessingFacility = null;
                        ComponentBlueprint = new Blueprint(readerME.GetInt32(0), BuildQuantity, TempME, TempTE, 1, 1, BPCharacter, BPUserSettings, BuildBuy, 0d, TempComponentFacility, ComponentManufacturingFacility, CapitalComponentManufacturingFacility, ReactionFacility, SellExcessItems, T2T3MaterialType, false, ref BBList, BPReprocessingFacility: ref argBPReprocessingFacility);

                        // Set this blueprint with the quantity needed and get it's mats
                        ComponentBlueprint.BuildItem(SetTaxes, BrokerFeeData, SetProductionCosts, IgnoreMinerals, IgnoreT1Item, ref ExcessBuildMaterials);

                        BPExcessMaterials.InsertMaterialList(ComponentBlueprint.BPExcessMaterials.GetMaterialList());

                        // Update this BP's excess materials if any were used from the excess list in this component bp when built
                        foreach (var Mat in ComponentBlueprint.UsedExcessMaterials.GetMaterialList())
                        {
                            if (Mat.GetMaterialTypeID() != CurrentMaterial.GetMaterialTypeID())
                            {
                                // See if material used is in the BP list and update quantity from what we used
                                LookupMaterial = BPExcessMaterials.SearchListbyName(Mat.GetMaterialName(), true);
                                if (!(LookupMaterial == null))
                                {
                                    long UpdateQuantity = LookupMaterial.GetQuantity() - Mat.GetQuantity();
                                    if (UpdateQuantity <= 0L)
                                    {
                                        // Used it all
                                        BPExcessMaterials.RemoveMaterial(LookupMaterial);
                                    }
                                    else
                                    {
                                        // Remove from list to update total list amount
                                        BPExcessMaterials.RemoveMaterial(LookupMaterial);
                                        // Update what we used and insert back into list
                                        LookupMaterial.SetQuantity(UpdateQuantity);
                                        BPExcessMaterials.InsertMaterial(LookupMaterial);
                                    }
                                }
                                else
                                {
                                    UsedExcessMaterials.InsertMaterial(Mat);
                                }
                                // Save if we don't end up building this and we can readjust
                                SavedUpdateBPExcessMaterialList.InsertMaterial(Mat);

                                // ' Update the BuiltComponentList quantity with what the build quantity needs are
                                // For Each BC In BuiltComponentList.GetBuiltItemList
                                // If BC.ItemTypeID = Mat.GetMaterialTypeID Then
                                // BC.ItemQuantity += Mat.GetQuantity
                                // Exit For
                                // End If
                                // Next

                            }
                        }

                        long BuiltQuantity = ComponentBlueprint.GetPortionSize() * ComponentBlueprint.GetUserRuns();

                        // Set all the materials that are excess and save later if built
                        ExtraMaterial = null;

                        // If this built item is more than we need for the main blueprint, add it to excess. If less, then we have already calced what we need plus excess above
                        if (CurrentMaterial.GetQuantity() < ComponentBlueprint.PortionSize * ComponentBlueprint.GetUserRuns())
                        {
                            ExtraItems = ComponentBlueprint.PortionSize * ComponentBlueprint.GetUserRuns() - CurrentMaterial.GetQuantity();
                            ExtraMaterial = (Material)CurrentMaterial.Clone();
                            ExtraMaterial.SetQuantity(ExtraItems);
                        }

                        // Figure out if we build or if cheaper to buy
                        bool BuildItem = GetBuildFlag(ComponentBlueprint, CurrentMaterial.GetCostPerItem(), BuildQuantity, OwnedBP, SetTaxes, BrokerFeeData);

                        if (BuildItem & BuildBuy | !BuildBuy)
                        {
                            // *** BUILD ***

                            // We want to build this item
                            CurrentMaterial.SetBuildItem(true);

                            // Update this if used later
                            if (!(ExtraMaterial == null))
                            {
                                ExtraMaterial.SetBuildItem(true);
                            }

                            // Set the name of the material to include the build runs only if build/buy
                            if (BuildBuy)
                            {
                                CurrentMaterial.SetName(Public_Variables.UpdateItemNamewithRuns(CurrentMaterial.GetMaterialName(), BuildQuantity));
                            }

                            // Use any materials before continuing
                            if (!(ExcessBuildMaterials == null))
                            {
                                UseExcessMaterials(ref ExcessBuildMaterials, CurrentMaterial.GetMaterialTypeID(), CurrentMaterial.GetQuantity() - BuiltQuantity, ref SavedExcessMaterialList, ref UsedExcessMaterial);
                            }

                            // Save the production time for this component
                            ComponentProductionTimes.Add(ComponentBlueprint.GetTotalProductionTime());

                            // Get the skills for BP to build it and add them to the list
                            TempSkills = ComponentBlueprint.GetReqBPSkills();

                            // Get the component usage
                            switch (ComponentBlueprint.GetItemGroupID())
                            {
                                case (int)Public_Variables.ItemIDs.AdvCapitalComponentGroupID:
                                case (int)Public_Variables.ItemIDs.CapitalComponentGroupID:
                                    {
                                        CapComponentFacilityUsage += ComponentBlueprint.GetManufacturingFacilityUsage();
                                        break;
                                    }
                                case var case1 when case1 == Public_Variables.ReactionGroupID(ComponentBlueprint.GetItemGroupID()):
                                    {
                                        // Save reaction and fuel block usage for reaction bps
                                        TotalReactionFacilityUsage += ComponentBlueprint.GetReactionFacilityUsage();
                                        ManufacturingFacilityUsage += ComponentBlueprint.GetManufacturingFacilityUsage();
                                        break;
                                    }

                                default:
                                    {
                                        if (ReactionBPGroups.Contains(BlueprintGroupID))
                                        {
                                            // Save fuel block usage
                                            ManufacturingFacilityUsage += ComponentBlueprint.GetManufacturingFacilityUsage();
                                        }
                                        else
                                        {
                                            // Just a regular component
                                            ComponentFacilityUsage += ComponentBlueprint.GetManufacturingFacilityUsage();
                                        }

                                        break;
                                    }
                            }

                            // Insert the raw mats of this blueprint
                            RawMaterials.InsertMaterialList(ComponentBlueprint.GetRawMaterials().GetMaterialList());

                            // If this item has buildable components, add those to this main list too so it nests up
                            if (!(ExcessBuildMaterials == null))
                            {
                                for (int i = 0, loopTo = ComponentBlueprint.BuiltComponentList.GetBuiltItemList().Count - 1; i <= loopTo; i++)
                                    BuiltComponentList.AddBuiltItem((BuiltItem)ComponentBlueprint.BuiltComponentList.GetBuiltItemList()[i].Clone());
                            }

                            int OverrideRunsModifier = -1;

                            // *** BUILD OR BUY ***
                            if (BuildBuy)
                            {
                                // Get the total component cost and adjust total with any excess sell
                                double TotalComponentCost = ComponentBlueprint.GetTotalComponentCost();
                                // - AdjustPriceforTaxesandFees(ComponentBlueprint.BPExcessMaterials.GetTotalMaterialsCost, SetTaxes, BrokerFeeData)

                                // Add in taxes and fees to the total build cost
                                SingleRunBuildCost = TotalComponentCost / BuildQuantity;
                                CurrentMaterial.SetBuildCostPerItem(SingleRunBuildCost);

                                // Save the item built, it's ME and the materials it used
                                var TempBuiltItem = new BuiltItem();

                                // Add the built item to the built component list for later use
                                TempBuiltItem = SetBuiltItem(readerME.GetInt64(0), CurrentMaterial, CurrentMatQuantity, ComponentBPPortionSize, TempME, TempTE, ComponentBlueprint, BuildQuantity, SetTaxes, BrokerFeeData);

                                TempBuiltItem.BuildMaterials = ComponentBlueprint.GetComponentMaterials();

                                if (ComponentBlueprint.BuiltComponentList.GetBuiltItemList().Count != 0)
                                {
                                    // Add any buildable components to this item list
                                    for (int i = 0, loopTo1 = ComponentBlueprint.BuiltComponentList.GetBuiltItemList().Count - 1; i <= loopTo1; i++)
                                        TempBuiltItem.ComponentBuildList.Add((BuiltItem)ComponentBlueprint.BuiltComponentList.GetBuiltItemList()[i].Clone());
                                }

                                // Add this item to the main build list 
                                BuiltComponentList.AddBuiltItem((BuiltItem)TempBuiltItem.Clone());

                                // Use the build cost for the material if the item quantity doesn't match portion size, and insert all components into the build/buy list
                                if (CurrentMatQuantity != BuildQuantity)
                                {
                                    // Override the total build cost (which for this is the number of runs we need and the cost of each) mostly for items with portion sizes
                                    ComponentMaterials.InsertMaterial(CurrentMaterial, SingleRunBuildCost * BuildQuantity);
                                }
                                else
                                {
                                    ComponentMaterials.InsertMaterial(CurrentMaterial, TotalComponentCost);
                                }
                            }

                            else // *** BUILD ALL COMPONENTS - so use BUY prices ***
                            {
                                // Add the built item to the built component list for later use
                                BuiltComponentList.AddBuiltItem((BuiltItem)SetBuiltItem(readerME.GetInt64(0), CurrentMaterial, CurrentMatQuantity, ComponentBPPortionSize, TempME, TempTE, ComponentBlueprint, BuildQuantity, SetTaxes, BrokerFeeData).Clone());

                                // Insert the existing component that we are using into the component list as set in the original BP
                                ComponentMaterials.InsertMaterial(CurrentMaterial);

                            }
                        }

                        else // *** BUY ***
                        {
                            // We want to buy this item, don't add raw mats but add the component to the buy list (raw mats)
                            CurrentMaterial.SetBuildItem(false);
                            // Update this if used later
                            if (!(ExtraMaterial == null))
                            {
                                ExtraMaterial.SetBuildItem(false);
                            }
                            // Also, not adding the build time to the lists
                            RawMaterials.InsertMaterial(CurrentMaterial);
                            ComponentMaterials.InsertMaterial(CurrentMaterial);
                        }

                        // If we build this blueprint, add on the skills required
                        if (TempSkills.NumSkills() != 0)
                        {
                            ReqBuildComponentSkills.InsertSkills(TempSkills, true);
                        }

                        // Check if we can build all components. If we can't make one item then we set it to false and leave it that way
                        if (CanBuildAll)
                        {
                            if (!UserHasReqSkills(BPCharacter.Skills, ComponentBlueprint.GetReqBPSkills()))
                            {
                                // Can't build this item, so we can't build all components from main blueprint
                                CanBuildAll = false;
                            }
                        }

                        // Adjust excess lists 
                        if (CurrentMaterial.GetBuildItem())
                        {
                            // Save the excess for this item
                            if (!(ExcessBuildMaterials == null))
                            {
                                ExcessBuildMaterials.InsertMaterial(ExtraMaterial);
                            }
                            // Add the used material to the BP excess materials since for this BP it was excess 
                            BPExcessMaterials.InsertMaterial(ExtraMaterial);
                        }
                        else if (!CurrentMaterial.GetBuildItem())
                        {
                            // Not building this item, so replace the copy we made before we started this bp to reset the list back
                            ExcessBuildMaterials = (Materials)SavedExcessMaterialList.Clone();
                            BPExcessMaterials = (Materials)SavedBPExcessMaterialList.Clone();
                            // Loop through and add back any used excess since we are buying this item
                            // For Each Mat In SavedUpdateBPExcessMaterialList.GetMaterialList
                            // LookupMaterial = BPExcessMaterials.SearchListbyName(Mat.GetMaterialName)
                            // If Not IsNothing(LookupMaterial) Then
                            // ' Remove from list to update total list amount
                            // Call BPExcessMaterials.RemoveMaterial(LookupMaterial)
                            // ' Update what we used and insert back into list
                            // LookupMaterial.SetQuantity(LookupMaterial.GetQuantity + Mat.GetQuantity)
                            // Call BPExcessMaterials.InsertMaterial(LookupMaterial)
                            // Else
                            // ' Just add it back to the list
                            // BPExcessMaterials.InsertMaterial(Mat)
                            // End If
                            // Next
                        }
                    }

                    else // Just raw material 
                    {
                        if (readerME.HasRows)
                        {
                            // This is a component, so look up the ME of the item to put on the material before adding (fixes issue when searching for shopping list items of the same type - no ME is "-" and these have an me
                            // For example, see modulated core strip miner and polarized heavy pulse weapons.
                            GetMETEforBP(readerME.GetInt64(0), readerME.GetInt32(1), readerME.GetInt32(2), ref TempME, ref TempTE, ref OwnedBP);
                            CurrentMaterial.SetItemME(TempME.ToString());
                        }

                        // We are not building these
                        CurrentMaterial.SetBuildItem(false);

                        // Insert the raw mats
                        RawMaterials.InsertMaterial(CurrentMaterial);
                        // Also insert into component list
                        ComponentMaterials.InsertMaterial(CurrentMaterial);
                        // These are from the bp and not a component
                        BPRawMats.InsertMaterial(CurrentMaterial);

                    }

                    readerME.Close();

                SkipProcessing:
                    ;


                }

            }

            readerBP.Close();

            // Set the build flag for the blueprint
            if (UserHasReqSkills(BPCharacter.Skills, ReqBuildSkills))
            {
                CanBuildBP = true;
            }
            else
            {
                CanBuildBP = false;
            }

            // Set the Advanced Skill levels to build this item for later application of Production Time
            AdvManufacturingSkillLevelBonus = SetAdvManufacturingSkillLevels(ReqBuildSkills);

            // Set the production time
            SetProductionTime();

            // Set taxes and fees on this item only (materials set in shopping list)
            Taxes = Public_Variables.GetSalesTax(ItemMarketCost);
            BrokerFees = Public_Variables.GetSalesBrokerFee(ItemMarketCost, BrokerFeeData);

            // Set the costs for making this item
            SetManufacturingCostsAndFees();

            // Update the total time, if we used components
            if (!(ComponentProductionTimes == null))
            {
                TotalProductionTime = TotalProductionTime + GetComponentProductionTime(ComponentProductionTimes);
            }

            // Add all the times here - only include copy, re, and invention times here since it's the total time
            TotalProductionTime = TotalProductionTime + BPProductionTime + CopyTime + InventionTime;
            // Finally, add in the copy, invention and RE time if they sent it
            BPProductionTime = BPProductionTime + CopyTime + InventionTime;

            // Update the built runs on each built item in the built component list
            foreach (var BI in BuiltComponentList.GetBuiltItemList())
                BI.ItemName = Public_Variables.UpdateItemNamewithRuns(BI.ItemName, (long)Math.Round(Math.Ceiling(BI.ItemQuantity / (double)BI.PortionSize)));

            // Finally set all the price data
            SetPriceData(SetTaxes, BrokerFeeData);

        }

        // See if the item is in the list and if so, return that value else false
        private bool ManualBuildBuyValue(long ItemID, bool DefaultValue)
        {
            Public_Variables.BuildBuyItem FoundItem;
            BBItemtoFind = ItemID;
            FoundItem = BBList.Find(FindBBItem);

            if (FoundItem.ItemID != 0L)
            {
                return FoundItem.BuildItem;
            }
            else
            {
                return DefaultValue;
            }

        }

        // Just look up excess to see if we have enough materials to use for material quantity and return difference needed to build if diff greater than zero (will be used later if so)
        private long GetAdjustedQuantity(ref Materials ExcessBuildItems, long MaterialTypeID, long MaterialQuantity, ref Material ItemUsed)
        {
            long ReturnQuantity = MaterialQuantity;
            Material UsedMat;
            long UsedQuantity;

            if (!(ExcessBuildItems == null))
            {
                if (ExcessBuildItems.GetMaterialList().Count != 0)
                {
                    Materials TempList = (Materials)ExcessBuildItems.Clone();
                    foreach (var ExcessMat in TempList.GetMaterialList())
                    {
                        if (ExcessMat.GetMaterialTypeID() == MaterialTypeID)
                        {
                            // Get a copy first
                            UsedMat = (Material)ExcessMat.Clone();
                            // If have excess materials from then use those mats, and only build what we need
                            if (MaterialQuantity > ExcessMat.GetQuantity())
                            {
                                // Need to update current mat quantity and continue to run as we need more now but still using all
                                ReturnQuantity = MaterialQuantity - ExcessMat.GetQuantity();
                                UsedQuantity = ReturnQuantity;
                            }
                            else
                            {
                                // We are using what's in the list and can skip processing - some left over
                                ReturnQuantity = 0L; // Skip
                                UsedQuantity = MaterialQuantity;
                                // Adjust the list
                                ExcessBuildItems.RemoveMaterial(ExcessMat);
                                // Update the quantity used from excess and skip processing
                                ExcessMat.SetQuantity(ExcessMat.GetQuantity() - MaterialQuantity);
                                if (ExcessMat.GetQuantity() > 0L)
                                {
                                    ExcessBuildItems.InsertMaterial(ExcessMat);
                                }
                            }

                            if (!(UsedMat == null))
                            {
                                // If using all mats, then clear out all excess materials below it
                                if (ExcessMat.GetQuantity() == 0L)
                                {
                                    UsedExcessMaterials = new Materials();
                                }
                                UsedMat.SetQuantity(UsedQuantity);
                                UsedExcessMaterials.InsertMaterial(UsedMat);
                            }

                            ItemUsed = UsedMat;

                            break;
                        }
                    }
                }
            }

            return ReturnQuantity;

        }

        // Adjusts the lists for use of excess materials - True means continue to build the updated material quantity, false means don't build
        private void UseExcessMaterials(ref Materials ExcessBuildItems, long MaterialTypeID, long MaterialQuantity, [Optional] ref Materials SavedExcessList, [Optional] ref Material UpdatedMaterial)
        {
            Material LookupMaterial;
            long UpdatedQuantity;

            if (MaterialQuantity <= 0L)
            {
                // We built what we need so we won't use anything
                return;
            }

            if (!(ExcessBuildItems == null))
            {
                Materials TempList = (Materials)ExcessBuildItems.Clone();
                if (TempList.GetMaterialList().Count != 0)
                {
                    foreach (var ExcessMat in TempList.GetMaterialList())
                    {
                        if (ExcessMat.GetMaterialTypeID() == MaterialTypeID)
                        {
                            // Remove first, then add back updated quantity after use
                            ExcessBuildItems.RemoveMaterial(ExcessMat);
                            UpdatedQuantity = ExcessMat.GetQuantity() - MaterialQuantity;
                            if (UpdatedQuantity > 0L)
                            {
                                // Update the quantity used from excess
                                ExcessMat.SetQuantity(UpdatedQuantity);
                                ExcessBuildItems.InsertMaterial(ExcessMat);
                            }
                            // Save that we used this material for the quantity sent, even if the remaining is 0
                            UpdatedMaterial = (Material)ExcessMat.Clone();
                        }
                    }
                }
            }

            if (!(SavedExcessList == null))
            {
                // We used excess mats so no need to build - however, need to restore excess for anything we built and used in drill down
                foreach (var Mat in SavedExcessList.GetMaterialList())
                {
                    if (Mat.GetMaterialTypeID() != MaterialTypeID)
                    {
                        // See if material is even in list (could have been removed when used)
                        LookupMaterial = ExcessBuildItems.SearchListbyName(Mat.GetMaterialName(), true);
                        if (LookupMaterial == null)
                        {
                            // Not found, so add back in
                            ExcessBuildItems.InsertMaterial(Mat);
                        }
                        else if (LookupMaterial.GetQuantity() != Mat.GetQuantity()) // Look up the material from the excess list and compare quantity
                        {
                            // If different, restore the original quantity to the excess list
                            ExcessBuildItems.RemoveMaterial(LookupMaterial);
                            // Update what we used and insert back into list
                            LookupMaterial.SetQuantity(Mat.GetQuantity());
                            ExcessBuildItems.InsertMaterial(LookupMaterial);
                        }
                    }
                }
            }

            if (!(UpdatedMaterial == null))
            {
                // If using all mats, then clear out all excess materials below it
                if (MaterialQuantity == 0L)
                {
                    UsedExcessMaterials = new Materials();
                }
                UsedExcessMaterials.InsertMaterial(UpdatedMaterial);
            }

        }

        private BuiltItem SetBuiltItem(long TypeID, Material SentMaterial, long MaterialQuantity, long PortionSize, int iME, int iTE, Blueprint RefBlueprint, long BuildRuns, bool SetTaxes, Public_Variables.BrokerFeeInfo BFData)
        {

            // Save the item built, it's ME and the materials it used
            var TempBuiltItem = new BuiltItem();

            TempBuiltItem.BPTypeID = TypeID;
            TempBuiltItem.ItemTypeID = SentMaterial.GetMaterialTypeID();
            TempBuiltItem.ItemName = SentMaterial.GetMaterialName();
            TempBuiltItem.ItemQuantity = MaterialQuantity;
            TempBuiltItem.UsedQuantity = (decimal)(MaterialQuantity / (double)PortionSize); // use decimal here, don't round yet
            TempBuiltItem.BuildME = iME;
            TempBuiltItem.BuildTE = iTE;
            TempBuiltItem.ItemVolume = SentMaterial.GetVolume();
            TempBuiltItem.BPRuns = BuildRuns;
            TempBuiltItem.PortionSize = PortionSize;

            TempBuiltItem.BuildMaterials = RefBlueprint.GetRawMaterials();
            TempBuiltItem.ManufacturingFacility = RefBlueprint.MainManufacturingFacility;
            TempBuiltItem.IncludeActivityCost = RefBlueprint.MainManufacturingFacility.IncludeActivityCost;
            TempBuiltItem.IncludeActivityTime = RefBlueprint.MainManufacturingFacility.IncludeActivityTime;
            TempBuiltItem.IncludeActivityUsage = RefBlueprint.MainManufacturingFacility.IncludeActivityUsage;

            TempBuiltItem.TotalBuildCost = RefBlueprint.GetComponentMaterials().GetTotalMaterialsCost() + (+RefBlueprint.TotalUsage) + RefBlueprint.GetSalesTaxes() + RefBlueprint.GetSalesBrokerFees();

            TempBuiltItem.TotalExcessSellBuildCost = TempBuiltItem.TotalBuildCost - Public_Variables.AdjustPriceforTaxesandFees(RefBlueprint.BPExcessMaterials.GetTotalMaterialsCost(), SetTaxes, BFData);

            return TempBuiltItem;

        }

        // Determine ProductionTime of Components - they have 15 components, and 10 usable production lines, then take the max time, and sum up the rest and divide as sections of the max
        // So if they have a 10 minute component, and 5, 1 minute components, we can make all in 2 jobs and the total time is 10 min. If they go over max jobs,
        // then take the max component and add on the max job of the 2nd component
        // TODO - FIX

        private double GetComponentProductionTime(List<double> SentTimes)
        {
            double MaxComponentTime = 0d;
            double RemainingTimeSum = 0d;
            double JobTimeSum = 0d;
            var Temp = new List<double>();
            int JobCount;

            int i;
            double SessionTime;

            // Dim ProductionCombos As New List(Of BPCombinations) ' Each entry is a combination, each index is a line, total time is the combined times
            // Dim CurrentBPCombo As BPCombinations = Nothing
            // 'Dim BPTimeStartIndex As Integer
            // Dim LinesIndex As Integer
            // Dim TimeIndex As Integer
            // Dim CompareTime As Double
            // Dim MinimumTimeIndex As Integer

            // Dim TopBPTimesperCombo() As Double

            if (SentTimes.Count == 0)
            {
                return 0d;
            }

            // If TestingVersion Then
            // ' Simple case 1
            // If NumberofProductionLines = 1 Then
            // ' Just sum up the times
            // For i = 0 To SentTimes.Count - 1
            // SessionTime = SessionTime + SentTimes(i)
            // Next

            // ElseIf ComponentProductionTimes.Count <= NumberofProductionLines Then
            // ' Simple case 2
            // ' Just return the max, we can make all the others within the time to make the first,
            // ' we have enough lines, and we have to wait for the first to end
            // SessionTime = SentTimes.Max

            // Else ' Hard case, need to find most optimal combination

            // ' Set the lines
            // ReDim CurrentBPCombo.CombinedTimes(NumberofProductionLines - 1)
            // LinesIndex = 0
            // BPTimeStartIndex = 0

            // ' This is the number of combinations we should get
            // For i = 0 To SentTimes.Count - 1

            // ' Loop through each blueprint and each set of combos, start on a new initial bp time
            // For j = 0 To SentTimes.Count - 1

            // ' This moves the index from the start (say 3) to loop back to 0 when necessary
            // If BPTimeStartIndex + j < SentTimes.Count Then
            // ' If less than count, just increment with j from start
            // TimeIndex = BPTimeStartIndex + j
            // ElseIf BPTimeStartIndex + j > SentTimes.Count Then
            // ' If we go over count, then the index must have been set to 0 (when equal) so increment the timeindex
            // TimeIndex += 1
            // Else ' equal
            // TimeIndex = 0
            // End If

            // ' Loop through each BP and move through the index
            // CurrentBPCombo.CombinedTimes(LinesIndex) = CurrentBPCombo.CombinedTimes(LinesIndex) + SentTimes(TimeIndex)

            // ' Reset line index so we add to the right line
            // If LinesIndex = CurrentBPCombo.CombinedTimes.Count - 1 Then
            // LinesIndex = 0
            // Else
            // LinesIndex += 1
            // End If

            // Next

            // ' Insert the current bp combo into the list, then start processing the next combination
            // ProductionCombos.Insert(i, CurrentBPCombo)

            // ' Increment the BP Start index
            // BPTimeStartIndex += 1
            // ' Reset combined times
            // LinesIndex = 0
            // ReDim CurrentBPCombo.CombinedTimes(NumberofProductionLines - 1)

            // Next

            // ' Now we should have a list of possible line and bp time (bps) time combinations
            // ' Find the largest of each index and save time - This is the max time it will take to make all the blueprints in that combo
            // ReDim TopBPTimesperCombo(ProductionCombos.Count - 1)

            // For i = 0 To ProductionCombos.Count - 1
            // TopBPTimesperCombo(i) = ProductionCombos(i).CombinedTimes.Max
            // Next

            // ' Finally, find the minimum time of the maximums from the combos (save the index by doing a loop instead of just getting the min)
            // ' This is the ideal BP production combination and the optimal time to make the item
            // For i = 0 To TopBPTimesperCombo.Count - 1
            // CompareTime = TopBPTimesperCombo(i)

            // If CompareTime < SessionTime Or SessionTime = 0 Then
            // SessionTime = CompareTime
            // MinimumTimeIndex = i
            // End If
            // Next

            // End If

            // Else

            // Easy case - NOT WORKING RIGHT - LOOK AT FENRIR
            if (NumberofProductionLines == 1)
            {
                // Nothing simpler than this, it's just the total time to make components back to back
                var loopTo = SentTimes.Count - 1;
                for (i = 0; i <= loopTo; i++)
                    RemainingTimeSum = RemainingTimeSum + SentTimes[i];

                SessionTime = RemainingTimeSum;
            }

            else if (ComponentProductionTimes.Count <= NumberofProductionLines)
            {
                // Just return the max, we can make all the others within the time to make the first,
                // we have enough lines, and we have to wait for the first to end
                SessionTime = SentTimes.Max();
            }
            else // Have some extra bps to make vs. lines - IE 7 components and 4 lines
            {
                // The max time is the metric for time per session
                MaxComponentTime = SentTimes.Max();
                // Sort the array (in ascending order)
                SentTimes.Sort();
                // Sum up the rest of the jobs, skipping the last one
                var loopTo1 = SentTimes.Count - 2;
                for (i = 0; i <= loopTo1; i++)
                    RemainingTimeSum = RemainingTimeSum + SentTimes[i];

                if (MaxComponentTime > RemainingTimeSum)
                {
                    // We can do all jobs in the time it takes to make the longest one
                    SessionTime = MaxComponentTime;
                }
                else
                {
                    // Have more than one set to do
                    // Reset time
                    RemainingTimeSum = 0d;
                    JobTimeSum = 0d;
                    JobCount = 1; // First new job
                    // Loop through times, and save index of last time that fits, start largest to smallest skipping first one
                    for (i = SentTimes.Count - 2; i >= 1; i -= 1)
                    {
                        JobTimeSum = JobTimeSum + SentTimes[i];
                        if (JobTimeSum > MaxComponentTime)
                        {
                            // We went over, so pull off the last time and step back i
                            JobTimeSum = JobTimeSum - SentTimes[i];
                            i = i + 1;
                            if (JobCount < NumberofProductionLines)
                            {
                                // One production line gone and we have more, move to the next
                                JobCount = JobCount + 1;
                                // Save this job time
                                RemainingTimeSum = RemainingTimeSum + JobTimeSum;
                                JobTimeSum = 0d;
                            }
                            else
                            {
                                // No more lines left, need to get a new job going
                                // Need to add this to the time and exit
                                RemainingTimeSum = RemainingTimeSum + JobTimeSum;
                                break;
                            }
                        }
                    }

                    if (JobCount == NumberofProductionLines)
                    {
                        // Need to get the time of the next session, call this again and get the next session time
                        int j = i - 1;
                        // Copy in the final values
                        var loopTo2 = j - 1;
                        for (i = 0; i <= loopTo2; i++)
                            Temp.Add(SentTimes[i]);

                        RemainingTimeSum = RemainingTimeSum + GetComponentProductionTime(Temp);
                    }

                    // Add up the final time
                    SessionTime = MaxComponentTime + RemainingTimeSum;

                }

            }
            // End If

            return SessionTime;

        }

        // Sets the Production time for this Blueprint
        private void SetProductionTime()
        {
            // For total runs
            long FullJobSessions = 0L;
            long JobsPerBatch = 0L;

            // If this is using advanced Industrial/Capital skills, then add this bonus as well to build time
            double AdvIndySkill = 1d;
            double AdvCapskill = 1d;
            int TempSkill = 0;

            // Include advanced industry skill bonuses
            TempSkill = ReqBuildSkills.GetSkillLevel(AdvISCSkill);
            if (TempSkill != 0)
            {
                AdvIndySkill = 1d - BPCharacter.Skills.GetSkillLevel(AdvISCSkill) * 0.01d; // 1% reduction in time per level
            }

            TempSkill = ReqBuildSkills.GetSkillLevel(AdvCSCSkill);
            if (TempSkill != 0)
            {
                AdvCapskill = 1d - BPCharacter.Skills.GetSkillLevel(AdvCSCSkill) * 0.01d; // 1% reduction in time per level
            }

            // For 1 run of this item add in the modifier plus skill level modifiers
            BPProductionTime = BaseProductionTime * SetBPTimeModifier() * AdvManufacturingSkillLevelBonus * AdvIndySkill * AdvCapskill;

            // Figure out how many jobs per batch we need to run, find the smallest of the two
            if (NumberofBlueprints > NumberofProductionLines)
            {
                JobsPerBatch = NumberofProductionLines;
            }
            else if (NumberofBlueprints <= NumberofProductionLines)
            {
                JobsPerBatch = NumberofBlueprints;
            }

            // Batches more than runs aren't used, so just normalize to runs
            if (JobsPerBatch > UserRuns)
            {
                JobsPerBatch = UserRuns;
            }

            // Now find the number of job sessions of 1 run each we need to do, round up to next whole integer - 1.1 sessions is 2
            FullJobSessions = (long)Math.Round(Math.Ceiling(UserRuns / (double)JobsPerBatch));

            // Total time is just the total sessions multiplied by the production time
            BPProductionTime = FullJobSessions * BPProductionTime;

        }

        private void AdjustSellExcessValue(bool _SetTaxes, Public_Variables.BrokerFeeInfo _BrokerFeeData)
        {
            // Total up the excess material amounts
            SellExcessAmount = 0d; // reset

            if (SellExcessItems)
            {
                foreach (var Item in ExcessMaterials.GetMaterialList())
                    SellExcessAmount += Item.GetTotalCost();

                // Apply taxes and fees
                SellExcessAmount = Public_Variables.AdjustPriceforTaxesandFees(SellExcessAmount, _SetTaxes, _BrokerFeeData);

                if (SellExcessAmount < 0d)
                {
                    SellExcessAmount = 0d;
                }
            }
        }

        // Sets all price data for the user to get on this blueprint, Set public so can reset with fees/taxes
        public void SetPriceData(bool SetTaxes, Public_Variables.BrokerFeeInfo BrokerFeeData)
        {
            double TaxesFees = 0d;
            double ComponentUsage = 0d;
            double MainFacilityUsage = 0d;
            double RemainingReactionUsage = 0d;

            if (SetTaxes)
            {
                DisplayTaxes = Public_Variables.GetSalesTax(ItemMarketCost);
            }
            else
            {
                DisplayTaxes = 0d;
            }

            DisplayBrokerFees = Public_Variables.GetSalesBrokerFee(ItemMarketCost, BrokerFeeData);

            TaxesFees = DisplayTaxes + DisplayBrokerFees;

            if (ComponentManufacturingFacility.IncludeActivityUsage)
            {
                ComponentUsage += ComponentFacilityUsage;
            }

            if (CapitalComponentManufacturingFacility.IncludeActivityUsage)
            {
                ComponentUsage += CapComponentFacilityUsage;
            }

            if (ReactionFacility.IncludeActivityUsage & MainManufacturingFacility.FacilityProductionType == ProductionType.Reactions)
            {
                MainFacilityUsage = ReactionFacilityUsage;
                ComponentUsage += ManufacturingFacilityUsage;
                RemainingReactionUsage = TotalReactionFacilityUsage - ReactionFacilityUsage;
            }
            else
            {
                MainFacilityUsage = ManufacturingFacilityUsage;
                ComponentUsage += ReactionFacilityUsage;
            }

            if (!(ReprocessingFacility == null))
            {
                if (!ReprocessingFacility.IncludeActivityUsage)
                {
                    // if we don't want to show this, reset to 0
                    ReprocessingUsage = 0d;
                }
            }

            // Finalize invention and copying usage and total cost of all invention
            SetCopyUsage();
            SetInventionUsage();

            // Set copy and invention costs (total mats needed + usage) for the number of runs they want
            if (IncludeInventionCosts)
            {
                // Set the total cost for the sent runs by totaling all to get success needed, then dividing it by the runs invented
                // (some bps have more runs than 1 - i.e. Drones = 10) to get the cost per run, then multiply that cost by the number of runs
                // InventionCost = TotalInventionCost / TotalInventedRuns * UserRuns
                // Use the Per Run Cost for a more accurate invention cost assuming a large number of runs - more accurate than small runs however will not be the exact cost of the invention materials needed
                InventionCost = PerInventionRunCost * UserRuns;
            }
            else
            {
                InventionCost = 0d;
            }

            if (IncludeCopyCosts & TechLevel != (int)Public_Variables.BPTechLevel.T3)
            {
                // Set the total cost for the sent runs by totaling all to get success needed, then dividing it by the runs invented
                // (some bps have more runs than 1 - i.e. Drones = 10) to get the cost per run, then multiply that cost by the number of runs
                CopyCost = TotalCopyCost / TotalInventedRuns * UserRuns;
            }
            else
            {
                CopyCost = 0d;
            }

            TotalUsage = MainFacilityUsage + ComponentUsage + InventionUsage + CopyUsage + RemainingReactionUsage + ReprocessingUsage;

            // Set up the excess material amounts
            AdjustSellExcessValue(SetTaxes, BrokerFeeData);

            // Totals 
            TotalRawCost = RawMaterials.GetTotalMaterialsCost() + InventionCost + CopyCost + TaxesFees + AdditionalCosts + TotalUsage - SellExcessAmount;
            TotalComponentCost = ComponentMaterials.GetTotalMaterialsCost() + InventionCost + CopyCost + TaxesFees + AdditionalCosts + (TotalUsage - ComponentUsage - RemainingReactionUsage - ReprocessingUsage) - SellExcessAmount; // don't build components

            // Don't include usage in the total cost above but if we are doing build/buy add it back
            if (BuildBuy)
            {
                TotalComponentCost += ComponentUsage + RemainingReactionUsage + ReprocessingUsage;
            }
            else
            {
                // For component cost without build/buy, we are buying all the components so nothing to build and sell
                TotalComponentCost += SellExcessAmount;
            }

            // Profit market cost - total cost of mats and invention and fees
            TotalRawProfit = ItemMarketCost - TotalRawCost;
            TotalComponentProfit = ItemMarketCost - TotalComponentCost;

            if (ItemMarketCost == 0d)
            {
                TotalRawProfitPercent = 0d;
                TotalComponentProfitPercent = 0d;
            }
            else
            {
                TotalRawProfitPercent = 1d - TotalRawCost / ItemMarketCost;
                TotalComponentProfitPercent = 1d - TotalComponentCost / ItemMarketCost;
            }

            // Final Calculation
            // ISK per Hour (divide total cost by production time in seconds for a isk per second calc, then multiply by 3600 for isk per hour)
            TotalIPHRaw = TotalRawProfit / TotalProductionTime * 3600d; // Build everything

            // If we are doing build/buy then the total IPH will be the same as RAW since the lists are identical for what to buy 
            if (BuildBuy)
            {
                TotalIPHComponent = TotalIPHRaw;
            }
            else
            {
                TotalIPHComponent = TotalComponentProfit / BPProductionTime * 3600d;
            } // Buy all components, just production time of BP

        }

        // Determines if we should add this material to the list or not, based on passed settings
        private bool AddMaterial(int CategoryID, int GroupID, bool IgnoreMinerals, bool IgnoreT1BaseItem)
        {

            if (IgnoreT1BaseItem & IsT1BaseItemforT2(CategoryID))
            {
                return false;
            }

            if (IgnoreMinerals & GroupID == 18) // 18= Minerals
            {
                return false;
            }

            return true;

        }

        // Determines if the item category sent is a T1 Base item used to make T2
        private bool IsT1BaseItemforT2(int CategoryID)
        {
            switch (CategoryID)
            {
                case 6:
                case 7:
                case 8:
                case 18: // "Ship", "Drone", "Module", "Charge"
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        // Calculates the total material muliplier for the blueprint based on the bp, and facility
        private double SetBPMaterialModifier(ref IndustryFacility SentFacility)
        {
            double FacilityMultiplier;

            // Check for Fulcrum bonus
            if (FulcrumBonusesApply)
            {
                FacilityMultiplier = 0.94d; // 6% reduction
            }
            else
            {
                FacilityMultiplier = SentFacility.MaterialMultiplier;
            }

            // Material modifier is the BP ME, and Facility - Facility is saved as a straight multiplier, the others need to be set
            return (1d - iME / 100d) * FacilityMultiplier;

        }

        // Gets the ME/TE for the BP
        public void GetMETEforBP(long BlueprintID, int BPTech, int BPItemGroup, ref int RefME, ref int RefTE, ref bool OwnedBP)
        {
            string SQL;
            SQLiteDataReader readerLookup;

            // See what ID we use for character bps
            string UserID;
            if (SettingsVariables.UserApplicationSettings.LoadBPsbyChar)
            {
                // Use the ID sent
                UserID = Public_Variables.SelectedCharacter.ID.ToString();
            }
            else
            {
                UserID = Public_Variables.CommonLoadBPsID.ToString();
            }

            // The user can't define an ME or TE for this blueprint, so just look it up
            SQL = "SELECT ME, TE, OWNED FROM OWNED_BLUEPRINTS WHERE USER_ID IN (" + UserID + "," + BPCharacter.CharacterCorporation.CorporationID + ") ";
            SQL += " AND BLUEPRINT_ID =" + BlueprintID.ToString() + " AND OWNED <> 0 ";
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerLookup = Public_Variables.DBCommand.ExecuteReader();

            if (readerLookup.Read())
            {
                RefME = readerLookup.GetInt32(0);
                RefTE = readerLookup.GetInt32(1);
                // Check if owned
                OwnedBP = Conversions.ToBoolean(readerLookup.GetInt64(2));
            }
            else
            {
                // T2
                if (BPTech == (int)Public_Variables.BPTechLevel.T2 | BPTech == (int)Public_Variables.BPTechLevel.T3)
                {
                    RefME = Public_Variables.BaseT2T3ME;
                    RefTE = Public_Variables.BaseT2T3TE;
                }
                else if (!Public_Variables.IsReaction(BPItemGroup))
                {
                    RefME = BPUserSettings.DefaultBPME;
                    RefTE = BPUserSettings.DefaultBPTE;
                }
                else
                {
                    RefME = 0;
                    RefTE = 0;
                }
                OwnedBP = false;
            }

            readerLookup.Close();

        }

        // Calculates the total time muliplier for the blueprint based on the bp, facility, amd implants
        private double SetBPTimeModifier()
        {
            double Modifier;
            double FacilityMultiplier;

            // Check for Fulcrum bonus
            if (FulcrumBonusesApply)
            {
                FacilityMultiplier = 0.3d; // 70% reduction
            }
            else
            {
                FacilityMultiplier = MainManufacturingFacility.TimeMultiplier;
            }

            // Time modifier is the BP ME, and Facility - Facility is saved as a straight multiplier, the others need to be set, then do the skills
            Modifier = (1d - iTE / 100d) * MainManufacturingFacility.TimeMultiplier * AIImplantValue * (1d - IndustrySkill * 0.04d) * (1d - AdvancedIndustrySkill * 0.03d);

            return Modifier;

        }

        // Returns T/F if the user has the required skills sent in when compared to character skills
        private bool UserHasReqSkills(EVESkillList EVESkillList, EVESkillList RequiredSkills)
        {
            int i;
            bool SkillFound = false;
            bool HasSkills = false;

            // Compare the required invention skills from blueprint to user skills
            // Start looping through the skills for the blueprint
            if (RequiredSkills.NumSkills() != 0)
            {
                var loopTo = RequiredSkills.GetSkillList().Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    // Check for the skill in the character skills for the appropriate level
                    if (EVESkillList.GetSkillLevel(RequiredSkills.GetSkillList()[i].TypeID) != 0)
                    {
                        SkillFound = true;
                    }

                    if (SkillFound)
                    {
                        if (EVESkillList.GetSkillLevel(RequiredSkills.GetSkillList()[i].TypeID) < RequiredSkills.GetSkillList()[i].Level)
                        {
                            // They have this skill but it isn't the correct level
                            // They don't have this, so just leave
                            return false;
                        }
                    }
                    else
                    {
                        // Skill not found, just leave
                        return false;
                    }

                    SkillFound = false;
                }
            }
            else
            {
                // If the Req Skills is empty, then return true since there are no required skills
                return true;
            }

            return true;

        }

        // Sets the fees for setting up a job to build this item
        private void SetManufacturingCostsAndFees()
        {
            double FacilityUsage = 0d;
            double TotalEIV = 0d;
            double Indexbonuses = 0d;

            AlphaCloneTax = 0d;

            // Formula: FacilityUsage = EstItemValue * ((SystemCostIndex * bonuses) + FacilityTax + SCC + AlphaClone) 

            if (IncludeManufacturingUsage)
            {
                // EIV = Sum(eachmaterialquantity * adjustedPrice) - set in build function
                TotalEIV = (long)Math.Round(EIV * UserRuns);
                Indexbonuses = MainManufacturingFacility.CostIndex * MainManufacturingFacility.CostMultiplier * FWManufacturingCostBonus;

                // Set Alpha tax
                if (BPUserSettings.AlphaAccount)
                {
                    AlphaCloneTax = SettingsVariables.UserApplicationSettings.AlphaAccountTaxRate;
                }

                double ModSCCSurcharge = SettingsVariables.UserApplicationSettings.SCCIndustryFeeSurcharge;
                {
                    ref var withBlock = ref Public_Variables.SelectedCharacter.CharacterCorporation;
                    if (MainManufacturingFacility.FacilityID == 60015187L & (withBlock.FactionID == 500010 | withBlock.FactionID == 500011))
                    {
                        ModSCCSurcharge *= 0.1d; // 90% reduction if in pirate factions at fulcrum for any build
                    }
                }

                FacilityUsage = TotalEIV * (Indexbonuses + MainManufacturingFacility.TaxRate + ModSCCSurcharge + AlphaCloneTax);
            }
            else
            {
                FacilityUsage = 0d;
            }

            if (MainManufacturingFacility.FacilityProductionType == ProductionType.Reactions)
            {
                ReactionFacilityUsage = FacilityUsage;
                TotalReactionFacilityUsage += FacilityUsage;
            }
            else
            {
                ManufacturingFacilityUsage = FacilityUsage;
            }

        }

        // Totals up all the skill levels for advanced manufacturing skills for TE reduction bonus
        private double SetAdvManufacturingSkillLevels(EVESkillList BuildSkills)
        {
            double BonusSum = 1d;

            // These skills for T2 now reduce TE by 1% per level for the manufacturing job with Pheobe
            // 3398	Advanced Large Ship Construction
            // 3397	Advanced Medium Ship Construction
            // 3395	Advanced Small Ship Construction
            // 11444	Amarr Starship Engineering
            // 11454	Caldari Starship Engineering
            // 11448  Electromagnetic Physics
            // 11453  Electronic Engineering
            // 11450	Gallente Starship Engineering
            // 11446  Graviton Physics
            // 11433	High Energy Physics
            // 11443  Hydromagnetic Physics
            // 11447  Laser Physics
            // 11452  Mechanical Engineering
            // 11445	Minmatar Starship Engineering
            // 11529  Molecular Engineering
            // 11451  Nuclear Physics
            // 11441  Plasma Physics
            // 11455  Quantum Physics
            // 11449  Rocket Science

            // Read through all the skills and if the ID is in the list, then sum up the levels
            for (int i = 0, loopTo = BuildSkills.NumSkills() - 1; i <= loopTo; i++)
            {
                switch (BuildSkills.GetSkillList()[i].TypeID)
                {
                    case 3398L:
                    case 3397L:
                    case 3395L:
                    case 11444L:
                    case 11454L:
                    case 11448L:
                    case 11453L:
                    case 11450L:
                    case 11446L:
                    case 11433L:
                    case 11443L:
                    case 11447L:
                    case 11452L:
                    case 11445L:
                    case 11529L:
                    case 11451L:
                    case 11441L:
                    case 11455L:
                    case 11449L:
                        {
                            // each skill is mulitplied by 1% then normalized percentage, then mulitiplied to any others to get the bonus
                            BonusSum = BonusSum * (1d - 0.01d * BPCharacter.Skills.GetSkillLevel(BuildSkills.GetSkillList()[i].TypeID));
                            break;
                        }
                }
            }

            return BonusSum;

        }

        // Determines if the item we are building should be bought or built for the main bp
        private bool GetBuildFlag(Blueprint ItemBlueprint, double OneItemMarketCost, long Runs, bool OwnedBP, bool SetTaxes, Public_Variables.BrokerFeeInfo BFData)
        {
            bool CheapertoBuild = false;
            double ExcessAmount = 0d;

            // First, check the overrides based on settings
            if (BPUserSettings.AlwaysBuyFuelBlocks & ItemBlueprint.BlueprintName.Contains("Fuel Block") | BPUserSettings.AlwaysBuyRAMs & ItemBlueprint.BlueprintName.Contains("R.A.M."))
            {
                return false;
            }

            // Get the excess amount cost of the build item for checking build/buy
            if (SellExcessItems)
            {
                ExcessAmount = ItemBlueprint.BPExcessMaterials.GetTotalMaterialsCost();
                // Add any excess for the main component too
                if (SetTaxes)
                {
                    ExcessAmount -= Public_Variables.GetSalesTax(ExcessAmount);
                }

                ExcessAmount -= Public_Variables.GetSalesBrokerFee(ExcessAmount, BFData);
            }

            // See if the costs to build are less than buy - cost to buy is greater than cost to build (compare total portion size for component)
            if (OneItemMarketCost * ItemBlueprint.GetPortionSize() * Runs > ItemBlueprint.GetTotalBuildCost() - ExcessAmount)
            {
                CheapertoBuild = true;
            }

            // Regardless of whatever is set, we want to override with what is in the BB list for base items on the main bp
            bool BuildItem = CheapertoBuild;

            // First time you run the bp, just use the base check 
            if (NewBPRequest)
            {
                BuildItem = OneItemMarketCost == 0d | CheapertoBuild & (BPUserSettings.SuggestBuildBPNotOwned | OwnedBP & !BPUserSettings.SuggestBuildBPNotOwned);
            }
            else
            {
                // Look up the override value and if not found, use the default
                BuildItem = ManualBuildBuyValue(ItemBlueprint.ItemID, CheapertoBuild);
            }

            return BuildItem;

        }

        // Returns the BPC used as a string
        public string GetInventionBPC()
        {

            for (int i = 0, loopTo = InventionMaterials.GetMaterialList().Count - 1; i <= loopTo; i++)
            {
                if (InventionMaterials.GetMaterialList()[i].GetMaterialTypeID() == InventionBPCTypeID)
                {
                    return InventionMaterials.GetMaterialList()[i].GetMaterialName();
                }
            }

            return "";
        }

        // Predicate for finding the BuildBuyItem in full list
        public bool FindBBItem(Public_Variables.BuildBuyItem Item)
        {
            if (BBItemtoFind == Item.ItemID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Invention/RE Functions

        // Sets the invention cost and materials for this BP
        private int InventREBlueprint(bool UseTypical = false)
        {
            double AvgRunsforSuccess;
            SQLiteDataReader readerBP;
            SQLiteDataReader readerCost;
            double MatCost = 0d;

            string SQL;
            Material InventionMat = null;
            Material CopyMat = null;
            var SingleInventionMats = new Materials();
            var SingleCopyMats = new Materials();
            int NumInventionSessions = 0; // How many sessions (runs per set of lines) ie. 10 runs 5 lines = 2 sessions

            // First select the datacores needed
            SQL = "SELECT MATERIAL_ID, MATERIAL, MATERIAL_CATEGORY, QUANTITY, MATERIAL_VOLUME, PRICE, MATERIAL_GROUP ";
            SQL += "FROM ALL_BLUEPRINT_MATERIALS LEFT OUTER JOIN ITEM_PRICES_FACT On ALL_BLUEPRINT_MATERIALS.MATERIAL_ID = ITEM_PRICES_FACT.ITEM_ID ";
            SQL += "WHERE BLUEPRINT_ID = " + InventionBPCTypeID + " And PRODUCT_ID = " + BlueprintID + " ";
            SQL += "AND ACTIVITY = 8 And MATERIAL_GROUP = 'Datacores'";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerBP = Public_Variables.DBCommand.ExecuteReader();

            // Get all the Datacores
            while (readerBP.Read())
            {
                // Add this to the invention materials - add price for data cores
                InventionMat = new Material(readerBP.GetInt64(0), readerBP.GetString(1), readerBP.GetString(2), readerBP.GetInt64(3), readerBP.GetDouble(4), readerBP.IsDBNull(5) ? 0d : readerBP.GetDouble(5), "", "");
                SingleInventionMats.InsertMaterial(InventionMat);
            }

            readerBP.Close();

            // If they selected a decryptor, add that cost for one invention run
            if ((InventionDecryptor.Name ?? "") != Public_Variables.None)
            {
                InventionMat = new Material(InventionDecryptor.TypeID, InventionDecryptor.Name, "Decryptors", 1L, 0.1d, Public_Variables.GetItemPrice(InventionDecryptor.TypeID), "", "");
                SingleInventionMats.InsertMaterial(InventionMat);
            }

            // If this is T3, get the relic and add it to the list of invention materials
            if (TechLevel == (int)Public_Variables.BPTechLevel.T3)
            {
                // Look up the cost for the material
                SQL = "SELECT PRICE, ITEM_NAME FROM ITEM_PRICES WHERE ITEM_ID =" + InventionBPCTypeID;

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerCost = Public_Variables.DBCommand.ExecuteReader();

                if (readerCost.Read())
                {
                    InventionMat = new Material(InventionBPCTypeID, readerCost.GetString(1), "Ancient Relics", 1L, 100d, readerCost.GetDouble(0), "", "");
                    SingleInventionMats.InsertMaterial(InventionMat);
                }

                readerCost.Close();
            }

            else if (TechLevel == (int)Public_Variables.BPTechLevel.T2)
            {
                SQL = "SELECT typeName, PRICE FROM INVENTORY_TYPES ";
                SQL += "LEFT OUTER JOIN ITEM_PRICES ON typeID = ITEM_ID ";
                SQL += "WHERE typeID = " + InventionBPCTypeID.ToString();

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerBP = Public_Variables.DBCommand.ExecuteReader();
                readerBP.Read();

                if (!(readerBP.GetValue(0) == null))
                {
                    double Price = 0d;
                    if (!(readerBP.GetValue(1) == null))
                    {
                        Price = readerBP.GetDouble(1);
                    }
                    // Add the T2 blueprint and cost
                    var TempMat = new Material(InventionBPCTypeID, readerBP.GetString(0) + " Copy", "Blueprint", 1L, 0.1d, Price, "", "");
                    SingleInventionMats.InsertMaterial(TempMat);
                }
                readerBP.Close();
            }

            // Get and set the invention chance
            InventionChance = SetInventionChance(UseTypical);

            // Use the max runs for the T2 item and this should be the invented runs for one bpc
            if (TechLevel == (int)Public_Variables.BPTechLevel.T2)
            {
                SingleInventedBPCRuns = MaxProductionLimit + InventionDecryptor.RunMod;
            }
            else
            {
                // Base it off of the relic type - need to look it up based on the TypeID
                SQL = "SELECT typeName, quantity FROM INVENTORY_TYPES, INDUSTRY_ACTIVITY_PRODUCTS ";
                SQL += "WHERE typeID = blueprintTypeID And typeID = " + InventionBPCTypeID.ToString() + " AND productTypeID = " + BlueprintID.ToString();

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerBP = Public_Variables.DBCommand.ExecuteReader();

                if (readerBP.Read())
                {
                    // Set the name
                    Relic = readerBP.GetString(0);
                    MaxProductionLimit = readerBP.GetInt32(1);
                }
                else
                {
                    MaxProductionLimit = 3;
                    Relic = Public_Variables.WreckedRelic;
                }

                // Set the final runs for one bp
                SingleInventedBPCRuns = MaxProductionLimit + InventionDecryptor.RunMod;
            }

            // Averages and final cost per run
            AvgRunsforSuccess = 1d / InventionChance;

            // Set how many total invention runs we will need to do - take the number of bpc's we'll need and multiply by how many runs for a success - round up
            if (InventionChance != 0d)
            {
                NumInventionJobs = (int)Math.Round(Math.Ceiling(AvgRunsforSuccess * Math.Ceiling(UserRuns / (double)SingleInventedBPCRuns)));
            }

            // Now set the total runs we will get from all jobs
            TotalInventedRuns = (int)Math.Round(Math.Ceiling(UserRuns / (double)SingleInventedBPCRuns) * SingleInventedBPCRuns);

            // Find the number of invention sessions we'll need to invent the number of runs for this item. This will be used in the copy and invention times
            // Basically, the number avg number of runs for success times the total runs wanted is the total invention runs needed for single runs. Divide this
            // by the invented runs, then divide that by how many laboratory lines we are using.  Need to round up each time
            // Ex. avgruns = 2, user runs = 100, inventedruns = 10, lines = 10 => 200/10 = 20/10 = 2 invention sessions to get enough bps to make 100 runs.
            NumInventionSessions = (int)Math.Round(Math.Ceiling(NumInventionJobs / (double)NumberofLaboratoryLines));

            if (IncludeCopyTime & TechLevel != (int)Public_Variables.BPTechLevel.T3)
            {
                // Set the total copy time based on the number of invention jobs we need - assume only one bp to copy
                CopyTime = GetCopyTime(NumInventionJobs);
            }
            else
            {
                CopyTime = 0d;
            } // No copies for T3

            if (IncludeCopyCosts & TechLevel != (int)Public_Variables.BPTechLevel.T3)
            {
                // Get the copy materials and update
                SQL = "SELECT MATERIAL_ID, MATERIAL, MATERIAL_CATEGORY, QUANTITY, MATERIAL_VOLUME, PRICE, MATERIAL_GROUP ";
                SQL += "FROM ALL_BLUEPRINT_MATERIALS LEFT OUTER JOIN ITEM_PRICES_FACT ON ALL_BLUEPRINT_MATERIALS.MATERIAL_ID = ITEM_PRICES_FACT.ITEM_ID ";
                SQL += "WHERE BLUEPRINT_ID = " + InventionBPCTypeID + " AND PRODUCT_ID = " + InventionBPCTypeID + " ";
                SQL += "AND ACTIVITY = 5 AND MATERIAL_CATEGORY <> 'Skill'";

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerBP = Public_Variables.DBCommand.ExecuteReader();

                // Get all the mats and add
                while (readerBP.Read())
                {
                    // Add this to the copy materials 
                    CopyMat = new Material(readerBP.GetInt64(0), readerBP.GetString(1), readerBP.GetString(2), readerBP.GetInt64(3), readerBP.GetDouble(4), readerBP.IsDBNull(5) ? 0d : readerBP.GetDouble(5), "", "");
                    SingleCopyMats.InsertMaterial(CopyMat);
                }

                readerBP.Close();

                if (!(SingleCopyMats.GetMaterialList() == null))
                {
                    // Update the copy mats to reflect the number of copy runs we will do and save into the final list
                    for (int i = 0, loopTo = SingleCopyMats.GetMaterialList().Count - 1; i <= loopTo; i++)
                        SingleCopyMats.GetMaterialList()[i].SetQuantity(SingleCopyMats.GetMaterialList()[i].GetQuantity() * NumInventionJobs);

                    // Now insert all the materials in a new list to get the correct cost (kind of a hack, need a better process - no automatic way to update the total price in a material list)
                    for (int i = 0, loopTo1 = SingleCopyMats.GetMaterialList().Count - 1; i <= loopTo1; i++)
                        CopyMaterials.InsertMaterial(SingleCopyMats.GetMaterialList()[i]);
                }

                // Finally set the cost
                TotalCopyCost = CopyMaterials.GetTotalMaterialsCost();
            }
            else
            {
                TotalCopyCost = 0d;
            } // No copies for T3

            // Set invention time
            if (IncludeInventionTime)
            {
                SetInventionTime(NumInventionSessions);
            }

            // Finally set the total invention cost for just inventing
            if (IncludeInventionCosts)
            {

                // Before updating the materials, use the cost of a single run to determine a single run invention cost. 
                // This Is an accurate cost based on the probability of success with a large number of runs
                PerInventionRunCost = SingleInventionMats.GetTotalMaterialsCost() / InventionChance / SingleInventedBPCRuns;

                // Update the invention mats to reflect the number of invention runs we will do and save into the final list
                for (int i = 0, loopTo2 = SingleInventionMats.GetMaterialList().Count - 1; i <= loopTo2; i++)
                    SingleInventionMats.GetMaterialList()[i].SetQuantity(SingleInventionMats.GetMaterialList()[i].GetQuantity() * NumInventionJobs);

                // Now insert all the materials in a new list to get the correct cost (kind of a hack, need a better process - no automatic way to update the total price in a material list)
                for (int i = 0, loopTo3 = SingleInventionMats.GetMaterialList().Count - 1; i <= loopTo3; i++)
                    InventionMaterials.InsertMaterial(SingleInventionMats.GetMaterialList()[i]);

            }

            return (int)Math.Round(Math.Ceiling(TotalInventedRuns / (double)SingleInventedBPCRuns));

        }

        // Sets the usage for Copying, which is based on the base mats cost
        private void SetCopyUsage()
        {

            if (IncludeCopyUsage & TechLevel != (int)Public_Variables.BPTechLevel.T3)
            {
                // Set the copy cost based on the number of copies we'll need for these runs
                CopyUsage = GetCopyUsage(NumInventionJobs) / TotalInventedRuns;
            }
            // InventionMaterials.InsertMaterial(New Material(0, "Copy Usage", "Usage", 1, 0, CopyUsage, ""))
            else
            {
                CopyUsage = 0d;
            } // No copies for T3
        }

        // Sets the usage for Invention, which is based on the base mats cost
        private void SetInventionUsage()
        {

            if (IncludeInventionUsage)
            {
                // Set the usage for these invention runs only
                InventionUsage = GetInventionUsage(NumInventionJobs) / TotalInventedRuns;
            }
            // Add the usage
            // InventionMaterials.InsertMaterial(New Material(0, "Invention Usage", "Usage", 1, 0, InventionUsage, ""))
            else
            {
                InventionUsage = 0d;
            }

        }

        // Sets the invention chance of the blueprint if set
        private double SetInventionChance(bool UseTypical)
        {
            double BaseInventionChance;
            int i = 0;
            SQLiteDataReader readerLookup;
            string SQL;

            var EncryptionSkillLevel = default(int);
            var InventionSkillLevels = new List<int>(); // 

            // Get the base invention chance from the activities for the T1 BPO
            SQL = "SELECT probability FROM INDUSTRY_ACTIVITY_PRODUCTS WHERE blueprintTypeID = " + InventionBPCTypeID;
            SQL += " AND activityID = 8 AND productTypeID = " + BlueprintID;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerLookup = Public_Variables.DBCommand.ExecuteReader();
            readerLookup.Read();

            if (readerLookup.HasRows)
            {
                BaseInventionChance = readerLookup.GetDouble(0);
            }
            else
            {
                BaseInventionChance = 0d;
            }

            readerLookup.Close();

            // Pull out the invention skills
            var loopTo = ReqInventionSkills.GetSkillList().Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                // Look up the level of the character's skills
                if (ReqInventionSkills.GetSkillList()[i].Name.Contains("Encryption"))
                {
                    EncryptionSkillLevel = BPCharacter.Skills.GetSkillLevel(ReqInventionSkills.GetSkillList()[i].TypeID);
                }
                else
                {
                    // A datacore or supporting skill (i.e. cap ship construction)
                    InventionSkillLevels.Add(BPCharacter.Skills.GetSkillLevel(ReqInventionSkills.GetSkillList()[i].TypeID));
                }
            }

            if (!UseTypical)
            {
                int TotalInventionSkillLevels = 0;
                foreach (var skill in InventionSkillLevels)
                    TotalInventionSkillLevels += skill;
                // BaseChance * [ 1 + (((ScienceSkill1 + ScienceSkill2 + ...) / 30) + (EncryptionSkill / 40 ))]
                InventionChance = BaseInventionChance * (1d + TotalInventionSkillLevels / 30d + EncryptionSkillLevel / 40d) * InventionDecryptor.ProductionMod;
            }
            // (1 + (0.01 * EncryptionSkillLevel) + (0.02 * (DatacoreSkillLevels(0) + DatacoreSkillLevels(1)))) * InventionDecryptor.ProductionMod
            else
            {
                // Just use typical invention costs - ie, all level 4 skills
                InventionChance = BaseInventionChance * (1d + ((4 + 4) / 30d + 4d / 40d)) * InventionDecryptor.ProductionMod;
            }

            return InventionChance;

        }

        // Sets the cost of doing the number of invention jobs sent
        private double GetInventionUsage(double InventionJobs)
        {
            // jobFee = baseJobCost * systemCostIndex * 0.02
            BaseInventionJobCost = GetBaseJobCostforBPC(InventionBPCTypeID);
            double InventionJobFee = BaseInventionJobCost * InventionFacility.CostIndex * 0.02d * InventionJobs;

            // facilityUsage = (jobFee) * taxRate
            double InventionFacilityTax = InventionJobFee * InventionFacility.TaxRate;

            // totalInstallationCost = jobFee + facilityTax * bonus for FW and invention facility
            return (InventionJobFee + InventionFacilityTax) * FWInventionCostBonus * InventionFacility.CostMultiplier;

        }

        // Sets the invention time for the sent BP 
        private void SetInventionTime(int NumInventionSessions)
        {
            string SQL;
            SQLiteDataReader readerLookup;
            double TempTime;

            // Look up the blueprint name from the sent blueprint ID
            if (TechLevel == (int)Public_Variables.BPTechLevel.T3)
            {
                // Hardcode this to 3600 for now. Later need to figure out the logic for looking it up, since the "T1" BP is a relic, we can't do anything but invent it and don't want to include it in the all_blueprints table since we only use that to select what to build
                TempTime = 3600d;
            }
            else
            {
                // Look it up
                SQL = "SELECT BASE_INVENTION_TIME FROM ALL_BLUEPRINTS_FACT WHERE BLUEPRINT_ID =" + InventionBPCTypeID;

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerLookup = Public_Variables.DBCommand.ExecuteReader();

                // inventionTime = baseInventionTime * facilityModifier * 3% of AI level * implant (doesn't work)
                if (readerLookup.Read())
                {
                    TempTime = readerLookup.GetInt64(0) * InventionFacility.TimeMultiplier * (1d - 0.03d * AdvancedIndustrySkill) * 1d; // * InventionImplantValue
                }
                else
                {
                    TempTime = 0d;
                }

                readerLookup.Close();
            }

            // Finally, set the time
            InventionTime = TempTime * NumInventionSessions;

        }

        // Sets and returns the copy cost for the number of copies sent
        private double GetCopyUsage(int NumberofCopies)
        {
            // jobFee = baseJobCost * systemCostIndex * 0.02 * runs * runsPerCopy (just use the total number of copies here)
            BaseCopyJobCost = GetBaseJobCostforBPC(InventionBPCTypeID);
            double CopyJobFee = BaseCopyJobCost * CopyFacility.CostIndex * 0.02d * NumberofCopies;

            // facilityUsage = jobFee * taxRate
            double CopyFacilityTax = CopyJobFee * CopyFacility.TaxRate;

            // totalInstallationCost = jobFee +  facilityTax * bonus for FW and copy facility
            return (CopyJobFee + CopyFacilityTax) * FWCopyingCostBonus * CopyFacility.CostMultiplier;

        }

        // Returns the copy time for a single T1 copy in seconds to copy the sent number of runs
        private double GetCopyTime(int UserCopyRuns)
        {
            string SQL;
            SQLiteDataReader readerLookup;
            decimal TempTime;

            // Look up the blueprint name from the sent blueprint ID 
            SQL = "SELECT BASE_COPY_TIME FROM ALL_BLUEPRINTS_FACT WHERE BLUEPRINT_ID =" + InventionBPCTypeID;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerLookup = Public_Variables.DBCommand.ExecuteReader();

            // copyTime = BaseCopyTime * runs * runsperBP * (1 - (0.05 * science)) * (1 - (0.03 * advancedindustry)) * facility copyslotmod * (1-implant)
            if (readerLookup.Read()) // just use the number of runs we need to make
            {
                TempTime = (decimal)(readerLookup.GetInt64(0) * (1d - 0.05d * ScienceSkill) * (1d - 0.03d * AdvancedIndustrySkill) * CopyFacility.TimeMultiplier * (1d - BPUserSettings.CopyImplantValue));
            }
            else
            {
                TempTime = 0m;
            }

            readerLookup.Close();

            return (double)(TempTime * UserCopyRuns);

        }

        // Sets the skills for inventing this blueprint (T2 or T3 blueprint types)
        private void SetInventionSkills()
        {
            string SQL = "";
            SQLiteDataReader readerItems;

            // Tech 2 items are invented from T1 blueprint copies, so take the T1 component ID and look it up for
            // the invention skill requirements (for datacores and data interface)
            SQL = "SELECT MATERIAL_ID, QUANTITY FROM ALL_BLUEPRINT_MATERIALS_FACT ";
            SQL += "WHERE BLUEPRINT_ID = " + InventionBPCTypeID + " ";
            SQL += "AND ACTIVITY = 8 AND MATERIAL_CATEGORY_ID = 16"; // 16 is Skill Category

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerItems = Public_Variables.DBCommand.ExecuteReader();

            // Just add all the skills and levels
            while (readerItems.Read())
                ReqInventionSkills.InsertSkill(readerItems.GetInt64(0), readerItems.GetInt32(1), readerItems.GetInt32(1), readerItems.GetInt32(1), 0L, false, 0, "", null, true);

            readerItems.Close();

        }

        // Sets the skills for copying this blueprint (T2 or T3 blueprint types)
        private void SetCopySkills()
        {
            string SQL = "";
            SQLiteDataReader readerItems;

            // Tech 2 items are invented from T1 blueprint copies, so take the T1 component ID and look it up for
            // the invention skill requirements (for datacores and data interface)
            SQL = "SELECT MATERIAL_ID, QUANTITY FROM ALL_BLUEPRINT_MATERIALS_FACT ";
            SQL += "WHERE BLUEPRINT_ID = " + InventionBPCTypeID + " ";
            SQL += "AND ACTIVITY = 5 AND MATERIAL_CATEGORY_ID = 16"; // 16 is Skill Category

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerItems = Public_Variables.DBCommand.ExecuteReader();

            // Just add all the skills and levels
            while (readerItems.Read())
                ReqCopySkills.InsertSkill(readerItems.GetInt64(0), readerItems.GetInt32(1), readerItems.GetInt32(1), readerItems.GetInt32(1), 0L, false, 0, "", null, true);

            readerItems.Close();

        }

        // Gets the job fee for the BPC and not the current T2/T3 bp
        private double GetBaseJobCostforBPC(long BPCTypeID)
        {
            string SQL;
            SQLiteDataReader readerLookup;
            double BaseJobCost = 0d;

            // Look up the sum of the quantity from the sent BPC ID 
            SQL = "SELECT QUANTITY, ADJUSTED_PRICE FROM ALL_BLUEPRINT_MATERIALS_FACT ";
            SQL += "LEFT OUTER JOIN ITEM_PRICES_FACT ON ALL_BLUEPRINT_MATERIALS_FACT.MATERIAL_ID = ITEM_PRICES_FACT.ITEM_ID ";
            SQL += "WHERE BLUEPRINT_ID =" + InventionBPCTypeID + " AND ACTIVITY IN (1,11) ";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerLookup = Public_Variables.DBCommand.ExecuteReader();

            while (readerLookup.Read())
                BaseJobCost += readerLookup.GetInt64(0) * (readerLookup.GetValue(1) is DBNull ? 0d : readerLookup.GetDouble(1));

            readerLookup.Close();

            return BaseJobCost;

        }

        #endregion

        #region Get Functions

        #region Invention Gets

        // Returns the copy time for a T1 copy used to make a T2
        public double GetCopyTime()
        {
            return CopyTime;
        }

        // Returns the total usage cost to make the copy
        public double GetCopyUsage()
        {
            return CopyUsage;
        }

        // Returns the total cost of materials for the copy
        public double GetCopyCost()
        {
            return CopyCost;
        }

        // Returns the list of materials used to make a copy for this BP
        public Materials GetCopyMaterials()
        {
            return CopyMaterials;
        }

        // Returns the invention time in friendly format it took to make a T2/T3 BPC 
        public double GetInventionTime()
        {
            return InventionTime;
        }

        // Gets the invention usage fees for installing this invention job for this BP
        public double GetInventionUsage()
        {
            return InventionUsage;
        }

        // Gets the total Invention Cost of this Blueprint if it can be invented
        public double GetInventionCost()
        {
            return InventionCost;
        }

        // Returns the list of invention materials used
        public Materials GetInventionMaterials()
        {
            return InventionMaterials;
        }

        // Returns the decryptor used in this BP
        public Decryptor GetDecryptor()
        {
            return InventionDecryptor;
        }

        // Returns the Relic name used in this BP
        public string GetRelic()
        {
            return Relic;
        }

        // Gets the Invention Chance this blueprint is invented if it can be
        public double GetInventionChance()
        {
            return InventionChance;
        }

        // Gets the total invented runs for each BPC
        public int GetSingleInventedBPCRuns()
        {
            return SingleInventedBPCRuns;
        }

        // Gets the total runs invented for the entire set of runs
        public int GetTotalInventedRuns()
        {
            return TotalInventedRuns;
        }

        // Returns the number of jobs we'll have to do
        public int GetInventionJobs()
        {
            return NumInventionJobs;
        }

        // Returns the Invention facility we used
        public IndustryFacility GetInventionFacility()
        {
            return InventionFacility;
        }

        // Returns the Copy facility we used
        public IndustryFacility GetCopyFacility()
        {
            return CopyFacility;
        }

        #endregion

        // Returns the manufacturing facility used
        public IndustryFacility GetManufacturingFacility()
        {
            return MainManufacturingFacility;
        }

        // Returns the component manufacturing facility used
        public IndustryFacility GetComponentManufacturingFacility()
        {
            return ComponentManufacturingFacility;
        }

        // Returns the capital component manufacturing facility used
        public IndustryFacility GetCapitalComponentManufacturingFacility()
        {
            return CapitalComponentManufacturingFacility;
        }

        // Returns the Reaction facility used
        public IndustryFacility GetReactionFacility()
        {
            return ReactionFacility;
        }

        // Returns the Reprocessing facility used
        public IndustryFacility GetReprocessingFacility()
        {
            return ReprocessingFacility;
        }

        // Returns the base job cost for this blueprint
        public double GetEstimatedItemValue()
        {
            return EIV;
        }

        // Returns the base job cost for the BPC to make this bp
        public double GetBaseInventionJobCost()
        {
            return BaseInventionJobCost;
        }

        // Returns the base job cost for the BPC to make the invention bpc
        public double GetBaseCopyJobCost()
        {
            return BaseCopyJobCost;
        }

        // Returns the Job fee based on the system index
        public double GetJobFee()
        {
            return JobFee;
        }

        // Returns the cost of setting up a job to build this item
        public double GetManufacturingFacilityUsage()
        {
            return ManufacturingFacilityUsage;
        }

        // Returns the base facility tax/fee for this blueprints components
        public double GetComponentFacilityUsage()
        {
            return ComponentFacilityUsage;
        }

        // Returns the base facility tax/fee for this blueprint's cap components
        public double GetCapComponentFacilityUsage()
        {
            return CapComponentFacilityUsage;
        }

        // Returns the base facility tax/fee usage for this blueprints reactions
        public double GetReactionFacilityUsage()
        {
            return ReactionFacilityUsage;
        }

        // Returns the total facility tax/fee usage for all reaction usage
        public double GetTotalReactionFacilityUsage()
        {
            return TotalReactionFacilityUsage;
        }

        // Returns the cost to refine any ores that were converted from minerals
        public double GetReprocessingUsage()
        {
            return ReprocessingUsage;
        }

        // Returns the max production limit for this blueprint
        public long GetMaxProductionLimit()
        {

            if (TechLevel == 1)
            {
                return MaxProductionLimit;
            }
            else if (TechLevel == 2)
            {
                if (TotalInventedRuns == 0)
                {
                    return MaxProductionLimit;
                }
                else
                {
                    return TotalInventedRuns;
                }
            }
            else
            {
                return MaxProductionLimit;
            }

        }

        // Returns the Tech Level of the blueprint
        public int GetTechLevel()
        {
            return TechLevel;
        }

        // Returns the Runs that were sent to this blueprint
        public long GetUserRuns()
        {
            return UserRuns;
        }

        // Returns the item type of the blueprint, which is really the Tech that I set instead of what is in the DB I.e. 'Augmented' drones show as T2 but act more like faction even though the BP's need T2 skills - however, they can't be invented anymore
        public int GetItemType()
        {
            return ItemType;
        }

        // Returns the Item ID made from this blueprint
        public long GetItemID()
        {
            return ItemID;
        }

        // Returns the item name made from this blueprint
        public string GetItemName()
        {
            return ItemName;
        }

        // Returns the sum of taxes for setting up a sell order for this BP item
        public double GetSalesTaxes()
        {
            return DisplayTaxes;
        }

        // Returns the total broker fees for 
        public double GetSalesBrokerFees()
        {
            return DisplayBrokerFees;
        }

        // Returns the total units this blueprint muliplied by runs, will create
        public long GetTotalUnits()
        {
            return PortionSize * UserRuns;
        }

        public long GetPortionSize()
        {
            return PortionSize;
        }

        // Returns the production time as a double for just the blueprint
        public double GetProductionTime()
        {
            return BPProductionTime;
        }

        // Returns the production time as a double for all components
        public double GetTotalProductionTime()
        {
            return TotalProductionTime;
        }

        // Returns the Race ID of the item built by this BP
        public int GetRaceID()
        {
            return BlueprintRace;
        }

        // Returns the category id for the item this BP builds
        public int GetItemCategoryID()
        {
            return ItemCategoryID;
        }

        // Function returns the array of the required character skills for building this blueprint
        public EVESkillList GetReqBPSkills()
        {
            return ReqBuildSkills;
        }

        // Returns the total cost of the blueprint using raw materials
        public double GetTotalRawCost()
        {
            return TotalRawCost;
        }

        // Returns the total build cost, which is everything except taxes and fees (? Not sure why I did this - it doesn't match up with double click to BP tab)
        public double GetTotalBuildCost()
        {
            return TotalRawCost;
            // Dim BuildCost As Double = TotalRawCost

            // If DisplayTaxes <> 0 Then
            // BuildCost -= Taxes
            // End If
            // Return BuildCost - BrokerFees
        }

        // Returns the total cost of the blueprint using components
        public double GetTotalComponentCost()
        {
            return TotalComponentCost;
        }

        // Returns the total profit for the blueprint using raw materials
        public double GetTotalRawProfit()
        {
            return TotalRawProfit;
        }

        // Returns the total profit for the blueprint using components
        public double GetTotalComponentProfit()
        {
            return TotalComponentProfit;
        }

        // Returns the total profitas a percent for the blueprint using raw materials
        public double GetTotalRawProfitPercent()
        {
            return TotalRawProfitPercent;
        }

        // Returns the total profit as a percent for the blueprint using components
        public double GetTotalComponentProfitPercent()
        {
            return TotalComponentProfitPercent;
        }

        // Returns the amount we used to calculate sell excess
        public double GetSellExcessAmount()
        {
            return SellExcessAmount;
        }

        // Returns the excess materials in a list of materials 
        public Materials GetExcessMaterials()
        {
            return ExcessMaterials;
        }

        // Returns the Isk per hour using Raw mats
        public double GetTotalIskperHourRaw()
        {
            return TotalIPHRaw;
        }

        // Returns the Isk per hour using components
        public double GetTotalIskperHourComponents()
        {
            return TotalIPHComponent;
        }

        // Returns whether this BP had buildable components or not
        public bool HasComponents()
        {
            return HasBuildableComponents;
        }

        // Returns the BP ID
        public int GetBPID()
        {
            return BlueprintID;
        }

        // Gets the Item's GroupID of the blueprint
        public int GetItemGroupID()
        {
            return ItemGroupID;
        }

        // Gets the built item's volume
        public double GetItemVolume()
        {
            return ItemVolume;
        }

        // Gets the total volume of the items built
        public double GetTotalItemVolume()
        {
            return ItemVolume * UserRuns;
        }

        // Returns the required skills to build all the components for this bp
        public EVESkillList GetReqComponentSkills()
        {
            return ReqBuildComponentSkills;
        }

        // Function returns the array of all the character skills to invent this blueprint
        public EVESkillList GetReqInventionSkills()
        {
            return ReqInventionSkills;
        }

        // Function returns the array of all the character skills to copy this blueprint
        public EVESkillList GetReqCopySkills()
        {
            return ReqCopySkills;
        }

        // Returns the total list of raw materials for the Blueprint
        public Materials GetRawMaterials()
        {
            return RawMaterials;
        }

        // Returns the Components and other mats for the Blueprint
        public Materials GetComponentMaterials()
        {
            return ComponentMaterials;
        }

        private Materials GetBPRawMaterials()
        {
            return BPRawMats;
        }

        // Returns the component lists used to build this item, with materials
        public BuiltItemList GetComponentsList()
        {
            return BuiltComponentList;
        }

        // Returns information on the item that this BP makes, For now, name, runs and the type id
        public Material GetItemData()
        {
            Material TempMat;
            SQLiteDataReader rsGroup;
            Public_Variables.DBCommand = new SQLiteCommand("SELECT groupName FROM INVENTORY_GROUPS WHERE groupID = " + ItemGroupID.ToString(), Public_Variables.EVEDB.DBREf());
            rsGroup = Public_Variables.DBCommand.ExecuteReader();
            rsGroup.Read();

            // Volume doesn't matter
            TempMat = new Material(ItemID, ItemName, rsGroup.GetString(0), UserRuns, 0d, ItemMarketCost, "", "");

            rsGroup.Close();

            return TempMat;

        }

        // Returns the TypeID of the BP
        public int GetTypeID()
        {
            return BlueprintID;
        }

        // Returns the blueprint name
        public string GetName()
        {
            return BlueprintName;
        }

        // Returns the number of blueprints used
        public int GetUsedNumBPs()
        {
            return NumberofBlueprints;
        }

        // Gets the market price of the produced item from this blueprint
        public double GetItemMarketPrice()
        {
            return ItemMarketCost;
        }

        // Gets the raw build cost for one unit
        public double GetRawItemUnitPrice()
        {
            return GetTotalBuildCost() / PortionSize;
        }

        // Gets the component build cost for one unit
        public double GetComponentItemUnitPrice()
        {
            return GetTotalComponentCost() / PortionSize;
        }

        // Returns T/F if the user for this blueprint can build  the blueprint
        public bool UserCanBuildBlueprint()
        {
            return CanBuildBP;
        }

        // Returns T/F if the user for this blueprint can build all components
        public bool UserCanBuildAllComponents()
        {
            return CanBuildAll;
        }

        public bool UserCanInventRE()
        {
            return CanInventRE;
        }

        // Returns the ME of the blueprint
        public int GetME()
        {
            return iME;
        }

        // Returns the TE of the blueprint
        public int GetTE()
        {
            return iTE;
        }

        // Returns the additional costs the user sent in
        public double GetAdditionalCosts()
        {
            return AdditionalCosts;
        }

        #endregion

    }
}