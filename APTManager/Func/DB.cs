using System.Data;
using System.Data.SQLite;

namespace APTManager
{
    public static class DB
    {
        /// <summary>
        /// 세대주 기본정보 조회
        /// </summary>
        /// <returns>세대주 목록</returns>
        public static DataTable getBasicInfo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("호번");
            dt.Columns.Add("세대주");
            dt.Columns[0].ColumnName = "home";
            dt.Columns[1].ColumnName = "name";

            string dbConn = @"Data Source=aptmanager.db";

            using (SQLiteConnection conn = new SQLiteConnection(dbConn))
            {
                conn.Open();
                string sql = "SELECT home, name FROM homeinfo";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dt.Rows.Add(new object[] { reader["home"], reader["name"] });
                }

                reader.Close();
            }

            return dt;
        }

        /// <summary>
        /// 관리비 조회
        /// </summary>
        /// <returns>세대주 목록</returns>
        public static DataTable getManageFeeInfo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("호번");
            dt.Columns.Add("세대주");
            dt.Columns[0].ColumnName = "home";
            dt.Columns[1].ColumnName = "name";

            string dbConn = @"Data Source=aptmanager.db";

            using (SQLiteConnection conn = new SQLiteConnection(dbConn))
            {
                conn.Open();
                string sql = "SELECT * FROM homeinfo";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dt.Rows.Add(new object[] { reader["home"], reader["name"] });
                }

                reader.Close();
            }

            Global.manageFeeDT = dt.Copy();
            Global.manageFeeDT.AcceptChanges();

            return Global.manageFeeDT;
        }
    }
}
