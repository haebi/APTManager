using System;
using System.Data;
using System.Windows.Forms;

using Haebi.Util;

using APTManager.Query;

namespace APTManager.SubForm
{
    public partial class AdmExpManagement : UserControl
    {

        #region Constructor

        public AdmExpManagement()
        {
            InitializeComponent();
        }

        #endregion
                
        #region Private

        private void APTManager_AdmExp_Load(object sender, EventArgs e)
        {
            Init();
        }

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
            gridAdmExp.AllowUserToAddRows   = false;    // Row 자동생성 금지
            gridAdmExp.RowHeadersVisible    = false;    // 로우 헤더 숨김

            gridAdmExp.Columns.Clear();     // 그리드 클리어

            // 그리드 컬럼 설정
            // colname / colheadertext / alignheader / aligncell / lock / hide
            gridAdmExp.SetColumn("yyyymm"        , "년월"     , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridAdmExp.SetColumn("home"          , "세대"     , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridAdmExp.SetColumn("name"          , "세대주"   , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridAdmExp.SetColumn("premonth"      , "전월지침" , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);
            gridAdmExp.SetColumn("nowmonth"      , "당월지침" , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);
            gridAdmExp.SetColumn("useamount"     , "사용량"   , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridAdmExp.SetColumn("usecost"       , "사용금액" , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);
            gridAdmExp.SetColumn("admexpcost"    , "관리비"   , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);
            gridAdmExp.SetColumn("totalcost"     , "합계"     , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridAdmExp.SetColumn("remark"        , "비고"     , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);
            gridAdmExp.SetColumn("ordernum"      , "정렬순서" , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , true );
            gridAdmExp.SetColumn("cost_diff_pre" , "전월차액" , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridAdmExp.SetColumn("cost_pay"      , "남입금"   , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);
            gridAdmExp.SetColumn("cost_diff"     , "차액"     , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);
            
            // 컬럼 정렬기능 비활성화
            gridAdmExp.AllowColumnSort(false);

            // 그리드 선택 줄 표시강조 기능 ON/OFF
            // 이 기능 사용시 Enter 로 다음 줄 넘어가는데 시간이 조금 더 걸린다. (미 사용과 비교시)
            gridAdmExp.ShowRowHighlight = true;
            chkRowHighlight.Checked = true;

            // 더블 버퍼링 설정 (로우 하이라이트 표시하는데 너무 오래 걸리는 관계로 설정)
            gridAdmExp.SetDoubleBuffer = true;

            // 자동계산 규칙 등록
            gridAdmExp.AddAutoProcRule(HBDataGridView.ProcType.Sub, (int)Common.AdmExp.useamount, (int)Common.AdmExp.nowmonth, (int)Common.AdmExp.premonth);
            gridAdmExp.AddAutoProcRule(HBDataGridView.ProcType.Add, (int)Common.AdmExp.totalcost, (int)Common.AdmExp.usecost, (int)Common.AdmExp.admexpcost);
            gridAdmExp.AddAutoProcRule(HBDataGridView.ProcType.Func, CalcTotalCost, (int)Common.AdmExp.premonth);
            gridAdmExp.AddAutoProcRule(HBDataGridView.ProcType.Func, CalcTotalCost, (int)Common.AdmExp.nowmonth);
            gridAdmExp.AddAutoProcRule(HBDataGridView.ProcType.Func, CalcTotalCost, (int)Common.AdmExp.cost_pay);
            gridAdmExp.AddAutoProcRule(HBDataGridView.ProcType.Func, CalcTotalCost, (int)Common.AdmExp.cost_diff);
            gridAdmExp.AddAutoProcRule(HBDataGridView.ProcType.Func, CalcTotalCost, (int)Common.AdmExp.cost_diff_pre);
            gridAdmExp.AddAutoProcRule(HBDataGridView.ProcType.Func, CalcTotalCost, (int)Common.AdmExp.cost_pay);
        }

        /// <summary>
        /// 콤마 추가
        /// </summary>
        private void NumCommaAll(bool flag)
        {
            gridAdmExp.ShowRowHighlight = false;

            for (int i = 0; i < Global.admExpDT.Rows.Count - 1; i++)
            {
                Util.NumComma(Global.admExpDT, i, (int)Common.AdmExp.premonth  , flag); // 전월지침
                Util.NumComma(Global.admExpDT, i, (int)Common.AdmExp.nowmonth  , flag); // 당월지침
                Util.NumComma(Global.admExpDT, i, (int)Common.AdmExp.useamount , flag); // 사용량
                Util.NumComma(Global.admExpDT, i, (int)Common.AdmExp.usecost   , flag); // 사용금액
                Util.NumComma(Global.admExpDT, i, (int)Common.AdmExp.admexpcost, flag); // 관리비
                Util.NumComma(Global.admExpDT, i, (int)Common.AdmExp.totalcost , flag); // 합계
            }

            Global.admExpDT.AcceptChanges();

            gridAdmExp.ShowRowHighlight = true;
        }

        /// <summary>
        /// 콤마 추가 (싱글)
        /// </summary>
        /// <param name="iRow"></param>
        private void NumCommaRow(int iRow, bool flag)
        {
            gridAdmExp.ShowRowHighlight = false;

            Util.NumComma(Global.admExpDT, iRow, (int)Common.AdmExp.premonth  , flag); // 전월지침
            Util.NumComma(Global.admExpDT, iRow, (int)Common.AdmExp.nowmonth  , flag); // 당월지침
            Util.NumComma(Global.admExpDT, iRow, (int)Common.AdmExp.useamount , flag); // 사용량
            Util.NumComma(Global.admExpDT, iRow, (int)Common.AdmExp.usecost   , flag); // 사용금액
            Util.NumComma(Global.admExpDT, iRow, (int)Common.AdmExp.admexpcost, flag); // 관리비
            Util.NumComma(Global.admExpDT, iRow, (int)Common.AdmExp.totalcost , flag); // 합계

            gridAdmExp.ShowRowHighlight = true;
        }

        /// <summary>
        /// 합계를 계산
        /// </summary>
        private void _CalcAdmExpSum()
        {
            long[] sum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < Global.admExpDT.Rows.Count; i++)
            {
                // 합계는 제외한다.
                if (Global.admExpDT.Rows[i][(int)Common.AdmExp.home].Equals("합계"))
                    continue;

                // 각 항목별로 합계를 구한다
                sum[(int)Common.AdmExp.premonth     ] += Convert.ToInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.premonth     ].ToString().Replace(",", "")); // 전월지침
                sum[(int)Common.AdmExp.nowmonth     ] += Convert.ToInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.nowmonth     ].ToString().Replace(",", "")); // 당월지침
                sum[(int)Common.AdmExp.useamount    ] += Convert.ToInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.useamount    ].ToString().Replace(",", "")); // 사용량
                sum[(int)Common.AdmExp.usecost      ] += Convert.ToInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.usecost      ].ToString().Replace(",", "")); // 사용금액
                sum[(int)Common.AdmExp.admexpcost   ] += Convert.ToInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.admexpcost   ].ToString().Replace(",", "")); // 관리비
                sum[(int)Common.AdmExp.totalcost    ] += Convert.ToInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.totalcost    ].ToString().Replace(",", "")); // 합계
                sum[(int)Common.AdmExp.cost_pay     ] += Convert.ToInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.cost_pay     ].ToString().Replace(",", "")); // 납입금
                sum[(int)Common.AdmExp.cost_diff    ] += Convert.ToInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.cost_diff    ].ToString().Replace(",", "")); // 차액
                sum[(int)Common.AdmExp.cost_diff_pre] += Convert.ToInt64(Global.admExpDT.Rows[i][(int)Common.AdmExp.cost_diff_pre].ToString().Replace(",", "")); // 전월차액
            }

            // 구한 합계를 테이블에 반영
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.premonth     ] = sum[(int)Common.AdmExp.premonth     ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.nowmonth     ] = sum[(int)Common.AdmExp.nowmonth     ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.useamount    ] = sum[(int)Common.AdmExp.useamount    ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.usecost      ] = sum[(int)Common.AdmExp.usecost      ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.admexpcost   ] = sum[(int)Common.AdmExp.admexpcost   ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.totalcost    ] = sum[(int)Common.AdmExp.totalcost    ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.cost_pay     ] = sum[(int)Common.AdmExp.cost_pay     ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.cost_diff    ] = sum[(int)Common.AdmExp.cost_diff    ];
            Global.admExpDT.Rows[Global.admExpDT.Rows.Count - 1][(int)Common.AdmExp.cost_diff_pre] = sum[(int)Common.AdmExp.cost_diff_pre];

            // 콤마 설정
            //NumCommaRow(Global.admExpDT.Rows.Count - 1, true);

            // 합계 셀 잠금 (조회 전 RowCount 를 확보 할 수 없어 여기에 둔다)
            gridAdmExp.LockRow(Global.admExpDT.Rows.Count - 1, true);
        }

        /// <summary>
        /// 데이터 변경 사항 체크 및 저장 확인
        /// </summary>
        public void CheckUnsavedData()
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
                        SaveAdmExp(false);  // false : 저장 후 조회안함
                }
            }
        }

        /// <summary>
        /// 합계 금액을 계산합니다. 각 행별 합계와 열 전체 합계를 계산합니다.
        /// </summary>
        /// <returns></returns>
        private bool CalcTotalCost()
        {
            /* HBGridView 내부에서 자체적으로 수행 할 수 없는 내용을 여기에 정의 합니다.
             * OnCellEndEdit 메서드에서 수행하기 위해 AddProcRule() 을 통해 본 메서드를 등록 합니다.
             */

            try
            {
                // 현재 컬럼 인덱스
                int curCol = gridAdmExp.CurrentCell.ColumnIndex;
                int curRow = gridAdmExp.CurrentCell.RowIndex;

                // 현재 행 콤마 제거
                NumCommaRow(curRow, false);

                // 사용금액 = 당월지침을 공통코드  수도요금 으로부터 조회
                gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.usecost].Value
                    = Util.GetUseCost(Convert.ToInt32(gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.useamount].Value));

                // 합계 = 사용금액 + 관리비
                gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.totalcost].Value
                    = Convert.ToInt32(gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.usecost].Value) 
                    + Convert.ToInt32(gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.admexpcost].Value);

                // 차액
                gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.cost_diff].Value                               // 차액
                    = (Convert.ToInt32(gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.cost_diff_pre].Value)   // = (전월차액 + 납입금)
                    + Convert.ToInt32(gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.cost_pay].Value))        // 
                    - Convert.ToInt32(gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.totalcost].Value)        // - (합계
                    ;

                // 합계 계산
                _CalcAdmExpSum();

            }
            catch(Exception ex)
            {
                throw ex;
            }

            // 함수 포인터 형식으로 넘기려면 리턴타입 void 가 안되므로 설정된 값이다. 리턴 값에 특별한 의미는 없다.
            return true;
        }

        #endregion

        #region Public

        /// <summary>
        /// 관리비 저장
        /// </summary>
        public void SaveAdmExp(bool select)
        {
            /* 변경사항 체크 -> 저장 시 조회 하지 않도록 하기 위해 파라미터 추가
             * true  : 조회
             * false : 미 조회
             */

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
                Util.NumComma(saveDT, i, (int)Common.AdmExp.premonth  , false); // 전월지침
                Util.NumComma(saveDT, i, (int)Common.AdmExp.nowmonth  , false); // 당월지침
                Util.NumComma(saveDT, i, (int)Common.AdmExp.useamount , false); // 사용량
                Util.NumComma(saveDT, i, (int)Common.AdmExp.usecost   , false); // 사용금액
                Util.NumComma(saveDT, i, (int)Common.AdmExp.admexpcost, false); // 관리비
                Util.NumComma(saveDT, i, (int)Common.AdmExp.totalcost , false); // 합계
            }

            // 데이터 저장
            int saveResult = AdmExpQuery.SaveAdmExpInfo(saveDT);

            // 성공, 실패 여부 메시지 출력
            Util.MessageSaveResult(saveResult);
            
            // 저장 성공 시 그리드 데이터 비운다
            if (saveResult > 0)
            {
                // 성공 시 테이블을 비운다
                /* 
                 * [버그] AcceptChanges()는 프로그램 종료단계에서 저장 시 잘못된 인덱스 참조 오류가 발생.
                 * 그리드 이벤트 관련 문제 인듯 한데 정확한 원인은 확인 안됨.
                 * 
                 * 어차피 저장 후 새로 조회하면 되므로 성공적으로 저장된 경우에 한해 비운다.
                 */
                Global.admExpDT = null;
            }

            // 저장 후 결과 메시지 출력
            //Util.MessageSaveResult(AdmExpQuery.SaveAdmExpInfo(saveDT));

            // 변경사항 커밋
            Global.admExpDT = null; // 이미 저장은 끝났고, 
            //Global.admExpDT.AcceptChanges(); [버그수정] 창 닫으면서 저장 시 수행 후 잘못된 인덱스 참조 오류 발생.

            // 조회
            if(select)
                SelectAdmExp(false);    // false : 조회 완료 메시지 출력 안함.
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

            // [버그수정] 조회 전 기존내용 초기화
            // 조회된 상태 -> 새로 생성 조회 되는 경우 그리드 헤더가 설정 안되는 문제 + 색상 적용 오류 문제 수정.
            // ----------------------------------------------------------------------------------------------------
            gridAdmExp.DataSource = null;
            Init_GridAdmExp();
            // ----------------------------------------------------------------------------------------------------

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
            gridAdmExp.ShowRowHighlight = false;
            Global.admExpDT.Rows.Add(new object[] { "", "합계", "", "", "", "", "", "", "", "", "9999" });

            // 합계 계산
            _CalcAdmExpSum();

            // 콤마 추가
            //NumCommaAll(true);

            // 변경사항 커밋
            Global.admExpDT.AcceptChanges();

            gridAdmExp.ShowRowHighlight = true;

            // 당월 사용량 입력 가능하도록 준비
            gridAdmExp.Focus();
            gridAdmExp.CurrentCell = gridAdmExp.Rows[0].Cells[(int)Common.AdmExp.nowmonth];
            
        }

        #endregion

        #region EVENTS

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
            // 그리드 행 표시 설정
            gridAdmExp.ShowRowHighlight = chkRowHighlight.Checked;
                            
            // 조회 전 이면 실행하지 않는다.
            if (gridAdmExp.Rows.Count == 0) return;

            // 그리드 색상 설정 재적용
            gridAdmExp.RefreshCellStyle();

            // 당월 사용량 입력 가능하도록 준비
            int curRow = gridAdmExp.CurrentCell.RowIndex;
            
            // 그리드 포커스 설정
            gridAdmExp.Focus();
            gridAdmExp.CurrentCell = gridAdmExp.Rows[curRow].Cells[(int)Common.AdmExp.nowmonth];
        }

        #endregion

    }
}
