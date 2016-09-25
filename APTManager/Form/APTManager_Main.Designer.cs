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
            this.btnGetAdmExp = new System.Windows.Forms.Button();
            this.btnOpenHomeInfo = new System.Windows.Forms.Button();
            this.dtpAdmExp = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new System.Windows.Forms.Button();
            this.gridAdmExp = new System.Windows.Forms.DataGridView();
            this.btnSaveAdmExp = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSetings = new System.Windows.Forms.Button();
            this.btnPrintAdmExp = new System.Windows.Forms.Button();
            this.btnApplyHomeInfo = new System.Windows.Forms.Button();
            this.btnApplyAdmExp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdmExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetAdmExp
            // 
            this.btnGetAdmExp.Location = new System.Drawing.Point(125, 17);
            this.btnGetAdmExp.Name = "btnGetAdmExp";
            this.btnGetAdmExp.Size = new System.Drawing.Size(102, 24);
            this.btnGetAdmExp.TabIndex = 0;
            this.btnGetAdmExp.Text = "조회";
            this.btnGetAdmExp.UseVisualStyleBackColor = true;
            this.btnGetAdmExp.Click += new System.EventHandler(this.btnGetAdmExp_Click);
            // 
            // btnOpenHomeInfo
            // 
            this.btnOpenHomeInfo.Location = new System.Drawing.Point(17, 69);
            this.btnOpenHomeInfo.Name = "btnOpenHomeInfo";
            this.btnOpenHomeInfo.Size = new System.Drawing.Size(102, 24);
            this.btnOpenHomeInfo.TabIndex = 2;
            this.btnOpenHomeInfo.Text = "세대정보";
            this.btnOpenHomeInfo.UseVisualStyleBackColor = true;
            this.btnOpenHomeInfo.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // dtpAdmExp
            // 
            this.dtpAdmExp.Location = new System.Drawing.Point(17, 17);
            this.dtpAdmExp.Name = "dtpAdmExp";
            this.dtpAdmExp.Size = new System.Drawing.Size(102, 21);
            this.dtpAdmExp.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(341, 69);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(102, 24);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // gridAdmExp
            // 
            this.gridAdmExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAdmExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAdmExp.Location = new System.Drawing.Point(0, 0);
            this.gridAdmExp.Name = "gridAdmExp";
            this.gridAdmExp.RowTemplate.Height = 23;
            this.gridAdmExp.Size = new System.Drawing.Size(1121, 663);
            this.gridAdmExp.TabIndex = 6;
            this.gridAdmExp.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAdmExp_CellEndEdit);
            // 
            // btnSaveAdmExp
            // 
            this.btnSaveAdmExp.Location = new System.Drawing.Point(557, 69);
            this.btnSaveAdmExp.Name = "btnSaveAdmExp";
            this.btnSaveAdmExp.Size = new System.Drawing.Size(102, 24);
            this.btnSaveAdmExp.TabIndex = 7;
            this.btnSaveAdmExp.Text = "저장";
            this.btnSaveAdmExp.UseVisualStyleBackColor = true;
            this.btnSaveAdmExp.Click += new System.EventHandler(this.btnSaveAdmExp_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.btnApplyAdmExp);
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
            this.splitContainer1.Panel2.Controls.Add(this.gridAdmExp);
            this.splitContainer1.Size = new System.Drawing.Size(1121, 781);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.TabIndex = 9;
            // 
            // btnSetings
            // 
            this.btnSetings.Location = new System.Drawing.Point(233, 17);
            this.btnSetings.Name = "btnSetings";
            this.btnSetings.Size = new System.Drawing.Size(102, 24);
            this.btnSetings.TabIndex = 11;
            this.btnSetings.Text = "설정";
            this.btnSetings.UseVisualStyleBackColor = true;
            this.btnSetings.Click += new System.EventHandler(this.btnSetings_Click);
            // 
            // btnPrintAdmExp
            // 
            this.btnPrintAdmExp.Location = new System.Drawing.Point(449, 69);
            this.btnPrintAdmExp.Name = "btnPrintAdmExp";
            this.btnPrintAdmExp.Size = new System.Drawing.Size(102, 24);
            this.btnPrintAdmExp.TabIndex = 10;
            this.btnPrintAdmExp.Text = "인쇄";
            this.btnPrintAdmExp.UseVisualStyleBackColor = true;
            this.btnPrintAdmExp.Click += new System.EventHandler(this.btnPrintAdmExp_Click);
            // 
            // btnApplyHomeInfo
            // 
            this.btnApplyHomeInfo.Location = new System.Drawing.Point(125, 69);
            this.btnApplyHomeInfo.Name = "btnApplyHomeInfo";
            this.btnApplyHomeInfo.Size = new System.Drawing.Size(102, 24);
            this.btnApplyHomeInfo.TabIndex = 8;
            this.btnApplyHomeInfo.Text = "세대정보 반영";
            this.btnApplyHomeInfo.UseVisualStyleBackColor = true;
            this.btnApplyHomeInfo.Click += new System.EventHandler(this.btnApplyHomeInfo_Click);
            // 
            // btnApplyAdmExp
            // 
            this.btnApplyAdmExp.Location = new System.Drawing.Point(233, 69);
            this.btnApplyAdmExp.Name = "btnApplyAdmExp";
            this.btnApplyAdmExp.Size = new System.Drawing.Size(102, 24);
            this.btnApplyAdmExp.TabIndex = 12;
            this.btnApplyAdmExp.Text = "관리비 반영";
            this.btnApplyAdmExp.UseVisualStyleBackColor = true;
            this.btnApplyAdmExp.Click += new System.EventHandler(this.btnApplyAdmExp_Click);
            // 
            // APTManager_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 781);
            this.Controls.Add(this.splitContainer1);
            this.Name = "APTManager_Main";
            this.Text = "APTManager (by haebi) ver. 20160922";
            this.Load += new System.EventHandler(this.APTManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdmExp)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAdmExp;
        private System.Windows.Forms.Button btnOpenHomeInfo;
        private System.Windows.Forms.DateTimePicker dtpAdmExp;
        private System.Windows.Forms.Button btnExcel;
        private DataGridView gridAdmExp;
        private Button btnSaveAdmExp;
        private SplitContainer splitContainer1;
        private Button btnApplyHomeInfo;
        private Button btnPrintAdmExp;
        private Button btnSetings;
        private Button btnApplyAdmExp;
    }
}

