using System.Windows.Forms;

namespace APTManager
{
    partial class APTManager
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
            this.panel_L1_TOP = new System.Windows.Forms.Panel();
            this.panel_L1_FILL = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdmExp)).BeginInit();
            this.panel_L1_TOP.SuspendLayout();
            this.panel_L1_FILL.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetAdmExp
            // 
            this.btnGetAdmExp.Location = new System.Drawing.Point(120, 10);
            this.btnGetAdmExp.Name = "btnGetAdmExp";
            this.btnGetAdmExp.Size = new System.Drawing.Size(102, 23);
            this.btnGetAdmExp.TabIndex = 0;
            this.btnGetAdmExp.Text = "관리비";
            this.btnGetAdmExp.UseVisualStyleBackColor = true;
            this.btnGetAdmExp.Click += new System.EventHandler(this.btnGetAdmExp_Click);
            // 
            // btnOpenHomeInfo
            // 
            this.btnOpenHomeInfo.Location = new System.Drawing.Point(12, 64);
            this.btnOpenHomeInfo.Name = "btnOpenHomeInfo";
            this.btnOpenHomeInfo.Size = new System.Drawing.Size(102, 23);
            this.btnOpenHomeInfo.TabIndex = 2;
            this.btnOpenHomeInfo.Text = "세대정보";
            this.btnOpenHomeInfo.UseVisualStyleBackColor = true;
            this.btnOpenHomeInfo.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // dtpAdmExp
            // 
            this.dtpAdmExp.Location = new System.Drawing.Point(12, 12);
            this.dtpAdmExp.Name = "dtpAdmExp";
            this.dtpAdmExp.Size = new System.Drawing.Size(102, 21);
            this.dtpAdmExp.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(120, 64);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(102, 23);
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
            this.gridAdmExp.Size = new System.Drawing.Size(1121, 681);
            this.gridAdmExp.TabIndex = 6;
            this.gridAdmExp.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAdmExp_CellEndEdit);
            // 
            // btnSaveAdmExp
            // 
            this.btnSaveAdmExp.Location = new System.Drawing.Point(228, 64);
            this.btnSaveAdmExp.Name = "btnSaveAdmExp";
            this.btnSaveAdmExp.Size = new System.Drawing.Size(102, 23);
            this.btnSaveAdmExp.TabIndex = 7;
            this.btnSaveAdmExp.Text = "저장";
            this.btnSaveAdmExp.UseVisualStyleBackColor = true;
            this.btnSaveAdmExp.Click += new System.EventHandler(this.btnSaveAdmExp_Click);
            // 
            // panel_L1_TOP
            // 
            this.panel_L1_TOP.Controls.Add(this.btnGetAdmExp);
            this.panel_L1_TOP.Controls.Add(this.btnSaveAdmExp);
            this.panel_L1_TOP.Controls.Add(this.dtpAdmExp);
            this.panel_L1_TOP.Controls.Add(this.btnOpenHomeInfo);
            this.panel_L1_TOP.Controls.Add(this.btnExcel);
            this.panel_L1_TOP.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_L1_TOP.Location = new System.Drawing.Point(0, 0);
            this.panel_L1_TOP.Name = "panel_L1_TOP";
            this.panel_L1_TOP.Size = new System.Drawing.Size(1121, 100);
            this.panel_L1_TOP.TabIndex = 8;
            // 
            // panel_L1_FILL
            // 
            this.panel_L1_FILL.Controls.Add(this.gridAdmExp);
            this.panel_L1_FILL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_L1_FILL.Location = new System.Drawing.Point(0, 100);
            this.panel_L1_FILL.Name = "panel_L1_FILL";
            this.panel_L1_FILL.Size = new System.Drawing.Size(1121, 681);
            this.panel_L1_FILL.TabIndex = 9;
            // 
            // APTManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 781);
            this.Controls.Add(this.panel_L1_FILL);
            this.Controls.Add(this.panel_L1_TOP);
            this.Name = "APTManager";
            this.Text = "APTManager (by haebi) 20160905";
            this.Load += new System.EventHandler(this.APTManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdmExp)).EndInit();
            this.panel_L1_TOP.ResumeLayout(false);
            this.panel_L1_FILL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAdmExp;
        private System.Windows.Forms.Button btnOpenHomeInfo;
        private System.Windows.Forms.DateTimePicker dtpAdmExp;
        private System.Windows.Forms.Button btnExcel;
        private DataGridView gridAdmExp;
        private Button btnSaveAdmExp;
        private Panel panel_L1_TOP;
        private Panel panel_L1_FILL;
    }
}

