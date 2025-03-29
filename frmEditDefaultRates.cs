using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{
    public partial class frmEditDefaultRates
    {
        public frmEditDefaultRates()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
        }

        private void frmEditDefaultRates_Load(object sender, EventArgs e)
        {
            // Load the current rates saved
            {
                ref var withBlock = ref SettingsVariables.UserApplicationSettings;
                txtBaseBrokerFee.Text = Strings.FormatPercent(withBlock.BaseBrokerFeeRate / 100d, 2);
                txtBaseSalesTax.Text = Strings.FormatPercent(withBlock.BaseSalesTaxRate / 100d, 2);

                txtAlphaAccountTaxRate.Text = Strings.FormatPercent(withBlock.AlphaAccountTaxRate, 2);
                txtDefaultStationTaxRate.Text = Strings.FormatPercent(withBlock.StationTaxRate, 2);
                txtDefaultStructureTaxRate.Text = Strings.FormatPercent(withBlock.StructureTaxRate, 2);
                txtSCCBrokerFeeSurcharge.Text = Strings.FormatPercent(withBlock.SCCBrokerFeeSurcharge, 2);
                txtSCCIndustryFeeSurcharge.Text = Strings.FormatPercent(withBlock.SCCIndustryFeeSurcharge, 2);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool DataCheckGood = true;
            var TextBoxRef = new TextBox();

            // Data check
            if (!Information.IsNumeric(txtBaseBrokerFee.Text.Replace("%", "")))
            {
                DataCheckGood = false;
                TextBoxRef = txtBaseBrokerFee;
            }
            if (!Information.IsNumeric(txtBaseSalesTax.Text.Replace("%", "")))
            {
                DataCheckGood = false;
                TextBoxRef = txtBaseSalesTax;
            }
            if (!Information.IsNumeric(txtSCCBrokerFeeSurcharge.Text.Replace("%", "")))
            {
                DataCheckGood = false;
                TextBoxRef = txtSCCBrokerFeeSurcharge;
            }
            if (!Information.IsNumeric(txtSCCIndustryFeeSurcharge.Text.Replace("%", "")))
            {
                DataCheckGood = false;
                TextBoxRef = txtSCCIndustryFeeSurcharge;
            }
            if (!Information.IsNumeric(txtAlphaAccountTaxRate.Text.Replace("%", "")))
            {
                DataCheckGood = false;
                TextBoxRef = txtAlphaAccountTaxRate;
            }
            if (!Information.IsNumeric(txtDefaultStationTaxRate.Text.Replace("%", "")))
            {
                DataCheckGood = false;
                TextBoxRef = txtDefaultStationTaxRate;
            }
            if (!Information.IsNumeric(txtDefaultStructureTaxRate.Text.Replace("%", "")))
            {
                DataCheckGood = false;
                TextBoxRef = txtDefaultStructureTaxRate;
            }

            if (!DataCheckGood)
            {
                Interaction.MsgBox("Invalid Entry Data", Constants.vbExclamation, TextBoxRef.Name);
                TextBoxRef.SelectAll();
                return;
            }

            // Save just these to the userapp settings
            {
                ref var withBlock = ref SettingsVariables.UserApplicationSettings;
                // Need digits for these
                withBlock.BaseBrokerFeeRate = Conversions.ToDouble(txtBaseBrokerFee.Text.Replace("%", ""));
                withBlock.BaseSalesTaxRate = Conversions.ToDouble(txtBaseSalesTax.Text.Replace("%", ""));
                // Just save these normally
                withBlock.SCCBrokerFeeSurcharge = Conversions.ToDouble(txtSCCBrokerFeeSurcharge.Text.Replace("%", "")) / 100d;
                withBlock.SCCIndustryFeeSurcharge = Conversions.ToDouble(txtSCCIndustryFeeSurcharge.Text.Replace("%", "")) / 100d;
                withBlock.StructureTaxRate = Conversions.ToDouble(txtDefaultStructureTaxRate.Text.Replace("%", "")) / 100d;
                withBlock.StationTaxRate = Conversions.ToDouble(txtDefaultStationTaxRate.Text.Replace("%", "")) / 100d;
                withBlock.AlphaAccountTaxRate = Conversions.ToDouble(txtAlphaAccountTaxRate.Text.Replace("%", "")) / 100d;
            }

            // Just Grab whatever is set already and update with the above
            var Tempsettings = SettingsVariables.UserApplicationSettings;
            var Settings = new ProgramSettings();

            // Save the data in the XML file
            Settings.SaveApplicationSettings(Tempsettings);

            // Load all the forms' facilities 
            My.MyProject.Forms.frmMain.LoadFacilities();
            // Re-init any tabs that have settings changes before displaying dialog
            My.MyProject.Forms.frmMain.ResetTabs(false);
            My.MyProject.Forms.frmMain.ResetRefresh();

            Interaction.MsgBox("Defaults Saved", Constants.vbInformation, Application.ProductName);

        }

        private void txtEntries_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedPercentChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }
        private void txtEntries_LostFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = FormatRate((TextBox)sender);
        }

        private string FormatRate(TextBox PricetxtBox)
        {
            if (string.IsNullOrEmpty(Strings.Trim(PricetxtBox.Text)))
            {
                return "0.0%";
            }
            else
            {
                return Strings.FormatPercent(Conversions.ToDouble(PricetxtBox.Text.Replace("%", "")) / 100d, 2);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var S = new ProgramSettings();

            {
                ref var withBlock = ref SettingsVariables.UserApplicationSettings;
                txtBaseBrokerFee.Text = Strings.FormatPercent(S.DefaultBaseBrokerFeeRate / 100d, 2);
                txtBaseSalesTax.Text = Strings.FormatPercent(S.DefaultBaseSalesTaxRate / 100d, 2);

                txtAlphaAccountTaxRate.Text = Strings.FormatPercent(S.DefaultAlphaAccountTaxRate, 2);
                txtDefaultStationTaxRate.Text = Strings.FormatPercent(S.DefaultStationTaxRate, 2);
                txtDefaultStructureTaxRate.Text = Strings.FormatPercent(S.DefaultStructureTaxRate, 2);
                txtSCCBrokerFeeSurcharge.Text = Strings.FormatPercent(S.DefaultSCCBrokerFeeSurcharge, 2);
                txtSCCIndustryFeeSurcharge.Text = Strings.FormatPercent(S.DefaultSCCIndustryFeeSurcharge, 2);
            }

            Interaction.MsgBox("Defaults Loaded", Constants.vbInformation, Application.ProductName);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

    }
}