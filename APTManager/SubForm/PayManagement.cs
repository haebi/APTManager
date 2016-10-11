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
            gridPayment.AllowUserToAddRows = false;    // Row 자동생성 금지
            gridPayment.RowHeadersVisible = false;    // 로우 헤더 숨김
            gridPayment.Columns.Clear();

            // 컬럼 설정 시 코드 길이 줄이기 위해 설정함.
            Common.Payment yyyymm     = Common.Payment.yyyymm;
            Common.Payment home       = Common.Payment.home;
            Common.Payment name       = Common.Payment.name;
            Common.Payment ordernum   = Common.Payment.ordernum;
            Common.Payment pay        = Common.Payment.pay;
            Common.Payment admexpcost = Common.Payment.admexpcost;
            Common.Payment prepay     = Common.Payment.prepay;
            Common.Payment nonpay     = Common.Payment.nonpay;
            Common.Payment totalcost  = Common.Payment.totalcost;
            Common.Payment remark     = Common.Payment.remark;

            Common.GridAlign Align_Center   = Common.GridAlign.Center;
            Common.GridAlign Align_Right    = Common.GridAlign.Right;

            // 그리드 컬럼 설정
            // grid / index / colname / colheadertext / alignheader / aligncell / lock / hide
            Util.SetGridColumn(gridPayment, (int)yyyymm     , Common.GetName(yyyymm    ), "년월"     , Align_Center, Align_Center, true , false);
            Util.SetGridColumn(gridPayment, (int)home       , Common.GetName(home      ), "세대"     , Align_Center, Align_Center, true , false);
            Util.SetGridColumn(gridPayment, (int)name       , Common.GetName(name      ), "세대주"   , Align_Center, Align_Center, true , false);
            Util.SetGridColumn(gridPayment, (int)ordernum   , Common.GetName(ordernum  ), "정렬순서" , Align_Center, Align_Right , true , true );
            Util.SetGridColumn(gridPayment, (int)admexpcost , Common.GetName(admexpcost), "관리비"   , Align_Center, Align_Right , false, false);
            Util.SetGridColumn(gridPayment, (int)pay        , Common.GetName(pay       ), "납입금"   , Align_Center, Align_Right , false, false);
            Util.SetGridColumn(gridPayment, (int)prepay     , Common.GetName(prepay    ), "선납금"   , Align_Center, Align_Right , false, false);
            Util.SetGridColumn(gridPayment, (int)nonpay     , Common.GetName(nonpay    ), "미납금"   , Align_Center, Align_Right , false, false);
            Util.SetGridColumn(gridPayment, (int)totalcost  , Common.GetName(totalcost ), "차액"     , Align_Center, Align_Right , true , false);
            Util.SetGridColumn(gridPayment, (int)remark     , Common.GetName(remark    ), "비고"     , Align_Center, Align_Center, false, false);
                       
            // 컬럼 정렬기능 비활성화
            for (int i = 0; i < gridPayment.Columns.Count; i++)
            {
                Util.SortColumn(gridPayment, i, false);
            }

            // 그리드 선택 줄 표시강조 기능 ON/OFF
            // 이 기능 사용시 Enter 로 다음 줄 넘어가는데 시간이 조금 더 걸린다. (미 사용과 비교시)
            chkRowHighlight.Checked = true;

            // 더블 버퍼링 설정 (로우 하이라이트 표시하는데 너무 오래 걸리는 관계로 설정)
            //DoubleBuffered = true; // 현재 폼 더블버퍼링 유뮤 설정인데... 폼 자체가 갱신되는게 아니기에 별 의미 없다.
            Util.SetDoubleBuffer(gridPayment);
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
