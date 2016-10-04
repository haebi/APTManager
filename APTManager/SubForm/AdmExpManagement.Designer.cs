namespace APTManager.SubForm
{
    partial class AdmExpManagement
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnApplyPreMonth = new System.Windows.Forms.Button();
            this.btnApplyAdmExp = new System.Windows.Forms.Button();
            this.chkRowHighlight = new System.Windows.Forms.CheckBox();
            this.gridAdmExp = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdmExp)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnApplyPreMonth);
            this.splitContainer1.Panel1.Controls.Add(this.btnApplyAdmExp);
            this.splitContainer1.Panel1.Controls.Add(this.chkRowHighlight);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridAdmExp);
            this.splitContainer1.Size = new System.Drawing.Size(1150, 744);
            this.splitContainer1.SplitterDistance = 45;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnApplyPreMonth
            // 
            this.btnApplyPreMonth.Location = new System.Drawing.Point(121, 12);
            this.btnApplyPreMonth.Name = "btnApplyPreMonth";
            this.btnApplyPreMonth.Size = new System.Drawing.Size(102, 24);
            this.btnApplyPreMonth.TabIndex = 18;
            this.btnApplyPreMonth.Text = "전월사용량 반영";
            this.btnApplyPreMonth.UseVisualStyleBackColor = true;
            this.btnApplyPreMonth.Click += new System.EventHandler(this.btnApplyPreMonth_Click);
            // 
            // btnApplyAdmExp
            // 
            this.btnApplyAdmExp.Location = new System.Drawing.Point(13, 12);
            this.btnApplyAdmExp.Name = "btnApplyAdmExp";
            this.btnApplyAdmExp.Size = new System.Drawing.Size(102, 24);
            this.btnApplyAdmExp.TabIndex = 17;
            this.btnApplyAdmExp.Text = "관리비 반영";
            this.btnApplyAdmExp.UseVisualStyleBackColor = true;
            this.btnApplyAdmExp.Click += new System.EventHandler(this.btnApplyAdmExp_Click);
            // 
            // chkRowHighlight
            // 
            this.chkRowHighlight.AutoSize = true;
            this.chkRowHighlight.Location = new System.Drawing.Point(937, 17);
            this.chkRowHighlight.Name = "chkRowHighlight";
            this.chkRowHighlight.Size = new System.Drawing.Size(170, 16);
            this.chkRowHighlight.TabIndex = 14;
            this.chkRowHighlight.Text = "선택 줄 표시 (약간 느려짐)";
            this.chkRowHighlight.UseVisualStyleBackColor = true;
            this.chkRowHighlight.CheckedChanged += new System.EventHandler(this.chkRowHighlight_CheckedChanged);
            // 
            // gridAdmExp
            // 
            this.gridAdmExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAdmExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAdmExp.Location = new System.Drawing.Point(0, 0);
            this.gridAdmExp.Name = "gridAdmExp";
            this.gridAdmExp.RowTemplate.Height = 23;
            this.gridAdmExp.Size = new System.Drawing.Size(1150, 695);
            this.gridAdmExp.TabIndex = 7;
            this.gridAdmExp.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAdmExp_CellEndEdit);
            this.gridAdmExp.SelectionChanged += new System.EventHandler(this.gridAdmExp_SelectionChanged);
            // 
            // APTManager_AdmExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "APTManager_AdmExp";
            this.Size = new System.Drawing.Size(1150, 744);
            this.Load += new System.EventHandler(this.APTManager_AdmExp_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdmExp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridAdmExp;
        private System.Windows.Forms.CheckBox chkRowHighlight;
        private System.Windows.Forms.Button btnApplyPreMonth;
        private System.Windows.Forms.Button btnApplyAdmExp;
    }
}
