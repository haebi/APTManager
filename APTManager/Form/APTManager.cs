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
        /// <summary>
        /// 생성자
        /// </summary>
        public APTManager()
        {
            InitializeComponent();
        }
       
        /// <summary>
        /// 폼 로드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            dtpAdmExp.Format = DateTimePickerFormat.Custom;
            dtpAdmExp.CustomFormat = "yyyy-MM";

            // 그리드 헤더, 컬럼 설정
            gridAdmExp.Columns.Clear();
            Util.setColumnHeader(gridAdmExp, "yyyymm", "년월");
            Util.setColumnHeader(gridAdmExp, "home", "세대");
            Util.setColumnHeader(gridAdmExp, "name", "세대주");
            Util.setColumnHeader(gridAdmExp, "premonth", "전월지침");
            Util.setColumnHeader(gridAdmExp, "nowmonth", "당월지침");
            Util.setColumnHeader(gridAdmExp, "useamount", "사용량");
            Util.setColumnHeader(gridAdmExp, "usecost", "사용금액");
            Util.setColumnHeader(gridAdmExp, "admexpcost", "관리비");
            Util.setColumnHeader(gridAdmExp, "totalcost", "합계");
            Util.setColumnHeader(gridAdmExp, "remark", "비고");

            gridAdmExp.AllowUserToAddRows = false;    // Row 자동생성 금지
            Util.lockCell(gridAdmExp, 0);
            Util.lockCell(gridAdmExp, 1);
            Util.lockCell(gridAdmExp, 2);
            Util.lockCell(gridAdmExp, 5);
            Util.lockCell(gridAdmExp, 8);
        }

        /// <summary>
        /// 엑셀 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (gridAdmExp.DataSource == null 
                || Global.admExpDT.Rows.Count == 0)
            {
                MessageBox.Show("내보낼 데이터가 없습니다." + Environment.NewLine + "조회 후 가능 합니다.");
                return;
            }

            Util.callExcel(Global.admExpDT);
        }

        /// <summary>
        /// 세대 정보 편집 창 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMember_Click(object sender, EventArgs e)
        {
            if (Global.frmHomeInfo == null 
                || Global.frmHomeInfo.IsDisposed)
                Global.frmHomeInfo = new frmHomeInfo();

            Global.frmHomeInfo.ShowDialog();
        }

        /// <summary>
        /// 관리비 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAdmExp_Click(object sender, EventArgs e)
        {
            /*
             * 1. 해당 월의 데이터가 있으면 조회한다.
             * 2. 데이터가 없는 경우 새로 양식을 생성한다.
             * 3. 조회된 세대 정보는 해당 시점에 실제 저장된 것을 가져온다.
             * 4. 전월사용량은 전월데이터를 참고하여 가져온다. (없으면 가져오지 않는다)
             * */

            string yyyymm = dtpAdmExp.Value.ToString("yyyyMM");

            // 현재년월 데이터 조회
            gridAdmExp.DataSource = DB.getAdmExpInfo(yyyymm);

            // 저장된 내용이 없으면 빈 셀 출력
            if(Global.admExpDT.Rows.Count == 0)
            {
                // 더미 데이터 생성
                DB.getEmptyAdmExpInfo(yyyymm);

                // 더미 데이터 저장
                DB.createAdmExpInfo(Global.admExpDT);

                // 저장된 데이터 불러오기
                gridAdmExp.DataSource = DB.getAdmExpInfo(yyyymm);
            }
        }

        /// <summary>
        /// 관리비 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAdmExp_Click(object sender, EventArgs e)
        {
            // 마지막 조회 후 변경된 행만 가져온다.
            DataTable saveDT = Global.admExpDT.GetChanges();

            // 저장 대상이 없으면 그냥 닫는다.
            if (saveDT == null || saveDT.Rows.Count == 0)
            {
                MessageBox.Show("변경 된 내용이 없습니다");
                return;
            }

            switch (DB.saveAdmExpInfo(saveDT))
            {
                case 0:
                    MessageBox.Show("변경 된 내용이 없습니다");
                    break;
                case -1:
                    MessageBox.Show("데이터 저장 중 오류 발생");
                    break;
                default:
                    MessageBox.Show("저장 완료");
                    break;
            }
        }
    }
}
