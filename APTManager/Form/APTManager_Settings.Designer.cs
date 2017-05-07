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
            this.components = new System.ComponentModel.Container();
            this.grpCommonCode = new System.Windows.Forms.GroupBox();
            this.gridCommonCode = new Haebi.Util.HBDataGridView(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.grpCommonCodeGroup = new System.Windows.Forms.GroupBox();
            this.gridCommonCodeGroup = new Haebi.Util.HBDataGridView(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataMgmt1 = new APTManager.SubForm.DataMgmt();
            this.grpCommonCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCode)).BeginInit();
            this.grpCommonCodeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCodeGroup)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCommonCode
            // 
            this.grpCommonCode.Controls.Add(this.gridCommonCode);
            this.grpCommonCode.Location = new System.Drawing.Point(218, 32);
            this.grpCommonCode.Name = "grpCommonCode";
            this.grpCommonCode.Size = new System.Drawing.Size(568, 480);
            this.grpCommonCode.TabIndex = 1;
            this.grpCommonCode.TabStop = false;
            this.grpCommonCode.Text = "공통코드 변경";
            // 
            // gridCommonCode
            // 
            this.gridCommonCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommonCode.DataSource = null;
            this.gridCommonCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCommonCode.Location = new System.Drawing.Point(3, 17);
            this.gridCommonCode.Name = "gridCommonCode";
            this.gridCommonCode.RowTemplate.Height = 23;
            this.gridCommonCode.Size = new System.Drawing.Size(562, 460);
            this.gridCommonCode.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(684, 3);
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
            this.grpCommonCodeGroup.Location = new System.Drawing.Point(12, 32);
            this.grpCommonCodeGroup.Name = "grpCommonCodeGroup";
            this.grpCommonCodeGroup.Size = new System.Drawing.Size(200, 480);
            this.grpCommonCodeGroup.TabIndex = 3;
            this.grpCommonCodeGroup.TabStop = false;
            this.grpCommonCodeGroup.Text = "코드 그룹";
            // 
            // gridCommonCodeGroup
            // 
            this.gridCommonCodeGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommonCodeGroup.DataSource = null;
            this.gridCommonCodeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCommonCodeGroup.Location = new System.Drawing.Point(3, 17);
            this.gridCommonCodeGroup.Name = "gridCommonCodeGroup";
            this.gridCommonCodeGroup.RowTemplate.Height = 23;
            this.gridCommonCodeGroup.Size = new System.Drawing.Size(194, 460);
            this.gridCommonCodeGroup.TabIndex = 0;
            this.gridCommonCodeGroup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridCommonCodeGroup_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(810, 552);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 526);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "공통코드";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpCommonCodeGroup);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.grpCommonCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 520);
            this.panel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataMgmt1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(802, 526);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "데이터 관리";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataMgmt1
            // 
            this.dataMgmt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataMgmt1.Location = new System.Drawing.Point(3, 3);
            this.dataMgmt1.Name = "dataMgmt1";
            this.dataMgmt1.Size = new System.Drawing.Size(796, 520);
            this.dataMgmt1.TabIndex = 0;
            // 
            // APTManager_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 573);
            this.Controls.Add(this.tabControl1);
            this.Name = "APTManager_Settings";
            this.Text = "환경설정";
            this.Load += new System.EventHandler(this.APTManager_Settings_Load);
            this.grpCommonCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCode)).EndInit();
            this.grpCommonCodeGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCommonCodeGroup)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpCommonCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpCommonCodeGroup;
        private Haebi.Util.HBDataGridView gridCommonCodeGroup;
        private Haebi.Util.HBDataGridView gridCommonCode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage2;
        private SubForm.DataMgmt dataMgmt1;
    }
}