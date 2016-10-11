using System.Data;
using System.Data.SQLite;

namespace APTManager.Query
{
    class ComCodeQuery
    {

        /// <summary>
        /// 공통코드 정보 조회
        /// </summary>
        /// <returns>세대주 목록</returns>
        public static DataTable GetComCode()
        {
            Global.comcodeDT = null;

            string sql = "SELECT comgroup"
                            + ", comcode"
                            + ", comname"
                            + ", comvalue"
                            + ", comremark"
                            + " FROM comcode ORDER BY comgroup, comcode";

            Global.comcodeDT = DB.ExecuteQuery(new SQLiteConnection(DB.dbConn), sql);

            Global.comcodeDT.AcceptChanges();

            return Global.comcodeDT;
        }


        /// <summary>
        /// 공통코드 저장
        /// </summary>
        /// <param name="pDT"></param>
        /// <returns></returns>
        public static int SaveComCode(DataTable pDT)
        {
            int result = 0;
            string sql;

            // 저장 대상만큼 반복 수행
            for (int i = 0; i < pDT.Rows.Count; i++)
            {
                sql = string.Format("UPDATE comcode "
                                    + "  SET comvalue  = '{0}' "
                                    + "    , comremark = '{1}' "
                                    + " WHERE comgroup = '{2}' "
                                    + "   AND comcode  = '{3}' "
                                    , pDT.Rows[i][(int)Common.ComCode.comvalue].ToString()
                                    , pDT.Rows[i][(int)Common.ComCode.comremark].ToString()
                                    , pDT.Rows[i][(int)Common.ComCode.comgroup].ToString()
                                    , pDT.Rows[i][(int)Common.ComCode.comcode].ToString());

                result += DB.ExecuteNonQuery(new SQLiteConnection(DB.dbConn), sql);
            }

            return result;
        }

        /// <summary>
        /// 공통코드 그룹 조회
        /// </summary>
        /// <returns></returns>
        public static DataTable GetComCodeGroup()
        {
            string sql = "SELECT comname"
                            + ", count(*) as comcount"
                            + " FROM comcode GROUP BY comname";

            return DB.ExecuteQuery(new SQLiteConnection(DB.dbConn), sql);
        }

    }
}
