namespace APTManager
{
    partial class APTManager_PrintAdmExp
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
            this.ReportViewer_AdmExp = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewer_AdmExp
            // 
            this.ReportViewer_AdmExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer_AdmExp.LocalReport.ReportEmbeddedResource = "APTManager.Report.rptAdmExp.rdlc";
            this.ReportViewer_AdmExp.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer_AdmExp.Name = "ReportViewer_AdmExp";
            this.ReportViewer_AdmExp.Size = new System.Drawing.Size(897, 995);
            this.ReportViewer_AdmExp.TabIndex = 0;
            // 
            // APTManager_PrintAdmExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 995);
            this.Controls.Add(this.ReportViewer_AdmExp);
            this.Name = "APTManager_PrintAdmExp";
            this.Text = "인쇄";
            this.Load += new System.EventHandler(this.frmPrintAdmExp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer_AdmExp;
    }
}