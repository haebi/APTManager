using System;
using System.Data;
using System.Windows.Forms;

namespace APTManager
{
    public partial class frmHomeInfo : Form
    {
        public frmHomeInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 폼 로드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicHomeInfo_Load(object sender, EventArgs e)
        {
            // 그리드 헤더, 컬럼 설정
            gridHomeInfo.Columns.Clear();
            Util.setColumnHeader(gridHomeInfo, "home", "세대");
            Util.setColumnHeader(gridHomeInfo, "name", "세대주");
            Util.setColumnHeader(gridHomeInfo, "ordernum", "정렬순서");

            // 세대정보 조회
            gridHomeInfo.DataSource = DB.getHomeInfo();

            gridHomeInfo.AllowUserToAddRows = false;    // Row 자동생성 금지
            Util.lockColumn(gridHomeInfo, 0);           // 컬럼 잠금 설정
            Util.hideColumn(gridHomeInfo, 2);           // 컬럼 숨김
        }

        /// <summary>
        /// 변경 내용 저장 및 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 마지막 조회 후 변경된 행만 가져온다
            DataTable saveDT = Global.homeInfoDT.GetChanges();

            // 저장 대상이 없으면 그냥 닫는다
            if (saveDT == null || saveDT.Rows.Count == 0)
            {
                MessageBox.Show("변경 된 내용이 없습니다");
                return;
            }

            // 저장
            int result = DB.saveHomeInfo(saveDT);

            // 결과 메시지
            Util.messageSaveResult(result);

            // 성공 시 창을 닫는다
            if (result > 0)
                Close();
        }
    }
}
