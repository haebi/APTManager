using System.Data;
using System.Data.SQLite;

namespace APTManager.Query
{
    class HomeInfoQuery
    {

        /// <summary>
        /// 세대주 정보 조회
        /// </summary>
        /// <returns>세대주 목록</returns>
        public static DataTable GetHomeInfo()
        {
            Global.homeInfoDT = null;

            string sql = "SELECT home"
                            + ", name"
                            + ", ordernum"
                            + " FROM homeinfo ORDER BY ordernum";

            Global.homeInfoDT = DB.ExecuteQuery(new SQLiteConnection(DB.dbConn), sql);

            Global.homeInfoDT.AcceptChanges();

            return Global.homeInfoDT;
        }

        /// <summary>
        /// 세대주 정보 저장
        /// </summary>
        /// <param name="pDT"></param>
        /// <returns></returns>
        public static int SaveHomeInfo(DataTable pDT)
        {
            int result = 0;
            string sql;
            
            // 저장 대상만큼 반복 수행
            for (int i = 0; i < pDT.Rows.Count; i++)
            {
                // 커넥션을 반복문 밖에 두면 DB.ExecuteNonQuery() 에서 [개체의 현재 상태 때문에 작업이 유효하지 않습니다.] 오류가 발생한다.
                // ExecuteNonQuery 가 수행되면 커넥션의 상태가 바뀌는건가...? -_-;;
                //SQLiteConnection conn = new SQLiteConnection(DB.dbConn);

                sql = string.Format("UPDATE homeinfo "
                                   + "  SET name='{0}' "
                                   + "WHERE home='{1}' "
                                   , pDT.Rows[i][(int)Common.HomeInfo.name].ToString()
                                   , pDT.Rows[i][(int)Common.HomeInfo.home].ToString());

                result += DB.ExecuteNonQuery(new SQLiteConnection(DB.dbConn), sql); // conn 변수 대신 그냥 여기서 생성하면 되는군!! (^o^)=b
            }

            return result;
        }

    }
}
