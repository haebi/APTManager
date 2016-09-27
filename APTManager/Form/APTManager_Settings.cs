using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APTManager
{
    public partial class APTManager_Settings : Form
    {
        public APTManager_Settings()
        {
            InitializeComponent();
        }

        private void APTManager_Settings_Load(object sender, EventArgs e)
        {
            // 그리드 헤더, 컬럼 설정
            gridCommonCode.Columns.Clear();

            Util.SetColumnHeader(gridCommonCode, Common.GetName(Common.ComCode.comgroup ), "코드그룹");
            Util.SetColumnHeader(gridCommonCode, Common.GetName(Common.ComCode.comcode  ), "코드"    );
            Util.SetColumnHeader(gridCommonCode, Common.GetName(Common.ComCode.comvalue ), "값"      );
            Util.SetColumnHeader(gridCommonCode, Common.GetName(Common.ComCode.comremark), "비고"    );

            // 공통코드 조회
            gridCommonCode.DataSource = DB.GetComCode();

            gridCommonCode.AllowUserToAddRows = false;    // Row 자동생성 금지
            Util.LockColumn(gridCommonCode, (int)Common.ComCode.comgroup);  // 컬럼 잠금 설정
            Util.LockColumn(gridCommonCode, (int)Common.ComCode.comcode );  // 컬럼 잠금 설정
        }

        /// <summary>
        /// 공통코드 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 마지막 조회 후 변경된 행만 가져온다
            DataTable saveDT = Global.comcodeDT.GetChanges();

            // 저장 대상이 없으면 그냥 닫는다
            if (saveDT == null || saveDT.Rows.Count == 0)
            {
                MessageBox.Show("변경 된 내용이 없습니다");
                return;
            }

            // 저장
            int result = DB.SaveComCode(saveDT);

            // 결과 메시지
            Util.MessageSaveResult(result);

            // 성공 시 창을 닫는다
            if (result > 0)
                Close();
        }
    }
}
