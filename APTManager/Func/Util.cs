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
        public static void SetColumnHeader(DataGridView grid, string ColumnName, string HeaderText)
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
        public static void LockColumn(DataGridView grid, int index)
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
        public static void LockRow(DataGridView grid, int index)
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
        public static void LockCell(DataGridView grid, int row, int col)
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
        public static void HideColumn(DataGridView grid, int index)
        {
            grid.Columns[index].Visible = false;
        }

        /// <summary>
        /// 컬럼 정렬기능을 설정합니다.
        /// </summary>
        /// <param name="grid"></param>
        public static void SortColumn(DataGridView grid, int index, bool flag)
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
        public static void CalcCell(DataGridView grid, int index1, int index2, int resultIndex, Common.Calc calc)
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
                        int preMonth = Convert.ToInt32(grid.Rows[curRow].Cells[index2].Value.ToString().Replace(",", ""));
                        int nowMonth = Convert.ToInt32(grid.Rows[curRow].Cells[index1].Value.ToString().Replace(",", ""));

                        grid.Rows[curRow].Cells[resultIndex].Value = nowMonth - preMonth;
                        break;

                    // 셀 덧셈
                    case Common.Calc.Add:
                        int useCost     = Convert.ToInt32(grid.Rows[curRow].Cells[index1].Value.ToString().Replace(",", ""));
                        int admExpCost  = Convert.ToInt32(grid.Rows[curRow].Cells[index2].Value.ToString().Replace(",", ""));

                        grid.Rows[curRow].Cells[resultIndex].Value = useCost + admExpCost;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 그리드 텍스트 정렬 방향
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="index"></param>
        /// <param name="align"></param>
        public static void AlignCell(DataGridView grid, int index,  Common.GridAlign align)
        {
            switch (align)
            {
                case Common.GridAlign.Center:
                    grid.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;

                case Common.GridAlign.Left:
                    grid.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    break;

                case Common.GridAlign.Right:
                    grid.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 그리드 헤더 텍스트 정렬 방향
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="index"></param>
        /// <param name="align"></param>
        public static void AlignCellHeader(DataGridView grid, int index, Common.GridAlign align)
        {
            switch (align)
            {
                case Common.GridAlign.Center:
                    grid.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;

                case Common.GridAlign.Left:
                    grid.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    break;

                case Common.GridAlign.Right:
                    grid.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 그리드 로우 색상 표시
        /// </summary>
        /// <param name="CurRowIndex"></param>
        public static void SetHighlightStyle(DataGridView grid, int CurRowIndex)
        {
            // 선택 라인 색상 표시
            DataGridViewCellStyle HighlightStyle = new DataGridViewCellStyle();
            HighlightStyle.BackColor = System.Drawing.Color.LightYellow;

            try
            {
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    grid.Rows[CurRowIndex].Cells[i].Style.ApplyStyle(HighlightStyle);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : [Util.SetHighlightStyle]" 
                    + Environment.NewLine + ex.ToString());
            }
        }

        /// <summary>
        /// 그리드 로우 기본 스타일로 되돌린다
        /// </summary>
        /// <param name="PrevRowIndex"></param>
        public static void SetDefaultStyle(DataGridView grid, int PrevRowIndex)
        {
            // 스타일 색상 설정
            DataGridViewCellStyle LockStyle = new DataGridViewCellStyle();
            LockStyle.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);

            DataGridViewCellStyle NormalStyle = new DataGridViewCellStyle();
            NormalStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            try
            {
                // 원상복귀
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    // 읽기전용 셀의 경우 색상이 다르기 때문에 복원을 위해 셀 특성을 구분해야 한다.
                    if (!grid.Columns[i].ReadOnly)
                    {
                        // 읽기전용 이 아닌 경우
                        grid.Rows[PrevRowIndex].Cells[i].Style.ApplyStyle(NormalStyle);
                    }
                    else
                    {
                        // 읽기전용 속성인 경우
                        grid.Rows[PrevRowIndex].Cells[i].Style.ApplyStyle(LockStyle);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : [Util.SetDefaultStyle]"
                    + Environment.NewLine + ex.ToString());
            }
        }

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
        public static void AddNumComma(DataTable dt, int iRow, int iCol)
        {
            //Global.admExpDT.Rows[i][7] = Convert.ToUInt32(Global.admExpDT.Rows[i][7]).ToString("N0");
            //Global.admExpDT.Rows[i][7] = string.Format("{0:n0}", Convert.ToUInt64(Global.admExpDT.Rows[i][7]));

            dt.Rows[iRow][iCol] = string.Format("{0:n0}", Convert.ToUInt64(dt.Rows[iRow][iCol].ToString().Replace(",", "")));
        }

        /// <summary>
        /// 콤마를 제거합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="iRow"></param>
        /// <param name="iCol"></param>
        public static void DelNumComma(DataTable dt, int iRow, int iCol)
        {
            dt.Rows[iRow][iCol] = dt.Rows[iRow][iCol].ToString().Replace(",", "");
        }

        /// <summary>
        /// 그리드 컬럼 설정
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="ColIndex"></param>
        /// <param name="ColName"></param>
        /// <param name="ColText"></param>
        /// <param name="ColumnHeader"></param>
        /// <param name="Column"></param>
        /// <param name="Lock"></param>
        /// <param name="Hide"></param>
        public static void SetGridColumn(DataGridView grid, int ColIndex, string ColName, string ColText, Common.GridAlign ColumnHeader, Common.GridAlign Column, bool Lock, bool Hide)
        {
            Util.SetColumnHeader(grid, ColName, ColText);
            
            if (Lock) Util.LockColumn(grid, ColIndex);

            if (Hide) Util.HideColumn(grid, ColIndex);

            // 정렬은 맨 마지막에 해야만 한다... Lock 속성 먹으면 정렬이 틀어지는 문제가 있음.
            Util.AlignCellHeader(grid, ColIndex, ColumnHeader);
            Util.AlignCell(grid, ColIndex, Column);
        }

    }
}
