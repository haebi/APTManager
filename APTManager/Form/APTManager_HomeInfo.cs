using System;
using System.Data;
using System.Windows.Forms;

using Haebi.Util;
using APTManager.Query;

namespace APTManager
{
    public partial class APTManager_HomeInfo : Form
    {
        public APTManager_HomeInfo()
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
            // 창 스타일 설정
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // 그리드 헤더, 컬럼 설정
            gridHomeInfo.AllowUserToAddRows = false;    // Row 자동생성 금지
            gridHomeInfo.RowHeadersVisible = false;     // 로우 헤더 숨김

            gridHomeInfo.Columns.Clear();

            Util.SetColumnHeader(gridHomeInfo, Common.GetName(Common.HomeInfo.home    ), "세대"    );
            Util.SetColumnHeader(gridHomeInfo, Common.GetName(Common.HomeInfo.name    ), "세대주"  );
            Util.SetColumnHeader(gridHomeInfo, Common.GetName(Common.HomeInfo.ordernum), "정렬순서");

            // 세대정보 조회
            gridHomeInfo.DataSource = HomeInfoQuery.GetHomeInfo();
            
            Util.LockColumn(gridHomeInfo, 0);           // 컬럼 잠금 설정

            Util.HideColumn(gridHomeInfo, 2);           // 컬럼 숨김
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
                HBMessageBox.Show("변경 된 내용이 없습니다");
                return;
            }

            // 저장
            int result = HomeInfoQuery.SaveHomeInfo(saveDT);

            // 결과 메시지
            Util.MessageSaveResult(result);

            // 성공 시 창을 닫는다
            if (result > 0)
                Close();
        }
    }
}
