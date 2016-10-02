using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Reflection;

using Haebi.Util;

namespace APTManager
{
    public partial class APTManager_Main : Form
    {
        private int gridPreviousRowIndex = 0;

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

            // 그리드 초기화
            Init_GridAdmExp();

            // Split Container 설정
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;

            // 가로 고정 상태로 최대화 할 경우, 시작표시줄 아래로 창이 확장되는 문제 있음(win 10, 다른버젼 미확인)
            //this.MaximumSize = new Size(1137, 9999);
            
            // 시작 시 비활성화 처리(오류방지 -> 조회 후 활성화 처리)
            btnExcel.Enabled        = false;
            btnPrintAdmExp.Enabled  = false;
            btnSaveAdmExp.Enabled   = false;

            // 빠른 조회 버튼 생성
            CreateQuickSelectButtons();            
        }

        /// <summary>
        /// 그리드 텍스트 정렬
        /// </summary>
        private void Init_GridAdmExp()
        {
            // 그리드 헤더, 컬럼 설정
            gridAdmExp.AllowUserToAddRows   = false;    // Row 자동생성 금지
            gridAdmExp.RowHeadersVisible    = false;    // 로우 헤더 숨김
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

            // 컬럼 잠금 설정
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.yyyymm   );
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.home     );
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.name     );
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.useamount);
            Util.LockColumn(gridAdmExp, (int)Common.AdmExp.totalcost);

            // 컬럼 숨김 설정
            Util.HideColumn(gridAdmExp, 10);

            // 컬럼 헤더 텍스트 정렬 설정
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.yyyymm    ), Common.GridAlign.Center);
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.home      ), Common.GridAlign.Center);
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.name      ), Common.GridAlign.Center);
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.premonth  ), Common.GridAlign.Center);
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.nowmonth  ), Common.GridAlign.Center);
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.useamount ), Common.GridAlign.Center);
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.usecost   ), Common.GridAlign.Center);
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.admexpcost), Common.GridAlign.Center);
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.totalcost ), Common.GridAlign.Center);
            Util.AlignCellHeader(gridAdmExp, (int)(Common.AdmExp.remark    ), Common.GridAlign.Center);

            // 컬럼 텍스트 정렬 설정
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.yyyymm    ), Common.GridAlign.Center);
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.home      ), Common.GridAlign.Center);
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.name      ), Common.GridAlign.Center);
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.premonth  ), Common.GridAlign.Right );
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.nowmonth  ), Common.GridAlign.Right );
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.useamount ), Common.GridAlign.Right );
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.usecost   ), Common.GridAlign.Right );
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.admexpcost), Common.GridAlign.Right );
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.totalcost ), Common.GridAlign.Right );
            Util.AlignCell(gridAdmExp, (int)(Common.AdmExp.remark    ), Common.GridAlign.Center);

            // 컬럼 정렬기능 비활성화
            for (int i = 0; i < gridAdmExp.Columns.Count; i++)
            {
                Util.SortColumn(gridAdmExp, i, false);
            }

            // 그리드 선택 줄 표시강조 기능 ON/OFF
            // 이 기능 사용시 Enter 로 다음 줄 넘어가는데 시간이 조금 더 걸린다. (미 사용과 비교시)
            chkRowHighlight.Checked = true;

            // 더블 버퍼링 설정 (로우 하이라이트 표시하는데 너무 오래 걸리는 관계로 설정)
            //DoubleBuffered = true; // 현재 폼 더블버퍼링 유뮤 설정인데... 폼 자체가 갱신되는게 아니기에 별 의미 없다.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, gridAdmExp, new object[] { true });
        }

        /// <summary>
        /// 빠른 조회 버튼 생성
        /// </summary>
        private void CreateQuickSelectButtons()
        {
            // 퀵조회 버튼 생성
            Button[] btn = new Button[12];

            for (int i = 0; i < btn.Length; i++)
            {
                btn[i] = new Button();
                grpQuick.Controls.Add(btn[i]);

                btn[i].Name     = string.Format("btnM{0}", i);
                btn[i].Width    = 30;
                btn[i].Height   = 30;
                btn[i].Top      = 14;
                btn[i].Left     = 6 + i * 36;
                btn[i].Text     = (i + 1).ToString();
                btn[i].Tag      = i + 1;

                btn[i].Click += APTManager_QuickSelect_Click;
            }
        }

        /// <summary>
        /// 빠른 조회 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APTManager_QuickSelect_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            switch((int)btn.Tag)
            {
                case 1:     _ProcessQuickButton("01"); break;
                case 2:     _ProcessQuickButton("02"); break;
                case 3:     _ProcessQuickButton("03"); break;
                case 4:     _ProcessQuickButton("04"); break;
                case 5:     _ProcessQuickButton("05"); break;
                case 6:     _ProcessQuickButton("06"); break;
                case 7:     _ProcessQuickButton("07"); break;
                case 8:     _ProcessQuickButton("08"); break;
                case 9:     _ProcessQuickButton("09"); break;
                case 10:    _ProcessQuickButton("10"); break;
                case 11:    _ProcessQuickButton("11"); break;
                case 12:    _ProcessQuickButton("12"); break;

                default: break;
            }
        }

        /// <summary>
        /// 빠른 조회 버튼 이벤트 처리
        /// </summary>
        /// <param name="MM"></param>
        private void _ProcessQuickButton(string MM)
        {
            string yyyy = dtpAdmExp.Value.ToString("yyyy");
            SelectAdmExp(yyyy + MM, true);
        }

        /// <summary>
        /// 합계를 계산
        /// </summary>
        private void CalcAdmExpSum()
        {
            ulong[] sum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < Global.admExpDT.Rows.Count; i++)
            {
                // 합계는 제외한다.
                if (Global.admExpDT.Rows[i][(int)Common.AdmExp.home].Equals("합계"))
                    continue;

                // 각 항목별로 합계를 구한다
                sum[(int)Common.AdmExp.premonth  ] += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.premonth  ].ToString().Replace(",", "")); // 전월지침
                sum[(int)Common.AdmExp.nowmonth  ] += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.nowmonth  ].ToString().Replace(",", "")); // 당월지침
                sum[(int)Common.AdmExp.useamount ] += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.useamount ].ToString().Replace(",", "")); // 사용량
                sum[(int)Common.AdmExp.usecost   ] += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.usecost   ].ToString().Replace(",", "")); // 사용금액
                sum[(int)Common.AdmExp.admexpcost] += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.admexpcost].ToString().Replace(",", "")); // 관리비
                sum[(int)Common.AdmExp.totalcost ] += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.totalcost ].ToString().Replace(",", "")); // 합계
            }

            // 구한 합계를 테이블에 반영
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.premonth  ] = sum[(int)Common.AdmExp.premonth  ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.nowmonth  ] = sum[(int)Common.AdmExp.nowmonth  ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.useamount ] = sum[(int)Common.AdmExp.useamount ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.usecost   ] = sum[(int)Common.AdmExp.usecost   ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.admexpcost] = sum[(int)Common.AdmExp.admexpcost];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.totalcost ] = sum[(int)Common.AdmExp.totalcost ];

            // 콤마 설정
            AddNumComma(Global.admExpDT.Rows.Count - 1);

            // 합계 셀 잠금 (조회 전 RowCount 를 확보 할 수 없어 여기에 둔다)
            Util.LockRow(gridAdmExp, Global.admExpDT.Rows.Count - 1);
        }

        /// <summary>
        /// 자동계산 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridAdmExp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
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

                // 콤마 설정
                AddNumComma(curRow);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 데이터 변경 사항 체크 및 저장 확인
        /// </summary>
        private void CheckUnsavedData()
        {
            if (Global.admExpDT != null)
            {
                DataTable chkDT = Global.admExpDT.GetChanges();

                if (chkDT != null && chkDT.Rows.Count > 0)
                {
                    string message = "저장 되지 않은 내역이 존재합니다."
                        + Environment.NewLine
                        + Environment.NewLine
                        + "저장 하시겠습니까?";

                    DialogResult result = HBMessageBox.Show(message, "", MessageBoxButtons.YesNo);

                    // 예 를 선택한 경우 저장.
                    if (result == DialogResult.Yes)
                        btnSaveAdmExp.PerformClick();
                }
            }
        }

        /// <summary>
        /// 그리드 로우 색상 표시
        /// </summary>
        /// <param name="CurRowIndex"></param>
        private void SetHighlightStyle(int CurRowIndex)
        {
            // 선택 라인 색상 표시
            DataGridViewCellStyle HighlightStyle = new DataGridViewCellStyle();
            HighlightStyle.BackColor = System.Drawing.Color.LightYellow;

            for (int i = 0; i < gridAdmExp.Columns.Count; i++)
            {
                this.gridAdmExp.Rows[CurRowIndex].Cells[i].Style.ApplyStyle(HighlightStyle);
            }
        }

        /// <summary>
        /// 그리드 로우 기본 스타일로 되돌린다
        /// </summary>
        /// <param name="PrevRowIndex"></param>
        private void SetDefaultStyle(int PrevRowIndex)
        {
            // 스타일 색상 설정
            DataGridViewCellStyle LockStyle = new DataGridViewCellStyle();
            LockStyle.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);

            DataGridViewCellStyle NormalStyle = new DataGridViewCellStyle();
            NormalStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // 원상복귀
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.yyyymm    ].Style.ApplyStyle(LockStyle  );
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.home      ].Style.ApplyStyle(LockStyle  );
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.name      ].Style.ApplyStyle(LockStyle  );
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.premonth  ].Style.ApplyStyle(NormalStyle);
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.nowmonth  ].Style.ApplyStyle(NormalStyle);
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.useamount ].Style.ApplyStyle(LockStyle  );
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.usecost   ].Style.ApplyStyle(NormalStyle);
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.admexpcost].Style.ApplyStyle(NormalStyle);
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.totalcost ].Style.ApplyStyle(LockStyle  );
            this.gridAdmExp.Rows[PrevRowIndex].Cells[(int)Common.AdmExp.remark    ].Style.ApplyStyle(NormalStyle);
        }

        /// <summary>
        /// 관리비 조회
        /// </summary>
        /// <param name="yyyymm"></param>
        private void SelectAdmExp(string yyyymm, bool msgShow)
        {
            // 변경 된 데이터 저장 여부 확인
            CheckUnsavedData();
            
            // 년월 표시를 현재 조회하는 데이터로 변경
            dtpAdmExp.Value = Convert.ToDateTime(string.Format("{0}-{1}", yyyymm.Substring(0,4), yyyymm.Substring(4, 2)));

            // 공통코드 데이터 로드 Global.comcodeDT
            DB.GetComCode();

            /*
             * 1. 해당 월의 데이터가 있으면 조회한다.
             * 2. 데이터가 없는 경우 새로 양식을 생성한다.
             * 3. 조회 시 세대 정보는 해당 시점에 실제 저장된 것을 가져온다.
             * 4. 전월사용량은 전월데이터를 참고하여 가져온다. (없으면 가져오지 않는다)
             * */

            // 현재년월 데이터 조회
            gridAdmExp.DataSource = DB.GetAdmExpInfo(yyyymm);

            // 저장된 내용이 없으면 빈 셀 출력
            if (Global.admExpDT.Rows.Count == 0)
            {
                // 더미 데이터 생성
                if (DB.CreateAdmExpInfo(yyyymm) > 0)
                {
                    HBMessageBox.Show("데이터 생성 완료", "관리비 조회");
                }

                // 저장된 데이터 불러오기
                gridAdmExp.DataSource = DB.GetAdmExpInfo(yyyymm);
            }
            else
            {
                if (msgShow)
                    HBMessageBox.Show("조회 완료", "관리비 조회");
            }

            // 합계 부분 추가
            Global.admExpDT.Rows.Add(new object[] { "", "합계", "", "", "", "", "", "", "", "", "9999" });

            // 합계 계산
            CalcAdmExpSum();

            // 콤마 추가
            AddNumCommaAll();
                        
            // 버튼 활성화
            btnExcel.Enabled = true;    // 엑셀
            btnPrintAdmExp.Enabled = true;    // 인쇄
            btnSaveAdmExp.Enabled = true;    // 저장

            // 당월 사용량 입력 가능하도록 준비
            gridAdmExp.Focus();
            gridAdmExp.CurrentCell = gridAdmExp.Rows[0].Cells[(int)Common.AdmExp.nowmonth];

            // 조회 된 직후 이므로, 아직 이전 Row 값은 없음
            gridPreviousRowIndex = -1;

            // 첫 번째 데이터가 자동 선택 되도록 강제 이벤트 실행
            gridAdmExp_SelectionChanged(null, null);
        }

        /// <summary>
        /// 콤마 추가
        /// </summary>
        private void AddNumCommaAll()
        {
            for (int i = 0; i < Global.admExpDT.Rows.Count - 1; i++)
            {
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.premonth); // 전월지침
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.nowmonth); // 당월지침
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.useamount); // 사용량
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.usecost); // 사용금액
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.admexpcost); // 관리비
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.totalcost); // 합계
            }

            Global.admExpDT.AcceptChanges();
        }

        /// <summary>
        /// 콤마 추가 (싱글)
        /// </summary>
        /// <param name="iRow"></param>
        private void AddNumComma(int iRow)
        {
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.premonth); // 전월지침
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.nowmonth); // 당월지침
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.useamount); // 사용량
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.usecost); // 사용금액
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.admexpcost); // 관리비
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.totalcost); // 합계
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
            SelectAdmExp(dtpAdmExp.Value.ToString("yyyyMM"), true);
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
                HBMessageBox.Show("변경 된 내용이 없습니다");
                return;
            }

            // 콤마 제거
            for(int i = 0; i < saveDT.Rows.Count;i++)
            {
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.premonth  ); // 전월지침
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.nowmonth  ); // 당월지침
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.useamount ); // 사용량
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.usecost   ); // 사용금액
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.admexpcost); // 관리비
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.totalcost ); // 합계
            }

            // 결과 메시지
            Util.MessageSaveResult(DB.SaveAdmExpInfo(saveDT));

            // 변경사항 커밋
            Global.admExpDT.AcceptChanges();

            // 조회
            SelectAdmExp(dtpAdmExp.Value.ToString("yyyyMM"), false);
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

        /// <summary>
        /// 전월 사용량 반영
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyPreMonth_Click(object sender, EventArgs e)
        {
            string message = "전월 사용량을 다시 가져옵니다."
                + Environment.NewLine
                + Environment.NewLine
                + "현재 사용량을 다시 입력하고 직접 확인 해야 합니다.";

            DialogResult result = HBMessageBox.Show(message, "", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            string yyyymm = dtpAdmExp.Value.ToString("yyyyMM");

            // 결과 메시지
            Util.MessageSaveResult(DB.UpdateAdmExpPreMonth(yyyymm));

            // 재조회
            SelectAdmExp(dtpAdmExp.Value.ToString("yyyyMM"), false);
        }

        /// <summary>
        /// 선택 로우 색상 표시 ON/OFF 토글
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRowHighlight_CheckedChanged(object sender, EventArgs e)
        {
            // 조회 전 이면 실행하지 않는다.
            if (gridAdmExp.Rows.Count == 0) return;

            int curRow = gridAdmExp.CurrentCell.RowIndex;

            if (!chkRowHighlight.Checked)
            {
                SetDefaultStyle(curRow);
            }
            else
            {
                SetHighlightStyle(gridPreviousRowIndex);
            }

            // 당월 사용량 입력 가능하도록 준비
            gridAdmExp.Focus();
            gridAdmExp.CurrentCell = gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.nowmonth];
        }

        /// <summary>
        /// 프로그램 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APTManager_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 변경 된 데이터 저장 여부 확인
            CheckUnsavedData();
        }

        /// <summary>
        /// 그리드 로우 체인지 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridAdmExp_SelectionChanged(object sender, EventArgs e)
        {
            int curRow = gridAdmExp.CurrentCell.RowIndex;

            if (chkRowHighlight.Checked)
            {
                // 현재로우 = 이전로우 인 경우, 아무 작업도 하지 않는다. (옆 셀로 이동 한 경우 ?)
                // 합계로우는 건들지 않는다.
                if (curRow == gridPreviousRowIndex
                    || curRow == gridAdmExp.Rows.Count - 1)
                    return;

                // 선택 라인 색상 표시
                SetHighlightStyle(curRow);

                // 이전로우가 0 보다 작으면 조회된 직후 이므로 아직 이전 로우가 없다. 따라서 이전 로우를 현재로우로 설정하고, 이전 로우 처리는 하지 않는다.
                // 처음 부터 0을 세팅 하면, 0번 로우의 색상 처리에 문제가 생긴다.
                if (gridPreviousRowIndex < 0)
                {
                    gridPreviousRowIndex = curRow;
                    return;
                }

                // 이전 라인 기본색상 표시
                SetDefaultStyle(gridPreviousRowIndex);
            }

            // 현재 줄 번호 기억
            gridPreviousRowIndex = curRow;
        }

    }
}

