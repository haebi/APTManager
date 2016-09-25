using ClosedXML.Excel;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System;

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
        /// 로우를 읽기전용으로 설정합니다.
        /// </summary>
        /// <param name="index"></param>
        public static void lockRow(DataGridView grid, int index)
        {
            grid.Rows[index].ReadOnly = true;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            grid.Rows[index].DefaultCellStyle = style;
        }

        /// <summary>
        /// 셀을 읽기전용으로 설정합니다.
        /// </summary>
        /// <param name="index"></param>
        public static void lockCell(DataGridView grid, int row, int col)
        {
            grid.Rows[row].Cells[col].ReadOnly = true;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            grid.Rows[row].Cells[col].Style = style;
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
        /// 컬럼 정렬기능을 설정합니다.
        /// </summary>
        /// <param name="grid"></param>
        public static void sortColumn(DataGridView grid, int index, bool flag)
        {
            grid.Columns[index].SortMode = flag ? 
                DataGridViewColumnSortMode.Automatic : // true - sortable
                DataGridViewColumnSortMode.NotSortable;  // false
        }

        /// <summary>
        /// 컬럼 자동계산
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        /// <param name="resultIndex"></param>
        /// <param name="calc"></param>
        public static void calcCell(DataGridView grid, int index1, int index2, int resultIndex, Common.Calc calc)
        {
            int curRow = grid.CurrentCell.RowIndex;
            int curCol = grid.CurrentCell.ColumnIndex;

            // 오류 회피용 try ~ catch 블록. -> regex 로 변경 예정.
            try
            {
                switch (calc)
                {
                    // 셀 뺄셈
                    case Common.Calc.Sub:
                        int preMonth = Convert.ToInt32(grid.Rows[curRow].Cells[index2].Value.ToString());
                        int nowMonth = Convert.ToInt32(grid.Rows[curRow].Cells[index1].Value.ToString());

                        grid.Rows[curRow].Cells[resultIndex].Value = nowMonth - preMonth;
                        break;

                    // 셀 덧셈
                    case Common.Calc.Add:
                        int useCost = Convert.ToInt32(grid.Rows[curRow].Cells[index1].Value.ToString());
                        int admExpCost = Convert.ToInt32(grid.Rows[curRow].Cells[index2].Value.ToString());

                        grid.Rows[curRow].Cells[resultIndex].Value = useCost + admExpCost;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex) { }
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
