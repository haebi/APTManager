using System;
using System.Data;
using System.Data.SQLite;

namespace APTManager
{
    public static class DB
    {
        /// <summary>
        /// 세대주 정보 조회
        /// </summary>
        /// <returns>세대주 목록</returns>
        public static DataTable getHomeInfo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("home");
            dt.Columns.Add("name");

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

            Global.homeInfoDT = dt.Copy();
            Global.homeInfoDT.AcceptChanges();

            return Global.homeInfoDT;
        }

        /// <summary>
        /// 세대주 정보 저장
        /// </summary>
        /// <param name="pDT"></param>
        /// <returns></returns>
        public static int saveHomeInfo(DataTable pDT)
        {
            string dbConn;
            string sql;
            SQLiteCommand cmd;
            int result = 0;

            try
            {
                dbConn = @"Data Source=aptmanager.db";

                using (SQLiteConnection conn = new SQLiteConnection(dbConn))
                {
                    conn.Open();

                    // 저장 대상만큼 반복 수행
                    for (int i = 0; i < pDT.Rows.Count; i++)
                    {
                        sql = "UPDATE homeinfo SET name='" + pDT.Rows[i][1].ToString() + "' WHERE home='" + pDT.Rows[i][0].ToString() + "' ";
                        cmd = new SQLiteCommand(sql, conn);
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("저장 실패");
                return -1;
            }

            return result;
        }

        /// <summary>
        /// 관리비 조회
        /// </summary>
        /// <returns>세대주 목록</returns>
        public static DataTable getAdmExpInfo(string yyyymm)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("yyyymm");
            dt.Columns.Add("home");
            dt.Columns.Add("name");
            dt.Columns.Add("premonth");
            dt.Columns.Add("nowmonth");
            dt.Columns.Add("useamount");
            dt.Columns.Add("usecost");
            dt.Columns.Add("admexpcost");
            dt.Columns.Add("totalcost");
            dt.Columns.Add("remark");

            string dbConn = @"Data Source=aptmanager.db";

            using (SQLiteConnection conn = new SQLiteConnection(dbConn))
            {
                conn.Open();
                string sql = "SELECT yyyymm, home, name, premonth, nowmonth, useamount, usecost, admexpcost, totalcost, remark FROM admexp where yyyymm = '" + yyyymm + "'";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dt.Rows.Add(new object[] { reader["yyyymm"]
                                            , reader["home"]
                                            , reader["name"]
                                            , reader["premonth"]
                                            , reader["nowmonth"]
                                            , reader["useamount"]
                                            , reader["usecost"]
                                            , reader["admexpcost"]
                                            , reader["totalcost"]
                                            , reader["remark"] });
                }

                reader.Close();
            }

            Global.admExpDT = dt.Copy();
            Global.admExpDT.AcceptChanges();

            return Global.admExpDT;
        }

        /// <summary>
        /// 관리비 양식 조회
        /// </summary>
        /// <returns>세대주 목록</returns>
        public static DataTable getEmptyAdmExpInfo(string yyyymm)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("yyyymm");
            dt.Columns.Add("home");
            dt.Columns.Add("name");
            dt.Columns.Add("premonth");
            dt.Columns.Add("nowmonth");
            dt.Columns.Add("useamount");
            dt.Columns.Add("usecost");
            dt.Columns.Add("admexpcost");
            dt.Columns.Add("totalcost");
            dt.Columns.Add("remark");

            string dbConn = @"Data Source=aptmanager.db";

            using (SQLiteConnection conn = new SQLiteConnection(dbConn))
            {
                conn.Open();
                string sql = "SELECT a.yyyymm, b.home, b.name, a.premonth, a.nowmonth, a.useamount, a.usecost, a.admexpcost, a.totalcost, a.remark from homeinfo b LEFT OUTER JOIN admexp a ON a.home = b.home AND a.yyyymm = '" + yyyymm + "'";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dt.Rows.Add(new object[] { yyyymm, reader["home"], reader["name"] });
                }

                reader.Close();
            }

            Global.admExpDT = dt.Copy();
            Global.admExpDT.AcceptChanges();

            return Global.admExpDT;
        }

        /// <summary>
        /// 관리비 양식 생성(신규)
        /// </summary>
        /// <param name=""></param>
        public static int createAdmExpInfo(DataTable pDT)
        {
            string dbConn;
            string sql;
            SQLiteCommand cmd;
            int result = 0;

            try
            {
                dbConn = @"Data Source=aptmanager.db";

                using (SQLiteConnection conn = new SQLiteConnection(dbConn))
                {
                    conn.Open();

                    // 저장 대상만큼 반복 수행
                    for (int i = 0; i < pDT.Rows.Count; i++)
                    {
                        sql = "INSERT INTO admexp ("
                            + "  yyyymm"
                            + ", home"
                            + ", name"
                            + ", premonth"
                            + ", nowmonth"
                            + ", useamount"
                            + ", usecost"
                            + ", admexpcost"
                            + ", totalcost"
                            + ", remark) VALUES ("
                            + " '" + pDT.Rows[i][0].ToString() + "'"
                            + ",'" + pDT.Rows[i][1].ToString() + "'"
                            + ",'" + pDT.Rows[i][2].ToString() + "'"
                            + ",'" + pDT.Rows[i][3].ToString() + "'"
                            + ",'" + pDT.Rows[i][4].ToString() + "'"
                            + ",'" + pDT.Rows[i][5].ToString() + "'"
                            + ",'" + pDT.Rows[i][6].ToString() + "'"
                            + ",'" + pDT.Rows[i][7].ToString() + "'"
                            + ",'" + pDT.Rows[i][8].ToString() + "'"
                            + ",'" + pDT.Rows[i][9].ToString() + "')";
                        cmd = new SQLiteCommand(sql, conn);
                        result += cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("저장 실패");
                Console.WriteLine(ex.ToString());
                return -1;
            }

            return result;
        }

        /// <summary>
        /// 관리비 양식 저장(업데이트)
        /// </summary>
        /// <param name="pDT"></param>
        /// <returns></returns>
        public static int saveAdmExpInfo(DataTable pDT)
        {
            string dbConn;
            string sql;
            SQLiteCommand cmd;
            int result = 0;

            try
            {
                dbConn = @"Data Source=aptmanager.db";

                using (SQLiteConnection conn = new SQLiteConnection(dbConn))
                {
                    conn.Open();

                    // 저장 대상만큼 반복 수행
                    for (int i = 0; i < pDT.Rows.Count; i++)
                    {
                        sql = "UPDATE admexp SET"
                            + "  name       = '" + pDT.Rows[i][2].ToString() + "'"
                            + ", premonth   = '" + pDT.Rows[i][3].ToString() + "'"
                            + ", nowmonth   = '" + pDT.Rows[i][4].ToString() + "'"
                            + ", useamount  = '" + pDT.Rows[i][5].ToString() + "'"
                            + ", usecost    = '" + pDT.Rows[i][6].ToString() + "'"
                            + ", admexpcost = '" + pDT.Rows[i][7].ToString() + "'"
                            + ", totalcost  = '" + pDT.Rows[i][8].ToString() + "'"
                            + ", remark     = '" + pDT.Rows[i][9].ToString() + "'"
                            + "WHERE yyyymm = '" + pDT.Rows[i][0].ToString() + "'"
                            + "AND home = '" + pDT.Rows[i][1].ToString() + "'";
                        cmd = new SQLiteCommand(sql, conn);
                        result += cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("저장 실패");
                string exam = ex.ToString();
                return -1;
            }

            return result;
        }
    }
}

