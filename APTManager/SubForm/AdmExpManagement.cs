using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Haebi.Util;
using APTManager.Query;

namespace APTManager.SubForm
{
    public partial class AdmExpManagement : UserControl
    {
        private int gridPreviousRowIndex = 0;

        public AdmExpManagement()
        {
            InitializeComponent();
        }

        private void APTManager_AdmExp_Load(object sender, EventArgs e)
        {
            Init();
        }

        // ==================================================
        //  Methods
        // ==================================================

        private void Init()
        {
            // 그리드 초기화
            Init_GridAdmExp();
        }

        /// <summary>
        /// 그리드 텍스트 정렬
        /// </summary>
        private void Init_GridAdmExp()
        {
            // 그리드 헤더, 컬럼 설정
            gridAdmExp.AllowUserToAddRows = false;    // Row 자동생성 금지
            gridAdmExp.RowHeadersVisible = false;    // 로우 헤더 숨김
            gridAdmExp.Columns.Clear();

            // 컬럼 설정 시 코드 길이 줄이기 위해 설정함.
            Common.AdmExp yyyymm	 = Common.AdmExp.yyyymm;
            Common.AdmExp home		 = Common.AdmExp.home;
            Common.AdmExp name		 = Common.AdmExp.name;
            Common.AdmExp premonth	 = Common.AdmExp.premonth;
            Common.AdmExp nowmonth	 = Common.AdmExp.nowmonth;
            Common.AdmExp useamount	 = Common.AdmExp.useamount;
            Common.AdmExp usecost	 = Common.AdmExp.usecost;
            Common.AdmExp admexpcost = Common.AdmExp.admexpcost;
            Common.AdmExp totalcost	 = Common.AdmExp.totalcost;
            Common.AdmExp remark	 = Common.AdmExp.remark;
            Common.AdmExp ordernum	 = Common.AdmExp.ordernum;

            Common.GridAlign Align_Center   = Common.GridAlign.Center;
            Common.GridAlign Align_Right    = Common.GridAlign.Right;

            // 그리드 컬럼 설정
            // grid / index / colname / colheadertext / alignheader / aligncell / lock / hide
            Util.SetGridColumn(gridAdmExp, (int)yyyymm	    , Common.GetName(yyyymm	   ), "년월"    , Align_Center, Align_Center, true , false);
            Util.SetGridColumn(gridAdmExp, (int)home        , Common.GetName(home      ), "세대"    , Align_Center, Align_Center, true , false);
            Util.SetGridColumn(gridAdmExp, (int)name        , Common.GetName(name      ), "세대주"  , Align_Center, Align_Center, true , false);
            Util.SetGridColumn(gridAdmExp, (int)premonth    , Common.GetName(premonth  ), "전월지침", Align_Center, Align_Right , false, false);
            Util.SetGridColumn(gridAdmExp, (int)nowmonth    , Common.GetName(nowmonth  ), "당월지침", Align_Center, Align_Right , false, false);
            Util.SetGridColumn(gridAdmExp, (int)useamount   , Common.GetName(useamount ), "사용량"  , Align_Center, Align_Right , true , false);
            Util.SetGridColumn(gridAdmExp, (int)usecost	    , Common.GetName(usecost   ), "사용금액", Align_Center, Align_Right , false, false);
            Util.SetGridColumn(gridAdmExp, (int)admexpcost  , Common.GetName(admexpcost), "관리비"  , Align_Center, Align_Right , false, false);
            Util.SetGridColumn(gridAdmExp, (int)totalcost   , Common.GetName(totalcost ), "합계"    , Align_Center, Align_Right , true , false);
            Util.SetGridColumn(gridAdmExp, (int)remark	    , Common.GetName(remark    ), "비고"    , Align_Center, Align_Center, false, false);
            Util.SetGridColumn(gridAdmExp, (int)ordernum    , Common.GetName(ordernum  ), "정렬순서", Align_Center, Align_Center, true , true );
                       
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
            Util.SetDoubleBuffer(gridAdmExp);
        }

