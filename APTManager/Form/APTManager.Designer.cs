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
            this.components = new System.ComponentModel.Container();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnOpenHomeInfo = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new System.Windows.Forms.Button();
            this.gridManageFee = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridManageFee)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(228, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(102, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "관리비";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnOpenHomeInfo
            // 
            this.btnOpenHomeInfo.Location = new System.Drawing.Point(12, 89);
            this.btnOpenHomeInfo.Name = "btnOpenHomeInfo";
            this.btnOpenHomeInfo.Size = new System.Drawing.Size(102, 23);
            this.btnOpenHomeInfo.TabIndex = 2;
            this.btnOpenHomeInfo.Text = "세대정보";
            this.btnOpenHomeInfo.UseVisualStyleBackColor = true;
            this.btnOpenHomeInfo.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(120, 14);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(102, 21);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(1236, 89);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(102, 23);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // gridManageFee
            // 
            this.gridManageFee.AutoGenerateColumns = false;
            this.gridManageFee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridManageFee.Location = new System.Drawing.Point(12, 118);
            this.gridManageFee.Name = "gridManageFee";
            this.gridManageFee.RowTemplate.Height = 23;
            this.gridManageFee.Size = new System.Drawing.Size(1326, 651);
            this.gridManageFee.TabIndex = 6;
            // 
            // APTManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 781);
            this.Controls.Add(this.gridManageFee);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnOpenHomeInfo);
            this.Controls.Add(this.btnLoad);
            this.Name = "APTManager";
            this.Text = "APTManager (by haebi) 20160901";
            this.Load += new System.EventHandler(this.APTManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridManageFee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnOpenHomeInfo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnExcel;
        private DataGridView gridManageFee;
    }
}

