using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmManageAccounts : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageAccounts));
            lstAccounts = new ListView();
            lstAccounts.ColumnClick += new ColumnClickEventHandler(lstAccounts_ColumnClick);
            lstAccounts.SelectedIndexChanged += new EventHandler(lstAccounts_SelectedIndexChanged);
            lstAccounts.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lstAccounts_ItemSelectionChanged);
            colCharacterID = new ColumnHeader();
            colCharacterName = new ColumnHeader();
            colCorporationName = new ColumnHeader();
            colIsDefault = new ColumnHeader();
            colAccountScopes = new ColumnHeader();
            colAccessToken = new ColumnHeader();
            colRefreshToken = new ColumnHeader();
            colAccessTokenExpireDate = new ColumnHeader();
            colTokenType = new ColumnHeader();
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnOK_Click);
            btnDeleteCharacter = new Button();
            btnDeleteCharacter.Click += new EventHandler(btnDeleteKey_Click);
            btnAddCharacter = new Button();
            btnAddCharacter.Click += new EventHandler(btnAdd_Click);
            btnSelectDefaultChar = new Button();
            btnSelectDefaultChar.Click += new EventHandler(btnSelectDefaultChar_Click);
            lstScopes = new ListView();
            colScopes = new ColumnHeader();
            gbAccountData = new GroupBox();
            btnCopyCorpID = new Button();
            btnCopyCorpID.Click += new EventHandler(btnCopyCorpID_Click);
            lblCorpID = new Label();
            txtCorpID = new TextBox();
            lblCharacterID = new Label();
            txtCharacterID = new TextBox();
            btnCopyCharacterID = new Button();
            btnCopyCharacterID.Click += new EventHandler(btnCopyCharacterID_Click);
            btnCopyAccesToken = new Button();
            btnCopyAccesToken.Click += new EventHandler(btnCopyAccesToken_Click);
            btnCopyAll = new Button();
            btnCopyAll.Click += new EventHandler(btnCopyAll_Click);
            Label1 = new Label();
            lblRefreshToken = new Label();
            lblAccessToken = new Label();
            txtRefreshToken = new TextBox();
            txtRefreshToken.KeyDown += new KeyEventHandler(txtRefreshToken_KeyDown);
            txtAccessTokenExpDate = new TextBox();
            txtAccessTokenExpDate.KeyDown += new KeyEventHandler(txtAccessTokenExpDate_KeyDown);
            txtAccessToken = new TextBox();
            txtAccessToken.KeyDown += new KeyEventHandler(txtAccessToken_KeyDown);
            btnRefreshToken = new Button();
            btnRefreshToken.Click += new EventHandler(btnRefreshToken_Click);
            chkDirector = new CheckBox();
            chkFactoryManager = new CheckBox();
            colCorpID = new ColumnHeader();
            gbAccountData.SuspendLayout();
            SuspendLayout();
            // 
            // lstAccounts
            // 
            lstAccounts.Columns.AddRange(new ColumnHeader[] { colCharacterID, colCharacterName, colCorporationName, colIsDefault, colAccountScopes, colAccessToken, colRefreshToken, colAccessTokenExpireDate, colTokenType, colCorpID });
            lstAccounts.FullRowSelect = true;
            lstAccounts.GridLines = true;
            lstAccounts.HideSelection = false;
            lstAccounts.Location = new Point(12, 12);
            lstAccounts.MultiSelect = false;
            lstAccounts.Name = "lstAccounts";
            lstAccounts.Size = new Size(594, 370);
            lstAccounts.TabIndex = 3;
            lstAccounts.UseCompatibleStateImageBehavior = false;
            lstAccounts.View = View.Details;
            // 
            // colCharacterID
            // 
            colCharacterID.Text = "Character ID";
            colCharacterID.Width = 0;
            // 
            // colCharacterName
            // 
            colCharacterName.Text = "Character Name";
            colCharacterName.Width = 238;
            // 
            // colCorporationName
            // 
            colCorporationName.Text = "Corporation Name";
            colCorporationName.Width = 275;
            // 
            // colIsDefault
            // 
            colIsDefault.Text = "Is Default";
            // 
            // colAccountScopes
            // 
            colAccountScopes.Text = "Scopes";
            colAccountScopes.Width = 0;
            // 
            // colAccessToken
            // 
            colAccessToken.Width = 0;
            // 
            // colRefreshToken
            // 
            colRefreshToken.Width = 0;
            // 
            // colAccessTokenExpireDate
            // 
            colAccessTokenExpireDate.Width = 0;
            // 
            // colTokenType
            // 
            colTokenType.Width = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(735, 391);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(122, 30);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCharacter
            // 
            btnDeleteCharacter.Enabled = false;
            btnDeleteCharacter.Location = new Point(351, 391);
            btnDeleteCharacter.Name = "btnDeleteCharacter";
            btnDeleteCharacter.Size = new Size(122, 30);
            btnDeleteCharacter.TabIndex = 6;
            btnDeleteCharacter.Text = "Delete Character";
            btnDeleteCharacter.UseVisualStyleBackColor = true;
            // 
            // btnAddCharacter
            // 
            btnAddCharacter.Location = new Point(223, 391);
            btnAddCharacter.Name = "btnAddCharacter";
            btnAddCharacter.Size = new Size(122, 30);
            btnAddCharacter.TabIndex = 7;
            btnAddCharacter.Text = "Add Character";
            btnAddCharacter.UseVisualStyleBackColor = true;
            // 
            // btnSelectDefaultChar
            // 
            btnSelectDefaultChar.Enabled = false;
            btnSelectDefaultChar.Location = new Point(479, 391);
            btnSelectDefaultChar.Name = "btnSelectDefaultChar";
            btnSelectDefaultChar.Size = new Size(122, 30);
            btnSelectDefaultChar.TabIndex = 8;
            btnSelectDefaultChar.Text = "Set Default Character";
            btnSelectDefaultChar.UseVisualStyleBackColor = true;
            // 
            // lstScopes
            // 
            lstScopes.CausesValidation = false;
            lstScopes.Columns.AddRange(new ColumnHeader[] { colScopes });
            lstScopes.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstScopes.HideSelection = false;
            lstScopes.Location = new Point(612, 12);
            lstScopes.MultiSelect = false;
            lstScopes.Name = "lstScopes";
            lstScopes.Size = new Size(458, 215);
            lstScopes.TabIndex = 9;
            lstScopes.UseCompatibleStateImageBehavior = false;
            lstScopes.View = View.Details;
            // 
            // colScopes
            // 
            colScopes.Text = "Scopes";
            colScopes.Width = 437;
            // 
            // gbAccountData
            // 
            gbAccountData.Controls.Add(btnCopyCorpID);
            gbAccountData.Controls.Add(lblCorpID);
            gbAccountData.Controls.Add(txtCorpID);
            gbAccountData.Controls.Add(lblCharacterID);
            gbAccountData.Controls.Add(txtCharacterID);
            gbAccountData.Controls.Add(btnCopyCharacterID);
            gbAccountData.Controls.Add(btnCopyAccesToken);
            gbAccountData.Controls.Add(btnCopyAll);
            gbAccountData.Controls.Add(Label1);
            gbAccountData.Controls.Add(lblRefreshToken);
            gbAccountData.Controls.Add(lblAccessToken);
            gbAccountData.Controls.Add(txtRefreshToken);
            gbAccountData.Controls.Add(txtAccessTokenExpDate);
            gbAccountData.Controls.Add(txtAccessToken);
            gbAccountData.Location = new Point(612, 249);
            gbAccountData.Name = "gbAccountData";
            gbAccountData.Size = new Size(458, 133);
            gbAccountData.TabIndex = 11;
            gbAccountData.TabStop = false;
            // 
            // btnCopyCorpID
            // 
            btnCopyCorpID.Location = new Point(336, 56);
            btnCopyCorpID.Name = "btnCopyCorpID";
            btnCopyCorpID.Size = new Size(116, 21);
            btnCopyCorpID.TabIndex = 20;
            btnCopyCorpID.Text = "Copy Corporation ID";
            btnCopyCorpID.UseVisualStyleBackColor = true;
            // 
            // lblCorpID
            // 
            lblCorpID.AutoSize = true;
            lblCorpID.Location = new Point(247, 61);
            lblCorpID.Name = "lblCorpID";
            lblCorpID.Size = new Size(78, 13);
            lblCorpID.TabIndex = 19;
            lblCorpID.Text = "Corporation ID:";
            // 
            // txtCorpID
            // 
            txtCorpID.Location = new Point(250, 77);
            txtCorpID.Name = "txtCorpID";
            txtCorpID.ReadOnly = true;
            txtCorpID.Size = new Size(80, 20);
            txtCorpID.TabIndex = 18;
            // 
            // lblCharacterID
            // 
            lblCharacterID.AutoSize = true;
            lblCharacterID.Location = new Point(160, 61);
            lblCharacterID.Name = "lblCharacterID";
            lblCharacterID.Size = new Size(70, 13);
            lblCharacterID.TabIndex = 17;
            lblCharacterID.Text = "Character ID:";
            // 
            // txtCharacterID
            // 
            txtCharacterID.Location = new Point(163, 77);
            txtCharacterID.Name = "txtCharacterID";
            txtCharacterID.ReadOnly = true;
            txtCharacterID.Size = new Size(80, 20);
            txtCharacterID.TabIndex = 16;
            // 
            // btnCopyCharacterID
            // 
            btnCopyCharacterID.Location = new Point(336, 79);
            btnCopyCharacterID.Name = "btnCopyCharacterID";
            btnCopyCharacterID.Size = new Size(116, 21);
            btnCopyCharacterID.TabIndex = 15;
            btnCopyCharacterID.Text = "Copy Character ID";
            btnCopyCharacterID.UseVisualStyleBackColor = true;
            // 
            // btnCopyAccesToken
            // 
            btnCopyAccesToken.Location = new Point(336, 33);
            btnCopyAccesToken.Name = "btnCopyAccesToken";
            btnCopyAccesToken.Size = new Size(116, 21);
            btnCopyAccesToken.TabIndex = 14;
            btnCopyAccesToken.Text = "Copy Acces Token";
            btnCopyAccesToken.UseVisualStyleBackColor = true;
            // 
            // btnCopyAll
            // 
            btnCopyAll.Location = new Point(336, 102);
            btnCopyAll.Name = "btnCopyAll";
            btnCopyAll.Size = new Size(116, 21);
            btnCopyAll.TabIndex = 12;
            btnCopyAll.Text = "Copy Token Data";
            btnCopyAll.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(3, 106);
            Label1.Name = "Label1";
            Label1.Size = new Size(154, 13);
            Label1.TabIndex = 13;
            Label1.Text = "Access Token Expiration Date:";
            // 
            // lblRefreshToken
            // 
            lblRefreshToken.AutoSize = true;
            lblRefreshToken.Location = new Point(3, 61);
            lblRefreshToken.Name = "lblRefreshToken";
            lblRefreshToken.Size = new Size(81, 13);
            lblRefreshToken.TabIndex = 4;
            lblRefreshToken.Text = "Refresh Token:";
            // 
            // lblAccessToken
            // 
            lblAccessToken.AutoSize = true;
            lblAccessToken.Location = new Point(3, 16);
            lblAccessToken.Name = "lblAccessToken";
            lblAccessToken.Size = new Size(79, 13);
            lblAccessToken.TabIndex = 3;
            lblAccessToken.Text = "Access Token:";
            // 
            // txtRefreshToken
            // 
            txtRefreshToken.Location = new Point(6, 77);
            txtRefreshToken.Name = "txtRefreshToken";
            txtRefreshToken.ReadOnly = true;
            txtRefreshToken.Size = new Size(151, 20);
            txtRefreshToken.TabIndex = 2;
            // 
            // txtAccessTokenExpDate
            // 
            txtAccessTokenExpDate.Location = new Point(163, 103);
            txtAccessTokenExpDate.Name = "txtAccessTokenExpDate";
            txtAccessTokenExpDate.ReadOnly = true;
            txtAccessTokenExpDate.Size = new Size(167, 20);
            txtAccessTokenExpDate.TabIndex = 1;
            txtAccessTokenExpDate.TextAlign = HorizontalAlignment.Center;
            // 
            // txtAccessToken
            // 
            txtAccessToken.Location = new Point(6, 34);
            txtAccessToken.Name = "txtAccessToken";
            txtAccessToken.ReadOnly = true;
            txtAccessToken.Size = new Size(324, 20);
            txtAccessToken.TabIndex = 0;
            // 
            // btnRefreshToken
            // 
            btnRefreshToken.Location = new Point(607, 391);
            btnRefreshToken.Name = "btnRefreshToken";
            btnRefreshToken.Size = new Size(122, 30);
            btnRefreshToken.TabIndex = 12;
            btnRefreshToken.Text = "Refresh Token Data";
            btnRefreshToken.UseVisualStyleBackColor = true;
            // 
            // chkDirector
            // 
            chkDirector.AutoCheck = false;
            chkDirector.AutoSize = true;
            chkDirector.Location = new Point(618, 233);
            chkDirector.Name = "chkDirector";
            chkDirector.Size = new Size(88, 17);
            chkDirector.TabIndex = 13;
            chkDirector.Text = "Director Role";
            chkDirector.UseVisualStyleBackColor = true;
            // 
            // chkFactoryManager
            // 
            chkFactoryManager.AutoCheck = false;
            chkFactoryManager.AutoSize = true;
            chkFactoryManager.Location = new Point(725, 233);
            chkFactoryManager.Name = "chkFactoryManager";
            chkFactoryManager.Size = new Size(131, 17);
            chkFactoryManager.TabIndex = 14;
            chkFactoryManager.Text = "Factory Manager Role";
            chkFactoryManager.UseVisualStyleBackColor = true;
            // 
            // colCorpID
            // 
            colCorpID.Width = 0;
            // 
            // frmManageAccounts
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(1080, 430);
            Controls.Add(chkFactoryManager);
            Controls.Add(chkDirector);
            Controls.Add(btnRefreshToken);
            Controls.Add(gbAccountData);
            Controls.Add(lstScopes);
            Controls.Add(btnSelectDefaultChar);
            Controls.Add(btnAddCharacter);
            Controls.Add(btnDeleteCharacter);
            Controls.Add(btnClose);
            Controls.Add(lstAccounts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmManageAccounts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Accounts";
            gbAccountData.ResumeLayout(false);
            gbAccountData.PerformLayout();
            Shown += new EventHandler(frmManageAccounts_Shown);
            ResumeLayout(false);
            PerformLayout();

        }
        internal ListView lstAccounts;
        internal ColumnHeader colCharacterName;
        internal Button btnClose;
        internal Button btnDeleteCharacter;
        internal Button btnAddCharacter;
        internal Button btnSelectDefaultChar;
        internal ColumnHeader colCorporationName;
        internal ListView lstScopes;
        internal ColumnHeader colScopes;
        internal ColumnHeader colIsDefault;
        internal ColumnHeader colAccountScopes;
        internal ColumnHeader colCharacterID;
        internal GroupBox gbAccountData;
        internal TextBox txtRefreshToken;
        internal TextBox txtAccessTokenExpDate;
        internal TextBox txtAccessToken;
        internal Label Label1;
        internal Button btnCopyAll;
        internal Label lblRefreshToken;
        internal Label lblAccessToken;
        internal ColumnHeader colAccessToken;
        internal ColumnHeader colRefreshToken;
        internal ColumnHeader colAccessTokenExpireDate;
        internal Button btnRefreshToken;
        internal ColumnHeader colTokenType;
        internal Label lblCharacterID;
        internal TextBox txtCharacterID;
        internal Button btnCopyCharacterID;
        internal Button btnCopyAccesToken;
        internal CheckBox chkDirector;
        internal CheckBox chkFactoryManager;
        internal Button btnCopyCorpID;
        internal Label lblCorpID;
        internal TextBox txtCorpID;
        internal ColumnHeader colCorpID;
    }
}