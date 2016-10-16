using ClosedXML.Excel;
using System.Data;
using System.Diagnostics;
using System;

namespace APTManager
{
    public static class Util
    {

        /// <summary>
        /// 사용량 금액 자동계산
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetUseCost(int value)
        {
            DataRow[] rows = Global.comcodeDT.Select(string.Format("comgroup = '2' AND comcode = '{0}'", value));

            if (rows.Length == 0)
                return 0;

            return Convert.ToInt32(rows[0]["comvalue"]);
        }

        /// <summary>
        /// 아파트 명칭 가져온다
        /// </summary>
        /// <returns></returns>
        public static string GetAptName()
        {
            DataRow[] rows = Global.comcodeDT.Select("comgroup = '3' AND comcode = '1'");

            if (rows.Length == 0)
                return "XX";

            return rows[0]["comvalue"].ToString();
        }

        /// <summary>
        /// 엑셀 출력
        /// </summary>
        public static void CallExcel(DataTable pDT)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(pDT, "WorksheetName");
                wb.SaveAs("file.xlsx");
            }

            Process.Start("file.xlsx");
        }

        /// <summary>
        /// 저장 결과 메시지 팝업
        /// </summary>
        /// <param name="result"></param>
        public static void MessageSaveResult(int result)
        {
            switch (result)
            {
                case 0:
                    Haebi.Util.HBMessageBox.Show("변경 된 내용이 없습니다");
                    break;
                case -1:
                    Haebi.Util.HBMessageBox.Show("데이터 저장 중 오류 발생");
                    break;
                default:
                    Haebi.Util.HBMessageBox.Show("저장 완료");
                    break;
            }
        }
        
        /// <summary>
        /// 3 자릿 수 마다 콤마를 추가합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="iRow"></param>
        /// <param name="iCol"></param>
        /// <param name="flag"></param>
        public static void NumComma(DataTable dt, int iRow, int iCol, bool flag)
        {
            //Global.admExpDT.Rows[i][7] = Convert.ToUInt32(Global.admExpDT.Rows[i][7]).ToString("N0");
            //Global.admExpDT.Rows[i][7] = string.Format("{0:n0}", Convert.ToUInt64(Global.admExpDT.Rows[i][7]));

            if(flag)
                dt.Rows[iRow][iCol] = string.Format("{0:n0}", Convert.ToInt64(dt.Rows[iRow][iCol].ToString().Replace(",", "")));
            else
                dt.Rows[iRow][iCol] = dt.Rows[iRow][iCol].ToString().Replace(",", "");
        }

    }
}
