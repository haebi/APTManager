using System.Data;
using System.Data.SQLite;

namespace APTManager.Query
{
    class PaymentQuery
    {

        /// <summary>
        /// 납입금 조회
        /// </summary>
        /// <param name="yyyymm"></param>
        /// <returns></returns>
        public static DataTable GetPaymentInfo(string yyyymm)
        {
            Global.PaymentDT = null;

            string sql = string.Format("SELECT yyyymm"
                                     + "     , home"
                                     + "     , name"
                                     + "     , ordernum"
                                     + "     , pay"
                                     + "     , admexpcost"
                                     + "     , prepay"
                                     + "     , nonpay"
                                     + "     , totalcost"
                                     + "     , remark"
                                     + "  FROM payment where yyyymm = '{0}'"
                                     + " ORDER BY ordernum"
                                     , yyyymm);

            Global.PaymentDT = DB.ExecuteQuery(new SQLiteConnection(DB.dbConn), sql);

            Global.PaymentDT.AcceptChanges();

            return Global.PaymentDT;
        }

        /// <summary>
        /// 납입금 양식 생성(신규)
        /// </summary>
        /// <param name="yyyymm"></param>
        /// <returns></returns>
        public static int CreatePaymentInfo(string yyyymm)
        {
            string sql = string.Format("INSERT INTO payment "
                                            + "SELECT b.yyyymm "
                                                + " , b.home"
                                                + " , b.name"
                                                + " , b.ordernum"
                                                + " , '0' "
                                                + " , b.totalcost "
                                                + " , '0' "
                                                + " , '0' "
                                                + " , '0' "
                                                + " , '' "
                                                + " from admexp b"
                                                + " LEFT OUTER JOIN admexp a ON a.home = b.home AND a.yyyymm = '{0}'"
                                                , yyyymm);

            return DB.ExecuteNonQuery(new SQLiteConnection(DB.dbConn), sql);
        }

    }
}
