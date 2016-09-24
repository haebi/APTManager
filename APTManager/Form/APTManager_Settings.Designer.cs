namespace APTManager
{
    partial class APTManager_Settings
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
            this.gridCommonCode = new System.Windows.Forms.DataGridView();
            this.grpCommonCode = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCode)).BeginInit();
            this.grpCommonCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridCommonCode
            // 
            this.gridCommonCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommonCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCommonCode.Location = new System.Drawing.Point(3, 17);
            this.gridCommonCode.Name = "gridCommonCode";
            this.gridCommonCode.RowTemplate.Height = 23;
            this.gridCommonCode.Size = new System.Drawing.Size(614, 367);
            this.gridCommonCode.TabIndex = 0;
            // 
            // grpCommonCode
            // 
            this.grpCommonCode.Controls.Add(this.gridCommonCode);
            this.grpCommonCode.Location = new System.Drawing.Point(12, 41);
            this.grpCommonCode.Name = "grpCommonCode";
            this.grpCommonCode.Size = new System.Drawing.Size(620, 387);
            this.grpCommonCode.TabIndex = 1;
            this.grpCommonCode.TabStop = false;
            this.grpCommonCode.Text = "공통코드 변경";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(527, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // APTManager_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 440);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpCommonCode);
            this.Name = "APTManager_Settings";
            this.Text = "환경설정";
            this.Load += new System.EventHandler(this.APTManager_Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCode)).EndInit();
            this.grpCommonCode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCommonCode;
        private System.Windows.Forms.GroupBox grpCommonCode;
        private System.Windows.Forms.Button button1;
    }
}