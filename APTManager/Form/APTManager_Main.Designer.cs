using System.Windows.Forms;

namespace APTManager
{
    partial class APTManager_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpQuick = new System.Windows.Forms.GroupBox();
            this.btnSetings = new System.Windows.Forms.Button();
            this.btnPrintAdmExp = new System.Windows.Forms.Button();
            this.btnApplyHomeInfo = new System.Windows.Forms.Button();
            this.btnGetAdmExp = new System.Windows.Forms.Button();
            this.btnSaveAdmExp = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dtpAdmExp = new System.Windows.Forms.DateTimePicker();
            this.btnOpenHomeInfo = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.aptManager_AdmExp1 = new APTManager.SubForm.AdmExpManagement();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.payManagement1 = new APTManager.SubForm.PayManagement();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpQuick);
            this.splitContainer1.Panel1.Controls.Add(this.btnSetings);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrintAdmExp);
            this.splitContainer1.Panel1.Controls.Add(this.btnApplyHomeInfo);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetAdmExp);
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveAdmExp);
            this.splitContainer1.Panel1.Controls.Add(this.btnExcel);
            this.splitContainer1.Panel1.Controls.Add(this.dtpAdmExp);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenHomeInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1121, 781);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 9;
            // 
            // grpQuick
            // 
            this.grpQuick.Location = new System.Drawing.Point(671, 3);
            this.grpQuick.Name = "grpQuick";
            this.grpQuick.Size = new System.Drawing.Size(438, 54);
            this.grpQuick.TabIndex = 15;
            this.grpQuick.TabStop = false;
            // 
            // btnSetings
            // 
            this.btnSetings.Location = new System.Drawing.Point(297, 17);
            this.btnSetings.Name = "btnSetings";
            this.btnSetings.Size = new System.Drawing.Size(80, 24);
            this.btnSetings.TabIndex = 11;
            this.btnSetings.Text = "설정";
            this.btnSetings.UseVisualStyleBackColor = true;
            this.btnSetings.Click += new System.EventHandler(this.btnSetings_Click);
            // 
            // btnPrintAdmExp
            // 
            this.btnPrintAdmExp.Location = new System.Drawing.Point(469, 17);
            this.btnPrintAdmExp.Name = "btnPrintAdmExp";
            this.btnPrintAdmExp.Size = new System.Drawing.Size(80, 24);
            this.btnPrintAdmExp.TabIndex = 10;
            this.btnPrintAdmExp.Text = "인쇄";
            this.btnPrintAdmExp.UseVisualStyleBackColor = true;
            this.btnPrintAdmExp.Click += new System.EventHandler(this.btnPrintAdmExp_Click);
            // 
            // btnApplyHomeInfo
            // 
            this.btnApplyHomeInfo.Location = new System.Drawing.Point(233, 47);
            this.btnApplyHomeInfo.Name = "btnApplyHomeInfo";
            this.btnApplyHomeInfo.Size = new System.Drawing.Size(102, 24);
            this.btnApplyHomeInfo.TabIndex = 8;
            this.btnApplyHomeInfo.Text = "세대정보 반영";
            this.btnApplyHomeInfo.UseVisualStyleBackColor = true;
            this.btnApplyHomeInfo.Click += new System.EventHandler(this.btnApplyHomeInfo_Click);
            // 
            // btnGetAdmExp
            // 
            this.btnGetAdmExp.Location = new System.Drawing.Point(125, 17);
            this.btnGetAdmExp.Name = "btnGetAdmExp";
            this.btnGetAdmExp.Size = new System.Drawing.Size(80, 24);
            this.btnGetAdmExp.TabIndex = 0;
            this.btnGetAdmExp.Text = "조회";
            this.btnGetAdmExp.UseVisualStyleBackColor = true;
            this.btnGetAdmExp.Click += new System.EventHandler(this.btnGetAdmExp_Click);
            // 
            // btnSaveAdmExp
            // 
            this.btnSaveAdmExp.Location = new System.Drawing.Point(211, 17);
            this.btnSaveAdmExp.Name = "btnSaveAdmExp";
            this.btnSaveAdmExp.Size = new System.Drawing.Size(80, 24);
            this.btnSaveAdmExp.TabIndex = 7;
            this.btnSaveAdmExp.Text = "저장";
            this.btnSaveAdmExp.UseVisualStyleBackColor = true;
            this.btnSaveAdmExp.Click += new System.EventHandler(this.btnSaveAdmExp_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(383, 17);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(80, 24);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dtpAdmExp
            // 
            this.dtpAdmExp.Location = new System.Drawing.Point(17, 17);
            this.dtpAdmExp.Name = "dtpAdmExp";
            this.dtpAdmExp.Size = new System.Drawing.Size(102, 21);
            this.dtpAdmExp.TabIndex = 4;
            // 
            // btnOpenHomeInfo
            // 
            this.btnOpenHomeInfo.Location = new System.Drawing.Point(125, 47);
            this.btnOpenHomeInfo.Name = "btnOpenHomeInfo";
            this.btnOpenHomeInfo.Size = new System.Drawing.Size(102, 24);
            this.btnOpenHomeInfo.TabIndex = 2;
            this.btnOpenHomeInfo.Text = "세대정보";
            this.btnOpenHomeInfo.UseVisualStyleBackColor = true;
            this.btnOpenHomeInfo.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1121, 693);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.aptManager_AdmExp1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1113, 667);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "관리비";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // aptManager_AdmExp1
            // 
            this.aptManager_AdmExp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aptManager_AdmExp1.Location = new System.Drawing.Point(3, 3);
            this.aptManager_AdmExp1.Name = "aptManager_AdmExp1";
            this.aptManager_AdmExp1.Size = new System.Drawing.Size(1107, 661);
            this.aptManager_AdmExp1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.payManagement1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1113, 667);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "납입금";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // payManagement1
            // 
            this.payManagement1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payManagement1.Location = new System.Drawing.Point(3, 3);
            this.payManagement1.Name = "payManagement1";
            this.payManagement1.Size = new System.Drawing.Size(1107, 661);
            this.payManagement1.TabIndex = 0;
            // 
            // APTManager_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 781);
            this.Controls.Add(this.splitContainer1);
            this.Name = "APTManager_Main";
            this.Text = "APTManager (by haebi) ver. 20161002";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.APTManager_Main_FormClosing);
            this.Load += new System.EventHandler(this.APTManager_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAdmExp;
        private System.Windows.Forms.Button btnOpenHomeInfo;
        private System.Windows.Forms.DateTimePicker dtpAdmExp;
        private System.Windows.Forms.Button btnExcel;
        private Button btnSaveAdmExp;
        private SplitContainer splitContainer1;
        private Button btnApplyHomeInfo;
        private Button btnPrintAdmExp;
        private Button btnSetings;
        private GroupBox grpQuick;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private SubForm.AdmExpManagement aptManager_AdmExp1;
        private TabPage tabPage2;
        private SubForm.PayManagement payManagement1;
    }
}