        /// <summary>
        /// 콤마 추가
        /// </summary>
        private void AddNumCommaAll()
        {
            for (int i = 0; i < Global.admExpDT.Rows.Count - 1; i++)
            {
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.premonth  ); // 전월지침
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.nowmonth  ); // 당월지침
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.useamount ); // 사용량
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.usecost   ); // 사용금액
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.admexpcost); // 관리비
                Util.AddNumComma(Global.admExpDT, i, (int)Common.AdmExp.totalcost ); // 합계
            }

            Global.admExpDT.AcceptChanges();
        }

        /// <summary>
        /// 콤마 추가 (싱글)
        /// </summary>
        /// <param name="iRow"></param>
        private void AddNumComma(int iRow)
        {
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.premonth  ); // 전월지침
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.nowmonth  ); // 당월지침
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.useamount ); // 사용량
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.usecost   ); // 사용금액
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.admexpcost); // 관리비
            Util.AddNumComma(Global.admExpDT, iRow, (int)Common.AdmExp.totalcost ); // 합계
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
                sum[(int)Common.AdmExp.premonth  ]  += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.premonth  ].ToString().Replace(",", "")); // 전월지침
                sum[(int)Common.AdmExp.nowmonth  ]  += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.nowmonth  ].ToString().Replace(",", "")); // 당월지침
                sum[(int)Common.AdmExp.useamount ]  += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.useamount ].ToString().Replace(",", "")); // 사용량
                sum[(int)Common.AdmExp.usecost   ]  += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.usecost   ].ToString().Replace(",", "")); // 사용금액
                sum[(int)Common.AdmExp.admexpcost]  += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.admexpcost].ToString().Replace(",", "")); // 관리비
                sum[(int)Common.AdmExp.totalcost ]  += Convert.ToUInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.totalcost ].ToString().Replace(",", "")); // 합계
            }

            // 구한 합계를 테이블에 반영
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.premonth]   = sum[(int)Common.AdmExp.premonth  ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.nowmonth]   = sum[(int)Common.AdmExp.nowmonth  ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.useamount]  = sum[(int)Common.AdmExp.useamount ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.usecost]    = sum[(int)Common.AdmExp.usecost   ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.admexpcost] = sum[(int)Common.AdmExp.admexpcost];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.totalcost]  = sum[(int)Common.AdmExp.totalcost ];

            // 콤마 설정
            AddNumComma(Global.admExpDT.Rows.Count - 1);

            // 합계 셀 잠금 (조회 전 RowCount 를 확보 할 수 없어 여기에 둔다)
            Util.LockRow(gridAdmExp, Global.admExpDT.Rows.Count - 1);
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
                        SaveAdmExp();
                }
            }
        }

        // ==================================================
        //  Public
        // ==================================================

        /// <summary>
        /// 관리비 저장
        /// </summary>
        public void SaveAdmExp()
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
            for (int i = 0; i < saveDT.Rows.Count; i++)
            {
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.premonth  ); // 전월지침
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.nowmonth  ); // 당월지침
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.useamount ); // 사용량
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.usecost   ); // 사용금액
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.admexpcost); // 관리비
                Util.DelNumComma(saveDT, i, (int)Common.AdmExp.totalcost ); // 합계
            }

            // 결과 메시지
            Util.MessageSaveResult(AdmExpQuery.SaveAdmExpInfo(saveDT));

            // 변경사항 커밋
            Global.admExpDT.AcceptChanges();

            // 조회
            SelectAdmExp(false);
        }

        /// <summary>
        /// 관리비 조회
        /// </summary>
        /// <param name="yyyymm"></param>
        public void SelectAdmExp(bool msgShow)
        {
            // 변경 된 데이터 저장 여부 확인
            CheckUnsavedData();

            // 공통코드 데이터 로드 Global.comcodeDT
            ComCodeQuery.GetComCode();

            /*
             * 1. 해당 월의 데이터가 있으면 조회한다.
             * 2. 데이터가 없는 경우 새로 양식을 생성한다.
             * 3. 조회 시 세대 정보는 해당 시점에 실제 저장된 것을 가져온다.
             * 4. 전월사용량은 전월데이터를 참고하여 가져온다. (없으면 가져오지 않는다)
             * */

            // 현재년월 데이터 조회
            gridAdmExp.DataSource = AdmExpQuery.GetAdmExpInfo(Global.YYYYMM);

            // 저장된 내용이 없으면 빈 셀 출력
            if (Global.admExpDT.Rows.Count == 0)
            {
                // 더미 데이터 생성
                if (AdmExpQuery.CreateAdmExpInfo(Global.YYYYMM) > 0)
                {
                    HBMessageBox.Show("데이터 생성 완료", "관리비 조회");
                }

                // 저장된 데이터 불러오기
                gridAdmExp.DataSource = AdmExpQuery.GetAdmExpInfo(Global.YYYYMM);
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

            // 당월 사용량 입력 가능하도록 준비
            gridAdmExp.Focus();
            gridAdmExp.CurrentCell = gridAdmExp.Rows[0].Cells[(int)Common.AdmExp.nowmonth];

            // 조회 된 직후 이므로, 아직 이전 Row 값은 없음
            gridPreviousRowIndex = -1;

            // 첫 번째 데이터가 자동 선택 되도록 강제 이벤트 실행
            gridAdmExp_SelectionChanged(null, null);
        }

        // ==================================================
        //  Events
        // ==================================================

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
                Util.SetHighlightStyle(this.gridAdmExp, curRow);

                // 이전로우가 0 보다 작으면 조회된 직후 이므로 아직 이전 로우가 없다. 따라서 이전 로우를 현재로우로 설정하고, 이전 로우 처리는 하지 않는다.
                // 처음 부터 0을 세팅 하면, 0번 로우의 색상 처리에 문제가 생긴다.
                if (gridPreviousRowIndex < 0)
                {
                    gridPreviousRowIndex = curRow;
                    return;
                }

                // 이전 라인 기본색상 표시
                Util.SetDefaultStyle(this.gridAdmExp, gridPreviousRowIndex);
            }

            // 현재 줄 번호 기억
            gridPreviousRowIndex = curRow;
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
        /// 현재 조회된 항목의 관리비 갱신
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyAdmExp_Click(object sender, EventArgs e)
        {
            if (Global.YYYYMM == null)
                return;

            // 결과 메시지
            Util.MessageSaveResult(AdmExpQuery.UpdateAdmExpCost(Global.YYYYMM));

            // 재조회
            SelectAdmExp(false);
        }

        /// <summary>
        /// 전월 사용량 반영
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyPreMonth_Click(object sender, EventArgs e)
        {
            if (Global.YYYYMM == null)
                return;

            string message = "전월 사용량을 다시 가져옵니다."
                + Environment.NewLine
                + Environment.NewLine
                + "현재 사용량을 다시 입력하고 직접 확인 해야 합니다.";

            DialogResult result = HBMessageBox.Show(message, "", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            // 결과 메시지
            Util.MessageSaveResult(AdmExpQuery.UpdateAdmExpPreMonth(Global.YYYYMM));

            // 재조회
            SelectAdmExp(false);
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
                Util.SetDefaultStyle(this.gridAdmExp, curRow);
            }
            else
            {
                Util.SetHighlightStyle(this.gridAdmExp, gridPreviousRowIndex);
            }

            // 당월 사용량 입력 가능하도록 준비
            gridAdmExp.Focus();
            gridAdmExp.CurrentCell = gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.nowmonth];
        }

    }
}
