using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmAddStructureIDs : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddStructureIDs));
            lblStructurePriceInstructions = new Label();
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            Label5 = new Label();
            Label6 = new Label();
            Label7 = new Label();
            Label8 = new Label();
            Label9 = new Label();
            Label10 = new Label();
            TextBox1 = new TextBox();
            TextBox1.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox1.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox1.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox2 = new TextBox();
            TextBox2.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox2.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox2.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox3 = new TextBox();
            TextBox3.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox3.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox3.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox4 = new TextBox();
            TextBox4.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox4.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox4.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox5 = new TextBox();
            TextBox5.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox5.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox5.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox6 = new TextBox();
            TextBox6.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox6.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox6.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox7 = new TextBox();
            TextBox7.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox7.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox7.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox8 = new TextBox();
            TextBox8.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox8.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox8.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox9 = new TextBox();
            TextBox9.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox9.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox9.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TextBox10 = new TextBox();
            TextBox10.TextChanged += new EventHandler(TextBox_TextChanged);
            TextBox10.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            TextBox10.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            btnExit = new Button();
            btnExit.Click += new EventHandler(btnExit_Click);
            btnSaveStuctureIDs = new Button();
            btnSaveStuctureIDs.Click += new EventHandler(btnSaveStuctureIDs_Click);
            Button1 = new Button();
            Button1.Click += new EventHandler(Button_Click);
            Button2 = new Button();
            Button2.Click += new EventHandler(Button_Click);
            Button3 = new Button();
            Button3.Click += new EventHandler(Button_Click);
            Button4 = new Button();
            Button4.Click += new EventHandler(Button_Click);
            Button5 = new Button();
            Button5.Click += new EventHandler(Button_Click);
            Button6 = new Button();
            Button6.Click += new EventHandler(Button_Click);
            Button7 = new Button();
            Button7.Click += new EventHandler(Button_Click);
            Button8 = new Button();
            Button8.Click += new EventHandler(Button_Click);
            Button9 = new Button();
            Button9.Click += new EventHandler(Button_Click);
            Button10 = new Button();
            Button10.Click += new EventHandler(Button_Click);
            CheckBox1 = new CheckBox();
            CheckBox1.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBox2 = new CheckBox();
            CheckBox2.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBox3 = new CheckBox();
            CheckBox3.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBox4 = new CheckBox();
            CheckBox4.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBox5 = new CheckBox();
            CheckBox5.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBox6 = new CheckBox();
            CheckBox6.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBox7 = new CheckBox();
            CheckBox7.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBox8 = new CheckBox();
            CheckBox8.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBox9 = new CheckBox();
            CheckBox9.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBox10 = new CheckBox();
            CheckBox10.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            btnViewSavedStructures = new Button();
            btnViewSavedStructures.Click += new EventHandler(btnViewSavedStructures_Click);
            SuspendLayout();
            // 
            // lblStructurePriceInstructions
            // 
            lblStructurePriceInstructions.Location = new Point(12, 9);
            lblStructurePriceInstructions.Name = "lblStructurePriceInstructions";
            lblStructurePriceInstructions.Size = new Size(432, 159);
            lblStructurePriceInstructions.TabIndex = 0;
            lblStructurePriceInstructions.Text = "text";
            // 
            // Label1
            // 
            Label1.BorderStyle = BorderStyle.Fixed3D;
            Label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label1.Location = new Point(299, 170);
            Label1.Name = "Label1";
            Label1.Size = new Size(145, 20);
            Label1.TabIndex = 4;
            Label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            Label2.BorderStyle = BorderStyle.Fixed3D;
            Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label2.Location = new Point(299, 198);
            Label2.Name = "Label2";
            Label2.Size = new Size(145, 20);
            Label2.TabIndex = 8;
            Label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            Label3.BorderStyle = BorderStyle.Fixed3D;
            Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label3.Location = new Point(299, 226);
            Label3.Name = "Label3";
            Label3.Size = new Size(145, 20);
            Label3.TabIndex = 12;
            Label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            Label4.BorderStyle = BorderStyle.Fixed3D;
            Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label4.Location = new Point(299, 254);
            Label4.Name = "Label4";
            Label4.Size = new Size(145, 20);
            Label4.TabIndex = 16;
            Label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            Label5.BorderStyle = BorderStyle.Fixed3D;
            Label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label5.Location = new Point(299, 282);
            Label5.Name = "Label5";
            Label5.Size = new Size(145, 20);
            Label5.TabIndex = 20;
            Label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label6
            // 
            Label6.BorderStyle = BorderStyle.Fixed3D;
            Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label6.Location = new Point(299, 310);
            Label6.Name = "Label6";
            Label6.Size = new Size(145, 20);
            Label6.TabIndex = 24;
            Label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            Label7.BorderStyle = BorderStyle.Fixed3D;
            Label7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label7.Location = new Point(299, 338);
            Label7.Name = "Label7";
            Label7.Size = new Size(145, 20);
            Label7.TabIndex = 28;
            Label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            Label8.BorderStyle = BorderStyle.Fixed3D;
            Label8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label8.Location = new Point(299, 368);
            Label8.Name = "Label8";
            Label8.Size = new Size(145, 20);
            Label8.TabIndex = 32;
            Label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label9
            // 
            Label9.BorderStyle = BorderStyle.Fixed3D;
            Label9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label9.Location = new Point(299, 397);
            Label9.Name = "Label9";
            Label9.Size = new Size(145, 20);
            Label9.TabIndex = 36;
            Label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label10
            // 
            Label10.BorderStyle = BorderStyle.Fixed3D;
            Label10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label10.Location = new Point(299, 423);
            Label10.Name = "Label10";
            Label10.Size = new Size(145, 20);
            Label10.TabIndex = 40;
            Label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBox1
            // 
            TextBox1.Enabled = false;
            TextBox1.Location = new Point(112, 170);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(103, 20);
            TextBox1.TabIndex = 2;
            // 
            // TextBox2
            // 
            TextBox2.Enabled = false;
            TextBox2.Location = new Point(112, 198);
            TextBox2.Name = "TextBox2";
            TextBox2.Size = new Size(103, 20);
            TextBox2.TabIndex = 6;
            // 
            // TextBox3
            // 
            TextBox3.Enabled = false;
            TextBox3.Location = new Point(112, 226);
            TextBox3.Name = "TextBox3";
            TextBox3.Size = new Size(103, 20);
            TextBox3.TabIndex = 10;
            // 
            // TextBox4
            // 
            TextBox4.Enabled = false;
            TextBox4.Location = new Point(112, 254);
            TextBox4.Name = "TextBox4";
            TextBox4.Size = new Size(103, 20);
            TextBox4.TabIndex = 14;
            // 
            // TextBox5
            // 
            TextBox5.Enabled = false;
            TextBox5.Location = new Point(112, 282);
            TextBox5.Name = "TextBox5";
            TextBox5.Size = new Size(103, 20);
            TextBox5.TabIndex = 18;
            // 
            // TextBox6
            // 
            TextBox6.Enabled = false;
            TextBox6.Location = new Point(112, 310);
            TextBox6.Name = "TextBox6";
            TextBox6.Size = new Size(103, 20);
            TextBox6.TabIndex = 22;
            // 
            // TextBox7
            // 
            TextBox7.Enabled = false;
            TextBox7.Location = new Point(112, 338);
            TextBox7.Name = "TextBox7";
            TextBox7.Size = new Size(103, 20);
            TextBox7.TabIndex = 26;
            // 
            // TextBox8
            // 
            TextBox8.Enabled = false;
            TextBox8.Location = new Point(112, 366);
            TextBox8.Name = "TextBox8";
            TextBox8.Size = new Size(103, 20);
            TextBox8.TabIndex = 30;
            // 
            // TextBox9
            // 
            TextBox9.Enabled = false;
            TextBox9.Location = new Point(112, 394);
            TextBox9.Name = "TextBox9";
            TextBox9.Size = new Size(103, 20);
            TextBox9.TabIndex = 34;
            // 
            // TextBox10
            // 
            TextBox10.Enabled = false;
            TextBox10.Location = new Point(112, 422);
            TextBox10.Name = "TextBox10";
            TextBox10.Size = new Size(103, 20);
            TextBox10.TabIndex = 38;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(284, 459);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 40);
            btnExit.TabIndex = 43;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnSaveStuctureIDs
            // 
            btnSaveStuctureIDs.Location = new Point(72, 459);
            btnSaveStuctureIDs.Name = "btnSaveStuctureIDs";
            btnSaveStuctureIDs.Size = new Size(100, 40);
            btnSaveStuctureIDs.TabIndex = 41;
            btnSaveStuctureIDs.Text = "Save Structures";
            btnSaveStuctureIDs.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            Button1.Location = new Point(221, 169);
            Button1.Name = "Button1";
            Button1.Size = new Size(70, 22);
            Button1.TabIndex = 3;
            Button1.Text = "Check ID";
            Button1.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            Button2.Location = new Point(221, 197);
            Button2.Name = "Button2";
            Button2.Size = new Size(70, 22);
            Button2.TabIndex = 7;
            Button2.Text = "Check ID";
            Button2.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            Button3.Location = new Point(221, 225);
            Button3.Name = "Button3";
            Button3.Size = new Size(70, 22);
            Button3.TabIndex = 11;
            Button3.Text = "Check ID";
            Button3.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            Button4.Location = new Point(221, 253);
            Button4.Name = "Button4";
            Button4.Size = new Size(70, 22);
            Button4.TabIndex = 15;
            Button4.Text = "Check ID";
            Button4.UseVisualStyleBackColor = true;
            // 
            // Button5
            // 
            Button5.Location = new Point(221, 281);
            Button5.Name = "Button5";
            Button5.Size = new Size(70, 22);
            Button5.TabIndex = 19;
            Button5.Text = "Check ID";
            Button5.UseVisualStyleBackColor = true;
            // 
            // Button6
            // 
            Button6.Location = new Point(221, 309);
            Button6.Name = "Button6";
            Button6.Size = new Size(70, 22);
            Button6.TabIndex = 23;
            Button6.Text = "Check ID";
            Button6.UseVisualStyleBackColor = true;
            // 
            // Button7
            // 
            Button7.Location = new Point(221, 337);
            Button7.Name = "Button7";
            Button7.Size = new Size(70, 22);
            Button7.TabIndex = 27;
            Button7.Text = "Check ID";
            Button7.UseVisualStyleBackColor = true;
            // 
            // Button8
            // 
            Button8.Location = new Point(221, 365);
            Button8.Name = "Button8";
            Button8.Size = new Size(70, 22);
            Button8.TabIndex = 31;
            Button8.Text = "Check ID";
            Button8.UseVisualStyleBackColor = true;
            // 
            // Button9
            // 
            Button9.Location = new Point(221, 393);
            Button9.Name = "Button9";
            Button9.Size = new Size(70, 22);
            Button9.TabIndex = 35;
            Button9.Text = "Check ID";
            Button9.UseVisualStyleBackColor = true;
            // 
            // Button10
            // 
            Button10.Location = new Point(221, 421);
            Button10.Name = "Button10";
            Button10.Size = new Size(70, 22);
            Button10.TabIndex = 39;
            Button10.Text = "Check ID";
            Button10.UseVisualStyleBackColor = true;
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.Location = new Point(15, 172);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(95, 17);
            CheckBox1.TabIndex = 1;
            CheckBox1.Text = "Structure ID 1:";
            CheckBox1.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            CheckBox2.AutoSize = true;
            CheckBox2.Location = new Point(15, 200);
            CheckBox2.Name = "CheckBox2";
            CheckBox2.Size = new Size(95, 17);
            CheckBox2.TabIndex = 5;
            CheckBox2.Text = "Structure ID 2:";
            CheckBox2.UseVisualStyleBackColor = true;
            // 
            // CheckBox3
            // 
            CheckBox3.AutoSize = true;
            CheckBox3.Location = new Point(15, 228);
            CheckBox3.Name = "CheckBox3";
            CheckBox3.Size = new Size(95, 17);
            CheckBox3.TabIndex = 9;
            CheckBox3.Text = "Structure ID 3:";
            CheckBox3.UseVisualStyleBackColor = true;
            // 
            // CheckBox4
            // 
            CheckBox4.AutoSize = true;
            CheckBox4.Location = new Point(15, 256);
            CheckBox4.Name = "CheckBox4";
            CheckBox4.Size = new Size(95, 17);
            CheckBox4.TabIndex = 13;
            CheckBox4.Text = "Structure ID 4:";
            CheckBox4.UseVisualStyleBackColor = true;
            // 
            // CheckBox5
            // 
            CheckBox5.AutoSize = true;
            CheckBox5.Location = new Point(15, 284);
            CheckBox5.Name = "CheckBox5";
            CheckBox5.Size = new Size(95, 17);
            CheckBox5.TabIndex = 17;
            CheckBox5.Text = "Structure ID 5:";
            CheckBox5.UseVisualStyleBackColor = true;
            // 
            // CheckBox6
            // 
            CheckBox6.AutoSize = true;
            CheckBox6.Location = new Point(15, 312);
            CheckBox6.Name = "CheckBox6";
            CheckBox6.Size = new Size(95, 17);
            CheckBox6.TabIndex = 21;
            CheckBox6.Text = "Structure ID 6:";
            CheckBox6.UseVisualStyleBackColor = true;
            // 
            // CheckBox7
            // 
            CheckBox7.AutoSize = true;
            CheckBox7.Location = new Point(15, 340);
            CheckBox7.Name = "CheckBox7";
            CheckBox7.Size = new Size(95, 17);
            CheckBox7.TabIndex = 25;
            CheckBox7.Text = "Structure ID 7:";
            CheckBox7.UseVisualStyleBackColor = true;
            // 
            // CheckBox8
            // 
            CheckBox8.AutoSize = true;
            CheckBox8.Location = new Point(15, 367);
            CheckBox8.Name = "CheckBox8";
            CheckBox8.Size = new Size(95, 17);
            CheckBox8.TabIndex = 29;
            CheckBox8.Text = "Structure ID 8:";
            CheckBox8.UseVisualStyleBackColor = true;
            // 
            // CheckBox9
            // 
            CheckBox9.AutoSize = true;
            CheckBox9.Location = new Point(15, 395);
            CheckBox9.Name = "CheckBox9";
            CheckBox9.Size = new Size(95, 17);
            CheckBox9.TabIndex = 33;
            CheckBox9.Text = "Structure ID 9:";
            CheckBox9.UseVisualStyleBackColor = true;
            // 
            // CheckBox10
            // 
            CheckBox10.AutoSize = true;
            CheckBox10.Location = new Point(15, 423);
            CheckBox10.Name = "CheckBox10";
            CheckBox10.Size = new Size(101, 17);
            CheckBox10.TabIndex = 37;
            CheckBox10.Text = "Structure ID 10:";
            CheckBox10.UseVisualStyleBackColor = true;
            // 
            // btnViewSavedStructures
            // 
            btnViewSavedStructures.Location = new Point(178, 459);
            btnViewSavedStructures.Name = "btnViewSavedStructures";
            btnViewSavedStructures.Size = new Size(100, 40);
            btnViewSavedStructures.TabIndex = 42;
            btnViewSavedStructures.Text = "View Saved Structures";
            btnViewSavedStructures.UseVisualStyleBackColor = true;
            // 
            // frmAddStructureIDs
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 511);
            Controls.Add(btnViewSavedStructures);
            Controls.Add(Button10);
            Controls.Add(Button9);
            Controls.Add(Button8);
            Controls.Add(Button7);
            Controls.Add(Button6);
            Controls.Add(Button5);
            Controls.Add(Button4);
            Controls.Add(Button3);
            Controls.Add(Button2);
            Controls.Add(Button1);
            Controls.Add(btnExit);
            Controls.Add(btnSaveStuctureIDs);
            Controls.Add(TextBox10);
            Controls.Add(TextBox9);
            Controls.Add(TextBox8);
            Controls.Add(TextBox7);
            Controls.Add(TextBox6);
            Controls.Add(TextBox5);
            Controls.Add(TextBox4);
            Controls.Add(TextBox3);
            Controls.Add(TextBox2);
            Controls.Add(TextBox1);
            Controls.Add(Label10);
            Controls.Add(Label9);
            Controls.Add(Label8);
            Controls.Add(Label7);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(lblStructurePriceInstructions);
            Controls.Add(CheckBox10);
            Controls.Add(CheckBox9);
            Controls.Add(CheckBox8);
            Controls.Add(CheckBox7);
            Controls.Add(CheckBox6);
            Controls.Add(CheckBox5);
            Controls.Add(CheckBox4);
            Controls.Add(CheckBox3);
            Controls.Add(CheckBox2);
            Controls.Add(CheckBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddStructureIDs";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Structure IDs";
            ResumeLayout(false);
            PerformLayout();

        }
        internal Label lblStructurePriceInstructions;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal Label Label6;
        internal Label Label7;
        internal Label Label8;
        internal Label Label9;
        internal Label Label10;
        internal TextBox TextBox1;
        internal TextBox TextBox2;
        internal TextBox TextBox3;
        internal TextBox TextBox4;
        internal TextBox TextBox5;
        internal TextBox TextBox6;
        internal TextBox TextBox7;
        internal TextBox TextBox8;
        internal TextBox TextBox9;
        internal TextBox TextBox10;
        internal Button btnExit;
        internal Button btnSaveStuctureIDs;
        internal Button Button1;
        internal Button Button2;
        internal Button Button3;
        internal Button Button4;
        internal Button Button5;
        internal Button Button6;
        internal Button Button7;
        internal Button Button8;
        internal Button Button9;
        internal Button Button10;
        internal CheckBox CheckBox1;
        internal CheckBox CheckBox2;
        internal CheckBox CheckBox3;
        internal CheckBox CheckBox4;
        internal CheckBox CheckBox5;
        internal CheckBox CheckBox6;
        internal CheckBox CheckBox7;
        internal CheckBox CheckBox8;
        internal CheckBox CheckBox9;
        internal CheckBox CheckBox10;
        internal Button btnViewSavedStructures;
    }
}