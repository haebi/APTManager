using System;
using System.Windows.Forms;

using Haebi.Util;

using APTManager.Query;

namespace APTManager.SubForm
{
    public partial class PayManagement : UserControl
    {
        public PayManagement()
        {
            InitializeComponent();
        }

        private void PayManagement_Load(object sender, EventArgs e)
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
            gridPayment.AllowUserToAddRows  = false;    // Row 자동생성 금지
            gridPayment.RowHeadersVisible   = false;    // 로우 헤더 숨김
            gridPayment.Columns.Clear();

            // 그리드 컬럼 설정
            // colname / colheadertext / alignheader / aligncell / lock / hide
            gridPayment.SetColumn("yyyymm"      , "년월"    , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridPayment.SetColumn("home"        , "세대"    , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridPayment.SetColumn("name"        , "세대주"  , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, true , false);
            gridPayment.SetColumn("ordernum"    , "정렬순서", DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight , true , true );
            gridPayment.SetColumn("admexpcost"  , "관리비"  , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight , false, false);
            gridPayment.SetColumn("pay"         , "납입금"  , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight , false, false);
            gridPayment.SetColumn("prepay"      , "선납금"  , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight , false, false);
            gridPayment.SetColumn("nonpay"      , "미납금"  , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight , false, false);
            gridPayment.SetColumn("totalcost"   , "차액"    , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight , true , false);
            gridPayment.SetColumn("remark"      , "비고"    , DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, false, false);

            // 컬럼 정렬기능 비활성화
            gridPayment.AllowColumnSort(false);

            // 그리드 선택 줄 표시강조 기능 ON/OFF
            // 이 기능 사용시 Enter 로 다음 줄 넘어가는데 시간이 조금 더 걸린다. (미 사용과 비교시)
            gridPayment.AllowRowHighlight = true;
            chkRowHighlight.Checked = true;

            // 더블 버퍼링 설정 (로우 하이라이트 표시하는데 너무 오래 걸리는 관계로 설정)
            gridPayment.SetDoubleBuffer = true;
        }

        /// <summary>
        /// 관리비 조회
        /// </summary>
        /// <param name="yyyymm"></param>
        public void SelectPayment(bool msgShow)
        {
            // 공통코드 데이터 로드 Global.comcodeDT
            ComCodeQuery.GetComCode();

            /*
             * 1. 해당 월의 데이터가 있으면 조회한다.
             * 2. 데이터가 없는 경우 새로 양식을 생성한다.
             * */

            // 현재년월 데이터 조회
            gridPayment.DataSource = PaymentQuery.GetPaymentInfo(Global.YYYYMM);

            // 저장된 내용이 없으면 빈 셀 출력
            if (Global.PaymentDT.Rows.Count == 0)
            {
                // 더미 데이터 생성
                if (PaymentQuery.CreatePaymentInfo(Global.YYYYMM) > 0)
                {
                    HBMessageBox.Show("데이터 생성 완료", "납입금 조회");
                }

                // 저장된 데이터 불러오기
                gridPayment.DataSource = PaymentQuery.GetPaymentInfo(Global.YYYYMM);

                if(Global.PaymentDT.Rows.Count == 0)
                {
                    HBMessageBox.Show("관리비 데이터가 존재하지 않습니다.");
                    return;
                }
            }
            else
            {
                if (msgShow)
                    HBMessageBox.Show("조회 완료", "납입금 조회");
            }
        }


    }
}
