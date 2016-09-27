using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace APTManager
{
    public partial class APTManager_Main : Form
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public APTManager_Main()
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
            gridAdmExp.AllowUserToAddRows = false;  // Row 자동생성 금지
            gridAdmExp.Columns.Clear();

            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.yyyymm    ), "년월"    );
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.home      ), "세대"    );
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.name      ), "세대주"  );
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.premonth  ), "전월지침");
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.nowmonth  ), "당월지침");
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.useamount ), "사용량"  );
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.usecost   ), "사용금액");
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.admexpcost), "관리비"  );
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.totalcost ), "합계"    );
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.remark    ), "비고"    );
            Util.SetColumnHeader(gridAdmExp, Common.GetName(Common.AdmExp.ordernum  ), "정렬순서");
            
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.yyyymm   );  // 컬럼 잠금
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.home     );
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.name     );
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.useamount);
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.totalcost);

            Util.HideColumn(gridAdmExp, 10);        // 컬럼 숨김
            
            // Split Container 설정
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;

            // 가로 고정 상태로 최대화 할 경우, 시작표시줄 아래로 창이 확장되는 문제 있음(win 10, 다른버젼 미확인)
            //this.MaximumSize = new Size(1137, 9999);

            // 컬럼 정렬기능 비활성화
            for(int i = 0; i < gridAdmExp.Columns.Count; i++)
            {
                Util.SortColumn(gridAdmExp, i, false);
            }

            // 시작 시 비활성화 처리(오류방지 -> 조회 후 활성화 처리)
            btnExcel.Enabled        = false;
            btnPrintAdmExp.Enabled  = false;
            btnSaveAdmExp.Enabled   = false;
        }

    /// <summary>
    /// 합계를 계산
    /// </summary>
    private void CalcAdmExpSum()
        {
            int[] sum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < Global.admExpDT.Rows.Count; i++)
            {
                // 합계는 제외한다.
                if (Global.admExpDT.Rows[i][(int)Common.AdmExp.home].Equals("합계"))
                    continue;

                // 각 항목별로 합계를 구한다
                sum[(int)Common.AdmExp.premonth  ] += Convert.ToInt32(Global.admExpDT.Rows[i][(int)Common.AdmExp.premonth  ]); // 전월지침
                sum[(int)Common.AdmExp.nowmonth  ] += Convert.ToInt32(Global.admExpDT.Rows[i][(int)Common.AdmExp.nowmonth  ]); // 당월지침
                sum[(int)Common.AdmExp.useamount ] += Convert.ToInt32(Global.admExpDT.Rows[i][(int)Common.AdmExp.useamount ]); // 사용량
                sum[(int)Common.AdmExp.usecost   ] += Convert.ToInt32(Global.admExpDT.Rows[i][(int)Common.AdmExp.usecost   ]); // 사용금액
                sum[(int)Common.AdmExp.admexpcost] += Convert.ToInt32(Global.admExpDT.Rows[i][(int)Common.AdmExp.admexpcost]); // 관리비
                sum[(int)Common.AdmExp.totalcost ] += Convert.ToInt32(Global.admExpDT.Rows[i][(int)Common.AdmExp.totalcost ]); // 합계
            }

            // 구한 합계를 테이블에 반영
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.premonth  ] = sum[(int)Common.AdmExp.premonth  ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.nowmonth  ] = sum[(int)Common.AdmExp.nowmonth  ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.useamount ] = sum[(int)Common.AdmExp.useamount ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.usecost   ] = sum[(int)Common.AdmExp.usecost   ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.admexpcost] = sum[(int)Common.AdmExp.admexpcost];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.totalcost ] = sum[(int)Common.AdmExp.totalcost ];

            // 합계 셀 잠금
            Util.LockRow(gridAdmExp, Global.admExpDT.Rows.Count - 1);
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
            int curRow = gridAdmExp.CurrentCell.RowIndex;

            switch ((Common.AdmExp)curCol)
            {
                case Common.AdmExp.premonth:
                case Common.AdmExp.nowmonth:
                    // 현재지침 - 전월지침 = 사용량
                    Util.CalcCell(gridAdmExp,
                        (int)Common.AdmExp.nowmonth,
                        (int)Common.AdmExp.premonth,
                        (int)Common.AdmExp.useamount,
                        Common.Calc.Sub);

                    // 사용량 자동반영
                    gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.usecost].Value 
                        = Util.GetUseCost(Convert.ToInt32(gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.useamount].Value));

                    // 사용금액 + 관리비 = 합계
                    Util.CalcCell(gridAdmExp,
                        (int)Common.AdmExp.usecost,
                        (int)Common.AdmExp.admexpcost,
                        (int)Common.AdmExp.totalcost,
                        Common.Calc.Add);
                    break;

                case Common.AdmExp.usecost:
                case Common.AdmExp.admexpcost:
                    // 사용금액 + 관리비 = 합계
                    Util.CalcCell(gridAdmExp,
                        (int)Common.AdmExp.usecost,
                        (int)Common.AdmExp.admexpcost,
                        (int)Common.AdmExp.totalcost,
                        Common.Calc.Add);
                    break;

                default:
                    break;
            }

            // 합계 계산
            CalcAdmExpSum();
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

            Util.CallExcel(Global.admExpDT);
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
                Global.frmHomeInfo = new APTManager_HomeInfo();

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
            // 공통코드 데이터 로드 Global.comcodeDT
            DB.GetComCode();

            /*
             * 1. 해당 월의 데이터가 있으면 조회한다.
             * 2. 데이터가 없는 경우 새로 양식을 생성한다.
             * 3. 조회 시 세대 정보는 해당 시점에 실제 저장된 것을 가져온다.
             * 4. 전월사용량은 전월데이터를 참고하여 가져온다. (없으면 가져오지 않는다)
             * */

            string yyyymm = dtpAdmExp.Value.ToString("yyyyMM");

            // 현재년월 데이터 조회
            gridAdmExp.DataSource = DB.GetAdmExpInfo(yyyymm);

            // 저장된 내용이 없으면 빈 셀 출력
            if(Global.admExpDT.Rows.Count == 0)
            {
                // 더미 데이터 생성
                if (DB.CreateAdmExpInfo(yyyymm) > 0)
                {
                    MessageBox.Show("데이터 생성 완료");
                }

                // 저장된 데이터 불러오기
                gridAdmExp.DataSource = DB.GetAdmExpInfo(yyyymm);
            }
            else
            {
                MessageBox.Show("조회 완료");
            }

            // 합계 부분 추가
            Global.admExpDT.Rows.Add(new object[] { "", "합계", "", "", "", "", "", "", "", "", "9999"});

            // 합계 계산
            CalcAdmExpSum();

            // 버튼 활성화
            btnExcel.Enabled        = true;    // 엑셀
            btnPrintAdmExp.Enabled  = true;    // 인쇄
            btnSaveAdmExp.Enabled   = true;    // 저장
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
            Util.MessageSaveResult(DB.SaveAdmExpInfo(saveDT));
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
            Util.MessageSaveResult(DB.UpdateAdmExpHomeInfo(yyyymm));

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
                Global.frmPrintAdmExp = new APTManager_PrintAdmExp();

            // 팝업 위치 설정
            Global.frmPrintAdmExp.StartPosition = FormStartPosition.Manual;
            Global.frmPrintAdmExp.Location = new Point(this.Left + 20, this.Top + 20);

            Global.frmPrintAdmExp.ShowDialog();
        }

        /// <summary>
        /// 환경설정 팝업 오픈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetings_Click(object sender, EventArgs e)
        {
            if (Global.APTManager_Settings == null
                || Global.APTManager_Settings.IsDisposed)
                Global.APTManager_Settings = new APTManager_Settings();

            // 팝업 위치 설정
            Global.APTManager_Settings.StartPosition = FormStartPosition.Manual;
            Global.APTManager_Settings.Location = new Point(this.Left + 20, this.Top + 20);

            Global.APTManager_Settings.ShowDialog();
        }

        /// <summary>
        /// 현재 조회된 항목의 관리비 갱신
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyAdmExp_Click(object sender, EventArgs e)
        {
            string yyyymm = dtpAdmExp.Value.ToString("yyyyMM");

            // 결과 메시지
            Util.MessageSaveResult(DB.UpdateAdmExpCost(yyyymm));

            // 재조회
            btnGetAdmExp.PerformClick();
        }
    }
}
