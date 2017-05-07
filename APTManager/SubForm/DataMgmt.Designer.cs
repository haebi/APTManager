namespace APTManager.SubForm
{
    partial class DataMgmt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImportAdmExp = new System.Windows.Forms.Button();
            this.btnExportAdmExp = new System.Windows.Forms.Button();
            this.lblExport = new System.Windows.Forms.Label();
            this.lblImport = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblImport);
            this.panel2.Controls.Add(this.lblExport);
            this.panel2.Controls.Add(this.btnImportAdmExp);
            this.panel2.Controls.Add(this.btnExportAdmExp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 428);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnImportAdmExp
            // 
            this.btnImportAdmExp.Location = new System.Drawing.Point(49, 176);
            this.btnImportAdmExp.Name = "btnImportAdmExp";
            this.btnImportAdmExp.Size = new System.Drawing.Size(124, 23);
            this.btnImportAdmExp.TabIndex = 0;
            this.btnImportAdmExp.Text = "CSV 복원";
            this.btnImportAdmExp.UseVisualStyleBackColor = true;
            this.btnImportAdmExp.Click += new System.EventHandler(this.btnImportAdmExp_Click);
            // 
            // btnExportAdmExp
            // 
            this.btnExportAdmExp.Location = new System.Drawing.Point(49, 47);
            this.btnExportAdmExp.Name = "btnExportAdmExp";
            this.btnExportAdmExp.Size = new System.Drawing.Size(124, 23);
            this.btnExportAdmExp.TabIndex = 0;
            this.btnExportAdmExp.Text = "CSV 백업";
            this.btnExportAdmExp.UseVisualStyleBackColor = true;
            this.btnExportAdmExp.Click += new System.EventHandler(this.btnExportAdmExp_Click);
            // 
            // lblExport
            // 
            this.lblExport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExport.Location = new System.Drawing.Point(179, 47);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(496, 82);
            this.lblExport.TabIndex = 1;
            this.lblExport.Text = "label1";
            // 
            // lblImport
            // 
            this.lblImport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblImport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImport.Location = new System.Drawing.Point(179, 176);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(496, 82);
            this.lblImport.TabIndex = 1;
            this.lblImport.Text = "label1";
            // 
            // DataMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "DataMgmt";
            this.Size = new System.Drawing.Size(718, 428);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnImportAdmExp;
        private System.Windows.Forms.Button btnExportAdmExp;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.Label lblImport;
    }
}