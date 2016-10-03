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
        /// 관리비 조회
        /// </summary>
        /// <param name="yyyymm"></param>
        private void SelectAdmExp(string yyyymm, bool msgShow)
        {
            // 년월 표시를 현재 조회하는 데이터로 변경
            dtpAdmExp.Value = Convert.ToDateTime(string.Format("{0}-{1}", yyyymm.Substring(0, 4), yyyymm.Substring(4, 2)));

            Global.YYYYMM = yyyymm;

            // 조회
            aptManager_AdmExp1.SelectAdmExp(true);

            // 버튼 활성화
            btnExcel.Enabled        = true;
            btnPrintAdmExp.Enabled  = true;
            btnSaveAdmExp.Enabled   = true;
        }
        
        /// <summary>
        /// 엑셀 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (Global.admExpDT == null 
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
            aptManager_AdmExp1.SaveAdmExp();
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
        /// 프로그램 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APTManager_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 변경 된 데이터 저장 여부 확인
            CheckUnsavedData();
        }



    }
}

