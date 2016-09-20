using System;
using System.Data;
using System.Data.SQLite;

namespace APTManager
{
    public static class DB
    {
        // 데이터베이스 파일
        private const string dbConn = @"Data Source=aptmanager.db";

        /// <summary>
        /// 세대주 정보 조회
        /// </summary>
        /// <returns>세대주 목록</returns>
        public static DataTable getHomeInfo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("home");
            dt.Columns.Add("name");
            dt.Columns.Add("ordernum");

            using (SQLiteConnection conn = new SQLiteConnection(dbConn))
            {
                conn.Open();
                string sql = "SELECT home"
                                + ", name"
                                + ", ordernum"
                                + " FROM homeinfo ORDER BY ordernum";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dt.Rows.Add(new object[] { reader["home"], reader["name"], reader["ordernum"] });
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
            string sql;
            SQLiteCommand cmd;
            int result = 0;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbConn))
                {
                    conn.Open();

                    // 저장 대상만큼 반복 수행
                    for (int i = 0; i < pDT.Rows.Count; i++)
                    {
                        sql = string.Format("UPDATE homeinfo "
                                            +"  SET name='{0}' "
                                            +"WHERE home='{1}' "
                                            , pDT.Rows[i][(int)Common.HomeInfo.name].ToString()
                                            , pDT.Rows[i][(int)Common.HomeInfo.home].ToString() );
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
            dt.Columns.Add("ordernum");

            using (SQLiteConnection conn = new SQLiteConnection(dbConn))
            {
                conn.Open();
                string sql = string.Format("SELECT yyyymm"
                                            + " , home"
                                            + " , name"
                                            + " , premonth"
                                            + " , nowmonth"
                                            + " , useamount"
                                            + " , usecost"
                                            + " , admexpcost"
                                            + " , totalcost"
                                            + " , remark"
                                            + " , ordernum"
                                            + " FROM admexp where yyyymm = '{0}'"
                                            + " ORDER BY ordernum"
                                            , yyyymm );

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
                                            , reader["remark"]
                                            , reader["ordernum"] });
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
        /// <param name="pDT"></param>
        /// <param name="yyyymm"></param>
        /// <returns></returns>
        public static int createAdmExpInfo(string yyyymm)
        {
            string sql;
            SQLiteCommand cmd;
            int result = 0;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbConn))
                {
                    conn.Open();

                    // Convert Datetime Format for get -1 Month in SQLite
                    // 2016-10-01 00:00:00
                    string preDate = string.Format("{0}-{1}-01 {2}", yyyymm.Substring(0, 4), yyyymm.Substring(4, 2), "00:00:00");

                    sql = string.Format("INSERT INTO admexp "
                        + "SELECT '{0}'"
                            + " , b.home"
                            + " , b.name"
                            + " , IFNULL((SELECT nowmonth from admexp c WHERE c.yyyymm = strftime(\"%Y%m\", '{1}', '-1 month') AND c.home = b.home), 0)"
                            + " , ''"
                            + " , ''"
                            + " , ''"
                            + " , ''"
                            + " , ''"
                            + " , ''"
                            + " , b.ordernum"
                            + " from homeinfo b"
                            + " LEFT OUTER JOIN admexp a ON a.home = b.home AND a.yyyymm = '{2}'"
                            , yyyymm
                            , preDate
                            , yyyymm );

                    cmd = new SQLiteCommand(sql, conn);
                    result += cmd.ExecuteNonQuery();
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
        /// 관리비 양식 저장(업데이트)
        /// </summary>
        /// <param name="pDT"></param>
        /// <returns></returns>
        public static int saveAdmExpInfo(DataTable pDT)
        {
            string sql;
            SQLiteCommand cmd;
            int result = 0;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbConn))
                {
                    conn.Open();

                    // 저장 대상만큼 반복 수행
                    for (int i = 0; i < pDT.Rows.Count; i++)
                    {
                        sql = string.Format("UPDATE admexp SET"
                                            + "  name       = '{0}'"
                                            + ", premonth   = '{1}'"
                                            + ", nowmonth   = '{2}'"
                                            + ", useamount  = '{3}'"
                                            + ", usecost    = '{4}'"
                                            + ", admexpcost = '{5}'"
                                            + ", totalcost  = '{6}'"
                                            + ", remark     = '{7}'"
                                            + ", ordernum   = '{8}'"
                                            + " WHERE yyyymm = '{9}'"
                                            + " AND home = '{10}'"
                                            , pDT.Rows[i][(int)Common.AdmExp.name].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.premonth].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.nowmonth].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.useamount].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.usecost].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.admexpcost].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.totalcost].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.remark].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.ordernum].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.yyyymm].ToString()
                                            , pDT.Rows[i][(int)Common.AdmExp.home].ToString() );

                        cmd = new SQLiteCommand(sql, conn);
                        result += cmd.ExecuteNonQuery();
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
        /// 현재 세대주 정보를 반영
        /// </summary>
        /// <returns></returns>
        public static int updateAdmExpHomeInfo(string yyyymm)
        {
            string sql;
            SQLiteCommand cmd;
            int result = 0;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbConn))
                {
                    conn.Open();

                    sql = string.Format(" UPDATE admexp "
                                        + " SET name = (SELECT homeinfo.name FROM homeinfo WHERE homeinfo.home = admexp.home) "
                                        + " WHERE yyyymm = '{0}' "
                                        , yyyymm);
                    cmd = new SQLiteCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // 저장 실패
                return -1;
            }

            return result;
        }

    }
}

