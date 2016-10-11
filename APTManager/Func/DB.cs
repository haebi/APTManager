using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace APTManager
{
    public static class DB
    {
        // 데이터베이스 파일
        public static string dbConn = @"Data Source=aptmanager.db";

        /// <summary>
        /// Insert, Update, Delete 공통 메서드
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SQLiteConnection conn, string SQL)
        {
            SQLiteCommand cmd;
            int result = 0;

            try
            {
                conn.Open();

                cmd = new SQLiteCommand(SQL, conn);

                result += cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// Select 공통 메서드
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(SQLiteConnection conn, string SQL)
        {
            SQLiteCommand cmd;
            SQLiteDataReader reader;
            DataTable dt = new DataTable();
            bool addColumn = true;

            try
            {
                conn.Open();

                cmd = new SQLiteCommand(SQL, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    object[] objData = new object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (addColumn)
                            dt.Columns.Add(reader.GetName(i));

                        objData[i] = reader[i];
                    }

                    dt.Rows.Add(objData);

                    addColumn = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }

    }
}

