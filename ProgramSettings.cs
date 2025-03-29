using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public static class SettingsVariables
    {

        // All settings
        public static ProgramSettings AllSettings = new ProgramSettings();
        // User Settings
        public static ApplicationSettings UserApplicationSettings;
        // BP Tab Settings
        public static BPTabSettings UserBPTabSettings;
        // Market History viewer
        public static MarketHistoryViewerSettings UserMHViewerSettings;
        // Manufacturing
        public static ManufacturingTabSettings UserManufacturingTabSettings;
        // Datacores
        public static DataCoreTabSettings UserDCTabSettings;
        // Update Prices Tab Settings
        public static UpdatePriceTabSettings UserUpdatePricesTabSettings;
        // Mining Tab Settings
        public static MiningTabSettings UserMiningTabSettings;
        // Industry Job Column Settings
        public static IndustryJobsColumnSettings UserIndustryJobsColumnSettings;
        // Manufacturing Tab Column Settings
        public static ManufacturingTabColumnSettings UserManufacturingTabColumnSettings;
        // Shopping List settings
        public static ShoppingListSettings UserShoppingListSettings;
        // Industry Flip Belt Settings
        public static IndustryFlipBeltSettings UserIndustryFlipBeltSettings;
        // and the five belts
        public static IndustryBeltOreChecks UserIndustryFlipBeltOreCheckSettings1;
        public static IndustryBeltOreChecks UserIndustryFlipBeltOreCheckSettings2;
        public static IndustryBeltOreChecks UserIndustryFlipBeltOreCheckSettings3;
        public static IndustryBeltOreChecks UserIndustryFlipBeltOreCheckSettings4;
        public static IndustryBeltOreChecks UserIndustryFlipBeltOreCheckSettings5;
        // Asset windows - multiple
        public static AssetWindowSettings UserAssetWindowDefaultSettings;
        public static AssetWindowSettings UserAssetWindowManufacturingTabSettings;
        public static AssetWindowSettings UserAssetWindowShoppingListSettings;
        public static AssetWindowSettings UserAssetWindowRefinerySettings;
        // For the Blueprint List Viewer
        public static BPViewerSettings UserBPViewerSettings;
        // For Upwell Structure viewer
        public static UpwellStructureSettings UserUpwellStructureSettings;
        // For bonus popout on structure viewer
        public static StructureBonusPopoutSettings StructureBonusPopoutViewerSettings;

        public static IceBeltFlipSettings UserIceBeltFlipSettings;
        public static IceBeltCheckSettings UserIceBeltCheckSettings;

        public static ConversionToOreSettings UserConversiontoOreSettings;

    }

    public class ProgramSettings
    {

        // Default Tower Settings
        public const string DefaultTowerName = Public_Variables.None;
        public const int DefaultTowerRaceID = 0;
        public const int DefaultCostperHour = 0;
        public const string DefaultTowerType = "Standard";
        public const string DefaultTowerSize = "Large";
        public const bool DefaultFuelBlockBuild = false;
        public const double DefaultCharterCost = 2500.0d;

        // Application Setting Defaults
        public string MBeanCounterName = "Zainou 'Beancounter' Industry BX-80"; // Manufacturing time
        public string RBeanCounterName = "Zainou 'Beancounter' Reprocessing RX-80"; // Refining waste
        public string CBeanCounterName = "Zainou 'Beancounter' Science SC-80"; // Copy time

        public bool DefaultCheckUpdatesOnStart = true;
        public bool DefaultAllowSkillOverride = false;
        public string DefaultDataExportFormat = "Default";
        public bool DefaultShowToolTips = true;
        public bool DefaultLoadAssetsonStartup = true;
        public bool DefaultLoadBPsonStartup = true;
        public bool DefaultRefreshMarketESIDataonStartup = true;
        public bool DefaultRefreshFacilityESIDataonStartup = true;
        public bool DefaultRefreshPublicStructureDataonStartup = true;
        public bool DefaultSupressESIStatusMessages = false;
        public bool DefaultDisableSound = false;
        public bool DefaultDNMarkInlineasOwned = false;
        public bool DefaultSaveFacilitiesbyChar = true;
        public bool DefaultLoadBPsbyChar = true;

        public double DefaultBuildBaseInstall = 1000d;
        public double DefaultBuildBaseHourly = 333d;
        public double DefaultBuildStandingDiscount = 0.015d;
        public double DefaultBuildStandingSurcharge = 0.005d;

        public double DefaultInventBaseInstall = 10000d;
        public double DefaultInventBaseHourly = 416.67d;
        public double DefaultInventStandingDiscount = 0.015d;
        public double DefaultInventStandingSurcharge = 0.005d;

        public double DefaultBuildCorpStanding = 5.0d; // Corp standing of where this blueprint will be made
        public double DefaultInventCorpStanding = 5.0d; // Corp standing of where this blueprint will be invented
        public double DefaultBrokerCorpStanding = 5.0d; // Corp standing of where this blueprint will be sold
        public double DefaultBrokerFactionStanding = 5.0d; // Faction standing of where this blueprint will be sold (for Broker calc)

        public double DefaultBaseSalesTaxRate = 4.5d; // Sales tax base is 4.5% and during holidays they may change it
        public double DefaultBaseBrokerFeeRate = 3d; // 3%
        public double DefaultSCCBrokerFeeSurcharge = 0.005d; // Fixed rate of 0.5%
        public double DefaultSCCIndustryFeeSurcharge = 0.04d; // Fixed rate of 4% on 2/1/2024
        public double DefaultAlphaAccountTaxRate = 0.0025d; // fixed to 0.25%
        public double DefaultStructureTaxRate = 0.0d; // 0% to start for structures
        public double DefaultStationTaxRate = 0.0025d; // 0.25% for all stations

        public bool DefaultIncludeCopyTimes = false; // If we include copy times in IPH calcs for invention
        public bool DefaultIncludeInventionTimes = false; // If we include invention times in IPH calcs for invention
        public bool DefaultIncludeRETimes = false; // If we include RE times in IPH calcs for RE

        public bool DefaultEstimateCopyCost = false; // Estimate copy costs for invention BPC's
        public string DefaultCopySlotModifier = "1.0"; // The default copy slot modifier for T1 BPC copies to use in invention
        public string DefaultInventionSlotModifier = "1.0"; // Default invention time
        public string DefaultBuildSlotModifier = "1.0"; // Default build time for production

        public bool DefaultCheckBuildBuy = false;
        public bool DefaultIgnoreRareandShipSkinBPs = true;
        public bool DefaultSaveBPRelicsDecryptors = false;
        public bool DefaultRefineDrillDown = false;

        public bool DefaultAlwaysBuyFuelBlocks = false;
        public bool DefaultAlwaysBuyRAMs = false;

        public int DefaultSettingME = 0;
        public int DefaultSettingTE = 0;

        public bool DefaultDisableSVR = false;
        public bool DefaultDisableGATracking = false;
        public bool DefaultShareSavedFacilities = true;
        public bool DefaultSuggestBuildBPNotOwned = true; // If the bp is not owned, default to suggesting they build the item anyway

        public bool DefaultAlphaAccount = false;
        public bool DefaultUseActiveSkills = false;
        public bool DefaultLoadMaxAlphaSkills = false;

        // SVR Stuff
        public double DefaultIgnoreSVRThresholdValue = 0.0d;
        public string DefaultSVRAveragePriceRegion = "The Forge";
        public string DefaultSVRAveragePriceDuration = "7";
        public bool DefaultAutoUpdateSVRonBPTab = true;

        public bool DefaultIncludeInGameLinksinCopyText = false;

        // Proxy
        public string DefaultProxyAddress = "";
        public int DefaultProxyPort = 0;

        // For shopping list
        public bool DefaultShopListIncludeInventMats = true;
        public bool DefaultShopListIncludeCopyMats = true;

        // If the user has no implants
        public double DefaultImplantValues = 0d;

        public double FacilityDefaultMM = 1d;
        public double FacilityDefaultTM = 1d;
        public double FacilityDefaultCM = 1d;
        public double FacilityDefaultTax = 0.1d; // Only for processing
        public double OutpostDefaultTax = 0d; // If we are saving the settings, then the only time would be for outposts

        public double FacilityDefaultActivityCostperSecond = 0d;
        public bool FacilityDefaultIncludeUsage = true;
        public bool FacilityDefaultIncludeCost = false; // Only for Invention, Copy, and RE so let this get set 
        public bool FacilityDefaultIncludeTime = false; // Only for Invention, Copy, and RE so let this get set 

        // Set here, but use in Update Prices - 10 minutes
        public int DefaultUpdatePricesRefreshInterval = 10;

        public int DefaultBuiltMatsType = 1; // use enum BuildMatType - both BP and Manufacturing tabs

        // BP Tab Default settings
        public bool DefaultBPTechChecks = true;
        public bool DefaultSizeChecks = false;
        public string DefaultBPSelectionType = "All";
        public int DefaultBPIncludeFees = 0;
        public double DefaultBPBrokerFeeRate = 0.05d;
        public bool DefaultBPIncludeTaxes = true;
        public bool DefaultBPIncludeUsage = true;
        public bool DefaultBPIgnoreChecks = false;
        public bool DefaultBPPricePerUnit = false;
        public bool DefaultBPIncludeInventionTime = false;
        public bool DefaultBPIncludeInventionCost = true;
        public bool DefaultBPIncludeCopyTime = false;
        public bool DefaultBPIncludecopyCost = true;
        public bool DefaultBPIncludeT3Cost = false;
        public bool DefaultBPIncludeT3Time = false;
        public bool DefaultBPSimpleCopyCheck = false;
        public bool DefaultBPNPCBPOs = false;
        public int DefaultBPProductionLines = 1;
        public int DefaultBPLaboratoryLines = 1;
        public int DefaultBPRELines = 1;
        public string DefaultBPRelicType = ""; // If they want to save and auto load relic types
        public string DefaultBPT3DecryptorType = ""; // if they want to save and auto load decryptors
        public string DefaultBPT2DecryptorType = ""; // if they want to save and auto load decryptors
        public bool DefaultBPIgnoreInvention = false;
        public bool DefaultBPIgnoreMinerals = false;
        public bool DefaultBPIgnoreT1Item = false;
        public bool DefaultBPIncludeIgnoredBPs = false;
        public string DefaultBPShoppingListExportType = "Components";
        public int DefaultBPCompColumnSort = 1;
        public string DefaultBPCompColumnSortType = "Decending";
        public int DefaultBPRawColumnSort = 1;
        public string DefaultBPRawColumnSortType = "Decending";
        public string DefaultBPRawProfitType = "Profit";
        public string DefaultBPCompProfitType = "Profit";
        public bool DefaultBPCompressedOre = false;
        public bool DefaultBPSellExcessItems = true;

        // Update Prices Default Settings
        public bool DefaultPriceChecks = true;
        public string DefaultPriceSystem = "Jita";
        public string DefaultPriceRegion = "The Forge";
        public string DefaultPriceRawMatsCombo = "Min Sell";
        public string DefaultPriceItemsCombo = "Min Sell";
        public int DefaultUPColumnSort = 1;
        public string DefaultUPColumnSortType = "Ascending";
        public double DefaultRawPriceModifier = 0d;
        public double DefaultItemsPriceModifier = 0d;
        public int DefaultUseESIData = 0;
        public bool DefaultUsePriceProfile = false;
        public string DefaultPPRawPriceType = "Max Buy";
        public string DefaultPPRawRegion = "The Forge";
        public string DefaultPPRawSystem = "Jita";
        public double DefaultPPRawPriceMod = 0d;
        public string DefaultPPItemsPriceType = "Min Sell";
        public string DefaultPPItemsRegion = "The Forge";
        public string DefaultPPItemsSystem = "Jita";
        public double DefaultPPItemsPriceMod = 0d;

        // Default Manufacturing Tab
        public string DefaultBlueprintType = "All Blueprints";
        public bool DefaultCheckTech1 = true;
        public bool DefaultCheckTech2 = true;
        public bool DefaultCheckTech3 = true;
        public bool DefaultCheckTechStoryline = true;
        public bool DefaultCheckTechNavy = true;
        public bool DefaultCheckTechPirate = true;
        public string DefaultItemTypeFilter = "All Types";
        public string DefaultTextItemFilter = "";
        public bool DefaultCheckBPTypeShips = true;
        public bool DefaultCheckBPTypeDrones = true;
        public bool DefaultCheckBPTypeComponents = true;
        public bool DefaultCheckBPTypeStructures = true;
        public bool DefaultCheckBPTypeTools = true;
        public bool DefaultCheckBPTypeModules = true;
        public bool DefaultCheckBPTypeNPCBPOs = false;
        public bool DefaultCheckBPTypeAmmoCharges = true;
        public bool DefaultCheckBPTypeRigs = true;
        public bool DefaultCheckBPTypeSubsystems = true;
        public bool DefaultCheckBPTypeBoosters = true;
        public bool DefaultCheckBPTypeDeployables = true;
        public bool DefaultCheckBPTypeCelestials = true;
        public bool DefaultCheckBPTypeReactions = true;
        public bool DefaultCheckBPTypeStructureModules = true;
        public bool DefaultCheckBPTypeStationParts = true;
        public bool DefaultCheckDecryptorNone = true;
        public int DefaultCheckDecryptorOptimal = 0;
        public bool DefaultCheckDecryptor06 = false;
        public bool DefaultCheckDecryptor09 = false;
        public bool DefaultCheckDecryptor10 = false;
        public bool DefaultCheckDecryptor11 = false;
        public bool DefaultCheckDecryptor12 = false;
        public bool DefaultCheckDecryptor15 = false;
        public bool DefaultCheckDecryptor18 = false;
        public bool DefaultCheckDecryptor19 = false;
        public bool DefaultCheckDecryptorUseforT2 = true;
        public bool DefaultCheckDecryptorUseforT3 = true;
        public bool DefaultCheckIgnoreInvention = false;
        public bool DefaultCheckRelicWrecked = true;
        public bool DefaultCheckRelicIntact = false;
        public bool DefaultCheckRelicMalfunction = false;
        public bool DefaultCheckOnlyBuild = false;
        public bool DefaultCheckOnlyInvent = false;
        public bool DefaultCheckIncludeTaxes = true;
        public int DefaultIncludeBrokersFees = 0;
        public double DefaultCalcBrokerFeeRate = 0.05d;
        public bool DefaultCheckIncludeUsage = true;
        public bool DefaultCheckRaceAmarr = true;
        public bool DefaultCheckRaceCaldari = true;
        public bool DefaultCheckRaceGallente = true;
        public bool DefaultCheckRaceMinmatar = true;
        public bool DefaultCheckRacePirate = true;
        public bool DefaultCheckRaceOther = true;
        public string DefaultPriceCompare = "Compare All";
        public bool DefaultCheckIncludeT2Owned = true;
        public bool DefaultCheckIncludeT3Owned = true;
        public bool DefaultCheckSVRIncludeNull = true;
        public int DefaultCalcProductionLines = 1;
        public int DefaultCalcLaboratoryLines = 1;
        public int DefaultCalcRuns = 1;
        public int DefaultCalcBPRuns = 1;
        public bool DefaultCheckAutoCalcNumBPs = true;
        public bool DefaultCalcSizeChecks = false;
        public bool DefaultCheckT3Destroyers = false;
        public bool DefaultCheckCapComponents = false;
        public bool DefaultCalcIgnoreInvention = false;
        public bool DefaultCalcIgnoreMinerals = false;
        public bool DefaultCalcIgnoreT1Item = false;
        public bool DefaultCalcPPU = false;
        public string DefaultCalcManufacturingFWLevel = "0";
        public string DefaultCalcCopyingFWLevel = "0";
        public string DefaultCalcInventionFWLevel = "0";
        public int DefaultCalcColumnSort = 10; // Default is sorting descending by IPH
        public string DefaultCalcColumnType = "Decending";
        public string DefaultCalcPriceTrend = "All";
        public string DefaultCalcMinBuildTime = "0 Days 00:00:00";
        public bool DefaultCalcMinBuildTimeCheck = false;
        public string DefaultCalcMaxBuildTime = "1 Days 00:00:00";
        public bool DefaultCalcMaxBuildTimeCheck = false;
        public double DefaultCalcIPHThreshold = 0d;
        public bool DefaultCalcIPHThresholdCheck = false;
        public double DefaultCalcProfitThreshold = 0d;
        public int DefaultCalcProfitThresholdCheck = 0;
        public double DefaultCalcVolumeThreshold = 0d;
        public bool DefaultCalcVolumeThresholdCheck = false;
        public bool DefaultCalcSellExcessItems = true;

        // Datacore Default Settings
        public string DefaultDCPricesFrom = "Updated Prices";
        public bool DefaultDCCheckHighSec = true;
        public bool DefaultDCCheckLowNullSec = false;
        public bool DefaultDCIncludeAgentsCantUse = false;
        public string DefaultDCAgentsInRegion = "All Regions";
        public bool DefaultDCSovCheck = true;
        public int DefaultDCColumnSort = 10;
        public string DefaultDCColumnSortType = "Decending";

        // Datacores For these, use the users settings
        public int DefaultConnections = -1;
        public int DefaultNegotiation = -1;
        public int DefaultResearchProjMgt = -1;
        public int DefaultCorpStanding = -1;
        public int DefaultCorpStandingChecked = -1;
        public int DefaultSkillLevel = -1;
        public int DefaultSkillLevelChecked = -1;

        // Datacore setting array sizes
        public int NumberofDCSettingsSkillRecords = 16;
        public int NumberofDCSettingsCorpRecords = 12;

        // Reactions Default Settings
        public double DefaultReactPOSFuelCost = 500000.0d;
        public bool DefaultReactCheckTaxes = true;
        public bool DefaultReactCheckFees = true;
        public bool DefaultReactItemChecks = false;
        public int DefaultReactNumPOS = 1;
        public int DefaultReactColumnSort = 5;
        public string DefaultReactColumnSortType = "Decending";

        // Mining Default Settings
        public string DefaultMiningOreType = "Ore";
        public bool DefaultMiningCheckHighYieldOres = false;
        public bool DefaultMiningCheckHighSecOres = true;
        public bool DefaultMiningCheckLowSecOres = false;
        public bool DefaultMiningCheckNullSecOres = false;
        public bool DefaultMiningCheckA0Ores = false;
        public bool DefaultMiningCheckSovAmarr = true;
        public bool DefaultMiningCheckSovCaldari = true;
        public bool DefaultMiningCheckSovGallente = true;
        public bool DefaultMiningCheckSovMinmatar = true;
        public bool DefaultMiningCheckSovTriglavian = true;
        public bool DefaultMiningCheckEDENCOM = false;
        public bool DefaultMiningCheckSovWormhole = true;
        public bool DefaultMiningCheckSovMoon = true;
        public bool DefaultMiningCheckSovC1 = true;
        public bool DefaultMiningCheckSovC2 = true;
        public bool DefaultMiningCheckSovC3 = true;
        public bool DefaultMiningCheckSovC4 = true;
        public bool DefaultMiningCheckSovC5 = true;
        public bool DefaultMiningCheckSovC6 = true;
        public bool DefaultMiningCheckIncludeFees = true;
        public double DefaultMiningBrokerFeeRate = 0.05d;
        public bool DefaultMiningCheckIncludeTaxes = true;
        public bool DefaultMiningCheckIncludeJumpFuelCosts = false;
        public int DefaultMiningTotalJumpFuelCost = 0;
        public int DefaultMiningTotalJumpFuelM3 = 1;
        public bool DefaultMiningJumpCompressedOre = true;
        public bool DefaultMiningJumpMinerals = false;
        public string DefaultMiningMiningShip = ""; // Keep this blank so that it will default to a ship for them, if they have the skills
        public string DefaultMiningIceMiningShip = ""; // Keep this blank so that it will default to a ship for them, if they have the skills
        public string DefaultMiningGasMiningShip = "";
        public string DefaultMiningOreStrip = ""; // Keep blank to set max possible strip/miner they can use
        public string DefaultMiningIceStrip = ""; // Keep blank so they can set the max possible ice strip
        public string DefaultMiningGasHarvester = "";
        public int DefaultMiningNumOreMiners = 0;
        public int DefaultMiningNumIceMiners = 0;
        public int DefaultMiningNumGasHarvesters = 0;
        public string DefaultMiningOreUpgrade = Public_Variables.None;
        public string DefaultMiningIceUpgrade = Public_Variables.None;
        public string DefaultMiningGasUpgrade = Public_Variables.None;
        public int DefaultMiningNumOreUpgrades = 0;
        public int DefaultMiningNumIceUpgrades = 0;
        public int DefaultMiningNumGasUpgrades = 0;
        public bool DefaultMiningMichiiImplant = false;
        public bool DefaultMiningCrystals = false;
        public bool DefaultMiningCrystalType = false;
        public string DefaultMiningOreImplant = Public_Variables.None;
        public string DefaultMiningIceImplant = Public_Variables.None;
        public string DefaultMiningGasImplant = Public_Variables.None;
        public string DefaultBeancounterImplant = Public_Variables.None;
        public string DefaultMiningRig = Public_Variables.None;
        public bool DefaultMiningCheckUseHauler = true;
        public int DefaultMiningRoundTripMin = 1;
        public int DefaultMiningRoundTripSec = 0;
        public int DefaultMiningHaulerm3 = 0;
        public bool DefaultMiningCheckUseFleetBooster = false;
        public string DefaultMiningBoosterShip = "Other";
        public int DefaultMiningBoosterShipSkill = 0;
        public int DefaultMiningMiningFormanSkill = 0;
        public int DefaultMiningMiningDirectorSkill = 0;
        public int DefaultMiningWarfareLinkSpecSkill = 0;
        public int DefaultMiningCheckMineForemanLaserOpBoost = 0;
        public bool DefaultMiningCheckMiningForemanMindLink = false;
        public double DefaultMiningRefineCorpTax = 0.05d;
        public int DefaultMiningRorqDeployed = 0;
        public double DefaultMiningDroneM3perHour = 0.0d;
        public bool DefaultMiningRefinedOre = true;
        public bool DefaultMiningCompressedOre = false;
        public bool DefaultMiningUnrefinedOre = false;
        public int DefaultMiningIndustrialReconfig = 0;
        public int DefaultMiningNumberofMiners = 1;
        public int DefaultMiningColumnSort = 9;
        public string DefaultMiningColumnSortType = "Decending";
        public string DefaultMiningDrone = "None";
        public string DefaultNumMiningDrone = "0";
        public string DefaultIceMiningDrone = "None";
        public string DefaultNumIceMiningdrone = "0";
        public string DefaultDroneSkills = "-1";
        public string DefaultDroneRigs = Public_Variables.None;
        public int DefaultBoosterDroneRigs = 0;
        public bool DefaultBoosterUseDrones = false;

        // Industry Jobs column settings
        public int DefaultJobState = 1;
        public int DefaultInstallerName = 2;
        public int DefaultTimeToComplete = 4;
        public int DefaultActivity = 3;
        public int DefaultStatus = 0;
        public int DefaultStartTime = 0;
        public int DefaultEndTime = 0;
        public int DefaultCompletionTime = 0;
        public int DefaultBlueprint = 5;
        public int DefaultOutputItem = 6;
        public int DefaultOutputItemType = 0;
        public int DefaultInstallSolarSystem = 7;
        public int DefaultInstallRegion = 8;
        public int DefaultLicensedRuns = 0;
        public int DefaultRuns = 0;
        public int DefaultSuccessfulRuns = 0;
        public int DefaultBlueprintLocation = 9;
        public int DefaultOutputLocation = 10;
        public int DefaultJobType = 11;
        public int DefaultLocalCompletionDateTime = 0;
        public string DefaultViewJobType = "Personal";
        public string DefaultJobTimes = "Current Jobs";
        public string DefaultSelectedCharacterIDs = "";
        public int DefaultIndustryColumnWidth = 100;
        public int DefaultOrderByColumn = 3;
        public string DefaultOrderType = "Ascending";
        public bool DefaultAutoUpdateJobs = true;

        // Column Names for industry jobs viewer
        public const string JobStateColumn = "Job State";
        public const string InstallerNameColumn = "Installer";
        public const string TimetoCompleteColumn = "Time to Complete";
        public const string ActivityColumn = "Activity";
        public const string StatusColumn = "Status";
        public const string StartTimeColumn = "Start Time";
        public const string EndTimeColumn = "End Time";
        public const string CompletionTimeColumn = "Completed Time";
        public const string BlueprintColumn = "Blueprint";
        public const string OutputItemColumn = "Output Item";
        public const string OutputItemTypeColumn = "Output Item Type";
        public const string InstallSolarSystemColumn = "Install System";
        public const string InstallRegionColumn = "Install Region";
        public const string LicensedRunsColumn = "Licensed Runs";
        public const string RunsColumn = "Runs";
        public const string SuccessfulRunsColumn = "Successful Runs";
        public const string BlueprintLocationColumn = "Blueprint Location";
        public const string OutputLocationColumn = "Output Location";
        public const string JobTypeColumn = "Job Type";
        public const string LocalCompletionDateTimeColumn = "Local Completion Time";

        // Manufacturing Tab column settings - index 0 is for hidden id column
        private int DefaultMTItemCategory = 3;
        private int DefaultMTItemGroup = 0;
        private int DefaultMTItemName = 4;
        private int DefaultMTOwned = 5;
        private int DefaultMTTech = 6;
        private int DefaultMTBPME = 7;
        private int DefaultMTBPTE = 8;
        private int DefaultMTInputs = 9;
        private int DefaultMTCompared = 10;
        private int DefaultMTTotalRuns = 0;
        private int DefaultMTSingleInventedBPCRuns = 0;
        private int DefaultMTProductionLines = 0;
        private int DefaultMTLaboratoryLines = 0;
        private int DefaultMTTotalInventionCost = 0;
        private int DefaultMTTotalCopyCost = 0;
        private int DefaultMTTaxes = 0;
        private int DefaultMTBrokerFees = 0;
        private int DefaultMTBPProductionTime = 0;
        private int DefaultMTTotalProductionTime = 0;
        private int DefaultMTCopyTime = 0;
        private int DefaultMTInventionTime = 0;
        private int DefaultMTItemMarketPrice = 0;
        private int DefaultMTProfit = 11;
        private int DefaultMTProfitPercentage = 0;
        private int DefaultMTIskperHour = 12;
        private int DefaultMTSVR = 13;
        private int DefaultMTSVRxIPH = 0;
        private int DefaultMTPriceTrend = 0;
        private int DefaultMTTotalItemsSold = 0;
        private int DefaultMTTotalOrdersFilled = 0;
        private int DefaultMTAvgItemsperOrder = 0;
        private int DefaultMTCurrentSellOrders = 0;
        private int DefaultMTCurrentBuyOrders = 0;
        private int DefaultMTItemsinProduction = 0;
        private int DefaultMTItemsinStock = 0;
        private int DefaultMTMaterialCost = 0;
        private int DefaultMTTotalCost = 14;
        private int DefaultMTBaseJobCost = 0;
        private int DefaultMTNumBPs = 0;
        private int DefaultMTInventionChance = 0;
        private int DefaultMTBPType = 0;
        private int DefaultMTRace = 0;
        private int DefaultMTVolumeperItem = 0;
        private int DefaultMTTotalVolume = 0;
        private int DefaultMTSellExcess = 0;
        private int DefaultMTROI = 0;
        private int DefaultMTPortionSize = 0;
        private int DefaultMTManufacturingJobFee = 0;
        private int DefaultMTManufacturingFacilityName = 0;
        private int DefaultMTManufacturingFacilitySystem = 0;
        private int DefaultMTManufacturingFacilityRegion = 0;
        private int DefaultMTManufacturingFacilitySystemIndex = 0;
        private int DefaultMTManufacturingFacilityTax = 0;
        private int DefaultMTManufacturingFacilityMEBonus = 0;
        private int DefaultMTManufacturingFacilityTEBonus = 0;
        private int DefaultMTManufacturingFacilityUsage = 0;
        private int DefaultMTManufacturingFacilityFWSystemLevel = 0;
        private int DefaultMTComponentFacilityName = 0;
        private int DefaultMTComponentFacilitySystem = 0;
        private int DefaultMTComponentFacilityRegion = 0;
        private int DefaultMTComponentFacilitySystemIndex = 0;
        private int DefaultMTComponentFacilityTax = 0;
        private int DefaultMTComponentFacilityMEBonus = 0;
        private int DefaultMTComponentFacilityTEBonus = 0;
        private int DefaultMTComponentFacilityUsage = 0;
        private int DefaultMTComponentFacilityFWSystemLevel = 0;
        private int DefaultMTCapComponentFacilityName = 0;
        private int DefaultMTCapComponentFacilitySystem = 0;
        private int DefaultMTCapComponentFacilityRegion = 0;
        private int DefaultMTCapComponentFacilitySystemIndex = 0;
        private int DefaultMTCapComponentFacilityTax = 0;
        private int DefaultMTCapComponentFacilityMEBonus = 0;
        private int DefaultMTCapComponentFacilityTEBonus = 0;
        private int DefaultMTCapComponentFacilityUsage = 0;
        private int DefaultMTCapComponentFacilityFWSystemLevel = 0;
        private int DefaultMTCopyingFacilityName = 0;
        private int DefaultMTCopyingFacilitySystem = 0;
        private int DefaultMTCopyingFacilityRegion = 0;
        private int DefaultMTCopyingFacilitySystemIndex = 0;
        private int DefaultMTCopyingFacilityTax = 0;
        private int DefaultMTCopyingFacilityMEBonus = 0;
        private int DefaultMTCopyingFacilityTEBonus = 0;
        private int DefaultMTCopyingFacilityUsage = 0;
        private int DefaultMTCopyingFacilityFWSystemLevel = 0;
        private int DefaultMTInventionFacilityName = 0;
        private int DefaultMTInventionFacilitySystem = 0;
        private int DefaultMTInventionFacilityRegion = 0;
        private int DefaultMTInventionFacilitySystemIndex = 0;
        private int DefaultMTInventionFacilityTax = 0;
        private int DefaultMTInventionFacilityMEBonus = 0;
        private int DefaultMTInventionFacilityTEBonus = 0;
        private int DefaultMTInventionFacilityUsage = 0;
        private int DefaultMTInventionFacilityFWSystemLevel = 0;
        private int DefaultMTReactionFacilityName = 0;
        private int DefaultMTReactionFacilitySystem = 0;
        private int DefaultMTReactionFacilityRegion = 0;
        private int DefaultMTReactionFacilitySystemIndex = 0;
        private int DefaultMTReactionFacilityTax = 0;
        private int DefaultMTReactionFacilityMEBonus = 0;
        private int DefaultMTReactionFacilityTEBonus = 0;
        private int DefaultMTReactionFacilityUsage = 0;
        private int DefaultMTReactionFacilityFWSystemLevel = 0;
        private int DefaultMTReprocessingFacilityName = 0;
        private int DefaultMTReprocessingFacilitySystem = 0;
        private int DefaultMTReprocessingFacilityRegion = 0;
        private int DefaultMTReprocessingFacilityTax = 0;
        private int DefaultMTReprocessingFacilityUsage = 0;
        private int DefaultMTReprocessingFacilityOreRefineRate = 0;
        private int DefaultMTReprocessingFacilityIceRefineRate = 0;
        private int DefaultMTReprocessingFacilityMoonRefineRate = 0;

        private int DefaultMTItemCategoryWidth = 100;
        private int DefaultMTItemGroupWidth = 100;
        private int DefaultMTItemNameWidth = 225;
        private int DefaultMTOwnedWidth = 50;
        private int DefaultMTTechWidth = 37;
        private int DefaultMTBPMEWidth = 28;
        private int DefaultMTBPTEWidth = 28;
        private int DefaultMTInputsWidth = 150;
        private int DefaultMTComparedWidth = 80;
        private int DefaultMTTotalRunsWidth = 64;
        private int DefaultMTSingleInventedBPCRunsWidth = 138;
        private int DefaultMTProductionLinesWidth = 92;
        private int DefaultMTLaboratoryLinesWidth = 92;
        private int DefaultMTTotalInventionCostWidth = 107;
        private int DefaultMTTotalCopyCostWidth = 88;
        private int DefaultMTTaxesWidth = 91;
        private int DefaultMTBrokerFeesWidth = 100;
        private int DefaultMTBPProductionTimeWidth = 106;
        private int DefaultMTTotalProductionTimeWidth = 116;
        private int DefaultMTCopyTimeWidth = 100;
        private int DefaultMTInventionTimeWidth = 100;
        private int DefaultMTItemMarketPriceWidth = 100;
        private int DefaultMTProfitWidth = 100;
        private int DefaultMTProfitPercentageWidth = 100;
        private int DefaultMTIskperHourWidth = 100;
        private int DefaultMTSVRWidth = 100;
        private int DefaultMTSVRxIPHWidth = 100;
        private int DefaultMTPriceTrendWidth = 100;
        private int DefaultMTTotalItemsSoldWidth = 100;
        private int DefaultMTTotalOrdersFilledWidth = 100;
        private int DefaultMTAvgItemsperOrderWidth = 100;
        private int DefaultMTCurrentSellOrdersWidth = 100;
        private int DefaultMTCurrentBuyOrdersWidth = 100;
        private int DefaultMTItemsinProductionWidth = 100;
        private int DefaultMTItemsinStockWidth = 100;
        private int DefaultMTMaterialCostWidth = 100;
        private int DefaultMTTotalCostWidth = 100;
        private int DefaultMTBaseJobCostWidth = 100;
        private int DefaultMTNumBPsWidth = 57;
        private int DefaultMTInventionChanceWidth = 100;
        private int DefaultMTBPTypeWidth = 54;
        private int DefaultMTRaceWidth = 77;
        private int DefaultMTVolumeperItemWidth = 89;
        private int DefaultMTTotalVolumeWidth = 75;
        private int DefaultMTSellExcessWidth = 100;
        private int DefaultMTROIWidth = 100;
        private int DefaultMTPortionSizeWidth = 75;
        private int DefaultMTManufacturingJobFeeWidth = 122;
        private int DefaultMTManufacturingFacilityNameWidth = 150;
        private int DefaultMTManufacturingFacilitySystemWidth = 152;
        private int DefaultMTManufacturingFacilityRegionWidth = 154;
        private int DefaultMTManufacturingFacilitySystemIndexWidth = 184;
        private int DefaultMTManufacturingFacilityTaxWidth = 138;
        private int DefaultMTManufacturingFacilityMEBonusWidth = 169;
        private int DefaultMTManufacturingFacilityTEBonusWidth = 166;
        private int DefaultMTManufacturingFacilityUsageWidth = 149;
        private int DefaultMTManufacturingFacilityFWSystemLevelWidth = 150;
        private int DefaultMTComponentFacilityNameWidth = 145;
        private int DefaultMTComponentFacilitySystemWidth = 140;
        private int DefaultMTComponentFacilityRegionWidth = 138;
        private int DefaultMTComponentFacilitySystemIndexWidth = 168;
        private int DefaultMTComponentFacilityTaxWidth = 122;
        private int DefaultMTComponentFacilityMEBonusWidth = 153;
        private int DefaultMTComponentFacilityTEBonusWidth = 153;
        private int DefaultMTComponentFacilityUsageWidth = 136;
        private int DefaultMTComponentFacilityFWSystemLevelWidth = 150;
        private int DefaultMTCapComponentFacilityNameWidth = 150;
        private int DefaultMTCapComponentFacilitySystemWidth = 150;
        private int DefaultMTCapComponentFacilityRegionWidth = 150;
        private int DefaultMTCapComponentFacilitySystemIndexWidth = 150;
        private int DefaultMTCapComponentFacilityTaxWidth = 150;
        private int DefaultMTCapComponentFacilityMEBonusWidth = 150;
        private int DefaultMTCapComponentFacilityTEBonusWidth = 150;
        private int DefaultMTCapComponentFacilityUsageWidth = 150;
        private int DefaultMTCapComponentFacilityFWSystemLevelWidth = 150;
        private int DefaultMTCopyingFacilityNameWidth = 116;
        private int DefaultMTCopyingFacilitySystemWidth = 122;
        private int DefaultMTCopyingFacilityRegionWidth = 122;
        private int DefaultMTCopyingFacilitySystemIndexWidth = 153;
        private int DefaultMTCopyingFacilityTaxWidth = 107;
        private int DefaultMTCopyingFacilityMEBonusWidth = 137;
        private int DefaultMTCopyingFacilityTEBonusWidth = 135;
        private int DefaultMTCopyingFacilityUsageWidth = 121;
        private int DefaultMTCopyingFacilityFWSystemLevelWidth = 150;
        private int DefaultMTInventionFacilityNameWidth = 122;
        private int DefaultMTInventionFacilitySystemWidth = 130;
        private int DefaultMTInventionFacilityRegionWidth = 129;
        private int DefaultMTInventionFacilitySystemIndexWidth = 156;
        private int DefaultMTInventionFacilityTaxWidth = 112;
        private int DefaultMTInventionFacilityMEBonusWidth = 144;
        private int DefaultMTInventionFacilityTEBonusWidth = 141;
        private int DefaultMTInventionFacilityUsageWidth = 127;
        private int DefaultMTInventionFacilityFWSystemLevelWidth = 150;
        private int DefaultMTReactionFacilityNameWidth = 150;
        private int DefaultMTReactionFacilitySystemWidth = 150;
        private int DefaultMTReactionFacilityRegionWidth = 150;
        private int DefaultMTReactionFacilitySystemIndexWidth = 150;
        private int DefaultMTReactionFacilityTaxWidth = 150;
        private int DefaultMTReactionFacilityMEBonusWidth = 150;
        private int DefaultMTReactionFacilityTEBonusWidth = 150;
        private int DefaultMTReactionFacilityUsageWidth = 150;
        private int DefaultMTReactionFacilityFWSystemLevelWidth = 122;
        private int DefaultMTReprocessingFacilityNameWidth = 122;
        private int DefaultMTReprocessingFacilitySystemWidth = 130;
        private int DefaultMTReprocessingFacilityRegionWidth = 129;
        private int DefaultMTReprocessingFacilityTaxWidth = 112;
        private int DefaultMTReprocessingFacilityUsageWidth = 127;
        private int DefaultMTReprocessingFacilityOreRefineRateWidth = 144;
        private int DefaultMTReprocessingFacilityIceRefineRateWidth = 144;
        private int DefaultMTReprocessingFacilityMoonRefineRateWidth = 144;

        public string DefaultMTOrderType = "Ascending";
        public int DefaultMTOrderByColumn = 3;

        // Column Names for manufacturing tab
        public const string ItemCategoryColumnName = "Item Category";
        public const string ItemGroupColumnName = "Item Group";
        public const string ItemNameColumnName = "Item Name";
        public const string OwnedColumnName = "Owned";
        public const string TechColumnName = "Tech";
        public const string BPMEColumnName = "ME";
        public const string BPTEColumnName = "TE";
        public const string InputsColumnName = "Inputs";
        public const string ComparedColumnName = "Compared";
        public const string TotalRunsColumnName = "Total Runs";
        public const string SingleInventedBPCRunsColumnName = "Single Invented BPC Runs";
        public const string ProductionLinesColumnName = "Production Lines";
        public const string LaboratoryLinesColumnName = "Laboratory Lines";
        public const string TotalInventionCostColumnName = "Total Invention Cost";
        public const string TotalCopyCostColumnName = "Total Copy Cost";
        public const string TaxesColumnName = "Taxes";
        public const string BrokerFeesColumnName = "Broker Fees";
        public const string BPProductionTimeColumnName = "BP Production Time";
        public const string TotalProductionTimeColumnName = "Total Production Time";
        public const string CopyTimeColumnName = "Copy Time";
        public const string InventionTimeColumnName = "Invention Time";
        public const string ItemMarketPriceColumnName = "Item Market Price";
        public const string ProfitColumnName = "Profit";
        public const string ProfitPercentageColumnName = "Profit Percentage";
        public const string IskperHourColumnName = "Isk per Hour";
        public const string SVRColumnName = "SVR";
        public const string SVRxIPHColumnName = "SVR * IPH";
        public const string PriceTrendColumnName = "Price Trend";
        public const string TotalItemsSoldColumnName = "Total Items Sold";
        public const string TotalOrdersFilledColumnName = "Total Orders Filled";
        public const string AvgItemsperOrderColumnName = "Average Items Per Order";
        public const string CurrentSellOrdersColumnName = "Current Sell Orders";
        public const string CurrentBuyOrdersColumnName = "Current Buy Orders";
        public const string ItemsinProductionColumnName = "Items in Production";
        public const string ItemsinStockColumnName = "Items in Stock";
        public const string MaterialCostColumnName = "Material Cost";
        public const string TotalCostColumnName = "Total Cost";
        public const string BaseJobCostColumnName = "Base Job Cost";
        public const string NumBPsColumnName = "Num BPs";
        public const string InventionChanceColumnName = "Invention Chance";
        public const string BPTypeColumnName = "BP Type";
        public const string RaceColumnName = "Race";
        public const string VolumeperItemColumnName = "Volume per Item";
        public const string TotalVolumeColumnName = "Total Volume";
        public const string SellExcessColumnName = "Sell Excess Amount";
        public const string ROIColumnName = "Return on Investment";
        public const string PortionSizeColumnName = "Portion Size";
        public const string ManufacturingJobFeeColumnName = "Manufacturing Job Fee";
        public const string ManufacturingFacilityNameColumnName = "Manufacturing Facility Name";
        public const string ManufacturingFacilitySystemColumnName = "Manufacturing Facility System";
        public const string ManufacturingFacilityRegionColumnName = "Manufacturing Facility Region";
        public const string ManufacturingFacilitySystemIndexColumnName = "Manufacturing Facility System Index";
        public const string ManufacturingFacilityTaxColumnName = "Manufacturing Facility Tax";
        public const string ManufacturingFacilityMEBonusColumnName = "Manufacturing Facility ME Bonus";
        public const string ManufacturingFacilityTEBonusColumnName = "Manufacturing Facility TE Bonus";
        public const string ManufacturingFacilityUsageColumnName = "Manufacturing Facility Usage";
        public const string ManufacturingFacilityFWSystemLevelColumnName = "Manufacturing Facility FW System Level";
        public const string ComponentFacilityNameColumnName = "Component Facility Name";
        public const string ComponentFacilitySystemColumnName = "Component Facility System";
        public const string ComponentFacilityRegionColumnName = "Component Facility Region";
        public const string ComponentFacilitySystemIndexColumnName = "Component Facility System Index";
        public const string ComponentFacilityTaxColumnName = "Component Facility Tax";
        public const string ComponentFacilityMEBonusColumnName = "Component Facility ME Bonus";
        public const string ComponentFacilityTEBonusColumnName = "Component Facility TE Bonus";
        public const string ComponentFacilityUsageColumnName = "Component Facility Usage";
        public const string ComponentFacilityFWSystemLevelColumnName = "Component Facility FW System Level";
        public const string CapComponentFacilityNameColumnName = "Capital Component Facility Name";
        public const string CapComponentFacilitySystemColumnName = "Capital Component Facility System";
        public const string CapComponentFacilityRegionColumnName = "Capital Component Facility Region";
        public const string CapComponentFacilitySystemIndexColumnName = "Capital Component Facility SystemIndex";
        public const string CapComponentFacilityTaxColumnName = "Capital Component Facility Tax";
        public const string CapComponentFacilityMEBonusColumnName = "Capital Component Facility ME Bonus";
        public const string CapComponentFacilityTEBonusColumnName = "Capital Component Facility TE Bonus";
        public const string CapComponentFacilityUsageColumnName = "Capital Component Facility Usage";
        public const string CapComponentFacilityFWSystemLevelColumnName = "Capital Component Facility FW System Level";
        public const string CopyingFacilityNameColumnName = "Copying Facility Name";
        public const string CopyingFacilitySystemColumnName = "Copying Facility System";
        public const string CopyingFacilityRegionColumnName = "Copying Facility Region";
        public const string CopyingFacilitySystemIndexColumnName = "Copying Facility System Index";
        public const string CopyingFacilityTaxColumnName = "Copying Facility Tax";
        public const string CopyingFacilityMEBonusColumnName = "Copying Facility ME Bonus";
        public const string CopyingFacilityTEBonusColumnName = "Copying Facility TE Bonus";
        public const string CopyingFacilityUsageColumnName = "Copying Facility Usage";
        public const string CopyingFacilityFWSystemLevelColumnName = "Copying Facility FW System Level";
        public const string InventionFacilityNameColumnName = "Invention Facility Name";
        public const string InventionFacilitySystemColumnName = "Invention Facility System";
        public const string InventionFacilityRegionColumnName = "Invention Facility Region";
        public const string InventionFacilitySystemIndexColumnName = "Invention Facility SystemIndex";
        public const string InventionFacilityTaxColumnName = "Invention Facility Tax";
        public const string InventionFacilityMEBonusColumnName = "Invention Facility ME Bonus";
        public const string InventionFacilityTEBonusColumnName = "Invention Facility TE Bonus";
        public const string InventionFacilityUsageColumnName = "Invention Facility Usage";
        public const string InventionFacilityFWSystemLevelColumnName = "Invention Facility FW System Level";
        public const string ReactionFacilityNameColumnName = "Reaction Facility Name";
        public const string ReactionFacilitySystemColumnName = "Reaction Facility System";
        public const string ReactionFacilityRegionColumnName = "Reaction Facility Region";
        public const string ReactionFacilitySystemIndexColumnName = "Reaction Facility SystemIndex";
        public const string ReactionFacilityTaxColumnName = "Reaction Facility Tax";
        public const string ReactionFacilityMEBonusColumnName = "Reaction Facility ME Bonus";
        public const string ReactionFacilityTEBonusColumnName = "Reaction Facility TE Bonus";
        public const string ReactionFacilityUsageColumnName = "Reaction Facility Usage";
        public const string ReactionFacilityFWSystemLevelColumnName = "Reaction Facility FW System Level";
        public const string ReprocessingFacilityNameColumnName = "Reprocessing Facility Name";
        public const string ReprocessingFacilitySystemColumnName = "Reprocessing Facility System";
        public const string ReprocessingFacilityRegionColumnName = "Reprocessing Facility Region";
        public const string ReprocessingFacilityTaxColumnName = "Reprocessing Facility Tax";
        public const string ReprocessingFacilityUsageColumnName = "Reprocessing Facility Usage";
        public const string ReprocessingFacilityOreRefineRateColumnName = "Reprocessing Facility Ore Efficiency Rate";
        public const string ReprocessingFacilityIceRefineRateColumnName = "Reprocessing Facility Ice Efficiency Rate";
        public const string ReprocessingFacilityMoonRefineRateColumnName = "Reprocessing Facility Moon Efficiency Rate";

        // Industry Ore/Ice Flip Belt settings
        private double DefaultCycleTime = 180d;
        private double Defaultm3perCycle = 3000d;
        private int DefaultNumMiners = 1;
        private bool DefaultCompressOre = false;
        private bool DefaultIPHperMiner = false;
        private int DefaultIncludeBrokerFees; // 0,1,2 - Tri-check
        private double DefaultBFBrokerFeeRate = 0.05d;
        private bool DefaultIncludeTaxes = true;
        private string DefaultTruesec = "";
        private string DefaultSpace = "";

        // Industry flip belt defaults
        private bool DefaultPlagioclase = true;
        private bool DefaultSpodumain = true;
        private bool DefaultKernite = true;
        private bool DefaultHedbergite = true;
        private bool DefaultArkonor = true;
        private bool DefaultBistot = true;
        private bool DefaultPyroxeres = true;
        private bool DefaultCrokite = true;
        private bool DefaultJaspet = true;
        private bool DefaultOmber = true;
        private bool DefaultScordite = true;
        private bool DefaultGneiss = true;
        private bool DefaultVeldspar = true;
        private bool DefaultHemorphite = true;
        private bool DefaultDarkOchre = true;
        private bool DefaultMercoxit = true;
        private bool DefaultCrimsonArkonor = true;
        private bool DefaultPrimeArkonor = true;
        private bool DefaultTriclinicBistot = true;
        private bool DefaultMonoclinicBistot = true;
        private bool DefaultSharpCrokite = true;
        private bool DefaultCrystallineCrokite = true;
        private bool DefaultOnyxOchre = true;
        private bool DefaultObsidianOchre = true;
        private bool DefaultVitricHedbergite = true;
        private bool DefaultGlazedHedbergite = true;
        private bool DefaultVividHemorphite = true;
        private bool DefaultRadiantHemorphite = true;
        private bool DefaultPureJaspet = true;
        private bool DefaultPristineJaspet = true;
        private bool DefaultLuminousKernite = true;
        private bool DefaultFieryKernite = true;
        private bool DefaultAzurePlagioclase = true;
        private bool DefaultRichPlagioclase = true;
        private bool DefaultSolidPyroxeres = true;
        private bool DefaultViscousPyroxeres = true;
        private bool DefaultCondensedScordite = true;
        private bool DefaultMassiveScordite = true;
        private bool DefaultBrightSpodumain = true;
        private bool DefaultGleamingSpodumain = true;
        private bool DefaultConcentratedVeldspar = true;
        private bool DefaultDenseVeldspar = true;
        private bool DefaultIridescentGneiss = true;
        private bool DefaultPrismaticGneiss = true;
        private bool DefaultSilveryOmber = true;
        private bool DefaultGoldenOmber = true;
        private bool DefaultMagmaMercoxit = true;
        private bool DefaultVitreousMercoxit = true;

        // Ice Belt Flip - checks
        private bool DefaultBlueIce = true;
        private bool DefaultClearIcicle = true;
        private bool DefaultDarkGlitter = true;
        private bool DefaultEnrichedClearIcicle = true;
        private bool DefaultGelidus = true;
        private bool DefaultGlacialMass = true;
        private bool DefaultGlareCrust = true;
        private bool DefaultKrystallos = true;
        private bool DefaultPristineWhiteGlaze = true;
        private bool DefaultSmoothGlacialMass = true;
        private bool DefaultThickBlueIce = true;
        private bool DefaultWhiteGlaze = true;
        private bool DefaultCompressedBlueIce = true;
        private bool DefaultCompressedClearIcicle = true;
        private bool DefaultCompressedDarkGlitter = true;
        private bool DefaultCompressedEnrichedClearIcicle = true;
        private bool DefaultCompressedGelidus = true;
        private bool DefaultCompressedGlacialMass = true;
        private bool DefaultCompressedGlareCrust = true;
        private bool DefaultCompressedKrystallos = true;
        private bool DefaultCompressedPristineWhiteGlaze = true;
        private bool DefaultCompressedSmoothGlacialMass = true;
        private bool DefaultCompressedThickBlueIce = true;
        private bool DefaultCompressedWhiteGlaze = true;

        // ConvertToOre
        private string DefaultConversionType = Public_Variables.None;
        private string DefaultMinimizeOn = "Refine Price";
        private bool DefaultCompressedOre = true;
        private bool DefaultCompressedIce = true;
        private bool DefaultHighSec = true;
        private bool DefaultLowSec = true;
        private bool DefaultNullSec = true;
        private bool DefaultOreVariant0 = true;
        private bool DefaultOreVariant5 = true;
        private bool DefaultOreVariant10 = true;
        private bool DefaultAmarr = true;
        private bool DefaultCaldari = true;
        private bool DefaultGallente = true;
        private bool DefaultMinmatar = true;
        private bool DefaultWormhole = false;
        private bool DefaultTriglavian = false;
        private bool DefaultC1 = true;
        private bool DefaultC2 = true;
        private bool DefaultC3 = true;
        private bool DefaultC4 = true;
        private bool DefaultC5 = true;
        private bool DefaultC6 = true;
        public int DefaultOverrideValue = 1; // 1 is not overridden, 0 is false, -1 true for override value
        public int DefaultIgnoreValue = 0;

        // Default Shopping List Settings
        private bool DefaultAlwaysonTop = false;
        private bool DefaultUpdateAssetsWhenUsed = false;
        private bool DefaultFees = true;
        private int DefaultCalcBuyBuyOrder = 1;
        private bool DefaultUsage = true;
        private bool DefaultReloadBPsFromFile = true;

        // Default Market History Viewer Settings
        private string DefaultMHDatePreference = "By Days";
        private bool DefaultMHVolume = false;
        private bool DefaultMHMinMaxDayPrice = false;
        private bool DefaultMHLinearTrend = false;
        private bool DefaultMHDochianChannel = false;
        private bool DefaultMHFiveDayAvg = false;
        private bool DefaultMHTwentyDayAvg = false;

        // Assets - Item Checks
        private bool DefaultAssetItemChecks = true;
        private string DefaultAssetItemTextFilter = "";
        private bool DefaultAllItems = true;
        // Assets - Main window 
        private string DefaultAssetType = "Both";
        private bool DefaultAssetSortbyName = true;

        // Default LP Store
        private string DefaultLPRewardType = "All";
        private string DefaultLPCorpFilter = "Use Standings";
        private bool DefaultLPCheckAgentLevel1 = true;
        private bool DefaultLPCheckAgentLevel2 = true;
        private bool DefaultLPCheckAgentLevel3 = true;
        private bool DefaultLPCheckAgentLevel4 = true;
        private bool DefaultLPCheckAgentLevel5 = true;
        private string DefaultLPTextItemSearch = "";
        private string DefaultLPTextReqItemSearch = "";
        private string DefaultLPLPCostLessThan = "0.00";
        private string DefaultLPLPCostGreaterThan = "0.00";
        private string DefaultLPISKCostLessThan = "0.00";
        private string DefaultLPISKCostGreaterThan = "0.00";
        private string DefaultLPStandingLessThan = "0.00";
        private string DefaultLPStandingGreaterThan = "0.00";
        private string DefaultLPSearchOption = "All Corporations";
        private string DefaultLPSortByOption = "ISK/LP";
        private bool DefaultLPHighlightCheck = true;
        private string DefaultLPSelectedCorporations = "";

        // Upwell Structures Viewer
        private bool DefaultHighSlotsCheck = false;
        private bool DefaultMediumSlotsCheck = false;
        private bool DefaultLowSlotsCheck = false;
        private bool DefaultServicesCheck = false;
        private bool DefaultReprocessingRigsCheck = false;
        private bool DefaultEngineeringRigsCheck = false;
        private bool DefaultCombatRigsCheck = false;
        private bool DefaultIncludeFuelCostsCheck = false;
        private string DefaultFuelBlockType = "Helium Fuel Block";
        private string DefaultBuyBuildBlockOption = "Buy Blocks";
        private bool DefaultAutoUpdateFuelBlockPricesCheck = false;
        private string DefaultSearchFilterText = "";
        private string DefaultSelectedStructureName = "Raitaru";
        private bool DefaultReactionsRigsCheck = false;
        private bool DefaultDrillingRigsCheck = false;
        private bool DefaultIconListView = true;

        // Bonus Popout Viewer Settings for facilities
        private int DefaultSBPVFormWidth = 750;
        private int DefaultSBPVFormHeight = 275;
        private int DefaultSBPVBonusAppliesColumnWidth = 150;
        private int DefaultSBPVActivityColumnWidth = 125;
        private int DefaultSBPVBonusesColumnWidth = 250;
        private int DefaultSBPVBonusSourceColumnWidth = 165;

        // Local versions of settings
        private ApplicationSettings ApplicationSettings;
        private BPTabSettings BPSettings;
        private ManufacturingTabSettings ManufacturingSettings;
        private DataCoreTabSettings DatacoreSettings;
        private MiningTabSettings MiningSettings;
        private UpdatePriceTabSettings UpdatePricesSettings;
        private IndustryJobsColumnSettings IndustryJobsColumnSettings;
        private ManufacturingTabColumnSettings ManufacturingTabColumnSettings;
        private IndustryFlipBeltSettings IndustryFlipBeltsSettings;
        private ShoppingListSettings ShoppingListTabSettings;
        private MarketHistoryViewerSettings MarketHistoryViewSettings;
        private UpwellStructureSettings UpwellStructureViewerSettings;
        private BPViewerSettings BPViewSettings;
        private IceBeltFlipSettings IceBeltFlipSetting;
        private IceBeltCheckSettings IceBeltCheckSetting;
        private ConversionToOreSettings ConversionToOreSetting;

        // Multiple versions of Asset windows
        private AssetWindowSettings AssetWindowSettingsManufacturingTab;
        private AssetWindowSettings AssetWindowSettingsShoppingList;
        private AssetWindowSettings AssetWindowsettingsRefinery;

        // 5 belt types
        private IndustryBeltOreChecks IndustryBeltOreChecksSettings1;
        private IndustryBeltOreChecks IndustryBeltOreChecksSettings2;
        private IndustryBeltOreChecks IndustryBeltOreChecksSettings3;
        private IndustryBeltOreChecks IndustryBeltOreChecksSettings4;
        private IndustryBeltOreChecks IndustryBeltOreChecksSettings5;

        private const string AppSettingsFileName = "ApplicationSettings";
        private const string BPSettingsFileName = "BPTabSettings";
        private const string ManufacturingSettingsFileName = "ManufacturingTabSettings";
        private const string UpdatePricesFileName = "UpdatePricesSettings";
        private const string DatacoreSettingsFileName = "DatacoreSettings";
        private const string ReactionSettingsFileName = "ReactionTabSettings";
        private const string MiningSettingsFileName = "MiningTabSettings";
        private const string IndustryJobsColumnSettingsFileName = "IndustryJobsColumnSettings";
        private const string ManufacturingTabColumnSettingsFileName = "ManufacturingTabColumnSettings";
        private const string IndustryFlipBeltSettingsFileName = "IndustryFlipBeltSettings";
        private const string ShoppingListSettingsFileName = "ShoppingListSettings";
        private const string BPViewerSettingsFileName = "BPViewerSettings";

        private const string LPStoreSettingsFileName = "LPStoreSettings";
        private const string MarketHistoryViewerSettingsFileName = "MarketHistoryViewerSettings";
        private const string UpwellStructureViewerSettingsFileName = "UpwellStructureViewerSettings";
        private const string StructureBonusPopoutViewerSettingsFileName = "StructureBonusPopoutViewerSettings";

        private const string IceBeltFlipSettingsFileName = "IceBeltFlipSettings";
        private const string IceBeltFlipCheckSettingsFileName = "IceBeltFlipCheckSettings";

        private const string ConvertToOreSettingsFileName = "ConvertToOreSettings";

        // For BP List Viewer
        public bool DefaultBPViewerTechChecks = true;
        public bool DefaultBPViewerSizeChecks = false;
        public bool DefaultBPViewerIgnoreBPsCheck = false;
        public bool DefaultBPNPCBPOsCheck = false;
        public string DefaultBPViewerSelectionType = "All";

        // 5 belts
        private string IndustryBeltOreChecksBaseFileName = "IndustryBeltOreChecks";
        private string IndustryBeltOreChecksFileName = "";
        private const string IndustryBeltOreChecksFileName1 = "1";
        private const string IndustryBeltOreChecksFileName2 = "2";
        private const string IndustryBeltOreChecksFileName3 = "3";
        private const string IndustryBeltOreChecksFileName4 = "4";
        private const string IndustryBeltOreChecksFileName5 = "5";

        // Multiple asset windows
        private const string AssetWindowFileNameDefault = "AssetWindowSettingsDefault";
        private const string AssetWindowFileNameManufacturingTab = "AssetWindowSettingsManufacturingTab";
        private const string AssetWindowFileNameShoppingList = "AssetWindowSettingsShoppingList";
        private const string AssetWindowFileNameRefinery = "AssetWindowFileNameRefinery";

        private const string XMLfileType = ".xml";

        public ProgramSettings()
        {
            ApplicationSettings = default;
            MiningSettings = default;
            BPSettings = default;
            ManufacturingSettings = default;
            DatacoreSettings = default;
            MiningSettings = default;
            UpdatePricesSettings = default;
            IndustryJobsColumnSettings = default;
            ManufacturingTabColumnSettings = default;
            IndustryFlipBeltsSettings = default;
            IceBeltFlipSetting = default;
            IceBeltCheckSetting = default;
            ShoppingListTabSettings = default;
            MarketHistoryViewSettings = default;
            UpwellStructureViewerSettings = default;
            BPViewSettings = default;
            ConversionToOreSetting = default;

            ConversionToOreSetting.OverrideChecks = new int[36];

        }

        // Writes the sent settings to the sent file name
        private void WriteSettingsToFile(string FileFolder, string FileName, Setting[] Settings, string RootName)
        {
            int i;

            // Create XmlWriterSettings.
            var XMLSettings = new XmlWriterSettings();
            string FilePath = Path.Combine(Public_Variables.DynamicFilePath, FileFolder);
            XMLSettings.Indent = true;

            if (!string.IsNullOrEmpty(FileFolder))
            {
                if (!Directory.Exists(FilePath))
                {
                    // Create the settings folder
                    Directory.CreateDirectory(FilePath);
                }
            }

            // Delete and make a fresh copy
            if (File.Exists(Path.ChangeExtension(Path.Combine(FilePath, FileName), XMLfileType)))
            {
                File.Delete(Path.ChangeExtension(Path.Combine(FilePath, FileName), XMLfileType));
            }

            // Loop through the settings sent and output each name and value
            using (var writer = XmlWriter.Create(Path.ChangeExtension(Path.Combine(FilePath, FileName), XMLfileType), XMLSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(RootName); // Root.

                // Main loop
                var loopTo = Settings.Count() - 1;
                for (i = 0; i <= loopTo; i++)
                    writer.WriteElementString(Settings[i].Name, Settings[i].Value);

                // End document.
                writer.WriteEndDocument();
            }

        }

        // Gets a value from a referenced XML file by searching for it
        private object GetSettingValue(string FileFolder, ref string FileName, SettingTypes ObjectType, string RootElement, string ElementString, object DefaultValue)
        {
            var m_xmld = new XmlDocument();
            XmlNodeList m_nodelist;
            string FilePath = Path.ChangeExtension(Path.Combine(Public_Variables.DynamicFilePath, FileFolder, FileName), XMLfileType);
            string TempValue;

            try
            {


                // Load the Xml file
                m_xmld.Load(FilePath);

                // Get the settings
                m_nodelist = m_xmld.SelectNodes("/" + RootElement + "/" + ElementString);

                if (!(m_nodelist.Item(0) == null))
                {
                    // Should only be one
                    TempValue = m_nodelist.Item(0).InnerText;

                    // If blank, then return default
                    if (string.IsNullOrEmpty(TempValue))
                    {
                        return DefaultValue;
                    }

                    if (TempValue == "False" | TempValue == "True")
                    {
                        // Change to type boolean
                        ObjectType = SettingTypes.TypeBoolean;
                    }

                    // Found it, return the cast
                    switch (ObjectType)
                    {
                        case SettingTypes.TypeBoolean:
                            {
                                return Conversions.ToBoolean(TempValue);
                            }
                        case SettingTypes.TypeDouble:
                            {
                                return Conversions.ToDouble(TempValue);
                            }
                        case SettingTypes.TypeInteger:
                            {
                                return Conversions.ToInteger(TempValue);
                            }
                        case SettingTypes.TypeString:
                            {
                                return TempValue;
                            }
                        case SettingTypes.TypeLong:
                            {
                                return Conversions.ToLong(TempValue);
                            }
                    }
                }

                else
                {
                    // Doesn't exist, use default
                    return DefaultValue;
                }
            }

            catch (Exception ex)
            {
                // Threw an error, so return the default value
                return DefaultValue;
            }

            return null;

        }

        // Just checks if the file exists or not so we don't have to mess with file names
        private bool FileExists(string FileFolder, string FileName)
        {

            if (File.Exists(Path.ChangeExtension(Path.Combine(Public_Variables.DynamicFilePath, FileFolder, FileName), XMLfileType)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private struct Setting
        {
            public string Name;
            public string Value;

            public Setting(string inName, string inValue)
            {
                Name = inName;
                Value = inValue;
            }

        }

        private enum SettingTypes
        {
            TypeInteger = 1,
            TypeDouble = 2,
            TypeString = 3,
            TypeBoolean = 4,
            TypeLong = 5
        }

        #region Application Settings

        // Loads the settings for the user from the DB (for now) for the whole program
        public ApplicationSettings LoadApplicationSettings()
        {
            ApplicationSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, AppSettingsFileName))
                {

                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = AppSettingsFileName;
                        string argFileName1 = AppSettingsFileName;
                        withBlock.CheckforUpdatesonStart = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeBoolean, AppSettingsFileName, "CheckforUpdatesonStart", DefaultCheckUpdatesOnStart));
                        string argFileName2 = AppSettingsFileName;
                        string argFileName3 = AppSettingsFileName;
                        withBlock.LoadAssetsonStartup = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadAssetsonStartup", DefaultLoadAssetsonStartup));
                        string argFileName4 = AppSettingsFileName;
                        string argFileName5 = AppSettingsFileName;
                        withBlock.LoadBPsonStartup = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadbpsonStartup", DefaultLoadBPsonStartup));
                        string argFileName6 = AppSettingsFileName;
                        string argFileName7 = AppSettingsFileName;
                        withBlock.LoadESIMarketDataonStartup = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadESIMarketDataonStartup", DefaultRefreshMarketESIDataonStartup));
                        string argFileName8 = AppSettingsFileName;
                        string argFileName9 = AppSettingsFileName;
                        withBlock.LoadESISystemCostIndiciesDataonStartup = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadESISystemCostIndiciesDataonStartup", DefaultRefreshFacilityESIDataonStartup));
                        string argFileName10 = AppSettingsFileName;
                        string argFileName11 = AppSettingsFileName;
                        withBlock.LoadESIPublicStructuresonStartup = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadESISystemCostIndiciesDataonStartup", DefaultRefreshPublicStructureDataonStartup));
                        string argFileName12 = AppSettingsFileName;
                        string argFileName13 = AppSettingsFileName;
                        withBlock.SupressESIStatusMessages = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, AppSettingsFileName, "SupressESIStatusMessages", DefaultSupressESIStatusMessages));
                        string argFileName14 = AppSettingsFileName;
                        string argFileName15 = AppSettingsFileName;
                        withBlock.DataExportFormat = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeString, AppSettingsFileName, "DataExportFormat", DefaultDataExportFormat));
                        string argFileName16 = AppSettingsFileName;
                        string argFileName17 = AppSettingsFileName;
                        withBlock.AllowSkillOverride = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeBoolean, AppSettingsFileName, "AllowSkillOverride", DefaultAllowSkillOverride));
                        string argFileName18 = AppSettingsFileName;
                        string argFileName19 = AppSettingsFileName;
                        withBlock.ShowToolTips = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeBoolean, AppSettingsFileName, "ShowToolTips", DefaultShowToolTips));
                        string argFileName20 = AppSettingsFileName;
                        string argFileName21 = AppSettingsFileName;
                        withBlock.RefiningImplantValue = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeDouble, AppSettingsFileName, "RefiningImplantValue", DefaultImplantValues));
                        string argFileName22 = AppSettingsFileName;
                        string argFileName23 = AppSettingsFileName;
                        withBlock.ManufacturingImplantValue = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeDouble, AppSettingsFileName, "ManufacturingImplantValue", DefaultImplantValues));
                        string argFileName24 = AppSettingsFileName;
                        string argFileName25 = AppSettingsFileName;
                        withBlock.CopyImplantValue = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeDouble, AppSettingsFileName, "CopyImplantValue", DefaultImplantValues));
                        string argFileName26 = AppSettingsFileName;
                        string argFileName27 = AppSettingsFileName;
                        withBlock.BrokerCorpStanding = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeDouble, AppSettingsFileName, "BrokerCorpStanding", DefaultBrokerCorpStanding));
                        string argFileName28 = AppSettingsFileName;
                        string argFileName29 = AppSettingsFileName;
                        withBlock.IncludeInGameLinksinCopyText = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeBoolean, AppSettingsFileName, "IncludeInGameLinksinCopyText", DefaultIncludeInGameLinksinCopyText));
                        string argFileName30 = AppSettingsFileName;
                        string argFileName31 = AppSettingsFileName;
                        withBlock.BrokerFactionStanding = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeDouble, AppSettingsFileName, "BrokerFactionStanding", DefaultBrokerFactionStanding));
                        string argFileName32 = AppSettingsFileName;
                        string argFileName33 = AppSettingsFileName;
                        withBlock.DefaultBPME = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeInteger, AppSettingsFileName, "DefaultBPME", DefaultSettingME));
                        string argFileName34 = AppSettingsFileName;
                        string argFileName35 = AppSettingsFileName;
                        withBlock.DefaultBPTE = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeInteger, AppSettingsFileName, "DefaultBPTE", DefaultSettingTE));
                        string argFileName36 = AppSettingsFileName;
                        string argFileName37 = AppSettingsFileName;
                        withBlock.CheckBuildBuy = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeBoolean, AppSettingsFileName, "CheckBuildBuy", DefaultCheckBuildBuy));
                        string argFileName38 = AppSettingsFileName;
                        string argFileName39 = AppSettingsFileName;
                        withBlock.DisableSVR = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeBoolean, AppSettingsFileName, "DisableSVR", DefaultDisableSVR));
                        string argFileName40 = AppSettingsFileName;
                        string argFileName41 = AppSettingsFileName;
                        withBlock.DisableGATracking = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeBoolean, AppSettingsFileName, "DisableGATracking", DefaultDisableGATracking));
                        string argFileName42 = AppSettingsFileName;
                        string argFileName43 = AppSettingsFileName;
                        withBlock.ShopListIncludeInventMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeBoolean, AppSettingsFileName, "ShopListIncludeInventMats", DefaultShopListIncludeInventMats));
                        string argFileName44 = AppSettingsFileName;
                        string argFileName45 = AppSettingsFileName;
                        withBlock.ShopListIncludeCopyMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName45, SettingTypes.TypeBoolean, AppSettingsFileName, "ShopListIncludeCopyMats", DefaultShopListIncludeCopyMats));
                        string argFileName46 = AppSettingsFileName;
                        string argFileName47 = AppSettingsFileName;
                        withBlock.SuggestBuildBPNotOwned = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName47, SettingTypes.TypeBoolean, AppSettingsFileName, "SuggestBuildBPNotOwned", DefaultSuggestBuildBPNotOwned));
                        string argFileName48 = AppSettingsFileName;
                        string argFileName49 = AppSettingsFileName;
                        withBlock.UpdatePricesRefreshInterval = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName49, SettingTypes.TypeInteger, AppSettingsFileName, "UpdatePricesRefreshInterval", DefaultUpdatePricesRefreshInterval));
                        string argFileName50 = AppSettingsFileName;
                        string argFileName51 = AppSettingsFileName;
                        withBlock.DisableSound = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName51, SettingTypes.TypeBoolean, AppSettingsFileName, "DisableSound", DefaultDisableSound));
                        string argFileName52 = AppSettingsFileName;
                        string argFileName53 = AppSettingsFileName;
                        withBlock.SaveBPRelicsDecryptors = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName53, SettingTypes.TypeBoolean, AppSettingsFileName, "SaveBPRelicsDecryptors", DefaultSaveBPRelicsDecryptors));
                        string argFileName54 = AppSettingsFileName;
                        string argFileName55 = AppSettingsFileName;
                        withBlock.AlwaysBuyFuelBlocks = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName55, SettingTypes.TypeBoolean, AppSettingsFileName, "AlwaysBuyFuelBlocks", DefaultAlwaysBuyFuelBlocks));
                        string argFileName56 = AppSettingsFileName;
                        string argFileName57 = AppSettingsFileName;
                        withBlock.AlwaysBuyRAMs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName57, SettingTypes.TypeBoolean, AppSettingsFileName, "AlwaysBuyRAMs", DefaultAlwaysBuyRAMs));
                        string argFileName58 = AppSettingsFileName;
                        string argFileName59 = AppSettingsFileName;
                        withBlock.IgnoreSVRThresholdValue = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName59, SettingTypes.TypeDouble, AppSettingsFileName, "IgnoreSVRThresholdValue", DefaultIgnoreSVRThresholdValue));
                        string argFileName60 = AppSettingsFileName;
                        string argFileName61 = AppSettingsFileName;
                        withBlock.SVRAveragePriceRegion = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName61, SettingTypes.TypeString, AppSettingsFileName, "SVRAveragePriceRegion", DefaultSVRAveragePriceRegion));
                        string argFileName62 = AppSettingsFileName;
                        string argFileName63 = AppSettingsFileName;
                        withBlock.SVRAveragePriceDuration = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName63, SettingTypes.TypeString, AppSettingsFileName, "SVRAveragePriceDuration", DefaultSVRAveragePriceDuration));
                        string argFileName64 = AppSettingsFileName;
                        string argFileName65 = AppSettingsFileName;
                        withBlock.AutoUpdateSVRonBPTab = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName65, SettingTypes.TypeBoolean, AppSettingsFileName, "AutoUpdateSVRonBPTab", DefaultAutoUpdateSVRonBPTab));
                        string argFileName66 = AppSettingsFileName;
                        string argFileName67 = AppSettingsFileName;
                        withBlock.ProxyAddress = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName67, SettingTypes.TypeString, AppSettingsFileName, "ProxyAddress", DefaultProxyAddress));
                        string argFileName68 = AppSettingsFileName;
                        string argFileName69 = AppSettingsFileName;
                        withBlock.ProxyPort = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName69, SettingTypes.TypeInteger, AppSettingsFileName, "ProxyPort", DefaultProxyPort));
                        string argFileName70 = AppSettingsFileName;
                        string argFileName71 = AppSettingsFileName;
                        withBlock.SaveFacilitiesbyChar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName71, SettingTypes.TypeBoolean, AppSettingsFileName, "SaveFacilitiesbyChar", DefaultSaveFacilitiesbyChar));
                        string argFileName72 = AppSettingsFileName;
                        string argFileName73 = AppSettingsFileName;
                        withBlock.LoadBPsbyChar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName73, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadBPsbyChar", DefaultLoadBPsbyChar));
                        string argFileName74 = AppSettingsFileName;
                        string argFileName75 = AppSettingsFileName;
                        withBlock.AlphaAccount = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName75, SettingTypes.TypeBoolean, AppSettingsFileName, "AlphaAccount", DefaultAlphaAccount));
                        string argFileName76 = AppSettingsFileName;
                        string argFileName77 = AppSettingsFileName;
                        withBlock.UseActiveSkillLevels = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName77, SettingTypes.TypeBoolean, AppSettingsFileName, "UseActiveSkillLevels", DefaultUseActiveSkills));
                        string argFileName78 = AppSettingsFileName;
                        string argFileName79 = AppSettingsFileName;
                        withBlock.LoadMaxAlphaSkills = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName79, SettingTypes.TypeBoolean, AppSettingsFileName, "LoadMaxAlphaSkills", DefaultLoadMaxAlphaSkills));
                        string argFileName80 = AppSettingsFileName;
                        string argFileName81 = AppSettingsFileName;
                        withBlock.ShareSavedFacilities = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName81, SettingTypes.TypeBoolean, AppSettingsFileName, "ShareSavedFacilities", DefaultDisableGATracking));
                        string argFileName82 = AppSettingsFileName;
                        string argFileName83 = AppSettingsFileName;
                        withBlock.RefineDrillDown = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName83, SettingTypes.TypeBoolean, AppSettingsFileName, "RefineDrillDown", DefaultRefineDrillDown));
                        string argFileName84 = AppSettingsFileName;
                        string argFileName85 = AppSettingsFileName;
                        withBlock.BaseSalesTaxRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName85, SettingTypes.TypeDouble, AppSettingsFileName, "BaseSalesTaxRate", DefaultBaseSalesTaxRate));
                        string argFileName86 = AppSettingsFileName;
                        string argFileName87 = AppSettingsFileName;
                        withBlock.BaseBrokerFeeRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName87, SettingTypes.TypeDouble, AppSettingsFileName, "BaseBrokerFeeRate", DefaultBaseBrokerFeeRate));
                        string argFileName88 = AppSettingsFileName;
                        string argFileName89 = AppSettingsFileName;
                        withBlock.SCCBrokerFeeSurcharge = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName89, SettingTypes.TypeDouble, AppSettingsFileName, "SCCBrokerFeeSurcharge", DefaultSCCBrokerFeeSurcharge));
                        string argFileName90 = AppSettingsFileName;
                        string argFileName91 = AppSettingsFileName;
                        withBlock.SCCIndustryFeeSurcharge = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName91, SettingTypes.TypeDouble, AppSettingsFileName, "SCCIndustryFeeSurcharge", DefaultSCCIndustryFeeSurcharge));
                        string argFileName92 = AppSettingsFileName;
                        string argFileName93 = AppSettingsFileName;
                        withBlock.AlphaAccountTaxRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName93, SettingTypes.TypeDouble, AppSettingsFileName, "AlphaAccountTaxRate", DefaultAlphaAccountTaxRate));
                        string argFileName94 = AppSettingsFileName;
                        string argFileName95 = AppSettingsFileName;
                        withBlock.StructureTaxRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName95, SettingTypes.TypeDouble, AppSettingsFileName, "StructureTaxRate", DefaultStructureTaxRate));
                        string argFileName96 = AppSettingsFileName;
                        string argFileName97 = AppSettingsFileName;
                        withBlock.StationTaxRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName97, SettingTypes.TypeDouble, AppSettingsFileName, "StationTaxRate", DefaultStationTaxRate));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultApplicationSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Application Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Some other error occured Load defaults 
                TempSettings = SetDefaultApplicationSettings();
            }

            // Save them locally and then export
            ApplicationSettings = TempSettings;

            return TempSettings;

        }

        // Loads the defaults
        public ApplicationSettings SetDefaultApplicationSettings()
        {
            var TempSettings = default(ApplicationSettings);

            // Load default settings
            TempSettings.CheckforUpdatesonStart = DefaultCheckUpdatesOnStart;
            TempSettings.DataExportFormat = DefaultDataExportFormat;
            TempSettings.ShowToolTips = DefaultShowToolTips;
            TempSettings.LoadAssetsonStartup = DefaultLoadAssetsonStartup;
            TempSettings.LoadBPsonStartup = DefaultLoadBPsonStartup;
            TempSettings.LoadESIMarketDataonStartup = DefaultRefreshMarketESIDataonStartup;
            TempSettings.SupressESIStatusMessages = DefaultSupressESIStatusMessages;
            TempSettings.LoadESISystemCostIndiciesDataonStartup = DefaultRefreshFacilityESIDataonStartup;
            TempSettings.LoadESIPublicStructuresonStartup = DefaultRefreshPublicStructureDataonStartup;
            TempSettings.DisableSound = DefaultDisableSound;
            TempSettings.ManufacturingImplantValue = DefaultImplantValues;
            TempSettings.RefiningImplantValue = DefaultImplantValues;
            TempSettings.CopyImplantValue = DefaultImplantValues;

            // Station Standings for building and selling
            TempSettings.BrokerCorpStanding = DefaultBrokerCorpStanding;
            TempSettings.BrokerFactionStanding = DefaultBrokerFactionStanding;

            TempSettings.CheckBuildBuy = DefaultCheckBuildBuy;

            TempSettings.DefaultBPME = DefaultSettingME;
            TempSettings.DefaultBPTE = DefaultSettingTE;

            TempSettings.AlphaAccount = DefaultAlphaAccount;
            TempSettings.UseActiveSkillLevels = DefaultUseActiveSkills;
            TempSettings.LoadMaxAlphaSkills = DefaultLoadMaxAlphaSkills;

            TempSettings.DisableSVR = DefaultDisableSVR;
            TempSettings.DisableGATracking = DefaultDisableGATracking;
            TempSettings.ShareSavedFacilities = DefaultShareSavedFacilities;
            TempSettings.SuggestBuildBPNotOwned = DefaultSuggestBuildBPNotOwned;
            TempSettings.SaveBPRelicsDecryptors = DefaultSaveBPRelicsDecryptors;

            TempSettings.AlwaysBuyFuelBlocks = DefaultAlwaysBuyFuelBlocks;
            TempSettings.AlwaysBuyRAMs = DefaultAlwaysBuyRAMs;

            TempSettings.ShopListIncludeInventMats = DefaultShopListIncludeInventMats;
            TempSettings.ShopListIncludeCopyMats = DefaultShopListIncludeCopyMats;

            TempSettings.UpdatePricesRefreshInterval = DefaultUpdatePricesRefreshInterval;

            TempSettings.IgnoreSVRThresholdValue = DefaultIgnoreSVRThresholdValue;
            TempSettings.SVRAveragePriceRegion = DefaultSVRAveragePriceRegion;
            TempSettings.SVRAveragePriceDuration = DefaultSVRAveragePriceDuration;
            TempSettings.AutoUpdateSVRonBPTab = DefaultAutoUpdateSVRonBPTab;

            TempSettings.ProxyAddress = DefaultProxyAddress;
            TempSettings.ProxyPort = DefaultProxyPort;

            TempSettings.LoadBPsbyChar = DefaultLoadBPsbyChar;
            TempSettings.SaveFacilitiesbyChar = DefaultSaveFacilitiesbyChar;

            TempSettings.RefineDrillDown = DefaultRefineDrillDown;

            TempSettings.BaseSalesTaxRate = DefaultBaseSalesTaxRate;
            TempSettings.BaseBrokerFeeRate = DefaultBaseBrokerFeeRate;
            TempSettings.SCCBrokerFeeSurcharge = DefaultSCCBrokerFeeSurcharge;
            TempSettings.SCCIndustryFeeSurcharge = DefaultSCCIndustryFeeSurcharge;
            TempSettings.AlphaAccountTaxRate = DefaultAlphaAccountTaxRate;
            TempSettings.StructureTaxRate = DefaultStructureTaxRate;
            TempSettings.StationTaxRate = DefaultStationTaxRate;

            // Save locally
            ApplicationSettings = TempSettings;
            return TempSettings;

        }

        // Saves the application settings to XML
        public void SaveApplicationSettings(ApplicationSettings SentSettings)
        {
            var ApplicationSettingsList = new Setting[48];

            try
            {
                ApplicationSettingsList[0] = new Setting("CheckforUpdatesonStart", Conversions.ToString(SentSettings.CheckforUpdatesonStart));
                ApplicationSettingsList[1] = new Setting("DataExportFormat", SentSettings.DataExportFormat);
                ApplicationSettingsList[2] = new Setting("AllowSkillOverride", Conversions.ToString(SentSettings.AllowSkillOverride));
                ApplicationSettingsList[3] = new Setting("ShowToolTips", Conversions.ToString(SentSettings.ShowToolTips));
                ApplicationSettingsList[4] = new Setting("RefiningImplantValue", SentSettings.RefiningImplantValue.ToString());
                ApplicationSettingsList[5] = new Setting("ManufacturingImplantValue", SentSettings.ManufacturingImplantValue.ToString());
                ApplicationSettingsList[6] = new Setting("CopyImplantValue", SentSettings.CopyImplantValue.ToString());
                ApplicationSettingsList[7] = new Setting("BrokerCorpStanding", SentSettings.BrokerCorpStanding.ToString());
                ApplicationSettingsList[8] = new Setting("BrokerFactionStanding", SentSettings.BrokerFactionStanding.ToString());
                ApplicationSettingsList[9] = new Setting("DefaultBPME", SentSettings.DefaultBPME.ToString());
                ApplicationSettingsList[10] = new Setting("DefaultBPTE", SentSettings.DefaultBPTE.ToString());
                ApplicationSettingsList[11] = new Setting("CheckBuildBuy", Conversions.ToString(SentSettings.CheckBuildBuy));
                ApplicationSettingsList[12] = new Setting("IncludeInGameLinksinCopyText", Conversions.ToString(SentSettings.IncludeInGameLinksinCopyText));
                ApplicationSettingsList[13] = new Setting("ShopListIncludeInventMats", Conversions.ToString(SentSettings.ShopListIncludeInventMats));
                ApplicationSettingsList[14] = new Setting("ShopListIncludeCopyMats", Conversions.ToString(SentSettings.ShopListIncludeCopyMats));
                ApplicationSettingsList[15] = new Setting("SuggestBuildBPNotOwned", Conversions.ToString(SentSettings.SuggestBuildBPNotOwned));
                ApplicationSettingsList[16] = new Setting("UpdatePricesRefreshInterval", SentSettings.UpdatePricesRefreshInterval.ToString());
                ApplicationSettingsList[17] = new Setting("LoadAssetsonStartup", Conversions.ToString(SentSettings.LoadAssetsonStartup));
                ApplicationSettingsList[18] = new Setting("DisableSound", Conversions.ToString(SentSettings.DisableSound));
                ApplicationSettingsList[19] = new Setting("LoadbpsonStartup", Conversions.ToString(SentSettings.LoadBPsonStartup));
                ApplicationSettingsList[20] = new Setting("LoadESISystemCostIndiciesDataonStartup", Conversions.ToString(SentSettings.LoadESISystemCostIndiciesDataonStartup));
                ApplicationSettingsList[21] = new Setting("LoadESIMarketDataonStartup", Conversions.ToString(SentSettings.LoadESIMarketDataonStartup));
                ApplicationSettingsList[22] = new Setting("SaveBPRelicsDecryptors", Conversions.ToString(SentSettings.SaveBPRelicsDecryptors));
                ApplicationSettingsList[23] = new Setting("IgnoreSVRThresholdValue", SentSettings.IgnoreSVRThresholdValue.ToString());
                ApplicationSettingsList[24] = new Setting("SVRAveragePriceRegion", SentSettings.SVRAveragePriceRegion);
                ApplicationSettingsList[25] = new Setting("SVRAveragePriceDuration", SentSettings.SVRAveragePriceDuration);
                ApplicationSettingsList[26] = new Setting("AutoUpdateSVRonBPTab", Conversions.ToString(SentSettings.AutoUpdateSVRonBPTab));
                ApplicationSettingsList[27] = new Setting("ProxyAddress", SentSettings.ProxyAddress);
                ApplicationSettingsList[28] = new Setting("ProxyPort", SentSettings.ProxyPort.ToString());
                ApplicationSettingsList[29] = new Setting("SaveFacilitiesbyChar", Conversions.ToString(SentSettings.SaveFacilitiesbyChar));
                ApplicationSettingsList[30] = new Setting("LoadBPsbyChar", Conversions.ToString(SentSettings.LoadBPsbyChar));
                ApplicationSettingsList[31] = new Setting("LoadESIPublicStructuresonStartup", Conversions.ToString(SentSettings.LoadESIPublicStructuresonStartup));
                ApplicationSettingsList[32] = new Setting("DisableGATracking", Conversions.ToString(SentSettings.DisableGATracking));
                ApplicationSettingsList[33] = new Setting("AlphaAccount", Conversions.ToString(SentSettings.AlphaAccount));
                ApplicationSettingsList[34] = new Setting("UseActiveSkillLevels", Conversions.ToString(SentSettings.UseActiveSkillLevels));
                ApplicationSettingsList[35] = new Setting("SupressESIStatusMessages", Conversions.ToString(SentSettings.SupressESIStatusMessages));
                ApplicationSettingsList[36] = new Setting("LoadMaxAlphaSkills", Conversions.ToString(SentSettings.LoadMaxAlphaSkills));
                ApplicationSettingsList[37] = new Setting("ShareSavedFacilities", Conversions.ToString(SentSettings.ShareSavedFacilities));
                ApplicationSettingsList[38] = new Setting("RefineDrillDown", Conversions.ToString(SentSettings.RefineDrillDown));
                ApplicationSettingsList[39] = new Setting("AlwaysBuyFuelBlocks", Conversions.ToString(SentSettings.AlwaysBuyFuelBlocks));
                ApplicationSettingsList[40] = new Setting("AlwaysBuyRAMs", Conversions.ToString(SentSettings.AlwaysBuyRAMs));
                ApplicationSettingsList[41] = new Setting("BaseSalesTaxRate", SentSettings.BaseSalesTaxRate.ToString());
                ApplicationSettingsList[42] = new Setting("BaseBrokerFeeRate", SentSettings.BaseBrokerFeeRate.ToString());
                ApplicationSettingsList[43] = new Setting("SCCBrokerFeeSurcharge", SentSettings.SCCBrokerFeeSurcharge.ToString());
                ApplicationSettingsList[44] = new Setting("SCCIndustryFeeSurcharge", SentSettings.SCCIndustryFeeSurcharge.ToString());
                ApplicationSettingsList[45] = new Setting("AlphaAccountTaxRate", SentSettings.AlphaAccountTaxRate.ToString());
                ApplicationSettingsList[46] = new Setting("StationTaxRate", SentSettings.StationTaxRate.ToString());
                ApplicationSettingsList[47] = new Setting("StructureTaxRate", SentSettings.StructureTaxRate.ToString());

                WriteSettingsToFile(Public_Variables.SettingsFolder, AppSettingsFileName, ApplicationSettingsList, AppSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Application Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the application settings
        public ApplicationSettings GetApplicationSettings()
        {
            return ApplicationSettings;
        }

        #endregion

        #region Shopping List Settings

        // Loads the shnopping list settings from XML setting file
        public ShoppingListSettings LoadShoppingListSettings()
        {
            ShoppingListSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, ShoppingListSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = ShoppingListSettingsFileName;
                        string argFileName1 = ShoppingListSettingsFileName;
                        withBlock.DataExportFormat = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeString, ShoppingListSettingsFileName, "DataExportFormat", DefaultDataExportFormat));
                        string argFileName2 = ShoppingListSettingsFileName;
                        string argFileName3 = ShoppingListSettingsFileName;
                        withBlock.AlwaysonTop = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "AlwaysonTop", DefaultAlwaysonTop));
                        string argFileName4 = ShoppingListSettingsFileName;
                        string argFileName5 = ShoppingListSettingsFileName;
                        withBlock.UpdateAssetsWhenUsed = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "UpdateAssetsWhenUsed", DefaultUpdateAssetsWhenUsed));
                        string argFileName6 = ShoppingListSettingsFileName;
                        string argFileName7 = ShoppingListSettingsFileName;
                        withBlock.Fees = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "Fees", DefaultFees));
                        string argFileName8 = ShoppingListSettingsFileName;
                        string argFileName9 = ShoppingListSettingsFileName;
                        withBlock.CalcBuyBuyOrder = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeInteger, ShoppingListSettingsFileName, "CalcBuyBuyOrder", DefaultCalcBuyBuyOrder));
                        string argFileName10 = ShoppingListSettingsFileName;
                        string argFileName11 = ShoppingListSettingsFileName;
                        withBlock.Usage = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "Usage", DefaultUsage));
                        string argFileName12 = ShoppingListSettingsFileName;
                        string argFileName13 = ShoppingListSettingsFileName;
                        withBlock.ReloadBPsFromFile = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, ShoppingListSettingsFileName, "ReloadBPsFromFile", DefaultReloadBPsFromFile));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultShopingListSettings();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Shopping List Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultShopingListSettings();
            }

            // Save them locally and then export
            ShoppingListTabSettings = TempSettings;

            return TempSettings;

        }

        // Load defaults 
        public ShoppingListSettings SetDefaultShopingListSettings()
        {
            ShoppingListSettings TempSettings = default;

            // Load defaults 
            TempSettings.DataExportFormat = DefaultDataExportFormat;
            TempSettings.AlwaysonTop = DefaultAlwaysonTop;
            TempSettings.UpdateAssetsWhenUsed = DefaultUpdateAssetsWhenUsed;
            TempSettings.UpdateAssetsWhenUsed = DefaultUpdateAssetsWhenUsed;
            TempSettings.Fees = DefaultFees;
            TempSettings.CalcBuyBuyOrder = DefaultCalcBuyBuyOrder;
            TempSettings.Usage = DefaultUsage;
            TempSettings.ReloadBPsFromFile = DefaultReloadBPsFromFile;

            ShoppingListTabSettings = TempSettings;

            return TempSettings;

        }

        // Saves the Shopping List Settings to XML
        public void SaveShoppingListSettings(ShoppingListSettings SentSettings)
        {
            var ShoppingListSettingsList = new Setting[7];

            try
            {
                ShoppingListSettingsList[0] = new Setting("DataExportFormat", SentSettings.DataExportFormat);
                ShoppingListSettingsList[1] = new Setting("AlwaysonTop", Conversions.ToString(SentSettings.AlwaysonTop));
                ShoppingListSettingsList[2] = new Setting("UpdateAssetsWhenUsed", Conversions.ToString(SentSettings.UpdateAssetsWhenUsed));
                ShoppingListSettingsList[3] = new Setting("Fees", Conversions.ToString(SentSettings.Fees));
                ShoppingListSettingsList[4] = new Setting("CalcBuyBuyOrder", SentSettings.CalcBuyBuyOrder.ToString());
                ShoppingListSettingsList[5] = new Setting("Usage", Conversions.ToString(SentSettings.Usage));
                ShoppingListSettingsList[6] = new Setting("ReloadBPsFromFile", Conversions.ToString(SentSettings.ReloadBPsFromFile));

                WriteSettingsToFile(Public_Variables.SettingsFolder, ShoppingListSettingsFileName, ShoppingListSettingsList, ShoppingListSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Shopping List Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the Shopping List Settings
        public ShoppingListSettings GetShoppingListSettings()
        {
            return ShoppingListTabSettings;
        }

        #endregion

        #region BP Tab Settings

        // Loads the tab settings
        public BPTabSettings LoadBPSettings()
        {
            BPTabSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, BPSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = BPSettingsFileName;
                        string argFileName1 = BPSettingsFileName;
                        withBlock.BlueprintTypeSelection = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeString, BPSettingsFileName, "BlueprintTypeSelection", DefaultBPSelectionType));
                        string argFileName2 = BPSettingsFileName;
                        string argFileName3 = BPSettingsFileName;
                        withBlock.Tech1Check = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, BPSettingsFileName, "Tech1Check", DefaultBPTechChecks));
                        string argFileName4 = BPSettingsFileName;
                        string argFileName5 = BPSettingsFileName;
                        withBlock.Tech2Check = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, BPSettingsFileName, "Tech2Check", DefaultBPTechChecks));
                        string argFileName6 = BPSettingsFileName;
                        string argFileName7 = BPSettingsFileName;
                        withBlock.Tech3Check = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, BPSettingsFileName, "Tech3Check", DefaultBPTechChecks));
                        string argFileName8 = BPSettingsFileName;
                        string argFileName9 = BPSettingsFileName;
                        withBlock.TechStorylineCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, BPSettingsFileName, "TechStorylineCheck", DefaultBPTechChecks));
                        string argFileName10 = BPSettingsFileName;
                        string argFileName11 = BPSettingsFileName;
                        withBlock.TechFactionCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, BPSettingsFileName, "TechFactionCheck", DefaultBPTechChecks));
                        string argFileName12 = BPSettingsFileName;
                        string argFileName13 = BPSettingsFileName;
                        withBlock.TechPirateCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, BPSettingsFileName, "TechPirateCheck", DefaultBPTechChecks));
                        string argFileName14 = BPSettingsFileName;
                        string argFileName15 = BPSettingsFileName;
                        withBlock.IncludeUsage = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeUsage", DefaultBPIncludeUsage));
                        string argFileName16 = BPSettingsFileName;
                        string argFileName17 = BPSettingsFileName;
                        withBlock.IncludeTaxes = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeTaxes", DefaultBPIncludeTaxes));
                        string argFileName18 = BPSettingsFileName;
                        string argFileName19 = BPSettingsFileName;
                        withBlock.PricePerUnit = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeBoolean, BPSettingsFileName, "PricePerUnit", DefaultBPPricePerUnit));
                        string argFileName20 = BPSettingsFileName;
                        string argFileName21 = BPSettingsFileName;
                        withBlock.IncludeInventionCost = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeInventionCost", DefaultBPIncludeInventionCost));
                        string argFileName22 = BPSettingsFileName;
                        string argFileName23 = BPSettingsFileName;
                        withBlock.IncludeInventionTime = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeInventionTime", DefaultBPIncludeInventionTime));
                        string argFileName24 = BPSettingsFileName;
                        string argFileName25 = BPSettingsFileName;
                        withBlock.IncludeCopyCost = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeCopyCost", DefaultBPIncludecopyCost));
                        string argFileName26 = BPSettingsFileName;
                        string argFileName27 = BPSettingsFileName;
                        withBlock.IncludeCopyTime = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeCopyTime", DefaultBPIncludeCopyTime));
                        string argFileName28 = BPSettingsFileName;
                        string argFileName29 = BPSettingsFileName;
                        withBlock.IncludeT3Cost = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeT3Cost", DefaultBPIncludeT3Cost));
                        string argFileName30 = BPSettingsFileName;
                        string argFileName31 = BPSettingsFileName;
                        withBlock.IncludeT3Time = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeT3Time", DefaultBPIncludeT3Time));
                        string argFileName32 = BPSettingsFileName;
                        string argFileName33 = BPSettingsFileName;
                        withBlock.ProductionLines = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeInteger, BPSettingsFileName, "ProductionLines", DefaultBPProductionLines));
                        string argFileName34 = BPSettingsFileName;
                        string argFileName35 = BPSettingsFileName;
                        withBlock.LaboratoryLines = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeInteger, BPSettingsFileName, "LaboratoryLines", DefaultBPLaboratoryLines));
                        string argFileName36 = BPSettingsFileName;
                        string argFileName37 = BPSettingsFileName;
                        withBlock.T3Lines = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeInteger, BPSettingsFileName, "RELines", DefaultBPRELines));
                        string argFileName38 = BPSettingsFileName;
                        string argFileName39 = BPSettingsFileName;
                        withBlock.SmallCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeBoolean, BPSettingsFileName, "SmallCheck", DefaultSizeChecks));
                        string argFileName40 = BPSettingsFileName;
                        string argFileName41 = BPSettingsFileName;
                        withBlock.MediumCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeBoolean, BPSettingsFileName, "MediumCheck", DefaultSizeChecks));
                        string argFileName42 = BPSettingsFileName;
                        string argFileName43 = BPSettingsFileName;
                        withBlock.LargeCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeBoolean, BPSettingsFileName, "LargeCheck", DefaultSizeChecks));
                        string argFileName44 = BPSettingsFileName;
                        string argFileName45 = BPSettingsFileName;
                        withBlock.XLCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName45, SettingTypes.TypeBoolean, BPSettingsFileName, "XLCheck", DefaultSizeChecks));
                        string argFileName46 = BPSettingsFileName;
                        string argFileName47 = BPSettingsFileName;
                        withBlock.IncludeFees = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName47, SettingTypes.TypeInteger, BPSettingsFileName, "IncludeFees", DefaultBPIncludeFees));
                        string argFileName48 = BPSettingsFileName;
                        string argFileName49 = BPSettingsFileName;
                        withBlock.BrokerFeeRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName49, SettingTypes.TypeDouble, BPSettingsFileName, "BrokerFeeRate", DefaultBPBrokerFeeRate));
                        string argFileName50 = BPSettingsFileName;
                        string argFileName51 = BPSettingsFileName;
                        withBlock.RelicType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName51, SettingTypes.TypeString, BPSettingsFileName, "RelicType", DefaultBPRelicType));
                        string argFileName52 = BPSettingsFileName;
                        string argFileName53 = BPSettingsFileName;
                        withBlock.T2DecryptorType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName53, SettingTypes.TypeString, BPSettingsFileName, "T2DecryptorType", DefaultBPT2DecryptorType));
                        string argFileName54 = BPSettingsFileName;
                        string argFileName55 = BPSettingsFileName;
                        withBlock.T3DecryptorType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName55, SettingTypes.TypeString, BPSettingsFileName, "T3DecryptorType", DefaultBPT3DecryptorType));
                        string argFileName56 = BPSettingsFileName;
                        string argFileName57 = BPSettingsFileName;
                        withBlock.IgnoreInvention = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName57, SettingTypes.TypeBoolean, BPSettingsFileName, "IgnoreInvention", DefaultBPIgnoreInvention));
                        string argFileName58 = BPSettingsFileName;
                        string argFileName59 = BPSettingsFileName;
                        withBlock.IgnoreMinerals = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName59, SettingTypes.TypeBoolean, BPSettingsFileName, "IgnoreMinerals", DefaultBPIgnoreMinerals));
                        string argFileName60 = BPSettingsFileName;
                        string argFileName61 = BPSettingsFileName;
                        withBlock.IgnoreT1Item = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName61, SettingTypes.TypeBoolean, BPSettingsFileName, "IgnoreT1Item", DefaultBPIgnoreT1Item));
                        string argFileName62 = BPSettingsFileName;
                        string argFileName63 = BPSettingsFileName;
                        withBlock.IncludeIgnoredBPs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName63, SettingTypes.TypeBoolean, BPSettingsFileName, "IncludeIgnoredBPs", DefaultBPIncludeIgnoredBPs));
                        string argFileName64 = BPSettingsFileName;
                        string argFileName65 = BPSettingsFileName;
                        withBlock.ExporttoShoppingListType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName65, SettingTypes.TypeString, BPSettingsFileName, "ExporttoShoppingListType", DefaultBPShoppingListExportType));
                        string argFileName66 = BPSettingsFileName;
                        string argFileName67 = BPSettingsFileName;
                        withBlock.RawColumnSort = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName67, SettingTypes.TypeInteger, BPSettingsFileName, "RawColumnSort", DefaultBPRawColumnSort));
                        string argFileName68 = BPSettingsFileName;
                        string argFileName69 = BPSettingsFileName;
                        withBlock.RawColumnSortType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName69, SettingTypes.TypeString, BPSettingsFileName, "RawColumnSortType", DefaultBPRawColumnSortType));
                        string argFileName70 = BPSettingsFileName;
                        string argFileName71 = BPSettingsFileName;
                        withBlock.CompColumnSort = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName71, SettingTypes.TypeInteger, BPSettingsFileName, "CompColumnSort", DefaultBPCompColumnSort));
                        string argFileName72 = BPSettingsFileName;
                        string argFileName73 = BPSettingsFileName;
                        withBlock.CompColumnSortType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName73, SettingTypes.TypeString, BPSettingsFileName, "CompColumnSortType", DefaultBPCompColumnSortType));
                        string argFileName74 = BPSettingsFileName;
                        string argFileName75 = BPSettingsFileName;
                        withBlock.RawProfitType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName75, SettingTypes.TypeString, BPSettingsFileName, "RawProfitType", DefaultBPRawProfitType));
                        string argFileName76 = BPSettingsFileName;
                        string argFileName77 = BPSettingsFileName;
                        withBlock.CompProfitType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName77, SettingTypes.TypeString, BPSettingsFileName, "CompProfitType", DefaultBPCompProfitType));
                        string argFileName78 = BPSettingsFileName;
                        string argFileName79 = BPSettingsFileName;
                        withBlock.CompressedOre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName79, SettingTypes.TypeBoolean, BPSettingsFileName, "CompressedOre", DefaultBPCompressedOre));
                        string argFileName80 = BPSettingsFileName;
                        string argFileName81 = BPSettingsFileName;
                        withBlock.SimpleCopyCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName81, SettingTypes.TypeBoolean, BPSettingsFileName, "SimpleCopyCheck", DefaultBPSimpleCopyCheck));
                        string argFileName82 = BPSettingsFileName;
                        string argFileName83 = BPSettingsFileName;
                        withBlock.NPCBPOs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName83, SettingTypes.TypeBoolean, BPSettingsFileName, "NPCBPOs", DefaultBPNPCBPOs));
                        string argFileName84 = BPSettingsFileName;
                        string argFileName85 = BPSettingsFileName;
                        withBlock.SellExcessBuildItems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName85, SettingTypes.TypeBoolean, BPSettingsFileName, "SellExcessBuildItems", DefaultBPSellExcessItems));
                        string argFileName86 = BPSettingsFileName;
                        withBlock.BuildT2T3Materials = (BuildMatType)Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName86, SettingTypes.TypeString, BPSettingsFileName, "BuildT2T3Materials", DefaultBuiltMatsType));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultBPSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading BP Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultBPSettings();
            }

            // Save them locally and then export
            BPSettings = TempSettings;

            return TempSettings;

        }

        // Saves the tab settings to XML
        public void SaveBPSettings(BPTabSettings SentSettings)
        {
            var BPSettingsList = new Setting[44];

            try
            {
                BPSettingsList[0] = new Setting("BlueprintTypeSelection", SentSettings.BlueprintTypeSelection);
                BPSettingsList[1] = new Setting("Tech1Check", Conversions.ToString(SentSettings.Tech1Check));
                BPSettingsList[2] = new Setting("Tech2Check", Conversions.ToString(SentSettings.Tech2Check));
                BPSettingsList[3] = new Setting("Tech3Check", Conversions.ToString(SentSettings.Tech3Check));
                BPSettingsList[4] = new Setting("TechStorylineCheck", Conversions.ToString(SentSettings.TechStorylineCheck));
                BPSettingsList[5] = new Setting("TechFactionCheck", Conversions.ToString(SentSettings.TechFactionCheck));
                BPSettingsList[6] = new Setting("TechPirateCheck", Conversions.ToString(SentSettings.TechPirateCheck));
                BPSettingsList[7] = new Setting("IncludeUsage", Conversions.ToString(SentSettings.IncludeUsage));
                BPSettingsList[8] = new Setting("IncludeTaxes", Conversions.ToString(SentSettings.IncludeTaxes));
                BPSettingsList[9] = new Setting("PricePerUnit", Conversions.ToString(SentSettings.PricePerUnit));
                BPSettingsList[10] = new Setting("ProductionLines", SentSettings.ProductionLines.ToString());
                BPSettingsList[11] = new Setting("LaboratoryLines", SentSettings.LaboratoryLines.ToString());
                BPSettingsList[12] = new Setting("RELines", SentSettings.T3Lines.ToString());
                BPSettingsList[13] = new Setting("SmallCheck", Conversions.ToString(SentSettings.SmallCheck));
                BPSettingsList[14] = new Setting("MediumCheck", Conversions.ToString(SentSettings.MediumCheck));
                BPSettingsList[15] = new Setting("LargeCheck", Conversions.ToString(SentSettings.LargeCheck));
                BPSettingsList[16] = new Setting("XLCheck", Conversions.ToString(SentSettings.XLCheck));
                BPSettingsList[17] = new Setting("IncludeFees", SentSettings.IncludeFees.ToString());

                BPSettingsList[18] = new Setting("IncludeInventionCost", Conversions.ToString(SentSettings.IncludeInventionCost));
                BPSettingsList[19] = new Setting("IncludeInventionTime", Conversions.ToString(SentSettings.IncludeInventionTime));
                BPSettingsList[20] = new Setting("IncludeCopyCost", Conversions.ToString(SentSettings.IncludeCopyCost));
                BPSettingsList[21] = new Setting("IncludeCopyTime", Conversions.ToString(SentSettings.IncludeCopyTime));
                BPSettingsList[22] = new Setting("IncludeT3Cost", Conversions.ToString(SentSettings.IncludeT3Cost));
                BPSettingsList[23] = new Setting("IncludeT3Time", Conversions.ToString(SentSettings.IncludeT3Time));
                BPSettingsList[24] = new Setting("RelicType", SentSettings.RelicType);
                BPSettingsList[25] = new Setting("T2DecryptorType", SentSettings.T2DecryptorType);

                BPSettingsList[26] = new Setting("IgnoreInvention", Conversions.ToString(SentSettings.IgnoreInvention));
                BPSettingsList[27] = new Setting("IgnoreMinerals", Conversions.ToString(SentSettings.IgnoreMinerals));
                BPSettingsList[28] = new Setting("IgnoreT1Item", Conversions.ToString(SentSettings.IgnoreT1Item));

                BPSettingsList[29] = new Setting("IncludeIgnoredBPs", Conversions.ToString(SentSettings.IncludeIgnoredBPs));
                BPSettingsList[30] = new Setting("T3DecryptorType", SentSettings.T3DecryptorType);
                BPSettingsList[31] = new Setting("ExporttoShoppingListType", SentSettings.ExporttoShoppingListType);

                BPSettingsList[32] = new Setting("RawColumnSort", SentSettings.RawColumnSort.ToString());
                BPSettingsList[33] = new Setting("RawColumnSortType", SentSettings.RawColumnSortType);
                BPSettingsList[34] = new Setting("CompColumnSort", SentSettings.CompColumnSort.ToString());
                BPSettingsList[35] = new Setting("CompColumnSortType", SentSettings.CompColumnSortType);

                BPSettingsList[36] = new Setting("RawProfitType", SentSettings.RawProfitType);
                BPSettingsList[37] = new Setting("CompProfitType", SentSettings.CompProfitType);
                BPSettingsList[38] = new Setting("CompressedOre", Conversions.ToString(SentSettings.CompressedOre));

                BPSettingsList[39] = new Setting("SimpleCopyCheck", Conversions.ToString(SentSettings.SimpleCopyCheck));

                BPSettingsList[40] = new Setting("NPCBPOs", Conversions.ToString(SentSettings.NPCBPOs));
                BPSettingsList[41] = new Setting("SellExcessBuildItems", Conversions.ToString(SentSettings.SellExcessBuildItems));
                BPSettingsList[42] = new Setting("BrokerFeeRate", SentSettings.BrokerFeeRate.ToString());

                BPSettingsList[43] = new Setting("BuildT2T3Materials", ((int)SentSettings.BuildT2T3Materials).ToString());

                WriteSettingsToFile(Public_Variables.SettingsFolder, BPSettingsFileName, BPSettingsList, BPSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving BP Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Loads the defaults
        public BPTabSettings SetDefaultBPSettings()
        {
            BPTabSettings LocalSettings;

            LocalSettings.BlueprintTypeSelection = DefaultBPSelectionType;
            LocalSettings.Tech1Check = DefaultBPTechChecks;
            LocalSettings.Tech2Check = DefaultBPTechChecks;
            LocalSettings.Tech3Check = DefaultBPTechChecks;
            LocalSettings.TechStorylineCheck = DefaultBPTechChecks;
            LocalSettings.TechFactionCheck = DefaultBPTechChecks;
            LocalSettings.TechPirateCheck = DefaultBPTechChecks;
            LocalSettings.IncludeUsage = DefaultBPIncludeUsage;
            LocalSettings.IncludeTaxes = DefaultBPIncludeTaxes;
            LocalSettings.IncludeFees = DefaultIncludeBrokerFees;
            LocalSettings.BrokerFeeRate = DefaultBPBrokerFeeRate;
            LocalSettings.PricePerUnit = DefaultBPPricePerUnit;
            LocalSettings.ProductionLines = DefaultBPProductionLines;
            LocalSettings.LaboratoryLines = DefaultBPLaboratoryLines;
            LocalSettings.T3Lines = DefaultBPRELines;
            LocalSettings.SmallCheck = DefaultSizeChecks;
            LocalSettings.MediumCheck = DefaultSizeChecks;
            LocalSettings.LargeCheck = DefaultSizeChecks;
            LocalSettings.XLCheck = DefaultSizeChecks;
            LocalSettings.SimpleCopyCheck = DefaultBPSimpleCopyCheck;
            LocalSettings.NPCBPOs = DefaultBPNPCBPOs;
            LocalSettings.SellExcessBuildItems = DefaultBPSellExcessItems;

            LocalSettings.IncludeInventionCost = DefaultBPIncludeInventionCost;
            LocalSettings.IncludeInventionTime = DefaultBPIncludeInventionTime;
            LocalSettings.IncludeCopyCost = DefaultBPIncludecopyCost;
            LocalSettings.IncludeCopyTime = DefaultBPIncludeCopyTime;
            LocalSettings.IncludeT3Cost = DefaultBPIncludeT3Cost;
            LocalSettings.IncludeT3Time = DefaultBPIncludeT3Time;

            LocalSettings.RelicType = DefaultBPRelicType;
            LocalSettings.T2DecryptorType = DefaultBPT2DecryptorType;
            LocalSettings.T3DecryptorType = DefaultBPT3DecryptorType;

            LocalSettings.IgnoreInvention = DefaultBPIgnoreInvention;
            LocalSettings.IgnoreMinerals = DefaultBPIgnoreMinerals;
            LocalSettings.IgnoreT1Item = DefaultBPIgnoreT1Item;

            LocalSettings.IncludeIgnoredBPs = DefaultBPIncludeIgnoredBPs;

            LocalSettings.ExporttoShoppingListType = DefaultBPShoppingListExportType;

            LocalSettings.CompColumnSort = DefaultBPCompColumnSort;
            LocalSettings.CompColumnSortType = DefaultBPCompColumnSortType;
            LocalSettings.RawColumnSort = DefaultBPRawColumnSort;
            LocalSettings.RawColumnSortType = DefaultBPRawColumnSortType;

            LocalSettings.RawProfitType = DefaultBPRawProfitType;
            LocalSettings.CompProfitType = DefaultBPCompProfitType;

            LocalSettings.CompressedOre = DefaultBPCompressedOre;
            LocalSettings.SellExcessBuildItems = DefaultBPSellExcessItems;
            LocalSettings.BuildT2T3Materials = (BuildMatType)DefaultBuiltMatsType;

            // Save locally
            BPSettings = LocalSettings;

            return LocalSettings;

        }

        // Returns the tab settings
        public BPTabSettings GetBPSettings()
        {
            return BPSettings;
        }

        #endregion

        #region Update Price Tab Settings

        // Loads the tab settings
        public UpdatePriceTabSettings LoadUpdatePricesSettings()
        {
            UpdatePriceTabSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, UpdatePricesFileName))
                {

                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = UpdatePricesFileName;
                        string argFileName1 = UpdatePricesFileName;
                        withBlock.AllRawMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeBoolean, UpdatePricesFileName, "AllRawMats", DefaultPriceChecks));
                        string argFileName2 = UpdatePricesFileName;
                        string argFileName3 = UpdatePricesFileName;
                        withBlock.AdvancedProtectiveTechnology = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, UpdatePricesFileName, "AdvancedProtectiveTechnology", DefaultPriceChecks));
                        string argFileName4 = UpdatePricesFileName;
                        string argFileName5 = UpdatePricesFileName;
                        withBlock.Gas = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, UpdatePricesFileName, "Gas", DefaultPriceChecks));
                        string argFileName6 = UpdatePricesFileName;
                        string argFileName7 = UpdatePricesFileName;
                        withBlock.IceProducts = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, UpdatePricesFileName, "IceProducts", DefaultPriceChecks));
                        string argFileName8 = UpdatePricesFileName;
                        string argFileName9 = UpdatePricesFileName;
                        withBlock.MolecularForgingTools = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, UpdatePricesFileName, "MolecularForgingTools", DefaultPriceChecks));
                        string argFileName10 = UpdatePricesFileName;
                        string argFileName11 = UpdatePricesFileName;
                        withBlock.FactionMaterials = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, UpdatePricesFileName, "FactionMaterials", DefaultPriceChecks));
                        string argFileName12 = UpdatePricesFileName;
                        string argFileName13 = UpdatePricesFileName;
                        withBlock.NamedComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, UpdatePricesFileName, "NamedComponents", DefaultPriceChecks));
                        string argFileName14 = UpdatePricesFileName;
                        string argFileName15 = UpdatePricesFileName;
                        withBlock.Minerals = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeBoolean, UpdatePricesFileName, "Minerals", DefaultPriceChecks));
                        string argFileName16 = UpdatePricesFileName;
                        string argFileName17 = UpdatePricesFileName;
                        withBlock.Planetary = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeBoolean, UpdatePricesFileName, "Planetary", DefaultPriceChecks));
                        string argFileName18 = UpdatePricesFileName;
                        string argFileName19 = UpdatePricesFileName;
                        withBlock.RawMaterials = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeBoolean, UpdatePricesFileName, "RawMaterials", DefaultPriceChecks));
                        string argFileName20 = UpdatePricesFileName;
                        string argFileName21 = UpdatePricesFileName;
                        withBlock.Salvage = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeBoolean, UpdatePricesFileName, "Salvage", DefaultPriceChecks));
                        string argFileName22 = UpdatePricesFileName;
                        string argFileName23 = UpdatePricesFileName;
                        withBlock.Misc = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeBoolean, UpdatePricesFileName, "Misc", DefaultPriceChecks));
                        string argFileName24 = UpdatePricesFileName;
                        string argFileName25 = UpdatePricesFileName;
                        withBlock.BPCs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeBoolean, UpdatePricesFileName, "BPCs", DefaultPriceChecks));

                        string argFileName26 = UpdatePricesFileName;
                        string argFileName27 = UpdatePricesFileName;
                        withBlock.AdvancedMoonMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeBoolean, UpdatePricesFileName, "AdvancedMoonMats", DefaultPriceChecks));
                        string argFileName28 = UpdatePricesFileName;
                        string argFileName29 = UpdatePricesFileName;
                        withBlock.BoosterMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeBoolean, UpdatePricesFileName, "BoosterMats", DefaultPriceChecks));
                        string argFileName30 = UpdatePricesFileName;
                        string argFileName31 = UpdatePricesFileName;
                        withBlock.MolecularForgedMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeBoolean, UpdatePricesFileName, "MolecularForgedMats", DefaultPriceChecks));
                        string argFileName32 = UpdatePricesFileName;
                        string argFileName33 = UpdatePricesFileName;
                        withBlock.Polymers = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeBoolean, UpdatePricesFileName, "Polymers", DefaultPriceChecks));
                        string argFileName34 = UpdatePricesFileName;
                        string argFileName35 = UpdatePricesFileName;
                        withBlock.ProcessedMoonMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeBoolean, UpdatePricesFileName, "ProcessedMoonMats", DefaultPriceChecks));
                        string argFileName36 = UpdatePricesFileName;
                        string argFileName37 = UpdatePricesFileName;
                        withBlock.RawMoonMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeBoolean, UpdatePricesFileName, "RawMoonMats", DefaultPriceChecks));

                        string argFileName38 = UpdatePricesFileName;
                        string argFileName39 = UpdatePricesFileName;
                        withBlock.AncientRelics = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeBoolean, UpdatePricesFileName, "AncientRelics", DefaultPriceChecks));
                        string argFileName40 = UpdatePricesFileName;
                        string argFileName41 = UpdatePricesFileName;
                        withBlock.Datacores = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeBoolean, UpdatePricesFileName, "Datacores", DefaultPriceChecks));
                        string argFileName42 = UpdatePricesFileName;
                        string argFileName43 = UpdatePricesFileName;
                        withBlock.Decryptors = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeBoolean, UpdatePricesFileName, "Decryptors", DefaultPriceChecks));
                        string argFileName44 = UpdatePricesFileName;
                        string argFileName45 = UpdatePricesFileName;
                        withBlock.RDB = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName45, SettingTypes.TypeBoolean, UpdatePricesFileName, "RDB", DefaultPriceChecks));

                        string argFileName46 = UpdatePricesFileName;
                        string argFileName47 = UpdatePricesFileName;
                        withBlock.AllManufacturedItems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName47, SettingTypes.TypeBoolean, UpdatePricesFileName, "AllManufacturedItems", DefaultPriceChecks));

                        string argFileName48 = UpdatePricesFileName;
                        string argFileName49 = UpdatePricesFileName;
                        withBlock.Ships = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName49, SettingTypes.TypeBoolean, UpdatePricesFileName, "Ships", DefaultPriceChecks));
                        string argFileName50 = UpdatePricesFileName;
                        string argFileName51 = UpdatePricesFileName;
                        withBlock.Charges = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName51, SettingTypes.TypeBoolean, UpdatePricesFileName, "Charges", DefaultPriceChecks));
                        string argFileName52 = UpdatePricesFileName;
                        string argFileName53 = UpdatePricesFileName;
                        withBlock.Modules = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName53, SettingTypes.TypeBoolean, UpdatePricesFileName, "Modules", DefaultPriceChecks));
                        string argFileName54 = UpdatePricesFileName;
                        string argFileName55 = UpdatePricesFileName;
                        withBlock.Drones = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName55, SettingTypes.TypeBoolean, UpdatePricesFileName, "Drones", DefaultPriceChecks));
                        string argFileName56 = UpdatePricesFileName;
                        string argFileName57 = UpdatePricesFileName;
                        withBlock.Rigs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName57, SettingTypes.TypeBoolean, UpdatePricesFileName, "Rigs", DefaultPriceChecks));
                        string argFileName58 = UpdatePricesFileName;
                        string argFileName59 = UpdatePricesFileName;
                        withBlock.Subsystems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName59, SettingTypes.TypeBoolean, UpdatePricesFileName, "Subsystems", DefaultPriceChecks));
                        string argFileName60 = UpdatePricesFileName;
                        string argFileName61 = UpdatePricesFileName;
                        withBlock.Deployables = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName61, SettingTypes.TypeBoolean, UpdatePricesFileName, "Deployables", DefaultPriceChecks));
                        string argFileName62 = UpdatePricesFileName;
                        string argFileName63 = UpdatePricesFileName;
                        withBlock.Boosters = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName63, SettingTypes.TypeBoolean, UpdatePricesFileName, "Boosters", DefaultPriceChecks));
                        string argFileName64 = UpdatePricesFileName;
                        string argFileName65 = UpdatePricesFileName;
                        withBlock.Structures = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName65, SettingTypes.TypeBoolean, UpdatePricesFileName, "Structures", DefaultPriceChecks));
                        string argFileName66 = UpdatePricesFileName;
                        string argFileName67 = UpdatePricesFileName;
                        withBlock.StructureRigs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName67, SettingTypes.TypeBoolean, UpdatePricesFileName, "StructureRigs", DefaultPriceChecks));
                        string argFileName68 = UpdatePricesFileName;
                        string argFileName69 = UpdatePricesFileName;
                        withBlock.Celestials = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName69, SettingTypes.TypeBoolean, UpdatePricesFileName, "Celestials", DefaultPriceChecks));
                        string argFileName70 = UpdatePricesFileName;
                        string argFileName71 = UpdatePricesFileName;
                        withBlock.StructureModules = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName71, SettingTypes.TypeBoolean, UpdatePricesFileName, "StructureModules", DefaultPriceChecks));
                        string argFileName72 = UpdatePricesFileName;
                        string argFileName73 = UpdatePricesFileName;
                        withBlock.Implants = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName73, SettingTypes.TypeBoolean, UpdatePricesFileName, "Implants", DefaultPriceChecks));

                        string argFileName74 = UpdatePricesFileName;
                        string argFileName75 = UpdatePricesFileName;
                        withBlock.AdvancedCapComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName75, SettingTypes.TypeBoolean, UpdatePricesFileName, "AdvancedCapComponents", DefaultPriceChecks));
                        string argFileName76 = UpdatePricesFileName;
                        string argFileName77 = UpdatePricesFileName;
                        withBlock.AdvancedComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName77, SettingTypes.TypeBoolean, UpdatePricesFileName, "AdvancedComponents", DefaultPriceChecks));
                        string argFileName78 = UpdatePricesFileName;
                        string argFileName79 = UpdatePricesFileName;
                        withBlock.FuelBlocks = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName79, SettingTypes.TypeBoolean, UpdatePricesFileName, "FuelBlocks", DefaultPriceChecks));
                        string argFileName80 = UpdatePricesFileName;
                        string argFileName81 = UpdatePricesFileName;
                        withBlock.ProtectiveComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName81, SettingTypes.TypeBoolean, UpdatePricesFileName, "ProtectiveComponents", DefaultPriceChecks));
                        string argFileName82 = UpdatePricesFileName;
                        string argFileName83 = UpdatePricesFileName;
                        withBlock.RAM = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName83, SettingTypes.TypeBoolean, UpdatePricesFileName, "RAM", DefaultPriceChecks));
                        string argFileName84 = UpdatePricesFileName;
                        string argFileName85 = UpdatePricesFileName;
                        withBlock.NoBuildItems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName85, SettingTypes.TypeBoolean, UpdatePricesFileName, "NoBuildItems", false)); // Default always false on this
                        string argFileName86 = UpdatePricesFileName;
                        string argFileName87 = UpdatePricesFileName;
                        withBlock.CapitalShipComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName87, SettingTypes.TypeBoolean, UpdatePricesFileName, "CapitalShipComponents", DefaultPriceChecks));
                        string argFileName88 = UpdatePricesFileName;
                        string argFileName89 = UpdatePricesFileName;
                        withBlock.StructureComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName89, SettingTypes.TypeBoolean, UpdatePricesFileName, "StructureComponents", DefaultPriceChecks));
                        string argFileName90 = UpdatePricesFileName;
                        string argFileName91 = UpdatePricesFileName;
                        withBlock.SubsystemComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName91, SettingTypes.TypeBoolean, UpdatePricesFileName, "SubsystemComponents", DefaultPriceChecks));

                        string argFileName92 = UpdatePricesFileName;
                        string argFileName93 = UpdatePricesFileName;
                        withBlock.T1 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName93, SettingTypes.TypeBoolean, UpdatePricesFileName, "T1", DefaultPriceChecks));
                        string argFileName94 = UpdatePricesFileName;
                        string argFileName95 = UpdatePricesFileName;
                        withBlock.T2 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName95, SettingTypes.TypeBoolean, UpdatePricesFileName, "T2", DefaultPriceChecks));
                        string argFileName96 = UpdatePricesFileName;
                        string argFileName97 = UpdatePricesFileName;
                        withBlock.T3 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName97, SettingTypes.TypeBoolean, UpdatePricesFileName, "T3", DefaultPriceChecks));
                        string argFileName98 = UpdatePricesFileName;
                        string argFileName99 = UpdatePricesFileName;
                        withBlock.Faction = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName99, SettingTypes.TypeBoolean, UpdatePricesFileName, "Faction", DefaultPriceChecks));
                        string argFileName100 = UpdatePricesFileName;
                        string argFileName101 = UpdatePricesFileName;
                        withBlock.Pirate = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName101, SettingTypes.TypeBoolean, UpdatePricesFileName, "Pirate", DefaultPriceChecks));
                        string argFileName102 = UpdatePricesFileName;
                        string argFileName103 = UpdatePricesFileName;
                        withBlock.Storyline = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName103, SettingTypes.TypeBoolean, UpdatePricesFileName, "Storyline", DefaultPriceChecks));

                        string argFileName104 = UpdatePricesFileName;
                        string argFileName105 = UpdatePricesFileName;
                        withBlock.SelectedRegion = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName105, SettingTypes.TypeString, UpdatePricesFileName, "SelectedRegion", DefaultPriceRegion));
                        string argFileName106 = UpdatePricesFileName;
                        string argFileName107 = UpdatePricesFileName;
                        withBlock.SelectedSystem = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName107, SettingTypes.TypeString, UpdatePricesFileName, "SelectedSystem", DefaultPriceSystem));
                        string argFileName108 = UpdatePricesFileName;
                        string argFileName109 = UpdatePricesFileName;
                        withBlock.ItemsCombo = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName109, SettingTypes.TypeString, UpdatePricesFileName, "ItemsCombo", DefaultPriceItemsCombo));
                        string argFileName110 = UpdatePricesFileName;
                        string argFileName111 = UpdatePricesFileName;
                        withBlock.RawMatsCombo = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName111, SettingTypes.TypeString, UpdatePricesFileName, "RawMatsCombo", DefaultPriceRawMatsCombo));

                        string argFileName112 = UpdatePricesFileName;
                        string argFileName113 = UpdatePricesFileName;
                        withBlock.RawPriceModifier = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName113, SettingTypes.TypeDouble, UpdatePricesFileName, "RawPriceModifier", DefaultRawPriceModifier));
                        string argFileName114 = UpdatePricesFileName;
                        string argFileName115 = UpdatePricesFileName;
                        withBlock.ItemsPriceModifier = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName115, SettingTypes.TypeDouble, UpdatePricesFileName, "ItemsPriceModifier", DefaultItemsPriceModifier));

                        string argFileName116 = UpdatePricesFileName;
                        withBlock.PriceDataSource = (DataSource)Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName116, SettingTypes.TypeInteger, UpdatePricesFileName, "PriceDataSource", DefaultUseESIData));
                        string argFileName117 = UpdatePricesFileName;
                        string argFileName118 = UpdatePricesFileName;
                        withBlock.UsePriceProfile = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName118, SettingTypes.TypeBoolean, UpdatePricesFileName, "UsePriceProfile", DefaultUsePriceProfile));

                        string argFileName119 = UpdatePricesFileName;
                        string argFileName120 = UpdatePricesFileName;
                        withBlock.ColumnSort = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName120, SettingTypes.TypeInteger, UpdatePricesFileName, "ColumnSort", DefaultUPColumnSort));
                        string argFileName121 = UpdatePricesFileName;
                        string argFileName122 = UpdatePricesFileName;
                        withBlock.ColumnSortType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName122, SettingTypes.TypeString, UpdatePricesFileName, "ColumnSortType", DefaultUPColumnSortType));

                        string argFileName123 = UpdatePricesFileName;
                        string argFileName124 = UpdatePricesFileName;
                        withBlock.PPRawPriceType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName124, SettingTypes.TypeString, UpdatePricesFileName, "PPRawPriceType", DefaultPPRawPriceType));
                        string argFileName125 = UpdatePricesFileName;
                        string argFileName126 = UpdatePricesFileName;
                        withBlock.PPRawRegion = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName126, SettingTypes.TypeString, UpdatePricesFileName, "PPRawRegion", DefaultPPRawRegion));
                        string argFileName127 = UpdatePricesFileName;
                        string argFileName128 = UpdatePricesFileName;
                        withBlock.PPRawSystem = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName128, SettingTypes.TypeString, UpdatePricesFileName, "PPRawSystem", DefaultPPRawSystem));
                        string argFileName129 = UpdatePricesFileName;
                        string argFileName130 = UpdatePricesFileName;
                        withBlock.PPRawPriceMod = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName130, SettingTypes.TypeDouble, UpdatePricesFileName, "PPRawPriceMod", DefaultPPRawPriceMod));

                        string argFileName131 = UpdatePricesFileName;
                        string argFileName132 = UpdatePricesFileName;
                        withBlock.PPItemsPriceType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName132, SettingTypes.TypeString, UpdatePricesFileName, "PPItemsPriceType", DefaultPPItemsPriceType));
                        string argFileName133 = UpdatePricesFileName;
                        string argFileName134 = UpdatePricesFileName;
                        withBlock.PPItemsRegion = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName134, SettingTypes.TypeString, UpdatePricesFileName, "PPItemsRegion", DefaultPPItemsRegion));
                        string argFileName135 = UpdatePricesFileName;
                        string argFileName136 = UpdatePricesFileName;
                        withBlock.PPItemsSystem = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName136, SettingTypes.TypeString, UpdatePricesFileName, "PPItemsSystem", DefaultPPItemsSystem));
                        string argFileName137 = UpdatePricesFileName;
                        string argFileName138 = UpdatePricesFileName;
                        withBlock.PPItemsPriceMod = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName138, SettingTypes.TypeDouble, UpdatePricesFileName, "PPItemsPriceMod", DefaultPPItemsPriceMod));

                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultUpdatePriceSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Update Prices Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultUpdatePriceSettings();
            }

            // Save them locally and then export
            UpdatePricesSettings = TempSettings;

            return TempSettings;

        }

        // Saves the tab settings to XML
        public void SaveUpdatePricesSettings(UpdatePriceTabSettings PriceSettings)
        {
            var UpdatePricesSettingsList = new Setting[70];

            try
            {
                UpdatePricesSettingsList[0] = new Setting("AllRawMats", Conversions.ToString(PriceSettings.AllRawMats));

                UpdatePricesSettingsList[1] = new Setting("AdvancedProtectiveTechnology", Conversions.ToString(PriceSettings.AdvancedProtectiveTechnology));
                UpdatePricesSettingsList[2] = new Setting("Gas", Conversions.ToString(PriceSettings.Gas));
                UpdatePricesSettingsList[3] = new Setting("IceProducts", Conversions.ToString(PriceSettings.IceProducts));
                UpdatePricesSettingsList[4] = new Setting("MolecularForgingTools", Conversions.ToString(PriceSettings.MolecularForgingTools));
                UpdatePricesSettingsList[5] = new Setting("FactionMaterials", Conversions.ToString(PriceSettings.FactionMaterials));
                UpdatePricesSettingsList[6] = new Setting("NamedComponents", Conversions.ToString(PriceSettings.NamedComponents));
                UpdatePricesSettingsList[7] = new Setting("Minerals", Conversions.ToString(PriceSettings.Minerals));
                UpdatePricesSettingsList[8] = new Setting("Planetary", Conversions.ToString(PriceSettings.Planetary));
                UpdatePricesSettingsList[9] = new Setting("RawMaterials", Conversions.ToString(PriceSettings.RawMaterials));
                UpdatePricesSettingsList[10] = new Setting("Salvage", Conversions.ToString(PriceSettings.Salvage));
                UpdatePricesSettingsList[11] = new Setting("Misc", Conversions.ToString(PriceSettings.Misc));
                UpdatePricesSettingsList[12] = new Setting("BPCs", Conversions.ToString(PriceSettings.BPCs));

                UpdatePricesSettingsList[13] = new Setting("AdvancedMoonMats", Conversions.ToString(PriceSettings.AdvancedMoonMats));
                UpdatePricesSettingsList[14] = new Setting("BoosterMats", Conversions.ToString(PriceSettings.BoosterMats));
                UpdatePricesSettingsList[15] = new Setting("MolecularForgedMats", Conversions.ToString(PriceSettings.MolecularForgedMats));
                UpdatePricesSettingsList[16] = new Setting("Polymers", Conversions.ToString(PriceSettings.Polymers));
                UpdatePricesSettingsList[17] = new Setting("ProcessedMoonMats", Conversions.ToString(PriceSettings.ProcessedMoonMats));
                UpdatePricesSettingsList[18] = new Setting("RawMoonMats", Conversions.ToString(PriceSettings.RawMoonMats));

                UpdatePricesSettingsList[19] = new Setting("AncientRelics", Conversions.ToString(PriceSettings.AncientRelics));
                UpdatePricesSettingsList[20] = new Setting("Datacores", Conversions.ToString(PriceSettings.Datacores));
                UpdatePricesSettingsList[21] = new Setting("Decryptors", Conversions.ToString(PriceSettings.Decryptors));
                UpdatePricesSettingsList[22] = new Setting("RDB", Conversions.ToString(PriceSettings.RDB));

                UpdatePricesSettingsList[23] = new Setting("AllManufacturedItems", Conversions.ToString(PriceSettings.AllManufacturedItems));

                UpdatePricesSettingsList[24] = new Setting("Ships", Conversions.ToString(PriceSettings.Ships));
                UpdatePricesSettingsList[25] = new Setting("Charges", Conversions.ToString(PriceSettings.Charges));
                UpdatePricesSettingsList[26] = new Setting("Modules", Conversions.ToString(PriceSettings.Modules));
                UpdatePricesSettingsList[27] = new Setting("Drones", Conversions.ToString(PriceSettings.Drones));
                UpdatePricesSettingsList[28] = new Setting("Rigs", Conversions.ToString(PriceSettings.Rigs));
                UpdatePricesSettingsList[29] = new Setting("Subsystems", Conversions.ToString(PriceSettings.Subsystems));
                UpdatePricesSettingsList[30] = new Setting("Deployables", Conversions.ToString(PriceSettings.Deployables));
                UpdatePricesSettingsList[31] = new Setting("Boosters", Conversions.ToString(PriceSettings.Boosters));
                UpdatePricesSettingsList[32] = new Setting("Structures", Conversions.ToString(PriceSettings.Structures));
                UpdatePricesSettingsList[33] = new Setting("StructureRigs", Conversions.ToString(PriceSettings.StructureRigs));
                UpdatePricesSettingsList[34] = new Setting("Celestials", Conversions.ToString(PriceSettings.Celestials));
                UpdatePricesSettingsList[35] = new Setting("StructureModules", Conversions.ToString(PriceSettings.StructureModules));
                UpdatePricesSettingsList[36] = new Setting("Implants", Conversions.ToString(PriceSettings.Implants));

                UpdatePricesSettingsList[37] = new Setting("AdvancedCapComponents", Conversions.ToString(PriceSettings.AdvancedCapComponents));
                UpdatePricesSettingsList[38] = new Setting("AdvancedComponents", Conversions.ToString(PriceSettings.AdvancedComponents));
                UpdatePricesSettingsList[39] = new Setting("FuelBlocks", Conversions.ToString(PriceSettings.FuelBlocks));
                UpdatePricesSettingsList[40] = new Setting("ProtectiveComponents", Conversions.ToString(PriceSettings.ProtectiveComponents));
                UpdatePricesSettingsList[41] = new Setting("RAM", Conversions.ToString(PriceSettings.RAM));
                UpdatePricesSettingsList[42] = new Setting("CapitalShipComponents", Conversions.ToString(PriceSettings.CapitalShipComponents));
                UpdatePricesSettingsList[43] = new Setting("StructureComponents", Conversions.ToString(PriceSettings.StructureComponents));
                UpdatePricesSettingsList[44] = new Setting("SubsystemComponents", Conversions.ToString(PriceSettings.SubsystemComponents));

                UpdatePricesSettingsList[45] = new Setting("T1", Conversions.ToString(PriceSettings.T1));
                UpdatePricesSettingsList[46] = new Setting("T2", Conversions.ToString(PriceSettings.T2));
                UpdatePricesSettingsList[47] = new Setting("T3", Conversions.ToString(PriceSettings.T3));
                UpdatePricesSettingsList[48] = new Setting("Faction", Conversions.ToString(PriceSettings.Faction));
                UpdatePricesSettingsList[49] = new Setting("Pirate", Conversions.ToString(PriceSettings.Pirate));
                UpdatePricesSettingsList[50] = new Setting("Storyline", Conversions.ToString(PriceSettings.Storyline));
                UpdatePricesSettingsList[51] = new Setting("SelectedRegion", PriceSettings.SelectedRegion);
                UpdatePricesSettingsList[52] = new Setting("SelectedSystem", PriceSettings.SelectedSystem);
                UpdatePricesSettingsList[53] = new Setting("ItemsCombo", PriceSettings.ItemsCombo);
                UpdatePricesSettingsList[54] = new Setting("RawMatsCombo", PriceSettings.RawMatsCombo);

                UpdatePricesSettingsList[55] = new Setting("ColumnSort", PriceSettings.ColumnSort.ToString());
                UpdatePricesSettingsList[56] = new Setting("ColumnSortType", PriceSettings.ColumnSortType);

                UpdatePricesSettingsList[57] = new Setting("RawPriceModifier", PriceSettings.RawPriceModifier.ToString());
                UpdatePricesSettingsList[58] = new Setting("ItemsPriceModifier", PriceSettings.ItemsPriceModifier.ToString());
                UpdatePricesSettingsList[59] = new Setting("PriceDataSource", ((int)PriceSettings.PriceDataSource).ToString());
                UpdatePricesSettingsList[60] = new Setting("UsePriceProfile", Conversions.ToString(PriceSettings.UsePriceProfile));

                UpdatePricesSettingsList[61] = new Setting("PPRawPriceType", PriceSettings.PPRawPriceType);
                UpdatePricesSettingsList[62] = new Setting("PPRawRegion", PriceSettings.PPRawRegion);
                UpdatePricesSettingsList[63] = new Setting("PPRawSystem", PriceSettings.PPRawSystem);
                UpdatePricesSettingsList[64] = new Setting("PPRawPriceMod", PriceSettings.PPRawPriceMod.ToString());

                UpdatePricesSettingsList[65] = new Setting("PPItemsPriceType", PriceSettings.PPItemsPriceType);
                UpdatePricesSettingsList[66] = new Setting("PPItemsRegion", PriceSettings.PPItemsRegion);
                UpdatePricesSettingsList[67] = new Setting("PPItemsSystem", PriceSettings.PPItemsSystem);
                UpdatePricesSettingsList[68] = new Setting("PPItemsPriceMod", PriceSettings.PPItemsPriceMod.ToString());

                UpdatePricesSettingsList[69] = new Setting("NoBuildItems", Conversions.ToString(PriceSettings.NoBuildItems));

                WriteSettingsToFile(Public_Variables.SettingsFolder, UpdatePricesFileName, UpdatePricesSettingsList, UpdatePricesFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Update Prices Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        public UpdatePriceTabSettings SetDefaultUpdatePriceSettings()
        {
            UpdatePriceTabSettings LocalSettings;

            LocalSettings.AllRawMats = DefaultPriceChecks;
            LocalSettings.AdvancedProtectiveTechnology = DefaultPriceChecks;
            LocalSettings.Gas = DefaultPriceChecks;
            LocalSettings.IceProducts = DefaultPriceChecks;
            LocalSettings.MolecularForgingTools = DefaultPriceChecks;
            LocalSettings.FactionMaterials = DefaultPriceChecks;
            LocalSettings.NamedComponents = DefaultPriceChecks;
            LocalSettings.Minerals = DefaultPriceChecks;
            LocalSettings.Planetary = DefaultPriceChecks;
            LocalSettings.RawMaterials = DefaultPriceChecks;
            LocalSettings.Salvage = DefaultPriceChecks;
            LocalSettings.Misc = DefaultPriceChecks;
            LocalSettings.BPCs = DefaultPriceChecks;

            LocalSettings.AdvancedMoonMats = DefaultPriceChecks;
            LocalSettings.BoosterMats = DefaultPriceChecks;
            LocalSettings.MolecularForgedMats = DefaultPriceChecks;
            LocalSettings.Polymers = DefaultPriceChecks;
            LocalSettings.ProcessedMoonMats = DefaultPriceChecks;
            LocalSettings.RawMoonMats = DefaultPriceChecks;

            LocalSettings.AncientRelics = DefaultPriceChecks;
            LocalSettings.Datacores = DefaultPriceChecks;
            LocalSettings.Decryptors = DefaultPriceChecks;
            LocalSettings.RDB = DefaultPriceChecks;

            LocalSettings.AllManufacturedItems = DefaultPriceChecks;

            LocalSettings.Ships = DefaultPriceChecks;
            LocalSettings.Charges = DefaultPriceChecks;
            LocalSettings.Modules = DefaultPriceChecks;
            LocalSettings.Drones = DefaultPriceChecks;
            LocalSettings.Rigs = DefaultPriceChecks;
            LocalSettings.Subsystems = DefaultPriceChecks;
            LocalSettings.Deployables = DefaultPriceChecks;
            LocalSettings.Boosters = DefaultPriceChecks;
            LocalSettings.Structures = DefaultPriceChecks;
            LocalSettings.StructureRigs = DefaultPriceChecks;
            LocalSettings.Celestials = DefaultPriceChecks;
            LocalSettings.StructureModules = DefaultPriceChecks;
            LocalSettings.Implants = DefaultPriceChecks;

            LocalSettings.AdvancedCapComponents = DefaultPriceChecks;
            LocalSettings.AdvancedComponents = DefaultPriceChecks;
            LocalSettings.FuelBlocks = DefaultPriceChecks;
            LocalSettings.ProtectiveComponents = DefaultPriceChecks;
            LocalSettings.RAM = DefaultPriceChecks;
            LocalSettings.NoBuildItems = false; // Always false
            LocalSettings.CapitalShipComponents = DefaultPriceChecks;
            LocalSettings.StructureComponents = DefaultPriceChecks;
            LocalSettings.SubsystemComponents = DefaultPriceChecks;

            LocalSettings.T1 = DefaultPriceChecks;
            LocalSettings.T2 = DefaultPriceChecks;
            LocalSettings.T3 = DefaultPriceChecks;
            LocalSettings.Faction = DefaultPriceChecks;
            LocalSettings.Pirate = DefaultPriceChecks;
            LocalSettings.Storyline = DefaultPriceChecks;
            LocalSettings.SelectedRegion = DefaultPriceRegion;
            LocalSettings.SelectedSystem = DefaultPriceSystem;
            LocalSettings.ItemsCombo = DefaultPriceItemsCombo;
            LocalSettings.RawMatsCombo = DefaultPriceRawMatsCombo;
            LocalSettings.ColumnSort = DefaultUPColumnSort;
            LocalSettings.ColumnSortType = DefaultUPColumnSortType;
            LocalSettings.RawPriceModifier = DefaultRawPriceModifier;
            LocalSettings.ItemsPriceModifier = DefaultItemsPriceModifier;
            LocalSettings.PriceDataSource = (DataSource)DefaultUseESIData;
            LocalSettings.UsePriceProfile = DefaultUsePriceProfile;
            LocalSettings.StructureModules = DefaultPriceChecks;

            LocalSettings.PPItemsPriceType = DefaultPPItemsPriceType;
            LocalSettings.PPItemsRegion = DefaultPPItemsRegion;
            LocalSettings.PPItemsSystem = DefaultPPItemsSystem;
            LocalSettings.PPItemsPriceMod = DefaultPPItemsPriceMod;
            LocalSettings.PPRawPriceType = DefaultPPRawPriceType;
            LocalSettings.PPRawRegion = DefaultPPRawRegion;
            LocalSettings.PPRawSystem = DefaultPPRawSystem;

            LocalSettings.PPRawPriceMod = DefaultPPRawPriceMod;

            // Save locally
            UpdatePricesSettings = LocalSettings;
            return LocalSettings;

        }

        // Returns the tab settings
        public UpdatePriceTabSettings GetUpdatePricesSettings()
        {
            return UpdatePricesSettings;
        }

        #endregion

        #region Manufacturing Tab Settings

        // Loads the tab settings
        public ManufacturingTabSettings LoadManufacturingSettings()
        {
            ManufacturingTabSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, ManufacturingSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = ManufacturingSettingsFileName;
                        string argFileName1 = ManufacturingSettingsFileName;
                        withBlock.BlueprintType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeString, ManufacturingSettingsFileName, "BlueprintType", DefaultBlueprintType));
                        string argFileName2 = ManufacturingSettingsFileName;
                        string argFileName3 = ManufacturingSettingsFileName;
                        withBlock.CheckTech1 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTech1", DefaultCheckTech1));
                        string argFileName4 = ManufacturingSettingsFileName;
                        string argFileName5 = ManufacturingSettingsFileName;
                        withBlock.CheckTech2 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTech2", DefaultCheckTech2));
                        string argFileName6 = ManufacturingSettingsFileName;
                        string argFileName7 = ManufacturingSettingsFileName;
                        withBlock.CheckTech3 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTech3", DefaultCheckTech3));
                        string argFileName8 = ManufacturingSettingsFileName;
                        string argFileName9 = ManufacturingSettingsFileName;
                        withBlock.CheckTechStoryline = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTechStoryline", DefaultCheckTechStoryline));
                        string argFileName10 = ManufacturingSettingsFileName;
                        string argFileName11 = ManufacturingSettingsFileName;
                        withBlock.CheckTechNavy = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTechNavy", DefaultCheckTechNavy));
                        string argFileName12 = ManufacturingSettingsFileName;
                        string argFileName13 = ManufacturingSettingsFileName;
                        withBlock.CheckTechPirate = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckTechPirate", DefaultCheckTechPirate));
                        string argFileName14 = ManufacturingSettingsFileName;
                        string argFileName15 = ManufacturingSettingsFileName;
                        withBlock.ItemTypeFilter = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeString, ManufacturingSettingsFileName, "ItemTypeFilter", DefaultItemTypeFilter));
                        string argFileName16 = ManufacturingSettingsFileName;
                        string argFileName17 = ManufacturingSettingsFileName;
                        withBlock.TextItemFilter = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeString, ManufacturingSettingsFileName, "TextItemFilter", DefaultTextItemFilter));
                        string argFileName18 = ManufacturingSettingsFileName;
                        string argFileName19 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeShips = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeShips", DefaultCheckBPTypeShips));
                        string argFileName20 = ManufacturingSettingsFileName;
                        string argFileName21 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeDrones = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeDrones", DefaultCheckBPTypeDrones));
                        string argFileName22 = ManufacturingSettingsFileName;
                        string argFileName23 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeComponents", DefaultCheckBPTypeComponents));
                        string argFileName24 = ManufacturingSettingsFileName;
                        string argFileName25 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeStructures = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeStructures", DefaultCheckBPTypeStructures));
                        string argFileName26 = ManufacturingSettingsFileName;
                        string argFileName27 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeMisc = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeMisc", DefaultCheckBPTypeTools));
                        string argFileName28 = ManufacturingSettingsFileName;
                        string argFileName29 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeNPCBPOs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeNPCBPOs", DefaultCheckBPTypeNPCBPOs));
                        string argFileName30 = ManufacturingSettingsFileName;
                        string argFileName31 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeModules = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeModules", DefaultCheckBPTypeModules));
                        string argFileName32 = ManufacturingSettingsFileName;
                        string argFileName33 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeAmmoCharges = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeAmmoCharges", DefaultCheckBPTypeAmmoCharges));
                        string argFileName34 = ManufacturingSettingsFileName;
                        string argFileName35 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeRigs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeRigs", DefaultCheckBPTypeRigs));
                        string argFileName36 = ManufacturingSettingsFileName;
                        string argFileName37 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeSubsystems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeSubsystems", DefaultCheckBPTypeSubsystems));
                        string argFileName38 = ManufacturingSettingsFileName;
                        string argFileName39 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeBoosters = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeBoosters", DefaultCheckBPTypeBoosters));
                        string argFileName40 = ManufacturingSettingsFileName;
                        string argFileName41 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeDeployables = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeDeployables", DefaultCheckBPTypeDeployables));
                        string argFileName42 = ManufacturingSettingsFileName;
                        string argFileName43 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeCelestials = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeCelestials", DefaultCheckBPTypeCelestials));
                        string argFileName44 = ManufacturingSettingsFileName;
                        string argFileName45 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeReactions = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName45, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeReactions", DefaultCheckBPTypeReactions));
                        string argFileName46 = ManufacturingSettingsFileName;
                        string argFileName47 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeStructureModules = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName47, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeStructureModules", DefaultCheckBPTypeStructureModules));
                        string argFileName48 = ManufacturingSettingsFileName;
                        string argFileName49 = ManufacturingSettingsFileName;
                        withBlock.CheckBPTypeStationParts = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName49, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckBPTypeStationParts", DefaultCheckBPTypeStationParts));
                        string argFileName50 = ManufacturingSettingsFileName;
                        string argFileName51 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptorNone = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName51, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptorNone", DefaultCheckDecryptorNone));
                        string argFileName52 = ManufacturingSettingsFileName;
                        string argFileName53 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptorOptimal = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName53, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "CheckDecryptorOptimal", DefaultCheckDecryptorOptimal));
                        string argFileName54 = ManufacturingSettingsFileName;
                        string argFileName55 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptor06 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName55, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor06", DefaultCheckDecryptor06));
                        string argFileName56 = ManufacturingSettingsFileName;
                        string argFileName57 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptor09 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName57, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor09", DefaultCheckDecryptor09));
                        string argFileName58 = ManufacturingSettingsFileName;
                        string argFileName59 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptor10 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName59, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor10", DefaultCheckDecryptor10));
                        string argFileName60 = ManufacturingSettingsFileName;
                        string argFileName61 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptor11 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName61, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor11", DefaultCheckDecryptor11));
                        string argFileName62 = ManufacturingSettingsFileName;
                        string argFileName63 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptor12 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName63, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor12", DefaultCheckDecryptor12));
                        string argFileName64 = ManufacturingSettingsFileName;
                        string argFileName65 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptor15 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName65, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor15", DefaultCheckDecryptor15));
                        string argFileName66 = ManufacturingSettingsFileName;
                        string argFileName67 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptor18 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName67, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor18", DefaultCheckDecryptor18));
                        string argFileName68 = ManufacturingSettingsFileName;
                        string argFileName69 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptor19 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName69, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptor19", DefaultCheckDecryptor19));
                        string argFileName70 = ManufacturingSettingsFileName;
                        string argFileName71 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptorUseforT2 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName71, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptorUseforT2", DefaultCheckDecryptorUseforT2));
                        string argFileName72 = ManufacturingSettingsFileName;
                        string argFileName73 = ManufacturingSettingsFileName;
                        withBlock.CheckDecryptorUseforT3 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName73, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckDecryptorUseforT3", DefaultCheckDecryptorUseforT3));
                        string argFileName74 = ManufacturingSettingsFileName;
                        string argFileName75 = ManufacturingSettingsFileName;
                        withBlock.CheckIgnoreInvention = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName75, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIgnoreInvention", DefaultCheckIgnoreInvention));
                        string argFileName76 = ManufacturingSettingsFileName;
                        string argFileName77 = ManufacturingSettingsFileName;
                        withBlock.CheckRelicWrecked = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName77, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRelicWrecked", DefaultCheckRelicWrecked));
                        string argFileName78 = ManufacturingSettingsFileName;
                        string argFileName79 = ManufacturingSettingsFileName;
                        withBlock.CheckRelicIntact = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName79, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRelicIntact", DefaultCheckRelicIntact));
                        string argFileName80 = ManufacturingSettingsFileName;
                        string argFileName81 = ManufacturingSettingsFileName;
                        withBlock.CheckRelicMalfunction = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName81, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRelicMalfunction", DefaultCheckRelicMalfunction));
                        string argFileName82 = ManufacturingSettingsFileName;
                        string argFileName83 = ManufacturingSettingsFileName;
                        withBlock.CheckOnlyBuild = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName83, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckOnlyBuild", DefaultCheckOnlyBuild));
                        string argFileName84 = ManufacturingSettingsFileName;
                        string argFileName85 = ManufacturingSettingsFileName;
                        withBlock.CheckOnlyInvent = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName85, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckOnlyInvent", DefaultCheckOnlyInvent));
                        string argFileName86 = ManufacturingSettingsFileName;
                        string argFileName87 = ManufacturingSettingsFileName;
                        withBlock.CheckIncludeTaxes = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName87, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIncludeTaxes", DefaultCheckIncludeTaxes));
                        string argFileName88 = ManufacturingSettingsFileName;
                        string argFileName89 = ManufacturingSettingsFileName;
                        withBlock.CheckIncludeBrokersFees = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName89, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "CheckIncludeBrokersFees", DefaultIncludeBrokersFees));
                        string argFileName90 = ManufacturingSettingsFileName;
                        string argFileName91 = ManufacturingSettingsFileName;
                        withBlock.CalcBrokerFeeRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName91, SettingTypes.TypeDouble, ManufacturingSettingsFileName, "CalcBrokerFeeRate", DefaultCalcBrokerFeeRate));
                        string argFileName92 = ManufacturingSettingsFileName;
                        string argFileName93 = ManufacturingSettingsFileName;
                        withBlock.CheckIncludeUsage = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName93, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIncludeUsage", DefaultCheckIncludeUsage));
                        string argFileName94 = ManufacturingSettingsFileName;
                        string argFileName95 = ManufacturingSettingsFileName;
                        withBlock.CheckRaceAmarr = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName95, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceAmarr", DefaultCheckRaceAmarr));
                        string argFileName96 = ManufacturingSettingsFileName;
                        string argFileName97 = ManufacturingSettingsFileName;
                        withBlock.CheckRaceCaldari = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName97, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceCaldari", DefaultCheckRaceCaldari));
                        string argFileName98 = ManufacturingSettingsFileName;
                        string argFileName99 = ManufacturingSettingsFileName;
                        withBlock.CheckRaceGallente = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName99, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceGallente", DefaultCheckRaceGallente));
                        string argFileName100 = ManufacturingSettingsFileName;
                        string argFileName101 = ManufacturingSettingsFileName;
                        withBlock.CheckRaceMinmatar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName101, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceMinmatar", DefaultCheckRacePirate));
                        string argFileName102 = ManufacturingSettingsFileName;
                        string argFileName103 = ManufacturingSettingsFileName;
                        withBlock.CheckRacePirate = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName103, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRacePirate", DefaultCheckRacePirate));
                        string argFileName104 = ManufacturingSettingsFileName;
                        string argFileName105 = ManufacturingSettingsFileName;
                        withBlock.CheckRaceOther = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName105, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckRaceOther", DefaultCheckRaceOther));
                        string argFileName106 = ManufacturingSettingsFileName;
                        string argFileName107 = ManufacturingSettingsFileName;
                        withBlock.PriceCompare = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName107, SettingTypes.TypeString, ManufacturingSettingsFileName, "PriceCompare", DefaultPriceCompare));
                        string argFileName108 = ManufacturingSettingsFileName;
                        string argFileName109 = ManufacturingSettingsFileName;
                        withBlock.CheckIncludeT2Owned = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName109, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIncludeT2Owned", DefaultCheckIncludeT2Owned));
                        string argFileName110 = ManufacturingSettingsFileName;
                        string argFileName111 = ManufacturingSettingsFileName;
                        withBlock.CheckIncludeT3Owned = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName111, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckIncludeT3Owned", DefaultCheckIncludeT3Owned));
                        string argFileName112 = ManufacturingSettingsFileName;
                        string argFileName113 = ManufacturingSettingsFileName;
                        withBlock.CheckSVRIncludeNull = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName113, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckSVRIncludeNull", DefaultCheckSVRIncludeNull));
                        string argFileName114 = ManufacturingSettingsFileName;
                        string argFileName115 = ManufacturingSettingsFileName;
                        withBlock.ProductionLines = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName115, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "ProductionLines", DefaultCalcProductionLines));
                        string argFileName116 = ManufacturingSettingsFileName;
                        string argFileName117 = ManufacturingSettingsFileName;
                        withBlock.LaboratoryLines = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName117, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "LaboratoryLines", DefaultCalcLaboratoryLines));
                        string argFileName118 = ManufacturingSettingsFileName;
                        string argFileName119 = ManufacturingSettingsFileName;
                        withBlock.Runs = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName119, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "Runs", DefaultCalcRuns));
                        string argFileName120 = ManufacturingSettingsFileName;
                        string argFileName121 = ManufacturingSettingsFileName;
                        withBlock.BPRuns = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName121, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "BPRuns", DefaultCalcBPRuns));
                        string argFileName122 = ManufacturingSettingsFileName;
                        string argFileName123 = ManufacturingSettingsFileName;
                        withBlock.CheckSmall = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName123, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckSmall", DefaultCalcSizeChecks));
                        string argFileName124 = ManufacturingSettingsFileName;
                        string argFileName125 = ManufacturingSettingsFileName;
                        withBlock.CheckMedium = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName125, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckMedium", DefaultCalcSizeChecks));
                        string argFileName126 = ManufacturingSettingsFileName;
                        string argFileName127 = ManufacturingSettingsFileName;
                        withBlock.CheckLarge = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName127, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckLarge", DefaultCalcSizeChecks));
                        string argFileName128 = ManufacturingSettingsFileName;
                        string argFileName129 = ManufacturingSettingsFileName;
                        withBlock.CheckXL = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName129, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckXL", DefaultCalcSizeChecks));
                        string argFileName130 = ManufacturingSettingsFileName;
                        string argFileName131 = ManufacturingSettingsFileName;
                        withBlock.CheckCapitalComponentsFacility = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName131, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckCapitalComponentsFacility", DefaultCheckT3Destroyers));
                        string argFileName132 = ManufacturingSettingsFileName;
                        string argFileName133 = ManufacturingSettingsFileName;
                        withBlock.CheckT3DestroyerFacility = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName133, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckT3DestroyerFacility", DefaultCheckCapComponents));
                        string argFileName134 = ManufacturingSettingsFileName;
                        string argFileName135 = ManufacturingSettingsFileName;
                        withBlock.CheckAutoCalcNumBPs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName135, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckAutoCalcNumBPs", DefaultCheckAutoCalcNumBPs));
                        string argFileName136 = ManufacturingSettingsFileName;
                        string argFileName137 = ManufacturingSettingsFileName;
                        withBlock.IgnoreInvention = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName137, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "IgnoreInvention", DefaultCalcIgnoreInvention));
                        string argFileName138 = ManufacturingSettingsFileName;
                        string argFileName139 = ManufacturingSettingsFileName;
                        withBlock.IgnoreMinerals = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName139, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "IgnoreMinerals", DefaultCalcIgnoreMinerals));
                        string argFileName140 = ManufacturingSettingsFileName;
                        string argFileName141 = ManufacturingSettingsFileName;
                        withBlock.IgnoreT1Item = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName141, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "IgnoreT1Item", DefaultCalcIgnoreT1Item));
                        string argFileName142 = ManufacturingSettingsFileName;
                        string argFileName143 = ManufacturingSettingsFileName;
                        withBlock.CalcPPU = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName143, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CalcPPU", DefaultCalcPPU));
                        string argFileName144 = ManufacturingSettingsFileName;
                        string argFileName145 = ManufacturingSettingsFileName;
                        withBlock.ManufacturingFWUpgradeLevel = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName145, SettingTypes.TypeString, ManufacturingSettingsFileName, "ManufacturingFWUpgradeLevel", DefaultCalcManufacturingFWLevel));
                        string argFileName146 = ManufacturingSettingsFileName;
                        string argFileName147 = ManufacturingSettingsFileName;
                        withBlock.CopyingFWUpgradeLevel = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName147, SettingTypes.TypeString, ManufacturingSettingsFileName, "CopyingFWUpgradeLevel", DefaultCalcCopyingFWLevel));
                        string argFileName148 = ManufacturingSettingsFileName;
                        string argFileName149 = ManufacturingSettingsFileName;
                        withBlock.InventionFWUpgradeLevel = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName149, SettingTypes.TypeString, ManufacturingSettingsFileName, "InventionFWUpgradeLevel", DefaultCalcInventionFWLevel));
                        string argFileName150 = ManufacturingSettingsFileName;
                        string argFileName151 = ManufacturingSettingsFileName;
                        withBlock.ColumnSort = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName151, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "ColumnSort", DefaultCalcColumnSort));
                        string argFileName152 = ManufacturingSettingsFileName;
                        string argFileName153 = ManufacturingSettingsFileName;
                        withBlock.ColumnSortType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName153, SettingTypes.TypeString, ManufacturingSettingsFileName, "ColumnSortType", DefaultCalcColumnType));
                        string argFileName154 = ManufacturingSettingsFileName;
                        string argFileName155 = ManufacturingSettingsFileName;
                        withBlock.PriceTrend = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName155, SettingTypes.TypeString, ManufacturingSettingsFileName, "PriceTrend", DefaultCalcPriceTrend));
                        string argFileName156 = ManufacturingSettingsFileName;
                        string argFileName157 = ManufacturingSettingsFileName;
                        withBlock.MinBuildTime = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName157, SettingTypes.TypeString, ManufacturingSettingsFileName, "MinBuildTime", DefaultCalcMinBuildTime));
                        string argFileName158 = ManufacturingSettingsFileName;
                        string argFileName159 = ManufacturingSettingsFileName;
                        withBlock.MinBuildTimeCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName159, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "MinBuildTimeCheck", DefaultCalcMinBuildTimeCheck));
                        string argFileName160 = ManufacturingSettingsFileName;
                        string argFileName161 = ManufacturingSettingsFileName;
                        withBlock.MaxBuildTime = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName161, SettingTypes.TypeString, ManufacturingSettingsFileName, "MaxBuildTime", DefaultCalcMaxBuildTime));
                        string argFileName162 = ManufacturingSettingsFileName;
                        string argFileName163 = ManufacturingSettingsFileName;
                        withBlock.MaxBuildTimeCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName163, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "MaxBuildTimeCheck", DefaultCalcMaxBuildTimeCheck));
                        string argFileName164 = ManufacturingSettingsFileName;
                        string argFileName165 = ManufacturingSettingsFileName;
                        withBlock.IPHThreshold = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName165, SettingTypes.TypeDouble, ManufacturingSettingsFileName, "IPHThreshold", DefaultCalcIPHThreshold));
                        string argFileName166 = ManufacturingSettingsFileName;
                        string argFileName167 = ManufacturingSettingsFileName;
                        withBlock.IPHThresholdCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName167, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "IPHThresholdCheck", DefaultCalcMinBuildTimeCheck));
                        string argFileName168 = ManufacturingSettingsFileName;
                        string argFileName169 = ManufacturingSettingsFileName;
                        withBlock.ProfitThreshold = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName169, SettingTypes.TypeDouble, ManufacturingSettingsFileName, "ProfitThreshold", DefaultCalcProfitThreshold));
                        string argFileName170 = ManufacturingSettingsFileName;
                        string argFileName171 = ManufacturingSettingsFileName;
                        withBlock.ProfitThresholdCheck = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName171, SettingTypes.TypeInteger, ManufacturingSettingsFileName, "ProfitThresholdCheck", DefaultCalcProfitThresholdCheck));
                        string argFileName172 = ManufacturingSettingsFileName;
                        string argFileName173 = ManufacturingSettingsFileName;
                        withBlock.VolumeThreshold = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName173, SettingTypes.TypeDouble, ManufacturingSettingsFileName, "VolumeThreshold", DefaultCalcVolumeThreshold));
                        string argFileName174 = ManufacturingSettingsFileName;
                        string argFileName175 = ManufacturingSettingsFileName;
                        withBlock.VolumeThresholdCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName175, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "VolumeThresholdCheck", DefaultCalcVolumeThresholdCheck));
                        string argFileName176 = ManufacturingSettingsFileName;
                        string argFileName177 = ManufacturingSettingsFileName;
                        withBlock.CheckSellExcessItems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName177, SettingTypes.TypeBoolean, ManufacturingSettingsFileName, "CheckSellExcessItems", DefaultCalcSellExcessItems));
                        string argFileName178 = ManufacturingSettingsFileName;
                        withBlock.BuildT2T3Materials = (BuildMatType)Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName178, SettingTypes.TypeString, ManufacturingSettingsFileName, "BuildT2T3Materials", DefaultBuiltMatsType));
                    }
                }
                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultManufacturingSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Manufacturing Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultManufacturingSettings();
            }

            // Save them locally and then export
            ManufacturingSettings = TempSettings;

            return TempSettings;

        }

        // Loads the Defaults for the tab
        public ManufacturingTabSettings SetDefaultManufacturingSettings()
        {
            ManufacturingTabSettings LocalSettings;

            LocalSettings.BlueprintType = DefaultBlueprintType;
            LocalSettings.CheckTech1 = DefaultCheckTech1;
            LocalSettings.CheckTech2 = DefaultCheckTech2;
            LocalSettings.CheckTech3 = DefaultCheckTech3;
            LocalSettings.CheckTechStoryline = DefaultCheckTechStoryline;
            LocalSettings.CheckTechNavy = DefaultCheckTechNavy;
            LocalSettings.CheckTechPirate = DefaultCheckTechPirate;
            LocalSettings.ItemTypeFilter = DefaultItemTypeFilter;
            LocalSettings.TextItemFilter = DefaultTextItemFilter;
            LocalSettings.CheckBPTypeNPCBPOs = DefaultCheckBPTypeNPCBPOs;
            LocalSettings.CheckBPTypeShips = DefaultCheckBPTypeShips;
            LocalSettings.CheckBPTypeDrones = DefaultCheckBPTypeDrones;
            LocalSettings.CheckBPTypeComponents = DefaultCheckBPTypeComponents;
            LocalSettings.CheckBPTypeStructures = DefaultCheckBPTypeStructures;
            LocalSettings.CheckBPTypeMisc = DefaultCheckBPTypeTools;
            LocalSettings.CheckBPTypeModules = DefaultCheckBPTypeModules;
            LocalSettings.CheckBPTypeAmmoCharges = DefaultCheckBPTypeAmmoCharges;
            LocalSettings.CheckBPTypeRigs = DefaultCheckBPTypeRigs;
            LocalSettings.CheckBPTypeSubsystems = DefaultCheckBPTypeSubsystems;
            LocalSettings.CheckBPTypeBoosters = DefaultCheckBPTypeBoosters;
            LocalSettings.CheckBPTypeCelestials = DefaultCheckBPTypeCelestials;
            LocalSettings.CheckBPTypeStructureModules = DefaultCheckBPTypeStructureModules;
            LocalSettings.CheckBPTypeStationParts = DefaultCheckBPTypeStationParts;
            LocalSettings.CheckBPTypeDeployables = DefaultCheckBPTypeDeployables;
            LocalSettings.CheckBPTypeReactions = DefaultCheckBPTypeReactions;
            LocalSettings.CheckDecryptorNone = DefaultCheckDecryptorNone;
            LocalSettings.CheckDecryptorOptimal = DefaultCheckDecryptorOptimal;
            LocalSettings.CheckDecryptor06 = DefaultCheckDecryptor06;
            LocalSettings.CheckDecryptor09 = DefaultCheckDecryptor09;
            LocalSettings.CheckDecryptor10 = DefaultCheckDecryptor10;
            LocalSettings.CheckDecryptor11 = DefaultCheckDecryptor11;
            LocalSettings.CheckDecryptor12 = DefaultCheckDecryptor12;
            LocalSettings.CheckDecryptor15 = DefaultCheckDecryptor15;
            LocalSettings.CheckDecryptor18 = DefaultCheckDecryptor18;
            LocalSettings.CheckDecryptor19 = DefaultCheckDecryptor19;
            LocalSettings.CheckDecryptorUseforT2 = DefaultCheckDecryptorUseforT2;
            LocalSettings.CheckDecryptorUseforT3 = DefaultCheckDecryptorUseforT3;
            LocalSettings.CheckIgnoreInvention = DefaultCheckIgnoreInvention;
            LocalSettings.CheckRelicWrecked = DefaultCheckRelicWrecked;
            LocalSettings.CheckRelicIntact = DefaultCheckRelicIntact;
            LocalSettings.CheckRelicMalfunction = DefaultCheckRelicMalfunction;
            LocalSettings.CheckOnlyBuild = DefaultCheckOnlyBuild;
            LocalSettings.CheckOnlyInvent = DefaultCheckOnlyInvent;
            LocalSettings.CheckIncludeTaxes = DefaultCheckIncludeTaxes;
            LocalSettings.CheckIncludeBrokersFees = DefaultIncludeBrokersFees;
            LocalSettings.CalcBrokerFeeRate = DefaultCalcBrokerFeeRate;
            LocalSettings.CheckIncludeUsage = DefaultCheckIncludeUsage;
            LocalSettings.CheckRaceAmarr = DefaultCheckRaceAmarr;
            LocalSettings.CheckRaceCaldari = DefaultCheckRaceCaldari;
            LocalSettings.CheckRaceGallente = DefaultCheckRaceGallente;
            LocalSettings.CheckRaceMinmatar = DefaultCheckRaceMinmatar;
            LocalSettings.CheckRacePirate = DefaultCheckRacePirate;
            LocalSettings.CheckRaceOther = DefaultCheckRaceOther;
            LocalSettings.PriceCompare = DefaultPriceCompare;
            LocalSettings.CheckIncludeT2Owned = DefaultCheckIncludeT2Owned;
            LocalSettings.CheckIncludeT3Owned = DefaultCheckIncludeT3Owned;
            LocalSettings.CheckSVRIncludeNull = DefaultCheckSVRIncludeNull;
            LocalSettings.ProductionLines = DefaultCalcProductionLines;
            LocalSettings.LaboratoryLines = DefaultCalcLaboratoryLines;
            LocalSettings.Runs = DefaultCalcRuns;
            LocalSettings.BPRuns = DefaultCalcBPRuns;
            LocalSettings.CheckSmall = DefaultCalcSizeChecks;
            LocalSettings.CheckMedium = DefaultCalcSizeChecks;
            LocalSettings.CheckLarge = DefaultCalcSizeChecks;
            LocalSettings.CheckXL = DefaultCalcSizeChecks;
            LocalSettings.CheckT3DestroyerFacility = DefaultCheckT3Destroyers;
            LocalSettings.CheckCapitalComponentsFacility = DefaultCheckCapComponents;
            LocalSettings.CheckAutoCalcNumBPs = DefaultCheckAutoCalcNumBPs;
            LocalSettings.IgnoreInvention = DefaultCalcIgnoreInvention;
            LocalSettings.IgnoreMinerals = DefaultCalcIgnoreMinerals;
            LocalSettings.IgnoreT1Item = DefaultCalcIgnoreT1Item;
            LocalSettings.CalcPPU = DefaultCalcPPU;
            LocalSettings.CheckSellExcessItems = DefaultBPSellExcessItems;
            LocalSettings.ManufacturingFWUpgradeLevel = DefaultCalcManufacturingFWLevel;
            LocalSettings.CopyingFWUpgradeLevel = DefaultCalcCopyingFWLevel;
            LocalSettings.InventionFWUpgradeLevel = DefaultCalcInventionFWLevel;
            LocalSettings.ColumnSort = DefaultCalcColumnSort;
            LocalSettings.ColumnSortType = DefaultCalcColumnType;
            LocalSettings.PriceTrend = DefaultCalcPriceTrend;
            LocalSettings.MinBuildTime = DefaultCalcMinBuildTime;
            LocalSettings.MinBuildTimeCheck = DefaultCalcMinBuildTimeCheck;
            LocalSettings.MaxBuildTime = DefaultCalcMaxBuildTime;
            LocalSettings.MaxBuildTimeCheck = DefaultCalcMaxBuildTimeCheck;
            LocalSettings.IPHThreshold = DefaultCalcIPHThreshold;
            LocalSettings.IPHThresholdCheck = DefaultCalcIPHThresholdCheck;
            LocalSettings.ProfitThreshold = DefaultCalcProfitThreshold;
            LocalSettings.ProfitThresholdCheck = DefaultCalcProfitThresholdCheck;
            LocalSettings.VolumeThreshold = DefaultCalcVolumeThreshold;
            LocalSettings.VolumeThresholdCheck = DefaultCalcVolumeThresholdCheck;
            LocalSettings.BuildT2T3Materials = (BuildMatType)DefaultBuiltMatsType;

            // Save locally
            ManufacturingSettings = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveManufacturingSettings(ManufacturingTabSettings SentSettings)
        {
            var ManufacturingSettingsList = new Setting[89];

            try
            {
                ManufacturingSettingsList[0] = new Setting("BlueprintType", SentSettings.BlueprintType);
                ManufacturingSettingsList[1] = new Setting("CheckTech1", Conversions.ToString(SentSettings.CheckTech1));
                ManufacturingSettingsList[2] = new Setting("CheckTech2", Conversions.ToString(SentSettings.CheckTech2));
                ManufacturingSettingsList[3] = new Setting("CheckTech3", Conversions.ToString(SentSettings.CheckTech3));
                ManufacturingSettingsList[4] = new Setting("CheckTechStoryline", Conversions.ToString(SentSettings.CheckTechStoryline));
                ManufacturingSettingsList[5] = new Setting("CheckTechNavy", Conversions.ToString(SentSettings.CheckTechNavy));
                ManufacturingSettingsList[6] = new Setting("CheckTechPirate", Conversions.ToString(SentSettings.CheckTechPirate));
                ManufacturingSettingsList[7] = new Setting("ItemTypeFilter", SentSettings.ItemTypeFilter);
                ManufacturingSettingsList[8] = new Setting("TextItemFilter", SentSettings.TextItemFilter);
                ManufacturingSettingsList[9] = new Setting("CheckBPTypeShips", Conversions.ToString(SentSettings.CheckBPTypeShips));
                ManufacturingSettingsList[10] = new Setting("CheckBPTypeDrones", Conversions.ToString(SentSettings.CheckBPTypeDrones));
                ManufacturingSettingsList[11] = new Setting("CheckBPTypeComponents", Conversions.ToString(SentSettings.CheckBPTypeComponents));
                ManufacturingSettingsList[12] = new Setting("CheckBPTypeStructures", Conversions.ToString(SentSettings.CheckBPTypeStructures));
                ManufacturingSettingsList[13] = new Setting("CheckBPTypeMisc", Conversions.ToString(SentSettings.CheckBPTypeMisc));
                ManufacturingSettingsList[14] = new Setting("CheckBPTypeModules", Conversions.ToString(SentSettings.CheckBPTypeModules));
                ManufacturingSettingsList[15] = new Setting("CheckBPTypeAmmoCharges", Conversions.ToString(SentSettings.CheckBPTypeAmmoCharges));
                ManufacturingSettingsList[16] = new Setting("CheckBPTypeRigs", Conversions.ToString(SentSettings.CheckBPTypeRigs));
                ManufacturingSettingsList[17] = new Setting("CheckBPTypeSubsystems", Conversions.ToString(SentSettings.CheckBPTypeSubsystems));
                ManufacturingSettingsList[18] = new Setting("CheckBPTypeBoosters", Conversions.ToString(SentSettings.CheckBPTypeBoosters));
                ManufacturingSettingsList[19] = new Setting("CheckDecryptorNone", Conversions.ToString(SentSettings.CheckDecryptorNone));
                ManufacturingSettingsList[20] = new Setting("CheckDecryptor06", Conversions.ToString(SentSettings.CheckDecryptor06));
                ManufacturingSettingsList[21] = new Setting("CheckDecryptor10", Conversions.ToString(SentSettings.CheckDecryptor10));
                ManufacturingSettingsList[22] = new Setting("CheckDecryptor11", Conversions.ToString(SentSettings.CheckDecryptor11));
                ManufacturingSettingsList[23] = new Setting("CheckDecryptor12", Conversions.ToString(SentSettings.CheckDecryptor12));
                ManufacturingSettingsList[24] = new Setting("CheckDecryptor18", Conversions.ToString(SentSettings.CheckDecryptor18));
                ManufacturingSettingsList[25] = new Setting("CheckIgnoreInvention", Conversions.ToString(SentSettings.CheckIgnoreInvention));
                ManufacturingSettingsList[26] = new Setting("CheckRelicWrecked", Conversions.ToString(SentSettings.CheckRelicWrecked));
                ManufacturingSettingsList[27] = new Setting("CheckRelicIntact", Conversions.ToString(SentSettings.CheckRelicIntact));
                ManufacturingSettingsList[28] = new Setting("CheckRelicMalfunction", Conversions.ToString(SentSettings.CheckRelicMalfunction));
                ManufacturingSettingsList[29] = new Setting("CheckOnlyBuild", Conversions.ToString(SentSettings.CheckOnlyBuild));
                ManufacturingSettingsList[30] = new Setting("CheckOnlyInvent", Conversions.ToString(SentSettings.CheckOnlyInvent));
                ManufacturingSettingsList[31] = new Setting("CheckIncludeTaxes", Conversions.ToString(SentSettings.CheckIncludeTaxes));
                ManufacturingSettingsList[32] = new Setting("CheckIncludeUsage", Conversions.ToString(SentSettings.CheckIncludeUsage));
                ManufacturingSettingsList[33] = new Setting("CheckRaceAmarr", Conversions.ToString(SentSettings.CheckRaceAmarr));
                ManufacturingSettingsList[34] = new Setting("CheckRaceCaldari", Conversions.ToString(SentSettings.CheckRaceCaldari));
                ManufacturingSettingsList[35] = new Setting("CheckRaceGallente", Conversions.ToString(SentSettings.CheckRaceGallente));
                ManufacturingSettingsList[36] = new Setting("CheckRaceMinmatar", Conversions.ToString(SentSettings.CheckRaceMinmatar));
                ManufacturingSettingsList[37] = new Setting("CheckRacePirate", Conversions.ToString(SentSettings.CheckRacePirate));
                ManufacturingSettingsList[38] = new Setting("CheckRaceOther", Conversions.ToString(SentSettings.CheckRaceOther));
                ManufacturingSettingsList[39] = new Setting("PriceCompare", SentSettings.PriceCompare);
                ManufacturingSettingsList[40] = new Setting("CheckIncludeT2Owned", Conversions.ToString(SentSettings.CheckIncludeT2Owned));
                ManufacturingSettingsList[41] = new Setting("CheckIncludeT3Owned", Conversions.ToString(SentSettings.CheckIncludeT3Owned));
                ManufacturingSettingsList[42] = new Setting("CheckSVRIncludeNull", Conversions.ToString(SentSettings.CheckSVRIncludeNull));
                ManufacturingSettingsList[43] = new Setting("ProductionLines", SentSettings.ProductionLines.ToString());
                ManufacturingSettingsList[44] = new Setting("LaboratoryLines", SentSettings.LaboratoryLines.ToString());
                ManufacturingSettingsList[45] = new Setting("CheckDecryptor09", Conversions.ToString(SentSettings.CheckDecryptor09));
                ManufacturingSettingsList[46] = new Setting("CheckDecryptor15", Conversions.ToString(SentSettings.CheckDecryptor15));
                ManufacturingSettingsList[47] = new Setting("CheckDecryptor19", Conversions.ToString(SentSettings.CheckDecryptor19));
                ManufacturingSettingsList[48] = new Setting("Runs", SentSettings.Runs.ToString());
                ManufacturingSettingsList[49] = new Setting("CheckBPTypeCelestials", Conversions.ToString(SentSettings.CheckBPTypeCelestials));
                ManufacturingSettingsList[50] = new Setting("CheckBPTypeDeployables", Conversions.ToString(SentSettings.CheckBPTypeDeployables));
                ManufacturingSettingsList[51] = new Setting("CheckSmall", Conversions.ToString(SentSettings.CheckSmall));
                ManufacturingSettingsList[52] = new Setting("CheckMedium", Conversions.ToString(SentSettings.CheckMedium));
                ManufacturingSettingsList[53] = new Setting("CheckLarge", Conversions.ToString(SentSettings.CheckLarge));
                ManufacturingSettingsList[54] = new Setting("CheckXL", Conversions.ToString(SentSettings.CheckXL));
                ManufacturingSettingsList[55] = new Setting("CheckBPTypeStationParts", Conversions.ToString(SentSettings.CheckBPTypeStationParts));
                ManufacturingSettingsList[56] = new Setting("CheckIncludeBrokersFees", SentSettings.CheckIncludeBrokersFees.ToString());
                ManufacturingSettingsList[57] = new Setting("CheckDecryptorUseforT2", Conversions.ToString(SentSettings.CheckDecryptorUseforT2));
                ManufacturingSettingsList[58] = new Setting("CheckDecryptorUseforT3", Conversions.ToString(SentSettings.CheckDecryptorUseforT3));
                ManufacturingSettingsList[59] = new Setting("CheckCapitalComponentsFacility", Conversions.ToString(SentSettings.CheckCapitalComponentsFacility));
                ManufacturingSettingsList[60] = new Setting("CheckT3DestroyerFacility", Conversions.ToString(SentSettings.CheckT3DestroyerFacility));
                ManufacturingSettingsList[61] = new Setting("BPRuns", SentSettings.BPRuns.ToString());
                ManufacturingSettingsList[62] = new Setting("CheckAutoCalcNumBPs", Conversions.ToString(SentSettings.CheckAutoCalcNumBPs));
                ManufacturingSettingsList[63] = new Setting("IgnoreInvention", Conversions.ToString(SentSettings.IgnoreInvention));
                ManufacturingSettingsList[64] = new Setting("IgnoreMinerals", Conversions.ToString(SentSettings.IgnoreMinerals));
                ManufacturingSettingsList[65] = new Setting("IgnoreT1Item", Conversions.ToString(SentSettings.IgnoreT1Item));
                ManufacturingSettingsList[66] = new Setting("CalcPPU", Conversions.ToString(SentSettings.CalcPPU));
                ManufacturingSettingsList[67] = new Setting("ColumnSort", SentSettings.ColumnSort.ToString());
                ManufacturingSettingsList[68] = new Setting("ColumnSortType", SentSettings.ColumnSortType);
                ManufacturingSettingsList[69] = new Setting("ManufacturingFWUpgradeLevel", SentSettings.ManufacturingFWUpgradeLevel);
                ManufacturingSettingsList[70] = new Setting("CopyingFWUpgradeLevel", SentSettings.CopyingFWUpgradeLevel);
                ManufacturingSettingsList[71] = new Setting("PriceTrend", SentSettings.PriceTrend);
                ManufacturingSettingsList[72] = new Setting("MinBuildTime", SentSettings.MinBuildTime);
                ManufacturingSettingsList[73] = new Setting("MinBuildTimeCheck", Conversions.ToString(SentSettings.MinBuildTimeCheck));
                ManufacturingSettingsList[74] = new Setting("MaxBuildTime", SentSettings.MaxBuildTime);
                ManufacturingSettingsList[75] = new Setting("MaxBuildTimeCheck", Conversions.ToString(SentSettings.MaxBuildTimeCheck));
                ManufacturingSettingsList[76] = new Setting("IPHThreshold", SentSettings.IPHThreshold.ToString());
                ManufacturingSettingsList[77] = new Setting("IPHThresholdCheck", Conversions.ToString(SentSettings.IPHThresholdCheck));
                ManufacturingSettingsList[78] = new Setting("ProfitThreshold", SentSettings.ProfitThreshold.ToString());
                ManufacturingSettingsList[79] = new Setting("ProfitThresholdCheck", SentSettings.ProfitThresholdCheck.ToString());
                ManufacturingSettingsList[80] = new Setting("VolumeThreshold", SentSettings.VolumeThreshold.ToString());
                ManufacturingSettingsList[81] = new Setting("VolumeThresholdCheck", Conversions.ToString(SentSettings.VolumeThresholdCheck));
                ManufacturingSettingsList[82] = new Setting("CheckDecryptorOptimal", SentSettings.CheckDecryptorOptimal.ToString());
                ManufacturingSettingsList[83] = new Setting("CheckBPTypeStructureModules", Conversions.ToString(SentSettings.CheckBPTypeStructureModules));
                ManufacturingSettingsList[84] = new Setting("CheckBPTypeReactions", Conversions.ToString(SentSettings.CheckBPTypeReactions));
                ManufacturingSettingsList[85] = new Setting("CheckBPTypeNPCBPOs", Conversions.ToString(SentSettings.CheckBPTypeNPCBPOs));
                ManufacturingSettingsList[86] = new Setting("CheckSellExcessItems", Conversions.ToString(SentSettings.CheckSellExcessItems));
                ManufacturingSettingsList[87] = new Setting("CalcBrokerFeeRate", SentSettings.CalcBrokerFeeRate.ToString());
                ManufacturingSettingsList[88] = new Setting("BuildT2T3Materials", ((int)SentSettings.BuildT2T3Materials).ToString());

                WriteSettingsToFile(Public_Variables.SettingsFolder, ManufacturingSettingsFileName, ManufacturingSettingsList, ManufacturingSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Manufacturing Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public ManufacturingTabSettings GetManufacturingSettings()
        {
            return ManufacturingSettings;
        }

        #endregion

        #region Datacore Tab Settings

        // Loads the tab settings
        public DataCoreTabSettings LoadDatacoreSettings()
        {
            DataCoreTabSettings TempSettings = default;

            try
            {

                // Dim the settings
                TempSettings.SkillsLevel = new int[NumberofDCSettingsSkillRecords + 1];
                TempSettings.SkillsChecked = new int[NumberofDCSettingsSkillRecords + 1];
                TempSettings.CorpsStanding = new double[NumberofDCSettingsCorpRecords + 1];
                TempSettings.CorpsChecked = new int[NumberofDCSettingsCorpRecords + 1];

                if (FileExists(Public_Variables.SettingsFolder, DatacoreSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = DatacoreSettingsFileName;
                        string argFileName1 = DatacoreSettingsFileName;
                        withBlock.PricesFrom = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeString, DatacoreSettingsFileName, "PricesFrom", DefaultReactPOSFuelCost));
                        string argFileName2 = DatacoreSettingsFileName;
                        string argFileName3 = DatacoreSettingsFileName;
                        withBlock.CheckHighSecAgents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckHighSecAgents", DefaultReactCheckTaxes));
                        string argFileName4 = DatacoreSettingsFileName;
                        string argFileName5 = DatacoreSettingsFileName;
                        withBlock.CheckLowNullSecAgents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckLowNullSecAgents", DefaultReactCheckFees));
                        string argFileName6 = DatacoreSettingsFileName;
                        string argFileName7 = DatacoreSettingsFileName;
                        withBlock.CheckIncludeAgentsCannotAccess = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckIncludeAgentsCannotAccess", DefaultReactItemChecks));
                        string argFileName8 = DatacoreSettingsFileName;
                        string argFileName9 = DatacoreSettingsFileName;
                        withBlock.AgentsInRegion = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeString, DatacoreSettingsFileName, "AgentsInRegion", DefaultReactItemChecks));
                        string argFileName10 = DatacoreSettingsFileName;
                        string argFileName11 = DatacoreSettingsFileName;
                        withBlock.CheckSovAmarr = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovAmarr", DefaultReactItemChecks));
                        string argFileName12 = DatacoreSettingsFileName;
                        string argFileName13 = DatacoreSettingsFileName;
                        withBlock.CheckSovAmmatar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovAmmatar", DefaultReactItemChecks));
                        string argFileName14 = DatacoreSettingsFileName;
                        string argFileName15 = DatacoreSettingsFileName;
                        withBlock.CheckSovGallente = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovGallente", DefaultReactItemChecks));
                        string argFileName16 = DatacoreSettingsFileName;
                        string argFileName17 = DatacoreSettingsFileName;
                        withBlock.CheckSovSyndicate = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovSyndicate", DefaultReactItemChecks));
                        string argFileName18 = DatacoreSettingsFileName;
                        string argFileName19 = DatacoreSettingsFileName;
                        withBlock.CheckSovKhanid = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovKhanid", DefaultReactItemChecks));
                        string argFileName20 = DatacoreSettingsFileName;
                        string argFileName21 = DatacoreSettingsFileName;
                        withBlock.CheckSovThukker = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovThukker", DefaultReactItemChecks));
                        string argFileName22 = DatacoreSettingsFileName;
                        string argFileName23 = DatacoreSettingsFileName;
                        withBlock.CheckSovCaldari = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovCaldari", DefaultReactItemChecks));
                        string argFileName24 = DatacoreSettingsFileName;
                        string argFileName25 = DatacoreSettingsFileName;
                        withBlock.CheckSovMinmatar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeBoolean, DatacoreSettingsFileName, "CheckSovMinmatar", DefaultReactItemChecks));

                        for (int i = 1; i <= 17; i++)
                        {
                            string argFileName26 = DatacoreSettingsFileName;
                            string argFileName27 = DatacoreSettingsFileName;
                            withBlock.SkillsChecked[i - 1] = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Skill" + i.ToString() + "Checked", DefaultSkillLevelChecked));
                            string argFileName28 = DatacoreSettingsFileName;
                            string argFileName29 = DatacoreSettingsFileName;
                            withBlock.SkillsLevel[i - 1] = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Skill" + i.ToString() + "Level ", DefaultSkillLevel));
                        }

                        for (int i = 1; i <= 13; i++)
                        {
                            string argFileName30 = DatacoreSettingsFileName;
                            string argFileName31 = DatacoreSettingsFileName;
                            withBlock.CorpsChecked[i - 1] = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Corp" + i.ToString() + "Checked", DefaultSkillLevelChecked));
                            string argFileName32 = DatacoreSettingsFileName;
                            string argFileName33 = DatacoreSettingsFileName;
                            withBlock.CorpsStanding[i - 1] = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Corp" + i.ToString() + "Standing ", DefaultSkillLevel));
                        }

                        string argFileName34 = DatacoreSettingsFileName;
                        string argFileName35 = DatacoreSettingsFileName;
                        withBlock.Negotiation = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Negotiation", DefaultNegotiation));
                        string argFileName36 = DatacoreSettingsFileName;
                        string argFileName37 = DatacoreSettingsFileName;
                        withBlock.Connections = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeInteger, DatacoreSettingsFileName, "Connections", DefaultConnections));
                        string argFileName38 = DatacoreSettingsFileName;
                        string argFileName39 = DatacoreSettingsFileName;
                        withBlock.ResearchProjectMgt = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeInteger, DatacoreSettingsFileName, "ResearchProjectMgt", DefaultResearchProjMgt));

                        string argFileName40 = DatacoreSettingsFileName;
                        string argFileName41 = DatacoreSettingsFileName;
                        withBlock.ColumnSort = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeInteger, DatacoreSettingsFileName, "ColumnSort", DefaultDCColumnSort));
                        string argFileName42 = DatacoreSettingsFileName;
                        string argFileName43 = DatacoreSettingsFileName;
                        withBlock.ColumnSortType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeString, DatacoreSettingsFileName, "ColumnSortType", DefaultDCColumnSortType));

                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultDatacoreSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Datacore Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultDatacoreSettings();
            }

            // Save them locally and then export
            DatacoreSettings = TempSettings;

            return TempSettings;

        }

        public DataCoreTabSettings SetDefaultDatacoreSettings()
        {
            DataCoreTabSettings LocalSettings;

            LocalSettings.SkillsChecked = new int[NumberofDCSettingsSkillRecords + 1];
            LocalSettings.SkillsLevel = new int[NumberofDCSettingsSkillRecords + 1];

            LocalSettings.CorpsChecked = new int[NumberofDCSettingsCorpRecords + 1];
            LocalSettings.CorpsStanding = new double[NumberofDCSettingsCorpRecords + 1];

            LocalSettings.PricesFrom = DefaultDCPricesFrom;
            LocalSettings.CheckHighSecAgents = DefaultDCCheckHighSec;
            LocalSettings.CheckLowNullSecAgents = DefaultDCCheckLowNullSec;
            LocalSettings.CheckIncludeAgentsCannotAccess = DefaultDCIncludeAgentsCantUse;
            LocalSettings.AgentsInRegion = DefaultDCAgentsInRegion;
            LocalSettings.CheckSovAmarr = DefaultDCSovCheck;
            LocalSettings.CheckSovAmmatar = DefaultDCSovCheck;
            LocalSettings.CheckSovGallente = DefaultDCSovCheck;
            LocalSettings.CheckSovSyndicate = DefaultDCSovCheck;
            LocalSettings.CheckSovKhanid = DefaultDCSovCheck;
            LocalSettings.CheckSovThukker = DefaultDCSovCheck;
            LocalSettings.CheckSovCaldari = DefaultDCSovCheck;
            LocalSettings.CheckSovMinmatar = DefaultDCSovCheck;

            for (int i = 0, loopTo = LocalSettings.SkillsChecked.Count() - 1; i <= loopTo; i++)
            {
                LocalSettings.SkillsChecked[i] = DefaultSkillLevelChecked;
                LocalSettings.SkillsLevel[i] = DefaultSkillLevel;
            }

            for (int i = 0, loopTo1 = LocalSettings.CorpsChecked.Count() - 1; i <= loopTo1; i++)
            {
                LocalSettings.CorpsChecked[i] = DefaultCorpStandingChecked;
                LocalSettings.CorpsStanding[i] = DefaultCorpStanding;
            }

            LocalSettings.Negotiation = DefaultNegotiation;
            LocalSettings.Connections = DefaultConnections;
            LocalSettings.ResearchProjectMgt = DefaultResearchProjMgt;

            LocalSettings.ColumnSort = DefaultDCColumnSort;

            LocalSettings.ColumnSortType = DefaultDCColumnSortType;
            // Save locally
            DatacoreSettings = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveDatacoreSettings(DataCoreTabSettings SentSettings)
        {
            var DatacoreSettingsList = new Setting[78];
            int j;

            try
            {
                DatacoreSettingsList[0] = new Setting("PricesFrom", SentSettings.PricesFrom);
                DatacoreSettingsList[1] = new Setting("CheckHighSecAgents", Conversions.ToString(SentSettings.CheckHighSecAgents));
                DatacoreSettingsList[2] = new Setting("CheckLowNullSecAgents", Conversions.ToString(SentSettings.CheckLowNullSecAgents));
                DatacoreSettingsList[3] = new Setting("CheckIncludeAgentsCannotAccess", Conversions.ToString(SentSettings.CheckIncludeAgentsCannotAccess));
                DatacoreSettingsList[4] = new Setting("AgentsInRegion", SentSettings.AgentsInRegion);
                DatacoreSettingsList[5] = new Setting("CheckSovAmarr", Conversions.ToString(SentSettings.CheckSovAmarr));
                DatacoreSettingsList[6] = new Setting("CheckSovAmmatar", Conversions.ToString(SentSettings.CheckSovAmmatar));
                DatacoreSettingsList[7] = new Setting("CheckSovGallente", Conversions.ToString(SentSettings.CheckSovGallente));
                DatacoreSettingsList[8] = new Setting("CheckSovSyndicate", Conversions.ToString(SentSettings.CheckSovSyndicate));
                DatacoreSettingsList[9] = new Setting("CheckSovKhanid", Conversions.ToString(SentSettings.CheckSovKhanid));
                DatacoreSettingsList[10] = new Setting("CheckSovThukker", Conversions.ToString(SentSettings.CheckSovThukker));
                DatacoreSettingsList[11] = new Setting("CheckSovCaldari", Conversions.ToString(SentSettings.CheckSovCaldari));
                DatacoreSettingsList[12] = new Setting("CheckSovMinmatar", Conversions.ToString(SentSettings.CheckSovMinmatar));

                // Skills
                j = 0;
                for (int i = 13; i <= 29; i++)
                {
                    j += 1;
                    DatacoreSettingsList[i] = new Setting("Skill" + j.ToString() + "Level", SentSettings.SkillsLevel[j - 1].ToString());
                }

                j = 0;
                for (int i = 30; i <= 46; i++)
                {
                    j += 1;
                    DatacoreSettingsList[i] = new Setting("Skill" + j.ToString() + "Checked", SentSettings.SkillsChecked[j - 1].ToString());
                }

                // Corp Standings
                j = 0;
                for (int i = 47; i <= 59; i++)
                {
                    j += 1;
                    DatacoreSettingsList[i] = new Setting("Corp" + j.ToString() + "Standing", SentSettings.CorpsStanding[j - 1].ToString());
                }

                j = 0;
                for (int i = 60; i <= 72; i++)
                {
                    j += 1;
                    DatacoreSettingsList[i] = new Setting("Corp" + j.ToString() + "Checked", SentSettings.CorpsChecked[j - 1].ToString());
                }

                DatacoreSettingsList[73] = new Setting("Negotiation", SentSettings.Negotiation.ToString());
                DatacoreSettingsList[74] = new Setting("Connections", SentSettings.Connections.ToString());
                DatacoreSettingsList[75] = new Setting("ResearchProjectMgt", SentSettings.ResearchProjectMgt.ToString());

                DatacoreSettingsList[76] = new Setting("ColumnSort", SentSettings.ColumnSort.ToString());
                DatacoreSettingsList[77] = new Setting("ColumnSortType", SentSettings.ColumnSortType);

                WriteSettingsToFile(Public_Variables.SettingsFolder, DatacoreSettingsFileName, DatacoreSettingsList, DatacoreSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Datacore Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public DataCoreTabSettings GetDatacoreSettings()
        {
            return DatacoreSettings;
        }

        #endregion

        #region Mining Tab Settings

        // Loads the tab settings
        public MiningTabSettings LoadMiningSettings()
        {
            MiningTabSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, MiningSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = MiningSettingsFileName;
                        string argFileName1 = MiningSettingsFileName;
                        withBlock.OreType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeString, MiningSettingsFileName, "OreType", DefaultMiningOreType));
                        string argFileName2 = MiningSettingsFileName;
                        string argFileName3 = MiningSettingsFileName;
                        withBlock.CheckHighYieldOres = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckHighYieldOres", DefaultMiningCheckHighYieldOres));
                        string argFileName4 = MiningSettingsFileName;
                        string argFileName5 = MiningSettingsFileName;
                        withBlock.CheckHighSecOres = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckHighSecOres", DefaultMiningCheckHighSecOres));
                        string argFileName6 = MiningSettingsFileName;
                        string argFileName7 = MiningSettingsFileName;
                        withBlock.CheckLowSecOres = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckLowSecOres", DefaultMiningCheckLowSecOres));
                        string argFileName8 = MiningSettingsFileName;
                        string argFileName9 = MiningSettingsFileName;
                        withBlock.CheckNullSecOres = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckNullSecOres", DefaultMiningCheckNullSecOres));
                        string argFileName10 = MiningSettingsFileName;
                        string argFileName11 = MiningSettingsFileName;
                        withBlock.CheckA0Ores = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckA0Ores", DefaultMiningCheckA0Ores));
                        string argFileName12 = MiningSettingsFileName;
                        string argFileName13 = MiningSettingsFileName;
                        withBlock.CheckSovAmarr = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovAmarr", DefaultMiningCheckSovAmarr));
                        string argFileName14 = MiningSettingsFileName;
                        string argFileName15 = MiningSettingsFileName;
                        withBlock.CheckSovCaldari = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovCaldari", DefaultMiningCheckSovCaldari));
                        string argFileName16 = MiningSettingsFileName;
                        string argFileName17 = MiningSettingsFileName;
                        withBlock.CheckSovGallente = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovGallente", DefaultMiningCheckSovGallente));
                        string argFileName18 = MiningSettingsFileName;
                        string argFileName19 = MiningSettingsFileName;
                        withBlock.CheckSovMinmatar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovMinmatar", DefaultMiningCheckSovMinmatar));
                        string argFileName20 = MiningSettingsFileName;
                        string argFileName21 = MiningSettingsFileName;
                        withBlock.CheckSovTriglavian = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovTriglavian", DefaultMiningCheckSovTriglavian));
                        string argFileName22 = MiningSettingsFileName;
                        string argFileName23 = MiningSettingsFileName;
                        withBlock.CheckEDENCOM = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckEDENCOM", DefaultMiningCheckEDENCOM));
                        string argFileName24 = MiningSettingsFileName;
                        string argFileName25 = MiningSettingsFileName;
                        withBlock.CheckIncludeFees = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckIncludeFees", DefaultMiningCheckIncludeFees));
                        string argFileName26 = MiningSettingsFileName;
                        string argFileName27 = MiningSettingsFileName;
                        withBlock.BrokerFeeRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeDouble, MiningSettingsFileName, "BrokerFeeRate", DefaultMiningBrokerFeeRate));
                        string argFileName28 = MiningSettingsFileName;
                        string argFileName29 = MiningSettingsFileName;
                        withBlock.CheckIncludeTaxes = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckIncludeTaxes", DefaultMiningCheckIncludeTaxes));
                        string argFileName30 = MiningSettingsFileName;
                        string argFileName31 = MiningSettingsFileName;
                        withBlock.OreMiningShip = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeString, MiningSettingsFileName, "OreMiningShip", DefaultMiningMiningShip));
                        string argFileName32 = MiningSettingsFileName;
                        string argFileName33 = MiningSettingsFileName;
                        withBlock.IceMiningShip = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeString, MiningSettingsFileName, "IceMiningShip", DefaultMiningIceMiningShip));
                        string argFileName34 = MiningSettingsFileName;
                        string argFileName35 = MiningSettingsFileName;
                        withBlock.GasMiningShip = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeString, MiningSettingsFileName, "GasMiningShip", DefaultMiningGasMiningShip));
                        string argFileName36 = MiningSettingsFileName;
                        string argFileName37 = MiningSettingsFileName;
                        withBlock.OreStrip = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeString, MiningSettingsFileName, "OreStrip", DefaultMiningOreStrip));
                        string argFileName38 = MiningSettingsFileName;
                        string argFileName39 = MiningSettingsFileName;
                        withBlock.IceStrip = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeString, MiningSettingsFileName, "IceStrip", DefaultMiningIceStrip));
                        string argFileName40 = MiningSettingsFileName;
                        string argFileName41 = MiningSettingsFileName;
                        withBlock.GasHarvester = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeString, MiningSettingsFileName, "GasHarvester", DefaultMiningGasHarvester));
                        string argFileName42 = MiningSettingsFileName;
                        string argFileName43 = MiningSettingsFileName;
                        withBlock.NumOreMiners = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeInteger, MiningSettingsFileName, "NumOreMiners", DefaultMiningNumOreMiners));
                        string argFileName44 = MiningSettingsFileName;
                        string argFileName45 = MiningSettingsFileName;
                        withBlock.NumIceMiners = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName45, SettingTypes.TypeInteger, MiningSettingsFileName, "NumIceMiners", DefaultMiningNumIceMiners));
                        string argFileName46 = MiningSettingsFileName;
                        string argFileName47 = MiningSettingsFileName;
                        withBlock.NumGasHarvesters = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName47, SettingTypes.TypeInteger, MiningSettingsFileName, "NumGasHarvesters", DefaultMiningNumGasHarvesters));
                        string argFileName48 = MiningSettingsFileName;
                        string argFileName49 = MiningSettingsFileName;
                        withBlock.OreUpgrade = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName49, SettingTypes.TypeString, MiningSettingsFileName, "OreUpgrade", DefaultMiningOreUpgrade));
                        string argFileName50 = MiningSettingsFileName;
                        string argFileName51 = MiningSettingsFileName;
                        withBlock.IceUpgrade = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName51, SettingTypes.TypeString, MiningSettingsFileName, "IceUpgrade", DefaultMiningIceUpgrade));
                        string argFileName52 = MiningSettingsFileName;
                        string argFileName53 = MiningSettingsFileName;
                        withBlock.GasUpgrade = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName53, SettingTypes.TypeString, MiningSettingsFileName, "GasUpgrade", DefaultMiningGasUpgrade));
                        string argFileName54 = MiningSettingsFileName;
                        string argFileName55 = MiningSettingsFileName;
                        withBlock.NumOreUpgrades = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName55, SettingTypes.TypeInteger, MiningSettingsFileName, "NumOreUpgrades", DefaultMiningNumOreUpgrades));
                        string argFileName56 = MiningSettingsFileName;
                        string argFileName57 = MiningSettingsFileName;
                        withBlock.NumIceUpgrades = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName57, SettingTypes.TypeInteger, MiningSettingsFileName, "NumIceUpgrades", DefaultMiningNumIceUpgrades));
                        string argFileName58 = MiningSettingsFileName;
                        string argFileName59 = MiningSettingsFileName;
                        withBlock.NumGasUpgrades = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName59, SettingTypes.TypeInteger, MiningSettingsFileName, "NumGasUpgrades", DefaultMiningNumGasUpgrades));
                        string argFileName60 = MiningSettingsFileName;
                        string argFileName61 = MiningSettingsFileName;
                        withBlock.MichiiImplant = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName61, SettingTypes.TypeBoolean, MiningSettingsFileName, "MichiiImplant", DefaultMiningMichiiImplant));
                        string argFileName62 = MiningSettingsFileName;
                        string argFileName63 = MiningSettingsFileName;
                        withBlock.T1Crystals = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName63, SettingTypes.TypeBoolean, MiningSettingsFileName, "T1Crystals", DefaultMiningCrystals));
                        string argFileName64 = MiningSettingsFileName;
                        string argFileName65 = MiningSettingsFileName;
                        withBlock.T2Crystals = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName65, SettingTypes.TypeBoolean, MiningSettingsFileName, "T2Crystals", DefaultMiningCrystals));
                        string argFileName66 = MiningSettingsFileName;
                        string argFileName67 = MiningSettingsFileName;
                        withBlock.OreImplant = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName67, SettingTypes.TypeString, MiningSettingsFileName, "OreImplant", DefaultMiningOreImplant));
                        string argFileName68 = MiningSettingsFileName;
                        string argFileName69 = MiningSettingsFileName;
                        withBlock.IceImplant = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName69, SettingTypes.TypeString, MiningSettingsFileName, "IceImplant", DefaultMiningIceImplant));
                        string argFileName70 = MiningSettingsFileName;
                        string argFileName71 = MiningSettingsFileName;
                        withBlock.GasImplant = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName71, SettingTypes.TypeString, MiningSettingsFileName, "GasImplant", DefaultMiningGasImplant));
                        string argFileName72 = MiningSettingsFileName;
                        string argFileName73 = MiningSettingsFileName;
                        withBlock.CheckUseHauler = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName73, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckUseHauler", DefaultMiningCheckUseHauler));
                        string argFileName74 = MiningSettingsFileName;
                        string argFileName75 = MiningSettingsFileName;
                        withBlock.RoundTripMin = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName75, SettingTypes.TypeInteger, MiningSettingsFileName, "RoundTripMin", DefaultMiningRoundTripMin));
                        string argFileName76 = MiningSettingsFileName;
                        string argFileName77 = MiningSettingsFileName;
                        withBlock.RoundTripSec = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName77, SettingTypes.TypeInteger, MiningSettingsFileName, "RoundTripSec", DefaultMiningRoundTripSec));
                        string argFileName78 = MiningSettingsFileName;
                        string argFileName79 = MiningSettingsFileName;
                        withBlock.Haulerm3 = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName79, SettingTypes.TypeInteger, MiningSettingsFileName, "Haulerm3", DefaultMiningHaulerm3));
                        string argFileName80 = MiningSettingsFileName;
                        string argFileName81 = MiningSettingsFileName;
                        withBlock.CheckUseFleetBooster = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName81, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckUseFleetBooster", DefaultMiningCheckUseFleetBooster));
                        string argFileName82 = MiningSettingsFileName;
                        string argFileName83 = MiningSettingsFileName;
                        withBlock.BoosterShip = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName83, SettingTypes.TypeString, MiningSettingsFileName, "BoosterShip", DefaultMiningBoosterShip));
                        string argFileName84 = MiningSettingsFileName;
                        string argFileName85 = MiningSettingsFileName;
                        withBlock.BoosterShipSkill = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName85, SettingTypes.TypeInteger, MiningSettingsFileName, "BoosterShipSkill", DefaultMiningBoosterShipSkill));
                        string argFileName86 = MiningSettingsFileName;
                        string argFileName87 = MiningSettingsFileName;
                        withBlock.MiningFormanSkill = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName87, SettingTypes.TypeInteger, MiningSettingsFileName, "MiningFormanSkill", DefaultMiningMiningFormanSkill));
                        string argFileName88 = MiningSettingsFileName;
                        string argFileName89 = MiningSettingsFileName;
                        withBlock.MiningDirectorSkill = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName89, SettingTypes.TypeInteger, MiningSettingsFileName, "MiningDirectorSkill", DefaultMiningMiningDirectorSkill));
                        string argFileName90 = MiningSettingsFileName;
                        string argFileName91 = MiningSettingsFileName;
                        withBlock.CheckMineForemanLaserOpBoost = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName91, SettingTypes.TypeInteger, MiningSettingsFileName, "CheckMineForemanLaserOpBoost", DefaultMiningCheckMineForemanLaserOpBoost));
                        string argFileName92 = MiningSettingsFileName;
                        string argFileName93 = MiningSettingsFileName;
                        withBlock.CheckMineForemanLaserRangeBoost = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName93, SettingTypes.TypeInteger, MiningSettingsFileName, "CheckMineForemanLaserRangeBoost", DefaultMiningCheckMineForemanLaserOpBoost));
                        string argFileName94 = MiningSettingsFileName;
                        string argFileName95 = MiningSettingsFileName;
                        withBlock.CheckMiningForemanMindLink = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName95, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckMiningForemanMindLink", DefaultMiningCheckMiningForemanMindLink));
                        string argFileName96 = MiningSettingsFileName;
                        string argFileName97 = MiningSettingsFileName;
                        withBlock.CheckRorqDeployed = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName97, SettingTypes.TypeInteger, MiningSettingsFileName, "CheckRorqDeployed", DefaultMiningRorqDeployed));
                        string argFileName98 = MiningSettingsFileName;
                        string argFileName99 = MiningSettingsFileName;
                        withBlock.RefinedOre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName99, SettingTypes.TypeBoolean, MiningSettingsFileName, "RefinedOre", DefaultMiningRefinedOre));
                        string argFileName100 = MiningSettingsFileName;
                        string argFileName101 = MiningSettingsFileName;
                        withBlock.UnrefinedOre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName101, SettingTypes.TypeBoolean, MiningSettingsFileName, "UnrefinedOre", DefaultMiningUnrefinedOre));
                        string argFileName102 = MiningSettingsFileName;
                        string argFileName103 = MiningSettingsFileName;
                        withBlock.CompressedOre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName103, SettingTypes.TypeBoolean, MiningSettingsFileName, "CompressedOre", DefaultMiningCompressedOre));
                        string argFileName104 = MiningSettingsFileName;
                        string argFileName105 = MiningSettingsFileName;
                        withBlock.IndustrialReconfig = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName105, SettingTypes.TypeInteger, MiningSettingsFileName, "IndustrialReconfig", DefaultMiningIndustrialReconfig));
                        string argFileName106 = MiningSettingsFileName;
                        string argFileName107 = MiningSettingsFileName;
                        withBlock.CheckSovWormhole = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName107, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovWormhole", DefaultMiningCheckSovWormhole));
                        string argFileName108 = MiningSettingsFileName;
                        string argFileName109 = MiningSettingsFileName;
                        withBlock.CheckSovMoon = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName109, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovMoon", DefaultMiningCheckSovMoon));
                        string argFileName110 = MiningSettingsFileName;
                        string argFileName111 = MiningSettingsFileName;
                        withBlock.CheckSovC1 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName111, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC1", DefaultMiningCheckSovC1));
                        string argFileName112 = MiningSettingsFileName;
                        string argFileName113 = MiningSettingsFileName;
                        withBlock.CheckSovC2 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName113, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC2", DefaultMiningCheckSovC2));
                        string argFileName114 = MiningSettingsFileName;
                        string argFileName115 = MiningSettingsFileName;
                        withBlock.CheckSovC3 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName115, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC3", DefaultMiningCheckSovC3));
                        string argFileName116 = MiningSettingsFileName;
                        string argFileName117 = MiningSettingsFileName;
                        withBlock.CheckSovC4 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName117, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC4", DefaultMiningCheckSovC4));
                        string argFileName118 = MiningSettingsFileName;
                        string argFileName119 = MiningSettingsFileName;
                        withBlock.CheckSovC5 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName119, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC5", DefaultMiningCheckSovC5));
                        string argFileName120 = MiningSettingsFileName;
                        string argFileName121 = MiningSettingsFileName;
                        withBlock.CheckSovC6 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName121, SettingTypes.TypeBoolean, MiningSettingsFileName, "CheckSovC6", DefaultMiningCheckSovC6));
                        string argFileName122 = MiningSettingsFileName;
                        string argFileName123 = MiningSettingsFileName;
                        withBlock.NumberofMiners = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName123, SettingTypes.TypeInteger, MiningSettingsFileName, "NumberofMiners", DefaultMiningNumberofMiners));
                        string argFileName124 = MiningSettingsFileName;
                        string argFileName125 = MiningSettingsFileName;
                        withBlock.ColumnSort = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName125, SettingTypes.TypeInteger, MiningSettingsFileName, "ColumnSort", DefaultMiningColumnSort));
                        string argFileName126 = MiningSettingsFileName;
                        string argFileName127 = MiningSettingsFileName;
                        withBlock.ColumnSortType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName127, SettingTypes.TypeString, MiningSettingsFileName, "ColumnSortType", DefaultMiningColumnSortType));
                        string argFileName128 = MiningSettingsFileName;
                        string argFileName129 = MiningSettingsFileName;
                        withBlock.MiningDrone = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName129, SettingTypes.TypeString, MiningSettingsFileName, "MiningDrone", DefaultMiningDrone));
                        string argFileName130 = MiningSettingsFileName;
                        string argFileName131 = MiningSettingsFileName;
                        withBlock.IceMiningDrone = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName131, SettingTypes.TypeString, MiningSettingsFileName, "IceMiningDrone", DefaultIceMiningDrone));
                        string argFileName132 = MiningSettingsFileName;
                        string argFileName133 = MiningSettingsFileName;
                        withBlock.NumMiningDrones = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName133, SettingTypes.TypeString, MiningSettingsFileName, "NumMiningDrones", DefaultNumMiningDrone));
                        string argFileName134 = MiningSettingsFileName;
                        string argFileName135 = MiningSettingsFileName;
                        withBlock.NumIceMiningDrones = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName135, SettingTypes.TypeString, MiningSettingsFileName, "NumIceMiningDrones", DefaultNumIceMiningdrone));
                        string argFileName136 = MiningSettingsFileName;
                        string argFileName137 = MiningSettingsFileName;
                        withBlock.DroneOpSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName137, SettingTypes.TypeString, MiningSettingsFileName, "DroneOpSkill", DefaultDroneSkills));
                        string argFileName138 = MiningSettingsFileName;
                        string argFileName139 = MiningSettingsFileName;
                        withBlock.DroneSpecSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName139, SettingTypes.TypeString, MiningSettingsFileName, "DroneSpecSkill", DefaultDroneSkills));
                        string argFileName140 = MiningSettingsFileName;
                        string argFileName141 = MiningSettingsFileName;
                        withBlock.DroneInterfaceSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName141, SettingTypes.TypeString, MiningSettingsFileName, "DroneInterfaceSkill", DefaultDroneSkills));
                        string argFileName142 = MiningSettingsFileName;
                        string argFileName143 = MiningSettingsFileName;
                        withBlock.IceDroneOpSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName143, SettingTypes.TypeString, MiningSettingsFileName, "IceDroneOpSkill", DefaultDroneSkills));
                        string argFileName144 = MiningSettingsFileName;
                        string argFileName145 = MiningSettingsFileName;
                        withBlock.IceDroneSpecSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName145, SettingTypes.TypeString, MiningSettingsFileName, "IceDroneSpecSkill", DefaultDroneSkills));
                        string argFileName146 = MiningSettingsFileName;
                        string argFileName147 = MiningSettingsFileName;
                        withBlock.IceDroneInterfaceSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName147, SettingTypes.TypeString, MiningSettingsFileName, "IceDroneInterfaceSkill", DefaultDroneSkills));
                        string argFileName148 = MiningSettingsFileName;
                        string argFileName149 = MiningSettingsFileName;
                        withBlock.BoosterMiningDrone = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName149, SettingTypes.TypeString, MiningSettingsFileName, "BoosterMiningDrone", DefaultMiningDrone));
                        string argFileName150 = MiningSettingsFileName;
                        string argFileName151 = MiningSettingsFileName;
                        withBlock.BoosterIceMiningDrone = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName151, SettingTypes.TypeString, MiningSettingsFileName, "BoosterIceMiningDrone", DefaultIceMiningDrone));
                        string argFileName152 = MiningSettingsFileName;
                        string argFileName153 = MiningSettingsFileName;
                        withBlock.BoosterNumMiningDrones = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName153, SettingTypes.TypeString, MiningSettingsFileName, "BoosterNumMiningDrones", DefaultNumMiningDrone));
                        string argFileName154 = MiningSettingsFileName;
                        string argFileName155 = MiningSettingsFileName;
                        withBlock.BoosterNumIceMiningDrones = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName155, SettingTypes.TypeString, MiningSettingsFileName, "BoosterNumIceMiningDrones", DefaultNumIceMiningdrone));
                        string argFileName156 = MiningSettingsFileName;
                        string argFileName157 = MiningSettingsFileName;
                        withBlock.BoosterDroneOpSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName157, SettingTypes.TypeString, MiningSettingsFileName, "BoosterDroneOpSkill", DefaultDroneSkills));
                        string argFileName158 = MiningSettingsFileName;
                        string argFileName159 = MiningSettingsFileName;
                        withBlock.BoosterDroneSpecSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName159, SettingTypes.TypeString, MiningSettingsFileName, "BoosterDroneSpecSkill", DefaultDroneSkills));
                        string argFileName160 = MiningSettingsFileName;
                        string argFileName161 = MiningSettingsFileName;
                        withBlock.BoosterDroneInterfaceSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName161, SettingTypes.TypeString, MiningSettingsFileName, "BoosterDroneInterfaceSkill", DefaultDroneSkills));
                        string argFileName162 = MiningSettingsFileName;
                        string argFileName163 = MiningSettingsFileName;
                        withBlock.BoosterIceDroneOpSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName163, SettingTypes.TypeString, MiningSettingsFileName, "BoosterIceDroneOpSkill", DefaultDroneSkills));
                        string argFileName164 = MiningSettingsFileName;
                        string argFileName165 = MiningSettingsFileName;
                        withBlock.BoosterIceDroneSpecSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName165, SettingTypes.TypeString, MiningSettingsFileName, "BoosterIceDroneSpecSkill", DefaultDroneSkills));
                        string argFileName166 = MiningSettingsFileName;
                        string argFileName167 = MiningSettingsFileName;
                        withBlock.BoosterIceDroneInterfaceSkill = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName167, SettingTypes.TypeString, MiningSettingsFileName, "BoosterIceDroneInterfaceSkill", DefaultDroneSkills));
                        string argFileName168 = MiningSettingsFileName;
                        string argFileName169 = MiningSettingsFileName;
                        withBlock.BoosterUseDrones = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName169, SettingTypes.TypeBoolean, MiningSettingsFileName, "BoosterUseDrones", DefaultBoosterUseDrones));
                        string argFileName170 = MiningSettingsFileName;
                        string argFileName171 = MiningSettingsFileName;
                        withBlock.ShipDroneRig1 = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName171, SettingTypes.TypeString, MiningSettingsFileName, "ShipDroneRig1", DefaultDroneRigs));
                        string argFileName172 = MiningSettingsFileName;
                        string argFileName173 = MiningSettingsFileName;
                        withBlock.ShipDroneRig2 = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName173, SettingTypes.TypeString, MiningSettingsFileName, "ShipDroneRig2", DefaultDroneRigs));
                        string argFileName174 = MiningSettingsFileName;
                        string argFileName175 = MiningSettingsFileName;
                        withBlock.ShipDroneRig3 = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName175, SettingTypes.TypeString, MiningSettingsFileName, "ShipDroneRig3", DefaultDroneRigs));
                        string argFileName176 = MiningSettingsFileName;
                        string argFileName177 = MiningSettingsFileName;
                        withBlock.ShipIceDroneRig1 = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName177, SettingTypes.TypeString, MiningSettingsFileName, "ShipIceDroneRig1", DefaultDroneRigs));
                        string argFileName178 = MiningSettingsFileName;
                        string argFileName179 = MiningSettingsFileName;
                        withBlock.ShipIceDroneRig2 = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName179, SettingTypes.TypeString, MiningSettingsFileName, "ShipIceDroneRig2", DefaultDroneRigs));
                        string argFileName180 = MiningSettingsFileName;
                        string argFileName181 = MiningSettingsFileName;
                        withBlock.ShipIceDroneRig3 = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName181, SettingTypes.TypeString, MiningSettingsFileName, "ShipIceDroneRig3", DefaultDroneRigs));
                        string argFileName182 = MiningSettingsFileName;
                        string argFileName183 = MiningSettingsFileName;
                        withBlock.BoosterDroneRig1 = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName183, SettingTypes.TypeInteger, MiningSettingsFileName, "BoosterDroneRig1", DefaultBoosterDroneRigs));
                        string argFileName184 = MiningSettingsFileName;
                        string argFileName185 = MiningSettingsFileName;
                        withBlock.BoosterDroneRig2 = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName185, SettingTypes.TypeInteger, MiningSettingsFileName, "BoosterDroneRig2", DefaultBoosterDroneRigs));
                        string argFileName186 = MiningSettingsFileName;
                        string argFileName187 = MiningSettingsFileName;
                        withBlock.BoosterDroneRig3 = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName187, SettingTypes.TypeInteger, MiningSettingsFileName, "BoosterDroneRig3", DefaultBoosterDroneRigs));
                        string argFileName188 = MiningSettingsFileName;
                        string argFileName189 = MiningSettingsFileName;
                        withBlock.BoosterIceDroneRig1 = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName189, SettingTypes.TypeInteger, MiningSettingsFileName, "BoosterIceDroneRig1", DefaultBoosterDroneRigs));
                        string argFileName190 = MiningSettingsFileName;
                        string argFileName191 = MiningSettingsFileName;
                        withBlock.BoosterIceDroneRig2 = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName191, SettingTypes.TypeInteger, MiningSettingsFileName, "BoosterIceDroneRig2", DefaultBoosterDroneRigs));
                        string argFileName192 = MiningSettingsFileName;
                        string argFileName193 = MiningSettingsFileName;
                        withBlock.BoosterIceDroneRig3 = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName193, SettingTypes.TypeInteger, MiningSettingsFileName, "BoosterIceDroneRig3", DefaultBoosterDroneRigs));
                        string argFileName194 = MiningSettingsFileName;
                        string argFileName195 = MiningSettingsFileName;
                        withBlock.CrystalTypeA = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName195, SettingTypes.TypeBoolean, MiningSettingsFileName, "CrystalTypeA", DefaultMiningCrystalType));
                        string argFileName196 = MiningSettingsFileName;
                        string argFileName197 = MiningSettingsFileName;
                        withBlock.CrystalTypeB = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName197, SettingTypes.TypeBoolean, MiningSettingsFileName, "CrystalTypeB", DefaultMiningCrystalType));
                        string argFileName198 = MiningSettingsFileName;
                        string argFileName199 = MiningSettingsFileName;
                        withBlock.CrystalTypeC = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName199, SettingTypes.TypeBoolean, MiningSettingsFileName, "CrystalTypeC", DefaultMiningCrystalType));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultMiningSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Mining Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultMiningSettings();
            }

            // Save them locally and then export
            MiningSettings = TempSettings;

            return TempSettings;

        }

        // Loads the Defaults for the tab
        public MiningTabSettings SetDefaultMiningSettings()
        {
            MiningTabSettings LocalSettings;

            LocalSettings.OreType = DefaultMiningOreType;
            LocalSettings.CheckHighYieldOres = DefaultMiningCheckHighYieldOres;
            LocalSettings.CheckHighSecOres = DefaultMiningCheckHighSecOres;
            LocalSettings.CheckLowSecOres = DefaultMiningCheckLowSecOres;
            LocalSettings.CheckNullSecOres = DefaultMiningCheckNullSecOres;
            LocalSettings.CheckA0Ores = DefaultMiningCheckA0Ores;
            LocalSettings.CheckSovAmarr = DefaultMiningCheckSovAmarr;
            LocalSettings.CheckSovCaldari = DefaultMiningCheckSovCaldari;
            LocalSettings.CheckSovGallente = DefaultMiningCheckSovGallente;
            LocalSettings.CheckSovMinmatar = DefaultMiningCheckSovMinmatar;
            LocalSettings.CheckSovTriglavian = DefaultMiningCheckSovTriglavian;
            LocalSettings.CheckEDENCOM = DefaultMiningCheckEDENCOM;
            LocalSettings.CheckSovWormhole = DefaultMiningCheckSovWormhole;
            LocalSettings.CheckSovMoon = DefaultMiningCheckSovMoon;
            LocalSettings.CheckSovC1 = DefaultMiningCheckSovC1;
            LocalSettings.CheckSovC2 = DefaultMiningCheckSovC2;
            LocalSettings.CheckSovC3 = DefaultMiningCheckSovC3;
            LocalSettings.CheckSovC4 = DefaultMiningCheckSovC4;
            LocalSettings.CheckSovC5 = DefaultMiningCheckSovC5;
            LocalSettings.CheckSovC6 = DefaultMiningCheckSovC6;
            LocalSettings.CheckIncludeFees = DefaultMiningCheckIncludeFees;
            LocalSettings.BrokerFeeRate = DefaultMiningBrokerFeeRate;
            LocalSettings.CheckIncludeTaxes = DefaultMiningCheckIncludeTaxes;
            LocalSettings.OreMiningShip = DefaultMiningMiningShip;
            LocalSettings.IceMiningShip = DefaultMiningIceMiningShip;
            LocalSettings.GasMiningShip = DefaultMiningGasMiningShip;
            LocalSettings.OreStrip = DefaultMiningOreStrip;
            LocalSettings.IceStrip = DefaultMiningIceStrip;
            LocalSettings.GasHarvester = DefaultMiningGasHarvester;
            LocalSettings.NumOreMiners = DefaultMiningNumOreMiners;
            LocalSettings.NumIceMiners = DefaultMiningNumIceMiners;
            LocalSettings.NumGasHarvesters = DefaultMiningNumGasHarvesters;
            LocalSettings.OreUpgrade = DefaultMiningOreUpgrade;
            LocalSettings.IceUpgrade = DefaultMiningIceUpgrade;
            LocalSettings.GasUpgrade = DefaultMiningGasUpgrade;
            LocalSettings.NumOreUpgrades = DefaultMiningNumOreUpgrades;
            LocalSettings.NumIceUpgrades = DefaultMiningNumIceUpgrades;
            LocalSettings.NumGasUpgrades = DefaultMiningNumGasUpgrades;
            LocalSettings.MichiiImplant = DefaultMiningMichiiImplant;
            LocalSettings.T1Crystals = DefaultMiningCrystals;
            LocalSettings.T2Crystals = DefaultMiningCrystals;
            LocalSettings.CrystalTypeA = DefaultMiningCrystalType;
            LocalSettings.CrystalTypeB = DefaultMiningCrystalType;
            LocalSettings.CrystalTypeC = DefaultMiningCrystalType;
            LocalSettings.OreImplant = DefaultMiningOreImplant;
            LocalSettings.IceImplant = DefaultMiningIceImplant;
            LocalSettings.GasImplant = DefaultMiningGasImplant;
            LocalSettings.CheckUseHauler = DefaultMiningCheckUseHauler;
            LocalSettings.RoundTripMin = DefaultMiningRoundTripMin;
            LocalSettings.RoundTripSec = DefaultMiningRoundTripSec;
            LocalSettings.Haulerm3 = DefaultMiningHaulerm3;
            LocalSettings.CheckUseFleetBooster = DefaultMiningCheckUseFleetBooster;
            LocalSettings.BoosterShip = DefaultMiningBoosterShip;
            LocalSettings.BoosterShipSkill = DefaultMiningBoosterShipSkill;
            LocalSettings.MiningFormanSkill = DefaultMiningMiningFormanSkill;
            LocalSettings.MiningDirectorSkill = DefaultMiningMiningDirectorSkill;
            LocalSettings.CheckMineForemanLaserOpBoost = DefaultMiningCheckMineForemanLaserOpBoost;
            LocalSettings.CheckMineForemanLaserRangeBoost = DefaultMiningCheckMineForemanLaserOpBoost;
            LocalSettings.CheckMiningForemanMindLink = DefaultMiningCheckMiningForemanMindLink;
            LocalSettings.CheckRorqDeployed = DefaultMiningRorqDeployed;
            LocalSettings.RefinedOre = DefaultMiningRefinedOre;
            LocalSettings.UnrefinedOre = DefaultMiningUnrefinedOre;
            LocalSettings.CompressedOre = DefaultMiningCompressedOre;
            LocalSettings.IndustrialReconfig = DefaultMiningIndustrialReconfig;
            LocalSettings.NumberofMiners = DefaultNumMiners;
            LocalSettings.ColumnSort = DefaultMiningColumnSort;
            LocalSettings.ColumnSortType = DefaultMiningColumnSortType;

            LocalSettings.MiningDrone = DefaultMiningDrone;
            LocalSettings.NumMiningDrones = DefaultNumMiningDrone;
            LocalSettings.IceMiningDrone = DefaultIceMiningDrone;
            LocalSettings.NumIceMiningDrones = DefaultNumIceMiningdrone;
            LocalSettings.DroneOpSkill = DefaultDroneSkills;
            LocalSettings.DroneSpecSkill = DefaultDroneSkills;
            LocalSettings.DroneInterfaceSkill = DefaultDroneSkills;
            LocalSettings.IceDroneOpSkill = DefaultDroneSkills;
            LocalSettings.IceDroneSpecSkill = DefaultDroneSkills;
            LocalSettings.IceDroneInterfaceSkill = DefaultDroneSkills;

            LocalSettings.BoosterMiningDrone = DefaultMiningDrone;
            LocalSettings.BoosterNumMiningDrones = DefaultNumMiningDrone;
            LocalSettings.BoosterIceMiningDrone = DefaultIceMiningDrone;
            LocalSettings.BoosterNumIceMiningDrones = DefaultNumIceMiningdrone;
            LocalSettings.BoosterDroneOpSkill = DefaultDroneSkills;
            LocalSettings.BoosterDroneSpecSkill = DefaultDroneSkills;
            LocalSettings.BoosterDroneInterfaceSkill = DefaultDroneSkills;
            LocalSettings.BoosterIceDroneOpSkill = DefaultDroneSkills;
            LocalSettings.BoosterIceDroneSpecSkill = DefaultDroneSkills;
            LocalSettings.BoosterIceDroneInterfaceSkill = DefaultDroneSkills;

            LocalSettings.BoosterUseDrones = DefaultBoosterUseDrones;
            LocalSettings.ShipDroneRig1 = DefaultDroneRigs;
            LocalSettings.ShipDroneRig2 = DefaultDroneRigs;
            LocalSettings.ShipDroneRig3 = DefaultDroneRigs;
            LocalSettings.BoosterDroneRig1 = DefaultBoosterDroneRigs;
            LocalSettings.BoosterDroneRig2 = DefaultBoosterDroneRigs;
            LocalSettings.BoosterDroneRig3 = DefaultBoosterDroneRigs;
            LocalSettings.ShipIceDroneRig1 = DefaultDroneRigs;
            LocalSettings.ShipIceDroneRig2 = DefaultDroneRigs;
            LocalSettings.ShipIceDroneRig3 = DefaultDroneRigs;
            LocalSettings.BoosterIceDroneRig1 = DefaultBoosterDroneRigs;
            LocalSettings.BoosterIceDroneRig2 = DefaultBoosterDroneRigs;

            LocalSettings.BoosterIceDroneRig3 = DefaultBoosterDroneRigs;

            // Save locally
            MiningSettings = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveMiningSettings(MiningTabSettings SentSettings)
        {
            var MiningSettingsList = new Setting[100];

            try
            {
                MiningSettingsList[0] = new Setting("OreType", SentSettings.OreType);
                MiningSettingsList[1] = new Setting("CheckHighYieldOres", Conversions.ToString(SentSettings.CheckHighYieldOres));
                MiningSettingsList[2] = new Setting("CheckHighSecOres", Conversions.ToString(SentSettings.CheckHighSecOres));
                MiningSettingsList[3] = new Setting("CheckLowSecOres", Conversions.ToString(SentSettings.CheckLowSecOres));
                MiningSettingsList[4] = new Setting("CheckNullSecOres", Conversions.ToString(SentSettings.CheckNullSecOres));
                MiningSettingsList[5] = new Setting("CheckSovAmarr", Conversions.ToString(SentSettings.CheckSovAmarr));
                MiningSettingsList[6] = new Setting("CheckSovCaldari", Conversions.ToString(SentSettings.CheckSovCaldari));
                MiningSettingsList[7] = new Setting("CheckSovGallente", Conversions.ToString(SentSettings.CheckSovGallente));
                MiningSettingsList[8] = new Setting("CheckSovMinmatar", Conversions.ToString(SentSettings.CheckSovMinmatar));
                MiningSettingsList[9] = new Setting("CheckIncludeFees", Conversions.ToString(SentSettings.CheckIncludeFees));
                MiningSettingsList[10] = new Setting("CheckIncludeTaxes", Conversions.ToString(SentSettings.CheckIncludeTaxes));
                MiningSettingsList[11] = new Setting("OreMiningShip", SentSettings.OreMiningShip);
                MiningSettingsList[12] = new Setting("IceMiningShip", SentSettings.IceMiningShip);
                MiningSettingsList[13] = new Setting("OreStrip", SentSettings.OreStrip);
                MiningSettingsList[14] = new Setting("IceStrip", SentSettings.IceStrip);
                MiningSettingsList[15] = new Setting("NumOreMiners", SentSettings.NumOreMiners.ToString());
                MiningSettingsList[16] = new Setting("NumIceMiners", SentSettings.NumIceMiners.ToString());
                MiningSettingsList[17] = new Setting("OreUpgrade", SentSettings.OreUpgrade);
                MiningSettingsList[18] = new Setting("IceUpgrade", SentSettings.IceUpgrade);
                MiningSettingsList[19] = new Setting("NumOreUpgrades", SentSettings.NumOreUpgrades.ToString());
                MiningSettingsList[20] = new Setting("NumIceUpgrades", SentSettings.NumIceUpgrades.ToString());
                MiningSettingsList[21] = new Setting("MichiiImplant", Conversions.ToString(SentSettings.MichiiImplant));
                MiningSettingsList[22] = new Setting("T2Crystals", Conversions.ToString(SentSettings.T2Crystals));
                MiningSettingsList[23] = new Setting("OreImplant", SentSettings.OreImplant);
                MiningSettingsList[24] = new Setting("IceImplant", SentSettings.IceImplant);
                MiningSettingsList[25] = new Setting("CheckUseHauler", Conversions.ToString(SentSettings.CheckUseHauler));
                MiningSettingsList[26] = new Setting("RoundTripMin", SentSettings.RoundTripMin.ToString());
                MiningSettingsList[27] = new Setting("RoundTripSec", SentSettings.RoundTripSec.ToString());
                MiningSettingsList[28] = new Setting("Haulerm3", SentSettings.Haulerm3.ToString());
                MiningSettingsList[29] = new Setting("CheckUseFleetBooster", Conversions.ToString(SentSettings.CheckUseFleetBooster));
                MiningSettingsList[30] = new Setting("BoosterShip", SentSettings.BoosterShip);
                MiningSettingsList[31] = new Setting("BoosterShipSkill", SentSettings.BoosterShipSkill.ToString());
                MiningSettingsList[32] = new Setting("MiningFormanSkill", SentSettings.MiningFormanSkill.ToString());
                MiningSettingsList[33] = new Setting("MiningDirectorSkill", SentSettings.MiningDirectorSkill.ToString());
                MiningSettingsList[34] = new Setting("CheckMineForemanLaserOpBoost", SentSettings.CheckMineForemanLaserOpBoost.ToString());
                MiningSettingsList[35] = new Setting("CheckMiningForemanMindLink", Conversions.ToString(SentSettings.CheckMiningForemanMindLink));
                MiningSettingsList[36] = new Setting("CheckRorqDeployed", SentSettings.CheckRorqDeployed.ToString());
                MiningSettingsList[37] = new Setting("RefinedOre", Conversions.ToString(SentSettings.RefinedOre));
                MiningSettingsList[38] = new Setting("IndustrialReconfig", SentSettings.IndustrialReconfig.ToString());
                MiningSettingsList[39] = new Setting("CheckMineForemanLaserRangeBoost", SentSettings.CheckMineForemanLaserRangeBoost.ToString());
                MiningSettingsList[40] = new Setting("GasMiningShip", SentSettings.GasMiningShip);
                MiningSettingsList[41] = new Setting("GasHarvester", SentSettings.GasHarvester);
                MiningSettingsList[42] = new Setting("NumGasHarvesters", SentSettings.NumGasHarvesters.ToString());
                MiningSettingsList[43] = new Setting("GasUpgrade", SentSettings.GasUpgrade);
                MiningSettingsList[44] = new Setting("NumGasUpgrades", SentSettings.NumGasUpgrades.ToString());
                MiningSettingsList[45] = new Setting("GasImplant", SentSettings.GasImplant);
                MiningSettingsList[46] = new Setting("CheckSovWormhole", Conversions.ToString(SentSettings.CheckSovWormhole));
                MiningSettingsList[47] = new Setting("CheckSovC1", Conversions.ToString(SentSettings.CheckSovC1));
                MiningSettingsList[48] = new Setting("CheckSovC2", Conversions.ToString(SentSettings.CheckSovC2));
                MiningSettingsList[49] = new Setting("CheckSovC3", Conversions.ToString(SentSettings.CheckSovC3));
                MiningSettingsList[50] = new Setting("CheckSovC4", Conversions.ToString(SentSettings.CheckSovC4));
                MiningSettingsList[51] = new Setting("CheckSovC5", Conversions.ToString(SentSettings.CheckSovC5));
                MiningSettingsList[52] = new Setting("CheckSovC6", Conversions.ToString(SentSettings.CheckSovC6));
                MiningSettingsList[53] = new Setting("CompressedOre", Conversions.ToString(SentSettings.CompressedOre));
                MiningSettingsList[54] = new Setting("UnrefinedOre", Conversions.ToString(SentSettings.UnrefinedOre));
                MiningSettingsList[55] = new Setting("NumberofMiners", SentSettings.NumberofMiners.ToString());

                MiningSettingsList[56] = new Setting("ColumnSort", SentSettings.ColumnSort.ToString());
                MiningSettingsList[57] = new Setting("ColumnSortType", SentSettings.ColumnSortType);

                MiningSettingsList[58] = new Setting("CheckSovMoon", Conversions.ToString(SentSettings.CheckSovMoon));
                MiningSettingsList[59] = new Setting("BrokerFeeRate", SentSettings.BrokerFeeRate.ToString());
                MiningSettingsList[60] = new Setting("CheckSovTriglavian", Conversions.ToString(SentSettings.CheckSovTriglavian));

                MiningSettingsList[61] = new Setting("MiningDrone", SentSettings.MiningDrone);
                MiningSettingsList[62] = new Setting("NumMiningDrones", SentSettings.NumMiningDrones);
                MiningSettingsList[63] = new Setting("IceMiningDrone", SentSettings.IceMiningDrone);
                MiningSettingsList[64] = new Setting("NumIceMiningDrones", SentSettings.NumIceMiningDrones);
                MiningSettingsList[65] = new Setting("DroneOpSkill", SentSettings.DroneOpSkill);
                MiningSettingsList[66] = new Setting("DroneSpecSkill", SentSettings.DroneSpecSkill);
                MiningSettingsList[67] = new Setting("DroneInterfaceSkill", SentSettings.DroneInterfaceSkill);

                MiningSettingsList[68] = new Setting("BoosterMiningDrone", SentSettings.BoosterMiningDrone);
                MiningSettingsList[69] = new Setting("BoosterNumMiningDrones", SentSettings.BoosterNumMiningDrones);
                MiningSettingsList[70] = new Setting("BoosterIceMiningDrone", SentSettings.BoosterIceMiningDrone);
                MiningSettingsList[71] = new Setting("BoosterNumIceMiningDrones", SentSettings.BoosterNumIceMiningDrones);
                MiningSettingsList[72] = new Setting("BoosterDroneOpSkill", SentSettings.BoosterDroneOpSkill);
                MiningSettingsList[73] = new Setting("BoosterDroneSpecSkill", SentSettings.BoosterDroneSpecSkill);
                MiningSettingsList[74] = new Setting("BoosterDroneInterfaceSkill", SentSettings.BoosterDroneInterfaceSkill);

                MiningSettingsList[75] = new Setting("BoosterUseDrones", Conversions.ToString(SentSettings.BoosterUseDrones));
                MiningSettingsList[76] = new Setting("ShipDroneRig1", SentSettings.ShipDroneRig1);
                MiningSettingsList[77] = new Setting("ShipDroneRig2", SentSettings.ShipDroneRig2);
                MiningSettingsList[78] = new Setting("ShipDroneRig3", SentSettings.ShipDroneRig3);
                MiningSettingsList[79] = new Setting("BoosterDroneRig1", SentSettings.BoosterDroneRig1.ToString());
                MiningSettingsList[80] = new Setting("BoosterDroneRig2", SentSettings.BoosterDroneRig2.ToString());
                MiningSettingsList[81] = new Setting("BoosterDroneRig3", SentSettings.BoosterDroneRig3.ToString());

                MiningSettingsList[82] = new Setting("ShipIceDroneRig1", SentSettings.ShipIceDroneRig1);
                MiningSettingsList[83] = new Setting("ShipIceDroneRig2", SentSettings.ShipIceDroneRig2);
                MiningSettingsList[84] = new Setting("ShipIceDroneRig3", SentSettings.ShipIceDroneRig3);
                MiningSettingsList[85] = new Setting("BoosterIceDroneRig1", SentSettings.BoosterIceDroneRig1.ToString());
                MiningSettingsList[86] = new Setting("BoosterIceDroneRig2", SentSettings.BoosterIceDroneRig2.ToString());
                MiningSettingsList[87] = new Setting("BoosterIceDroneRig3", SentSettings.BoosterIceDroneRig3.ToString());

                MiningSettingsList[88] = new Setting("IceDroneOpSkill", SentSettings.IceDroneOpSkill);
                MiningSettingsList[89] = new Setting("IceDroneSpecSkill", SentSettings.IceDroneSpecSkill);
                MiningSettingsList[90] = new Setting("IceDroneInterfaceSkill", SentSettings.IceDroneInterfaceSkill);
                MiningSettingsList[91] = new Setting("BoosterIceDroneOpSkill", SentSettings.BoosterIceDroneOpSkill);
                MiningSettingsList[92] = new Setting("BoosterIceDroneSpecSkill", SentSettings.BoosterIceDroneSpecSkill);
                MiningSettingsList[93] = new Setting("BoosterIceDroneInterfaceSkill", SentSettings.BoosterIceDroneInterfaceSkill);

                MiningSettingsList[94] = new Setting("T1Crystals", Conversions.ToString(SentSettings.T1Crystals));

                MiningSettingsList[95] = new Setting("CrystalTypeA", Conversions.ToString(SentSettings.CrystalTypeA));
                MiningSettingsList[96] = new Setting("CrystalTypeB", Conversions.ToString(SentSettings.CrystalTypeB));
                MiningSettingsList[97] = new Setting("CrystalTypeC", Conversions.ToString(SentSettings.CrystalTypeC));

                MiningSettingsList[98] = new Setting("CheckEDENCOM", Conversions.ToString(SentSettings.CheckEDENCOM));
                MiningSettingsList[99] = new Setting("CheckA0Ores", Conversions.ToString(SentSettings.CheckA0Ores));

                WriteSettingsToFile(Public_Variables.SettingsFolder, MiningSettingsFileName, MiningSettingsList, MiningSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Mining Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public MiningTabSettings GetMiningSettings()
        {
            return MiningSettings;
        }

        #endregion

        #region Industry Jobs Column Settings

        // Loads the tab settings
        public IndustryJobsColumnSettings LoadIndustryJobsColumnSettings()
        {
            IndustryJobsColumnSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, IndustryJobsColumnSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = IndustryJobsColumnSettingsFileName;
                        string argFileName1 = IndustryJobsColumnSettingsFileName;
                        withBlock.JobState = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "JobState", DefaultJobState));
                        string argFileName2 = IndustryJobsColumnSettingsFileName;
                        string argFileName3 = IndustryJobsColumnSettingsFileName;
                        withBlock.InstallerName = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallerName", DefaultInstallerName));
                        string argFileName4 = IndustryJobsColumnSettingsFileName;
                        string argFileName5 = IndustryJobsColumnSettingsFileName;
                        withBlock.TimeToComplete = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "TimeToComplete", DefaultTimeToComplete));
                        string argFileName6 = IndustryJobsColumnSettingsFileName;
                        string argFileName7 = IndustryJobsColumnSettingsFileName;
                        withBlock.Activity = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "Activity", DefaultActivity));
                        string argFileName8 = IndustryJobsColumnSettingsFileName;
                        string argFileName9 = IndustryJobsColumnSettingsFileName;
                        withBlock.Status = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "Status", DefaultStatus));
                        string argFileName10 = IndustryJobsColumnSettingsFileName;
                        string argFileName11 = IndustryJobsColumnSettingsFileName;
                        withBlock.StartTime = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "StartTime", DefaultStartTime));
                        string argFileName12 = IndustryJobsColumnSettingsFileName;
                        string argFileName13 = IndustryJobsColumnSettingsFileName;
                        withBlock.EndTime = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "EndTime", DefaultEndTime));
                        string argFileName14 = IndustryJobsColumnSettingsFileName;
                        string argFileName15 = IndustryJobsColumnSettingsFileName;
                        withBlock.CompletionTime = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "CompletionTime", DefaultCompletionTime));
                        string argFileName16 = IndustryJobsColumnSettingsFileName;
                        string argFileName17 = IndustryJobsColumnSettingsFileName;
                        withBlock.Blueprint = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "Blueprint", DefaultBlueprint));
                        string argFileName18 = IndustryJobsColumnSettingsFileName;
                        string argFileName19 = IndustryJobsColumnSettingsFileName;
                        withBlock.OutputItem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputItem", DefaultOutputItem));
                        string argFileName20 = IndustryJobsColumnSettingsFileName;
                        string argFileName21 = IndustryJobsColumnSettingsFileName;
                        withBlock.OutputItemType = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputItemType", DefaultOutputItemType));
                        string argFileName22 = IndustryJobsColumnSettingsFileName;
                        string argFileName23 = IndustryJobsColumnSettingsFileName;
                        withBlock.InstallSystem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallSystem", DefaultInstallSolarSystem));
                        string argFileName24 = IndustryJobsColumnSettingsFileName;
                        string argFileName25 = IndustryJobsColumnSettingsFileName;
                        withBlock.InstallRegion = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallRegion", DefaultInstallRegion));
                        string argFileName26 = IndustryJobsColumnSettingsFileName;
                        string argFileName27 = IndustryJobsColumnSettingsFileName;
                        withBlock.LicensedRuns = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "LicensedRuns", DefaultLicensedRuns));
                        string argFileName28 = IndustryJobsColumnSettingsFileName;
                        string argFileName29 = IndustryJobsColumnSettingsFileName;
                        withBlock.Runs = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "Runs", DefaultRuns));
                        string argFileName30 = IndustryJobsColumnSettingsFileName;
                        string argFileName31 = IndustryJobsColumnSettingsFileName;
                        withBlock.SuccessfulRuns = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "SuccessfulRuns", DefaultSuccessfulRuns));
                        string argFileName32 = IndustryJobsColumnSettingsFileName;
                        string argFileName33 = IndustryJobsColumnSettingsFileName;
                        withBlock.BlueprintLocation = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "BlueprintLocation", DefaultBlueprintLocation));
                        string argFileName34 = IndustryJobsColumnSettingsFileName;
                        string argFileName35 = IndustryJobsColumnSettingsFileName;
                        withBlock.OutputLocation = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputLocation", DefaultOutputLocation));
                        string argFileName36 = IndustryJobsColumnSettingsFileName;
                        string argFileName37 = IndustryJobsColumnSettingsFileName;
                        withBlock.JobType = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "JobType", DefaultJobType));
                        string argFileName38 = IndustryJobsColumnSettingsFileName;
                        string argFileName39 = IndustryJobsColumnSettingsFileName;
                        withBlock.LocalCompletionDateTime = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "LocalCompletionDateTime", DefaultLocalCompletionDateTime));

                        string argFileName40 = IndustryJobsColumnSettingsFileName;
                        string argFileName41 = IndustryJobsColumnSettingsFileName;
                        withBlock.JobStateWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "JobStateWidth", DefaultIndustryColumnWidth));
                        string argFileName42 = IndustryJobsColumnSettingsFileName;
                        string argFileName43 = IndustryJobsColumnSettingsFileName;
                        withBlock.InstallerNameWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallerNameWidth", DefaultIndustryColumnWidth));
                        string argFileName44 = IndustryJobsColumnSettingsFileName;
                        string argFileName45 = IndustryJobsColumnSettingsFileName;
                        withBlock.TimeToCompleteWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName45, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "TimeToCompleteWidth", DefaultIndustryColumnWidth));
                        string argFileName46 = IndustryJobsColumnSettingsFileName;
                        string argFileName47 = IndustryJobsColumnSettingsFileName;
                        withBlock.ActivityWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName47, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "ActivityWidth", DefaultIndustryColumnWidth));
                        string argFileName48 = IndustryJobsColumnSettingsFileName;
                        string argFileName49 = IndustryJobsColumnSettingsFileName;
                        withBlock.StatusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName49, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "StatusWidth", DefaultIndustryColumnWidth));
                        string argFileName50 = IndustryJobsColumnSettingsFileName;
                        string argFileName51 = IndustryJobsColumnSettingsFileName;
                        withBlock.StartTimeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName51, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "StartTimewidth", DefaultIndustryColumnWidth));
                        string argFileName52 = IndustryJobsColumnSettingsFileName;
                        string argFileName53 = IndustryJobsColumnSettingsFileName;
                        withBlock.EndTimeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName53, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "EndTimeWidth", DefaultIndustryColumnWidth));
                        string argFileName54 = IndustryJobsColumnSettingsFileName;
                        string argFileName55 = IndustryJobsColumnSettingsFileName;
                        withBlock.CompletionTimeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName55, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "CompletionTimeWidth", DefaultIndustryColumnWidth));
                        string argFileName56 = IndustryJobsColumnSettingsFileName;
                        string argFileName57 = IndustryJobsColumnSettingsFileName;
                        withBlock.BlueprintWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName57, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "BlueprintWidth", DefaultIndustryColumnWidth));
                        string argFileName58 = IndustryJobsColumnSettingsFileName;
                        string argFileName59 = IndustryJobsColumnSettingsFileName;
                        withBlock.OutputItemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName59, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputItemWidth", DefaultIndustryColumnWidth));
                        string argFileName60 = IndustryJobsColumnSettingsFileName;
                        string argFileName61 = IndustryJobsColumnSettingsFileName;
                        withBlock.OutputItemTypeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName61, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputItemTypeWidth", DefaultIndustryColumnWidth));
                        string argFileName62 = IndustryJobsColumnSettingsFileName;
                        string argFileName63 = IndustryJobsColumnSettingsFileName;
                        withBlock.InstallSystemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName63, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallSystemWidth", DefaultIndustryColumnWidth));
                        string argFileName64 = IndustryJobsColumnSettingsFileName;
                        string argFileName65 = IndustryJobsColumnSettingsFileName;
                        withBlock.InstallRegionWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName65, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "InstallRegionWidth", DefaultIndustryColumnWidth));
                        string argFileName66 = IndustryJobsColumnSettingsFileName;
                        string argFileName67 = IndustryJobsColumnSettingsFileName;
                        withBlock.LicensedRunsWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName67, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "LiscencedRunsWidth", DefaultIndustryColumnWidth));
                        string argFileName68 = IndustryJobsColumnSettingsFileName;
                        string argFileName69 = IndustryJobsColumnSettingsFileName;
                        withBlock.RunsWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName69, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "RunsWidth", DefaultIndustryColumnWidth));
                        string argFileName70 = IndustryJobsColumnSettingsFileName;
                        string argFileName71 = IndustryJobsColumnSettingsFileName;
                        withBlock.SuccessfulRunsWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName71, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "SuccessfulRunsWidth", DefaultIndustryColumnWidth));
                        string argFileName72 = IndustryJobsColumnSettingsFileName;
                        string argFileName73 = IndustryJobsColumnSettingsFileName;
                        withBlock.BlueprintLocationWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName73, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "BlueprintLocationWidth", DefaultIndustryColumnWidth));
                        string argFileName74 = IndustryJobsColumnSettingsFileName;
                        string argFileName75 = IndustryJobsColumnSettingsFileName;
                        withBlock.OutputLocationWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName75, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OutputLocationWidth", DefaultIndustryColumnWidth));
                        string argFileName76 = IndustryJobsColumnSettingsFileName;
                        string argFileName77 = IndustryJobsColumnSettingsFileName;
                        withBlock.JobTypeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName77, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "JobTypeWidth", DefaultIndustryColumnWidth));
                        string argFileName78 = IndustryJobsColumnSettingsFileName;
                        string argFileName79 = IndustryJobsColumnSettingsFileName;
                        withBlock.LocalCompletionDateTimeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName79, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "LocalCompletionDateTimeWidth", DefaultIndustryColumnWidth));

                        string argFileName80 = IndustryJobsColumnSettingsFileName;
                        string argFileName81 = IndustryJobsColumnSettingsFileName;
                        withBlock.OrderByColumn = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName81, SettingTypes.TypeInteger, IndustryJobsColumnSettingsFileName, "OrderByColumn", DefaultOrderByColumn));
                        string argFileName82 = IndustryJobsColumnSettingsFileName;
                        string argFileName83 = IndustryJobsColumnSettingsFileName;
                        withBlock.ViewJobType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName83, SettingTypes.TypeString, IndustryJobsColumnSettingsFileName, "ViewJobType", DefaultViewJobType));
                        string argFileName84 = IndustryJobsColumnSettingsFileName;
                        string argFileName85 = IndustryJobsColumnSettingsFileName;
                        withBlock.OrderType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName85, SettingTypes.TypeString, IndustryJobsColumnSettingsFileName, "OrderType", DefaultOrderType));
                        string argFileName86 = IndustryJobsColumnSettingsFileName;
                        string argFileName87 = IndustryJobsColumnSettingsFileName;
                        withBlock.JobTimes = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName87, SettingTypes.TypeString, IndustryJobsColumnSettingsFileName, "JobTimes", DefaultJobTimes));
                        string argFileName88 = IndustryJobsColumnSettingsFileName;
                        string argFileName89 = IndustryJobsColumnSettingsFileName;
                        withBlock.SelectedCharacterIDs = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName89, SettingTypes.TypeString, IndustryJobsColumnSettingsFileName, "SelectedCharacterIDs", DefaultSelectedCharacterIDs));
                        string argFileName90 = IndustryJobsColumnSettingsFileName;
                        string argFileName91 = IndustryJobsColumnSettingsFileName;
                        withBlock.AutoUpdateJobs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName91, SettingTypes.TypeBoolean, IndustryJobsColumnSettingsFileName, "AutoUpdateJobs", DefaultAutoUpdateJobs));

                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultIndustryJobsColumnSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Industry Jobs Column Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultIndustryJobsColumnSettings();
            }

            // Save them locally and then export
            IndustryJobsColumnSettings = TempSettings;

            return TempSettings;

        }

        // Loads the Defaults for the tab
        public IndustryJobsColumnSettings SetDefaultIndustryJobsColumnSettings()
        {
            IndustryJobsColumnSettings LocalSettings;

            LocalSettings.JobState = DefaultJobState;
            LocalSettings.InstallerName = DefaultInstallerName;
            LocalSettings.TimeToComplete = DefaultTimeToComplete;
            LocalSettings.Activity = DefaultActivity;
            LocalSettings.Status = DefaultStatus;
            LocalSettings.StartTime = DefaultStartTime;
            LocalSettings.EndTime = DefaultEndTime;
            LocalSettings.CompletionTime = DefaultCompletionTime;
            LocalSettings.Blueprint = DefaultBlueprint;
            LocalSettings.OutputItem = DefaultOutputItem;
            LocalSettings.OutputItemType = DefaultOutputItemType;
            LocalSettings.InstallSystem = DefaultInstallSolarSystem;
            LocalSettings.InstallRegion = DefaultInstallRegion;
            LocalSettings.LicensedRuns = DefaultLicensedRuns;
            LocalSettings.Runs = DefaultRuns;
            LocalSettings.BlueprintLocation = DefaultBlueprintLocation;
            LocalSettings.SuccessfulRuns = DefaultSuccessfulRuns;
            LocalSettings.OutputLocation = DefaultOutputLocation;
            LocalSettings.JobType = DefaultJobType;
            LocalSettings.LocalCompletionDateTime = DefaultLocalCompletionDateTime;

            LocalSettings.JobStateWidth = DefaultIndustryColumnWidth;
            LocalSettings.InstallerNameWidth = DefaultIndustryColumnWidth;
            LocalSettings.TimeToCompleteWidth = DefaultIndustryColumnWidth;
            LocalSettings.ActivityWidth = DefaultIndustryColumnWidth;
            LocalSettings.StatusWidth = DefaultIndustryColumnWidth;
            LocalSettings.StartTimeWidth = DefaultIndustryColumnWidth;
            LocalSettings.EndTimeWidth = DefaultIndustryColumnWidth;
            LocalSettings.CompletionTimeWidth = DefaultIndustryColumnWidth;
            LocalSettings.BlueprintWidth = DefaultIndustryColumnWidth;
            LocalSettings.OutputItemWidth = DefaultIndustryColumnWidth;
            LocalSettings.OutputItemTypeWidth = DefaultIndustryColumnWidth;
            LocalSettings.InstallSystemWidth = DefaultIndustryColumnWidth;
            LocalSettings.InstallRegionWidth = DefaultIndustryColumnWidth;
            LocalSettings.LicensedRunsWidth = DefaultIndustryColumnWidth;
            LocalSettings.RunsWidth = DefaultIndustryColumnWidth;
            LocalSettings.SuccessfulRunsWidth = DefaultIndustryColumnWidth;
            LocalSettings.BlueprintLocationWidth = DefaultIndustryColumnWidth;
            LocalSettings.OutputLocationWidth = DefaultIndustryColumnWidth;
            LocalSettings.JobTypeWidth = DefaultIndustryColumnWidth;
            LocalSettings.LocalCompletionDateTimeWidth = DefaultIndustryColumnWidth;

            LocalSettings.OrderByColumn = DefaultOrderByColumn;
            LocalSettings.OrderType = DefaultOrderType;
            LocalSettings.ViewJobType = DefaultViewJobType;
            LocalSettings.JobTimes = DefaultJobTimes;

            LocalSettings.SelectedCharacterIDs = DefaultSelectedCharacterIDs;


            LocalSettings.AutoUpdateJobs = DefaultAutoUpdateJobs;

            // Save locally
            IndustryJobsColumnSettings = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveIndustryJobsColumnSettings(IndustryJobsColumnSettings SentSettings)
        {
            var IndustryJobsColumnSettingsList = new Setting[46];

            try
            {
                IndustryJobsColumnSettingsList[0] = new Setting("JobState", SentSettings.JobState.ToString());
                IndustryJobsColumnSettingsList[1] = new Setting("TimeToComplete", SentSettings.TimeToComplete.ToString());
                IndustryJobsColumnSettingsList[2] = new Setting("Activity", SentSettings.Activity.ToString());
                IndustryJobsColumnSettingsList[3] = new Setting("Status", SentSettings.Status.ToString());
                IndustryJobsColumnSettingsList[4] = new Setting("StartTime", SentSettings.StartTime.ToString());
                IndustryJobsColumnSettingsList[5] = new Setting("EndTime", SentSettings.EndTime.ToString());
                IndustryJobsColumnSettingsList[6] = new Setting("CompletionTime", SentSettings.CompletionTime.ToString());
                IndustryJobsColumnSettingsList[7] = new Setting("Blueprint", SentSettings.Blueprint.ToString());
                IndustryJobsColumnSettingsList[8] = new Setting("OutputItem", SentSettings.OutputItem.ToString());
                IndustryJobsColumnSettingsList[9] = new Setting("OutputItemType", SentSettings.OutputItemType.ToString());
                IndustryJobsColumnSettingsList[10] = new Setting("InstallSystem", SentSettings.InstallSystem.ToString());
                IndustryJobsColumnSettingsList[11] = new Setting("InstallRegion", SentSettings.InstallRegion.ToString());
                IndustryJobsColumnSettingsList[12] = new Setting("LicensedRuns", SentSettings.LicensedRuns.ToString());
                IndustryJobsColumnSettingsList[13] = new Setting("Runs", SentSettings.Runs.ToString());
                IndustryJobsColumnSettingsList[14] = new Setting("SuccessfulRuns", SentSettings.SuccessfulRuns.ToString());
                IndustryJobsColumnSettingsList[15] = new Setting("BlueprintLocation", SentSettings.BlueprintLocation.ToString());
                IndustryJobsColumnSettingsList[16] = new Setting("OutputLocation", SentSettings.OutputLocation.ToString());

                IndustryJobsColumnSettingsList[17] = new Setting("JobStateWidth", SentSettings.JobStateWidth.ToString());
                IndustryJobsColumnSettingsList[18] = new Setting("TimeToCompleteWidth", SentSettings.TimeToCompleteWidth.ToString());
                IndustryJobsColumnSettingsList[19] = new Setting("ActivityWidth", SentSettings.ActivityWidth.ToString());
                IndustryJobsColumnSettingsList[20] = new Setting("StatusWidth", SentSettings.StatusWidth.ToString());
                IndustryJobsColumnSettingsList[21] = new Setting("StartTimeWidth", SentSettings.StartTimeWidth.ToString());
                IndustryJobsColumnSettingsList[22] = new Setting("EndTimeWidth", SentSettings.EndTimeWidth.ToString());
                IndustryJobsColumnSettingsList[23] = new Setting("CompletionTimeWidth", SentSettings.CompletionTimeWidth.ToString());
                IndustryJobsColumnSettingsList[24] = new Setting("BlueprintWidth", SentSettings.BlueprintWidth.ToString());
                IndustryJobsColumnSettingsList[25] = new Setting("OutputItemWidth", SentSettings.OutputItemWidth.ToString());
                IndustryJobsColumnSettingsList[26] = new Setting("OutputItemTypeWidth", SentSettings.OutputItemTypeWidth.ToString());
                IndustryJobsColumnSettingsList[27] = new Setting("InstallSystemWidth", SentSettings.InstallSystemWidth.ToString());
                IndustryJobsColumnSettingsList[28] = new Setting("InstallRegionWidth", SentSettings.InstallRegionWidth.ToString());
                IndustryJobsColumnSettingsList[29] = new Setting("LicensedRunsWidth", SentSettings.LicensedRunsWidth.ToString());
                IndustryJobsColumnSettingsList[30] = new Setting("RunsWidth", SentSettings.RunsWidth.ToString());
                IndustryJobsColumnSettingsList[31] = new Setting("SuccessfulRunsWidth", SentSettings.SuccessfulRunsWidth.ToString());
                IndustryJobsColumnSettingsList[32] = new Setting("BlueprintLocationWidth", SentSettings.BlueprintLocationWidth.ToString());
                IndustryJobsColumnSettingsList[33] = new Setting("OutputLocationWidth", SentSettings.OutputLocationWidth.ToString());

                IndustryJobsColumnSettingsList[34] = new Setting("OrderByColumn", SentSettings.OrderByColumn.ToString());
                IndustryJobsColumnSettingsList[35] = new Setting("ViewJobType", SentSettings.ViewJobType);
                IndustryJobsColumnSettingsList[36] = new Setting("OrderType", SentSettings.OrderType);
                IndustryJobsColumnSettingsList[37] = new Setting("JobTimes", SentSettings.JobTimes);
                IndustryJobsColumnSettingsList[38] = new Setting("SelectedCharacterIDs", SentSettings.SelectedCharacterIDs);

                IndustryJobsColumnSettingsList[39] = new Setting("InstallerName", SentSettings.InstallerName.ToString());
                IndustryJobsColumnSettingsList[40] = new Setting("InstallerNameWidth", SentSettings.InstallerNameWidth.ToString());

                IndustryJobsColumnSettingsList[41] = new Setting("JobType", SentSettings.JobType.ToString());
                IndustryJobsColumnSettingsList[42] = new Setting("JobTypeWidth", SentSettings.JobTypeWidth.ToString());

                IndustryJobsColumnSettingsList[43] = new Setting("AutoUpdateJobs", Conversions.ToString(SentSettings.AutoUpdateJobs));

                IndustryJobsColumnSettingsList[44] = new Setting("LocalCompletionDateTime", SentSettings.LocalCompletionDateTime.ToString());
                IndustryJobsColumnSettingsList[45] = new Setting("LocalCompletionDateTimeWidth", SentSettings.LocalCompletionDateTimeWidth.ToString());

                WriteSettingsToFile(Public_Variables.SettingsFolder, IndustryJobsColumnSettingsFileName, IndustryJobsColumnSettingsList, IndustryJobsColumnSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Industry Jobs Column Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public IndustryJobsColumnSettings GetIndustryJobsColumnSettings()
        {
            return IndustryJobsColumnSettings;
        }

        #endregion

        #region Manufacturing Tab Column Settings

        // Loads the tab settings
        public ManufacturingTabColumnSettings LoadManufacturingTabColumnSettings()
        {
            ManufacturingTabColumnSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, ManufacturingTabColumnSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = ManufacturingTabColumnSettingsFileName;
                        string argFileName1 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemCategory = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemCategory", DefaultMTItemCategory));
                        string argFileName2 = ManufacturingTabColumnSettingsFileName;
                        string argFileName3 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemGroup = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemGroup", DefaultMTItemGroup));
                        string argFileName4 = ManufacturingTabColumnSettingsFileName;
                        string argFileName5 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemName = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemName", DefaultMTItemName));
                        string argFileName6 = ManufacturingTabColumnSettingsFileName;
                        string argFileName7 = ManufacturingTabColumnSettingsFileName;
                        withBlock.Owned = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Owned", DefaultMTOwned));
                        string argFileName8 = ManufacturingTabColumnSettingsFileName;
                        string argFileName9 = ManufacturingTabColumnSettingsFileName;
                        withBlock.Tech = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Tech", DefaultMTTech));
                        string argFileName10 = ManufacturingTabColumnSettingsFileName;
                        string argFileName11 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BPME = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPME", DefaultMTBPME));
                        string argFileName12 = ManufacturingTabColumnSettingsFileName;
                        string argFileName13 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BPTE = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPTE", DefaultMTBPTE));
                        string argFileName14 = ManufacturingTabColumnSettingsFileName;
                        string argFileName15 = ManufacturingTabColumnSettingsFileName;
                        withBlock.Inputs = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Inputs", DefaultMTInputs));
                        string argFileName16 = ManufacturingTabColumnSettingsFileName;
                        string argFileName17 = ManufacturingTabColumnSettingsFileName;
                        withBlock.Compared = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Compared", DefaultMTCompared));
                        string argFileName18 = ManufacturingTabColumnSettingsFileName;
                        string argFileName19 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalRuns = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalRuns", DefaultMTTotalRuns));
                        string argFileName20 = ManufacturingTabColumnSettingsFileName;
                        string argFileName21 = ManufacturingTabColumnSettingsFileName;
                        withBlock.SingleInventedBPCRuns = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SingleInventedBPCRuns", DefaultMTSingleInventedBPCRuns));
                        string argFileName22 = ManufacturingTabColumnSettingsFileName;
                        string argFileName23 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ProductionLines = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProductionLines", DefaultMTProductionLines));
                        string argFileName24 = ManufacturingTabColumnSettingsFileName;
                        string argFileName25 = ManufacturingTabColumnSettingsFileName;
                        withBlock.LaboratoryLines = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "LaboratoryLines", DefaultMTLaboratoryLines));
                        string argFileName26 = ManufacturingTabColumnSettingsFileName;
                        string argFileName27 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalInventionCost = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalInventionCost", DefaultMTTotalInventionCost));
                        string argFileName28 = ManufacturingTabColumnSettingsFileName;
                        string argFileName29 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalCopyCost = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalCopyCost", DefaultMTTotalCopyCost));
                        string argFileName30 = ManufacturingTabColumnSettingsFileName;
                        string argFileName31 = ManufacturingTabColumnSettingsFileName;
                        withBlock.Taxes = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Taxes", DefaultMTTaxes));
                        string argFileName32 = ManufacturingTabColumnSettingsFileName;
                        string argFileName33 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BrokerFees = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BrokerFees", DefaultMTBrokerFees));
                        string argFileName34 = ManufacturingTabColumnSettingsFileName;
                        string argFileName35 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BPProductionTime = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPProductionTime", DefaultMTBPProductionTime));
                        string argFileName36 = ManufacturingTabColumnSettingsFileName;
                        string argFileName37 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalProductionTime = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalProductionTime", DefaultMTTotalProductionTime));
                        string argFileName38 = ManufacturingTabColumnSettingsFileName;
                        string argFileName39 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyTime = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyTime", DefaultMTCopyTime));
                        string argFileName40 = ManufacturingTabColumnSettingsFileName;
                        string argFileName41 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionTime = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionTime", DefaultMTInventionTime));
                        string argFileName42 = ManufacturingTabColumnSettingsFileName;
                        string argFileName43 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemMarketPrice = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemMarketPrice", DefaultMTItemMarketPrice));
                        string argFileName44 = ManufacturingTabColumnSettingsFileName;
                        string argFileName45 = ManufacturingTabColumnSettingsFileName;
                        withBlock.Profit = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName45, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Profit", DefaultMTProfit));
                        string argFileName46 = ManufacturingTabColumnSettingsFileName;
                        string argFileName47 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ProfitPercentage = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName47, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProfitPercentage", DefaultMTProfitPercentage));
                        string argFileName48 = ManufacturingTabColumnSettingsFileName;
                        string argFileName49 = ManufacturingTabColumnSettingsFileName;
                        withBlock.IskperHour = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName49, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "IskperHour", DefaultMTIskperHour));
                        string argFileName50 = ManufacturingTabColumnSettingsFileName;
                        string argFileName51 = ManufacturingTabColumnSettingsFileName;
                        withBlock.SVR = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName51, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SVR", DefaultMTSVR));
                        string argFileName52 = ManufacturingTabColumnSettingsFileName;
                        string argFileName53 = ManufacturingTabColumnSettingsFileName;
                        withBlock.SVRxIPH = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName53, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SVRxIPH", DefaultMTSVRxIPH));
                        string argFileName54 = ManufacturingTabColumnSettingsFileName;
                        string argFileName55 = ManufacturingTabColumnSettingsFileName;
                        withBlock.PriceTrend = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName55, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "PriceTrend", DefaultMTPriceTrend));
                        string argFileName56 = ManufacturingTabColumnSettingsFileName;
                        string argFileName57 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalItemsSold = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName57, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalItemsSold", DefaultMTTotalItemsSold));
                        string argFileName58 = ManufacturingTabColumnSettingsFileName;
                        string argFileName59 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalOrdersFilled = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName59, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalOrdersFilled", DefaultMTTotalOrdersFilled));
                        string argFileName60 = ManufacturingTabColumnSettingsFileName;
                        string argFileName61 = ManufacturingTabColumnSettingsFileName;
                        withBlock.AvgItemsperOrder = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName61, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "AvgItemsperOrder", DefaultMTAvgItemsperOrder));
                        string argFileName62 = ManufacturingTabColumnSettingsFileName;
                        string argFileName63 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CurrentSellOrders = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName63, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CurrentSellOrders", DefaultMTCurrentSellOrders));
                        string argFileName64 = ManufacturingTabColumnSettingsFileName;
                        string argFileName65 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CurrentBuyOrders = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName65, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CurrentBuyOrders", DefaultMTCurrentBuyOrders));
                        string argFileName66 = ManufacturingTabColumnSettingsFileName;
                        string argFileName67 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemsinProduction = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName67, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemsinProduction", DefaultMTItemsinProduction));
                        string argFileName68 = ManufacturingTabColumnSettingsFileName;
                        string argFileName69 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemsinStock = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName69, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemsinStock", DefaultMTItemsinStock));
                        string argFileName70 = ManufacturingTabColumnSettingsFileName;
                        string argFileName71 = ManufacturingTabColumnSettingsFileName;
                        withBlock.MaterialCost = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName71, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "MaterialCost", DefaultMTMaterialCost));
                        string argFileName72 = ManufacturingTabColumnSettingsFileName;
                        string argFileName73 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalCost = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName73, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalCost", DefaultMTTotalCost));
                        string argFileName74 = ManufacturingTabColumnSettingsFileName;
                        string argFileName75 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BaseJobCost = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName75, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BaseJobCost", DefaultMTBaseJobCost));
                        string argFileName76 = ManufacturingTabColumnSettingsFileName;
                        string argFileName77 = ManufacturingTabColumnSettingsFileName;
                        withBlock.NumBPs = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName77, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "NumBPs", DefaultMTNumBPs));
                        string argFileName78 = ManufacturingTabColumnSettingsFileName;
                        string argFileName79 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionChance = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName79, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionChance", DefaultMTInventionChance));
                        string argFileName80 = ManufacturingTabColumnSettingsFileName;
                        string argFileName81 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BPType = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName81, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPType", DefaultMTBPType));
                        string argFileName82 = ManufacturingTabColumnSettingsFileName;
                        string argFileName83 = ManufacturingTabColumnSettingsFileName;
                        withBlock.Race = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName83, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "Race", DefaultMTRace));
                        string argFileName84 = ManufacturingTabColumnSettingsFileName;
                        string argFileName85 = ManufacturingTabColumnSettingsFileName;
                        withBlock.VolumeperItem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName85, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "VolumeperItem", DefaultMTVolumeperItem));
                        string argFileName86 = ManufacturingTabColumnSettingsFileName;
                        string argFileName87 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalVolume = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName87, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalVolume", DefaultMTTotalVolume));
                        string argFileName88 = ManufacturingTabColumnSettingsFileName;
                        string argFileName89 = ManufacturingTabColumnSettingsFileName;
                        withBlock.SellExcess = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName89, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SellExcess", DefaultMTSellExcess));
                        string argFileName90 = ManufacturingTabColumnSettingsFileName;
                        string argFileName91 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ROI = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName91, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ROI", DefaultMTROI));
                        string argFileName92 = ManufacturingTabColumnSettingsFileName;
                        string argFileName93 = ManufacturingTabColumnSettingsFileName;
                        withBlock.PortionSize = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName93, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "PortionSize", DefaultMTPortionSize));
                        string argFileName94 = ManufacturingTabColumnSettingsFileName;
                        string argFileName95 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingJobFee = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName95, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingJobFee", DefaultMTManufacturingJobFee));
                        string argFileName96 = ManufacturingTabColumnSettingsFileName;
                        string argFileName97 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityName = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName97, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityName", DefaultMTManufacturingFacilityName));
                        string argFileName98 = ManufacturingTabColumnSettingsFileName;
                        string argFileName99 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilitySystem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName99, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilitySystem", DefaultMTManufacturingFacilitySystem));
                        string argFileName100 = ManufacturingTabColumnSettingsFileName;
                        string argFileName101 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityRegion = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName101, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityRegion", DefaultMTManufacturingFacilityRegion));
                        string argFileName102 = ManufacturingTabColumnSettingsFileName;
                        string argFileName103 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilitySystemIndex = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName103, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilitySystemIndex", DefaultMTManufacturingFacilitySystemIndex));
                        string argFileName104 = ManufacturingTabColumnSettingsFileName;
                        string argFileName105 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityTax = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName105, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityTax", DefaultMTManufacturingFacilityTax));
                        string argFileName106 = ManufacturingTabColumnSettingsFileName;
                        string argFileName107 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityMEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName107, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityMEBonus", DefaultMTManufacturingFacilityMEBonus));
                        string argFileName108 = ManufacturingTabColumnSettingsFileName;
                        string argFileName109 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityTEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName109, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityTEBonus", DefaultMTManufacturingFacilityTEBonus));
                        string argFileName110 = ManufacturingTabColumnSettingsFileName;
                        string argFileName111 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityUsage = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName111, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityUsage", DefaultMTManufacturingFacilityUsage));
                        string argFileName112 = ManufacturingTabColumnSettingsFileName;
                        string argFileName113 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityFWSystemLevel = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName113, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityFWSystemLevel", DefaultMTManufacturingFacilityFWSystemLevel));
                        string argFileName114 = ManufacturingTabColumnSettingsFileName;
                        string argFileName115 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityName = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName115, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityName", DefaultMTComponentFacilityName));
                        string argFileName116 = ManufacturingTabColumnSettingsFileName;
                        string argFileName117 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilitySystem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName117, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilitySystem", DefaultMTComponentFacilitySystem));
                        string argFileName118 = ManufacturingTabColumnSettingsFileName;
                        string argFileName119 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityRegion = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName119, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityRegion", DefaultMTComponentFacilityRegion));
                        string argFileName120 = ManufacturingTabColumnSettingsFileName;
                        string argFileName121 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilitySystemIndex = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName121, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilitySystemIndex", DefaultMTComponentFacilitySystemIndex));
                        string argFileName122 = ManufacturingTabColumnSettingsFileName;
                        string argFileName123 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityTax = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName123, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityTax", DefaultMTComponentFacilityTax));
                        string argFileName124 = ManufacturingTabColumnSettingsFileName;
                        string argFileName125 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityMEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName125, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityMEBonus", DefaultMTComponentFacilityMEBonus));
                        string argFileName126 = ManufacturingTabColumnSettingsFileName;
                        string argFileName127 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityTEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName127, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityTEBonus", DefaultMTComponentFacilityTEBonus));
                        string argFileName128 = ManufacturingTabColumnSettingsFileName;
                        string argFileName129 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityUsage = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName129, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityUsage", DefaultMTComponentFacilityUsage));
                        string argFileName130 = ManufacturingTabColumnSettingsFileName;
                        string argFileName131 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityFWSystemLevel = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName131, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityFWSystemLevel", DefaultMTComponentFacilityFWSystemLevel));
                        string argFileName132 = ManufacturingTabColumnSettingsFileName;
                        string argFileName133 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityName = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName133, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityName", DefaultMTCapComponentFacilityName));
                        string argFileName134 = ManufacturingTabColumnSettingsFileName;
                        string argFileName135 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilitySystem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName135, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilitySystem", DefaultMTCapComponentFacilitySystem));
                        string argFileName136 = ManufacturingTabColumnSettingsFileName;
                        string argFileName137 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityRegion = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName137, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityRegion", DefaultMTCapComponentFacilityRegion));
                        string argFileName138 = ManufacturingTabColumnSettingsFileName;
                        string argFileName139 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilitySystemIndex = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName139, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilitySystemIndex", DefaultMTCapComponentFacilitySystemIndex));
                        string argFileName140 = ManufacturingTabColumnSettingsFileName;
                        string argFileName141 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityTax = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName141, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityTax", DefaultMTCapComponentFacilityTax));
                        string argFileName142 = ManufacturingTabColumnSettingsFileName;
                        string argFileName143 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityMEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName143, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityMEBonus", DefaultMTCapComponentFacilityMEBonus));
                        string argFileName144 = ManufacturingTabColumnSettingsFileName;
                        string argFileName145 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityTEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName145, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityTEBonus", DefaultMTCapComponentFacilityTEBonus));
                        string argFileName146 = ManufacturingTabColumnSettingsFileName;
                        string argFileName147 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityUsage = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName147, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityUsage", DefaultMTCapComponentFacilityUsage));
                        string argFileName148 = ManufacturingTabColumnSettingsFileName;
                        string argFileName149 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityFWSystemLevel = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName149, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityFWSystemLevel", DefaultMTCapComponentFacilityFWSystemLevel));
                        string argFileName150 = ManufacturingTabColumnSettingsFileName;
                        string argFileName151 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityName = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName151, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityName", DefaultMTCopyingFacilityName));
                        string argFileName152 = ManufacturingTabColumnSettingsFileName;
                        string argFileName153 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilitySystem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName153, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilitySystem", DefaultMTCopyingFacilitySystem));
                        string argFileName154 = ManufacturingTabColumnSettingsFileName;
                        string argFileName155 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityRegion = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName155, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityRegion", DefaultMTCopyingFacilityRegion));
                        string argFileName156 = ManufacturingTabColumnSettingsFileName;
                        string argFileName157 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilitySystemIndex = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName157, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilitySystemIndex", DefaultMTCopyingFacilitySystemIndex));
                        string argFileName158 = ManufacturingTabColumnSettingsFileName;
                        string argFileName159 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityTax = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName159, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityTax", DefaultMTCopyingFacilityTax));
                        string argFileName160 = ManufacturingTabColumnSettingsFileName;
                        string argFileName161 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityMEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName161, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityMEBonus", DefaultMTCopyingFacilityMEBonus));
                        string argFileName162 = ManufacturingTabColumnSettingsFileName;
                        string argFileName163 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityTEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName163, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityTEBonus", DefaultMTCopyingFacilityTEBonus));
                        string argFileName164 = ManufacturingTabColumnSettingsFileName;
                        string argFileName165 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityUsage = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName165, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityUsage", DefaultMTCopyingFacilityUsage));
                        string argFileName166 = ManufacturingTabColumnSettingsFileName;
                        string argFileName167 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityFWSystemLevel = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName167, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityFWSystemLevel", DefaultMTCopyingFacilityFWSystemLevel));
                        string argFileName168 = ManufacturingTabColumnSettingsFileName;
                        string argFileName169 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityName = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName169, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityName", DefaultMTInventionFacilityName));
                        string argFileName170 = ManufacturingTabColumnSettingsFileName;
                        string argFileName171 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilitySystem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName171, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilitySystem", DefaultMTInventionFacilitySystem));
                        string argFileName172 = ManufacturingTabColumnSettingsFileName;
                        string argFileName173 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityRegion = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName173, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityRegion", DefaultMTInventionFacilityRegion));
                        string argFileName174 = ManufacturingTabColumnSettingsFileName;
                        string argFileName175 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilitySystemIndex = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName175, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilitySystemIndex", DefaultMTInventionFacilitySystemIndex));
                        string argFileName176 = ManufacturingTabColumnSettingsFileName;
                        string argFileName177 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityTax = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName177, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityTax", DefaultMTInventionFacilityTax));
                        string argFileName178 = ManufacturingTabColumnSettingsFileName;
                        string argFileName179 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityMEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName179, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityMEBonus", DefaultMTInventionFacilityMEBonus));
                        string argFileName180 = ManufacturingTabColumnSettingsFileName;
                        string argFileName181 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityTEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName181, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityTEBonus", DefaultMTInventionFacilityTEBonus));
                        string argFileName182 = ManufacturingTabColumnSettingsFileName;
                        string argFileName183 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityUsage = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName183, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityUsage", DefaultMTInventionFacilityUsage));
                        string argFileName184 = ManufacturingTabColumnSettingsFileName;
                        string argFileName185 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityFWSystemLevel = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName185, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityFWSystemLevel", DefaultMTInventionFacilityFWSystemLevel));
                        string argFileName186 = ManufacturingTabColumnSettingsFileName;
                        string argFileName187 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityName = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName187, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityName", DefaultMTReactionFacilityName));
                        string argFileName188 = ManufacturingTabColumnSettingsFileName;
                        string argFileName189 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilitySystem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName189, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilitySystem", DefaultMTReactionFacilitySystem));
                        string argFileName190 = ManufacturingTabColumnSettingsFileName;
                        string argFileName191 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityRegion = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName191, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityRegion", DefaultMTReactionFacilityRegion));
                        string argFileName192 = ManufacturingTabColumnSettingsFileName;
                        string argFileName193 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilitySystemIndex = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName193, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilitySystemIndex", DefaultMTReactionFacilitySystemIndex));
                        string argFileName194 = ManufacturingTabColumnSettingsFileName;
                        string argFileName195 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityTax = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName195, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityTax", DefaultMTReactionFacilityTax));
                        string argFileName196 = ManufacturingTabColumnSettingsFileName;
                        string argFileName197 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityMEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName197, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityMEBonus", DefaultMTReactionFacilityMEBonus));
                        string argFileName198 = ManufacturingTabColumnSettingsFileName;
                        string argFileName199 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityTEBonus = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName199, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityTEBonus", DefaultMTReactionFacilityTEBonus));
                        string argFileName200 = ManufacturingTabColumnSettingsFileName;
                        string argFileName201 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityUsage = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName201, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityUsage", DefaultMTReactionFacilityUsage));
                        string argFileName202 = ManufacturingTabColumnSettingsFileName;
                        string argFileName203 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityFWSystemLevel = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName203, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityFWSystemLevel", DefaultMTReactionFacilityFWSystemLevel));
                        string argFileName204 = ManufacturingTabColumnSettingsFileName;
                        string argFileName205 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityName = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName205, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityName", DefaultMTReprocessingFacilityName));
                        string argFileName206 = ManufacturingTabColumnSettingsFileName;
                        string argFileName207 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilitySystem = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName207, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilitySystem", DefaultMTReprocessingFacilitySystem));
                        string argFileName208 = ManufacturingTabColumnSettingsFileName;
                        string argFileName209 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityRegion = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName209, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityRegion", DefaultMTReprocessingFacilityRegion));
                        string argFileName210 = ManufacturingTabColumnSettingsFileName;
                        string argFileName211 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityTax = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName211, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityTax", DefaultMTReprocessingFacilityTax));
                        string argFileName212 = ManufacturingTabColumnSettingsFileName;
                        string argFileName213 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityUsage = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName213, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityUsage", DefaultMTReprocessingFacilityUsage));
                        string argFileName214 = ManufacturingTabColumnSettingsFileName;
                        string argFileName215 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityOreRefineRate = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName215, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityOreRefineRate", DefaultMTReprocessingFacilityOreRefineRate));
                        string argFileName216 = ManufacturingTabColumnSettingsFileName;
                        string argFileName217 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityIceRefineRate = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName217, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityIceRefineRate", DefaultMTReprocessingFacilityIceRefineRate));
                        string argFileName218 = ManufacturingTabColumnSettingsFileName;
                        string argFileName219 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityMoonRefineRate = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName219, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityMoonRefineRate", DefaultMTReprocessingFacilityMoonRefineRate));

                        string argFileName220 = ManufacturingTabColumnSettingsFileName;
                        string argFileName221 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemCategoryWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName221, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemCategoryWidth", DefaultMTItemCategoryWidth));
                        string argFileName222 = ManufacturingTabColumnSettingsFileName;
                        string argFileName223 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemGroupWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName223, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemGroupWidth", DefaultMTItemGroupWidth));
                        string argFileName224 = ManufacturingTabColumnSettingsFileName;
                        string argFileName225 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemNameWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName225, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemNameWidth", DefaultMTItemNameWidth));
                        string argFileName226 = ManufacturingTabColumnSettingsFileName;
                        string argFileName227 = ManufacturingTabColumnSettingsFileName;
                        withBlock.OwnedWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName227, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "OwnedWidth", DefaultMTOwnedWidth));
                        string argFileName228 = ManufacturingTabColumnSettingsFileName;
                        string argFileName229 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TechWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName229, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TechWidth", DefaultMTTechWidth));
                        string argFileName230 = ManufacturingTabColumnSettingsFileName;
                        string argFileName231 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BPMEWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName231, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPMEWidth", DefaultMTBPMEWidth));
                        string argFileName232 = ManufacturingTabColumnSettingsFileName;
                        string argFileName233 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BPTEWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName233, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPTEWidth", DefaultMTBPTEWidth));
                        string argFileName234 = ManufacturingTabColumnSettingsFileName;
                        string argFileName235 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InputsWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName235, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InputsWidth", DefaultMTInputsWidth));
                        string argFileName236 = ManufacturingTabColumnSettingsFileName;
                        string argFileName237 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComparedWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName237, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComparedWidth", DefaultMTComparedWidth));
                        string argFileName238 = ManufacturingTabColumnSettingsFileName;
                        string argFileName239 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalRunsWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName239, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalRunsWidth", DefaultMTTotalRunsWidth));
                        string argFileName240 = ManufacturingTabColumnSettingsFileName;
                        string argFileName241 = ManufacturingTabColumnSettingsFileName;
                        withBlock.SingleInventedBPCRunsWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName241, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SingleInventedBPCRunsWidth", DefaultMTSingleInventedBPCRunsWidth));
                        string argFileName242 = ManufacturingTabColumnSettingsFileName;
                        string argFileName243 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ProductionLinesWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName243, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProductionLinesWidth", DefaultMTProductionLinesWidth));
                        string argFileName244 = ManufacturingTabColumnSettingsFileName;
                        string argFileName245 = ManufacturingTabColumnSettingsFileName;
                        withBlock.LaboratoryLinesWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName245, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "LaboratoryLinesWidth", DefaultMTLaboratoryLinesWidth));
                        string argFileName246 = ManufacturingTabColumnSettingsFileName;
                        string argFileName247 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalInventionCostWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName247, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalInventionCostWidth", DefaultMTTotalInventionCostWidth));
                        string argFileName248 = ManufacturingTabColumnSettingsFileName;
                        string argFileName249 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalCopyCostWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName249, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalCopyCostWidth", DefaultMTTotalCopyCostWidth));
                        string argFileName250 = ManufacturingTabColumnSettingsFileName;
                        string argFileName251 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TaxesWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName251, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TaxesWidth", DefaultMTTaxesWidth));
                        string argFileName252 = ManufacturingTabColumnSettingsFileName;
                        string argFileName253 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BrokerFeesWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName253, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BrokerFeesWidth", DefaultMTBrokerFeesWidth));
                        string argFileName254 = ManufacturingTabColumnSettingsFileName;
                        string argFileName255 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BPProductionTimeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName255, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPProductionTimeWidth", DefaultMTBPProductionTimeWidth));
                        string argFileName256 = ManufacturingTabColumnSettingsFileName;
                        string argFileName257 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalProductionTimeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName257, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalProductionTimeWidth", DefaultMTTotalProductionTimeWidth));
                        string argFileName258 = ManufacturingTabColumnSettingsFileName;
                        string argFileName259 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyTimeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName259, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyTimeWidth", DefaultMTCopyTimeWidth));
                        string argFileName260 = ManufacturingTabColumnSettingsFileName;
                        string argFileName261 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionTimeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName261, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionTimeWidth", DefaultMTInventionTimeWidth));
                        string argFileName262 = ManufacturingTabColumnSettingsFileName;
                        string argFileName263 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemMarketPriceWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName263, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemMarketPriceWidth", DefaultMTItemMarketPriceWidth));
                        string argFileName264 = ManufacturingTabColumnSettingsFileName;
                        string argFileName265 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ProfitWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName265, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProfitWidth", DefaultMTProfitWidth));
                        string argFileName266 = ManufacturingTabColumnSettingsFileName;
                        string argFileName267 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ProfitPercentageWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName267, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ProfitPercentageWidth", DefaultMTProfitPercentageWidth));
                        string argFileName268 = ManufacturingTabColumnSettingsFileName;
                        string argFileName269 = ManufacturingTabColumnSettingsFileName;
                        withBlock.IskperHourWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName269, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "IskperHourWidth", DefaultMTIskperHourWidth));
                        string argFileName270 = ManufacturingTabColumnSettingsFileName;
                        string argFileName271 = ManufacturingTabColumnSettingsFileName;
                        withBlock.SVRWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName271, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SVRWidth", DefaultMTSVRWidth));
                        string argFileName272 = ManufacturingTabColumnSettingsFileName;
                        string argFileName273 = ManufacturingTabColumnSettingsFileName;
                        withBlock.SVRxIPHWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName273, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SVRxIPHWidth", DefaultMTSVRxIPHWidth));
                        string argFileName274 = ManufacturingTabColumnSettingsFileName;
                        string argFileName275 = ManufacturingTabColumnSettingsFileName;
                        withBlock.PriceTrendWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName275, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "PriceTrendWidth", DefaultMTPriceTrendWidth));
                        string argFileName276 = ManufacturingTabColumnSettingsFileName;
                        string argFileName277 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalItemsSoldWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName277, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalItemsSoldWidth", DefaultMTTotalItemsSoldWidth));
                        string argFileName278 = ManufacturingTabColumnSettingsFileName;
                        string argFileName279 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalOrdersFilledWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName279, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalOrdersFilledWidth", DefaultMTTotalOrdersFilledWidth));
                        string argFileName280 = ManufacturingTabColumnSettingsFileName;
                        string argFileName281 = ManufacturingTabColumnSettingsFileName;
                        withBlock.AvgItemsperOrderWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName281, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "AvgItemsperOrderWidth", DefaultMTAvgItemsperOrderWidth));
                        string argFileName282 = ManufacturingTabColumnSettingsFileName;
                        string argFileName283 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CurrentSellOrdersWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName283, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CurrentSellOrdersWidth", DefaultMTCurrentSellOrdersWidth));
                        string argFileName284 = ManufacturingTabColumnSettingsFileName;
                        string argFileName285 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CurrentBuyOrdersWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName285, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CurrentBuyOrdersWidth", DefaultMTCurrentBuyOrdersWidth));
                        string argFileName286 = ManufacturingTabColumnSettingsFileName;
                        string argFileName287 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemsinProductionWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName287, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemsinProductionWidth", DefaultMTItemsinProductionWidth));
                        string argFileName288 = ManufacturingTabColumnSettingsFileName;
                        string argFileName289 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ItemsinStockWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName289, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ItemsinStockWidth", DefaultMTItemsinStockWidth));
                        string argFileName290 = ManufacturingTabColumnSettingsFileName;
                        string argFileName291 = ManufacturingTabColumnSettingsFileName;
                        withBlock.MaterialCostWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName291, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "MaterialCostWidth", DefaultMTMaterialCostWidth));
                        string argFileName292 = ManufacturingTabColumnSettingsFileName;
                        string argFileName293 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalCostWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName293, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalCostWidth", DefaultMTTotalCostWidth));
                        string argFileName294 = ManufacturingTabColumnSettingsFileName;
                        string argFileName295 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BaseJobCostWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName295, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BaseJobCostWidth", DefaultMTBaseJobCostWidth));
                        string argFileName296 = ManufacturingTabColumnSettingsFileName;
                        string argFileName297 = ManufacturingTabColumnSettingsFileName;
                        withBlock.NumBPsWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName297, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "NumBPsWidth", DefaultMTNumBPsWidth));
                        string argFileName298 = ManufacturingTabColumnSettingsFileName;
                        string argFileName299 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionChanceWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName299, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionChanceWidth", DefaultMTInventionChanceWidth));
                        string argFileName300 = ManufacturingTabColumnSettingsFileName;
                        string argFileName301 = ManufacturingTabColumnSettingsFileName;
                        withBlock.BPTypeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName301, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "BPTypeWidth", DefaultMTBPTypeWidth));
                        string argFileName302 = ManufacturingTabColumnSettingsFileName;
                        string argFileName303 = ManufacturingTabColumnSettingsFileName;
                        withBlock.RaceWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName303, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "RaceWidth", DefaultMTRaceWidth));
                        string argFileName304 = ManufacturingTabColumnSettingsFileName;
                        string argFileName305 = ManufacturingTabColumnSettingsFileName;
                        withBlock.VolumeperItemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName305, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "VolumeperItemWidth", DefaultMTVolumeperItemWidth));
                        string argFileName306 = ManufacturingTabColumnSettingsFileName;
                        string argFileName307 = ManufacturingTabColumnSettingsFileName;
                        withBlock.TotalVolumeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName307, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "TotalVolumeWidth", DefaultMTTotalVolumeWidth));
                        string argFileName308 = ManufacturingTabColumnSettingsFileName;
                        string argFileName309 = ManufacturingTabColumnSettingsFileName;
                        withBlock.SellExcessWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName309, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "SellExcessWidth", DefaultMTSellExcessWidth));
                        string argFileName310 = ManufacturingTabColumnSettingsFileName;
                        string argFileName311 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ROIWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName311, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ROIWidth", DefaultMTROIWidth));
                        string argFileName312 = ManufacturingTabColumnSettingsFileName;
                        string argFileName313 = ManufacturingTabColumnSettingsFileName;
                        withBlock.PortionSizeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName313, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "PortionSizeWidth", DefaultMTPortionSizeWidth));
                        string argFileName314 = ManufacturingTabColumnSettingsFileName;
                        string argFileName315 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingJobFeeWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName315, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingJobFeeWidth", DefaultMTManufacturingJobFeeWidth));
                        string argFileName316 = ManufacturingTabColumnSettingsFileName;
                        string argFileName317 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityNameWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName317, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityNameWidth", DefaultMTManufacturingFacilityNameWidth));
                        string argFileName318 = ManufacturingTabColumnSettingsFileName;
                        string argFileName319 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilitySystemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName319, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilitySystemWidth", DefaultMTManufacturingFacilitySystemWidth));
                        string argFileName320 = ManufacturingTabColumnSettingsFileName;
                        string argFileName321 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityRegionWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName321, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityRegionWidth", DefaultMTManufacturingFacilityRegionWidth));
                        string argFileName322 = ManufacturingTabColumnSettingsFileName;
                        string argFileName323 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilitySystemIndexWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName323, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilitySystemIndexWidth", DefaultMTManufacturingFacilitySystemIndexWidth));
                        string argFileName324 = ManufacturingTabColumnSettingsFileName;
                        string argFileName325 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityTaxWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName325, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityTaxWidth", DefaultMTManufacturingFacilityTaxWidth));
                        string argFileName326 = ManufacturingTabColumnSettingsFileName;
                        string argFileName327 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityMEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName327, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityMEBonusWidth", DefaultMTManufacturingFacilityMEBonusWidth));
                        string argFileName328 = ManufacturingTabColumnSettingsFileName;
                        string argFileName329 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityTEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName329, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityTEBonusWidth", DefaultMTManufacturingFacilityTEBonusWidth));
                        string argFileName330 = ManufacturingTabColumnSettingsFileName;
                        string argFileName331 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityUsageWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName331, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityUsageWidth", DefaultMTManufacturingFacilityUsageWidth));
                        string argFileName332 = ManufacturingTabColumnSettingsFileName;
                        string argFileName333 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ManufacturingFacilityFWSystemLevelWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName333, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ManufacturingFacilityFWSystemLevelWidth", DefaultMTManufacturingFacilityFWSystemLevelWidth));
                        string argFileName334 = ManufacturingTabColumnSettingsFileName;
                        string argFileName335 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityNameWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName335, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityNameWidth", DefaultMTComponentFacilityNameWidth));
                        string argFileName336 = ManufacturingTabColumnSettingsFileName;
                        string argFileName337 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilitySystemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName337, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilitySystemWidth", DefaultMTComponentFacilitySystemWidth));
                        string argFileName338 = ManufacturingTabColumnSettingsFileName;
                        string argFileName339 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityRegionWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName339, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityRegionWidth", DefaultMTComponentFacilityRegionWidth));
                        string argFileName340 = ManufacturingTabColumnSettingsFileName;
                        string argFileName341 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilitySystemIndexWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName341, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilitySystemIndexWidth", DefaultMTComponentFacilitySystemIndexWidth));
                        string argFileName342 = ManufacturingTabColumnSettingsFileName;
                        string argFileName343 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityTaxWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName343, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityTaxWidth", DefaultMTComponentFacilityTaxWidth));
                        string argFileName344 = ManufacturingTabColumnSettingsFileName;
                        string argFileName345 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityMEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName345, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityMEBonusWidth", DefaultMTComponentFacilityMEBonusWidth));
                        string argFileName346 = ManufacturingTabColumnSettingsFileName;
                        string argFileName347 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityTEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName347, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityTEBonusWidth", DefaultMTComponentFacilityTEBonusWidth));
                        string argFileName348 = ManufacturingTabColumnSettingsFileName;
                        string argFileName349 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityUsageWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName349, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityUsageWidth", DefaultMTComponentFacilityUsageWidth));
                        string argFileName350 = ManufacturingTabColumnSettingsFileName;
                        string argFileName351 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ComponentFacilityFWSystemLevelWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName351, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ComponentFacilityFWSystemLevelWidth", DefaultMTComponentFacilityFWSystemLevelWidth));
                        string argFileName352 = ManufacturingTabColumnSettingsFileName;
                        string argFileName353 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityNameWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName353, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityNameWidth", DefaultMTCapComponentFacilityNameWidth));
                        string argFileName354 = ManufacturingTabColumnSettingsFileName;
                        string argFileName355 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilitySystemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName355, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilitySystemWidth", DefaultMTCapComponentFacilitySystemWidth));
                        string argFileName356 = ManufacturingTabColumnSettingsFileName;
                        string argFileName357 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityRegionWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName357, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityRegionWidth", DefaultMTCapComponentFacilityRegionWidth));
                        string argFileName358 = ManufacturingTabColumnSettingsFileName;
                        string argFileName359 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilitySystemIndexWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName359, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilitySystemIndexWidth", DefaultMTCapComponentFacilitySystemIndexWidth));
                        string argFileName360 = ManufacturingTabColumnSettingsFileName;
                        string argFileName361 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityTaxWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName361, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityTaxWidth", DefaultMTCapComponentFacilityTaxWidth));
                        string argFileName362 = ManufacturingTabColumnSettingsFileName;
                        string argFileName363 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityMEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName363, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityMEBonusWidth", DefaultMTCapComponentFacilityMEBonusWidth));
                        string argFileName364 = ManufacturingTabColumnSettingsFileName;
                        string argFileName365 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityTEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName365, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityTEBonusWidth", DefaultMTCapComponentFacilityTEBonusWidth));
                        string argFileName366 = ManufacturingTabColumnSettingsFileName;
                        string argFileName367 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityUsageWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName367, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityUsageWidth", DefaultMTCapComponentFacilityUsageWidth));
                        string argFileName368 = ManufacturingTabColumnSettingsFileName;
                        string argFileName369 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CapComponentFacilityFWSystemLevelWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName369, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CapComponentFacilityFWSystemLevelWidth", DefaultMTCapComponentFacilityFWSystemLevelWidth));
                        string argFileName370 = ManufacturingTabColumnSettingsFileName;
                        string argFileName371 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityNameWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName371, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityNameWidth", DefaultMTCopyingFacilityNameWidth));
                        string argFileName372 = ManufacturingTabColumnSettingsFileName;
                        string argFileName373 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilitySystemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName373, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilitySystemWidth", DefaultMTCopyingFacilitySystemWidth));
                        string argFileName374 = ManufacturingTabColumnSettingsFileName;
                        string argFileName375 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityRegionWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName375, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityRegionWidth", DefaultMTCopyingFacilityRegionWidth));
                        string argFileName376 = ManufacturingTabColumnSettingsFileName;
                        string argFileName377 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilitySystemIndexWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName377, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilitySystemIndexWidth", DefaultMTCopyingFacilitySystemIndexWidth));
                        string argFileName378 = ManufacturingTabColumnSettingsFileName;
                        string argFileName379 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityTaxWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName379, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityTaxWidth", DefaultMTCopyingFacilityTaxWidth));
                        string argFileName380 = ManufacturingTabColumnSettingsFileName;
                        string argFileName381 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityMEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName381, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityMEBonusWidth", DefaultMTCopyingFacilityMEBonusWidth));
                        string argFileName382 = ManufacturingTabColumnSettingsFileName;
                        string argFileName383 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityTEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName383, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityTEBonusWidth", DefaultMTCopyingFacilityTEBonusWidth));
                        string argFileName384 = ManufacturingTabColumnSettingsFileName;
                        string argFileName385 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityUsageWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName385, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityUsageWidth", DefaultMTCopyingFacilityUsageWidth));
                        string argFileName386 = ManufacturingTabColumnSettingsFileName;
                        string argFileName387 = ManufacturingTabColumnSettingsFileName;
                        withBlock.CopyingFacilityFWSystemLevelWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName387, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "CopyingFacilityFWSystemLevelWidth", DefaultMTCopyingFacilityFWSystemLevelWidth));
                        string argFileName388 = ManufacturingTabColumnSettingsFileName;
                        string argFileName389 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityNameWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName389, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityNameWidth", DefaultMTInventionFacilityNameWidth));
                        string argFileName390 = ManufacturingTabColumnSettingsFileName;
                        string argFileName391 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilitySystemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName391, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilitySystemWidth", DefaultMTInventionFacilitySystemWidth));
                        string argFileName392 = ManufacturingTabColumnSettingsFileName;
                        string argFileName393 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityRegionWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName393, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityRegionWidth", DefaultMTInventionFacilityRegionWidth));
                        string argFileName394 = ManufacturingTabColumnSettingsFileName;
                        string argFileName395 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilitySystemIndexWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName395, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilitySystemIndexWidth", DefaultMTInventionFacilitySystemIndexWidth));
                        string argFileName396 = ManufacturingTabColumnSettingsFileName;
                        string argFileName397 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityTaxWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName397, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityTaxWidth", DefaultMTInventionFacilityTaxWidth));
                        string argFileName398 = ManufacturingTabColumnSettingsFileName;
                        string argFileName399 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityMEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName399, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityMEBonusWidth", DefaultMTInventionFacilityMEBonusWidth));
                        string argFileName400 = ManufacturingTabColumnSettingsFileName;
                        string argFileName401 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityTEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName401, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityTEBonusWidth", DefaultMTInventionFacilityTEBonusWidth));
                        string argFileName402 = ManufacturingTabColumnSettingsFileName;
                        string argFileName403 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityUsageWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName403, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityUsageWidth", DefaultMTInventionFacilityUsageWidth));
                        string argFileName404 = ManufacturingTabColumnSettingsFileName;
                        string argFileName405 = ManufacturingTabColumnSettingsFileName;
                        withBlock.InventionFacilityFWSystemLevelWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName405, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "InventionFacilityFWSystemLevelWidth", DefaultMTInventionFacilityFWSystemLevelWidth));
                        string argFileName406 = ManufacturingTabColumnSettingsFileName;
                        string argFileName407 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityNameWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName407, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityNameWidth", DefaultMTReactionFacilityNameWidth));
                        string argFileName408 = ManufacturingTabColumnSettingsFileName;
                        string argFileName409 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilitySystemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName409, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilitySystemWidth", DefaultMTReactionFacilitySystemWidth));
                        string argFileName410 = ManufacturingTabColumnSettingsFileName;
                        string argFileName411 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityRegionWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName411, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityRegionWidth", DefaultMTReactionFacilityRegionWidth));
                        string argFileName412 = ManufacturingTabColumnSettingsFileName;
                        string argFileName413 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilitySystemIndexWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName413, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilitySystemIndexWidth", DefaultMTReactionFacilitySystemIndexWidth));
                        string argFileName414 = ManufacturingTabColumnSettingsFileName;
                        string argFileName415 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityTaxWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName415, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityTaxWidth", DefaultMTReactionFacilityTaxWidth));
                        string argFileName416 = ManufacturingTabColumnSettingsFileName;
                        string argFileName417 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityMEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName417, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityMEBonusWidth", DefaultMTReactionFacilityMEBonusWidth));
                        string argFileName418 = ManufacturingTabColumnSettingsFileName;
                        string argFileName419 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityTEBonusWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName419, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityTEBonusWidth", DefaultMTReactionFacilityTEBonusWidth));
                        string argFileName420 = ManufacturingTabColumnSettingsFileName;
                        string argFileName421 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityUsageWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName421, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityUsageWidth", DefaultMTReactionFacilityUsageWidth));
                        string argFileName422 = ManufacturingTabColumnSettingsFileName;
                        string argFileName423 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReactionFacilityFWSystemLevelWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName423, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReactionFacilityFWSystemLevelWidth", DefaultMTReactionFacilityFWSystemLevelWidth));
                        string argFileName424 = ManufacturingTabColumnSettingsFileName;
                        string argFileName425 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityNameWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName425, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityNameWidth", DefaultMTReprocessingFacilityNameWidth));
                        string argFileName426 = ManufacturingTabColumnSettingsFileName;
                        string argFileName427 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilitySystemWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName427, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilitySystemWidth", DefaultMTReprocessingFacilitySystemWidth));
                        string argFileName428 = ManufacturingTabColumnSettingsFileName;
                        string argFileName429 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityRegionWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName429, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityRegionWidth", DefaultMTReprocessingFacilityRegionWidth));
                        string argFileName430 = ManufacturingTabColumnSettingsFileName;
                        string argFileName431 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityTaxWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName431, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityTaxWidth", DefaultMTReprocessingFacilityTaxWidth));
                        string argFileName432 = ManufacturingTabColumnSettingsFileName;
                        string argFileName433 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityUsageWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName433, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityUsageWidth", DefaultMTReprocessingFacilityUsageWidth));
                        string argFileName434 = ManufacturingTabColumnSettingsFileName;
                        string argFileName435 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityOreRefineRateWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName435, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityOreRefineRateWidth", DefaultMTReprocessingFacilityOreRefineRateWidth));
                        string argFileName436 = ManufacturingTabColumnSettingsFileName;
                        string argFileName437 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityIceRefineRateWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName437, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityIceRefineRateWidth", DefaultMTReprocessingFacilityIceRefineRateWidth));
                        string argFileName438 = ManufacturingTabColumnSettingsFileName;
                        string argFileName439 = ManufacturingTabColumnSettingsFileName;
                        withBlock.ReprocessingFacilityMoonRefineRateWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName439, SettingTypes.TypeInteger, "ManufacturingTabColumnSettings", "ReprocessingFacilityMoonRefineRateWidth", DefaultMTReprocessingFacilityMoonRefineRateWidth));

                        string argFileName440 = ManufacturingTabColumnSettingsFileName;
                        string argFileName441 = ManufacturingTabColumnSettingsFileName;
                        withBlock.OrderByColumn = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName441, SettingTypes.TypeInteger, ManufacturingTabColumnSettingsFileName, "OrderByColumn", DefaultMTOrderByColumn));
                        string argFileName442 = ManufacturingTabColumnSettingsFileName;
                        string argFileName443 = ManufacturingTabColumnSettingsFileName;
                        withBlock.OrderType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName443, SettingTypes.TypeString, ManufacturingTabColumnSettingsFileName, "OrderType", DefaultMTOrderType));

                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultManufacturingTabColumnSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Industry Jobs Column Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultManufacturingTabColumnSettings();
            }

            // Save them locally and then export
            ManufacturingTabColumnSettings = TempSettings;

            return TempSettings;

        }

        // Loads the Defaults for the tab
        public ManufacturingTabColumnSettings SetDefaultManufacturingTabColumnSettings()
        {
            ManufacturingTabColumnSettings LocalSettings;

            LocalSettings.ItemCategory = DefaultMTItemCategory;
            LocalSettings.ItemGroup = DefaultMTItemGroup;
            LocalSettings.ItemName = DefaultMTItemName;
            LocalSettings.Owned = DefaultMTOwned;
            LocalSettings.Tech = DefaultMTTech;
            LocalSettings.BPME = DefaultMTBPME;
            LocalSettings.BPTE = DefaultMTBPTE;
            LocalSettings.Inputs = DefaultMTInputs;
            LocalSettings.Compared = DefaultMTCompared;
            LocalSettings.TotalRuns = DefaultMTTotalRuns;
            LocalSettings.SingleInventedBPCRuns = DefaultMTSingleInventedBPCRuns;
            LocalSettings.ProductionLines = DefaultMTProductionLines;
            LocalSettings.LaboratoryLines = DefaultMTLaboratoryLines;
            LocalSettings.TotalInventionCost = DefaultMTTotalInventionCost;
            LocalSettings.TotalCopyCost = DefaultMTTotalCopyCost;
            LocalSettings.Taxes = DefaultMTTaxes;
            LocalSettings.BrokerFees = DefaultMTBrokerFees;
            LocalSettings.BPProductionTime = DefaultMTBPProductionTime;
            LocalSettings.TotalProductionTime = DefaultMTTotalProductionTime;
            LocalSettings.CopyTime = DefaultMTCopyTime;
            LocalSettings.InventionTime = DefaultMTInventionTime;
            LocalSettings.ItemMarketPrice = DefaultMTItemMarketPrice;
            LocalSettings.Profit = DefaultMTProfit;
            LocalSettings.ProfitPercentage = DefaultMTProfitPercentage;
            LocalSettings.IskperHour = DefaultMTIskperHour;
            LocalSettings.SVR = DefaultMTSVR;
            LocalSettings.SVRxIPH = DefaultMTSVRxIPH;
            LocalSettings.PriceTrend = DefaultMTPriceTrend;
            LocalSettings.TotalItemsSold = DefaultMTTotalItemsSold;
            LocalSettings.TotalOrdersFilled = DefaultMTTotalOrdersFilled;
            LocalSettings.AvgItemsperOrder = DefaultMTAvgItemsperOrder;
            LocalSettings.CurrentSellOrders = DefaultMTCurrentSellOrders;
            LocalSettings.CurrentBuyOrders = DefaultMTCurrentBuyOrders;
            LocalSettings.ItemsinProduction = DefaultMTItemsinProduction;
            LocalSettings.ItemsinStock = DefaultMTItemsinStock;
            LocalSettings.MaterialCost = DefaultMTMaterialCost;
            LocalSettings.TotalCost = DefaultMTTotalCost;
            LocalSettings.BaseJobCost = DefaultMTBaseJobCost;
            LocalSettings.NumBPs = DefaultMTNumBPs;
            LocalSettings.InventionChance = DefaultMTInventionChance;
            LocalSettings.BPType = DefaultMTBPType;
            LocalSettings.Race = DefaultMTRace;
            LocalSettings.VolumeperItem = DefaultMTVolumeperItem;
            LocalSettings.TotalVolume = DefaultMTTotalVolume;
            LocalSettings.SellExcess = DefaultMTSellExcess;
            LocalSettings.ROI = DefaultMTROI;
            LocalSettings.PortionSize = DefaultMTPortionSize;
            LocalSettings.ManufacturingJobFee = DefaultMTManufacturingJobFee;
            LocalSettings.ManufacturingFacilityName = DefaultMTManufacturingFacilityName;
            LocalSettings.ManufacturingFacilitySystem = DefaultMTManufacturingFacilitySystem;
            LocalSettings.ManufacturingFacilityRegion = DefaultMTManufacturingFacilityRegion;
            LocalSettings.ManufacturingFacilitySystemIndex = DefaultMTManufacturingFacilitySystemIndex;
            LocalSettings.ManufacturingFacilityTax = DefaultMTManufacturingFacilityTax;
            LocalSettings.ManufacturingFacilityMEBonus = DefaultMTManufacturingFacilityMEBonus;
            LocalSettings.ManufacturingFacilityTEBonus = DefaultMTManufacturingFacilityTEBonus;
            LocalSettings.ManufacturingFacilityUsage = DefaultMTManufacturingFacilityUsage;
            LocalSettings.ManufacturingFacilityFWSystemLevel = DefaultMTManufacturingFacilityFWSystemLevel;
            LocalSettings.ComponentFacilityName = DefaultMTComponentFacilityName;
            LocalSettings.ComponentFacilitySystem = DefaultMTComponentFacilitySystem;
            LocalSettings.ComponentFacilityRegion = DefaultMTComponentFacilityRegion;
            LocalSettings.ComponentFacilitySystemIndex = DefaultMTComponentFacilitySystemIndex;
            LocalSettings.ComponentFacilityTax = DefaultMTComponentFacilityTax;
            LocalSettings.ComponentFacilityMEBonus = DefaultMTComponentFacilityMEBonus;
            LocalSettings.ComponentFacilityTEBonus = DefaultMTComponentFacilityTEBonus;
            LocalSettings.ComponentFacilityUsage = DefaultMTComponentFacilityUsage;
            LocalSettings.ComponentFacilityFWSystemLevel = DefaultMTComponentFacilityFWSystemLevel;
            LocalSettings.CapComponentFacilityName = DefaultMTCapComponentFacilityName;
            LocalSettings.CapComponentFacilitySystem = DefaultMTCapComponentFacilitySystem;
            LocalSettings.CapComponentFacilityRegion = DefaultMTCapComponentFacilityRegion;
            LocalSettings.CapComponentFacilitySystemIndex = DefaultMTCapComponentFacilitySystemIndex;
            LocalSettings.CapComponentFacilityTax = DefaultMTCapComponentFacilityTax;
            LocalSettings.CapComponentFacilityMEBonus = DefaultMTCapComponentFacilityMEBonus;
            LocalSettings.CapComponentFacilityTEBonus = DefaultMTCapComponentFacilityTEBonus;
            LocalSettings.CapComponentFacilityUsage = DefaultMTCapComponentFacilityUsage;
            LocalSettings.CapComponentFacilityFWSystemLevel = DefaultMTCapComponentFacilityFWSystemLevel;
            LocalSettings.CopyingFacilityName = DefaultMTCopyingFacilityName;
            LocalSettings.CopyingFacilitySystem = DefaultMTCopyingFacilitySystem;
            LocalSettings.CopyingFacilityRegion = DefaultMTCopyingFacilityRegion;
            LocalSettings.CopyingFacilitySystemIndex = DefaultMTCopyingFacilitySystemIndex;
            LocalSettings.CopyingFacilityTax = DefaultMTCopyingFacilityTax;
            LocalSettings.CopyingFacilityMEBonus = DefaultMTCopyingFacilityMEBonus;
            LocalSettings.CopyingFacilityTEBonus = DefaultMTCopyingFacilityTEBonus;
            LocalSettings.CopyingFacilityUsage = DefaultMTCopyingFacilityUsage;
            LocalSettings.CopyingFacilityFWSystemLevel = DefaultMTCopyingFacilityFWSystemLevel;
            LocalSettings.InventionFacilityName = DefaultMTInventionFacilityName;
            LocalSettings.InventionFacilitySystem = DefaultMTInventionFacilitySystem;
            LocalSettings.InventionFacilityRegion = DefaultMTInventionFacilityRegion;
            LocalSettings.InventionFacilitySystemIndex = DefaultMTInventionFacilitySystemIndex;
            LocalSettings.InventionFacilityTax = DefaultMTInventionFacilityTax;
            LocalSettings.InventionFacilityMEBonus = DefaultMTInventionFacilityMEBonus;
            LocalSettings.InventionFacilityTEBonus = DefaultMTInventionFacilityTEBonus;
            LocalSettings.InventionFacilityUsage = DefaultMTInventionFacilityUsage;
            LocalSettings.InventionFacilityFWSystemLevel = DefaultMTInventionFacilityFWSystemLevel;
            LocalSettings.ReactionFacilityName = DefaultMTReactionFacilityName;
            LocalSettings.ReactionFacilitySystem = DefaultMTReactionFacilitySystem;
            LocalSettings.ReactionFacilityRegion = DefaultMTReactionFacilityRegion;
            LocalSettings.ReactionFacilitySystemIndex = DefaultMTReactionFacilitySystemIndex;
            LocalSettings.ReactionFacilityTax = DefaultMTReactionFacilityTax;
            LocalSettings.ReactionFacilityMEBonus = DefaultMTReactionFacilityMEBonus;
            LocalSettings.ReactionFacilityTEBonus = DefaultMTReactionFacilityTEBonus;
            LocalSettings.ReactionFacilityUsage = DefaultMTReactionFacilityUsage;
            LocalSettings.ReactionFacilityFWSystemLevel = DefaultMTReactionFacilityFWSystemLevel;
            LocalSettings.ReprocessingFacilityName = DefaultMTReprocessingFacilityName;
            LocalSettings.ReprocessingFacilitySystem = DefaultMTReprocessingFacilitySystem;
            LocalSettings.ReprocessingFacilityRegion = DefaultMTReprocessingFacilityRegion;
            LocalSettings.ReprocessingFacilityTax = DefaultMTReprocessingFacilityTax;
            LocalSettings.ReprocessingFacilityUsage = DefaultMTReprocessingFacilityUsage;
            LocalSettings.ReprocessingFacilityOreRefineRate = DefaultMTReprocessingFacilityOreRefineRate;
            LocalSettings.ReprocessingFacilityIceRefineRate = DefaultMTReprocessingFacilityIceRefineRate;
            LocalSettings.ReprocessingFacilityMoonRefineRate = DefaultMTReprocessingFacilityMoonRefineRate;

            LocalSettings.ItemCategoryWidth = DefaultMTItemCategoryWidth;
            LocalSettings.ItemGroupWidth = DefaultMTItemGroupWidth;
            LocalSettings.ItemNameWidth = DefaultMTItemNameWidth;
            LocalSettings.OwnedWidth = DefaultMTOwnedWidth;
            LocalSettings.TechWidth = DefaultMTTechWidth;
            LocalSettings.BPMEWidth = DefaultMTBPMEWidth;
            LocalSettings.BPTEWidth = DefaultMTBPTEWidth;
            LocalSettings.InputsWidth = DefaultMTInputsWidth;
            LocalSettings.ComparedWidth = DefaultMTComparedWidth;
            LocalSettings.TotalRunsWidth = DefaultMTTotalRunsWidth;
            LocalSettings.SingleInventedBPCRunsWidth = DefaultMTSingleInventedBPCRunsWidth;
            LocalSettings.ProductionLinesWidth = DefaultMTProductionLinesWidth;
            LocalSettings.LaboratoryLinesWidth = DefaultMTLaboratoryLinesWidth;
            LocalSettings.TotalInventionCostWidth = DefaultMTTotalInventionCostWidth;
            LocalSettings.TotalCopyCostWidth = DefaultMTTotalCopyCostWidth;
            LocalSettings.TaxesWidth = DefaultMTTaxesWidth;
            LocalSettings.BrokerFeesWidth = DefaultMTBrokerFeesWidth;
            LocalSettings.BPProductionTimeWidth = DefaultMTBPProductionTimeWidth;
            LocalSettings.TotalProductionTimeWidth = DefaultMTTotalProductionTimeWidth;
            LocalSettings.CopyTimeWidth = DefaultMTCopyTimeWidth;
            LocalSettings.InventionTimeWidth = DefaultMTInventionTimeWidth;
            LocalSettings.ItemMarketPriceWidth = DefaultMTItemMarketPriceWidth;
            LocalSettings.ProfitWidth = DefaultMTProfitWidth;
            LocalSettings.ProfitPercentageWidth = DefaultMTProfitPercentageWidth;
            LocalSettings.IskperHourWidth = DefaultMTIskperHourWidth;
            LocalSettings.SVRWidth = DefaultMTSVRWidth;
            LocalSettings.SVRxIPHWidth = DefaultMTSVRxIPHWidth;
            LocalSettings.PriceTrendWidth = DefaultMTPriceTrendWidth;
            LocalSettings.TotalItemsSoldWidth = DefaultMTTotalItemsSoldWidth;
            LocalSettings.TotalOrdersFilledWidth = DefaultMTTotalOrdersFilledWidth;
            LocalSettings.AvgItemsperOrderWidth = DefaultMTAvgItemsperOrderWidth;
            LocalSettings.CurrentSellOrdersWidth = DefaultMTCurrentSellOrdersWidth;
            LocalSettings.CurrentBuyOrdersWidth = DefaultMTCurrentBuyOrdersWidth;
            LocalSettings.ItemsinProductionWidth = DefaultMTItemsinProductionWidth;
            LocalSettings.ItemsinStockWidth = DefaultMTItemsinStockWidth;
            LocalSettings.MaterialCostWidth = DefaultMTMaterialCostWidth;
            LocalSettings.TotalCostWidth = DefaultMTTotalCostWidth;
            LocalSettings.BaseJobCostWidth = DefaultMTBaseJobCostWidth;
            LocalSettings.NumBPsWidth = DefaultMTNumBPsWidth;
            LocalSettings.InventionChanceWidth = DefaultMTInventionChanceWidth;
            LocalSettings.BPTypeWidth = DefaultMTBPTypeWidth;
            LocalSettings.RaceWidth = DefaultMTRaceWidth;
            LocalSettings.VolumeperItemWidth = DefaultMTVolumeperItemWidth;
            LocalSettings.TotalVolumeWidth = DefaultMTTotalVolumeWidth;
            LocalSettings.SellExcessWidth = DefaultMTSellExcessWidth;
            LocalSettings.ROIWidth = DefaultMTROIWidth;
            LocalSettings.PortionSizeWidth = DefaultMTPortionSizeWidth;
            LocalSettings.ManufacturingJobFeeWidth = DefaultMTManufacturingJobFeeWidth;
            LocalSettings.ManufacturingFacilityNameWidth = DefaultMTManufacturingFacilityNameWidth;
            LocalSettings.ManufacturingFacilitySystemWidth = DefaultMTManufacturingFacilitySystemWidth;
            LocalSettings.ManufacturingFacilityRegionWidth = DefaultMTManufacturingFacilityRegionWidth;
            LocalSettings.ManufacturingFacilitySystemIndexWidth = DefaultMTManufacturingFacilitySystemIndexWidth;
            LocalSettings.ManufacturingFacilityTaxWidth = DefaultMTManufacturingFacilityTaxWidth;
            LocalSettings.ManufacturingFacilityMEBonusWidth = DefaultMTManufacturingFacilityMEBonusWidth;
            LocalSettings.ManufacturingFacilityTEBonusWidth = DefaultMTManufacturingFacilityTEBonusWidth;
            LocalSettings.ManufacturingFacilityUsageWidth = DefaultMTManufacturingFacilityUsageWidth;
            LocalSettings.ManufacturingFacilityFWSystemLevelWidth = DefaultMTManufacturingFacilityFWSystemLevelWidth;
            LocalSettings.ComponentFacilityNameWidth = DefaultMTComponentFacilityNameWidth;
            LocalSettings.ComponentFacilitySystemWidth = DefaultMTComponentFacilitySystemWidth;
            LocalSettings.ComponentFacilityRegionWidth = DefaultMTComponentFacilityRegionWidth;
            LocalSettings.ComponentFacilitySystemIndexWidth = DefaultMTComponentFacilitySystemIndexWidth;
            LocalSettings.ComponentFacilityTaxWidth = DefaultMTComponentFacilityTaxWidth;
            LocalSettings.ComponentFacilityMEBonusWidth = DefaultMTComponentFacilityMEBonusWidth;
            LocalSettings.ComponentFacilityTEBonusWidth = DefaultMTComponentFacilityTEBonusWidth;
            LocalSettings.ComponentFacilityUsageWidth = DefaultMTComponentFacilityUsageWidth;
            LocalSettings.ComponentFacilityFWSystemLevelWidth = DefaultMTComponentFacilityFWSystemLevelWidth;
            LocalSettings.CapComponentFacilityNameWidth = DefaultMTCapComponentFacilityNameWidth;
            LocalSettings.CapComponentFacilitySystemWidth = DefaultMTCapComponentFacilitySystemWidth;
            LocalSettings.CapComponentFacilityRegionWidth = DefaultMTCapComponentFacilityRegionWidth;
            LocalSettings.CapComponentFacilitySystemIndexWidth = DefaultMTCapComponentFacilitySystemIndexWidth;
            LocalSettings.CapComponentFacilityTaxWidth = DefaultMTCapComponentFacilityTaxWidth;
            LocalSettings.CapComponentFacilityMEBonusWidth = DefaultMTCapComponentFacilityMEBonusWidth;
            LocalSettings.CapComponentFacilityTEBonusWidth = DefaultMTCapComponentFacilityTEBonusWidth;
            LocalSettings.CapComponentFacilityUsageWidth = DefaultMTCapComponentFacilityUsageWidth;
            LocalSettings.CapComponentFacilityFWSystemLevelWidth = DefaultMTCapComponentFacilityFWSystemLevelWidth;
            LocalSettings.CopyingFacilityNameWidth = DefaultMTCopyingFacilityNameWidth;
            LocalSettings.CopyingFacilitySystemWidth = DefaultMTCopyingFacilitySystemWidth;
            LocalSettings.CopyingFacilityRegionWidth = DefaultMTCopyingFacilityRegionWidth;
            LocalSettings.CopyingFacilitySystemIndexWidth = DefaultMTCopyingFacilitySystemIndexWidth;
            LocalSettings.CopyingFacilityTaxWidth = DefaultMTCopyingFacilityTaxWidth;
            LocalSettings.CopyingFacilityMEBonusWidth = DefaultMTCopyingFacilityMEBonusWidth;
            LocalSettings.CopyingFacilityTEBonusWidth = DefaultMTCopyingFacilityTEBonusWidth;
            LocalSettings.CopyingFacilityUsageWidth = DefaultMTCopyingFacilityUsageWidth;
            LocalSettings.CopyingFacilityFWSystemLevelWidth = DefaultMTCopyingFacilityFWSystemLevelWidth;
            LocalSettings.InventionFacilityNameWidth = DefaultMTInventionFacilityNameWidth;
            LocalSettings.InventionFacilitySystemWidth = DefaultMTInventionFacilitySystemWidth;
            LocalSettings.InventionFacilityRegionWidth = DefaultMTInventionFacilityRegionWidth;
            LocalSettings.InventionFacilitySystemIndexWidth = DefaultMTInventionFacilitySystemIndexWidth;
            LocalSettings.InventionFacilityTaxWidth = DefaultMTInventionFacilityTaxWidth;
            LocalSettings.InventionFacilityMEBonusWidth = DefaultMTInventionFacilityMEBonusWidth;
            LocalSettings.InventionFacilityTEBonusWidth = DefaultMTInventionFacilityTEBonusWidth;
            LocalSettings.InventionFacilityUsageWidth = DefaultMTInventionFacilityUsageWidth;
            LocalSettings.InventionFacilityFWSystemLevelWidth = DefaultMTInventionFacilityFWSystemLevelWidth;
            LocalSettings.ReactionFacilityNameWidth = DefaultMTReactionFacilityNameWidth;
            LocalSettings.ReactionFacilitySystemWidth = DefaultMTReactionFacilitySystemWidth;
            LocalSettings.ReactionFacilityRegionWidth = DefaultMTReactionFacilityRegionWidth;
            LocalSettings.ReactionFacilitySystemIndexWidth = DefaultMTReactionFacilitySystemIndexWidth;
            LocalSettings.ReactionFacilityTaxWidth = DefaultMTReactionFacilityTaxWidth;
            LocalSettings.ReactionFacilityMEBonusWidth = DefaultMTReactionFacilityMEBonusWidth;
            LocalSettings.ReactionFacilityTEBonusWidth = DefaultMTReactionFacilityTEBonusWidth;
            LocalSettings.ReactionFacilityUsageWidth = DefaultMTReactionFacilityUsageWidth;
            LocalSettings.ReactionFacilityFWSystemLevelWidth = DefaultMTReactionFacilityFWSystemLevelWidth;
            LocalSettings.ReprocessingFacilityNameWidth = DefaultMTReprocessingFacilityNameWidth;
            LocalSettings.ReprocessingFacilitySystemWidth = DefaultMTReprocessingFacilitySystemWidth;
            LocalSettings.ReprocessingFacilityRegionWidth = DefaultMTReprocessingFacilityRegionWidth;
            LocalSettings.ReprocessingFacilityTaxWidth = DefaultMTReprocessingFacilityTaxWidth;
            LocalSettings.ReprocessingFacilityUsageWidth = DefaultMTReprocessingFacilityUsageWidth;
            LocalSettings.ReprocessingFacilityOreRefineRateWidth = DefaultMTReprocessingFacilityOreRefineRateWidth;
            LocalSettings.ReprocessingFacilityIceRefineRateWidth = DefaultMTReprocessingFacilityIceRefineRateWidth;
            LocalSettings.ReprocessingFacilityMoonRefineRateWidth = DefaultMTReprocessingFacilityMoonRefineRateWidth;

            LocalSettings.OrderByColumn = DefaultMTOrderByColumn;

            LocalSettings.OrderType = DefaultMTOrderType;

            // save locally
            ManufacturingTabColumnSettings = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveManufacturingTabColumnSettings(ManufacturingTabColumnSettings SentSettings)
        {
            var ManufacturingTabColumnSettingsList = new Setting[222];

            try
            {
                ManufacturingTabColumnSettingsList[0] = new Setting("ItemCategory", SentSettings.ItemCategory.ToString());
                ManufacturingTabColumnSettingsList[1] = new Setting("ItemGroup", SentSettings.ItemGroup.ToString());
                ManufacturingTabColumnSettingsList[2] = new Setting("ItemName", SentSettings.ItemName.ToString());
                ManufacturingTabColumnSettingsList[3] = new Setting("Owned", SentSettings.Owned.ToString());
                ManufacturingTabColumnSettingsList[4] = new Setting("Tech", SentSettings.Tech.ToString());
                ManufacturingTabColumnSettingsList[5] = new Setting("BPME", SentSettings.BPME.ToString());
                ManufacturingTabColumnSettingsList[6] = new Setting("BPTE", SentSettings.BPTE.ToString());
                ManufacturingTabColumnSettingsList[7] = new Setting("Inputs", SentSettings.Inputs.ToString());
                ManufacturingTabColumnSettingsList[8] = new Setting("Compared", SentSettings.Compared.ToString());
                ManufacturingTabColumnSettingsList[9] = new Setting("TotalRuns", SentSettings.TotalRuns.ToString());
                ManufacturingTabColumnSettingsList[10] = new Setting("SingleInventedBPCRuns", SentSettings.SingleInventedBPCRuns.ToString());
                ManufacturingTabColumnSettingsList[11] = new Setting("ProductionLines", SentSettings.ProductionLines.ToString());
                ManufacturingTabColumnSettingsList[12] = new Setting("LaboratoryLines", SentSettings.LaboratoryLines.ToString());
                ManufacturingTabColumnSettingsList[13] = new Setting("TotalInventionCost", SentSettings.TotalInventionCost.ToString());
                ManufacturingTabColumnSettingsList[14] = new Setting("TotalCopyCost", SentSettings.TotalCopyCost.ToString());
                ManufacturingTabColumnSettingsList[15] = new Setting("Taxes", SentSettings.Taxes.ToString());
                ManufacturingTabColumnSettingsList[16] = new Setting("BrokerFees", SentSettings.BrokerFees.ToString());
                ManufacturingTabColumnSettingsList[17] = new Setting("BPProductionTime", SentSettings.BPProductionTime.ToString());
                ManufacturingTabColumnSettingsList[18] = new Setting("TotalProductionTime", SentSettings.TotalProductionTime.ToString());
                ManufacturingTabColumnSettingsList[19] = new Setting("CopyTime", SentSettings.CopyTime.ToString());
                ManufacturingTabColumnSettingsList[20] = new Setting("InventionTime", SentSettings.InventionTime.ToString());
                ManufacturingTabColumnSettingsList[21] = new Setting("ItemMarketPrice", SentSettings.ItemMarketPrice.ToString());
                ManufacturingTabColumnSettingsList[22] = new Setting("Profit", SentSettings.Profit.ToString());
                ManufacturingTabColumnSettingsList[23] = new Setting("ProfitPercentage", SentSettings.ProfitPercentage.ToString());
                ManufacturingTabColumnSettingsList[24] = new Setting("IskperHour", SentSettings.IskperHour.ToString());
                ManufacturingTabColumnSettingsList[25] = new Setting("SVR", SentSettings.SVR.ToString());
                ManufacturingTabColumnSettingsList[26] = new Setting("SVRxIPH", SentSettings.SVRxIPH.ToString());
                ManufacturingTabColumnSettingsList[27] = new Setting("PriceTrend", SentSettings.PriceTrend.ToString());
                ManufacturingTabColumnSettingsList[28] = new Setting("TotalItemsSold", SentSettings.TotalItemsSold.ToString());
                ManufacturingTabColumnSettingsList[29] = new Setting("TotalOrdersFilled", SentSettings.TotalOrdersFilled.ToString());
                ManufacturingTabColumnSettingsList[30] = new Setting("AvgItemsperOrder", SentSettings.AvgItemsperOrder.ToString());
                ManufacturingTabColumnSettingsList[31] = new Setting("CurrentSellOrders", SentSettings.CurrentSellOrders.ToString());
                ManufacturingTabColumnSettingsList[32] = new Setting("CurrentBuyOrders", SentSettings.CurrentBuyOrders.ToString());
                ManufacturingTabColumnSettingsList[33] = new Setting("ItemsinProduction", SentSettings.ItemsinProduction.ToString());
                ManufacturingTabColumnSettingsList[34] = new Setting("ItemsinStock", SentSettings.ItemsinStock.ToString());
                ManufacturingTabColumnSettingsList[35] = new Setting("MaterialCost", SentSettings.MaterialCost.ToString());
                ManufacturingTabColumnSettingsList[36] = new Setting("TotalCost", SentSettings.TotalCost.ToString());
                ManufacturingTabColumnSettingsList[37] = new Setting("BaseJobCost", SentSettings.BaseJobCost.ToString());
                ManufacturingTabColumnSettingsList[38] = new Setting("NumBPs", SentSettings.NumBPs.ToString());
                ManufacturingTabColumnSettingsList[39] = new Setting("InventionChance", SentSettings.InventionChance.ToString());
                ManufacturingTabColumnSettingsList[40] = new Setting("BPType", SentSettings.BPType.ToString());
                ManufacturingTabColumnSettingsList[41] = new Setting("Race", SentSettings.Race.ToString());
                ManufacturingTabColumnSettingsList[42] = new Setting("VolumeperItem", SentSettings.VolumeperItem.ToString());
                ManufacturingTabColumnSettingsList[43] = new Setting("TotalVolume", SentSettings.TotalVolume.ToString());
                ManufacturingTabColumnSettingsList[44] = new Setting("SellExcess", SentSettings.SellExcess.ToString());
                ManufacturingTabColumnSettingsList[45] = new Setting("ROI", SentSettings.ROI.ToString());
                ManufacturingTabColumnSettingsList[46] = new Setting("PortionSize", SentSettings.PortionSize.ToString());
                ManufacturingTabColumnSettingsList[47] = new Setting("ManufacturingJobFee", SentSettings.ManufacturingJobFee.ToString());
                ManufacturingTabColumnSettingsList[48] = new Setting("ManufacturingFacilityName", SentSettings.ManufacturingFacilityName.ToString());
                ManufacturingTabColumnSettingsList[49] = new Setting("ManufacturingFacilitySystem", SentSettings.ManufacturingFacilitySystem.ToString());
                ManufacturingTabColumnSettingsList[50] = new Setting("ManufacturingFacilityRegion", SentSettings.ManufacturingFacilityRegion.ToString());
                ManufacturingTabColumnSettingsList[51] = new Setting("ManufacturingFacilitySystemIndex", SentSettings.ManufacturingFacilitySystemIndex.ToString());
                ManufacturingTabColumnSettingsList[52] = new Setting("ManufacturingFacilityTax", SentSettings.ManufacturingFacilityTax.ToString());
                ManufacturingTabColumnSettingsList[53] = new Setting("ManufacturingFacilityMEBonus", SentSettings.ManufacturingFacilityMEBonus.ToString());
                ManufacturingTabColumnSettingsList[54] = new Setting("ManufacturingFacilityTEBonus", SentSettings.ManufacturingFacilityTEBonus.ToString());
                ManufacturingTabColumnSettingsList[55] = new Setting("ManufacturingFacilityUsage", SentSettings.ManufacturingFacilityUsage.ToString());
                ManufacturingTabColumnSettingsList[56] = new Setting("ManufacturingFacilityFWSystemLevel", SentSettings.ManufacturingFacilityFWSystemLevel.ToString());
                ManufacturingTabColumnSettingsList[57] = new Setting("ComponentFacilityName", SentSettings.ComponentFacilityName.ToString());
                ManufacturingTabColumnSettingsList[58] = new Setting("ComponentFacilitySystem", SentSettings.ComponentFacilitySystem.ToString());
                ManufacturingTabColumnSettingsList[59] = new Setting("ComponentFacilityRegion", SentSettings.ComponentFacilityRegion.ToString());
                ManufacturingTabColumnSettingsList[60] = new Setting("ComponentFacilitySystemIndex", SentSettings.ComponentFacilitySystemIndex.ToString());
                ManufacturingTabColumnSettingsList[61] = new Setting("ComponentFacilityTax", SentSettings.ComponentFacilityTax.ToString());
                ManufacturingTabColumnSettingsList[62] = new Setting("ComponentFacilityMEBonus", SentSettings.ComponentFacilityMEBonus.ToString());
                ManufacturingTabColumnSettingsList[63] = new Setting("ComponentFacilityTEBonus", SentSettings.ComponentFacilityTEBonus.ToString());
                ManufacturingTabColumnSettingsList[64] = new Setting("ComponentFacilityUsage", SentSettings.ComponentFacilityUsage.ToString());
                ManufacturingTabColumnSettingsList[65] = new Setting("ComponentFacilityFWSystemLevel", SentSettings.ComponentFacilityFWSystemLevel.ToString());
                ManufacturingTabColumnSettingsList[66] = new Setting("CapComponentFacilityName", SentSettings.CapComponentFacilityName.ToString());
                ManufacturingTabColumnSettingsList[67] = new Setting("CapComponentFacilitySystem", SentSettings.CapComponentFacilitySystem.ToString());
                ManufacturingTabColumnSettingsList[68] = new Setting("CapComponentFacilityRegion", SentSettings.CapComponentFacilityRegion.ToString());
                ManufacturingTabColumnSettingsList[69] = new Setting("CapComponentFacilitySystemIndex", SentSettings.CapComponentFacilitySystemIndex.ToString());
                ManufacturingTabColumnSettingsList[70] = new Setting("CapComponentFacilityTax", SentSettings.CapComponentFacilityTax.ToString());
                ManufacturingTabColumnSettingsList[71] = new Setting("CapComponentFacilityMEBonus", SentSettings.CapComponentFacilityMEBonus.ToString());
                ManufacturingTabColumnSettingsList[72] = new Setting("CapComponentFacilityTEBonus", SentSettings.CapComponentFacilityTEBonus.ToString());
                ManufacturingTabColumnSettingsList[73] = new Setting("CapComponentFacilityUsage", SentSettings.CapComponentFacilityUsage.ToString());
                ManufacturingTabColumnSettingsList[74] = new Setting("CapComponentFacilityFWSystemLevel", SentSettings.CapComponentFacilityFWSystemLevel.ToString());
                ManufacturingTabColumnSettingsList[75] = new Setting("CopyingFacilityName", SentSettings.CopyingFacilityName.ToString());
                ManufacturingTabColumnSettingsList[76] = new Setting("CopyingFacilitySystem", SentSettings.CopyingFacilitySystem.ToString());
                ManufacturingTabColumnSettingsList[77] = new Setting("CopyingFacilityRegion", SentSettings.CopyingFacilityRegion.ToString());
                ManufacturingTabColumnSettingsList[78] = new Setting("CopyingFacilitySystemIndex", SentSettings.CopyingFacilitySystemIndex.ToString());
                ManufacturingTabColumnSettingsList[79] = new Setting("CopyingFacilityTax", SentSettings.CopyingFacilityTax.ToString());
                ManufacturingTabColumnSettingsList[80] = new Setting("CopyingFacilityMEBonus", SentSettings.CopyingFacilityMEBonus.ToString());
                ManufacturingTabColumnSettingsList[81] = new Setting("CopyingFacilityTEBonus", SentSettings.CopyingFacilityTEBonus.ToString());
                ManufacturingTabColumnSettingsList[82] = new Setting("CopyingFacilityUsage", SentSettings.CopyingFacilityUsage.ToString());
                ManufacturingTabColumnSettingsList[83] = new Setting("CopyingFacilityFWSystemLevel", SentSettings.CopyingFacilityFWSystemLevel.ToString());
                ManufacturingTabColumnSettingsList[84] = new Setting("InventionFacilityName", SentSettings.InventionFacilityName.ToString());
                ManufacturingTabColumnSettingsList[85] = new Setting("InventionFacilitySystem", SentSettings.InventionFacilitySystem.ToString());
                ManufacturingTabColumnSettingsList[86] = new Setting("InventionFacilityRegion", SentSettings.InventionFacilityRegion.ToString());
                ManufacturingTabColumnSettingsList[87] = new Setting("InventionFacilitySystemIndex", SentSettings.InventionFacilitySystemIndex.ToString());
                ManufacturingTabColumnSettingsList[88] = new Setting("InventionFacilityTax", SentSettings.InventionFacilityTax.ToString());
                ManufacturingTabColumnSettingsList[89] = new Setting("InventionFacilityMEBonus", SentSettings.InventionFacilityMEBonus.ToString());
                ManufacturingTabColumnSettingsList[90] = new Setting("InventionFacilityTEBonus", SentSettings.InventionFacilityTEBonus.ToString());
                ManufacturingTabColumnSettingsList[91] = new Setting("InventionFacilityUsage", SentSettings.InventionFacilityUsage.ToString());
                ManufacturingTabColumnSettingsList[92] = new Setting("InventionFacilityFWSystemLevel", SentSettings.InventionFacilityFWSystemLevel.ToString());
                ManufacturingTabColumnSettingsList[93] = new Setting("ReactionFacilityName", SentSettings.ReactionFacilityName.ToString());
                ManufacturingTabColumnSettingsList[94] = new Setting("ReactionFacilitySystem", SentSettings.ReactionFacilitySystem.ToString());
                ManufacturingTabColumnSettingsList[95] = new Setting("ReactionFacilityRegion", SentSettings.ReactionFacilityRegion.ToString());
                ManufacturingTabColumnSettingsList[96] = new Setting("ReactionFacilitySystemIndex", SentSettings.ReactionFacilitySystemIndex.ToString());
                ManufacturingTabColumnSettingsList[97] = new Setting("ReactionFacilityTax", SentSettings.ReactionFacilityTax.ToString());
                ManufacturingTabColumnSettingsList[98] = new Setting("ReactionFacilityMEBonus", SentSettings.ReactionFacilityMEBonus.ToString());
                ManufacturingTabColumnSettingsList[99] = new Setting("ReactionFacilityTEBonus", SentSettings.ReactionFacilityTEBonus.ToString());
                ManufacturingTabColumnSettingsList[100] = new Setting("ReactionFacilityUsage", SentSettings.ReactionFacilityUsage.ToString());
                ManufacturingTabColumnSettingsList[101] = new Setting("ReactionFacilityFWSystemLevel", SentSettings.ReactionFacilityFWSystemLevel.ToString());
                ManufacturingTabColumnSettingsList[102] = new Setting("ReprocessingFacilityName", SentSettings.ReprocessingFacilityName.ToString());
                ManufacturingTabColumnSettingsList[103] = new Setting("ReprocessingFacilitySystem", SentSettings.ReprocessingFacilitySystem.ToString());
                ManufacturingTabColumnSettingsList[104] = new Setting("ReprocessingFacilityRegion", SentSettings.ReprocessingFacilityRegion.ToString());
                ManufacturingTabColumnSettingsList[105] = new Setting("ReprocessingFacilityTax", SentSettings.ReprocessingFacilityTax.ToString());
                ManufacturingTabColumnSettingsList[106] = new Setting("ReprocessingFacilityUsage", SentSettings.ReprocessingFacilityUsage.ToString());
                ManufacturingTabColumnSettingsList[107] = new Setting("ReprocessingFacilityOreRefineRate", SentSettings.ReprocessingFacilityOreRefineRate.ToString());
                ManufacturingTabColumnSettingsList[108] = new Setting("ReprocessingFacilityIceRefineRate", SentSettings.ReprocessingFacilityIceRefineRate.ToString());
                ManufacturingTabColumnSettingsList[109] = new Setting("ReprocessingFacilityMoonRefineRate", SentSettings.ReprocessingFacilityMoonRefineRate.ToString());

                ManufacturingTabColumnSettingsList[110] = new Setting("ItemCategoryWidth", SentSettings.ItemCategoryWidth.ToString());
                ManufacturingTabColumnSettingsList[111] = new Setting("ItemGroupWidth", SentSettings.ItemGroupWidth.ToString());
                ManufacturingTabColumnSettingsList[112] = new Setting("ItemNameWidth", SentSettings.ItemNameWidth.ToString());
                ManufacturingTabColumnSettingsList[113] = new Setting("OwnedWidth", SentSettings.OwnedWidth.ToString());
                ManufacturingTabColumnSettingsList[114] = new Setting("TechWidth", SentSettings.TechWidth.ToString());
                ManufacturingTabColumnSettingsList[115] = new Setting("BPMEWidth", SentSettings.BPMEWidth.ToString());
                ManufacturingTabColumnSettingsList[116] = new Setting("BPTEWidth", SentSettings.BPTEWidth.ToString());
                ManufacturingTabColumnSettingsList[117] = new Setting("InputsWidth", SentSettings.InputsWidth.ToString());
                ManufacturingTabColumnSettingsList[118] = new Setting("ComparedWidth", SentSettings.ComparedWidth.ToString());
                ManufacturingTabColumnSettingsList[119] = new Setting("TotalRunsWidth", SentSettings.TotalRunsWidth.ToString());
                ManufacturingTabColumnSettingsList[120] = new Setting("SingleInventedBPCRunsWidth", SentSettings.SingleInventedBPCRunsWidth.ToString());
                ManufacturingTabColumnSettingsList[121] = new Setting("ProductionLinesWidth", SentSettings.ProductionLinesWidth.ToString());
                ManufacturingTabColumnSettingsList[122] = new Setting("LaboratoryLinesWidth", SentSettings.LaboratoryLinesWidth.ToString());
                ManufacturingTabColumnSettingsList[123] = new Setting("TotalInventionCostWidth", SentSettings.TotalInventionCostWidth.ToString());
                ManufacturingTabColumnSettingsList[124] = new Setting("TotalCopyCostWidth", SentSettings.TotalCopyCostWidth.ToString());
                ManufacturingTabColumnSettingsList[125] = new Setting("TaxesWidth", SentSettings.TaxesWidth.ToString());
                ManufacturingTabColumnSettingsList[126] = new Setting("BrokerFeesWidth", SentSettings.BrokerFeesWidth.ToString());
                ManufacturingTabColumnSettingsList[127] = new Setting("BPProductionTimeWidth", SentSettings.BPProductionTimeWidth.ToString());
                ManufacturingTabColumnSettingsList[128] = new Setting("TotalProductionTimeWidth", SentSettings.TotalProductionTimeWidth.ToString());
                ManufacturingTabColumnSettingsList[129] = new Setting("CopyTimeWidth", SentSettings.CopyTimeWidth.ToString());
                ManufacturingTabColumnSettingsList[130] = new Setting("InventionTimeWidth", SentSettings.InventionTimeWidth.ToString());
                ManufacturingTabColumnSettingsList[131] = new Setting("ItemMarketPriceWidth", SentSettings.ItemMarketPriceWidth.ToString());
                ManufacturingTabColumnSettingsList[132] = new Setting("ProfitWidth", SentSettings.ProfitWidth.ToString());
                ManufacturingTabColumnSettingsList[133] = new Setting("ProfitPercentageWidth", SentSettings.ProfitPercentageWidth.ToString());
                ManufacturingTabColumnSettingsList[134] = new Setting("IskperHourWidth", SentSettings.IskperHourWidth.ToString());
                ManufacturingTabColumnSettingsList[135] = new Setting("SVRWidth", SentSettings.SVRWidth.ToString());
                ManufacturingTabColumnSettingsList[136] = new Setting("SVRxIPHWidth", SentSettings.SVRxIPHWidth.ToString());
                ManufacturingTabColumnSettingsList[137] = new Setting("PriceTrendWidth", SentSettings.PriceTrendWidth.ToString());
                ManufacturingTabColumnSettingsList[138] = new Setting("TotalItemsSoldWidth", SentSettings.TotalItemsSoldWidth.ToString());
                ManufacturingTabColumnSettingsList[139] = new Setting("TotalOrdersFilledWidth", SentSettings.TotalOrdersFilledWidth.ToString());
                ManufacturingTabColumnSettingsList[140] = new Setting("AvgItemsperOrderWidth", SentSettings.AvgItemsperOrderWidth.ToString());
                ManufacturingTabColumnSettingsList[141] = new Setting("CurrentSellOrdersWidth", SentSettings.CurrentSellOrdersWidth.ToString());
                ManufacturingTabColumnSettingsList[142] = new Setting("CurrentBuyOrdersWidth", SentSettings.CurrentBuyOrdersWidth.ToString());
                ManufacturingTabColumnSettingsList[143] = new Setting("ItemsinProductionWidth", SentSettings.ItemsinProductionWidth.ToString());
                ManufacturingTabColumnSettingsList[144] = new Setting("ItemsinStockWidth", SentSettings.ItemsinStockWidth.ToString());
                ManufacturingTabColumnSettingsList[145] = new Setting("MaterialCostWidth", SentSettings.MaterialCostWidth.ToString());
                ManufacturingTabColumnSettingsList[146] = new Setting("TotalCostWidth", SentSettings.TotalCostWidth.ToString());
                ManufacturingTabColumnSettingsList[147] = new Setting("BaseJobCostWidth", SentSettings.BaseJobCostWidth.ToString());
                ManufacturingTabColumnSettingsList[148] = new Setting("NumBPsWidth", SentSettings.NumBPsWidth.ToString());
                ManufacturingTabColumnSettingsList[149] = new Setting("InventionChanceWidth", SentSettings.InventionChanceWidth.ToString());
                ManufacturingTabColumnSettingsList[150] = new Setting("BPTypeWidth", SentSettings.BPTypeWidth.ToString());
                ManufacturingTabColumnSettingsList[151] = new Setting("RaceWidth", SentSettings.RaceWidth.ToString());
                ManufacturingTabColumnSettingsList[152] = new Setting("VolumeperItemWidth", SentSettings.VolumeperItemWidth.ToString());
                ManufacturingTabColumnSettingsList[153] = new Setting("TotalVolumeWidth", SentSettings.TotalVolumeWidth.ToString());
                ManufacturingTabColumnSettingsList[154] = new Setting("SellExcessWidth", SentSettings.SellExcessWidth.ToString());
                ManufacturingTabColumnSettingsList[155] = new Setting("ROIWidth", SentSettings.ROIWidth.ToString());
                ManufacturingTabColumnSettingsList[156] = new Setting("PortionSizeWidth", SentSettings.PortionSizeWidth.ToString());
                ManufacturingTabColumnSettingsList[157] = new Setting("ManufacturingJobFeeWidth", SentSettings.ManufacturingJobFeeWidth.ToString());
                ManufacturingTabColumnSettingsList[158] = new Setting("ManufacturingFacilityNameWidth", SentSettings.ManufacturingFacilityNameWidth.ToString());
                ManufacturingTabColumnSettingsList[159] = new Setting("ManufacturingFacilitySystemWidth", SentSettings.ManufacturingFacilitySystemWidth.ToString());
                ManufacturingTabColumnSettingsList[160] = new Setting("ManufacturingFacilityRegionWidth", SentSettings.ManufacturingFacilityRegionWidth.ToString());
                ManufacturingTabColumnSettingsList[161] = new Setting("ManufacturingFacilitySystemIndexWidth", SentSettings.ManufacturingFacilitySystemIndexWidth.ToString());
                ManufacturingTabColumnSettingsList[162] = new Setting("ManufacturingFacilityTaxWidth", SentSettings.ManufacturingFacilityTaxWidth.ToString());
                ManufacturingTabColumnSettingsList[163] = new Setting("ManufacturingFacilityMEBonusWidth", SentSettings.ManufacturingFacilityMEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[164] = new Setting("ManufacturingFacilityTEBonusWidth", SentSettings.ManufacturingFacilityTEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[165] = new Setting("ManufacturingFacilityUsageWidth", SentSettings.ManufacturingFacilityUsageWidth.ToString());
                ManufacturingTabColumnSettingsList[166] = new Setting("ManufacturingFacilityFWSystemLevelWidth", SentSettings.ManufacturingFacilityFWSystemLevelWidth.ToString());
                ManufacturingTabColumnSettingsList[167] = new Setting("ComponentFacilityNameWidth", SentSettings.ComponentFacilityNameWidth.ToString());
                ManufacturingTabColumnSettingsList[168] = new Setting("ComponentFacilitySystemWidth", SentSettings.ComponentFacilitySystemWidth.ToString());
                ManufacturingTabColumnSettingsList[169] = new Setting("ComponentFacilityRegionWidth", SentSettings.ComponentFacilityRegionWidth.ToString());
                ManufacturingTabColumnSettingsList[170] = new Setting("ComponentFacilitySystemIndexWidth", SentSettings.ComponentFacilitySystemIndexWidth.ToString());
                ManufacturingTabColumnSettingsList[171] = new Setting("ComponentFacilityTaxWidth", SentSettings.ComponentFacilityTaxWidth.ToString());
                ManufacturingTabColumnSettingsList[172] = new Setting("ComponentFacilityMEBonusWidth", SentSettings.ComponentFacilityMEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[173] = new Setting("ComponentFacilityTEBonusWidth", SentSettings.ComponentFacilityTEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[174] = new Setting("ComponentFacilityUsageWidth", SentSettings.ComponentFacilityUsageWidth.ToString());
                ManufacturingTabColumnSettingsList[175] = new Setting("ComponentFacilityFWSystemLevelWidth", SentSettings.ComponentFacilityFWSystemLevelWidth.ToString());
                ManufacturingTabColumnSettingsList[176] = new Setting("CapComponentFacilityNameWidth", SentSettings.CapComponentFacilityNameWidth.ToString());
                ManufacturingTabColumnSettingsList[177] = new Setting("CapComponentFacilitySystemWidth", SentSettings.CapComponentFacilitySystemWidth.ToString());
                ManufacturingTabColumnSettingsList[178] = new Setting("CapComponentFacilityRegionWidth", SentSettings.CapComponentFacilityRegionWidth.ToString());
                ManufacturingTabColumnSettingsList[179] = new Setting("CapComponentFacilitySystemIndexWidth", SentSettings.CapComponentFacilitySystemIndexWidth.ToString());
                ManufacturingTabColumnSettingsList[180] = new Setting("CapComponentFacilityTaxWidth", SentSettings.CapComponentFacilityTaxWidth.ToString());
                ManufacturingTabColumnSettingsList[181] = new Setting("CapComponentFacilityMEBonusWidth", SentSettings.CapComponentFacilityMEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[182] = new Setting("CapComponentFacilityTEBonusWidth", SentSettings.CapComponentFacilityTEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[183] = new Setting("CapComponentFacilityUsageWidth", SentSettings.CapComponentFacilityUsageWidth.ToString());
                ManufacturingTabColumnSettingsList[184] = new Setting("CapComponentFacilityFWSystemLevelWidth", SentSettings.CapComponentFacilityFWSystemLevelWidth.ToString());
                ManufacturingTabColumnSettingsList[185] = new Setting("CopyingFacilityNameWidth", SentSettings.CopyingFacilityNameWidth.ToString());
                ManufacturingTabColumnSettingsList[186] = new Setting("CopyingFacilitySystemWidth", SentSettings.CopyingFacilitySystemWidth.ToString());
                ManufacturingTabColumnSettingsList[187] = new Setting("CopyingFacilityRegionWidth", SentSettings.CopyingFacilityRegionWidth.ToString());
                ManufacturingTabColumnSettingsList[188] = new Setting("CopyingFacilitySystemIndexWidth", SentSettings.CopyingFacilitySystemIndexWidth.ToString());
                ManufacturingTabColumnSettingsList[189] = new Setting("CopyingFacilityTaxWidth", SentSettings.CopyingFacilityTaxWidth.ToString());
                ManufacturingTabColumnSettingsList[190] = new Setting("CopyingFacilityMEBonusWidth", SentSettings.CopyingFacilityMEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[191] = new Setting("CopyingFacilityTEBonusWidth", SentSettings.CopyingFacilityTEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[192] = new Setting("CopyingFacilityUsageWidth", SentSettings.CopyingFacilityUsageWidth.ToString());
                ManufacturingTabColumnSettingsList[193] = new Setting("CopyingFacilityFWSystemLevelWidth", SentSettings.CopyingFacilityFWSystemLevelWidth.ToString());
                ManufacturingTabColumnSettingsList[194] = new Setting("InventionFacilityNameWidth", SentSettings.InventionFacilityNameWidth.ToString());
                ManufacturingTabColumnSettingsList[195] = new Setting("InventionFacilitySystemWidth", SentSettings.InventionFacilitySystemWidth.ToString());
                ManufacturingTabColumnSettingsList[196] = new Setting("InventionFacilityRegionWidth", SentSettings.InventionFacilityRegionWidth.ToString());
                ManufacturingTabColumnSettingsList[197] = new Setting("InventionFacilitySystemIndexWidth", SentSettings.InventionFacilitySystemIndexWidth.ToString());
                ManufacturingTabColumnSettingsList[198] = new Setting("InventionFacilityTaxWidth", SentSettings.InventionFacilityTaxWidth.ToString());
                ManufacturingTabColumnSettingsList[199] = new Setting("InventionFacilityMEBonusWidth", SentSettings.InventionFacilityMEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[200] = new Setting("InventionFacilityTEBonusWidth", SentSettings.InventionFacilityTEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[201] = new Setting("InventionFacilityUsageWidth", SentSettings.InventionFacilityUsageWidth.ToString());
                ManufacturingTabColumnSettingsList[202] = new Setting("InventionFacilityFWSystemLevelWidth", SentSettings.InventionFacilityFWSystemLevelWidth.ToString());
                ManufacturingTabColumnSettingsList[203] = new Setting("ReactionFacilityNameWidth", SentSettings.ReactionFacilityNameWidth.ToString());
                ManufacturingTabColumnSettingsList[204] = new Setting("ReactionFacilitySystemWidth", SentSettings.ReactionFacilitySystemWidth.ToString());
                ManufacturingTabColumnSettingsList[205] = new Setting("ReactionFacilityRegionWidth", SentSettings.ReactionFacilityRegionWidth.ToString());
                ManufacturingTabColumnSettingsList[206] = new Setting("ReactionFacilitySystemIndexWidth", SentSettings.ReactionFacilitySystemIndexWidth.ToString());
                ManufacturingTabColumnSettingsList[207] = new Setting("ReactionFacilityTaxWidth", SentSettings.ReactionFacilityTaxWidth.ToString());
                ManufacturingTabColumnSettingsList[208] = new Setting("ReactionFacilityMEBonusWidth", SentSettings.ReactionFacilityMEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[209] = new Setting("ReactionFacilityTEBonusWidth", SentSettings.ReactionFacilityTEBonusWidth.ToString());
                ManufacturingTabColumnSettingsList[210] = new Setting("ReactionFacilityUsageWidth", SentSettings.ReactionFacilityUsageWidth.ToString());
                ManufacturingTabColumnSettingsList[211] = new Setting("ReactionFacilityFWSystemLevelWidth", SentSettings.ReactionFacilityFWSystemLevelWidth.ToString());
                ManufacturingTabColumnSettingsList[212] = new Setting("ReprocessingFacilityNameWidth", SentSettings.ReprocessingFacilityNameWidth.ToString());
                ManufacturingTabColumnSettingsList[213] = new Setting("ReprocessingFacilitySystemWidth", SentSettings.ReprocessingFacilitySystemWidth.ToString());
                ManufacturingTabColumnSettingsList[214] = new Setting("ReprocessingFacilityRegionWidth", SentSettings.ReprocessingFacilityRegionWidth.ToString());
                ManufacturingTabColumnSettingsList[215] = new Setting("ReprocessingFacilityTaxWidth", SentSettings.ReprocessingFacilityTaxWidth.ToString());
                ManufacturingTabColumnSettingsList[216] = new Setting("ReprocessingFacilityUsageWidth", SentSettings.ReprocessingFacilityUsageWidth.ToString());
                ManufacturingTabColumnSettingsList[217] = new Setting("ReprocessingFacilityOreRefineRateWidth", SentSettings.ReprocessingFacilityOreRefineRateWidth.ToString());
                ManufacturingTabColumnSettingsList[218] = new Setting("ReprocessingFacilityIceRefineRateWidth", SentSettings.ReprocessingFacilityIceRefineRateWidth.ToString());
                ManufacturingTabColumnSettingsList[219] = new Setting("ReprocessingFacilityMoonRefineRateWidth", SentSettings.ReprocessingFacilityMoonRefineRateWidth.ToString());

                ManufacturingTabColumnSettingsList[220] = new Setting("OrderMTByColumn", SentSettings.OrderByColumn.ToString());
                ManufacturingTabColumnSettingsList[221] = new Setting("OrderMTType", SentSettings.OrderType);

                WriteSettingsToFile(Public_Variables.SettingsFolder, ManufacturingTabColumnSettingsFileName, ManufacturingTabColumnSettingsList, ManufacturingTabColumnSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Industry Jobs Column Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public ManufacturingTabColumnSettings GetManufacturingTabColumnSettings()
        {
            return ManufacturingTabColumnSettings;
        }

        #endregion

        #region Industry Belt Flip

        // Loads the tab settings
        public IndustryFlipBeltSettings LoadIndustryFlipBeltColumnSettings()
        {
            IndustryFlipBeltSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, IndustryFlipBeltSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = IndustryFlipBeltSettingsFileName;
                        string argFileName1 = IndustryFlipBeltSettingsFileName;
                        withBlock.CycleTime = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeDouble, IndustryFlipBeltSettingsFileName, "CycleTime", DefaultCycleTime));
                        string argFileName2 = IndustryFlipBeltSettingsFileName;
                        string argFileName3 = IndustryFlipBeltSettingsFileName;
                        withBlock.m3perCycle = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeDouble, IndustryFlipBeltSettingsFileName, "m3perCycle", Defaultm3perCycle));
                        string argFileName4 = IndustryFlipBeltSettingsFileName;
                        string argFileName5 = IndustryFlipBeltSettingsFileName;
                        withBlock.NumMiners = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeInteger, IndustryFlipBeltSettingsFileName, "NumMiners", DefaultNumMiners));
                        string argFileName6 = IndustryFlipBeltSettingsFileName;
                        string argFileName7 = IndustryFlipBeltSettingsFileName;
                        withBlock.CompressOre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, IndustryFlipBeltSettingsFileName, "CompressOre", DefaultCompressOre));
                        string argFileName8 = IndustryFlipBeltSettingsFileName;
                        string argFileName9 = IndustryFlipBeltSettingsFileName;
                        withBlock.IPHperMiner = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, IndustryFlipBeltSettingsFileName, "IPHperMiner", DefaultIPHperMiner));
                        string argFileName10 = IndustryFlipBeltSettingsFileName;
                        string argFileName11 = IndustryFlipBeltSettingsFileName;
                        withBlock.IncludeBrokerFees = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeInteger, IndustryFlipBeltSettingsFileName, "IncludeBrokerFees", DefaultIncludeBrokerFees));
                        string argFileName12 = IndustryFlipBeltSettingsFileName;
                        string argFileName13 = IndustryFlipBeltSettingsFileName;
                        withBlock.IncludeTaxes = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, IndustryFlipBeltSettingsFileName, "IncludeTaxes", DefaultIncludeTaxes));
                        string argFileName14 = IndustryFlipBeltSettingsFileName;
                        string argFileName15 = IndustryFlipBeltSettingsFileName;
                        withBlock.TrueSec = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeString, IndustryFlipBeltSettingsFileName, "TrueSec", DefaultTruesec));
                        string argFileName16 = BPSettingsFileName;
                        string argFileName17 = BPSettingsFileName;
                        withBlock.BrokerFeeRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeDouble, BPSettingsFileName, "BrokerFeeRate", DefaultBPBrokerFeeRate));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultIndustryFlipBeltSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Industry Flip Belt Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultIndustryFlipBeltSettings();
            }

            // Save them locally and then export
            IndustryFlipBeltsSettings = TempSettings;

            return TempSettings;

        }

        // Loads the Defaults for the tab
        public IndustryFlipBeltSettings SetDefaultIndustryFlipBeltSettings()
        {
            IndustryFlipBeltSettings LocalSettings;

            LocalSettings.CycleTime = DefaultCycleTime;
            LocalSettings.m3perCycle = Defaultm3perCycle;
            LocalSettings.NumMiners = DefaultNumMiners;
            LocalSettings.CompressOre = DefaultCompressOre;
            LocalSettings.IPHperMiner = DefaultIPHperMiner;
            LocalSettings.IncludeBrokerFees = DefaultIncludeBrokerFees;
            LocalSettings.BrokerFeeRate = DefaultBFBrokerFeeRate;
            LocalSettings.IncludeTaxes = DefaultIncludeTaxes;
            LocalSettings.TrueSec = DefaultTruesec;

            // Save locally
            IndustryFlipBeltsSettings = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveIndustryFlipBeltSettings(IndustryFlipBeltSettings SentSettings)
        {
            var IndustryFlipBeltSettingsList = new Setting[9];

            try
            {
                IndustryFlipBeltSettingsList[0] = new Setting("CycleTime", SentSettings.CycleTime.ToString());
                IndustryFlipBeltSettingsList[1] = new Setting("m3perCycle", SentSettings.m3perCycle.ToString());
                IndustryFlipBeltSettingsList[2] = new Setting("NumMiners", SentSettings.NumMiners.ToString());
                IndustryFlipBeltSettingsList[3] = new Setting("CompressedOre", Conversions.ToString(SentSettings.CompressOre));
                IndustryFlipBeltSettingsList[4] = new Setting("IPHperMiner", Conversions.ToString(SentSettings.IPHperMiner));
                IndustryFlipBeltSettingsList[5] = new Setting("IncludeBrokerFees", SentSettings.IncludeBrokerFees.ToString());
                IndustryFlipBeltSettingsList[6] = new Setting("IncludeTaxes", Conversions.ToString(SentSettings.IncludeTaxes));
                IndustryFlipBeltSettingsList[7] = new Setting("TrueSec", SentSettings.TrueSec);
                IndustryFlipBeltSettingsList[8] = new Setting("BrokerFeeRate", SentSettings.BrokerFeeRate.ToString());

                WriteSettingsToFile(Public_Variables.SettingsFolder, IndustryFlipBeltSettingsFileName, IndustryFlipBeltSettingsList, IndustryFlipBeltSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Industry Flip Belt Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public IndustryFlipBeltSettings GetIndustryFlipBeltSettings()
        {
            return IndustryFlipBeltsSettings;
        }

        #endregion

        #region Ice Belt Flip

        // Loads the tab settings
        public IceBeltFlipSettings LoadIceFlipBeltColumnSettings()
        {
            IceBeltFlipSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, IceBeltFlipSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = IceBeltFlipSettingsFileName;
                        string argFileName1 = IceBeltFlipSettingsFileName;
                        withBlock.CycleTime = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeDouble, IceBeltFlipSettingsFileName, "CycleTime", DefaultCycleTime));
                        string argFileName2 = IceBeltFlipSettingsFileName;
                        string argFileName3 = IceBeltFlipSettingsFileName;
                        withBlock.m3perCycle = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeDouble, IceBeltFlipSettingsFileName, "m3perCycle", Defaultm3perCycle));
                        string argFileName4 = IceBeltFlipSettingsFileName;
                        string argFileName5 = IceBeltFlipSettingsFileName;
                        withBlock.NumMiners = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeInteger, IceBeltFlipSettingsFileName, "NumMiners", DefaultNumMiners));
                        string argFileName6 = IceBeltFlipSettingsFileName;
                        string argFileName7 = IceBeltFlipSettingsFileName;
                        withBlock.CompressOre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, IceBeltFlipSettingsFileName, "CompressOre", DefaultCompressOre));
                        string argFileName8 = IceBeltFlipSettingsFileName;
                        string argFileName9 = IceBeltFlipSettingsFileName;
                        withBlock.IPHperMiner = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, IceBeltFlipSettingsFileName, "IPHperMiner", DefaultIPHperMiner));
                        string argFileName10 = IceBeltFlipSettingsFileName;
                        string argFileName11 = IceBeltFlipSettingsFileName;
                        withBlock.IncludeBrokerFees = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeInteger, IceBeltFlipSettingsFileName, "IncludeBrokerFees", DefaultIncludeBrokerFees));
                        string argFileName12 = IceBeltFlipSettingsFileName;
                        string argFileName13 = IceBeltFlipSettingsFileName;
                        withBlock.IncludeTaxes = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, IceBeltFlipSettingsFileName, "IncludeTaxes", DefaultIncludeTaxes));
                        string argFileName14 = IceBeltFlipSettingsFileName;
                        string argFileName15 = IceBeltFlipSettingsFileName;
                        withBlock.SystemSecurity = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeString, IceBeltFlipSettingsFileName, "SystemSecurity", DefaultTruesec));
                        string argFileName16 = BPSettingsFileName;
                        string argFileName17 = BPSettingsFileName;
                        withBlock.BrokerFeeRate = Conversions.ToDouble(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeDouble, BPSettingsFileName, "BrokerFeeRate", DefaultBPBrokerFeeRate));
                        string argFileName18 = IceBeltFlipSettingsFileName;
                        string argFileName19 = IceBeltFlipSettingsFileName;
                        withBlock.Space = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeString, IceBeltFlipSettingsFileName, "Space", DefaultSpace));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultIceBeltFlipSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Ice Flip Belt Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultIceBeltFlipSettings();
            }

            // Save them locally and then export
            IceBeltFlipSetting = TempSettings;

            return TempSettings;

        }

        // Loads the Defaults for the tab
        public IceBeltFlipSettings SetDefaultIceBeltFlipSettings()
        {
            IceBeltFlipSettings LocalSettings;

            LocalSettings.CycleTime = DefaultCycleTime;
            LocalSettings.m3perCycle = Defaultm3perCycle;
            LocalSettings.NumMiners = DefaultNumMiners;
            LocalSettings.CompressOre = DefaultCompressOre;
            LocalSettings.IPHperMiner = DefaultIPHperMiner;
            LocalSettings.IncludeBrokerFees = DefaultIncludeBrokerFees;
            LocalSettings.BrokerFeeRate = DefaultBFBrokerFeeRate;
            LocalSettings.IncludeTaxes = DefaultIncludeTaxes;
            LocalSettings.SystemSecurity = DefaultTruesec;
            LocalSettings.Space = DefaultSpace;

            // Save locally
            IceBeltFlipSetting = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveIceBeltFlipSettings(IceBeltFlipSettings SentSettings)
        {
            var IceBeltFlipSettingsList = new Setting[9];

            try
            {
                IceBeltFlipSettingsList[0] = new Setting("CycleTime", SentSettings.CycleTime.ToString());
                IceBeltFlipSettingsList[1] = new Setting("m3perCycle", SentSettings.m3perCycle.ToString());
                IceBeltFlipSettingsList[2] = new Setting("NumMiners", SentSettings.NumMiners.ToString());
                IceBeltFlipSettingsList[3] = new Setting("CompressedOre", Conversions.ToString(SentSettings.CompressOre));
                IceBeltFlipSettingsList[4] = new Setting("IPHperMiner", Conversions.ToString(SentSettings.IPHperMiner));
                IceBeltFlipSettingsList[5] = new Setting("IncludeBrokerFees", SentSettings.IncludeBrokerFees.ToString());
                IceBeltFlipSettingsList[6] = new Setting("IncludeTaxes", Conversions.ToString(SentSettings.IncludeTaxes));
                IceBeltFlipSettingsList[7] = new Setting("SystemSecurity", SentSettings.SystemSecurity);
                IceBeltFlipSettingsList[8] = new Setting("BrokerFeeRate", SentSettings.BrokerFeeRate.ToString());

                WriteSettingsToFile(Public_Variables.SettingsFolder, IceBeltFlipSettingsFileName, IceBeltFlipSettingsList, IceBeltFlipSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Ice Flip Belt Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public IceBeltFlipSettings GetIceBeltFlipSettings()
        {
            return IceBeltFlipSetting;
        }

        #endregion

        #region Industry Belt Ore Checks

        // Loads the tab settings
        public IndustryBeltOreChecks LoadIndustryBeltOreChecksSettings(Public_Variables.BeltType Belt)
        {
            IndustryBeltOreChecks TempSettings = default;

            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName1;
                        break;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName2;
                        break;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName3;
                        break;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName4;
                        break;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName5;
                        break;
                    }
            }

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, IndustryBeltOreChecksFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        withBlock.Plagioclase = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Plagioclase", DefaultPlagioclase));
                        withBlock.Spodumain = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Spodumain", DefaultSpodumain));
                        withBlock.Kernite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Kernite", DefaultKernite));
                        withBlock.Hedbergite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Hedbergite", DefaultHedbergite));
                        withBlock.Arkonor = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Arkonor", DefaultArkonor));
                        withBlock.Bistot = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Bistot", DefaultBistot));
                        withBlock.Pyroxeres = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Pyroxeres", DefaultPyroxeres));
                        withBlock.Crokite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Crokite", DefaultCrokite));
                        withBlock.Jaspet = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Jaspet", DefaultJaspet));
                        withBlock.Omber = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Omber", DefaultOmber));
                        withBlock.Scordite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Scordite", DefaultScordite));
                        withBlock.Gneiss = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Gneiss", DefaultGneiss));
                        withBlock.Veldspar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Veldspar", DefaultVeldspar));
                        withBlock.Hemorphite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Hemorphite", DefaultHemorphite));
                        withBlock.DarkOchre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "DarkOchre", DefaultDarkOchre));
                        withBlock.Mercoxit = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "Mercoxit", DefaultMercoxit));
                        withBlock.CrimsonArkonor = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "CrimsonArkonor", DefaultCrimsonArkonor));
                        withBlock.PrimeArkonor = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "PrimeArkonor", DefaultPrimeArkonor));
                        withBlock.TriclinicBistot = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "TriclinicBistot", DefaultTriclinicBistot));
                        withBlock.MonoclinicBistot = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "MonoclinicBistot", DefaultMonoclinicBistot));
                        withBlock.SharpCrokite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "SharpCrokite", DefaultSharpCrokite));
                        withBlock.CrystallineCrokite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "CrystallineCrokite", DefaultCrystallineCrokite));
                        withBlock.OnyxOchre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "OnyxOchre", DefaultOnyxOchre));
                        withBlock.ObsidianOchre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "ObsidianOchre", DefaultObsidianOchre));
                        withBlock.VitricHedbergite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "VitricHedbergite", DefaultVitricHedbergite));
                        withBlock.GlazedHedbergite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "GlazedHedbergite", DefaultGlazedHedbergite));
                        withBlock.VividHemorphite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "VividHemorphite", DefaultVividHemorphite));
                        withBlock.RadiantHemorphite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "RadiantHemorphite", DefaultRadiantHemorphite));
                        withBlock.PureJaspet = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "PureJaspet", DefaultPureJaspet));
                        withBlock.PristineJaspet = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "PristineJaspet", DefaultPristineJaspet));
                        withBlock.LuminousKernite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "LuminousKernite", DefaultLuminousKernite));
                        withBlock.FieryKernite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "FieryKernite", DefaultFieryKernite));
                        withBlock.AzurePlagioclase = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "AzurePlagioclase", DefaultAzurePlagioclase));
                        withBlock.RichPlagioclase = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "RichPlagioclase", DefaultRichPlagioclase));
                        withBlock.SolidPyroxeres = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "SolidPyroxeres", DefaultSolidPyroxeres));
                        withBlock.ViscousPyroxeres = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "ViscousPyroxeres", DefaultViscousPyroxeres));
                        withBlock.CondensedScordite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "CondensedScordite", DefaultCondensedScordite));
                        withBlock.MassiveScordite = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "MassiveScordite", DefaultMassiveScordite));
                        withBlock.BrightSpodumain = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "BrightSpodumain", DefaultBrightSpodumain));
                        withBlock.GleamingSpodumain = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "GleamingSpodumain", DefaultGleamingSpodumain));
                        withBlock.ConcentratedVeldspar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "ConcentratedVeldspar", DefaultConcentratedVeldspar));
                        withBlock.DenseVeldspar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "DenseVeldspar", DefaultDenseVeldspar));
                        withBlock.IridescentGneiss = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "IridescentGneiss", DefaultIridescentGneiss));
                        withBlock.PrismaticGneiss = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "PrismaticGneiss", DefaultPrismaticGneiss));
                        withBlock.SilveryOmber = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "SilveryOmber", DefaultSilveryOmber));
                        withBlock.GoldenOmber = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "GoldenOmber", DefaultGoldenOmber));
                        withBlock.MagmaMercoxit = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "MagmaMercoxit", DefaultMagmaMercoxit));
                        withBlock.VitreousMercoxit = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref IndustryBeltOreChecksFileName, SettingTypes.TypeBoolean, IndustryBeltOreChecksFileName, "VitreousMercoxit", DefaultVitreousMercoxit));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultIndustryBeltOreChecksSettings(Belt);
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Industry Flip Belt Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultIndustryBeltOreChecksSettings(Belt);
            }

            // Save them locally and then export
            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        IndustryBeltOreChecksSettings1 = TempSettings;
                        break;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        IndustryBeltOreChecksSettings2 = TempSettings;
                        break;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        IndustryBeltOreChecksSettings3 = TempSettings;
                        break;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        IndustryBeltOreChecksSettings4 = TempSettings;
                        break;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        IndustryBeltOreChecksSettings5 = TempSettings;
                        break;
                    }
            }

            return TempSettings;

        }

        // Loads the Defaults for the tab
        public IndustryBeltOreChecks SetDefaultIndustryBeltOreChecksSettings(Public_Variables.BeltType Belt)
        {
            IndustryBeltOreChecks LocalSettings;

            LocalSettings.Plagioclase = DefaultPlagioclase;
            LocalSettings.Spodumain = DefaultSpodumain;
            LocalSettings.Kernite = DefaultKernite;
            LocalSettings.Hedbergite = DefaultHedbergite;
            LocalSettings.Arkonor = DefaultArkonor;
            LocalSettings.Bistot = DefaultBistot;
            LocalSettings.Pyroxeres = DefaultPyroxeres;
            LocalSettings.Crokite = DefaultCrokite;
            LocalSettings.Jaspet = DefaultJaspet;
            LocalSettings.Omber = DefaultOmber;
            LocalSettings.Scordite = DefaultScordite;
            LocalSettings.Gneiss = DefaultGneiss;
            LocalSettings.Veldspar = DefaultVeldspar;
            LocalSettings.Hemorphite = DefaultHemorphite;
            LocalSettings.DarkOchre = DefaultDarkOchre;
            LocalSettings.Mercoxit = DefaultMercoxit;
            LocalSettings.CrimsonArkonor = DefaultCrimsonArkonor;
            LocalSettings.PrimeArkonor = DefaultPrimeArkonor;
            LocalSettings.TriclinicBistot = DefaultTriclinicBistot;
            LocalSettings.MonoclinicBistot = DefaultMonoclinicBistot;
            LocalSettings.SharpCrokite = DefaultSharpCrokite;
            LocalSettings.CrystallineCrokite = DefaultCrystallineCrokite;
            LocalSettings.OnyxOchre = DefaultOnyxOchre;
            LocalSettings.ObsidianOchre = DefaultObsidianOchre;
            LocalSettings.VitricHedbergite = DefaultVitricHedbergite;
            LocalSettings.GlazedHedbergite = DefaultGlazedHedbergite;
            LocalSettings.VividHemorphite = DefaultVividHemorphite;
            LocalSettings.RadiantHemorphite = DefaultRadiantHemorphite;
            LocalSettings.PureJaspet = DefaultPureJaspet;
            LocalSettings.PristineJaspet = DefaultPristineJaspet;
            LocalSettings.LuminousKernite = DefaultLuminousKernite;
            LocalSettings.FieryKernite = DefaultFieryKernite;
            LocalSettings.AzurePlagioclase = DefaultAzurePlagioclase;
            LocalSettings.RichPlagioclase = DefaultRichPlagioclase;
            LocalSettings.SolidPyroxeres = DefaultSolidPyroxeres;
            LocalSettings.ViscousPyroxeres = DefaultViscousPyroxeres;
            LocalSettings.CondensedScordite = DefaultCondensedScordite;
            LocalSettings.MassiveScordite = DefaultMassiveScordite;
            LocalSettings.BrightSpodumain = DefaultBrightSpodumain;
            LocalSettings.GleamingSpodumain = DefaultGleamingSpodumain;
            LocalSettings.ConcentratedVeldspar = DefaultConcentratedVeldspar;
            LocalSettings.DenseVeldspar = DefaultDenseVeldspar;
            LocalSettings.IridescentGneiss = DefaultIridescentGneiss;
            LocalSettings.PrismaticGneiss = DefaultPrismaticGneiss;
            LocalSettings.SilveryOmber = DefaultSilveryOmber;
            LocalSettings.GoldenOmber = DefaultGoldenOmber;
            LocalSettings.MagmaMercoxit = DefaultMagmaMercoxit;
            LocalSettings.VitreousMercoxit = DefaultVitreousMercoxit;

            // Save locally
            // Save them locally and then export
            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        IndustryBeltOreChecksSettings1 = LocalSettings;
                        break;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        IndustryBeltOreChecksSettings2 = LocalSettings;
                        break;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        IndustryBeltOreChecksSettings3 = LocalSettings;
                        break;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        IndustryBeltOreChecksSettings4 = LocalSettings;
                        break;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        IndustryBeltOreChecksSettings5 = LocalSettings;
                        break;
                    }
            }

            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveIndustryBeltOreChecksSettings(IndustryBeltOreChecks SentSettings, Public_Variables.BeltType Belt)
        {
            var IndustryBeltOreChecksList = new Setting[48];

            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName1;
                        break;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName2;
                        break;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName3;
                        break;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName4;
                        break;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        IndustryBeltOreChecksFileName = IndustryBeltOreChecksBaseFileName + IndustryBeltOreChecksFileName5;
                        break;
                    }
            }

            try
            {
                IndustryBeltOreChecksList[0] = new Setting("Plagioclase", Conversions.ToString(SentSettings.Plagioclase));
                IndustryBeltOreChecksList[1] = new Setting("Spodumain", Conversions.ToString(SentSettings.Spodumain));
                IndustryBeltOreChecksList[2] = new Setting("Kernite", Conversions.ToString(SentSettings.Kernite));
                IndustryBeltOreChecksList[3] = new Setting("Hedbergite", Conversions.ToString(SentSettings.Hedbergite));
                IndustryBeltOreChecksList[4] = new Setting("Arkonor", Conversions.ToString(SentSettings.Arkonor));
                IndustryBeltOreChecksList[5] = new Setting("Bistot", Conversions.ToString(SentSettings.Bistot));
                IndustryBeltOreChecksList[6] = new Setting("Pyroxeres", Conversions.ToString(SentSettings.Pyroxeres));
                IndustryBeltOreChecksList[7] = new Setting("Crokite", Conversions.ToString(SentSettings.Crokite));
                IndustryBeltOreChecksList[8] = new Setting("Jaspet", Conversions.ToString(SentSettings.Jaspet));
                IndustryBeltOreChecksList[9] = new Setting("Omber", Conversions.ToString(SentSettings.Omber));
                IndustryBeltOreChecksList[10] = new Setting("Scordite", Conversions.ToString(SentSettings.Scordite));
                IndustryBeltOreChecksList[11] = new Setting("Gneiss", Conversions.ToString(SentSettings.Gneiss));
                IndustryBeltOreChecksList[12] = new Setting("Veldspar", Conversions.ToString(SentSettings.Veldspar));
                IndustryBeltOreChecksList[13] = new Setting("Hemorphite", Conversions.ToString(SentSettings.Hemorphite));
                IndustryBeltOreChecksList[14] = new Setting("DarkOchre", Conversions.ToString(SentSettings.DarkOchre));
                IndustryBeltOreChecksList[15] = new Setting("Mercoxit", Conversions.ToString(SentSettings.Mercoxit));
                IndustryBeltOreChecksList[16] = new Setting("CrimsonArkonor", Conversions.ToString(SentSettings.CrimsonArkonor));
                IndustryBeltOreChecksList[17] = new Setting("PrimeArkonor", Conversions.ToString(SentSettings.PrimeArkonor));
                IndustryBeltOreChecksList[18] = new Setting("TriclinicBistot", Conversions.ToString(SentSettings.TriclinicBistot));
                IndustryBeltOreChecksList[19] = new Setting("MonoclinicBistot", Conversions.ToString(SentSettings.MonoclinicBistot));
                IndustryBeltOreChecksList[20] = new Setting("SharpCrokite", Conversions.ToString(SentSettings.SharpCrokite));
                IndustryBeltOreChecksList[21] = new Setting("CrystallineCrokite", Conversions.ToString(SentSettings.CrystallineCrokite));
                IndustryBeltOreChecksList[22] = new Setting("OnyxOchre", Conversions.ToString(SentSettings.OnyxOchre));
                IndustryBeltOreChecksList[23] = new Setting("ObsidianOchre", Conversions.ToString(SentSettings.ObsidianOchre));
                IndustryBeltOreChecksList[24] = new Setting("VitricHedbergite", Conversions.ToString(SentSettings.VitricHedbergite));
                IndustryBeltOreChecksList[25] = new Setting("GlazedHedbergite", Conversions.ToString(SentSettings.GlazedHedbergite));
                IndustryBeltOreChecksList[26] = new Setting("VividHemorphite", Conversions.ToString(SentSettings.VividHemorphite));
                IndustryBeltOreChecksList[27] = new Setting("RadiantHemorphite", Conversions.ToString(SentSettings.RadiantHemorphite));
                IndustryBeltOreChecksList[28] = new Setting("PureJaspet", Conversions.ToString(SentSettings.PureJaspet));
                IndustryBeltOreChecksList[29] = new Setting("PristineJaspet", Conversions.ToString(SentSettings.PristineJaspet));
                IndustryBeltOreChecksList[30] = new Setting("LuminousKernite", Conversions.ToString(SentSettings.LuminousKernite));
                IndustryBeltOreChecksList[31] = new Setting("FieryKernite", Conversions.ToString(SentSettings.FieryKernite));
                IndustryBeltOreChecksList[32] = new Setting("AzurePlagioclase", Conversions.ToString(SentSettings.AzurePlagioclase));
                IndustryBeltOreChecksList[33] = new Setting("RichPlagioclase", Conversions.ToString(SentSettings.RichPlagioclase));
                IndustryBeltOreChecksList[34] = new Setting("SolidPyroxeres", Conversions.ToString(SentSettings.SolidPyroxeres));
                IndustryBeltOreChecksList[35] = new Setting("ViscousPyroxeres", Conversions.ToString(SentSettings.ViscousPyroxeres));
                IndustryBeltOreChecksList[36] = new Setting("CondensedScordite", Conversions.ToString(SentSettings.CondensedScordite));
                IndustryBeltOreChecksList[37] = new Setting("MassiveScordite", Conversions.ToString(SentSettings.MassiveScordite));
                IndustryBeltOreChecksList[38] = new Setting("BrightSpodumain", Conversions.ToString(SentSettings.BrightSpodumain));
                IndustryBeltOreChecksList[39] = new Setting("GleamingSpodumain", Conversions.ToString(SentSettings.GleamingSpodumain));
                IndustryBeltOreChecksList[40] = new Setting("ConcentratedVeldspar", Conversions.ToString(SentSettings.ConcentratedVeldspar));
                IndustryBeltOreChecksList[41] = new Setting("DenseVeldspar", Conversions.ToString(SentSettings.DenseVeldspar));
                IndustryBeltOreChecksList[42] = new Setting("IridescentGneiss", Conversions.ToString(SentSettings.IridescentGneiss));
                IndustryBeltOreChecksList[43] = new Setting("PrismaticGneiss", Conversions.ToString(SentSettings.PrismaticGneiss));
                IndustryBeltOreChecksList[44] = new Setting("SilveryOmber", Conversions.ToString(SentSettings.SilveryOmber));
                IndustryBeltOreChecksList[45] = new Setting("GoldenOmber", Conversions.ToString(SentSettings.GoldenOmber));
                IndustryBeltOreChecksList[46] = new Setting("MagmaMercoxit", Conversions.ToString(SentSettings.MagmaMercoxit));
                IndustryBeltOreChecksList[47] = new Setting("VitreousMercoxit", Conversions.ToString(SentSettings.VitreousMercoxit));

                WriteSettingsToFile(Public_Variables.SettingsFolder, IndustryBeltOreChecksFileName, IndustryBeltOreChecksList, IndustryBeltOreChecksFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Industry Flip Belt Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public IndustryBeltOreChecks GetIndustryBeltOreChecksSettings(Public_Variables.BeltType Belt)
        {
            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        return IndustryBeltOreChecksSettings1;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        return IndustryBeltOreChecksSettings2;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        return IndustryBeltOreChecksSettings3;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        return IndustryBeltOreChecksSettings4;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        return IndustryBeltOreChecksSettings5;
                    }
            }

            return default;
        }

        #endregion

        #region Ice Belt Ore Checks

        // Loads the tab settings
        public IceBeltCheckSettings LoadIceBeltOreChecksSettings()
        {
            IceBeltCheckSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, IceBeltFlipCheckSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = IceBeltFlipCheckSettingsFileName;
                        string argFileName1 = IceBeltFlipCheckSettingsFileName;
                        withBlock.BlueIce = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "BlueIce", DefaultBlueIce));
                        string argFileName2 = IceBeltFlipCheckSettingsFileName;
                        string argFileName3 = IceBeltFlipCheckSettingsFileName;
                        withBlock.ClearIcicle = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "ClearIcicle", DefaultClearIcicle));
                        string argFileName4 = IceBeltFlipCheckSettingsFileName;
                        string argFileName5 = IceBeltFlipCheckSettingsFileName;
                        withBlock.DarkGlitter = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "DarkGlitter", DefaultDarkGlitter));
                        string argFileName6 = IceBeltFlipCheckSettingsFileName;
                        string argFileName7 = IceBeltFlipCheckSettingsFileName;
                        withBlock.EnrichedClearIcicle = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "EnrichedClearIcicle", DefaultEnrichedClearIcicle));
                        string argFileName8 = IceBeltFlipCheckSettingsFileName;
                        string argFileName9 = IceBeltFlipCheckSettingsFileName;
                        withBlock.Gelidus = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "Gelidus", DefaultGelidus));
                        string argFileName10 = IceBeltFlipCheckSettingsFileName;
                        string argFileName11 = IceBeltFlipCheckSettingsFileName;
                        withBlock.GlacialMass = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "GlacialMass", DefaultGlacialMass));
                        string argFileName12 = IceBeltFlipCheckSettingsFileName;
                        string argFileName13 = IceBeltFlipCheckSettingsFileName;
                        withBlock.GlareCrust = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "GlareCrust", DefaultGlareCrust));
                        string argFileName14 = IceBeltFlipCheckSettingsFileName;
                        string argFileName15 = IceBeltFlipCheckSettingsFileName;
                        withBlock.Krystallos = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "Krystallos", DefaultKrystallos));
                        string argFileName16 = IceBeltFlipCheckSettingsFileName;
                        string argFileName17 = IceBeltFlipCheckSettingsFileName;
                        withBlock.PristineWhiteGlaze = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "PristineWhiteGlaze", DefaultPristineWhiteGlaze));
                        string argFileName18 = IceBeltFlipCheckSettingsFileName;
                        string argFileName19 = IceBeltFlipCheckSettingsFileName;
                        withBlock.SmoothGlacialMass = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "SmoothGlacialMass", DefaultSmoothGlacialMass));
                        string argFileName20 = IceBeltFlipCheckSettingsFileName;
                        string argFileName21 = IceBeltFlipCheckSettingsFileName;
                        withBlock.ThickBlueIce = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "ThickBlueIce", DefaultThickBlueIce));
                        string argFileName22 = IceBeltFlipCheckSettingsFileName;
                        string argFileName23 = IceBeltFlipCheckSettingsFileName;
                        withBlock.WhiteGlaze = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "WhiteGlaze", DefaultWhiteGlaze));

                        string argFileName24 = IceBeltFlipCheckSettingsFileName;
                        string argFileName25 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedBlueIce = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedBlueIce", DefaultCompressedBlueIce));
                        string argFileName26 = IceBeltFlipCheckSettingsFileName;
                        string argFileName27 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedClearIcicle = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedClearIcicle", DefaultCompressedClearIcicle));
                        string argFileName28 = IceBeltFlipCheckSettingsFileName;
                        string argFileName29 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedDarkGlitter = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedDarkGlitter", DefaultCompressedDarkGlitter));
                        string argFileName30 = IceBeltFlipCheckSettingsFileName;
                        string argFileName31 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedEnrichedClearIcicle = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedEnrichedClearIcicle", DefaultCompressedEnrichedClearIcicle));
                        string argFileName32 = IceBeltFlipCheckSettingsFileName;
                        string argFileName33 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedGelidus = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedGelidus", DefaultCompressedGelidus));
                        string argFileName34 = IceBeltFlipCheckSettingsFileName;
                        string argFileName35 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedGlacialMass = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedGlacialMass", DefaultCompressedGlacialMass));
                        string argFileName36 = IceBeltFlipCheckSettingsFileName;
                        string argFileName37 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedGlareCrust = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedGlareCrust", DefaultCompressedGlareCrust));
                        string argFileName38 = IceBeltFlipCheckSettingsFileName;
                        string argFileName39 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedKrystallos = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedKrystallos", DefaultCompressedKrystallos));
                        string argFileName40 = IceBeltFlipCheckSettingsFileName;
                        string argFileName41 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedPristineWhiteGlaze = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedPristineWhiteGlaze", DefaultCompressedPristineWhiteGlaze));
                        string argFileName42 = IceBeltFlipCheckSettingsFileName;
                        string argFileName43 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedSmoothGlacialMass = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedSmoothGlacialMass", DefaultCompressedSmoothGlacialMass));
                        string argFileName44 = IceBeltFlipCheckSettingsFileName;
                        string argFileName45 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedThickBlueIce = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName45, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedThickBlueIce", DefaultCompressedThickBlueIce));
                        string argFileName46 = IceBeltFlipCheckSettingsFileName;
                        string argFileName47 = IceBeltFlipCheckSettingsFileName;
                        withBlock.CompressedWhiteGlaze = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName47, SettingTypes.TypeBoolean, IceBeltFlipCheckSettingsFileName, "CompressedWhiteGlaze", DefaultCompressedWhiteGlaze));

                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultIceBeltChecksSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Ice Flip Belt Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultIceBeltChecksSettings();
            }

            // Save them locally and then export
            IceBeltCheckSetting = TempSettings;

            return TempSettings;

        }

        // Loads the Defaults for the tab
        public IceBeltCheckSettings SetDefaultIceBeltChecksSettings()
        {
            IceBeltCheckSettings LocalSettings;

            LocalSettings.BlueIce = DefaultBlueIce;
            LocalSettings.ClearIcicle = DefaultClearIcicle;
            LocalSettings.DarkGlitter = DefaultDarkGlitter;
            LocalSettings.EnrichedClearIcicle = DefaultEnrichedClearIcicle;
            LocalSettings.Gelidus = DefaultGelidus;
            LocalSettings.GlacialMass = DefaultGlacialMass;
            LocalSettings.GlareCrust = DefaultGlareCrust;
            LocalSettings.Krystallos = DefaultKrystallos;
            LocalSettings.PristineWhiteGlaze = DefaultPristineWhiteGlaze;
            LocalSettings.SmoothGlacialMass = DefaultSmoothGlacialMass;
            LocalSettings.ThickBlueIce = DefaultThickBlueIce;
            LocalSettings.WhiteGlaze = DefaultWhiteGlaze;
            LocalSettings.CompressedBlueIce = DefaultCompressedBlueIce;
            LocalSettings.CompressedClearIcicle = DefaultCompressedClearIcicle;
            LocalSettings.CompressedDarkGlitter = DefaultCompressedDarkGlitter;
            LocalSettings.CompressedEnrichedClearIcicle = DefaultCompressedEnrichedClearIcicle;
            LocalSettings.CompressedGelidus = DefaultCompressedGelidus;
            LocalSettings.CompressedGlacialMass = DefaultCompressedGlacialMass;
            LocalSettings.CompressedGlareCrust = DefaultCompressedGlareCrust;
            LocalSettings.CompressedKrystallos = DefaultCompressedKrystallos;
            LocalSettings.CompressedPristineWhiteGlaze = DefaultCompressedPristineWhiteGlaze;
            LocalSettings.CompressedSmoothGlacialMass = DefaultCompressedSmoothGlacialMass;
            LocalSettings.CompressedThickBlueIce = DefaultCompressedThickBlueIce;
            LocalSettings.CompressedWhiteGlaze = DefaultCompressedWhiteGlaze;

            // Save Locally
            IceBeltCheckSetting = LocalSettings;

            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveIceBeltChecksSettings(IceBeltCheckSettings SentSettings)
        {
            var IceBeltOreChecksList = new Setting[24];

            try
            {
                IceBeltOreChecksList[0] = new Setting("BlueIce", Conversions.ToString(SentSettings.BlueIce));
                IceBeltOreChecksList[1] = new Setting("ClearIcicle", Conversions.ToString(SentSettings.ClearIcicle));
                IceBeltOreChecksList[2] = new Setting("DarkGlitter", Conversions.ToString(SentSettings.DarkGlitter));
                IceBeltOreChecksList[3] = new Setting("EnrichedClearIcicle", Conversions.ToString(SentSettings.EnrichedClearIcicle));
                IceBeltOreChecksList[4] = new Setting("Gelidus", Conversions.ToString(SentSettings.Gelidus));
                IceBeltOreChecksList[5] = new Setting("GlacialMass", Conversions.ToString(SentSettings.GlacialMass));
                IceBeltOreChecksList[6] = new Setting("GlareCrust", Conversions.ToString(SentSettings.GlareCrust));
                IceBeltOreChecksList[7] = new Setting("Krystallos", Conversions.ToString(SentSettings.Krystallos));
                IceBeltOreChecksList[8] = new Setting("PristineWhiteGlaze", Conversions.ToString(SentSettings.PristineWhiteGlaze));
                IceBeltOreChecksList[9] = new Setting("SmoothGlacialMass", Conversions.ToString(SentSettings.SmoothGlacialMass));
                IceBeltOreChecksList[10] = new Setting("ThickBlueIce", Conversions.ToString(SentSettings.ThickBlueIce));
                IceBeltOreChecksList[11] = new Setting("WhiteGlaze", Conversions.ToString(SentSettings.WhiteGlaze));

                IceBeltOreChecksList[12] = new Setting("CompressedBlueIce", Conversions.ToString(SentSettings.CompressedBlueIce));
                IceBeltOreChecksList[13] = new Setting("CompressedClearIcicle", Conversions.ToString(SentSettings.CompressedClearIcicle));
                IceBeltOreChecksList[14] = new Setting("CompressedDarkGlitter", Conversions.ToString(SentSettings.CompressedDarkGlitter));
                IceBeltOreChecksList[15] = new Setting("CompressedEnrichedClearIcicle", Conversions.ToString(SentSettings.CompressedEnrichedClearIcicle));
                IceBeltOreChecksList[16] = new Setting("CompressedGelidus", Conversions.ToString(SentSettings.CompressedGelidus));
                IceBeltOreChecksList[17] = new Setting("CompressedGlacialMass", Conversions.ToString(SentSettings.CompressedGlacialMass));
                IceBeltOreChecksList[18] = new Setting("CompressedGlareCrust", Conversions.ToString(SentSettings.CompressedGlareCrust));
                IceBeltOreChecksList[19] = new Setting("CompressedKrystallos", Conversions.ToString(SentSettings.CompressedKrystallos));
                IceBeltOreChecksList[20] = new Setting("CompressedPristineWhiteGlaze", Conversions.ToString(SentSettings.CompressedPristineWhiteGlaze));
                IceBeltOreChecksList[21] = new Setting("CompressedSmoothGlacialMass", Conversions.ToString(SentSettings.CompressedSmoothGlacialMass));
                IceBeltOreChecksList[22] = new Setting("CompressedThickBlueIce", Conversions.ToString(SentSettings.CompressedThickBlueIce));
                IceBeltOreChecksList[23] = new Setting("CompressedWhiteGlaze", Conversions.ToString(SentSettings.CompressedWhiteGlaze));

                WriteSettingsToFile(Public_Variables.SettingsFolder, IceBeltFlipCheckSettingsFileName, IceBeltOreChecksList, IceBeltFlipCheckSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Ice Flip Belt Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public IceBeltCheckSettings GetIceBeltOreChecksSettings(Public_Variables.BeltType Belt)
        {
            return IceBeltCheckSetting;
        }

        #endregion

        #region Conversion to Ore

        // Loads the tab settings
        public ConversionToOreSettings LoadConversiontoOreSettings()
        {
            ConversionToOreSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, ConvertToOreSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = ConvertToOreSettingsFileName;
                        string argFileName1 = ConvertToOreSettingsFileName;
                        withBlock.ConversionType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeString, ConvertToOreSettingsFileName, "ConversionType", DefaultConversionType));
                        string argFileName2 = ConvertToOreSettingsFileName;
                        string argFileName3 = ConvertToOreSettingsFileName;
                        withBlock.MinimizeOn = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeString, ConvertToOreSettingsFileName, "MinimizeOn", DefaultMinimizeOn));

                        string argFileName4 = ConvertToOreSettingsFileName;
                        string argFileName5 = ConvertToOreSettingsFileName;
                        withBlock.CompressedIce = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "CompressedIce", DefaultCompressedIce));
                        string argFileName6 = ConvertToOreSettingsFileName;
                        string argFileName7 = ConvertToOreSettingsFileName;
                        withBlock.CompressedOre = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "CompressedOre", DefaultCompressedOre));
                        string argFileName8 = ConvertToOreSettingsFileName;
                        string argFileName9 = ConvertToOreSettingsFileName;
                        withBlock.HighSec = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "HighSec", DefaultHighSec));
                        string argFileName10 = ConvertToOreSettingsFileName;
                        string argFileName11 = ConvertToOreSettingsFileName;
                        withBlock.LowSec = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "LowSec", DefaultLowSec));
                        string argFileName12 = ConvertToOreSettingsFileName;
                        string argFileName13 = ConvertToOreSettingsFileName;
                        withBlock.NullSec = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "NullSec", DefaultNullSec));

                        string argFileName14 = ConvertToOreSettingsFileName;
                        string argFileName15 = ConvertToOreSettingsFileName;
                        withBlock.OreVariant0 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "OreVariant0", DefaultOreVariant0));
                        string argFileName16 = ConvertToOreSettingsFileName;
                        string argFileName17 = ConvertToOreSettingsFileName;
                        withBlock.OreVariant5 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "OreVariant5", DefaultOreVariant5));
                        string argFileName18 = ConvertToOreSettingsFileName;
                        string argFileName19 = ConvertToOreSettingsFileName;
                        withBlock.OreVariant10 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "OreVariant10", DefaultOreVariant10));
                        string argFileName20 = ConvertToOreSettingsFileName;
                        string argFileName21 = ConvertToOreSettingsFileName;
                        withBlock.Amarr = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "Amarr", DefaultAmarr));
                        string argFileName22 = ConvertToOreSettingsFileName;
                        string argFileName23 = ConvertToOreSettingsFileName;
                        withBlock.Caldari = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "Caldari", DefaultCaldari));
                        string argFileName24 = ConvertToOreSettingsFileName;
                        string argFileName25 = ConvertToOreSettingsFileName;
                        withBlock.Gallente = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "Gallente", DefaultGallente));
                        string argFileName26 = ConvertToOreSettingsFileName;
                        string argFileName27 = ConvertToOreSettingsFileName;
                        withBlock.Minmatar = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "Minmatar", DefaultMinmatar));
                        string argFileName28 = ConvertToOreSettingsFileName;
                        string argFileName29 = ConvertToOreSettingsFileName;
                        withBlock.Wormhole = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "Wormhole", DefaultWormhole));
                        string argFileName30 = ConvertToOreSettingsFileName;
                        string argFileName31 = ConvertToOreSettingsFileName;
                        withBlock.Triglavian = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "Triglavian", DefaultTriglavian));

                        string argFileName32 = ConvertToOreSettingsFileName;
                        string argFileName33 = ConvertToOreSettingsFileName;
                        withBlock.C1 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName33, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "C1", DefaultC1));
                        string argFileName34 = ConvertToOreSettingsFileName;
                        string argFileName35 = ConvertToOreSettingsFileName;
                        withBlock.C2 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName35, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "C2", DefaultC2));
                        string argFileName36 = ConvertToOreSettingsFileName;
                        string argFileName37 = ConvertToOreSettingsFileName;
                        withBlock.C3 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName37, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "C3", DefaultC3));
                        string argFileName38 = ConvertToOreSettingsFileName;
                        string argFileName39 = ConvertToOreSettingsFileName;
                        withBlock.C4 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName39, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "C4", DefaultC4));
                        string argFileName40 = ConvertToOreSettingsFileName;
                        string argFileName41 = ConvertToOreSettingsFileName;
                        withBlock.C5 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName41, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "C5", DefaultC5));
                        string argFileName42 = ConvertToOreSettingsFileName;
                        string argFileName43 = ConvertToOreSettingsFileName;
                        withBlock.C6 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName43, SettingTypes.TypeBoolean, ConvertToOreSettingsFileName, "C6", DefaultC6));

                        string argFileName44 = ConvertToOreSettingsFileName;
                        string argFileName45 = ConvertToOreSettingsFileName;
                        string OverrideString = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName45, SettingTypes.TypeString, ConvertToOreSettingsFileName, "OverrideChecks", ""));
                        withBlock.OverrideChecks = new int[36];

                        if (string.IsNullOrEmpty(OverrideString))
                        {
                            withBlock.OverrideChecks = GetDefaultOverrideChecks();
                        }
                        else
                        {
                            // Parse it out and Save values
                            string[] Items = OverrideString.Split(new char[] { ',' });

                            for (int i = 0; i <= 35; i++)
                                withBlock.OverrideChecks[i] = Conversions.ToInteger(Items[i]);
                        }

                        withBlock.SelectedOres = new List<OreType>();
                        withBlock.IgnoreItems = new List<string>();
                        withBlock.IgnoreRefinedItems = new int[15];
                        string argFileName46 = ConvertToOreSettingsFileName;
                        string argFileName47 = ConvertToOreSettingsFileName;
                        string IgnoreRefinedItemsString = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName47, SettingTypes.TypeString, ConvertToOreSettingsFileName, "IgnoreRefinedItems", ""));

                        if (!string.IsNullOrEmpty(IgnoreRefinedItemsString))
                        {
                            string[] RefinedItems = IgnoreRefinedItemsString.Split(new char[] { ',' });
                            for (int i = 0; i <= 14; i++)
                                withBlock.IgnoreRefinedItems[i] = Conversions.ToInteger(RefinedItems[i]);
                        }
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultConversionToOreSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Conversion to Ore Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultConversionToOreSettings();
            }

            // Save them locally and then export
            ConversionToOreSetting = TempSettings;

            return TempSettings;

        }

        // Loads the Defaults for the tab
        public ConversionToOreSettings SetDefaultConversionToOreSettings()
        {
            ConversionToOreSettings LocalSettings;

            LocalSettings.ConversionType = DefaultConversionType;
            LocalSettings.MinimizeOn = DefaultMinimizeOn;
            LocalSettings.CompressedOre = DefaultCompressedOre;
            LocalSettings.CompressedIce = DefaultCompressedIce;
            LocalSettings.HighSec = DefaultHighSec;
            LocalSettings.LowSec = DefaultLowSec;
            LocalSettings.NullSec = DefaultNullSec;
            LocalSettings.OreVariant0 = DefaultOreVariant0;
            LocalSettings.OreVariant5 = DefaultOreVariant5;
            LocalSettings.OreVariant10 = DefaultOreVariant10;
            LocalSettings.Amarr = DefaultAmarr;
            LocalSettings.Caldari = DefaultCaldari;
            LocalSettings.Gallente = DefaultGallente;
            LocalSettings.Minmatar = DefaultMinmatar;
            LocalSettings.Wormhole = DefaultWormhole;
            LocalSettings.Triglavian = DefaultTriglavian;
            LocalSettings.C1 = DefaultC1;
            LocalSettings.C2 = DefaultC2;
            LocalSettings.C3 = DefaultC3;
            LocalSettings.C4 = DefaultC4;
            LocalSettings.C5 = DefaultC5;
            LocalSettings.C6 = DefaultC6;

            LocalSettings.OverrideChecks = GetDefaultOverrideChecks();
            LocalSettings.SelectedOres = new List<OreType>();
            LocalSettings.IgnoreRefinedItems = GetDefaultIgnoreChecks();
            LocalSettings.IgnoreItems = new List<string>();

            // Save Locally
            ConversionToOreSetting = LocalSettings;

            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveConversionToOreSettings(ConversionToOreSettings SentSettings)
        {
            var ConvertSetting = new Setting[24];

            try
            {
                ConvertSetting[0] = new Setting("ConversionType", SentSettings.ConversionType);
                ConvertSetting[1] = new Setting("MinimizeOn", SentSettings.MinimizeOn);
                ConvertSetting[2] = new Setting("CompressedOre", Conversions.ToString(SentSettings.CompressedOre));
                ConvertSetting[3] = new Setting("CompressedIce", Conversions.ToString(SentSettings.CompressedIce));
                ConvertSetting[4] = new Setting("HighSec", Conversions.ToString(SentSettings.HighSec));
                ConvertSetting[5] = new Setting("LowSec", Conversions.ToString(SentSettings.LowSec));
                ConvertSetting[6] = new Setting("NullSec", Conversions.ToString(SentSettings.NullSec));
                ConvertSetting[7] = new Setting("OreVariant0", Conversions.ToString(SentSettings.OreVariant0));
                ConvertSetting[8] = new Setting("OreVariant5", Conversions.ToString(SentSettings.OreVariant5));
                ConvertSetting[9] = new Setting("OreVariant10", Conversions.ToString(SentSettings.OreVariant10));
                ConvertSetting[10] = new Setting("Amarr", Conversions.ToString(SentSettings.Amarr));
                ConvertSetting[11] = new Setting("Caldari", Conversions.ToString(SentSettings.Caldari));
                ConvertSetting[12] = new Setting("Gallente", Conversions.ToString(SentSettings.Gallente));
                ConvertSetting[13] = new Setting("Minmatar", Conversions.ToString(SentSettings.Minmatar));
                ConvertSetting[14] = new Setting("Wormhole", Conversions.ToString(SentSettings.Wormhole));
                ConvertSetting[15] = new Setting("Triglavian", Conversions.ToString(SentSettings.Triglavian));
                ConvertSetting[16] = new Setting("C1", Conversions.ToString(SentSettings.C1));
                ConvertSetting[17] = new Setting("C2", Conversions.ToString(SentSettings.C2));
                ConvertSetting[18] = new Setting("C3", Conversions.ToString(SentSettings.C3));
                ConvertSetting[19] = new Setting("C4", Conversions.ToString(SentSettings.C4));
                ConvertSetting[20] = new Setting("C5", Conversions.ToString(SentSettings.C5));
                ConvertSetting[21] = new Setting("C6", Conversions.ToString(SentSettings.C6));

                // For overridechecks, just make one long string with the value for each index in order
                string OverrideList = "";

                foreach (var CheckValue in SentSettings.OverrideChecks)
                    OverrideList += CheckValue + ",";
                OverrideList = OverrideList.Substring(0, Strings.Len(OverrideList) - 1);
                ConvertSetting[22] = new Setting("OverrideChecks", OverrideList);

                string IgnoreItemsList = "";
                foreach (var item in SentSettings.IgnoreRefinedItems)
                    IgnoreItemsList += item + ",";
                IgnoreItemsList = IgnoreItemsList.Substring(0, Strings.Len(IgnoreItemsList) - 1);
                ConvertSetting[23] = new Setting("IgnoreRefinedItems", IgnoreItemsList);

                WriteSettingsToFile(Public_Variables.SettingsFolder, ConvertToOreSettingsFileName, ConvertSetting, ConvertToOreSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Conversion to Ore Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public ConversionToOreSettings GetConversiontoOreSettings(Public_Variables.BeltType Belt)
        {
            return ConversionToOreSetting;
        }

        private int[] GetDefaultOverrideChecks()
        {
            var ReturnList = new int[36];
            for (int i = 0; i <= 35; i++)
                ReturnList[i] = DefaultOverrideValue;

            return ReturnList;

        }

        private int[] GetDefaultIgnoreChecks()
        {
            var ReturnList = new int[15];
            for (int i = 0; i <= 14; i++)
                ReturnList[i] = DefaultIgnoreValue;

            return ReturnList;

        }

        #endregion

        #region Asset Window Settings

        // Loads the tab settings
        public AssetWindowSettings LoadAssetWindowSettings(AssetWindow Location)
        {
            AssetWindowSettings TempSettings = default;
            string AssetWindowFileName = "";

            switch (Location)
            {
                case AssetWindow.DefaultView:
                    {
                        AssetWindowFileName = AssetWindowFileNameDefault;
                        break;
                    }
                case AssetWindow.ManufacturingTab:
                    {
                        AssetWindowFileName = AssetWindowFileNameManufacturingTab;
                        break;
                    }
                case AssetWindow.ShoppingList:
                    {
                        AssetWindowFileName = AssetWindowFileNameShoppingList;
                        break;
                    }
                case AssetWindow.Refinery:
                    {
                        AssetWindowFileName = AssetWindowFileNameRefinery;
                        break;
                    }
            }

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, AssetWindowFileName))
                {

                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        // Main window
                        withBlock.AssetType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeString, AssetWindowFileName, "AssetType", DefaultAssetType));
                        withBlock.SortbyName = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "SortbyName", DefaultAssetSortbyName));

                        // Search Settings
                        withBlock.ItemFilterText = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeString, AssetWindowFileName, "ItemFilterText", DefaultAssetItemTextFilter));
                        withBlock.AllItems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AllItems", DefaultAllItems));
                        withBlock.AllRawMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AllRawMats", DefaultAssetItemChecks));

                        withBlock.AdvancedProtectiveTechnology = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AdvancedProtectiveTechnology", DefaultAssetItemChecks));
                        withBlock.Gas = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Gas", DefaultAssetItemChecks));
                        withBlock.IceProducts = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "IceProducts", DefaultAssetItemChecks));
                        withBlock.MolecularForgingTools = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "MolecularForgingTools", DefaultAssetItemChecks));
                        withBlock.FactionMaterials = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "FactionMaterials", DefaultAssetItemChecks));
                        withBlock.NamedComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "NamedComponents", DefaultAssetItemChecks));
                        withBlock.Minerals = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Minerals", DefaultAssetItemChecks));
                        withBlock.Planetary = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Planetary", DefaultAssetItemChecks));
                        withBlock.RawMaterials = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "RawMaterials", DefaultAssetItemChecks));
                        withBlock.Salvage = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Salvage", DefaultAssetItemChecks));
                        withBlock.Misc = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Misc", DefaultAssetItemChecks));
                        withBlock.BPCs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "BPCs", false));

                        withBlock.AdvancedMoonMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AdvancedMoonMats", DefaultAssetItemChecks));
                        withBlock.BoosterMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "BoosterMats", DefaultAssetItemChecks));
                        withBlock.MolecularForgedMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "MolecularForgedMats", DefaultAssetItemChecks));
                        withBlock.Polymers = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Polymers", DefaultAssetItemChecks));
                        withBlock.ProcessedMoonMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "ProcessedMoonMats", DefaultAssetItemChecks));
                        withBlock.RawMoonMats = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "RawMoonMats", DefaultAssetItemChecks));

                        withBlock.AncientRelics = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AncientRelics", DefaultAssetItemChecks));
                        withBlock.Datacores = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Datacores", DefaultAssetItemChecks));
                        withBlock.Decryptors = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Decryptors", DefaultAssetItemChecks));
                        withBlock.RDB = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "RDB", DefaultAssetItemChecks));

                        withBlock.AllManufacturedItems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AllManufacturedItems", DefaultAssetItemChecks));

                        withBlock.Ships = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Ships", DefaultAssetItemChecks));
                        withBlock.Charges = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Charges", DefaultAssetItemChecks));
                        withBlock.Modules = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Modules", DefaultAssetItemChecks));
                        withBlock.Drones = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Drones", DefaultAssetItemChecks));
                        withBlock.Rigs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Rigs", DefaultAssetItemChecks));
                        withBlock.Subsystems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Subsystems", DefaultAssetItemChecks));
                        withBlock.Deployables = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Deployables", DefaultAssetItemChecks));
                        withBlock.Boosters = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Boosters", DefaultAssetItemChecks));
                        withBlock.Structures = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Structures", DefaultAssetItemChecks));
                        withBlock.StructureRigs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "StructureRigs", DefaultAssetItemChecks));
                        withBlock.Celestials = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Celestials", DefaultAssetItemChecks));
                        withBlock.StructureModules = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "StructureModules", DefaultAssetItemChecks));
                        withBlock.Implants = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Implants", DefaultAssetItemChecks));

                        withBlock.AdvancedCapComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AdvancedCapComponents", DefaultAssetItemChecks));
                        withBlock.AdvancedComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "AdvancedComponents", DefaultAssetItemChecks));
                        withBlock.FuelBlocks = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "FuelBlocks", DefaultAssetItemChecks));
                        withBlock.ProtectiveComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "ProtectiveComponents", DefaultAssetItemChecks));
                        withBlock.RAM = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "RAM", DefaultAssetItemChecks));
                        withBlock.CapitalShipComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "CapitalShipComponents", DefaultAssetItemChecks));
                        withBlock.StructureComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Structure Components", DefaultAssetItemChecks));
                        withBlock.SubsystemComponents = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "SubsystemComponents", DefaultAssetItemChecks));
                        withBlock.NoBuildItems = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "NoBuildItems", false));

                        withBlock.T1 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "T1", DefaultAssetItemChecks));
                        withBlock.T2 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "T2", DefaultAssetItemChecks));
                        withBlock.T3 = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "T3", DefaultAssetItemChecks));
                        withBlock.Faction = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Faction", DefaultAssetItemChecks));
                        withBlock.Pirate = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Pirate", DefaultAssetItemChecks));
                        withBlock.Storyline = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref AssetWindowFileName, SettingTypes.TypeBoolean, AssetWindowFileName, "Storyline", DefaultAssetItemChecks));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultAssetWindowSettings(Location);

                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading Asset Window Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults                            
                TempSettings = SetDefaultAssetWindowSettings(Location);
            }

            // Save them locally and then export
            switch (Location)
            {
                case AssetWindow.ManufacturingTab:
                    {
                        AssetWindowSettingsManufacturingTab = TempSettings;
                        break;
                    }
                case AssetWindow.ShoppingList:
                    {
                        AssetWindowSettingsShoppingList = TempSettings;
                        break;
                    }
                case AssetWindow.Refinery:
                    {
                        AssetWindowsettingsRefinery = TempSettings;
                        break;
                    }
            }

            return TempSettings;

        }

        // Saves the tab settings to XML
        public void SaveAssetWindowSettings(AssetWindowSettings ItemsSelected, AssetWindow Location)
        {
            var AssetWindowSettingsList = new Setting[56];
            string AssetWindowFileName = "";

            switch (Location)
            {
                case AssetWindow.DefaultView:
                    {
                        AssetWindowFileName = AssetWindowFileNameDefault;
                        break;
                    }
                case AssetWindow.ManufacturingTab:
                    {
                        AssetWindowFileName = AssetWindowFileNameManufacturingTab;
                        break;
                    }
                case AssetWindow.ShoppingList:
                    {
                        AssetWindowFileName = AssetWindowFileNameShoppingList;
                        break;
                    }
                case AssetWindow.Refinery:
                    {
                        AssetWindowFileName = AssetWindowFileNameRefinery;
                        break;
                    }
            }

            try
            {
                // Main window
                AssetWindowSettingsList[0] = new Setting("AssetType", ItemsSelected.AssetType);
                AssetWindowSettingsList[1] = new Setting("SortbyName", Conversions.ToString(ItemsSelected.SortbyName));
                AssetWindowSettingsList[2] = new Setting("ItemFilterText", ItemsSelected.ItemFilterText);
                AssetWindowSettingsList[3] = new Setting("AllItems", Conversions.ToString(ItemsSelected.AllItems));

                AssetWindowSettingsList[4] = new Setting("AllRawMats", Conversions.ToString(ItemsSelected.AllRawMats));
                AssetWindowSettingsList[5] = new Setting("AdvancedProtectiveTechnology", Conversions.ToString(ItemsSelected.AdvancedProtectiveTechnology));
                AssetWindowSettingsList[6] = new Setting("Gas", Conversions.ToString(ItemsSelected.Gas));
                AssetWindowSettingsList[7] = new Setting("IceProducts", Conversions.ToString(ItemsSelected.IceProducts));
                AssetWindowSettingsList[8] = new Setting("MolecularForgingTools", Conversions.ToString(ItemsSelected.MolecularForgingTools));
                AssetWindowSettingsList[9] = new Setting("FactionMaterials", Conversions.ToString(ItemsSelected.FactionMaterials));
                AssetWindowSettingsList[10] = new Setting("NamedComponents", Conversions.ToString(ItemsSelected.NamedComponents));
                AssetWindowSettingsList[11] = new Setting("Minerals", Conversions.ToString(ItemsSelected.Minerals));
                AssetWindowSettingsList[12] = new Setting("Planetary", Conversions.ToString(ItemsSelected.Planetary));
                AssetWindowSettingsList[13] = new Setting("RawMaterials", Conversions.ToString(ItemsSelected.RawMaterials));
                AssetWindowSettingsList[14] = new Setting("Salvage", Conversions.ToString(ItemsSelected.Salvage));
                AssetWindowSettingsList[15] = new Setting("Misc", Conversions.ToString(ItemsSelected.Misc));
                AssetWindowSettingsList[16] = new Setting("BPCs", Conversions.ToString(ItemsSelected.BPCs));
                AssetWindowSettingsList[17] = new Setting("AdvancedMoonMats", Conversions.ToString(ItemsSelected.AdvancedMoonMats));
                AssetWindowSettingsList[18] = new Setting("BoosterMats", Conversions.ToString(ItemsSelected.BoosterMats));
                AssetWindowSettingsList[19] = new Setting("MolecularForgedMats", Conversions.ToString(ItemsSelected.MolecularForgedMats));
                AssetWindowSettingsList[20] = new Setting("Polymers", Conversions.ToString(ItemsSelected.Polymers));
                AssetWindowSettingsList[21] = new Setting("ProcessedMoonMats", Conversions.ToString(ItemsSelected.ProcessedMoonMats));
                AssetWindowSettingsList[22] = new Setting("RawMoonMats", Conversions.ToString(ItemsSelected.RawMoonMats));
                AssetWindowSettingsList[23] = new Setting("AncientRelics", Conversions.ToString(ItemsSelected.AncientRelics));
                AssetWindowSettingsList[24] = new Setting("Datacores", Conversions.ToString(ItemsSelected.Datacores));
                AssetWindowSettingsList[25] = new Setting("Decryptors", Conversions.ToString(ItemsSelected.Decryptors));
                AssetWindowSettingsList[26] = new Setting("RDB", Conversions.ToString(ItemsSelected.RDB));
                AssetWindowSettingsList[27] = new Setting("AllManufacturedItems", Conversions.ToString(ItemsSelected.AllManufacturedItems));
                AssetWindowSettingsList[28] = new Setting("Ships", Conversions.ToString(ItemsSelected.Ships));
                AssetWindowSettingsList[29] = new Setting("Charges", Conversions.ToString(ItemsSelected.Charges));
                AssetWindowSettingsList[30] = new Setting("Modules", Conversions.ToString(ItemsSelected.Modules));
                AssetWindowSettingsList[31] = new Setting("Drones", Conversions.ToString(ItemsSelected.Drones));
                AssetWindowSettingsList[32] = new Setting("Rigs", Conversions.ToString(ItemsSelected.Rigs));
                AssetWindowSettingsList[33] = new Setting("Subsystems", Conversions.ToString(ItemsSelected.Subsystems));
                AssetWindowSettingsList[34] = new Setting("Deployables", Conversions.ToString(ItemsSelected.Deployables));
                AssetWindowSettingsList[35] = new Setting("Boosters", Conversions.ToString(ItemsSelected.Boosters));
                AssetWindowSettingsList[36] = new Setting("Structures", Conversions.ToString(ItemsSelected.Structures));
                AssetWindowSettingsList[37] = new Setting("StructureRigs", Conversions.ToString(ItemsSelected.StructureRigs));
                AssetWindowSettingsList[38] = new Setting("Celestials", Conversions.ToString(ItemsSelected.Celestials));
                AssetWindowSettingsList[39] = new Setting("StructureModules", Conversions.ToString(ItemsSelected.StructureModules));
                AssetWindowSettingsList[40] = new Setting("Implants", Conversions.ToString(ItemsSelected.Implants));
                AssetWindowSettingsList[41] = new Setting("AdvancedCapComponents", Conversions.ToString(ItemsSelected.AdvancedCapComponents));
                AssetWindowSettingsList[42] = new Setting("AdvancedComponents", Conversions.ToString(ItemsSelected.AdvancedComponents));
                AssetWindowSettingsList[43] = new Setting("FuelBlocks", Conversions.ToString(ItemsSelected.FuelBlocks));
                AssetWindowSettingsList[44] = new Setting("ProtectiveComponents", Conversions.ToString(ItemsSelected.ProtectiveComponents));
                AssetWindowSettingsList[45] = new Setting("RAM", Conversions.ToString(ItemsSelected.RAM));
                AssetWindowSettingsList[46] = new Setting("CapitalShipComponents", Conversions.ToString(ItemsSelected.CapitalShipComponents));
                AssetWindowSettingsList[47] = new Setting("StructureComponents", Conversions.ToString(ItemsSelected.StructureComponents));
                AssetWindowSettingsList[48] = new Setting("SubsystemComponents", Conversions.ToString(ItemsSelected.SubsystemComponents));
                AssetWindowSettingsList[49] = new Setting("T1", Conversions.ToString(ItemsSelected.T1));
                AssetWindowSettingsList[50] = new Setting("T2", Conversions.ToString(ItemsSelected.T2));
                AssetWindowSettingsList[51] = new Setting("T3", Conversions.ToString(ItemsSelected.T3));
                AssetWindowSettingsList[52] = new Setting("Faction", Conversions.ToString(ItemsSelected.Faction));
                AssetWindowSettingsList[53] = new Setting("Pirate", Conversions.ToString(ItemsSelected.Pirate));
                AssetWindowSettingsList[54] = new Setting("Storyline", Conversions.ToString(ItemsSelected.Storyline));
                AssetWindowSettingsList[55] = new Setting("NoBuildItems", Conversions.ToString(ItemsSelected.NoBuildItems));

                WriteSettingsToFile(Public_Variables.SettingsFolder, AssetWindowFileName, AssetWindowSettingsList, AssetWindowFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Asset Window Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public AssetWindowSettings GetAssetWindowSettings(AssetWindow Location)
        {

            switch (Location)
            {
                case AssetWindow.ManufacturingTab:
                    {
                        return AssetWindowSettingsManufacturingTab;
                    }
                case AssetWindow.ShoppingList:
                    {
                        return AssetWindowSettingsShoppingList;
                    }
                case AssetWindow.Refinery:
                    {
                        return AssetWindowsettingsRefinery;
                    }

                default:
                    {
                        return default;
                    }
            }

        }

        public AssetWindowSettings SetDefaultAssetWindowSettings(AssetWindow Location)
        {
            AssetWindowSettings LocalSettings = default;

            LocalSettings.AssetType = DefaultAssetType;
            LocalSettings.SortbyName = DefaultAssetSortbyName;
            LocalSettings.ItemFilterText = DefaultAssetItemTextFilter;
            LocalSettings.AllItems = DefaultAllItems;
            LocalSettings.AllRawMats = DefaultAssetItemChecks;
            LocalSettings.AdvancedProtectiveTechnology = DefaultAssetItemChecks;
            LocalSettings.Gas = DefaultAssetItemChecks;
            LocalSettings.IceProducts = DefaultAssetItemChecks;
            LocalSettings.MolecularForgingTools = DefaultAssetItemChecks;
            LocalSettings.FactionMaterials = DefaultAssetItemChecks;
            LocalSettings.NamedComponents = DefaultAssetItemChecks;
            LocalSettings.Minerals = DefaultAssetItemChecks;
            LocalSettings.Planetary = DefaultAssetItemChecks;
            LocalSettings.RawMaterials = DefaultAssetItemChecks;
            LocalSettings.Salvage = DefaultAssetItemChecks;
            LocalSettings.Misc = DefaultAssetItemChecks;
            LocalSettings.BPCs = DefaultAssetItemChecks;
            LocalSettings.AdvancedMoonMats = DefaultAssetItemChecks;
            LocalSettings.BoosterMats = DefaultAssetItemChecks;
            LocalSettings.MolecularForgedMats = DefaultAssetItemChecks;
            LocalSettings.Polymers = DefaultAssetItemChecks;
            LocalSettings.ProcessedMoonMats = DefaultAssetItemChecks;
            LocalSettings.RawMoonMats = DefaultAssetItemChecks;
            LocalSettings.AncientRelics = DefaultAssetItemChecks;
            LocalSettings.Datacores = DefaultAssetItemChecks;
            LocalSettings.Decryptors = DefaultAssetItemChecks;
            LocalSettings.RDB = DefaultAssetItemChecks;
            LocalSettings.AllManufacturedItems = DefaultAssetItemChecks;
            LocalSettings.Ships = DefaultAssetItemChecks;
            LocalSettings.Charges = DefaultAssetItemChecks;
            LocalSettings.Modules = DefaultAssetItemChecks;
            LocalSettings.Drones = DefaultAssetItemChecks;
            LocalSettings.Rigs = DefaultAssetItemChecks;
            LocalSettings.Subsystems = DefaultAssetItemChecks;
            LocalSettings.Deployables = DefaultAssetItemChecks;
            LocalSettings.Boosters = DefaultAssetItemChecks;
            LocalSettings.Structures = DefaultAssetItemChecks;
            LocalSettings.StructureRigs = DefaultAssetItemChecks;
            LocalSettings.Celestials = DefaultAssetItemChecks;
            LocalSettings.StructureModules = DefaultAssetItemChecks;
            LocalSettings.Implants = DefaultAssetItemChecks;
            LocalSettings.AdvancedCapComponents = DefaultAssetItemChecks;
            LocalSettings.AdvancedComponents = DefaultAssetItemChecks;
            LocalSettings.FuelBlocks = DefaultAssetItemChecks;
            LocalSettings.ProtectiveComponents = DefaultAssetItemChecks;
            LocalSettings.RAM = DefaultAssetItemChecks;
            LocalSettings.NoBuildItems = false;
            LocalSettings.CapitalShipComponents = DefaultAssetItemChecks;
            LocalSettings.StructureComponents = DefaultAssetItemChecks;
            LocalSettings.SubsystemComponents = DefaultAssetItemChecks;
            LocalSettings.T1 = DefaultAssetItemChecks;
            LocalSettings.T2 = DefaultAssetItemChecks;
            LocalSettings.T3 = DefaultAssetItemChecks;
            LocalSettings.Faction = DefaultAssetItemChecks;
            LocalSettings.Pirate = DefaultAssetItemChecks;

            LocalSettings.Storyline = DefaultAssetItemChecks;

            // Save locally - Will have more than one
            switch (Location)
            {
                case AssetWindow.ManufacturingTab:
                    {
                        AssetWindowSettingsManufacturingTab = LocalSettings;
                        break;
                    }
                case AssetWindow.ShoppingList:
                    {
                        AssetWindowSettingsShoppingList = LocalSettings;
                        break;
                    }
                case AssetWindow.Refinery:
                    {
                        AssetWindowsettingsRefinery = LocalSettings;
                        break;
                    }
            }

            return LocalSettings;

        }

        #endregion

        #region Market History Viewer Settings

        // Loads the tab settings
        public MarketHistoryViewerSettings LoadMarketHistoryViewerSettingsSettings()
        {
            MarketHistoryViewerSettings TempSettings = default;

            try
            {

                if (FileExists(Public_Variables.SettingsFolder, MarketHistoryViewerSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = MarketHistoryViewerSettingsFileName;
                        string argFileName1 = MarketHistoryViewerSettingsFileName;
                        withBlock.DatePreference = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeString, MarketHistoryViewerSettingsFileName, "DatePreference", DefaultMHDatePreference));
                        string argFileName2 = MarketHistoryViewerSettingsFileName;
                        string argFileName3 = MarketHistoryViewerSettingsFileName;
                        withBlock.Volume = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "Volume", DefaultMHVolume));
                        string argFileName4 = MarketHistoryViewerSettingsFileName;
                        string argFileName5 = MarketHistoryViewerSettingsFileName;
                        withBlock.MinMaxDayPrice = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "MinMaxDayPrice", DefaultMHMinMaxDayPrice));
                        string argFileName6 = MarketHistoryViewerSettingsFileName;
                        string argFileName7 = MarketHistoryViewerSettingsFileName;
                        withBlock.LinearTrend = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "LinearTrend", DefaultMHLinearTrend));
                        string argFileName8 = MarketHistoryViewerSettingsFileName;
                        string argFileName9 = MarketHistoryViewerSettingsFileName;
                        withBlock.DochianChannel = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "DochianChannel", DefaultMHDochianChannel));
                        string argFileName10 = MarketHistoryViewerSettingsFileName;
                        string argFileName11 = MarketHistoryViewerSettingsFileName;
                        withBlock.FiveDayAvg = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "FiveDayAvg", DefaultMHFiveDayAvg));
                        string argFileName12 = MarketHistoryViewerSettingsFileName;
                        string argFileName13 = MarketHistoryViewerSettingsFileName;
                        withBlock.TwentyDayAvg = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, MarketHistoryViewerSettingsFileName, "TwentyDayAvg", DefaultMHTwentyDayAvg));
                    }
                }
                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultMarketHistoryViewerSettingsSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading MarketHistoryViewerSettings Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultMarketHistoryViewerSettingsSettings();
            }

            // Save them locally and then export
            MarketHistoryViewSettings = TempSettings;

            return TempSettings;

        }

        public MarketHistoryViewerSettings SetDefaultMarketHistoryViewerSettingsSettings()
        {
            MarketHistoryViewerSettings LocalSettings;

            LocalSettings.DatePreference = DefaultMHDatePreference;
            LocalSettings.Volume = DefaultMHVolume;
            LocalSettings.MinMaxDayPrice = DefaultMHMinMaxDayPrice;
            LocalSettings.LinearTrend = DefaultMHLinearTrend;
            LocalSettings.DochianChannel = DefaultMHDochianChannel;
            LocalSettings.FiveDayAvg = DefaultMHFiveDayAvg;
            LocalSettings.TwentyDayAvg = DefaultMHTwentyDayAvg;

            // Save locally
            MarketHistoryViewSettings = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveMarketHistoryViewerSettingsSettings(MarketHistoryViewerSettings SentSettings)
        {
            var MarketHistoryViewerSettingsSettingsList = new Setting[7];

            try
            {
                MarketHistoryViewerSettingsSettingsList[0] = new Setting("DatePreference", SentSettings.DatePreference);
                MarketHistoryViewerSettingsSettingsList[1] = new Setting("MinMaxDayPrice", Conversions.ToString(SentSettings.MinMaxDayPrice));
                MarketHistoryViewerSettingsSettingsList[2] = new Setting("Volume", Conversions.ToString(SentSettings.Volume));
                MarketHistoryViewerSettingsSettingsList[3] = new Setting("LinearTrend", Conversions.ToString(SentSettings.LinearTrend));
                MarketHistoryViewerSettingsSettingsList[4] = new Setting("DochianChannel", Conversions.ToString(SentSettings.DochianChannel));
                MarketHistoryViewerSettingsSettingsList[5] = new Setting("FiveDayAvg", Conversions.ToString(SentSettings.FiveDayAvg));
                MarketHistoryViewerSettingsSettingsList[6] = new Setting("TwentyDayAvg", Conversions.ToString(SentSettings.TwentyDayAvg));

                WriteSettingsToFile(Public_Variables.SettingsFolder, MarketHistoryViewerSettingsFileName, MarketHistoryViewerSettingsSettingsList, MarketHistoryViewerSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving LP Store Tab Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public MarketHistoryViewerSettings GetMarketHistoryViewerSettingsSettings()
        {
            return MarketHistoryViewSettings;
        }

        #endregion

        #region BP Viewer Settings

        // Loads the tab settings
        public BPViewerSettings LoadBPViewerSettings()
        {
            BPViewerSettings TempSettings = default;

            try
            {
                if (FileExists(Public_Variables.SettingsFolder, BPViewerSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = BPViewerSettingsFileName;
                        string argFileName1 = BPViewerSettingsFileName;
                        withBlock.BlueprintTypeSelection = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeString, BPViewerSettingsFileName, "BlueprintTypeSelection", DefaultBPViewerSelectionType));
                        string argFileName2 = BPViewerSettingsFileName;
                        string argFileName3 = BPViewerSettingsFileName;
                        withBlock.Tech1Check = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "Tech1Check", DefaultBPViewerTechChecks));
                        string argFileName4 = BPViewerSettingsFileName;
                        string argFileName5 = BPViewerSettingsFileName;
                        withBlock.Tech2Check = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "Tech2Check", DefaultBPViewerTechChecks));
                        string argFileName6 = BPViewerSettingsFileName;
                        string argFileName7 = BPViewerSettingsFileName;
                        withBlock.Tech3Check = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "Tech3Check", DefaultBPViewerTechChecks));
                        string argFileName8 = BPViewerSettingsFileName;
                        string argFileName9 = BPViewerSettingsFileName;
                        withBlock.TechStorylineCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "TechStorylineCheck", DefaultBPViewerTechChecks));
                        string argFileName10 = BPViewerSettingsFileName;
                        string argFileName11 = BPViewerSettingsFileName;
                        withBlock.TechFactionCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "TechFactionCheck", DefaultBPViewerTechChecks));
                        string argFileName12 = BPViewerSettingsFileName;
                        string argFileName13 = BPViewerSettingsFileName;
                        withBlock.TechPirateCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "TechPirateCheck", DefaultBPViewerTechChecks));
                        string argFileName14 = BPViewerSettingsFileName;
                        string argFileName15 = BPViewerSettingsFileName;
                        withBlock.SmallCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "SmallCheck", DefaultBPViewerSizeChecks));
                        string argFileName16 = BPViewerSettingsFileName;
                        string argFileName17 = BPViewerSettingsFileName;
                        withBlock.MediumCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "SmallCheck", DefaultBPViewerSizeChecks));
                        string argFileName18 = BPViewerSettingsFileName;
                        string argFileName19 = BPViewerSettingsFileName;
                        withBlock.LargeCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "SmallCheck", DefaultBPViewerSizeChecks));
                        string argFileName20 = BPViewerSettingsFileName;
                        string argFileName21 = BPViewerSettingsFileName;
                        withBlock.XLCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "SmallCheck", DefaultBPViewerSizeChecks));
                        string argFileName22 = BPViewerSettingsFileName;
                        string argFileName23 = BPViewerSettingsFileName;
                        withBlock.IncludeIgnoredBPs = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "IncludeIgnoredBPs", DefaultBPViewerIgnoreBPsCheck));
                        string argFileName24 = BPViewerSettingsFileName;
                        string argFileName25 = BPViewerSettingsFileName;
                        withBlock.BPNPCBPOsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeBoolean, BPViewerSettingsFileName, "BPNPCBPOsCheck", DefaultBPNPCBPOsCheck));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultBPViewerSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading BP Viewer Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultBPViewerSettings();
            }

            // Save them locally and then export
            BPViewSettings = TempSettings;

            return TempSettings;

        }

        // Saves the tab settings to XML
        public void SaveBPViewerSettings(BPViewerSettings SentSettings)
        {
            var BPSettingsList = new Setting[13];

            try
            {
                BPSettingsList[0] = new Setting("BlueprintTypeSelection", SentSettings.BlueprintTypeSelection);
                BPSettingsList[1] = new Setting("Tech1Check", Conversions.ToString(SentSettings.Tech1Check));
                BPSettingsList[2] = new Setting("Tech2Check", Conversions.ToString(SentSettings.Tech2Check));
                BPSettingsList[3] = new Setting("Tech3Check", Conversions.ToString(SentSettings.Tech3Check));
                BPSettingsList[4] = new Setting("TechStorylineCheck", Conversions.ToString(SentSettings.TechStorylineCheck));
                BPSettingsList[5] = new Setting("TechFactionCheck", Conversions.ToString(SentSettings.TechFactionCheck));
                BPSettingsList[6] = new Setting("TechPirateCheck", Conversions.ToString(SentSettings.TechPirateCheck));
                BPSettingsList[7] = new Setting("SmallCheck", Conversions.ToString(SentSettings.SmallCheck));
                BPSettingsList[8] = new Setting("MediumCheck", Conversions.ToString(SentSettings.MediumCheck));
                BPSettingsList[9] = new Setting("LargeCheck", Conversions.ToString(SentSettings.LargeCheck));
                BPSettingsList[10] = new Setting("XLCheck", Conversions.ToString(SentSettings.XLCheck));
                BPSettingsList[11] = new Setting("IncludeIgnoredBPs", Conversions.ToString(SentSettings.IncludeIgnoredBPs));
                BPSettingsList[12] = new Setting("BPNPCBPOsCheck", Conversions.ToString(SentSettings.BPNPCBPOsCheck));

                WriteSettingsToFile(Public_Variables.SettingsFolder, BPSettingsFileName, BPSettingsList, BPSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving BP Viewer Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Loads the defaults
        public BPViewerSettings SetDefaultBPViewerSettings()
        {
            BPViewerSettings LocalSettings;

            LocalSettings.BPNPCBPOsCheck = DefaultBPNPCBPOsCheck;
            LocalSettings.BlueprintTypeSelection = DefaultBPViewerSelectionType;
            LocalSettings.Tech1Check = DefaultBPViewerTechChecks;
            LocalSettings.Tech2Check = DefaultBPViewerTechChecks;
            LocalSettings.Tech3Check = DefaultBPViewerTechChecks;
            LocalSettings.TechStorylineCheck = DefaultBPViewerTechChecks;
            LocalSettings.TechFactionCheck = DefaultBPViewerTechChecks;
            LocalSettings.TechPirateCheck = DefaultBPViewerTechChecks;
            LocalSettings.SmallCheck = DefaultBPViewerSizeChecks;
            LocalSettings.MediumCheck = DefaultBPViewerSizeChecks;
            LocalSettings.LargeCheck = DefaultBPViewerSizeChecks;
            LocalSettings.XLCheck = DefaultBPViewerSizeChecks;
            LocalSettings.IncludeIgnoredBPs = DefaultBPViewerIgnoreBPsCheck;

            // Save locally
            BPViewSettings = LocalSettings;

            return LocalSettings;

        }

        // Returns the tab settings
        public BPViewerSettings GetBPViewerSettings()
        {
            return BPViewSettings;
        }

        #endregion

        #region Upwell Structures Viewer Settings

        // Loads the tab settings
        public UpwellStructureSettings LoadUpwellStructureViewerSettings()
        {
            UpwellStructureSettings TempSettings = default;

            try
            {

                if (FileExists(Public_Variables.SettingsFolder, UpwellStructureViewerSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = UpwellStructureViewerSettingsFileName;
                        string argFileName1 = UpwellStructureViewerSettingsFileName;
                        withBlock.HighSlotsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "HighSlotsCheck", DefaultHighSlotsCheck));
                        string argFileName2 = UpwellStructureViewerSettingsFileName;
                        string argFileName3 = UpwellStructureViewerSettingsFileName;
                        withBlock.MediumSlotsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "MediumSlotsCheck", DefaultMediumSlotsCheck));
                        string argFileName4 = UpwellStructureViewerSettingsFileName;
                        string argFileName5 = UpwellStructureViewerSettingsFileName;
                        withBlock.LowSlotsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "LowSlotsCheck", DefaultLowSlotsCheck));
                        string argFileName6 = UpwellStructureViewerSettingsFileName;
                        string argFileName7 = UpwellStructureViewerSettingsFileName;
                        withBlock.ServicesCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "ServicesCheck", DefaultServicesCheck));
                        string argFileName8 = UpwellStructureViewerSettingsFileName;
                        string argFileName9 = UpwellStructureViewerSettingsFileName;
                        withBlock.ReprocessingRigsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "ReprocessingRigsCheck", DefaultReprocessingRigsCheck));
                        string argFileName10 = UpwellStructureViewerSettingsFileName;
                        string argFileName11 = UpwellStructureViewerSettingsFileName;
                        withBlock.EngineeringRigsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "EngineeringRigsCheck", DefaultEngineeringRigsCheck));
                        string argFileName12 = UpwellStructureViewerSettingsFileName;
                        string argFileName13 = UpwellStructureViewerSettingsFileName;
                        withBlock.CombatRigsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName13, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "CombatRigsCheck", DefaultCombatRigsCheck));
                        string argFileName14 = UpwellStructureViewerSettingsFileName;
                        string argFileName15 = UpwellStructureViewerSettingsFileName;
                        withBlock.IncludeFuelCostsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName15, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "IncludeFuelCostsCheck", DefaultIncludeFuelCostsCheck));
                        string argFileName16 = UpwellStructureViewerSettingsFileName;
                        string argFileName17 = UpwellStructureViewerSettingsFileName;
                        withBlock.FuelBlockType = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName17, SettingTypes.TypeString, UpwellStructureViewerSettingsFileName, "FuelBlockType", DefaultFuelBlockType));
                        string argFileName18 = UpwellStructureViewerSettingsFileName;
                        string argFileName19 = UpwellStructureViewerSettingsFileName;
                        withBlock.BuyBuildBlockOption = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName19, SettingTypes.TypeString, UpwellStructureViewerSettingsFileName, "BuyBuildBlockOption", DefaultBuyBuildBlockOption));
                        string argFileName20 = UpwellStructureViewerSettingsFileName;
                        string argFileName21 = UpwellStructureViewerSettingsFileName;
                        withBlock.AutoUpdateFuelBlockPricesCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName21, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "AutoUpdateFuelBlockPricesCheck", DefaultAutoUpdateFuelBlockPricesCheck));
                        string argFileName22 = UpwellStructureViewerSettingsFileName;
                        string argFileName23 = UpwellStructureViewerSettingsFileName;
                        withBlock.SearchFilterText = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName23, SettingTypes.TypeString, UpwellStructureViewerSettingsFileName, "SearchFilterText", DefaultSearchFilterText));
                        string argFileName24 = UpwellStructureViewerSettingsFileName;
                        string argFileName25 = UpwellStructureViewerSettingsFileName;
                        withBlock.SelectedStructureName = Conversions.ToString(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName25, SettingTypes.TypeString, UpwellStructureViewerSettingsFileName, "SelectedStructureName", DefaultSelectedStructureName));
                        string argFileName26 = UpwellStructureViewerSettingsFileName;
                        string argFileName27 = UpwellStructureViewerSettingsFileName;
                        withBlock.ReactionsRigsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName27, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "ReactionsRigsCheck", DefaultReactionsRigsCheck));
                        string argFileName28 = UpwellStructureViewerSettingsFileName;
                        string argFileName29 = UpwellStructureViewerSettingsFileName;
                        withBlock.DrillingRigsCheck = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName29, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "DrillingRigsCheck", DefaultDrillingRigsCheck));
                        string argFileName30 = UpwellStructureViewerSettingsFileName;
                        string argFileName31 = UpwellStructureViewerSettingsFileName;
                        withBlock.IconListView = Conversions.ToBoolean(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName31, SettingTypes.TypeBoolean, UpwellStructureViewerSettingsFileName, "IconListView", DefaultIconListView));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultUpwellStructureViewerSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading UpwellStructureViewer Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultUpwellStructureViewerSettings();
            }

            // Save them locally and then export
            UpwellStructureViewerSettings = TempSettings;

            return TempSettings;

        }

        public UpwellStructureSettings SetDefaultUpwellStructureViewerSettings()
        {
            UpwellStructureSettings LocalSettings;

            LocalSettings.HighSlotsCheck = DefaultHighSlotsCheck;
            LocalSettings.MediumSlotsCheck = DefaultMediumSlotsCheck;
            LocalSettings.LowSlotsCheck = DefaultLowSlotsCheck;
            LocalSettings.ServicesCheck = DefaultServicesCheck;
            LocalSettings.ReprocessingRigsCheck = DefaultReprocessingRigsCheck;
            LocalSettings.EngineeringRigsCheck = DefaultEngineeringRigsCheck;
            LocalSettings.CombatRigsCheck = DefaultCombatRigsCheck;
            LocalSettings.IncludeFuelCostsCheck = DefaultIncludeFuelCostsCheck;
            LocalSettings.FuelBlockType = DefaultFuelBlockType;
            LocalSettings.BuyBuildBlockOption = DefaultBuyBuildBlockOption;
            LocalSettings.AutoUpdateFuelBlockPricesCheck = DefaultAutoUpdateFuelBlockPricesCheck;
            LocalSettings.SearchFilterText = DefaultSearchFilterText;
            LocalSettings.SelectedStructureName = DefaultSelectedStructureName;
            LocalSettings.ReactionsRigsCheck = DefaultReactionsRigsCheck;
            LocalSettings.DrillingRigsCheck = DefaultDrillingRigsCheck;
            LocalSettings.IconListView = DefaultIconListView;

            // Save locally
            UpwellStructureViewerSettings = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveUpwellStructureViewerSettings(UpwellStructureSettings SentSettings)
        {
            var UpwellStructureViewerSettingsList = new Setting[16];

            try
            {
                UpwellStructureViewerSettingsList[0] = new Setting("HighSlotsCheck", Conversions.ToString(SentSettings.HighSlotsCheck));
                UpwellStructureViewerSettingsList[1] = new Setting("MediumSlotsCheck", Conversions.ToString(SentSettings.MediumSlotsCheck));
                UpwellStructureViewerSettingsList[2] = new Setting("LowSlotsCheck", Conversions.ToString(SentSettings.LowSlotsCheck));
                UpwellStructureViewerSettingsList[3] = new Setting("ServicesCheck", Conversions.ToString(SentSettings.ServicesCheck));
                UpwellStructureViewerSettingsList[4] = new Setting("ReprocessingRigsCheck", Conversions.ToString(SentSettings.ReprocessingRigsCheck));
                UpwellStructureViewerSettingsList[5] = new Setting("EngineeringRigsCheck", Conversions.ToString(SentSettings.EngineeringRigsCheck));
                UpwellStructureViewerSettingsList[6] = new Setting("CombatRigsCheck", Conversions.ToString(SentSettings.CombatRigsCheck));
                UpwellStructureViewerSettingsList[7] = new Setting("IncludeFuelCostsCheck", Conversions.ToString(SentSettings.IncludeFuelCostsCheck));
                UpwellStructureViewerSettingsList[8] = new Setting("FuelBlockType", SentSettings.FuelBlockType);
                UpwellStructureViewerSettingsList[9] = new Setting("BuyBuildBlockOption", SentSettings.BuyBuildBlockOption);
                UpwellStructureViewerSettingsList[10] = new Setting("AutoUpdateFuelBlockPricesCheck", Conversions.ToString(SentSettings.AutoUpdateFuelBlockPricesCheck));
                UpwellStructureViewerSettingsList[11] = new Setting("SearchFilterText", SentSettings.SearchFilterText);
                UpwellStructureViewerSettingsList[12] = new Setting("SelectedStructureName", SentSettings.SelectedStructureName);
                UpwellStructureViewerSettingsList[13] = new Setting("ReactionsRigsCheck", Conversions.ToString(SentSettings.ReactionsRigsCheck));
                UpwellStructureViewerSettingsList[14] = new Setting("DrillingRigsCheck", Conversions.ToString(SentSettings.DrillingRigsCheck));
                UpwellStructureViewerSettingsList[15] = new Setting("IconListView", Conversions.ToString(SentSettings.IconListView));

                WriteSettingsToFile(Public_Variables.SettingsFolder, UpwellStructureViewerSettingsFileName, UpwellStructureViewerSettingsList, UpwellStructureViewerSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Upwell Structures Viewer Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public UpwellStructureSettings GetUpwellStructureViewerSettings()
        {
            return UpwellStructureViewerSettings;
        }

        #endregion

        #region Bonus Popup Settings

        // Loads the tab settings
        public StructureBonusPopoutSettings LoadStructureBonusPopoutViewerSettings()
        {
            StructureBonusPopoutSettings TempSettings = default;

            try
            {

                if (FileExists(Public_Variables.SettingsFolder, StructureBonusPopoutViewerSettingsFileName))
                {
                    // Get the settings
                    {
                        ref var withBlock = ref TempSettings;
                        string argFileName = StructureBonusPopoutViewerSettingsFileName;
                        string argFileName1 = StructureBonusPopoutViewerSettingsFileName;
                        withBlock.FormHeight = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName1, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "FormHeight", DefaultSBPVFormHeight));
                        string argFileName2 = StructureBonusPopoutViewerSettingsFileName;
                        string argFileName3 = StructureBonusPopoutViewerSettingsFileName;
                        withBlock.FormWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName3, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "FormWidth", DefaultSBPVFormWidth));
                        string argFileName4 = StructureBonusPopoutViewerSettingsFileName;
                        string argFileName5 = StructureBonusPopoutViewerSettingsFileName;
                        withBlock.ActivityColumnWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName5, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "ActivityColumnWidth", DefaultSBPVActivityColumnWidth));
                        string argFileName6 = StructureBonusPopoutViewerSettingsFileName;
                        string argFileName7 = StructureBonusPopoutViewerSettingsFileName;
                        withBlock.BonusAppliesColumnWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName7, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "BonusAppliesColumnWidth", DefaultSBPVBonusAppliesColumnWidth));
                        string argFileName8 = StructureBonusPopoutViewerSettingsFileName;
                        string argFileName9 = StructureBonusPopoutViewerSettingsFileName;
                        withBlock.BonusesColumnWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName9, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "BonusesColumnWidth", DefaultSBPVBonusesColumnWidth));
                        string argFileName10 = StructureBonusPopoutViewerSettingsFileName;
                        string argFileName11 = StructureBonusPopoutViewerSettingsFileName;
                        withBlock.BonusSourceColumnWidth = Conversions.ToInteger(GetSettingValue(Public_Variables.SettingsFolder, ref argFileName11, SettingTypes.TypeInteger, StructureBonusPopoutViewerSettingsFileName, "BonusSourceColumnWidth", DefaultSBPVBonusSourceColumnWidth));
                    }
                }

                else
                {
                    // Load defaults 
                    TempSettings = SetDefaultStructureBonusPopoutViewerSettings();
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when loading UpwellStructureViewer Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Default settings were loaded.", Constants.vbExclamation, Application.ProductName);
                // Load defaults 
                TempSettings = SetDefaultStructureBonusPopoutViewerSettings();
            }

            // Save them locally and then export
            SettingsVariables.StructureBonusPopoutViewerSettings = TempSettings;

            return TempSettings;

        }

        public StructureBonusPopoutSettings SetDefaultStructureBonusPopoutViewerSettings()
        {
            StructureBonusPopoutSettings LocalSettings;

            LocalSettings.FormHeight = DefaultSBPVFormHeight;
            LocalSettings.FormWidth = DefaultSBPVFormWidth;
            LocalSettings.ActivityColumnWidth = DefaultSBPVActivityColumnWidth;
            LocalSettings.BonusAppliesColumnWidth = DefaultSBPVBonusAppliesColumnWidth;
            LocalSettings.BonusesColumnWidth = DefaultSBPVBonusesColumnWidth;
            LocalSettings.BonusSourceColumnWidth = DefaultSBPVBonusSourceColumnWidth;

            // Save locally
            SettingsVariables.StructureBonusPopoutViewerSettings = LocalSettings;
            return LocalSettings;

        }

        // Saves the tab settings to XML
        public void SaveStructureBonusPopoutViewerSettings(StructureBonusPopoutSettings SentSettings)
        {
            var StructureBonusPopoutViewerSettingsList = new Setting[6];

            try
            {
                StructureBonusPopoutViewerSettingsList[0] = new Setting("FormHeight", SentSettings.FormHeight.ToString());
                StructureBonusPopoutViewerSettingsList[1] = new Setting("FormWidth", SentSettings.FormWidth.ToString());
                StructureBonusPopoutViewerSettingsList[2] = new Setting("ActivityColumnWidth", SentSettings.ActivityColumnWidth.ToString());
                StructureBonusPopoutViewerSettingsList[3] = new Setting("BonusAppliesColumnWidth", SentSettings.BonusAppliesColumnWidth.ToString());
                StructureBonusPopoutViewerSettingsList[4] = new Setting("BonusesColumnWidth", SentSettings.BonusesColumnWidth.ToString());
                StructureBonusPopoutViewerSettingsList[5] = new Setting("BonusSourceColumnWidth", SentSettings.BonusSourceColumnWidth.ToString());

                WriteSettingsToFile(Public_Variables.SettingsFolder, StructureBonusPopoutViewerSettingsFileName, StructureBonusPopoutViewerSettingsList, StructureBonusPopoutViewerSettingsFileName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when saving Upwell Structures Viewer Settings. Error: " + Information.Err().Description + Constants.vbCrLf + "Settings not saved.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Returns the tab settings
        public StructureBonusPopoutSettings GetStructureBonusPopoutViewerSettings()
        {
            return SettingsVariables.StructureBonusPopoutViewerSettings;
        }

        #endregion

    }

    // For general program settings
    public struct ApplicationSettings
    {
        public bool CheckforUpdatesonStart;
        public string DataExportFormat;
        public bool AllowSkillOverride;
        public bool ShowToolTips;

        public double RefiningImplantValue;
        public double ManufacturingImplantValue;
        public double CopyImplantValue;

        public bool LoadAssetsonStartup;
        public bool LoadBPsonStartup;
        public bool LoadESIMarketDataonStartup;
        public bool LoadESISystemCostIndiciesDataonStartup;
        public bool LoadESIPublicStructuresonStartup;
        public bool SupressESIStatusMessages;
        public bool DisableSound;
        public bool IncludeInGameLinksinCopyText;

        public bool SaveFacilitiesbyChar;
        public bool LoadBPsbyChar;

        // Station Standings for building and selling
        public double BrokerCorpStanding;
        public double BrokerFactionStanding;

        // For setting default rates
        public double BaseSalesTaxRate;
        public double BaseBrokerFeeRate;
        public double SCCBrokerFeeSurcharge;
        public double SCCIndustryFeeSurcharge;
        public double AlphaAccountTaxRate;
        public double StructureTaxRate;
        public double StationTaxRate;

        // ME/TE for BP's we don't own or haven't entered info for
        public int DefaultBPME;
        public int DefaultBPTE;

        // For Build/Buy 
        public bool CheckBuildBuy; // Default for setting the check box for build/buy on the blueprints screen
        public bool SuggestBuildBPNotOwned; // For Build/Buy suggestions
        public bool SaveBPRelicsDecryptors; // For auto-loading relics and decryptor types
        public bool AlwaysBuyFuelBlocks; // Forces build/buy to always buy fuel blocks instead of making a decision
        public bool AlwaysBuyRAMs; // Forces build/buy to always buy RAMs instead of making a decision

        public bool DisableSVR; // For disabling SVR updates
        public bool DisableGATracking; // for disabling tracking app usage through Google Analytics

        public bool ShareSavedFacilities; // to use the same facility everywhere

        public bool RefineDrillDown; // This is only on the refinery but since it's the only setting there, I'll just save it with application settings

        // Character options
        public bool AlphaAccount; // Check to determine if they are using an alpha account or not
        public bool UseActiveSkillLevels; // Use active skill levels instead of trained - useful for omega on alpha currently
        public bool LoadMaxAlphaSkills; // Load the max alpha skills for dummy accounts

        // For shopping list
        public bool ShopListIncludeInventMats;
        public bool ShopListIncludeCopyMats;

        // The interval for allowing refresh of prices 
        public int UpdatePricesRefreshInterval;

        // Filter variables for svr
        public double IgnoreSVRThresholdValue;
        public string SVRAveragePriceRegion;
        public string SVRAveragePriceDuration;
        public bool AutoUpdateSVRonBPTab;

        public string ProxyAddress;
        public int ProxyPort;

    }

    public enum BuildMatType
    {
        AdvMaterials = 1,
        ProcessedMaterials = 2,
        RawMaterials = 3
    }

    // For BP Tab Settings
    public struct BPTabSettings
    {
        // Form stuff
        public string BlueprintTypeSelection;
        public bool Tech1Check;
        public bool Tech2Check;
        public bool Tech3Check;
        public bool TechStorylineCheck;
        public bool TechFactionCheck;
        public bool TechPirateCheck;
        public bool IncludeIgnoredBPs;

        public bool SmallCheck;
        public bool MediumCheck;
        public bool LargeCheck;
        public bool XLCheck;

        public int IncludeFees; // 0,1,2 - Tri check
        public double BrokerFeeRate;
        public bool IncludeUsage;
        public bool IncludeTaxes;

        public bool IncludeInventionCost;
        public bool IncludeInventionTime;
        public bool IncludeCopyCost;
        public bool IncludeCopyTime;
        public bool IncludeT3Cost;
        public bool IncludeT3Time;

        public bool PricePerUnit;

        public bool SimpleCopyCheck;
        public bool NPCBPOs;

        public int ProductionLines;
        public int LaboratoryLines;
        public int T3Lines;

        public string T2DecryptorType;
        public string RelicType;
        public string T3DecryptorType;

        public bool IgnoreInvention;
        public bool IgnoreMinerals;
        public bool IgnoreT1Item;

        public string ExporttoShoppingListType;

        public int RawColumnSort;
        public string RawColumnSortType;
        public int CompColumnSort;
        public string CompColumnSortType;

        public string RawProfitType;
        public string CompProfitType;

        public bool CompressedOre;

        public bool SellExcessBuildItems;

        public BuildMatType BuildT2T3Materials; // How they want to build T2/T3 items (BuildMatType) - BP Tab

    }

    // For the Market Viewer
    public struct MarketHistoryViewerSettings
    {
        public string DatePreference;

        public bool Volume;
        public bool MinMaxDayPrice;

        public bool LinearTrend;
        public bool DochianChannel;
        public bool FiveDayAvg;
        public bool TwentyDayAvg;

    }

    // For Update Price Settings
    public struct UpdatePriceTabSettings
    {
        public bool AllRawMats;

        public bool AdvancedProtectiveTechnology;
        public bool Gas;
        public bool IceProducts;
        public bool MolecularForgingTools;
        public bool FactionMaterials;
        public bool NamedComponents;
        public bool Minerals;
        public bool Planetary;
        public bool RawMaterials;
        public bool Salvage;
        public bool Misc;
        public bool BPCs;

        public bool AdvancedMoonMats;
        public bool BoosterMats;
        public bool MolecularForgedMats;
        public bool Polymers;
        public bool ProcessedMoonMats;
        public bool RawMoonMats;

        public bool AncientRelics;
        public bool Datacores;
        public bool Decryptors;
        public bool RDB;

        public bool AllManufacturedItems;

        public bool Ships;
        public bool Charges;
        public bool Modules;
        public bool Drones;
        public bool Rigs;
        public bool Subsystems;
        public bool Deployables;
        public bool Boosters;
        public bool Structures;
        public bool StructureRigs;
        public bool Celestials;
        public bool StructureModules;
        public bool Implants;

        public bool AdvancedCapComponents;
        public bool AdvancedComponents;
        public bool FuelBlocks;
        public bool ProtectiveComponents;
        public bool RAM;
        public bool NoBuildItems;
        public bool CapitalShipComponents;
        public bool StructureComponents;
        public bool SubsystemComponents;

        public bool T1;
        public bool T2;
        public bool T3;
        public bool Faction;
        public bool Pirate;
        public bool Storyline;

        public string SelectedRegion;
        public string SelectedSystem;

        // The default price profile settings
        public string PPRawPriceType;
        public string PPRawRegion;
        public string PPRawSystem;
        public double PPRawPriceMod;
        public string PPItemsPriceType;
        public string PPItemsRegion;
        public string PPItemsSystem;
        public double PPItemsPriceMod;

        // For two price types
        public string ItemsCombo;
        public string RawMatsCombo;

        public double ItemsPriceModifier;
        public double RawPriceModifier;

        public DataSource PriceDataSource;
        public bool UsePriceProfile;

        public int ColumnSort;
        public string ColumnSortType;

    }

    public enum DataSource
    {
        CCP = 0,
        EVEMarketer = 1,
        Fuzzworks = 2
    }

    // For Manufacturing Tab Settings
    public struct ManufacturingTabSettings
    {
        public string BlueprintType;

        public bool CheckTech1;
        public bool CheckTech2;
        public bool CheckTech3;
        public bool CheckTechStoryline;
        public bool CheckTechNavy;
        public bool CheckTechPirate;

        public string ItemTypeFilter;
        public string TextItemFilter;

        public bool CheckBPTypeShips;
        public bool CheckBPTypeDrones;
        public bool CheckBPTypeComponents;
        public bool CheckBPTypeStructures;
        public bool CheckBPTypeMisc;
        public bool CheckBPTypeNPCBPOs;
        public bool CheckBPTypeModules;
        public bool CheckBPTypeAmmoCharges;
        public bool CheckBPTypeRigs;
        public bool CheckBPTypeSubsystems;
        public bool CheckBPTypeBoosters;
        public bool CheckBPTypeDeployables;
        public bool CheckBPTypeCelestials;
        public bool CheckBPTypeStructureModules;
        public bool CheckBPTypeStationParts;
        public bool CheckBPTypeReactions;

        public bool CheckCapitalComponentsFacility;
        public bool CheckT3DestroyerFacility;

        public bool CheckAutoCalcNumBPs;

        public bool CheckDecryptorNone;
        public int CheckDecryptorOptimal; // Check State
        public bool CheckDecryptor06;
        public bool CheckDecryptor09;
        public bool CheckDecryptor10;
        public bool CheckDecryptor11;
        public bool CheckDecryptor12;
        public bool CheckDecryptor15;
        public bool CheckDecryptor18;
        public bool CheckDecryptor19;

        public bool CheckDecryptorUseforT2;
        public bool CheckDecryptorUseforT3;

        public bool CheckIgnoreInvention;

        public bool CheckRelicWrecked;
        public bool CheckRelicIntact;
        public bool CheckRelicMalfunction;

        public bool CheckOnlyBuild;
        public bool CheckOnlyInvent;

        public bool CheckIncludeTaxes;
        public int CheckIncludeBrokersFees; // Tri check
        public double CalcBrokerFeeRate;
        public bool CheckIncludeUsage;

        public bool CheckRaceAmarr;
        public bool CheckRaceCaldari;
        public bool CheckRaceGallente;
        public bool CheckRaceMinmatar;
        public bool CheckRacePirate;
        public bool CheckRaceOther;

        public string PriceCompare;

        public bool CheckIncludeT2Owned;
        public bool CheckIncludeT3Owned;

        // Filter variables
        public bool CheckSVRIncludeNull;
        public string PriceTrend;
        public string MinBuildTime;
        public bool MinBuildTimeCheck;
        public string MaxBuildTime;
        public bool MaxBuildTimeCheck;
        public double IPHThreshold;
        public bool IPHThresholdCheck;
        public double ProfitThreshold;
        public int ProfitThresholdCheck;
        public double VolumeThreshold;
        public bool VolumeThresholdCheck;

        public int ProductionLines;
        public int LaboratoryLines;
        public int Runs;
        public int BPRuns;

        public bool CheckSmall;
        public bool CheckMedium;
        public bool CheckLarge;
        public bool CheckXL;

        public bool IgnoreInvention;
        public bool IgnoreMinerals;
        public bool IgnoreT1Item;

        public bool CalcPPU;
        public bool CheckSellExcessItems;

        public string ManufacturingFWUpgradeLevel;
        public string CopyingFWUpgradeLevel;
        public string InventionFWUpgradeLevel;

        public int ColumnSort;
        public string ColumnSortType;

        public BuildMatType BuildT2T3Materials; // How they want to build T2/T3 items (BuildMatType) - BP Tab

    }

    // For Datacore Tab Settings
    public struct DataCoreTabSettings
    {
        public string PricesFrom;

        public bool CheckHighSecAgents;
        public bool CheckLowNullSecAgents;
        public bool CheckIncludeAgentsCannotAccess;

        public string AgentsInRegion;

        public bool CheckSovAmarr;
        public bool CheckSovAmmatar;
        public bool CheckSovGallente;
        public bool CheckSovSyndicate;
        public bool CheckSovKhanid;
        public bool CheckSovThukker;
        public bool CheckSovCaldari;
        public bool CheckSovMinmatar;

        public int[] SkillsChecked;
        public int[] SkillsLevel;

        public int[] CorpsChecked;
        public double[] CorpsStanding;

        public int Connections;
        public int Negotiation;
        public int ResearchProjectMgt;

        public int ColumnSort;
        public string ColumnSortType;

    }

    // For Mining Settings
    public struct MiningTabSettings
    {
        public string OreType; // Ore or Ice

        public bool CheckHighYieldOres;
        public bool CheckHighSecOres;
        public bool CheckLowSecOres;
        public bool CheckNullSecOres;
        public bool CheckA0Ores;

        public bool CheckSovAmarr;
        public bool CheckSovCaldari;
        public bool CheckSovGallente;
        public bool CheckSovMinmatar;
        public bool CheckSovTriglavian;
        public bool CheckEDENCOM;
        public bool CheckSovWormhole;
        public bool CheckSovMoon;
        public bool CheckSovC1;
        public bool CheckSovC2;
        public bool CheckSovC3;
        public bool CheckSovC4;
        public bool CheckSovC5;
        public bool CheckSovC6;

        public bool CheckIncludeFees;
        public bool CheckIncludeTaxes;
        public double BrokerFeeRate;

        public string OreMiningShip;
        public string IceMiningShip;
        public string GasMiningShip;
        public string OreStrip;
        public string IceStrip;
        public string GasHarvester;
        public int NumOreMiners;
        public int NumIceMiners;
        public int NumGasHarvesters;
        public string OreUpgrade;
        public string IceUpgrade;
        public string GasUpgrade;
        public int NumOreUpgrades;
        public int NumIceUpgrades;
        public int NumGasUpgrades;
        public string OreImplant;
        public string IceImplant;
        public string GasImplant;
        public string ShipDroneRig1;
        public string ShipDroneRig2;
        public string ShipDroneRig3;
        public string ShipIceDroneRig1;
        public string ShipIceDroneRig2;
        public string ShipIceDroneRig3;

        public string MiningDrone;
        public string NumMiningDrones;
        public string IceMiningDrone;
        public string NumIceMiningDrones;
        public string DroneOpSkill;
        public string DroneSpecSkill;
        public string DroneInterfaceSkill;
        public string IceDroneOpSkill;
        public string IceDroneSpecSkill;
        public string IceDroneInterfaceSkill;

        public string BoosterMiningDrone;
        public string BoosterNumMiningDrones;
        public string BoosterIceMiningDrone;
        public string BoosterNumIceMiningDrones;
        public string BoosterDroneOpSkill;
        public string BoosterDroneSpecSkill;
        public string BoosterDroneInterfaceSkill;
        public string BoosterIceDroneOpSkill;
        public string BoosterIceDroneSpecSkill;
        public string BoosterIceDroneInterfaceSkill;

        public bool MichiiImplant;
        public bool T1Crystals;
        public bool T2Crystals;

        public bool CrystalTypeA;
        public bool CrystalTypeB;
        public bool CrystalTypeC;

        public bool CheckUseHauler;
        public int RoundTripMin;
        public int RoundTripSec;
        public double Haulerm3;

        public bool CheckUseFleetBooster;
        public string BoosterShip;
        public int BoosterShipSkill;
        public int MiningFormanSkill;
        public int MiningDirectorSkill;
        public int CheckMineForemanLaserOpBoost; // 0,1,2
        public int CheckMineForemanLaserRangeBoost; // 0,1,2
        public bool CheckMiningForemanMindLink;
        public bool BoosterUseDrones;
        public int BoosterDroneRig1;
        public int BoosterDroneRig2;
        public int BoosterDroneRig3;
        public int BoosterIceDroneRig1;
        public int BoosterIceDroneRig2;
        public int BoosterIceDroneRig3;

        public int CheckRorqDeployed;  // 0,1,2
        public int IndustrialReconfig;

        public int NumberofMiners;

        public bool RefinedOre;
        public bool UnrefinedOre;
        public bool CompressedOre;

        public int ColumnSort;
        public string ColumnSortType;

    }

    // If we show these columns or not
    public struct IndustryJobsColumnSettings
    {

        // These are the column orders and shown/not shown. 0 is not shown, else the order number
        public int JobState;
        public int InstallerName;
        public int TimeToComplete;
        public int Activity;
        public int Status;
        public int StartTime;
        public int EndTime;
        public int CompletionTime;
        public int Blueprint;
        public int OutputItem;
        public int OutputItemType;
        public int InstallSystem;
        public int InstallRegion;
        public int LicensedRuns;
        public int Runs;
        public int SuccessfulRuns;
        public int BlueprintLocation;
        public int OutputLocation;
        public int JobType; // Personal or Corp
        public int LocalCompletionDateTime;

        public int JobStateWidth;
        public int InstallerNameWidth;
        public int TimeToCompleteWidth;
        public int ActivityWidth;
        public int StatusWidth;
        public int StartTimeWidth;
        public int EndTimeWidth;
        public int CompletionTimeWidth;
        public int BlueprintWidth;
        public int OutputItemWidth;
        public int OutputItemTypeWidth;
        public int InstallSystemWidth;
        public int InstallRegionWidth;
        public int LicensedRunsWidth;
        public int RunsWidth;
        public int SuccessfulRunsWidth;
        public int BlueprintLocationWidth;
        public int OutputLocationWidth;
        public int JobTypeWidth; // Personal or Corp
        public int LocalCompletionDateTimeWidth;

        public int OrderByColumn; // What column index the jobs are sorted
        public string OrderType; // Ascending or Descending

        public string ViewJobType; // Personal, Corp, or Both

        public string JobTimes; // Current or History

        // List of selected characters, comma separated - default is going to be empty but will automatically choose the selected character
        public string SelectedCharacterIDs;

        // Whether we automatically update jobs every time they open the window - if not checked, they need to hit 'Update Jobs'
        public bool AutoUpdateJobs;

    }

    // If we show these columns or not
    public struct ManufacturingTabColumnSettings
    {

        // These are the column orders and shown/not shown. 0 is not shown so it can be used for the order number
        public int ItemCategory;
        public int ItemGroup;
        public int ItemName;
        public int Owned;
        public int Tech;
        public int BPME;
        public int BPTE;
        public int Inputs;
        public int Compared;
        public int TotalRuns;
        public int SingleInventedBPCRuns;
        public int ProductionLines;
        public int LaboratoryLines;
        public int TotalInventionCost;
        public int TotalCopyCost;
        public int Taxes;
        public int BrokerFees;
        public int BPProductionTime;
        public int TotalProductionTime;
        public int CopyTime;
        public int InventionTime;
        public int ItemMarketPrice;
        public int Profit;
        public int ProfitPercentage;
        public int IskperHour;
        public int SVR;
        public int SVRxIPH;
        public int PriceTrend;
        public int TotalItemsSold;
        public int TotalOrdersFilled;
        public int AvgItemsperOrder;
        public int CurrentSellOrders;
        public int CurrentBuyOrders;
        public int ItemsinProduction;
        public int ItemsinStock;
        public int MaterialCost;
        public int TotalCost;
        public int BaseJobCost;
        public int NumBPs;
        public int InventionChance;
        public int BPType;
        public int Race;
        public int VolumeperItem;
        public int TotalVolume;
        public int SellExcess;
        public int ROI;
        public int PortionSize;
        public int ManufacturingJobFee;
        public int ManufacturingFacilityName;
        public int ManufacturingFacilitySystem;
        public int ManufacturingFacilityRegion;
        public int ManufacturingFacilitySystemIndex;
        public int ManufacturingFacilityTax;
        public int ManufacturingFacilityMEBonus;
        public int ManufacturingFacilityTEBonus;
        public int ManufacturingFacilityUsage;
        public int ManufacturingFacilityFWSystemLevel;
        public int ComponentFacilityName;
        public int ComponentFacilitySystem;
        public int ComponentFacilityRegion;
        public int ComponentFacilitySystemIndex;
        public int ComponentFacilityTax;
        public int ComponentFacilityMEBonus;
        public int ComponentFacilityTEBonus;
        public int ComponentFacilityUsage;
        public int ComponentFacilityFWSystemLevel;
        public int CapComponentFacilityName;
        public int CapComponentFacilitySystem;
        public int CapComponentFacilityRegion;
        public int CapComponentFacilitySystemIndex;
        public int CapComponentFacilityTax;
        public int CapComponentFacilityMEBonus;
        public int CapComponentFacilityTEBonus;
        public int CapComponentFacilityUsage;
        public int CapComponentFacilityFWSystemLevel;
        public int CopyingFacilityName;
        public int CopyingFacilitySystem;
        public int CopyingFacilityRegion;
        public int CopyingFacilitySystemIndex;
        public int CopyingFacilityTax;
        public int CopyingFacilityMEBonus;
        public int CopyingFacilityTEBonus;
        public int CopyingFacilityUsage;
        public int CopyingFacilityFWSystemLevel;
        public int InventionFacilityName;
        public int InventionFacilitySystem;
        public int InventionFacilityRegion;
        public int InventionFacilitySystemIndex;
        public int InventionFacilityTax;
        public int InventionFacilityMEBonus;
        public int InventionFacilityTEBonus;
        public int InventionFacilityUsage;
        public int InventionFacilityFWSystemLevel;
        public int ReactionFacilityName;
        public int ReactionFacilitySystem;
        public int ReactionFacilityRegion;
        public int ReactionFacilitySystemIndex;
        public int ReactionFacilityTax;
        public int ReactionFacilityMEBonus;
        public int ReactionFacilityTEBonus;
        public int ReactionFacilityUsage;
        public int ReactionFacilityFWSystemLevel;
        public int ReprocessingFacilityName;
        public int ReprocessingFacilitySystem;
        public int ReprocessingFacilityRegion;
        public int ReprocessingFacilityTax;
        public int ReprocessingFacilityUsage;
        public int ReprocessingFacilityOreRefineRate;
        public int ReprocessingFacilityIceRefineRate;
        public int ReprocessingFacilityMoonRefineRate;

        public int ItemCategoryWidth;
        public int ItemGroupWidth;
        public int ItemNameWidth;
        public int OwnedWidth;
        public int TechWidth;
        public int BPMEWidth;
        public int BPTEWidth;
        public int InputsWidth;
        public int ComparedWidth;
        public int TotalRunsWidth;
        public int SingleInventedBPCRunsWidth;
        public int ProductionLinesWidth;
        public int LaboratoryLinesWidth;
        public int TotalInventionCostWidth;
        public int TotalCopyCostWidth;
        public int TaxesWidth;
        public int BrokerFeesWidth;
        public int BPProductionTimeWidth;
        public int TotalProductionTimeWidth;
        public int CopyTimeWidth;
        public int InventionTimeWidth;
        public int ItemMarketPriceWidth;
        public int ProfitWidth;
        public int ProfitPercentageWidth;
        public int IskperHourWidth;
        public int SVRWidth;
        public int SVRxIPHWidth;
        public int PriceTrendWidth;
        public int TotalItemsSoldWidth;
        public int TotalOrdersFilledWidth;
        public int AvgItemsperOrderWidth;
        public int CurrentSellOrdersWidth;
        public int CurrentBuyOrdersWidth;
        public int ItemsinProductionWidth;
        public int ItemsinStockWidth;
        public int MaterialCostWidth;
        public int TotalCostWidth;
        public int BaseJobCostWidth;
        public int NumBPsWidth;
        public int InventionChanceWidth;
        public int BPTypeWidth;
        public int RaceWidth;
        public int VolumeperItemWidth;
        public int TotalVolumeWidth;
        public int SellExcessWidth;
        public int ROIWidth;
        public int PortionSizeWidth;
        public int ManufacturingJobFeeWidth;
        public int ManufacturingFacilityNameWidth;
        public int ManufacturingFacilitySystemWidth;
        public int ManufacturingFacilityRegionWidth;
        public int ManufacturingFacilitySystemIndexWidth;
        public int ManufacturingFacilityTaxWidth;
        public int ManufacturingFacilityMEBonusWidth;
        public int ManufacturingFacilityTEBonusWidth;
        public int ManufacturingFacilityUsageWidth;
        public int ManufacturingFacilityFWSystemLevelWidth;
        public int ComponentFacilityNameWidth;
        public int ComponentFacilitySystemWidth;
        public int ComponentFacilityRegionWidth;
        public int ComponentFacilitySystemIndexWidth;
        public int ComponentFacilityTaxWidth;
        public int ComponentFacilityMEBonusWidth;
        public int ComponentFacilityTEBonusWidth;
        public int ComponentFacilityUsageWidth;
        public int ComponentFacilityFWSystemLevelWidth;
        public int CapComponentFacilityNameWidth;
        public int CapComponentFacilitySystemWidth;
        public int CapComponentFacilityRegionWidth;
        public int CapComponentFacilitySystemIndexWidth;
        public int CapComponentFacilityTaxWidth;
        public int CapComponentFacilityMEBonusWidth;
        public int CapComponentFacilityTEBonusWidth;
        public int CapComponentFacilityUsageWidth;
        public int CapComponentFacilityFWSystemLevelWidth;
        public int CopyingFacilityNameWidth;
        public int CopyingFacilitySystemWidth;
        public int CopyingFacilityRegionWidth;
        public int CopyingFacilitySystemIndexWidth;
        public int CopyingFacilityTaxWidth;
        public int CopyingFacilityMEBonusWidth;
        public int CopyingFacilityTEBonusWidth;
        public int CopyingFacilityUsageWidth;
        public int CopyingFacilityFWSystemLevelWidth;
        public int InventionFacilityNameWidth;
        public int InventionFacilitySystemWidth;
        public int InventionFacilityRegionWidth;
        public int InventionFacilitySystemIndexWidth;
        public int InventionFacilityTaxWidth;
        public int InventionFacilityMEBonusWidth;
        public int InventionFacilityTEBonusWidth;
        public int InventionFacilityUsageWidth;
        public int InventionFacilityFWSystemLevelWidth;
        public int ReactionFacilityNameWidth;
        public int ReactionFacilitySystemWidth;
        public int ReactionFacilityRegionWidth;
        public int ReactionFacilitySystemIndexWidth;
        public int ReactionFacilityTaxWidth;
        public int ReactionFacilityMEBonusWidth;
        public int ReactionFacilityTEBonusWidth;
        public int ReactionFacilityUsageWidth;
        public int ReactionFacilityFWSystemLevelWidth;
        public int ReprocessingFacilityNameWidth;
        public int ReprocessingFacilitySystemWidth;
        public int ReprocessingFacilityRegionWidth;
        public int ReprocessingFacilityTaxWidth;
        public int ReprocessingFacilityUsageWidth;
        public int ReprocessingFacilityOreRefineRateWidth;
        public int ReprocessingFacilityIceRefineRateWidth;
        public int ReprocessingFacilityMoonRefineRateWidth;

        public int OrderByColumn; // What column index the jobs are sorted
        public string OrderType; // Ascending or Descending

    }

    // For Main Industry Flip Belt Settings
    public struct IndustryFlipBeltSettings
    {
        public double CycleTime;
        public double m3perCycle;
        public int NumMiners;
        public bool CompressOre;
        public bool IPHperMiner;
        public int IncludeBrokerFees;
        public bool IncludeTaxes;
        public double BrokerFeeRate;
        public string TrueSec;
    }

    // For the checked ore on each mining tab
    public struct IndustryBeltOreChecks
    {
        public bool Plagioclase;
        public bool Spodumain;
        public bool Kernite;
        public bool Hedbergite;
        public bool Arkonor;
        public bool Bistot;
        public bool Pyroxeres;
        public bool Crokite;
        public bool Jaspet;
        public bool Omber;
        public bool Scordite;
        public bool Gneiss;
        public bool Veldspar;
        public bool Hemorphite;
        public bool DarkOchre;
        public bool Mercoxit;
        public bool CrimsonArkonor;
        public bool PrimeArkonor;
        public bool TriclinicBistot;
        public bool MonoclinicBistot;
        public bool SharpCrokite;
        public bool CrystallineCrokite;
        public bool OnyxOchre;
        public bool ObsidianOchre;
        public bool VitricHedbergite;
        public bool GlazedHedbergite;
        public bool VividHemorphite;
        public bool RadiantHemorphite;
        public bool PureJaspet;
        public bool PristineJaspet;
        public bool LuminousKernite;
        public bool FieryKernite;
        public bool AzurePlagioclase;
        public bool RichPlagioclase;
        public bool SolidPyroxeres;
        public bool ViscousPyroxeres;
        public bool CondensedScordite;
        public bool MassiveScordite;
        public bool BrightSpodumain;
        public bool GleamingSpodumain;
        public bool ConcentratedVeldspar;
        public bool DenseVeldspar;
        public bool IridescentGneiss;
        public bool PrismaticGneiss;
        public bool SilveryOmber;
        public bool GoldenOmber;
        public bool MagmaMercoxit;
        public bool VitreousMercoxit;
    }

    // For Ice Flip Belt Settings
    public struct IceBeltFlipSettings
    {
        public double CycleTime;
        public double m3perCycle;
        public int NumMiners;
        public bool CompressOre;
        public bool IPHperMiner;
        public bool IncludeTaxes;
        public int IncludeBrokerFees;
        public double BrokerFeeRate;
        public string SystemSecurity;
        public string Space;
    }

    // For the checked ore on each mining tab
    public struct IceBeltCheckSettings
    {
        public bool BlueIce;
        public bool ClearIcicle;
        public bool DarkGlitter;
        public bool EnrichedClearIcicle;
        public bool Gelidus;
        public bool GlacialMass;
        public bool GlareCrust;
        public bool Krystallos;
        public bool PristineWhiteGlaze;
        public bool SmoothGlacialMass;
        public bool ThickBlueIce;
        public bool WhiteGlaze;

        public bool CompressedBlueIce;
        public bool CompressedClearIcicle;
        public bool CompressedDarkGlitter;
        public bool CompressedEnrichedClearIcicle;
        public bool CompressedGelidus;
        public bool CompressedGlacialMass;
        public bool CompressedGlareCrust;
        public bool CompressedKrystallos;
        public bool CompressedPristineWhiteGlaze;
        public bool CompressedSmoothGlacialMass;
        public bool CompressedThickBlueIce;
        public bool CompressedWhiteGlaze;

    }

    // For Ice Flip Belt Settings
    public struct ConversionToOreSettings
    {
        public string ConversionType;
        public string MinimizeOn;
        public bool CompressedOre;
        public bool CompressedIce;
        public bool HighSec;
        public bool LowSec;
        public bool NullSec;
        public bool OreVariant0;
        public bool OreVariant5;
        public bool OreVariant10;
        public bool Amarr;
        public bool Caldari;
        public bool Gallente;
        public bool Minmatar;
        public bool Wormhole;
        public bool Triglavian;
        public bool C1;
        public bool C2;
        public bool C3;
        public bool C4;
        public bool C5;
        public bool C6;
        // List of 35 check boxes cooresponds to the checks on settings for override savings
        public int[] OverrideChecks;
        public List<OreType> SelectedOres;
        // Names of all the item checks that they want to ignore in minerals/ice products to ores (meaning don't consider them in the conversion)
        public int[] IgnoreRefinedItems;
        public List<string> IgnoreItems;

    }

    public struct OreType
    {
        public string OreName;
        public string OreGroup; // Ice or Ore
    }

    // For Assets Selected Item Settings
    public struct AssetWindowSettings
    {

        // Main window
        public string AssetType;
        public bool SortbyName;

        // Selected Items
        public string ItemFilterText;
        public bool AllItems;

        public bool AllRawMats;

        public bool AdvancedProtectiveTechnology;
        public bool Gas;
        public bool IceProducts;
        public bool MolecularForgingTools;
        public bool FactionMaterials;
        public bool NamedComponents;
        public bool Minerals;
        public bool Planetary;
        public bool RawMaterials;
        public bool Salvage;
        public bool Misc;
        public bool BPCs;

        public bool AdvancedMoonMats;
        public bool BoosterMats;
        public bool MolecularForgedMats;
        public bool Polymers;
        public bool ProcessedMoonMats;
        public bool RawMoonMats;

        public bool AncientRelics;
        public bool Datacores;
        public bool Decryptors;
        public bool RDB;

        public bool AllManufacturedItems;

        public bool Ships;
        public bool Charges;
        public bool Modules;
        public bool Drones;
        public bool Rigs;
        public bool Subsystems;
        public bool Deployables;
        public bool Boosters;
        public bool Structures;
        public bool StructureRigs;
        public bool Celestials;
        public bool StructureModules;
        public bool Implants;

        public bool AdvancedCapComponents;
        public bool AdvancedComponents;
        public bool FuelBlocks;
        public bool ProtectiveComponents;
        public bool RAM;
        public bool NoBuildItems;
        public bool CapitalShipComponents;
        public bool StructureComponents;
        public bool SubsystemComponents;

        public bool T1;
        public bool T2;
        public bool T3;
        public bool Faction;
        public bool Pirate;
        public bool Storyline;

    }

    // For the Shopping List
    public struct ShoppingListSettings
    {
        public string DataExportFormat;
        public bool AlwaysonTop;
        public bool UpdateAssetsWhenUsed;
        public bool Fees;
        public int CalcBuyBuyOrder;
        public bool Usage;
        public bool ReloadBPsFromFile;
    }

    // For the BP Viewer
    public struct BPViewerSettings
    {
        public string BlueprintTypeSelection; // Saves the name of the radio button used

        public bool BPNPCBPOsCheck;

        public bool Tech1Check;
        public bool Tech2Check;
        public bool Tech3Check;
        public bool TechStorylineCheck;
        public bool TechFactionCheck;
        public bool TechPirateCheck;

        public bool IncludeIgnoredBPs;

        public bool SmallCheck;
        public bool MediumCheck;
        public bool LargeCheck;
        public bool XLCheck;
    }

    // For Upwell Structures fitting window
    public struct UpwellStructureSettings
    {
        public bool HighSlotsCheck;
        public bool MediumSlotsCheck;
        public bool LowSlotsCheck;
        public bool ServicesCheck;
        public bool ReprocessingRigsCheck;
        public bool EngineeringRigsCheck;
        public bool CombatRigsCheck;
        public bool ReactionsRigsCheck;
        public bool DrillingRigsCheck;

        public bool IncludeFuelCostsCheck;
        public string FuelBlockType;
        public string BuyBuildBlockOption;
        public bool AutoUpdateFuelBlockPricesCheck;
        public string SearchFilterText;
        public string SelectedStructureName;

        public bool IconListView;

    }

    // For structure bonus viewing
    public struct StructureBonusPopoutSettings
    {
        public int FormWidth;
        public int FormHeight;
        public int BonusAppliesColumnWidth;
        public int ActivityColumnWidth;
        public int BonusesColumnWidth;
        public int BonusSourceColumnWidth;
    }
}