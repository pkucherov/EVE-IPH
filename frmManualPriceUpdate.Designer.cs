using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmManualPriceUpdate : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManualPriceUpdate));
            tabpItemSearch = new TabPage();
            lblSelectedItem = new Label();
            lblLSelectedItem = new Label();
            btnItemSearch = new Button();
            btnItemSearch.Click += new EventHandler(btnItemSearch_Click);
            btnSearchClose = new Button();
            btnSearchClose.Click += new EventHandler(btnSearchClose_Click);
            btnSearchUpdate = new Button();
            btnSearchUpdate.Click += new EventHandler(btnSearchUpdate_Click);
            lblPriceUpdate = new Label();
            lblItemName = new Label();
            txtItemPriceUpdate = new TextBox();
            txtItemPriceUpdate.KeyDown += new KeyEventHandler(txtItemPriceUpdate_KeyDown);
            txtItemPriceUpdate.KeyPress += new KeyPressEventHandler(txtItemPriceUpdate_KeyPress);
            txtItemSearch = new TextBox();
            txtItemSearch.KeyDown += new KeyEventHandler(txtItemSearch_KeyDown);
            lstPriceLookup = new ListView();
            lstPriceLookup.SelectedIndexChanged += new EventHandler(lstPriceLookup_SelectedIndexChanged);
            lstPriceLookup.Click += new EventHandler(lstPriceLookup_Click);
            tabpMoonMats = new TabPage();
            txtMoon11 = new TextBox();
            txtMoon11.GotFocus += new EventHandler(txtMoon11_GotFocus);
            txtMoon11.KeyDown += new KeyEventHandler(txtMoon11_KeyDown);
            txtMoon11.KeyPress += new KeyPressEventHandler(txtMoon11_KeyPress);
            txtMoon11.TextChanged += new EventHandler(txtMoon11_TextChanged);
            txtMoon10 = new TextBox();
            txtMoon10.GotFocus += new EventHandler(txtMoon10_GotFocus);
            txtMoon10.KeyDown += new KeyEventHandler(txtMoon10_KeyDown);
            txtMoon10.KeyPress += new KeyPressEventHandler(txtMoon10_KeyPress);
            txtMoon10.TextChanged += new EventHandler(txtMoon10_TextChanged);
            txtMoon9 = new TextBox();
            txtMoon9.GotFocus += new EventHandler(txtMoon9_GotFocus);
            txtMoon9.KeyDown += new KeyEventHandler(txtMoon9_KeyDown);
            txtMoon9.KeyPress += new KeyPressEventHandler(txtMoon9_KeyPress);
            txtMoon9.TextChanged += new EventHandler(txtMoon9_TextChanged);
            txtMoon8 = new TextBox();
            txtMoon8.GotFocus += new EventHandler(txtMoon8_GotFocus);
            txtMoon8.KeyDown += new KeyEventHandler(txtMoon8_KeyDown);
            txtMoon8.KeyPress += new KeyPressEventHandler(txtMoon8_KeyPress);
            txtMoon8.TextChanged += new EventHandler(txtMoon8_TextChanged);
            txtMoon6 = new TextBox();
            txtMoon6.GotFocus += new EventHandler(txtMoon6_GotFocus);
            txtMoon6.KeyDown += new KeyEventHandler(txtMoon6_KeyDown);
            txtMoon6.KeyPress += new KeyPressEventHandler(txtMoon6_KeyPress);
            txtMoon6.TextChanged += new EventHandler(txtMoon6_TextChanged);
            txtMoon4 = new TextBox();
            txtMoon4.GotFocus += new EventHandler(txtMoon4_GotFocus);
            txtMoon4.KeyDown += new KeyEventHandler(txtMoon4_KeyDown);
            txtMoon4.KeyPress += new KeyPressEventHandler(txtMoon4_KeyPress);
            txtMoon4.TextChanged += new EventHandler(txtMoon4_TextChanged);
            txtMoon2 = new TextBox();
            txtMoon2.GotFocus += new EventHandler(txtMoon2_GotFocus);
            txtMoon2.KeyDown += new KeyEventHandler(txtMoon2_KeyDown);
            txtMoon2.KeyPress += new KeyPressEventHandler(txtMoon2_KeyPress);
            txtMoon2.TextChanged += new EventHandler(txtMoon2_TextChanged);
            txtMoon7 = new TextBox();
            txtMoon7.GotFocus += new EventHandler(txtMoon7_GotFocus);
            txtMoon7.KeyDown += new KeyEventHandler(txtMoon7_KeyDown);
            txtMoon7.KeyPress += new KeyPressEventHandler(txtMoon7_KeyPress);
            txtMoon7.TextChanged += new EventHandler(txtMoon7_TextChanged);
            txtMoon5 = new TextBox();
            txtMoon5.GotFocus += new EventHandler(txtMoon5_GotFocus);
            txtMoon5.KeyDown += new KeyEventHandler(txtMoon5_KeyDown);
            txtMoon5.KeyPress += new KeyPressEventHandler(txtMoon5_KeyPress);
            txtMoon5.TextChanged += new EventHandler(txtMoon5_TextChanged);
            txtMoon3 = new TextBox();
            txtMoon3.GotFocus += new EventHandler(txtMoon3_GotFocus);
            txtMoon3.KeyDown += new KeyEventHandler(txtMoon3_KeyDown);
            txtMoon3.KeyPress += new KeyPressEventHandler(txtMoon3_KeyPress);
            txtMoon3.TextChanged += new EventHandler(txtMoon3_TextChanged);
            txtMoon1 = new TextBox();
            txtMoon1.GotFocus += new EventHandler(txtMoon1_GotFocus);
            txtMoon1.KeyDown += new KeyEventHandler(txtMoon1_KeyDown);
            txtMoon1.KeyPress += new KeyPressEventHandler(txtMoon1_KeyPress);
            txtMoon1.TextChanged += new EventHandler(txtMoon1_TextChanged);
            lblMoon11 = new Label();
            pictMoon11 = new PictureBox();
            lblMoon10 = new Label();
            lblMoon9 = new Label();
            pictMoon10 = new PictureBox();
            pictMoon9 = new PictureBox();
            lblMoon8 = new Label();
            lblMoon6 = new Label();
            lblMoon4 = new Label();
            lblMoon2 = new Label();
            lblMoon7 = new Label();
            lblMoon5 = new Label();
            lblMoon3 = new Label();
            lblMoon1 = new Label();
            pictMoon8 = new PictureBox();
            pictMoon7 = new PictureBox();
            pictMoon6 = new PictureBox();
            pictMoon5 = new PictureBox();
            pictMoon4 = new PictureBox();
            pictMoon3 = new PictureBox();
            pictMoon2 = new PictureBox();
            pictMoon1 = new PictureBox();
            btnCloseMoonMats = new Button();
            btnCloseMoonMats.Click += new EventHandler(btnCloseMoonMats_Click);
            btnUpdateMoonMatPrices = new Button();
            btnUpdateMoonMatPrices.Click += new EventHandler(btnUpdateMoonMatPrices_Click);
            tabpMinerals = new TabPage();
            txtMineral8 = new TextBox();
            txtMineral8.GotFocus += new EventHandler(txtMineral8_GotFocus);
            txtMineral8.KeyDown += new KeyEventHandler(txtMineral8_KeyDown);
            txtMineral8.KeyPress += new KeyPressEventHandler(txtMineral8_KeyPress);
            txtMineral8.TextChanged += new EventHandler(txtMineral8_TextChanged);
            txtMineral7 = new TextBox();
            txtMineral7.GotFocus += new EventHandler(txtMineral7_GotFocus);
            txtMineral7.KeyDown += new KeyEventHandler(txtMineral7_KeyDown);
            txtMineral7.KeyPress += new KeyPressEventHandler(txtMineral7_KeyPress);
            txtMineral7.TextChanged += new EventHandler(txtMineral7_TextChanged);
            txtMineral6 = new TextBox();
            txtMineral6.GotFocus += new EventHandler(txtMineral6_GotFocus);
            txtMineral6.KeyDown += new KeyEventHandler(txtMineral6_KeyDown);
            txtMineral6.KeyPress += new KeyPressEventHandler(txtMineral6_KeyPress);
            txtMineral6.TextChanged += new EventHandler(txtMineral6_TextChanged);
            txtMineral5 = new TextBox();
            txtMineral5.GotFocus += new EventHandler(txtMineral5_GotFocus);
            txtMineral5.KeyDown += new KeyEventHandler(txtMineral5_KeyDown);
            txtMineral5.KeyPress += new KeyPressEventHandler(txtMineral5_KeyPress);
            txtMineral5.TextChanged += new EventHandler(txtMineral5_TextChanged);
            txtMineral4 = new TextBox();
            txtMineral4.GotFocus += new EventHandler(txtMineral4_GotFocus);
            txtMineral4.KeyDown += new KeyEventHandler(txtMineral4_KeyDown);
            txtMineral4.KeyPress += new KeyPressEventHandler(txtMineral4_KeyPress);
            txtMineral4.TextChanged += new EventHandler(txtMineral4_TextChanged);
            txtMineral3 = new TextBox();
            txtMineral3.GotFocus += new EventHandler(txtMineral3_GotFocus);
            txtMineral3.KeyDown += new KeyEventHandler(txtMineral3_KeyDown);
            txtMineral3.KeyPress += new KeyPressEventHandler(txtMineral3_KeyPress);
            txtMineral3.TextChanged += new EventHandler(txtMineral3_TextChanged);
            txtMineral2 = new TextBox();
            txtMineral2.GotFocus += new EventHandler(txtMineral2_GotFocus);
            txtMineral2.KeyDown += new KeyEventHandler(txtMineral2_KeyDown);
            txtMineral2.KeyPress += new KeyPressEventHandler(txtMineral2_KeyPress);
            txtMineral2.TextChanged += new EventHandler(txtMineral2_TextChanged);
            txtMineral1 = new TextBox();
            txtMineral1.GotFocus += new EventHandler(txtMineral1_GotFocus);
            txtMineral1.KeyDown += new KeyEventHandler(txtMineral1_KeyDown);
            txtMineral1.KeyPress += new KeyPressEventHandler(txtMineral1_KeyPress);
            txtMineral1.TextChanged += new EventHandler(txtMineral1_TextChanged);
            lblMineral8 = new Label();
            lblMineral7 = new Label();
            lblMineral6 = new Label();
            lblMineral5 = new Label();
            lblMineral4 = new Label();
            lblMineral3 = new Label();
            lblMineral2 = new Label();
            lblMineral1 = new Label();
            pictMineral8 = new PictureBox();
            pictMineral4 = new PictureBox();
            pictMineral7 = new PictureBox();
            pictMineral3 = new PictureBox();
            pictMineral6 = new PictureBox();
            pictMineral2 = new PictureBox();
            pictMineral5 = new PictureBox();
            pictMineral1 = new PictureBox();
            btnCloseMinerals = new Button();
            btnCloseMinerals.Click += new EventHandler(btnCloseMinerals_Click);
            btnUpdateMineralPrices = new Button();
            btnUpdateMineralPrices.Click += new EventHandler(btnUpdateMineralPrices_Click);
            tabPrices = new TabControl();
            tabPrices.Click += new EventHandler(tabPrices_Click);
            tabpItemSearch.SuspendLayout();
            tabpMoonMats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictMoon11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon1).BeginInit();
            tabpMinerals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictMineral8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral1).BeginInit();
            tabPrices.SuspendLayout();
            SuspendLayout();
            // 
            // tabpItemSearch
            // 
            tabpItemSearch.Controls.Add(lblSelectedItem);
            tabpItemSearch.Controls.Add(lblLSelectedItem);
            tabpItemSearch.Controls.Add(btnItemSearch);
            tabpItemSearch.Controls.Add(btnSearchClose);
            tabpItemSearch.Controls.Add(btnSearchUpdate);
            tabpItemSearch.Controls.Add(lblPriceUpdate);
            tabpItemSearch.Controls.Add(lblItemName);
            tabpItemSearch.Controls.Add(txtItemPriceUpdate);
            tabpItemSearch.Controls.Add(txtItemSearch);
            tabpItemSearch.Controls.Add(lstPriceLookup);
            tabpItemSearch.Location = new Point(4, 24);
            tabpItemSearch.Name = "tabpItemSearch";
            tabpItemSearch.Size = new Size(385, 350);
            tabpItemSearch.TabIndex = 2;
            tabpItemSearch.Text = "Item Search";
            tabpItemSearch.UseVisualStyleBackColor = true;
            // 
            // lblSelectedItem
            // 
            lblSelectedItem.BorderStyle = BorderStyle.FixedSingle;
            lblSelectedItem.Location = new Point(111, 247);
            lblSelectedItem.Name = "lblSelectedItem";
            lblSelectedItem.Size = new Size(266, 20);
            lblSelectedItem.TabIndex = 23;
            lblSelectedItem.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLSelectedItem
            // 
            lblLSelectedItem.AutoSize = true;
            lblLSelectedItem.Location = new Point(30, 248);
            lblLSelectedItem.Name = "lblLSelectedItem";
            lblLSelectedItem.Size = new Size(75, 13);
            lblLSelectedItem.TabIndex = 22;
            lblLSelectedItem.Text = "Selected Item:";
            // 
            // btnItemSearch
            // 
            btnItemSearch.Location = new Point(286, 220);
            btnItemSearch.Name = "btnItemSearch";
            btnItemSearch.Size = new Size(91, 24);
            btnItemSearch.TabIndex = 16;
            btnItemSearch.Text = "Search";
            btnItemSearch.UseVisualStyleBackColor = true;
            // 
            // btnSearchClose
            // 
            btnSearchClose.Location = new Point(206, 310);
            btnSearchClose.Name = "btnSearchClose";
            btnSearchClose.Size = new Size(91, 24);
            btnSearchClose.TabIndex = 19;
            btnSearchClose.Text = "Close";
            btnSearchClose.UseVisualStyleBackColor = true;
            // 
            // btnSearchUpdate
            // 
            btnSearchUpdate.Location = new Point(88, 310);
            btnSearchUpdate.Name = "btnSearchUpdate";
            btnSearchUpdate.Size = new Size(91, 24);
            btnSearchUpdate.TabIndex = 18;
            btnSearchUpdate.Text = "Update Price";
            btnSearchUpdate.UseVisualStyleBackColor = true;
            // 
            // lblPriceUpdate
            // 
            lblPriceUpdate.AutoSize = true;
            lblPriceUpdate.Location = new Point(92, 282);
            lblPriceUpdate.Name = "lblPriceUpdate";
            lblPriceUpdate.Size = new Size(72, 13);
            lblPriceUpdate.TabIndex = 18;
            lblPriceUpdate.Text = "Update Price:";
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Location = new Point(14, 226);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(91, 13);
            lblItemName.TabIndex = 17;
            lblItemName.Text = "Item Search Text:";
            // 
            // txtItemPriceUpdate
            // 
            txtItemPriceUpdate.Location = new Point(170, 279);
            txtItemPriceUpdate.Name = "txtItemPriceUpdate";
            txtItemPriceUpdate.Size = new Size(146, 20);
            txtItemPriceUpdate.TabIndex = 17;
            // 
            // txtItemSearch
            // 
            txtItemSearch.Location = new Point(111, 222);
            txtItemSearch.Name = "txtItemSearch";
            txtItemSearch.Size = new Size(169, 20);
            txtItemSearch.TabIndex = 15;
            // 
            // lstPriceLookup
            // 
            lstPriceLookup.FullRowSelect = true;
            lstPriceLookup.GridLines = true;
            lstPriceLookup.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstPriceLookup.HideSelection = false;
            lstPriceLookup.Location = new Point(0, 14);
            lstPriceLookup.MultiSelect = false;
            lstPriceLookup.Name = "lstPriceLookup";
            lstPriceLookup.Size = new Size(382, 200);
            lstPriceLookup.TabIndex = 14;
            lstPriceLookup.UseCompatibleStateImageBehavior = false;
            lstPriceLookup.View = View.Details;
            // 
            // tabpMoonMats
            // 
            tabpMoonMats.Controls.Add(txtMoon11);
            tabpMoonMats.Controls.Add(txtMoon10);
            tabpMoonMats.Controls.Add(txtMoon9);
            tabpMoonMats.Controls.Add(txtMoon8);
            tabpMoonMats.Controls.Add(txtMoon6);
            tabpMoonMats.Controls.Add(txtMoon4);
            tabpMoonMats.Controls.Add(txtMoon2);
            tabpMoonMats.Controls.Add(txtMoon7);
            tabpMoonMats.Controls.Add(txtMoon5);
            tabpMoonMats.Controls.Add(txtMoon3);
            tabpMoonMats.Controls.Add(txtMoon1);
            tabpMoonMats.Controls.Add(lblMoon11);
            tabpMoonMats.Controls.Add(pictMoon11);
            tabpMoonMats.Controls.Add(lblMoon10);
            tabpMoonMats.Controls.Add(lblMoon9);
            tabpMoonMats.Controls.Add(pictMoon10);
            tabpMoonMats.Controls.Add(pictMoon9);
            tabpMoonMats.Controls.Add(lblMoon8);
            tabpMoonMats.Controls.Add(lblMoon6);
            tabpMoonMats.Controls.Add(lblMoon4);
            tabpMoonMats.Controls.Add(lblMoon2);
            tabpMoonMats.Controls.Add(lblMoon7);
            tabpMoonMats.Controls.Add(lblMoon5);
            tabpMoonMats.Controls.Add(lblMoon3);
            tabpMoonMats.Controls.Add(lblMoon1);
            tabpMoonMats.Controls.Add(pictMoon8);
            tabpMoonMats.Controls.Add(pictMoon7);
            tabpMoonMats.Controls.Add(pictMoon6);
            tabpMoonMats.Controls.Add(pictMoon5);
            tabpMoonMats.Controls.Add(pictMoon4);
            tabpMoonMats.Controls.Add(pictMoon3);
            tabpMoonMats.Controls.Add(pictMoon2);
            tabpMoonMats.Controls.Add(pictMoon1);
            tabpMoonMats.Controls.Add(btnCloseMoonMats);
            tabpMoonMats.Controls.Add(btnUpdateMoonMatPrices);
            tabpMoonMats.Location = new Point(4, 24);
            tabpMoonMats.Name = "tabpMoonMats";
            tabpMoonMats.Padding = new Padding(3);
            tabpMoonMats.Size = new Size(385, 350);
            tabpMoonMats.TabIndex = 1;
            tabpMoonMats.Text = "Advanced Composites";
            tabpMoonMats.UseVisualStyleBackColor = true;
            // 
            // txtMoon11
            // 
            txtMoon11.Location = new Point(238, 177);
            txtMoon11.Name = "txtMoon11";
            txtMoon11.Size = new Size(123, 20);
            txtMoon11.TabIndex = 16;
            txtMoon11.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon10
            // 
            txtMoon10.Location = new Point(238, 79);
            txtMoon10.Name = "txtMoon10";
            txtMoon10.Size = new Size(123, 20);
            txtMoon10.TabIndex = 12;
            txtMoon10.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon9
            // 
            txtMoon9.Location = new Point(238, 29);
            txtMoon9.Name = "txtMoon9";
            txtMoon9.Size = new Size(123, 20);
            txtMoon9.TabIndex = 10;
            txtMoon9.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon8
            // 
            txtMoon8.Location = new Point(62, 130);
            txtMoon8.Name = "txtMoon8";
            txtMoon8.Size = new Size(123, 20);
            txtMoon8.TabIndex = 13;
            txtMoon8.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon6
            // 
            txtMoon6.Location = new Point(62, 177);
            txtMoon6.Name = "txtMoon6";
            txtMoon6.Size = new Size(123, 20);
            txtMoon6.TabIndex = 15;
            txtMoon6.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon4
            // 
            txtMoon4.Location = new Point(62, 272);
            txtMoon4.Name = "txtMoon4";
            txtMoon4.Size = new Size(123, 20);
            txtMoon4.TabIndex = 19;
            txtMoon4.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon2
            // 
            txtMoon2.Location = new Point(238, 227);
            txtMoon2.Name = "txtMoon2";
            txtMoon2.Size = new Size(123, 20);
            txtMoon2.TabIndex = 18;
            txtMoon2.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon7
            // 
            txtMoon7.Location = new Point(238, 130);
            txtMoon7.Name = "txtMoon7";
            txtMoon7.Size = new Size(123, 20);
            txtMoon7.TabIndex = 14;
            txtMoon7.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon5
            // 
            txtMoon5.Location = new Point(62, 227);
            txtMoon5.Name = "txtMoon5";
            txtMoon5.Size = new Size(123, 20);
            txtMoon5.TabIndex = 17;
            txtMoon5.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon3
            // 
            txtMoon3.Location = new Point(62, 79);
            txtMoon3.Name = "txtMoon3";
            txtMoon3.Size = new Size(123, 20);
            txtMoon3.TabIndex = 11;
            txtMoon3.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMoon1
            // 
            txtMoon1.Location = new Point(62, 29);
            txtMoon1.Name = "txtMoon1";
            txtMoon1.Size = new Size(123, 20);
            txtMoon1.TabIndex = 9;
            txtMoon1.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMoon11
            // 
            lblMoon11.Location = new Point(238, 161);
            lblMoon11.Name = "lblMoon11";
            lblMoon11.Size = new Size(123, 13);
            lblMoon11.TabIndex = 78;
            lblMoon11.Text = "Phenolic Composites";
            lblMoon11.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictMoon11
            // 
            pictMoon11.Image = (Image)resources.GetObject("pictMoon11.Image");
            pictMoon11.Location = new Point(200, 168);
            pictMoon11.Name = "pictMoon11";
            pictMoon11.Size = new Size(32, 32);
            pictMoon11.TabIndex = 77;
            pictMoon11.TabStop = false;
            // 
            // lblMoon10
            // 
            lblMoon10.Location = new Point(238, 63);
            lblMoon10.Name = "lblMoon10";
            lblMoon10.Size = new Size(123, 13);
            lblMoon10.TabIndex = 75;
            lblMoon10.Text = "Ferrogel";
            lblMoon10.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMoon9
            // 
            lblMoon9.Location = new Point(238, 13);
            lblMoon9.Name = "lblMoon9";
            lblMoon9.Size = new Size(123, 13);
            lblMoon9.TabIndex = 74;
            lblMoon9.Text = "Fermionic Condensates";
            lblMoon9.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictMoon10
            // 
            pictMoon10.Image = (Image)resources.GetObject("pictMoon10.Image");
            pictMoon10.Location = new Point(200, 71);
            pictMoon10.Name = "pictMoon10";
            pictMoon10.Size = new Size(32, 32);
            pictMoon10.TabIndex = 73;
            pictMoon10.TabStop = false;
            // 
            // pictMoon9
            // 
            pictMoon9.Image = (Image)resources.GetObject("pictMoon9.Image");
            pictMoon9.Location = new Point(200, 22);
            pictMoon9.Name = "pictMoon9";
            pictMoon9.Size = new Size(32, 32);
            pictMoon9.TabIndex = 72;
            pictMoon9.TabStop = false;
            // 
            // lblMoon8
            // 
            lblMoon8.Location = new Point(62, 114);
            lblMoon8.Name = "lblMoon8";
            lblMoon8.Size = new Size(123, 13);
            lblMoon8.TabIndex = 69;
            lblMoon8.Text = "Fullerides";
            lblMoon8.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMoon6
            // 
            lblMoon6.Location = new Point(62, 161);
            lblMoon6.Name = "lblMoon6";
            lblMoon6.Size = new Size(123, 13);
            lblMoon6.TabIndex = 68;
            lblMoon6.Text = "Nanotransistors";
            lblMoon6.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMoon4
            // 
            lblMoon4.Location = new Point(62, 256);
            lblMoon4.Name = "lblMoon4";
            lblMoon4.Size = new Size(123, 13);
            lblMoon4.TabIndex = 67;
            lblMoon4.Text = "Tungsten Carbide";
            lblMoon4.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMoon2
            // 
            lblMoon2.Location = new Point(238, 211);
            lblMoon2.Name = "lblMoon2";
            lblMoon2.Size = new Size(123, 13);
            lblMoon2.TabIndex = 66;
            lblMoon2.Text = "Titanium Carbide";
            lblMoon2.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMoon7
            // 
            lblMoon7.Location = new Point(238, 114);
            lblMoon7.Name = "lblMoon7";
            lblMoon7.Size = new Size(123, 13);
            lblMoon7.TabIndex = 65;
            lblMoon7.Text = "Hypersynaptic Fibers";
            lblMoon7.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMoon5
            // 
            lblMoon5.Location = new Point(62, 211);
            lblMoon5.Name = "lblMoon5";
            lblMoon5.Size = new Size(123, 13);
            lblMoon5.TabIndex = 64;
            lblMoon5.Text = "Sylramic Fibers";
            lblMoon5.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMoon3
            // 
            lblMoon3.Location = new Point(62, 63);
            lblMoon3.Name = "lblMoon3";
            lblMoon3.Size = new Size(123, 13);
            lblMoon3.TabIndex = 63;
            lblMoon3.Text = "Fernite Carbide";
            lblMoon3.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMoon1
            // 
            lblMoon1.Location = new Point(62, 13);
            lblMoon1.Name = "lblMoon1";
            lblMoon1.Size = new Size(123, 13);
            lblMoon1.TabIndex = 62;
            lblMoon1.Text = "Crystalline Carbonide";
            lblMoon1.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictMoon8
            // 
            pictMoon8.Image = (Image)resources.GetObject("pictMoon8.Image");
            pictMoon8.Location = new Point(24, 120);
            pictMoon8.Name = "pictMoon8";
            pictMoon8.Size = new Size(32, 32);
            pictMoon8.TabIndex = 61;
            pictMoon8.TabStop = false;
            // 
            // pictMoon7
            // 
            pictMoon7.Image = (Image)resources.GetObject("pictMoon7.Image");
            pictMoon7.Location = new Point(200, 120);
            pictMoon7.Name = "pictMoon7";
            pictMoon7.Size = new Size(32, 32);
            pictMoon7.TabIndex = 60;
            pictMoon7.TabStop = false;
            // 
            // pictMoon6
            // 
            pictMoon6.Image = (Image)resources.GetObject("pictMoon6.Image");
            pictMoon6.Location = new Point(24, 168);
            pictMoon6.Name = "pictMoon6";
            pictMoon6.Size = new Size(32, 32);
            pictMoon6.TabIndex = 59;
            pictMoon6.TabStop = false;
            // 
            // pictMoon5
            // 
            pictMoon5.Image = (Image)resources.GetObject("pictMoon5.Image");
            pictMoon5.Location = new Point(24, 218);
            pictMoon5.Name = "pictMoon5";
            pictMoon5.Size = new Size(32, 32);
            pictMoon5.TabIndex = 58;
            pictMoon5.TabStop = false;
            // 
            // pictMoon4
            // 
            pictMoon4.Image = (Image)resources.GetObject("pictMoon4.Image");
            pictMoon4.Location = new Point(24, 264);
            pictMoon4.Name = "pictMoon4";
            pictMoon4.Size = new Size(32, 32);
            pictMoon4.TabIndex = 57;
            pictMoon4.TabStop = false;
            // 
            // pictMoon3
            // 
            pictMoon3.Image = (Image)resources.GetObject("pictMoon3.Image");
            pictMoon3.Location = new Point(24, 71);
            pictMoon3.Name = "pictMoon3";
            pictMoon3.Size = new Size(32, 32);
            pictMoon3.TabIndex = 56;
            pictMoon3.TabStop = false;
            // 
            // pictMoon2
            // 
            pictMoon2.Image = (Image)resources.GetObject("pictMoon2.Image");
            pictMoon2.Location = new Point(200, 218);
            pictMoon2.Name = "pictMoon2";
            pictMoon2.Size = new Size(32, 32);
            pictMoon2.TabIndex = 55;
            pictMoon2.TabStop = false;
            // 
            // pictMoon1
            // 
            pictMoon1.Image = (Image)resources.GetObject("pictMoon1.Image");
            pictMoon1.Location = new Point(24, 22);
            pictMoon1.Name = "pictMoon1";
            pictMoon1.Size = new Size(32, 32);
            pictMoon1.TabIndex = 54;
            pictMoon1.TabStop = false;
            // 
            // btnCloseMoonMats
            // 
            btnCloseMoonMats.Location = new Point(206, 310);
            btnCloseMoonMats.Name = "btnCloseMoonMats";
            btnCloseMoonMats.Size = new Size(91, 24);
            btnCloseMoonMats.TabIndex = 22;
            btnCloseMoonMats.Text = "Close";
            btnCloseMoonMats.UseVisualStyleBackColor = true;
            // 
            // btnUpdateMoonMatPrices
            // 
            btnUpdateMoonMatPrices.Location = new Point(88, 310);
            btnUpdateMoonMatPrices.Name = "btnUpdateMoonMatPrices";
            btnUpdateMoonMatPrices.Size = new Size(91, 24);
            btnUpdateMoonMatPrices.TabIndex = 21;
            btnUpdateMoonMatPrices.Text = "Update Prices";
            btnUpdateMoonMatPrices.UseVisualStyleBackColor = true;
            // 
            // tabpMinerals
            // 
            tabpMinerals.Controls.Add(txtMineral8);
            tabpMinerals.Controls.Add(txtMineral7);
            tabpMinerals.Controls.Add(txtMineral6);
            tabpMinerals.Controls.Add(txtMineral5);
            tabpMinerals.Controls.Add(txtMineral4);
            tabpMinerals.Controls.Add(txtMineral3);
            tabpMinerals.Controls.Add(txtMineral2);
            tabpMinerals.Controls.Add(txtMineral1);
            tabpMinerals.Controls.Add(lblMineral8);
            tabpMinerals.Controls.Add(lblMineral7);
            tabpMinerals.Controls.Add(lblMineral6);
            tabpMinerals.Controls.Add(lblMineral5);
            tabpMinerals.Controls.Add(lblMineral4);
            tabpMinerals.Controls.Add(lblMineral3);
            tabpMinerals.Controls.Add(lblMineral2);
            tabpMinerals.Controls.Add(lblMineral1);
            tabpMinerals.Controls.Add(pictMineral8);
            tabpMinerals.Controls.Add(pictMineral4);
            tabpMinerals.Controls.Add(pictMineral7);
            tabpMinerals.Controls.Add(pictMineral3);
            tabpMinerals.Controls.Add(pictMineral6);
            tabpMinerals.Controls.Add(pictMineral2);
            tabpMinerals.Controls.Add(pictMineral5);
            tabpMinerals.Controls.Add(pictMineral1);
            tabpMinerals.Controls.Add(btnCloseMinerals);
            tabpMinerals.Controls.Add(btnUpdateMineralPrices);
            tabpMinerals.Location = new Point(4, 24);
            tabpMinerals.Name = "tabpMinerals";
            tabpMinerals.Padding = new Padding(3);
            tabpMinerals.Size = new Size(385, 350);
            tabpMinerals.TabIndex = 0;
            tabpMinerals.Text = "Minerals";
            tabpMinerals.UseVisualStyleBackColor = true;
            // 
            // txtMineral8
            // 
            txtMineral8.Location = new Point(262, 242);
            txtMineral8.Name = "txtMineral8";
            txtMineral8.Size = new Size(84, 20);
            txtMineral8.TabIndex = 8;
            txtMineral8.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMineral7
            // 
            txtMineral7.Location = new Point(262, 178);
            txtMineral7.Name = "txtMineral7";
            txtMineral7.Size = new Size(84, 20);
            txtMineral7.TabIndex = 6;
            txtMineral7.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMineral6
            // 
            txtMineral6.Location = new Point(86, 178);
            txtMineral6.Name = "txtMineral6";
            txtMineral6.Size = new Size(84, 20);
            txtMineral6.TabIndex = 4;
            txtMineral6.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMineral5
            // 
            txtMineral5.Location = new Point(262, 50);
            txtMineral5.Name = "txtMineral5";
            txtMineral5.Size = new Size(84, 20);
            txtMineral5.TabIndex = 2;
            txtMineral5.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMineral4
            // 
            txtMineral4.Location = new Point(86, 242);
            txtMineral4.Name = "txtMineral4";
            txtMineral4.Size = new Size(84, 20);
            txtMineral4.TabIndex = 7;
            txtMineral4.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMineral3
            // 
            txtMineral3.Location = new Point(262, 114);
            txtMineral3.Name = "txtMineral3";
            txtMineral3.Size = new Size(84, 20);
            txtMineral3.TabIndex = 5;
            txtMineral3.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMineral2
            // 
            txtMineral2.Location = new Point(86, 114);
            txtMineral2.Name = "txtMineral2";
            txtMineral2.Size = new Size(84, 20);
            txtMineral2.TabIndex = 3;
            txtMineral2.TextAlign = HorizontalAlignment.Right;
            // 
            // txtMineral1
            // 
            txtMineral1.Location = new Point(86, 50);
            txtMineral1.Name = "txtMineral1";
            txtMineral1.Size = new Size(84, 20);
            txtMineral1.TabIndex = 1;
            txtMineral1.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMineral8
            // 
            lblMineral8.Location = new Point(262, 226);
            lblMineral8.Name = "lblMineral8";
            lblMineral8.Size = new Size(84, 13);
            lblMineral8.TabIndex = 45;
            lblMineral8.Text = "Morphite";
            lblMineral8.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMineral7
            // 
            lblMineral7.Location = new Point(262, 162);
            lblMineral7.Name = "lblMineral7";
            lblMineral7.Size = new Size(84, 13);
            lblMineral7.TabIndex = 43;
            lblMineral7.Text = "Zydrine";
            lblMineral7.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMineral6
            // 
            lblMineral6.Location = new Point(86, 162);
            lblMineral6.Name = "lblMineral6";
            lblMineral6.Size = new Size(84, 13);
            lblMineral6.TabIndex = 41;
            lblMineral6.Text = "Nocxium";
            lblMineral6.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMineral5
            // 
            lblMineral5.Location = new Point(262, 34);
            lblMineral5.Name = "lblMineral5";
            lblMineral5.Size = new Size(84, 13);
            lblMineral5.TabIndex = 39;
            lblMineral5.Text = "Pyerite";
            lblMineral5.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMineral4
            // 
            lblMineral4.Location = new Point(86, 226);
            lblMineral4.Name = "lblMineral4";
            lblMineral4.Size = new Size(84, 13);
            lblMineral4.TabIndex = 37;
            lblMineral4.Text = "Megacyte";
            lblMineral4.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMineral3
            // 
            lblMineral3.Location = new Point(262, 98);
            lblMineral3.Name = "lblMineral3";
            lblMineral3.Size = new Size(84, 13);
            lblMineral3.TabIndex = 35;
            lblMineral3.Text = "Isogen";
            lblMineral3.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMineral2
            // 
            lblMineral2.Location = new Point(86, 98);
            lblMineral2.Name = "lblMineral2";
            lblMineral2.Size = new Size(84, 13);
            lblMineral2.TabIndex = 33;
            lblMineral2.Text = "Mexallon";
            lblMineral2.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMineral1
            // 
            lblMineral1.Location = new Point(86, 34);
            lblMineral1.Name = "lblMineral1";
            lblMineral1.Size = new Size(84, 13);
            lblMineral1.TabIndex = 31;
            lblMineral1.Text = "Tritanium";
            lblMineral1.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictMineral8
            // 
            pictMineral8.Image = (Image)resources.GetObject("pictMineral8.Image");
            pictMineral8.Location = new Point(224, 235);
            pictMineral8.Name = "pictMineral8";
            pictMineral8.Size = new Size(32, 32);
            pictMineral8.TabIndex = 30;
            pictMineral8.TabStop = false;
            // 
            // pictMineral4
            // 
            pictMineral4.Image = (Image)resources.GetObject("pictMineral4.Image");
            pictMineral4.Location = new Point(48, 235);
            pictMineral4.Name = "pictMineral4";
            pictMineral4.Size = new Size(32, 32);
            pictMineral4.TabIndex = 29;
            pictMineral4.TabStop = false;
            // 
            // pictMineral7
            // 
            pictMineral7.Image = (Image)resources.GetObject("pictMineral7.Image");
            pictMineral7.Location = new Point(224, 171);
            pictMineral7.Name = "pictMineral7";
            pictMineral7.Size = new Size(32, 32);
            pictMineral7.TabIndex = 28;
            pictMineral7.TabStop = false;
            // 
            // pictMineral3
            // 
            pictMineral3.Image = (Image)resources.GetObject("pictMineral3.Image");
            pictMineral3.Location = new Point(224, 107);
            pictMineral3.Name = "pictMineral3";
            pictMineral3.Size = new Size(32, 32);
            pictMineral3.TabIndex = 27;
            pictMineral3.TabStop = false;
            // 
            // pictMineral6
            // 
            pictMineral6.Image = (Image)resources.GetObject("pictMineral6.Image");
            pictMineral6.Location = new Point(48, 171);
            pictMineral6.Name = "pictMineral6";
            pictMineral6.Size = new Size(32, 32);
            pictMineral6.TabIndex = 26;
            pictMineral6.TabStop = false;
            // 
            // pictMineral2
            // 
            pictMineral2.Image = (Image)resources.GetObject("pictMineral2.Image");
            pictMineral2.Location = new Point(48, 107);
            pictMineral2.Name = "pictMineral2";
            pictMineral2.Size = new Size(32, 32);
            pictMineral2.TabIndex = 25;
            pictMineral2.TabStop = false;
            // 
            // pictMineral5
            // 
            pictMineral5.Image = (Image)resources.GetObject("pictMineral5.Image");
            pictMineral5.Location = new Point(224, 43);
            pictMineral5.Name = "pictMineral5";
            pictMineral5.Size = new Size(32, 32);
            pictMineral5.TabIndex = 24;
            pictMineral5.TabStop = false;
            // 
            // pictMineral1
            // 
            pictMineral1.Image = (Image)resources.GetObject("pictMineral1.Image");
            pictMineral1.Location = new Point(48, 43);
            pictMineral1.Name = "pictMineral1";
            pictMineral1.Size = new Size(32, 32);
            pictMineral1.TabIndex = 23;
            pictMineral1.TabStop = false;
            // 
            // btnCloseMinerals
            // 
            btnCloseMinerals.Location = new Point(206, 310);
            btnCloseMinerals.Name = "btnCloseMinerals";
            btnCloseMinerals.Size = new Size(91, 24);
            btnCloseMinerals.TabIndex = 9;
            btnCloseMinerals.Text = "Close";
            btnCloseMinerals.UseVisualStyleBackColor = true;
            // 
            // btnUpdateMineralPrices
            // 
            btnUpdateMineralPrices.Location = new Point(88, 310);
            btnUpdateMineralPrices.Name = "btnUpdateMineralPrices";
            btnUpdateMineralPrices.Size = new Size(91, 24);
            btnUpdateMineralPrices.TabIndex = 8;
            btnUpdateMineralPrices.Text = "Update Prices";
            btnUpdateMineralPrices.UseVisualStyleBackColor = true;
            // 
            // tabPrices
            // 
            tabPrices.Controls.Add(tabpMinerals);
            tabPrices.Controls.Add(tabpMoonMats);
            tabPrices.Controls.Add(tabpItemSearch);
            tabPrices.ItemSize = new Size(130, 20);
            tabPrices.Location = new Point(5, 9);
            tabPrices.Name = "tabPrices";
            tabPrices.Padding = new Point(3, 3);
            tabPrices.RightToLeft = RightToLeft.No;
            tabPrices.SelectedIndex = 0;
            tabPrices.Size = new Size(393, 378);
            tabPrices.SizeMode = TabSizeMode.FillToRight;
            tabPrices.TabIndex = 0;
            tabPrices.TabStop = false;
            // 
            // frmManualPriceUpdate
            // 
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(396, 389);
            Controls.Add(tabPrices);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmManualPriceUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manual Price Update";
            tabpItemSearch.ResumeLayout(false);
            tabpItemSearch.PerformLayout();
            tabpMoonMats.ResumeLayout(false);
            tabpMoonMats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictMoon11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMoon1).EndInit();
            tabpMinerals.ResumeLayout(false);
            tabpMinerals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictMineral8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMineral1).EndInit();
            tabPrices.ResumeLayout(false);
            ResumeLayout(false);

        }
        internal TabPage tabpItemSearch;
        internal Label lblSelectedItem;
        internal Label lblLSelectedItem;
        internal Button btnItemSearch;
        internal Button btnSearchClose;
        internal Button btnSearchUpdate;
        internal Label lblPriceUpdate;
        internal Label lblItemName;
        internal TextBox txtItemPriceUpdate;
        internal TextBox txtItemSearch;
        internal ListView lstPriceLookup;
        internal TabPage tabpMoonMats;
        internal TextBox txtMoon11;
        internal TextBox txtMoon10;
        internal TextBox txtMoon9;
        internal TextBox txtMoon8;
        internal TextBox txtMoon6;
        internal TextBox txtMoon4;
        internal TextBox txtMoon2;
        internal TextBox txtMoon7;
        internal TextBox txtMoon5;
        internal TextBox txtMoon3;
        internal TextBox txtMoon1;
        internal Label lblMoon11;
        internal PictureBox pictMoon11;
        internal Label lblMoon10;
        internal Label lblMoon9;
        internal PictureBox pictMoon10;
        internal PictureBox pictMoon9;
        internal Label lblMoon8;
        internal Label lblMoon6;
        internal Label lblMoon4;
        internal Label lblMoon2;
        internal Label lblMoon7;
        internal Label lblMoon5;
        internal Label lblMoon3;
        internal Label lblMoon1;
        internal PictureBox pictMoon8;
        internal PictureBox pictMoon7;
        internal PictureBox pictMoon6;
        internal PictureBox pictMoon5;
        internal PictureBox pictMoon4;
        internal PictureBox pictMoon3;
        internal PictureBox pictMoon2;
        internal PictureBox pictMoon1;
        internal Button btnCloseMoonMats;
        internal Button btnUpdateMoonMatPrices;
        internal TabPage tabpMinerals;
        internal TextBox txtMineral8;
        internal TextBox txtMineral7;
        internal TextBox txtMineral6;
        internal TextBox txtMineral5;
        internal TextBox txtMineral4;
        internal TextBox txtMineral3;
        internal TextBox txtMineral2;
        internal TextBox txtMineral1;
        internal Label lblMineral8;
        internal Label lblMineral7;
        internal Label lblMineral6;
        internal Label lblMineral5;
        internal Label lblMineral4;
        internal Label lblMineral3;
        internal Label lblMineral2;
        internal Label lblMineral1;
        internal PictureBox pictMineral8;
        internal PictureBox pictMineral4;
        internal PictureBox pictMineral7;
        internal PictureBox pictMineral3;
        internal PictureBox pictMineral6;
        internal PictureBox pictMineral2;
        internal PictureBox pictMineral5;
        internal PictureBox pictMineral1;
        internal Button btnCloseMinerals;
        internal Button btnUpdateMineralPrices;
        internal TabControl tabPrices;
    }
}