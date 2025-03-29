using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmSettings
    {

        private bool SSLoaded;
        private bool RegionLoaded;
        private bool FirstLoad;
        private bool SelectedReset;
        private bool SVRComboLoaded;

        private bool ReloadSkills;

        private ProgramSettings Defaults = new ProgramSettings(); // For default constants

        #region Click object Functions

        private void chkBeanCounterManufacturing_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                if (chkBeanCounterManufacturing.Checked)
                {
                    cmbBeanCounterManufacturing.Enabled = true;
                    cmbBeanCounterManufacturing.Text = "Zainou 'Beancounter' Industry BX-802";
                }
                else
                {
                    cmbBeanCounterManufacturing.Enabled = false;
                    cmbBeanCounterManufacturing.Text = "";
                }
            }
            btnSave.Text = "Save";
        }

        private void chkBeanCounterRefining_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                if (chkBeanCounterRefining.Checked)
                {
                    cmbBeanCounterRefining.Enabled = true;
                    cmbBeanCounterRefining.Text = "Zainou 'Beancounter' Reprocessing RX-802";
                }
                else
                {
                    cmbBeanCounterRefining.Enabled = false;
                    cmbBeanCounterRefining.Text = "";
                }
            }
            btnSave.Text = "Save";
        }

        private void chkBeanCounterCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                if (chkBeanCounterCopy.Checked)
                {
                    cmbBeanCounterCopy.Enabled = true;
                    cmbBeanCounterCopy.Text = "Zainou 'Beancounter' Science SC-803";
                }
                else
                {
                    cmbBeanCounterCopy.Enabled = false;
                    cmbBeanCounterCopy.Text = "";
                }
            }
            btnSave.Text = "Save";
        }

        private void chkBrokerCorpStanding_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBrokerCorpStanding.Checked == true)
            {
                txtBrokerCorpStanding.Enabled = true;
                txtBrokerCorpStanding.Focus();
            }
            else
            {
                txtBrokerCorpStanding.Enabled = false;
                txtBrokerCorpStanding.Text = Strings.FormatNumber(Defaults.DefaultBrokerCorpStanding, 2);
            }
            btnSave.Text = "Save";
        }

        private void chkBrokerFactionStanding_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBrokerFactionStanding.Checked == true)
            {
                txtBrokerFactionStanding.Enabled = true;
                txtBrokerFactionStanding.Focus();
            }
            else
            {
                txtBrokerFactionStanding.Enabled = false;
                txtBrokerFactionStanding.Text = Strings.FormatNumber(Defaults.DefaultBrokerFactionStanding, 2);
            }
            btnSave.Text = "Save";
        }

        private void txtEVEMarketerInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                // Only integer values
                if (Public_Variables.allowedRunschars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtBrokerFactionStandings_keypress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedDecimalChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtBrokerCorpStandings_keypress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedDecimalChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtRefineCorpStanding_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedDecimalChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void chkShowToolTips_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkCheckUpdatesStartup_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkBuildBuyDefault_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkDefaultME_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDefaultME.Checked == true)
            {
                txtDefaultME.Enabled = true;
                txtDefaultME.Focus();
            }
            else
            {
                txtDefaultME.Enabled = false;
                txtDefaultME.Text = Strings.FormatNumber(Defaults.DefaultSettingME, 0);
            }
            btnSave.Text = "Save";
        }

        private void chkEVEMarketerInterval_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFuzzworksMarketInterval.Checked == true)
            {
                txtFuzzworksMarketInterval.Enabled = true;
                txtFuzzworksMarketInterval.Focus();
            }
            else
            {
                txtFuzzworksMarketInterval.Enabled = false;
                txtFuzzworksMarketInterval.Text = Strings.FormatNumber(Defaults.DefaultUpdatePricesRefreshInterval, 0);
            }
            btnSave.Text = "Save";
        }

        private void chkDefaultPE_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDefaultTE.Checked == true)
            {
                txtDefaultTE.Enabled = true;
                txtDefaultTE.Focus();
            }
            else
            {
                txtDefaultTE.Enabled = false;
                txtDefaultTE.Text = Strings.FormatNumber(Defaults.DefaultSettingTE, 0);
            }
            btnSave.Text = "Save";
        }

        private void chkDisableSVR_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkDisableSound_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkSaveFacilitiesbyChar_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkLoadBPsbyChar_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void cmbRefineTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers, period or percent and backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedPercentChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void chkRefreshMarketDataonStartup_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkRefreshFacilityDataonStartup_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void rbtnExportDefault_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void rbtnExportCSV_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void rbtnExportSSV_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkSaveBPRelicsDecryptors_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkBuyFuelBlocks_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void chkBuyRAMs_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void rbtnBuildT2T3AdvancedMats_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void rbtnBuildT2ProcessedMats_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void rbtnBuildT2T3RawMats_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        private void cmbSVRAvgPriceDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedRunschars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtSVRThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedDecimalChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
                else
                {
                    btnSave.Text = "Save";
                }
            }
        }

        private void cmbSVRRegion_DropDown(object sender, EventArgs e)
        {
            if (!SVRComboLoaded)
            {
                var argRegionCombo = cmbSVRRegion;
                Public_Variables.LoadRegionCombo(ref argRegionCombo, SettingsVariables.UserApplicationSettings.SVRAveragePriceRegion);
                cmbSVRRegion = argRegionCombo;
                SVRComboLoaded = true;
            }
        }

        private void cmbSVRRegion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtDefaultME_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedRunschars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtDefaultTE_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedRunschars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtProxyPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedRunschars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
                else
                {
                    btnSave.Text = "Save";
                }
            }
        }

        private void txtProxyAddress_TextChanged(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
        }

        #endregion

        public frmSettings()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            SSLoaded = false;
            RegionLoaded = false;
            btnSave.Text = "Save";
            FirstLoad = true;
            SelectedReset = false;
            SVRComboLoaded = false;
            ReloadSkills = false;

            if (SettingsVariables.UserApplicationSettings.ShowToolTips)
            {
                {
                    var withBlock = ToolTip1;
                    // General
                    withBlock.SetToolTip(chkShowToolTips, "Toogles tool tips through out IPH");
                    withBlock.SetToolTip(chkLinksInCopyText, "Copying data to the clipboard will contain formatted text that enables in-game links to show when pasted in game");
                    withBlock.SetToolTip(chkDisableSVR, "If you have issues with SVR updates on the Manufacturing Tab (ie website down, etc), you can disable those queries here");
                    withBlock.SetToolTip(rbtnExportCSV, "Exports data in Common Separated Values with periods for decimals");
                    withBlock.SetToolTip(chkDisableSound, "Disables sound functions in IPH");
                    withBlock.SetToolTip(chkSaveFacilitiesbyChar, "When checked, saved facilities will only apply to the selected character. If unchecked, all characters will share saved facilities");
                    withBlock.SetToolTip(chkLoadBPsbyChar, "When checked, blueprints loaded into IPH will be different for each character. If unchecked, all characters share the same BPs");
                    withBlock.SetToolTip(chkDisableTracking, "When checked, IPH will not send anonymous useage data to Google Analytics");
                    withBlock.SetToolTip(chkShareFacilities, "When checked, IPH will use the same facility type saved on any form when used on any other form. If unchecked, IPH will save each facility uniquely");

                    // Startup Options
                    withBlock.SetToolTip(chkCheckUpdatesStartup, "IPH will check for program updates when the program starts");
                    withBlock.SetToolTip(chkRefreshAssetsonStartup, "When checked, IPH will refresh assets (if cache date has past) for the selected character");
                    withBlock.SetToolTip(chkRefreshBPsonStartup, "When checked, IPH will refresh blueprints (if cache date has past) for the selected character");
                    withBlock.SetToolTip(chkRefreshMarketDataonStartup, "When checked, IPH will refresh average and adjusted market prices (if cache date has past) on startup for use in industry calcuations");
                    withBlock.SetToolTip(chkRefreshSystemCostIndiciesDataonStartup, "When checked, IPH will refresh the system industry indicies on startup (if cache date has past) for use in industry calculations");
                    withBlock.SetToolTip(chkRefreshPublicStructureDataonStartup, "When checked, IPH will refresh data on public structures (if cache date has past) for use in price updates");
                    withBlock.SetToolTip(chkSupressESImsgs, "When checked, supresses messages if there are ESI Status errors.");

                    // SVR Settings
                    withBlock.SetToolTip(lblSVRThreshold, "When set, this will be the default threshold for Sales to Volume Ratio on the BP and Manufacturing tabs");
                    withBlock.SetToolTip(lblSVRAvgPrice, "When set, this will be the default days the Sales to Volume Ratio will be averaged over for the BP and Manufacturing tabs");
                    withBlock.SetToolTip(lblSVRRegion, "When set, this will be the default region for Sales to Volume Ratio calcuations on the BP and Manufacturing tabs");
                    withBlock.SetToolTip(chkAutoUpdateSVRBPTab, "When set, the Sales to Volume Ratio will be updated on the BP tab when a Blueprint is selected");

                    // Export Data
                    withBlock.SetToolTip(rbtnExportSSV, "Exports data in SemiColon Separated Values with commas for decimals");
                    withBlock.SetToolTip(rbtnExportDefault, "Exports data in basic space or dashes to separate data for easy readability");
                    withBlock.SetToolTip(rbtnExportCSV, "Exports data in Comma Separated Values");

                    // Character Options
                    withBlock.SetToolTip(chkAlphaAccount, "When checked, IPH will calculate costs adding the 2% industry tax on industry and science jobs");
                    withBlock.SetToolTip(chkUseActiveSkills, "When checked, IPH will use active skills instead of trained skills for calculations (useful for unsubscribed Omega accounts in Alpha)");
                    withBlock.SetToolTip(chkLoadMaxAlphaSkills, "When checked, IPH will load the maximum trainable alpha skills for a dummy character.");

                    // Tips by Group box
                    withBlock.SetToolTip(gbImplants, "Select implants to use with selected characters for industry calculations");
                    withBlock.SetToolTip(gbDefaultMEPE, "On the BP and Manufacturing tabs, these default ME and TE values will be used for non-owned blueprints");
                    withBlock.SetToolTip(gbShoppingList, "If checked, then IPH will send invention or copy materials needed to the shopping list when saving the build information for a blueprint");
                    withBlock.SetToolTip(gb3rdpartyMarketRefresh, "The value stored here is the cache date (how often IPH will update) for EVE Marketer prices");
                    withBlock.SetToolTip(gbStationStandings, "Station standings affect broker fees and some other industry related fees based on standing. These values here will be used in those calculations.");
                    withBlock.SetToolTip(gbProxySettings, "When proxy information is in both the port and address, IPH will use this to connect to CCP servers. Note this information will also be used with the EVE IPH updater");

                    withBlock.SetToolTip(chkAlwaysBuyFuelBlocks, "When selected, IPH will always force buying of fuel blocks as components in Build/Buy calculations");
                    withBlock.SetToolTip(chkAlwaysBuyRAMs, "When selected, IPH will always force buying of R.A.M.s as components in Build/Buy calculations");
                }
            }

        }

        private void frmSettings_Shown(object sender, EventArgs e)
        {
            // Load the settings for the program from DB
            LoadFormSettings();
        }

        private void LoadFormSettings()
        {

            var AttribLookup = new EVEAttributes();

            {
                ref var withBlock = ref SettingsVariables.UserApplicationSettings;
                // General Settings
                chkCheckUpdatesStartup.Checked = withBlock.CheckforUpdatesonStart;

                if ((rbtnExportCSV.Text ?? "") == (withBlock.DataExportFormat ?? ""))
                {
                    rbtnExportCSV.Checked = true;
                }
                else if ((rbtnExportSSV.Text ?? "") == (withBlock.DataExportFormat ?? ""))
                {
                    rbtnExportSSV.Checked = true;
                }
                else if ((rbtnExportDefault.Text ?? "") == (withBlock.DataExportFormat ?? ""))
                {
                    rbtnExportDefault.Checked = true;
                }

                chkShowToolTips.Checked = withBlock.ShowToolTips;
                chkRefreshAssetsonStartup.Checked = withBlock.LoadAssetsonStartup;
                chkRefreshBPsonStartup.Checked = withBlock.LoadBPsonStartup;
                chkDisableSound.Checked = withBlock.DisableSound;

                chkLoadBPsbyChar.Checked = withBlock.LoadBPsbyChar;
                chkSaveFacilitiesbyChar.Checked = withBlock.SaveFacilitiesbyChar;

                // ESI
                chkRefreshSystemCostIndiciesDataonStartup.Checked = withBlock.LoadESISystemCostIndiciesDataonStartup;
                chkRefreshMarketDataonStartup.Checked = withBlock.LoadESIMarketDataonStartup;
                chkRefreshPublicStructureDataonStartup.Checked = withBlock.LoadESIPublicStructuresonStartup;
                chkSupressESImsgs.Checked = withBlock.SupressESIStatusMessages;

                if (withBlock.BrokerCorpStanding == Defaults.DefaultBrokerCorpStanding)
                {
                    // Default
                    chkBrokerCorpStanding.Checked = false;
                    txtBrokerCorpStanding.Enabled = false;
                    txtBrokerCorpStanding.Text = Strings.FormatNumber(Defaults.DefaultBrokerCorpStanding, 2);
                }
                else
                {
                    // User
                    chkBrokerCorpStanding.Checked = true;
                    txtBrokerCorpStanding.Enabled = true;
                    txtBrokerCorpStanding.Text = Strings.FormatNumber(withBlock.BrokerCorpStanding, 2);
                }

                if (withBlock.BrokerFactionStanding == Defaults.DefaultBrokerFactionStanding)
                {
                    // Default
                    chkBrokerFactionStanding.Checked = false;
                    txtBrokerFactionStanding.Enabled = false;
                    txtBrokerFactionStanding.Text = Strings.FormatNumber(Defaults.DefaultBrokerFactionStanding, 2);
                }
                else
                {
                    // User
                    chkBrokerFactionStanding.Checked = true;
                    txtBrokerFactionStanding.Enabled = true;
                    txtBrokerFactionStanding.Text = Strings.FormatNumber(withBlock.BrokerFactionStanding, 2);
                }

                // Implants
                if (withBlock.ManufacturingImplantValue > 0d)
                {
                    chkBeanCounterManufacturing.Checked = true;
                    switch (withBlock.ManufacturingImplantValue)
                    {
                        case var @case when @case == -1 * AttribLookup.GetAttribute(Defaults.MBeanCounterName + "1", ItemAttributes.manufacturingTimeBonus) / 100d:
                            {
                                cmbBeanCounterManufacturing.Text = Defaults.MBeanCounterName + "1";
                                break;
                            }
                        case var case1 when case1 == -1 * AttribLookup.GetAttribute(Defaults.MBeanCounterName + "2", ItemAttributes.manufacturingTimeBonus) / 100d:
                            {
                                cmbBeanCounterManufacturing.Text = Defaults.MBeanCounterName + "2";
                                break;
                            }
                        case var case2 when case2 == -1 * AttribLookup.GetAttribute(Defaults.MBeanCounterName + "4", ItemAttributes.manufacturingTimeBonus) / 100d:
                            {
                                cmbBeanCounterManufacturing.Text = Defaults.MBeanCounterName + "4";
                                break;
                            }
                    }
                }
                else
                {
                    cmbBeanCounterManufacturing.Enabled = false;
                }

                if (withBlock.RefiningImplantValue > 0d)
                {
                    chkBeanCounterRefining.Checked = true;
                    switch (withBlock.RefiningImplantValue)
                    {
                        case var case3 when case3 == AttribLookup.GetAttribute(Defaults.RBeanCounterName + "1", ItemAttributes.refiningYieldMutator) / 100d:
                            {
                                cmbBeanCounterRefining.Text = Defaults.RBeanCounterName + "1";
                                break;
                            }
                        case var case4 when case4 == AttribLookup.GetAttribute(Defaults.RBeanCounterName + "2", ItemAttributes.refiningYieldMutator) / 100d:
                            {
                                cmbBeanCounterRefining.Text = Defaults.RBeanCounterName + "2";
                                break;
                            }
                        case var case5 when case5 == AttribLookup.GetAttribute(Defaults.RBeanCounterName + "4", ItemAttributes.refiningYieldMutator) / 100d:
                            {
                                cmbBeanCounterRefining.Text = Defaults.RBeanCounterName + "4";
                                break;
                            }
                    }
                }
                else
                {
                    cmbBeanCounterRefining.Enabled = false;
                }

                if (withBlock.CopyImplantValue > 0d)
                {
                    chkBeanCounterCopy.Checked = true;
                    switch (withBlock.CopyImplantValue)
                    {
                        case var case6 when case6 == -1 * AttribLookup.GetAttribute(Defaults.MBeanCounterName + "1", ItemAttributes.copySpeedBonus) / 100d:
                            {
                                cmbBeanCounterCopy.Text = Defaults.CBeanCounterName + "1";
                                break;
                            }
                        case var case7 when case7 == -1 * AttribLookup.GetAttribute(Defaults.MBeanCounterName + "3", ItemAttributes.copySpeedBonus) / 100d:
                            {
                                cmbBeanCounterCopy.Text = Defaults.CBeanCounterName + "3";
                                break;
                            }
                        case var case8 when case8 == -1 * AttribLookup.GetAttribute(Defaults.MBeanCounterName + "5", ItemAttributes.copySpeedBonus) / 100d:
                            {
                                cmbBeanCounterCopy.Text = Defaults.CBeanCounterName + "5";
                                break;
                            }
                    }
                }
                else
                {
                    cmbBeanCounterCopy.Enabled = false;
                }

                // For Build/Buy
                chkBuildBuyDefault.Checked = withBlock.CheckBuildBuy;
                chkSuggestBuildwhenBPnotOwned.Checked = withBlock.SuggestBuildBPNotOwned;
                chkSaveBPRelicsDecryptors.Checked = withBlock.SaveBPRelicsDecryptors;
                chkAlwaysBuyFuelBlocks.Checked = withBlock.AlwaysBuyFuelBlocks;
                chkAlwaysBuyRAMs.Checked = withBlock.AlwaysBuyRAMs;

                chkDisableSVR.Checked = withBlock.DisableSVR;
                chkDisableTracking.Checked = withBlock.DisableGATracking;
                chkShareFacilities.Checked = withBlock.ShareSavedFacilities;

                chkAlphaAccount.Checked = withBlock.AlphaAccount;
                chkUseActiveSkills.Checked = withBlock.UseActiveSkillLevels;
                chkLoadMaxAlphaSkills.Checked = withBlock.LoadMaxAlphaSkills;

                chkLinksInCopyText.Checked = withBlock.IncludeInGameLinksinCopyText;

                // ShoppingList
                chkIncludeShopListInventMats.Checked = withBlock.ShopListIncludeInventMats;
                chkIncludeShopListCopyMats.Checked = withBlock.ShopListIncludeCopyMats;

                if (withBlock.DefaultBPME == 0)
                {
                    txtDefaultME.Text = Defaults.DefaultSettingME.ToString();
                    chkDefaultME.Checked = false;
                    txtDefaultME.Enabled = false;
                }
                else
                {
                    txtDefaultME.Text = withBlock.DefaultBPME.ToString();
                    chkDefaultME.Checked = true;
                    txtDefaultME.Enabled = true;
                }

                if (withBlock.DefaultBPTE == 0)
                {
                    txtDefaultTE.Text = Defaults.DefaultSettingTE.ToString();
                    chkDefaultTE.Checked = false;
                    txtDefaultTE.Enabled = false;
                }
                else
                {
                    txtDefaultTE.Text = withBlock.DefaultBPTE.ToString();
                    chkDefaultTE.Checked = true;
                    txtDefaultTE.Enabled = true;
                }

                if (withBlock.UpdatePricesRefreshInterval != Defaults.DefaultUpdatePricesRefreshInterval)
                {
                    chkFuzzworksMarketInterval.Checked = true;
                    txtFuzzworksMarketInterval.Enabled = true;
                    txtFuzzworksMarketInterval.Text = withBlock.UpdatePricesRefreshInterval.ToString();
                }
                else
                {
                    chkFuzzworksMarketInterval.Checked = false;
                    txtFuzzworksMarketInterval.Enabled = false;
                    txtFuzzworksMarketInterval.Text = Defaults.DefaultUpdatePricesRefreshInterval.ToString();
                }

                cmbSVRRegion.Text = withBlock.SVRAveragePriceRegion;
                cmbSVRAvgPriceDuration.Text = withBlock.SVRAveragePriceDuration;
                txtSVRThreshold.Text = withBlock.IgnoreSVRThresholdValue.ToString();
                chkAutoUpdateSVRBPTab.Checked = withBlock.AutoUpdateSVRonBPTab;

                txtProxyAddress.Text = withBlock.ProxyAddress;
                txtProxyPort.Text = withBlock.ProxyPort.ToString();
            }

            FirstLoad = false;

            btnSave.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ApplicationSettings TempSettings = default;

            // Default values are 0 for implants in settings, since the value stored will get added later. This is the value bonus of the implant
            double RefineImplantValue = 0d;
            double ManufacturingImplantValue = 0d;
            double CopyImplantValue = 0d;

            bool OldMaxAlphaSkillsSetting = SettingsVariables.UserApplicationSettings.LoadMaxAlphaSkills;

            var Settings = new ProgramSettings();
            bool ReloadFacilties = false;
            var AttribLookup = new EVEAttributes();

            if (btnSave.Text == "Save")
            {

                // Make sure accurate data is entered
                if (!CheckEntries())
                {
                    return;
                }

                Cursor = Cursors.WaitCursor;
                Enabled = false;

                // Get the implant values if set
                if (chkBeanCounterManufacturing.Checked)
                {
                    ManufacturingImplantValue = -1 * AttribLookup.GetAttribute(cmbBeanCounterManufacturing.Text, ItemAttributes.manufacturingTimeBonus) / 100d;
                }

                if (chkBeanCounterRefining.Checked)
                {
                    RefineImplantValue = AttribLookup.GetAttribute(cmbBeanCounterRefining.Text, ItemAttributes.refiningYieldMutator) / 100d;
                }

                if (chkBeanCounterCopy.Checked)
                {
                    CopyImplantValue = -1 * AttribLookup.GetAttribute(cmbBeanCounterCopy.Text, ItemAttributes.copySpeedBonus) / 100d;
                }


                TempSettings.CheckforUpdatesonStart = chkCheckUpdatesStartup.Checked;
                if (rbtnExportDefault.Checked)
                {
                    TempSettings.DataExportFormat = rbtnExportDefault.Text;
                }
                else if (rbtnExportCSV.Checked)
                {
                    TempSettings.DataExportFormat = rbtnExportCSV.Text;
                }
                else if (rbtnExportSSV.Checked)
                {
                    TempSettings.DataExportFormat = rbtnExportSSV.Text;
                }
                TempSettings.ShowToolTips = chkShowToolTips.Checked;
                // Disable sound here - only works for update dings, not all sound
                TempSettings.DisableSound = chkDisableSound.Checked;

                TempSettings.RefiningImplantValue = RefineImplantValue;
                TempSettings.ManufacturingImplantValue = ManufacturingImplantValue;
                TempSettings.CopyImplantValue = CopyImplantValue;

                // ESI
                TempSettings.LoadESISystemCostIndiciesDataonStartup = chkRefreshSystemCostIndiciesDataonStartup.Checked;
                TempSettings.LoadESIMarketDataonStartup = chkRefreshMarketDataonStartup.Checked;
                TempSettings.LoadESIPublicStructuresonStartup = chkRefreshPublicStructureDataonStartup.Checked;
                TempSettings.SupressESIStatusMessages = chkSupressESImsgs.Checked;

                // If they didn't have this checked before, refresh assets
                if (Public_Variables.SelectedCharacter.ID != Public_Variables.DummyCharacterID)
                {
                    if (SettingsVariables.UserApplicationSettings.LoadAssetsonStartup == false & chkRefreshAssetsonStartup.Checked)
                    {
                        Public_Variables.SelectedCharacter.GetAssets().LoadAssets(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, true);
                        Public_Variables.SelectedCharacter.CharacterCorporation.GetAssets().LoadAssets(Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID, Public_Variables.SelectedCharacter.CharacterTokenData, true);
                    }

                    // Same with blueprints
                    if (SettingsVariables.UserApplicationSettings.LoadBPsonStartup == false & chkRefreshBPsonStartup.Checked)
                    {
                        Public_Variables.SelectedCharacter.GetBlueprints().LoadBlueprints(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, Public_Variables.ScanType.Personal, true);
                        Public_Variables.SelectedCharacter.CharacterCorporation.GetBlueprints().LoadBlueprints(Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID, Public_Variables.SelectedCharacter.CharacterTokenData, Public_Variables.ScanType.Corporation, true);
                    }
                }

                // Now set these
                TempSettings.LoadAssetsonStartup = chkRefreshAssetsonStartup.Checked;
                TempSettings.LoadBPsonStartup = chkRefreshBPsonStartup.Checked;

                if (SettingsVariables.UserApplicationSettings.SaveFacilitiesbyChar != chkSaveFacilitiesbyChar.Checked)
                {
                    ReloadFacilties = true;
                }
                TempSettings.SaveFacilitiesbyChar = chkSaveFacilitiesbyChar.Checked;

                if (SettingsVariables.UserApplicationSettings.LoadBPsbyChar != chkLoadBPsbyChar.Checked)
                {
                    MsgBoxResult Response;
                    Response = Interaction.MsgBox("This will reset all Blueprint Data for the program." + Environment.NewLine + "Are you sure you want to do this?", Constants.vbYesNo, Application.ProductName);

                    if (Response == Constants.vbYes)
                    {
                        // Delete all bps
                        Public_Variables.EVEDB.ExecuteNonQuerySQL("DELETE FROM OWNED_BLUEPRINTS");
                        // Also reset all BP cache dates incase they just updated the character or loaded it
                        Public_Variables.EVEDB.ExecuteNonQuerySQL("UPDATE ESI_CHARACTER_DATA SET BLUEPRINTS_CACHE_DATE = NULL");

                        // Set the current setting to what they want so the BP's load per the setting
                        SettingsVariables.UserApplicationSettings.LoadBPsbyChar = chkLoadBPsbyChar.Checked;

                        // Need to reload the blueprints for all characters
                        SQLiteDataReader rsChar;
                        Public_Variables.DBCommand = new SQLiteCommand("SELECT CHARACTER_ID, ACCESS_TOKEN, TOKEN_TYPE, ACCESS_TOKEN_EXPIRE_DATE_TIME, REFRESH_TOKEN, SCOPES FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> " + Public_Variables.DummyCharacterID.ToString(), Public_Variables.EVEDB.DBREf());
                        rsChar = Public_Variables.DBCommand.ExecuteReader();
                        while (rsChar.Read())
                        {
                            var TempToken = new SavedTokenData();
                            TempToken.CharacterID = rsChar.GetInt32(0);
                            TempToken.AccessToken = rsChar.GetString(1);
                            TempToken.TokenType = rsChar.GetString(2);
                            TempToken.TokenExpiration = Conversions.ToDate(rsChar.GetString(3));
                            TempToken.RefreshToken = rsChar.GetString(4);
                            TempToken.Scopes = rsChar.GetString(5);
                            Public_Variables.SelectedCharacter.GetBlueprints().LoadBlueprints(TempToken.CharacterID, TempToken, Public_Variables.ScanType.Personal, true);
                        }
                        rsChar.Close();
                    }
                    else
                    {
                        // Switch back
                        chkLoadBPsbyChar.Checked = TempSettings.LoadBPsbyChar;
                    }
                }

                // Save change
                TempSettings.LoadBPsbyChar = chkLoadBPsbyChar.Checked;

                // Standings
                TempSettings.BrokerCorpStanding = Conversions.ToDouble(txtBrokerCorpStanding.Text);
                TempSettings.BrokerFactionStanding = Conversions.ToDouble(txtBrokerFactionStanding.Text);

                // Default build/buy
                TempSettings.CheckBuildBuy = chkBuildBuyDefault.Checked;

                TempSettings.DefaultBPME = Conversions.ToInteger(txtDefaultME.Text);
                TempSettings.DefaultBPTE = Conversions.ToInteger(txtDefaultTE.Text);

                TempSettings.DisableSVR = chkDisableSVR.Checked;
                TempSettings.DisableGATracking = chkDisableTracking.Checked;
                TempSettings.ShareSavedFacilities = chkShareFacilities.Checked;

                TempSettings.SuggestBuildBPNotOwned = chkSuggestBuildwhenBPnotOwned.Checked;
                TempSettings.SaveBPRelicsDecryptors = chkSaveBPRelicsDecryptors.Checked;

                TempSettings.AlwaysBuyFuelBlocks = chkAlwaysBuyFuelBlocks.Checked;
                TempSettings.AlwaysBuyRAMs = chkAlwaysBuyRAMs.Checked;

                TempSettings.AlphaAccount = chkAlphaAccount.Checked;
                TempSettings.UseActiveSkillLevels = chkUseActiveSkills.Checked;
                TempSettings.LoadMaxAlphaSkills = chkLoadMaxAlphaSkills.Checked;

                TempSettings.ShopListIncludeInventMats = chkIncludeShopListInventMats.Checked;
                TempSettings.ShopListIncludeCopyMats = chkIncludeShopListCopyMats.Checked;

                TempSettings.UpdatePricesRefreshInterval = Conversions.ToInteger(txtFuzzworksMarketInterval.Text);

                TempSettings.IncludeInGameLinksinCopyText = chkLinksInCopyText.Checked;

                // SVR
                TempSettings.IgnoreSVRThresholdValue = Conversions.ToDouble(txtSVRThreshold.Text);
                TempSettings.SVRAveragePriceRegion = cmbSVRRegion.Text;
                TempSettings.SVRAveragePriceDuration = cmbSVRAvgPriceDuration.Text;
                TempSettings.AutoUpdateSVRonBPTab = chkAutoUpdateSVRBPTab.Checked;

                // Save the editable rates - these are set on the other screen
                TempSettings.AlphaAccountTaxRate = SettingsVariables.UserApplicationSettings.AlphaAccountTaxRate;
                TempSettings.BaseBrokerFeeRate = SettingsVariables.UserApplicationSettings.BaseBrokerFeeRate;
                TempSettings.BaseSalesTaxRate = SettingsVariables.UserApplicationSettings.BaseSalesTaxRate;
                TempSettings.SCCBrokerFeeSurcharge = SettingsVariables.UserApplicationSettings.SCCBrokerFeeSurcharge;
                TempSettings.SCCIndustryFeeSurcharge = SettingsVariables.UserApplicationSettings.SCCIndustryFeeSurcharge;
                TempSettings.StructureTaxRate = SettingsVariables.UserApplicationSettings.StructureTaxRate;
                TempSettings.StationTaxRate = SettingsVariables.UserApplicationSettings.StationTaxRate;

                if (!string.IsNullOrEmpty(txtProxyAddress.Text))
                {
                    TempSettings.ProxyAddress = txtProxyAddress.Text;
                }
                else
                {
                    TempSettings.ProxyAddress = "";
                }

                if (!string.IsNullOrEmpty(Strings.Trim(txtProxyPort.Text)))
                {
                    TempSettings.ProxyPort = Conversions.ToInteger(txtProxyPort.Text);
                }
                else
                {
                    TempSettings.ProxyPort = 0;

                }

                // Save the data in the XML file
                Settings.SaveApplicationSettings(TempSettings);

                // Save the data to the local variable
                SettingsVariables.UserApplicationSettings = TempSettings;

                // If they selected to load max alpha skills for dummy character or reset it, then reload them if it changed
                if (Public_Variables.SelectedCharacter.ID == Public_Variables.DummyCharacterID)
                {
                    if (OldMaxAlphaSkillsSetting != chkLoadMaxAlphaSkills.Checked)
                    {
                        Public_Variables.SelectedCharacter.LoadDummyCharacter(true, true);
                    }
                }

                // They changed the active skill levels, update skills now with new application settings
                if (ReloadSkills)
                {
                    // Set the flag first
                    Public_Variables.SelectedCharacter.Skills.SetActiveSkillFlagValue(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);
                    Public_Variables.SelectedCharacter.Skills.LoadCharacterSkills(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData);
                }

                // If they changed what the original value was for the shared facilities, reload them
                if (ReloadFacilties)
                {
                    // Load all the forms' facilities 
                    My.MyProject.Forms.frmMain.LoadFacilities();

                    if (Public_Variables.ReprocessingPlantOpen)
                    {
                        ((frmReprocessingPlant)Application.OpenForms["frmReprocessingPlant"]).InitializeReprocessingFacility();
                    }

                    // If IceBeltFlipOpen Then
                    // Call CType(Application.OpenForms.Item("frmIceBeltFlip"), frmIceBeltFlip).InitializeReprocessingFacility()
                    // End If

                    // If OreBeltFlipOpen Then
                    // Call CType(Application.OpenForms.Item("frmIndustryBeltFlip"), frmIndustryBeltFlip).InitializeReprocessingFacility()
                    // End If
                }

                // Re-init any tabs that have settings changes before displaying dialog
                My.MyProject.Forms.frmMain.ResetTabs(false);
                My.MyProject.Forms.frmMain.ResetRefresh();

                Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);

                btnSave.Text = "OK";
                Enabled = true;
                Cursor = Cursors.Default;
            }
            else
            {
                // Just exit
                Hide();
            }

            btnSave.Focus();

        }

        private bool CheckEntries()
        {
            TextBox TempTextBox = null;
            CheckBox TempCheckBox = null;
            ComboBox TempComboBox = null;

            if ((!Information.IsNumeric(txtBrokerCorpStanding.Text) | string.IsNullOrEmpty(Strings.Trim(txtBrokerCorpStanding.Text))) & chkBrokerCorpStanding.Checked)
            {
                TempTextBox = txtBrokerCorpStanding;
                TempCheckBox = chkBrokerCorpStanding;
                goto InvalidData;
            }
            else if (Conversions.ToDouble(txtBrokerCorpStanding.Text) > 10d)
            {
                txtBrokerCorpStanding.Text = "10.0";
            }

            if ((!Information.IsNumeric(txtBrokerFactionStanding.Text) | string.IsNullOrEmpty(Strings.Trim(txtBrokerFactionStanding.Text))) & chkBrokerFactionStanding.Checked)
            {
                TempTextBox = txtBrokerFactionStanding;
                TempCheckBox = chkBrokerFactionStanding;
                goto InvalidData;
            }
            else if (Conversions.ToDouble(txtBrokerFactionStanding.Text) > 10d)
            {
                txtBrokerFactionStanding.Text = "10.0";
            }

            // ME/TE
            if ((!Information.IsNumeric(txtDefaultME.Text) | string.IsNullOrEmpty(Strings.Trim(txtDefaultME.Text))) & chkDefaultME.Checked)
            {
                TempTextBox = txtDefaultME;
                TempCheckBox = chkDefaultME;
                goto InvalidData;
            }

            if ((!Information.IsNumeric(txtDefaultTE.Text) | string.IsNullOrEmpty(Strings.Trim(txtDefaultTE.Text))) & chkDefaultTE.Checked)
            {
                TempTextBox = txtDefaultTE;
                TempCheckBox = chkDefaultTE;
                goto InvalidData;
            }

            if ((!Information.IsNumeric(txtFuzzworksMarketInterval.Text) | string.IsNullOrEmpty(Strings.Trim(txtFuzzworksMarketInterval.Text))) & chkFuzzworksMarketInterval.Checked)
            {
                TempTextBox = txtFuzzworksMarketInterval;
                TempCheckBox = chkFuzzworksMarketInterval;
                goto InvalidData;
            }
            else if (Conversions.ToInteger(txtFuzzworksMarketInterval.Text) <= 0)
            {
                Interaction.MsgBox("Cannot set EVE Central Update Interval less than 1 Hour", Constants.vbExclamation, Application.ProductName);
                txtFuzzworksMarketInterval.Focus();
                txtFuzzworksMarketInterval.SelectAll();
                return false;
            }
            else if (Conversions.ToInteger(txtFuzzworksMarketInterval.Text) > 99)
            {
                Interaction.MsgBox("Cannot set EVE Central Update Interval greater than 99 hours", Constants.vbExclamation, Application.ProductName);
                txtFuzzworksMarketInterval.Focus();
                txtFuzzworksMarketInterval.SelectAll();
                return false;
            }

            return true;

        InvalidData:
            ;


            if (!(TempComboBox == null))
            {
                Interaction.MsgBox("Invalid " + TempComboBox.Name + " Value", Constants.vbExclamation, Application.ProductName);
                TempComboBox.Focus();
                TempComboBox.SelectAll();
            }
            else
            {
                Interaction.MsgBox("Invalid " + TempCheckBox.Name + " Value", Constants.vbExclamation, Application.ProductName);
                TempTextBox.Focus();
                TempTextBox.SelectAll();
            }

            return false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (SelectedReset)
            {
                // If we hit reset, then we need to get the current list of settings, not just what is loaded (might be defaults)
                // So just reload the settings
                SettingsVariables.UserApplicationSettings = SettingsVariables.AllSettings.LoadApplicationSettings();
            }
            Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SelectedReset = true;
            // Load default settings
            SettingsVariables.UserApplicationSettings = SettingsVariables.AllSettings.SetDefaultApplicationSettings();
            // Reload the form
            LoadFormSettings();

        }

        private void chkAlphaAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlphaAccount.Checked)
            {
                // Force them to use active skills in this case
                chkUseActiveSkills.Checked = true;
                chkUseActiveSkills.Enabled = false;
            }
            else
            {
                chkUseActiveSkills.Enabled = true;
            }
        }

        private void chkUseActiveSkills_CheckedChanged(object sender, EventArgs e)
        {
            // They changed active skills, so reload character skills on exit
            ReloadSkills = true;
        }

        private void btnOpenRates_Click(object sender, EventArgs e)
        {
            var f1 = new frmEditDefaultRates();
            f1.ShowDialog();
        }

    }
}