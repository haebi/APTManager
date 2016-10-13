using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Haebi.Util
{
    public class HBDataGridView : DataGridView
    {

        //==================================================
        // 전역 변수
        //==================================================

        private DataGridViewCellStyle NormalStyle;      // 일반 색상
        private DataGridViewCellStyle LockStyle;        // 잠금 색상
        private DataGridViewCellStyle HighlightStyle;   // 선택 색상

        private int PrevRowIndex;   // 이전 행 위치 (RowHighlight 기능, 이전 행의 색상 복원을 위해 필요하다)

        //==================================================
        // 열거형
        //==================================================

        /// <summary>
        /// 계산 종류
        /// </summary>
        public enum CalcType
        {
            Add = 0x1,
            Sub = 0x2,
        }

        /// <summary>
        /// 컬러 상태 종류
        /// </summary>
        public enum ColorState
        {
            Normal      = 0x1,
            Lock        = 0x2,
            Highlight   = 0x4,
        }

        //==================================================
        // 속성 정의
        //==================================================

        /// <summary>
        /// 데이터 소스를 가져오거나 설정에서 DataGridView 에 대한 데이터를 표시 합니다.
        /// </summary>
        [DefaultValue(false), Category("데이터"), Description("DataGridView 컨트롤의 데이터 소스를 나타냅니다.")]
        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                if (RowHighlight)
                {
                    /* 열 표시가 OnSelectionChanged 에서 수행되는데, 데이터 바인딩 시 행 갯수반큼 반복하면서 오류나는 경우가 있다.
                     * 그래서, 조회 직전에 잠깐 끄고, 조회 완료 후 다시 켜는 것으로 한다. 
                     */ 
                    RowHighlight    = false;
                    base.DataSource = value;
                    RowHighlight    = true;
                }
                else
                {
                    base.DataSource = value;
                }
            }
        }

        /// <summary>
        /// 현재 행 가이드 표시
        /// </summary>
        [DefaultValue(false), Category("동작"), Description("현재 행 가이드 표시여부")]
        public bool RowHighlight { get; set; }

        /// <summary>
        /// 컨트롤 그릴 때 더블 버퍼링 사용
        /// </summary>
        [DefaultValue(false), Category("동작"), Description("이 컨트롤에서 깜빡임을 줄이거나 방지하기 위해 보조 버퍼를 사용하여 화면을 다시 그려야 하는지 여부를 나타내는 값을 가져오거나 설정합니다.")]
        public bool SetDoubleBuffer
        {
            get { return DoubleBuffered;  }
            set { DoubleBuffered = value; }
        }
        
        //==================================================
        // 이벤트 오버라이드
        //==================================================
        
        /// <summary>
        /// 현재 선택이 변경될 때 발생합니다
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectionChanged(EventArgs e)
        {
            SetHighlightStyle();    // 현재 행 색상 적용
            SetDefaultStyle();      // 이전 행 색상 해제

            base.OnSelectionChanged(e);
        }

        //==================================================
        // 접근제한 메서드 private, protected
        //==================================================

        /// <summary>
        /// 배경색 설정 합니다.
        /// </summary>
        /// <param name="Red"></param>
        /// <param name="Green"></param>
        /// <param name="Blue"></param>
        /// <returns></returns>
        private DataGridViewCellStyle SetBackgroundColor(byte Red, byte Green, byte Blue)
        {
            try
            {
                DataGridViewCellStyle style
                    = new DataGridViewCellStyle();
                style.BackColor = Color.FromArgb(Red, Green, Blue);
                return style;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 그리드 행 기본색상 설정
        /// </summary>
        private void SetDefaultStyle()
        {
            if (!RowHighlight)
                return;

            if (PrevRowIndex == base.CurrentCell.RowIndex)
                return;

            try
            {
                for (int i = 0; i < base.Columns.Count; i++)
                {
                    if (!base.Columns[i].ReadOnly)
                        base.Rows[PrevRowIndex].Cells[i].Style.ApplyStyle(NormalStyle); // NormalStyle
                    else
                        base.Rows[PrevRowIndex].Cells[i].Style.ApplyStyle(LockStyle);   // LockStyle
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            PrevRowIndex = base.CurrentCell.RowIndex;
        }

        /// <summary>
        /// 그리드 현재 행 색상 설정
        /// </summary>
        /// <param name="CurRowIndex"></param>
        private void SetHighlightStyle()
        {
            if (!RowHighlight)
                return;

            try
            {
                for (int i = 0; i < base.Columns.Count; i++)
                {
                    base.Rows[base.CurrentCell.RowIndex].Cells[i].Style.ApplyStyle(HighlightStyle);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
        //==================================================
        // 공개 메서드 public
        //==================================================

        /// <summary>
        /// 생성자
        /// </summary>
        public HBDataGridView()
        {

        }

        /// <summary>
        /// 생성자, 초기 세팅
        /// </summary>
        /// <param name="container"></param>
        public HBDataGridView(IContainer container)
        {
            container.Add(this);

            LockStyle       = SetBackgroundColor(200, 200, 200);
            NormalStyle     = SetBackgroundColor(255, 255, 255);
            HighlightStyle  = SetBackgroundColor(255, 255, 224);

            PrevRowIndex    = 0;
        }
        
        /// <summary>
        /// 그리드 전체 색상설정 다시적용
        /// </summary>
        public void SetRefreshStyle()
        {
            try
            {
                for (int j = 0; j < base.Rows.Count; j++)
                {
                    for (int i = 0; i < base.Columns.Count; i++)
                    {
                        if (!base.Columns[i].ReadOnly)
                            base.Rows[j].Cells[i].Style.ApplyStyle(NormalStyle); // NormalStyle
                        else
                            base.Rows[j].Cells[i].Style.ApplyStyle(LockStyle);   // LockStyle
                    }
                }

                SetHighlightStyle();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            PrevRowIndex = base.CurrentCell.RowIndex;
        }
        
        /// <summary>
        /// 셀 상태 배경색을 지정합니다
        /// </summary>
        /// <param name="state"></param>
        /// <param name="Red"></param>
        /// <param name="Green"></param>
        /// <param name="Blue"></param>
        public void SetStateColorBackground(ColorState state, byte Red, byte Green, byte Blue)
        {
            try
            {
                switch (state)
                {
                    case ColorState.Normal:
                        NormalStyle = SetBackgroundColor(Red, Green, Blue);
                        break;

                    case ColorState.Lock:
                        LockStyle = SetBackgroundColor(Red, Green, Blue);
                        break;

                    case ColorState.Highlight:
                        HighlightStyle = SetBackgroundColor(Red, Green, Blue);
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
        /// 컬럼 정렬
        /// </summary>
        /// <param name="index"></param>
        /// <param name="align"></param>
        public void AlignColumnContent(int index, DataGridViewContentAlignment align)
        {
            base.Columns[index].DefaultCellStyle.Alignment = align;
        }

        /// <summary>
        /// 컬럼헤더 정렬
        /// </summary>
        /// <param name="index"></param>
        /// <param name="align"></param>
        public void AlignColumnHeader(int index, DataGridViewContentAlignment align)
        {
            base.Columns[index].HeaderCell.Style.Alignment = align;
        }

        /// <summary>
        /// 셀 계산
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Dest"></param>
        /// <param name="Col1"></param>
        /// <param name="Col2"></param>
        public void CalcCell(CalcType type, int Dest, int Col1, int Col2)
        {
            try
            {
                switch (type)
                {
                    case CalcType.Add:
                        base.Rows[base.CurrentCell.RowIndex].Cells[Dest].Value
                            = Convert.ToInt64(base.Rows[base.CurrentCell.RowIndex].Cells[Col1].Value)
                            + Convert.ToInt64(base.Rows[base.CurrentCell.RowIndex].Cells[Col2].Value);
                        break;

                    case CalcType.Sub:
                        base.Rows[base.CurrentCell.RowIndex].Cells[Dest].Value
                            = Convert.ToInt64(base.Rows[base.CurrentCell.RowIndex].Cells[Col1].Value)
                            - Convert.ToInt64(base.Rows[base.CurrentCell.RowIndex].Cells[Col2].Value);
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
        /// 컬럼을 숨깁니다.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="index"></param>
        public void HideColumn(int index, bool flag)
        {
            try
            {
                base.Columns[index].Visible = !flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 셀을 읽기전용으로 설정합니다.
        /// </summary>
        /// <param name="index"></param>
        public void LockCell(int row, int col, bool flag)
        {
            try
            {
                base.Rows[row].Cells[col].ReadOnly = flag;
                base.Rows[row].Cells[col].Style
                    = flag ? LockStyle : NormalStyle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 컬럼을 읽기전용으로 설정합니다.
        /// </summary>
        /// <param name="index"></param>
        public void LockColumn(int index, bool flag)
        {
            try
            {
                base.Columns[index].ReadOnly = flag;
                base.Columns[index].DefaultCellStyle
                    = flag ? LockStyle : NormalStyle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 로우를 읽기전용으로 설정합니다.
        /// </summary>
        /// <param name="index"></param>
        public void LockRow(int index, bool flag)
        {
            try
            {
                base.Rows[index].ReadOnly = flag;
                base.Rows[index].DefaultCellStyle
                    = flag ? LockStyle : NormalStyle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// 컬럼 설정
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="ColumnName"></param>
        /// <param name="HeaderText"></param>
        public void SetColumn(string ColumnName, string HeaderText)
        {
            try
            {
                DataGridViewTextBoxColumn col
                    = new DataGridViewTextBoxColumn();
                col.DataPropertyName = ColumnName;
                col.HeaderText = HeaderText;
                base.Columns.Add(col);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 컬럼 설정 상세
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="HeaderText"></param>
        /// <param name="AlignHeader"></param>
        /// <param name="AlignColumn"></param>
        /// <param name="Lock"></param>
        /// <param name="Hide"></param>
        public void SetColumn(string ColumnName, string HeaderText, DataGridViewContentAlignment AlignHeader, DataGridViewContentAlignment AlignColumn, bool Lock, bool Hide)
        {
            try
            {
                DataGridViewTextBoxColumn col
                    = new DataGridViewTextBoxColumn();
                col.DataPropertyName = ColumnName;
                col.HeaderText = HeaderText;
                base.Columns.Add(col);

                int ColIndex = Columns.Count - 1;

                AlignColumnHeader(ColIndex, AlignHeader);
                AlignColumnContent(ColIndex, AlignColumn);

                LockColumn(ColIndex, Lock);
                HideColumn(ColIndex, Hide);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 컬럼 정렬기능을 설정합니다.
        /// </summary>
        /// <param name="grid"></param>
        public void SortColumn(bool flag)
        {
            try
            {
                for (int i = 0; i < base.Columns.Count; i++)
                {
                    base.Columns[i].SortMode = flag ?
                        DataGridViewColumnSortMode.Automatic :     // true - sortable
                        DataGridViewColumnSortMode.NotSortable;    // false
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 컬럼 정렬기능을 설정합니다.
        /// </summary>
        /// <param name="grid"></param>
        public void SortColumn(int index, bool flag)
        {
            try
            {
                base.Columns[index].SortMode = flag ?
                    DataGridViewColumnSortMode.Automatic :     // true - sortable
                    DataGridViewColumnSortMode.NotSortable;    // false
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
    }
}
