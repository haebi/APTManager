namespace APTManager.SubForm
{
    partial class PayManagement
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
            this.btnReApply = new System.Windows.Forms.Button();
            this.chkRowHighlight = new System.Windows.Forms.CheckBox();
            this.gridPayment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPayment)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnReApply);
            this.splitContainer1.Panel1.Controls.Add(this.chkRowHighlight);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridPayment);
            this.splitContainer1.Size = new System.Drawing.Size(1150, 744);
            this.splitContainer1.SplitterDistance = 45;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnApplyPreMonth
            // 
            this.btnApplyPreMonth.Location = new System.Drawing.Point(121, 12);
            this.btnApplyPreMonth.Name = "btnApplyPreMonth";
            this.btnApplyPreMonth.Size = new System.Drawing.Size(102, 24);
            this.btnApplyPreMonth.TabIndex = 18;
            this.btnApplyPreMonth.Text = "미 지정";
            this.btnApplyPreMonth.UseVisualStyleBackColor = true;
            // 
            // btnReApply
            // 
            this.btnReApply.Location = new System.Drawing.Point(13, 12);
            this.btnReApply.Name = "btnReApply";
            this.btnReApply.Size = new System.Drawing.Size(102, 24);
            this.btnReApply.TabIndex = 17;
            this.btnReApply.Text = "다시 가져오기";
            this.btnReApply.UseVisualStyleBackColor = true;
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
            // 
            // gridPayment
            // 
            this.gridPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPayment.Location = new System.Drawing.Point(0, 0);
            this.gridPayment.Name = "gridPayment";
            this.gridPayment.RowTemplate.Height = 23;
            this.gridPayment.Size = new System.Drawing.Size(1150, 695);
            this.gridPayment.TabIndex = 7;
            // 
            // PayManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "PayManagement";
            this.Size = new System.Drawing.Size(1150, 744);
            this.Load += new System.EventHandler(this.PayManagement_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnApplyPreMonth;
        private System.Windows.Forms.Button btnReApply;
        private System.Windows.Forms.CheckBox chkRowHighlight;
        private System.Windows.Forms.DataGridView gridPayment;
    }
}
