using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmReqSkills : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReqSkills));
            btnOK = new Button();
            btnOK.Click += new EventHandler(btnOK_Click);
            SkillTree = new TreeView();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(91, 259);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 25);
            btnOK.TabIndex = 5;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // SkillTree
            // 
            SkillTree.Location = new Point(12, 12);
            SkillTree.Name = "SkillTree";
            SkillTree.Size = new Size(255, 241);
            SkillTree.TabIndex = 4;
            // 
            // frmReqSkills
            // 
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(278, 292);
            Controls.Add(btnOK);
            Controls.Add(SkillTree);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmReqSkills";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Required Skills";
            Shown += new EventHandler(frmReqSkills_Shown);
            ResumeLayout(false);

        }
        internal Button btnOK;
        internal TreeView SkillTree;
    }
}