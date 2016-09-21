using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

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
            Util.setColumnHeader(gridAdmExp, "ordernum", "정렬순서");

            gridAdmExp.AllowUserToAddRows = false;  // Row 자동생성 금지

            Util.lockColumn(gridAdmExp, 0);         // 컬럼 잠금
            Util.lockColumn(gridAdmExp, 1);
            Util.lockColumn(gridAdmExp, 2);
            Util.lockColumn(gridAdmExp, 5);
            Util.lockColumn(gridAdmExp, 8);

            Util.hideColumn(gridAdmExp, 10);        // 컬럼 숨김

            // Split Container 설정
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;

            // 가로 고정 상태로 최대화 할 경우, 시작표시줄 아래로 창이 확장되는 문제 있음(win 10, 다른버젼 미확인)
            //this.MaximumSize = new Size(1137, 9999);
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

            // 팝업 위치 설정
            Global.frmHomeInfo.StartPosition = FormStartPosition.Manual;
            Global.frmHomeInfo.Location = new Point(this.Left +20, this.Top +20);

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
             * 3. 조회 시 세대 정보는 해당 시점에 실제 저장된 것을 가져온다.
             * 4. 전월사용량은 전월데이터를 참고하여 가져온다. (없으면 가져오지 않는다)
             * */

            string yyyymm = dtpAdmExp.Value.ToString("yyyyMM");

            // 현재년월 데이터 조회
            gridAdmExp.DataSource = DB.getAdmExpInfo(yyyymm);

            // 저장된 내용이 없으면 빈 셀 출력
            if(Global.admExpDT.Rows.Count == 0)
            {
                // 더미 데이터 생성
                if (DB.createAdmExpInfo(yyyymm) > 0)
                {
                    MessageBox.Show("데이터 생성 완료");
                }

                // 저장된 데이터 불러오기
                gridAdmExp.DataSource = DB.getAdmExpInfo(yyyymm);
            }
            else
            {
                MessageBox.Show("조회 완료");
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

            // 결과 메시지
            Util.messageSaveResult(DB.saveAdmExpInfo(saveDT));
        }

        /// <summary>
        /// 자동계산 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridAdmExp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // 현재 컬럼 인덱스
            int curCol = gridAdmExp.CurrentCell.ColumnIndex;

            switch ((Common.AdmExp)curCol)
            {
                case Common.AdmExp.premonth:
                case Common.AdmExp.nowmonth:
                    // 현재지침 - 전월지침 = 사용량
                    Util.calcCell(gridAdmExp,
                        (int)Common.AdmExp.nowmonth,
                        (int)Common.AdmExp.premonth,
                        (int)Common.AdmExp.useamount,
                        Common.Calc.Sub);
                    break;

                case Common.AdmExp.usecost:
                case Common.AdmExp.admexpcost:
                    // 사용금액 + 관리비 = 합계
                    Util.calcCell(gridAdmExp,
                        (int)Common.AdmExp.usecost,
                        (int)Common.AdmExp.admexpcost,
                        (int)Common.AdmExp.totalcost,
                        Common.Calc.Add);
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// 현재 조회된 항목의 세대정보를 갱신
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyHomeInfo_Click(object sender, EventArgs e)
        {
            string yyyymm = dtpAdmExp.Value.ToString("yyyyMM");

            // 결과 메시지
            Util.messageSaveResult(DB.updateAdmExpHomeInfo(yyyymm));

            // 재조회
            btnGetAdmExp.PerformClick();
        }

        /// <summary>
        /// 인쇄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintAdmExp_Click(object sender, EventArgs e)
        {
            if (Global.frmPrintAdmExp == null
                || Global.frmPrintAdmExp.IsDisposed)
                Global.frmPrintAdmExp = new frmPrintAdmExp();

            // 팝업 위치 설정
            Global.frmPrintAdmExp.StartPosition = FormStartPosition.Manual;
            Global.frmPrintAdmExp.Location = new Point(this.Left + 20, this.Top + 20);

            Global.frmPrintAdmExp.ShowDialog();
        }
    }
}
