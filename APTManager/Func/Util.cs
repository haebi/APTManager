using ClosedXML.Excel;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace APTManager
{
    public static class Util
    {
        /// <summary>
        /// 컬럼 헤더 설정
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="ColumnName"></param>
        /// <param name="HeaderText"></param>
        public static void setColumnHeader(DataGridView grid, string ColumnName, string HeaderText)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = ColumnName;
            col.HeaderText = HeaderText;
            grid.Columns.Add(col);
        }

        /// <summary>
        /// 셀을 읽기전용으로 설정합니다.
        /// </summary>
        /// <param name="index"></param>
        public static void lockCell(DataGridView grid, int index)
        {
            grid.Columns[index].ReadOnly = true;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            grid.Columns[index].DefaultCellStyle = style;
        }

        /// <summary>
        /// 엑셀 출력
        /// </summary>
        public static void callExcel(DataTable pDT)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(pDT, "WorksheetName");
                wb.SaveAs("file.xlsx");
            }

            Process.Start("file.xlsx");
        }
    }
}
