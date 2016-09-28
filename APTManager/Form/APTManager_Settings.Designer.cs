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
            this.grpCommonCodeGroup = new System.Windows.Forms.GroupBox();
            this.gridCommonCodeGroup = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCode)).BeginInit();
            this.grpCommonCode.SuspendLayout();
            this.grpCommonCodeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCodeGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCommonCode
            // 
            this.gridCommonCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommonCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCommonCode.Location = new System.Drawing.Point(3, 17);
            this.gridCommonCode.Name = "gridCommonCode";
            this.gridCommonCode.RowHeadersVisible = false;
            this.gridCommonCode.RowTemplate.Height = 23;
            this.gridCommonCode.Size = new System.Drawing.Size(562, 466);
            this.gridCommonCode.TabIndex = 0;
            // 
            // grpCommonCode
            // 
            this.grpCommonCode.Controls.Add(this.gridCommonCode);
            this.grpCommonCode.Location = new System.Drawing.Point(223, 41);
            this.grpCommonCode.Name = "grpCommonCode";
            this.grpCommonCode.Size = new System.Drawing.Size(568, 486);
            this.grpCommonCode.TabIndex = 1;
            this.grpCommonCode.TabStop = false;
            this.grpCommonCode.Text = "공통코드 변경";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpCommonCodeGroup
            // 
            this.grpCommonCodeGroup.Controls.Add(this.gridCommonCodeGroup);
            this.grpCommonCodeGroup.Location = new System.Drawing.Point(12, 41);
            this.grpCommonCodeGroup.Name = "grpCommonCodeGroup";
            this.grpCommonCodeGroup.Size = new System.Drawing.Size(200, 483);
            this.grpCommonCodeGroup.TabIndex = 3;
            this.grpCommonCodeGroup.TabStop = false;
            this.grpCommonCodeGroup.Text = "코드 그룹";
            // 
            // gridCommonCodeGroup
            // 
            this.gridCommonCodeGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommonCodeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCommonCodeGroup.Location = new System.Drawing.Point(3, 17);
            this.gridCommonCodeGroup.Name = "gridCommonCodeGroup";
            this.gridCommonCodeGroup.RowTemplate.Height = 23;
            this.gridCommonCodeGroup.Size = new System.Drawing.Size(194, 463);
            this.gridCommonCodeGroup.TabIndex = 4;
            this.gridCommonCodeGroup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridCommonCodeGroup_MouseUp);
            // 
            // APTManager_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 539);
            this.Controls.Add(this.grpCommonCodeGroup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpCommonCode);
            this.Name = "APTManager_Settings";
            this.Text = "환경설정";
            this.Load += new System.EventHandler(this.APTManager_Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCode)).EndInit();
            this.grpCommonCode.ResumeLayout(false);
            this.grpCommonCodeGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCodeGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCommonCode;
        private System.Windows.Forms.GroupBox grpCommonCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpCommonCodeGroup;
        private System.Windows.Forms.DataGridView gridCommonCodeGroup;
    }
}