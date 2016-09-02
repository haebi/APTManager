using System;
using System.Data;
using System.Data.SQLite;
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

            gridHomeInfo.Columns.Clear();
            Util.setColumnHeader(gridHomeInfo, "home", "세대");
            Util.setColumnHeader(gridHomeInfo, "name", "세대주");

            Global.homeInfoDT = DB.getBasicInfo();
            Global.homeInfoDT.AcceptChanges();

            gridHomeInfo.DataSource = Global.homeInfoDT;

            gridHomeInfo.AllowUserToAddRows = false;      // Row 자동생성 금지
        }

        /// <summary>
        /// 변경 내용 저장 및 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string dbConn;
            string sql;
            SQLiteCommand cmd;

            try
            {
                dbConn = @"Data Source=aptmanager.db";

                using (SQLiteConnection conn = new SQLiteConnection(dbConn))
                {
                    conn.Open();

                    // 마지막 조회 후 변경된 행만 가져온다.
                    DataTable saveDT = Global.homeInfoDT.GetChanges();

                    // 저장 대상이 없으면 그냥 닫는다.
                    if (saveDT == null || saveDT.Rows.Count == 0)
                    {
                        MessageBox.Show("변경 된 내용이 없습니다");
                        return;
                    }

                    // 저장 대상만큼 반복 수행
                    for (int i = 0; i < saveDT.Rows.Count; i++)
                    {
                        sql = "UPDATE homeinfo SET name='" + saveDT.Rows[i][1].ToString() + "' WHERE home='" + saveDT.Rows[i][0].ToString() + "' ";
                        cmd = new SQLiteCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("저장 완료");

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장 실패");
            }
        }
    }
}
