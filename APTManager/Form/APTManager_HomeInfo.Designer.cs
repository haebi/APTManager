namespace APTManager
{
    partial class APTManager_HomeInfo
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
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.gridHomeInfo = new Haebi.Util.HBDataGridView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridHomeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(225, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridHomeInfo
            // 
            this.gridHomeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHomeInfo.DataSource = null;
            this.gridHomeInfo.Location = new System.Drawing.Point(8, 39);
            this.gridHomeInfo.Name = "gridHomeInfo";
            this.gridHomeInfo.RowTemplate.Height = 23;
            this.gridHomeInfo.Size = new System.Drawing.Size(317, 665);
            this.gridHomeInfo.TabIndex = 2;
            // 
            // APTManager_HomeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 711);
            this.Controls.Add(this.gridHomeInfo);
            this.Controls.Add(this.btnSave);
            this.Name = "APTManager_HomeInfo";
            this.Text = "세대 기본정보";
            this.Load += new System.EventHandler(this.BasicHomeInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridHomeInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private Haebi.Util.HBDataGridView gridHomeInfo;
    }
}