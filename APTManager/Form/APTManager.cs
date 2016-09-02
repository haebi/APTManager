using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using ClosedXML.Excel;
using System.Diagnostics;

using APTManager;

namespace APTManager
{
    public partial class APTManager : Form
    {
        public APTManager()
        {
            InitializeComponent();
        }
       
        private void APTManager_Load(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 초기화
        /// </summary>
        private void Init()
        {
            // 데이터타임 피커 포맷 설정 MSDN 코드
            // https://msdn.microsoft.com/ko-kr/library/system.windows.forms.datetimepicker.customformat(v=vs.110).aspx
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM";

            
            //dataGridView1.AllowUserToAddRows = false;      // Row 자동생성 금지
            //dataGridView1.AutoGenerateColumns = false;      
        }

        /// <summary>
        /// 엑셀 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Util.callExcel(Global.manageFeeDT);
        }

        /// <summary>
        /// 세대 정보 편집 창 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMember_Click(object sender, EventArgs e)
        {
            if (Global.frmHomeInfo == null || Global.frmHomeInfo.IsDisposed)
                Global.frmHomeInfo = new frmHomeInfo();

            Global.frmHomeInfo.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // 현재년월 데이터 조회

            // 없으면 멤버목록 조회하여 현재년월 데이터 생성
            gridManageFee.DataSource = DB.getManageFeeInfo();

            //foreach (DataRow dr in dtMonth.Rows)
            //{
            //    dr["YYYYMM"] = dateTimePicker1.Value.ToString("yyyyMM");
            //}

            //gridManageFee.DataSource = dtMonth;

            //Global.lockCell(gridManageFee, 0);
            //Global.lockCell(gridManageFee, 2);
            //Global.lockCell(gridManageFee, 5);

            //gdt = dtMonth.Copy();
        }

    }
}
