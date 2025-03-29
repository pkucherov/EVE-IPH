using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmAddCharacter : Form
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddCharacter));
            btnEVESSOLogin = new Button();
            btnEVESSOLogin.Click += new EventHandler(btnEVESSOLogin_Click);
            lblKeyType = new Label();
            chkReadStructures = new CheckBox();
            chkReadStructures.CheckedChanged += new EventHandler(chkReadStructures_CheckedChanged);
            chkReadStructureMarkets = new CheckBox();
            chkReadStructureMarkets.CheckedChanged += new EventHandler(chkReadStructureMarkets_CheckedChanged);
            chkReadStandings = new CheckBox();
            chkReadStandings.CheckedChanged += new EventHandler(chkReadStandings_CheckedChanged);
            chkReadCharacterJobs = new CheckBox();
            chkReadCharacterJobs.CheckedChanged += new EventHandler(chkReadCharacterJobs_CheckedChanged);
            chkReadAgentsResearch = new CheckBox();
            chkReadAgentsResearch.CheckedChanged += new EventHandler(chkReadAgentsResearch_CheckedChanged);
            chkReadAssets = new CheckBox();
            chkReadAssets.CheckedChanged += new EventHandler(chkReadAssets_CheckedChanged);
            chkReadBlueprints = new CheckBox();
            chkReadBlueprints.CheckedChanged += new EventHandler(chkReadBlueprints_CheckedChanged);
            chkManagePlanets = new CheckBox();
            chkManagePlanets.CheckedChanged += new EventHandler(chkManagePlanets_CheckedChanged);
            chkReadCorporationMembership = new CheckBox();
            chkReadCorporationMembership.CheckedChanged += new EventHandler(chkReadCorporationMembership_CheckedChanged);
            chkReadCorporationJobs = new CheckBox();
            chkReadCorporationJobs.CheckedChanged += new EventHandler(chkReadCorporationJobs_CheckedChanged);
            chkReadCorporationAssets = new CheckBox();
            chkReadCorporationAssets.CheckedChanged += new EventHandler(chkReadCorporationAssets_CheckedChanged);
            chkReadCorporationBlueprints = new CheckBox();
            chkReadCorporationBlueprints.CheckedChanged += new EventHandler(chkReadCorporationBlueprints_CheckedChanged);
            gbCorp = new GroupBox();
            gbCharacter = new GroupBox();
            gbStructures = new GroupBox();
            CheckBox5 = new CheckBox();
            CheckBox5.CheckedChanged += new EventHandler(chkReadCharacterJobs_CheckedChanged);
            CheckBox4 = new CheckBox();
            CheckBox4.CheckedChanged += new EventHandler(chkReadStandings_CheckedChanged);
            CheckBox3 = new CheckBox();
            CheckBox3.CheckedChanged += new EventHandler(chkReadAgentsResearch_CheckedChanged);
            CheckBox1 = new CheckBox();
            CheckBox1.CheckedChanged += new EventHandler(chkReadBlueprints_CheckedChanged);
            CheckBox2 = new CheckBox();
            CheckBox2.CheckedChanged += new EventHandler(chkReadAssets_CheckedChanged);
            ttAPI = new ToolTip(components);
            gbCorp.SuspendLayout();
            gbCharacter.SuspendLayout();
            gbStructures.SuspendLayout();
            SuspendLayout();
            // 
            // btnEVESSOLogin
            // 
            btnEVESSOLogin.BackgroundImage = (Image)resources.GetObject("btnEVESSOLogin.BackgroundImage");
            btnEVESSOLogin.BackgroundImageLayout = ImageLayout.Center;
            btnEVESSOLogin.Location = new Point(141, 238);
            btnEVESSOLogin.Name = "btnEVESSOLogin";
            btnEVESSOLogin.Size = new Size(270, 46);
            btnEVESSOLogin.TabIndex = 2;
            btnEVESSOLogin.UseVisualStyleBackColor = true;
            // 
            // lblKeyType
            // 
            lblKeyType.Location = new Point(12, 9);
            lblKeyType.Name = "lblKeyType";
            lblKeyType.Size = new Size(527, 32);
            lblKeyType.TabIndex = 13;
            lblKeyType.Text = "Select the scopes you wish to authorize for this Character and log into EVE to au" + "thorize your character for IPH. (Note: esi-skills.read_skills.v1 is required)";
            // 
            // chkReadStructures
            // 
            chkReadStructures.AutoSize = true;
            chkReadStructures.Location = new Point(11, 19);
            chkReadStructures.Name = "chkReadStructures";
            chkReadStructures.Size = new Size(173, 17);
            chkReadStructures.TabIndex = 14;
            chkReadStructures.Text = "esi-universe.read_structures.v1";
            chkReadStructures.UseVisualStyleBackColor = true;
            // 
            // chkReadStructureMarkets
            // 
            chkReadStructureMarkets.AutoSize = true;
            chkReadStructureMarkets.Location = new Point(11, 42);
            chkReadStructureMarkets.Name = "chkReadStructureMarkets";
            chkReadStructureMarkets.Size = new Size(181, 17);
            chkReadStructureMarkets.TabIndex = 15;
            chkReadStructureMarkets.Text = "esi-markets.structure_markets.v1";
            chkReadStructureMarkets.UseVisualStyleBackColor = true;
            // 
            // chkReadStandings
            // 
            chkReadStandings.AutoSize = true;
            chkReadStandings.Location = new Point(11, 20);
            chkReadStandings.Name = "chkReadStandings";
            chkReadStandings.Size = new Size(182, 17);
            chkReadStandings.TabIndex = 16;
            chkReadStandings.Text = "esi-characters.read_standings.v1";
            chkReadStandings.UseVisualStyleBackColor = true;
            // 
            // chkReadCharacterJobs
            // 
            chkReadCharacterJobs.AutoSize = true;
            chkReadCharacterJobs.Location = new Point(11, 66);
            chkReadCharacterJobs.Name = "chkReadCharacterJobs";
            chkReadCharacterJobs.Size = new Size(193, 17);
            chkReadCharacterJobs.TabIndex = 17;
            chkReadCharacterJobs.Text = "esi-industry.read_character_jobs.v1";
            chkReadCharacterJobs.UseVisualStyleBackColor = true;
            // 
            // chkReadAgentsResearch
            // 
            chkReadAgentsResearch.AutoSize = true;
            chkReadAgentsResearch.Location = new Point(11, 43);
            chkReadAgentsResearch.Name = "chkReadAgentsResearch";
            chkReadAgentsResearch.Size = new Size(216, 17);
            chkReadAgentsResearch.TabIndex = 18;
            chkReadAgentsResearch.Text = "esi-characters.read_agents_research.v1";
            chkReadAgentsResearch.UseVisualStyleBackColor = true;
            // 
            // chkReadAssets
            // 
            chkReadAssets.AutoSize = true;
            chkReadAssets.Location = new Point(11, 89);
            chkReadAssets.Name = "chkReadAssets";
            chkReadAssets.Size = new Size(147, 17);
            chkReadAssets.TabIndex = 19;
            chkReadAssets.Text = "esi-assets.read_assets.v1";
            chkReadAssets.UseVisualStyleBackColor = true;
            // 
            // chkReadBlueprints
            // 
            chkReadBlueprints.AutoSize = true;
            chkReadBlueprints.Location = new Point(11, 112);
            chkReadBlueprints.Name = "chkReadBlueprints";
            chkReadBlueprints.Size = new Size(182, 17);
            chkReadBlueprints.TabIndex = 20;
            chkReadBlueprints.Text = "esi-characters.read_blueprints.v1";
            chkReadBlueprints.UseVisualStyleBackColor = true;
            // 
            // chkManagePlanets
            // 
            chkManagePlanets.AutoSize = true;
            chkManagePlanets.Location = new Point(11, 135);
            chkManagePlanets.Name = "chkManagePlanets";
            chkManagePlanets.Size = new Size(172, 17);
            chkManagePlanets.TabIndex = 21;
            chkManagePlanets.Text = "esi-planets.manage_planets.v1";
            chkManagePlanets.UseVisualStyleBackColor = true;
            // 
            // chkReadCorporationMembership
            // 
            chkReadCorporationMembership.AutoSize = true;
            chkReadCorporationMembership.Location = new Point(11, 20);
            chkReadCorporationMembership.Name = "chkReadCorporationMembership";
            chkReadCorporationMembership.Size = new Size(260, 17);
            chkReadCorporationMembership.TabIndex = 22;
            chkReadCorporationMembership.Text = "esi-corporations.read_corporation_membership.v1";
            chkReadCorporationMembership.UseVisualStyleBackColor = true;
            // 
            // chkReadCorporationJobs
            // 
            chkReadCorporationJobs.AutoSize = true;
            chkReadCorporationJobs.Location = new Point(11, 43);
            chkReadCorporationJobs.Name = "chkReadCorporationJobs";
            chkReadCorporationJobs.Size = new Size(201, 17);
            chkReadCorporationJobs.TabIndex = 23;
            chkReadCorporationJobs.Text = "esi-industry.read_corporation_jobs.v1";
            chkReadCorporationJobs.UseVisualStyleBackColor = true;
            // 
            // chkReadCorporationAssets
            // 
            chkReadCorporationAssets.AutoSize = true;
            chkReadCorporationAssets.Location = new Point(11, 66);
            chkReadCorporationAssets.Name = "chkReadCorporationAssets";
            chkReadCorporationAssets.Size = new Size(206, 17);
            chkReadCorporationAssets.TabIndex = 24;
            chkReadCorporationAssets.Text = "esi-assets.read_corporation_assets.v1";
            chkReadCorporationAssets.UseVisualStyleBackColor = true;
            // 
            // chkReadCorporationBlueprints
            // 
            chkReadCorporationBlueprints.AutoSize = true;
            chkReadCorporationBlueprints.Location = new Point(11, 89);
            chkReadCorporationBlueprints.Name = "chkReadCorporationBlueprints";
            chkReadCorporationBlueprints.Size = new Size(190, 17);
            chkReadCorporationBlueprints.TabIndex = 25;
            chkReadCorporationBlueprints.Text = "esi-corporations.read_blueprints.v1";
            chkReadCorporationBlueprints.UseVisualStyleBackColor = true;
            // 
            // gbCorp
            // 
            gbCorp.Controls.Add(chkReadCorporationMembership);
            gbCorp.Controls.Add(chkReadCorporationJobs);
            gbCorp.Controls.Add(chkReadCorporationAssets);
            gbCorp.Controls.Add(chkReadCorporationBlueprints);
            gbCorp.Location = new Point(258, 44);
            gbCorp.Name = "gbCorp";
            gbCorp.Size = new Size(281, 113);
            gbCorp.TabIndex = 26;
            gbCorp.TabStop = false;
            gbCorp.Text = "Corporation";
            // 
            // gbCharacter
            // 
            gbCharacter.Controls.Add(chkReadCharacterJobs);
            gbCharacter.Controls.Add(chkReadStandings);
            gbCharacter.Controls.Add(chkReadAgentsResearch);
            gbCharacter.Controls.Add(chkManagePlanets);
            gbCharacter.Controls.Add(chkReadAssets);
            gbCharacter.Controls.Add(chkReadBlueprints);
            gbCharacter.Location = new Point(15, 44);
            gbCharacter.Name = "gbCharacter";
            gbCharacter.Size = new Size(237, 188);
            gbCharacter.TabIndex = 27;
            gbCharacter.TabStop = false;
            gbCharacter.Text = "Character";
            // 
            // gbStructures
            // 
            gbStructures.Controls.Add(CheckBox5);
            gbStructures.Controls.Add(CheckBox4);
            gbStructures.Controls.Add(chkReadStructures);
            gbStructures.Controls.Add(CheckBox3);
            gbStructures.Controls.Add(chkReadStructureMarkets);
            gbStructures.Controls.Add(CheckBox1);
            gbStructures.Controls.Add(CheckBox2);
            gbStructures.Location = new Point(258, 163);
            gbStructures.Name = "gbStructures";
            gbStructures.Size = new Size(281, 69);
            gbStructures.TabIndex = 28;
            gbStructures.TabStop = false;
            gbStructures.Text = "Structures";
            // 
            // CheckBox5
            // 
            CheckBox5.AutoSize = true;
            CheckBox5.Location = new Point(-232, -53);
            CheckBox5.Name = "CheckBox5";
            CheckBox5.Size = new Size(193, 17);
            CheckBox5.TabIndex = 17;
            CheckBox5.Text = "esi-industry.read_character_jobs.v1";
            CheckBox5.UseVisualStyleBackColor = true;
            // 
            // CheckBox4
            // 
            CheckBox4.AutoSize = true;
            CheckBox4.Location = new Point(-232, -99);
            CheckBox4.Name = "CheckBox4";
            CheckBox4.Size = new Size(182, 17);
            CheckBox4.TabIndex = 16;
            CheckBox4.Text = "esi-characters.read_standings.v1";
            CheckBox4.UseVisualStyleBackColor = true;
            // 
            // CheckBox3
            // 
            CheckBox3.AutoSize = true;
            CheckBox3.Location = new Point(-232, -76);
            CheckBox3.Name = "CheckBox3";
            CheckBox3.Size = new Size(216, 17);
            CheckBox3.TabIndex = 18;
            CheckBox3.Text = "esi-characters.read_agents_research.v1";
            CheckBox3.UseVisualStyleBackColor = true;
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.Location = new Point(-232, -7);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(182, 17);
            CheckBox1.TabIndex = 20;
            CheckBox1.Text = "esi-characters.read_blueprints.v1";
            CheckBox1.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            CheckBox2.AutoSize = true;
            CheckBox2.Location = new Point(-232, -30);
            CheckBox2.Name = "CheckBox2";
            CheckBox2.Size = new Size(147, 17);
            CheckBox2.TabIndex = 19;
            CheckBox2.Text = "esi-assets.read_assets.v1";
            CheckBox2.UseVisualStyleBackColor = true;
            // 
            // frmAddCharacter
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 292);
            Controls.Add(gbStructures);
            Controls.Add(gbCharacter);
            Controls.Add(gbCorp);
            Controls.Add(lblKeyType);
            Controls.Add(btnEVESSOLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddCharacter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Character";
            gbCorp.ResumeLayout(false);
            gbCorp.PerformLayout();
            gbCharacter.ResumeLayout(false);
            gbCharacter.PerformLayout();
            gbStructures.ResumeLayout(false);
            gbStructures.PerformLayout();
            ResumeLayout(false);

        }

        internal Button btnEVESSOLogin;
        internal Label lblKeyType;
        internal CheckBox chkReadStructures;
        internal CheckBox chkReadStructureMarkets;
        internal CheckBox chkReadStandings;
        internal CheckBox chkReadCharacterJobs;
        internal CheckBox chkReadAgentsResearch;
        internal CheckBox chkReadAssets;
        internal CheckBox chkReadBlueprints;
        internal CheckBox chkManagePlanets;
        internal CheckBox chkReadCorporationMembership;
        internal CheckBox chkReadCorporationJobs;
        internal CheckBox chkReadCorporationAssets;
        internal CheckBox chkReadCorporationBlueprints;
        internal GroupBox gbCorp;
        internal GroupBox gbCharacter;
        internal GroupBox gbStructures;
        internal CheckBox CheckBox5;
        internal CheckBox CheckBox4;
        internal CheckBox CheckBox3;
        internal CheckBox CheckBox1;
        internal CheckBox CheckBox2;
        internal ToolTip ttAPI;
    }
}