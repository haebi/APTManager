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
        /// 컬럼을 읽기전용으로 설정합니다.
        /// </summary>
        /// <param name="index"></param>
        public static void lockColumn(DataGridView grid, int index)
        {
            grid.Columns[index].ReadOnly = true;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            grid.Columns[index].DefaultCellStyle = style;
        }

        /// <summary>
        /// 컬럼을 숨깁니다.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="index"></param>
        public static void hideColumn(DataGridView grid, int index)
        {
            grid.Columns[index].Visible = false;
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

        /// <summary>
        /// 저장 결과 메시지 팝업
        /// </summary>
        /// <param name="result"></param>
        public static void messageSaveResult(int result)
        {
            switch (result)
            {
                case 0:
                    MessageBox.Show("변경 된 내용이 없습니다");
                    break;
                case -1:
                    MessageBox.Show("데이터 저장 중 오류 발생");
                    break;
                default:
                    MessageBox.Show("저장 완료");
                    break;
            }
        }

    }
}
