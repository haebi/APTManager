using System.Data;
using System.Data.SQLite;

namespace APTManager.Query
{
    static class AdmExpQuery
    {

        /// <summary>
        /// 관리비 조회
        /// </summary>
        /// <param name="yyyymm"></param>
        /// <returns></returns>
        public static DataTable GetAdmExpInfo(string yyyymm)
        {
            Global.admExpDT = null;

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
                                            , yyyymm);

            Global.admExpDT = DB.ExecuteQuery(new SQLiteConnection(DB.dbConn), sql);

            Global.admExpDT.AcceptChanges();

            return Global.admExpDT;
        }

        /// <summary>
        /// 관리비 양식 생성(신규)
        /// </summary>
        /// <param name="yyyymm"></param>
        /// <returns></returns>
        public static int CreateAdmExpInfo(string yyyymm)
        {
            // Convert Datetime Format for get -1 Month in SQLite
            // 2016-10-01 00:00:00
            string preDate = string.Format("{0}-{1}-01 {2}", yyyymm.Substring(0, 4), yyyymm.Substring(4, 2), "00:00:00");

            string sql = string.Format("INSERT INTO admexp "
                                            + "SELECT '{0}'"
                                            + " , b.home"
                                            + " , b.name"
                                            + " , IFNULL((SELECT nowmonth from admexp c WHERE c.yyyymm = strftime(\"%Y%m\", '{1}', '-1 month') AND c.home = b.home), 0)"
                                            + " , ''"
                                            + " , ''"
                                            + " , ''"
                                            + " , (SELECT comvalue FROM comcode WHERE comgroup = 1 AND comcode = 1)"
                                            + " , (SELECT comvalue FROM comcode WHERE comgroup = 1 AND comcode = 1)"
                                            + " , ''"
                                            + " , b.ordernum"
                                            + " from homeinfo b"
                                            + " LEFT OUTER JOIN admexp a ON a.home = b.home AND a.yyyymm = '{2}'"
                                            , yyyymm
                                            , preDate
                                            , yyyymm);

            return DB.ExecuteNonQuery(new SQLiteConnection(DB.dbConn), sql);
        }

        /// <summary>
        /// 관리비 양식 저장(업데이트)
        /// </summary>
        /// <param name="pDT"></param>
        /// <returns></returns>
        public static int SaveAdmExpInfo(DataTable pDT)
        {
            int result = 0;
            string sql;

            // 저장 대상만큼 반복 수행
            for (int i = 0; i < pDT.Rows.Count; i++)
            {
                // 합계는 제외한다.
                if (pDT.Rows[i][(int)Common.AdmExp.home].Equals("합계"))
                    continue;

                sql = string.Format("UPDATE admexp SET"
                                       + "  name        = '{0}'"
                                       + ", premonth    = '{1}'"
                                       + ", nowmonth    = '{2}'"
                                       + ", useamount   = '{3}'"
                                       + ", usecost     = '{4}'"
                                       + ", admexpcost  = '{5}'"
                                       + ", totalcost   = '{6}'"
                                       + ", remark      = '{7}'"
                                       + ", ordernum    = '{8}'"
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
                                       , pDT.Rows[i][(int)Common.AdmExp.home].ToString());

                result += DB.ExecuteNonQuery(new SQLiteConnection(DB.dbConn), sql);
            }

            return result;
        }

        /// <summary>
        /// 현재 세대주 정보를 반영
        /// </summary>
        /// <param name="yyyymm"></param>
        /// <returns></returns>
        public static int UpdateAdmExpHomeInfo(string yyyymm)
        {
            string sql = string.Format(" UPDATE admexp "
                                        + " SET name = (SELECT homeinfo.name FROM homeinfo WHERE homeinfo.home = admexp.home) "
                                        + " WHERE yyyymm = '{0}' "
                                        , yyyymm);

            return DB.ExecuteNonQuery(new SQLiteConnection(DB.dbConn), sql);
        }

        /// <summary>
        /// 현재 관리비 정보를 반영
        /// </summary>
        /// <param name="yyyymm"></param>
        /// <returns></returns>
        public static int UpdateAdmExpCost(string yyyymm)
        {
            string sql = string.Format(" UPDATE admexp "
                                        + " SET admexpcost = (SELECT comcode.comvalue FROM comcode WHERE comcode.comgroup = 1 AND comcode.comcode = 1) "
                                        + "    , totalcost = usecost + (SELECT comcode.comvalue FROM comcode WHERE comcode.comgroup = 1 AND comcode.comcode = 1)"
                                        + " WHERE yyyymm = '{0}' "
                                        , yyyymm);

            return DB.ExecuteNonQuery(new SQLiteConnection(DB.dbConn), sql);
        }

        /// <summary>
        /// 전월 사용량 정보를 반영
        /// </summary>
        /// <param name="yyyymm"></param>
        /// <returns></returns>
        public static int UpdateAdmExpPreMonth(string yyyymm)
        {
            // Convert Datetime Format for get -1 Month in SQLite
            // 2016-10-01 00:00:00
            string preDate = string.Format("{0}-{1}-01 {2}", yyyymm.Substring(0, 4), yyyymm.Substring(4, 2), "00:00:00");

            string sql = string.Format(" UPDATE admexp "
                                        + " SET premonth = IFNULL((SELECT nowmonth from admexp c WHERE c.yyyymm = strftime(\"%Y%m\", '{0}', '-1 month') AND c.home = admexp.home), 0) "
                                        + " WHERE yyyymm = '{2}' "
                                        , preDate
                                        , preDate
                                        , yyyymm);

            return DB.ExecuteNonQuery(new SQLiteConnection(DB.dbConn), sql);
        }

    }
}
