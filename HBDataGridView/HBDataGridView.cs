using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Haebi.Util
{
    public class HBDataGridView : DataGridView
    {
        #region 생성자

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

            PrevRowIndex = 0;

            ProcRules = new List<ProcRule>();
        }

        #endregion

        #region 모델 클래스
        
        /// <summary>
        /// 셀 자동계산 모델
        /// </summary>
        public class ProcRule
        {
            private ProcType   _Type;
            private Func<bool> _Func;
            private int        _Dest;
            private int        _Col1;
            private int        _Col2;

            public ProcRule()
            {

            }

            public ProcRule(ProcType Type, int Dest, int Col1, int Col2)
            {
                _Type = Type;
                _Dest = Dest;
                _Col1 = Col1;
                _Col2 = Col2;
            }

            public ProcRule(ProcType Type, Func<bool> Func, int Col1)
            {
                _Type = Type;
                _Func = Func;
                _Dest = 0;
                _Col1 = Col1;
                _Col2 = 0;
            }

            public ProcType Type
            {
                get { return _Type; }
                set { _Type = value; }
            }

            public Func<bool> Func
            {
                get { return _Func; }
                set { _Func = value; }
            }

            public int Dest
            {
                get { return _Dest; }
                set { _Dest = value; }
            }

            public int Col1
            {
                get { return _Col1; }
                set { _Col1 = value; }
            }

            public int Col2
            {
                get { return _Col2; }
                set { _Col2 = value; }
            }
        }

        #endregion

        #region 전역 변수

        private DataGridViewCellStyle NormalStyle;      // 일반 색상
        private DataGridViewCellStyle LockStyle;        // 잠금 색상
        private DataGridViewCellStyle HighlightStyle;   // 선택 색상

        private List<ProcRule> ProcRules;    // 셀 자동계산 규칙 목록

        private int PrevRowIndex;   // 이전 행 위치 (RowHighlight 기능, 이전 행의 색상 복원을 위해 필요하다)
        
        #endregion

        #region 열거형
        
        /// <summary>
        /// 계산 종류
        /// </summary>
        public enum ProcType
        {
            Add  = 0x01,
            Sub  = 0x02,
            Mul  = 0x04,
            Div  = 0x08,
            Mod  = 0x10,
            Func = 0x20,
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

        #endregion

        #region 속성 정의

        /// <summary>
        /// 데이터 소스를 가져오거나 설정에서 DataGridView 에 대한 데이터를 표시 합니다.
        /// </summary>
        [DefaultValue(false), Category("데이터"), Description("DataGridView 컨트롤의 데이터 소스를 나타냅니다.")]
        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                if (AllowRowHighlight)
                {
                    /* 열 표시가 OnSelectionChanged 에서 수행되는데, 데이터 바인딩 시 행 갯수반큼 반복하면서 오류나는 경우가 있다.
                     * 그래서, 조회 직전에 잠깐 끄고, 조회 완료 후 다시 켜는 것으로 한다. 
                     */
                    AllowRowHighlight = false;
                    base.DataSource   = value;
                    AllowRowHighlight = true;
                }
                else
                {
                    base.DataSource = value;
                }
            }
        }

        /// <summary>
        /// 현재 행 표시
        /// </summary>
        [DefaultValue(false), Category("동작"), Description("현재 행 표시를 가능하게 할 것인지 여부를 나타내는 값을 가져오거나 설정합니다.")]
        public bool AllowRowHighlight { get; set; }

        /// <summary>
        /// 컨트롤 그릴 때 더블 버퍼링 사용
        /// </summary>
        [DefaultValue(false), Category("동작")]
        [Description("이 컨트롤에서 깜빡임을 줄이거나 방지하기 위해 보조 버퍼를 사용하여 화면을 다시 그려야 하는지 여부를 나타내는 값을 가져오거나 설정합니다.")]
        public bool SetDoubleBuffer
        {
            get { return DoubleBuffered;  }
            set { DoubleBuffered = value; }
        }

        #endregion

        #region 이벤트 오버라이드

        /// <summary>
        /// 현재 선택이 변경될 때 발생합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectionChanged(EventArgs e)
        {
            ApplyCellStyle(ColorState.Highlight);   // 현재 행 색상 적용
            ApplyCellStyle(ColorState.Normal);      // 이전 행 색상 해제
            
            base.OnSelectionChanged(e);
        }

        /// <summary>
        /// 현재 선택한 셀에 대한 편집 모드가 중지될 때 발생합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            try
            {
                // 셀 자동계산 구현 예정 [미구현]
                int CurRow = base.CurrentCell.RowIndex;
                int CurCol = base.CurrentCell.ColumnIndex;

                foreach (ProcRule rule in ProcRules)
                {
                    // 계산 대상 셀1, 셀2 중 하나가 현재 열인 경우 계산을 진행한다.
                    if (CurCol == rule.Col1 || CurCol == rule.Col2)
                    {
                        Int64 Col1Value = Convert.ToInt64(base.Rows[CurRow].Cells[rule.Col1].Value);
                        Int64 Col2Value = Convert.ToInt64(base.Rows[CurRow].Cells[rule.Col2].Value);

                        // 계산 타입을 검사
                        switch (rule.Type)
                        {
                            case ProcType.Add:
                                base.Rows[CurRow].Cells[rule.Dest].Value = Col1Value + Col2Value;
                                break;

                            case ProcType.Sub:
                                base.Rows[CurRow].Cells[rule.Dest].Value = Col1Value - Col2Value;
                                break;

                            case ProcType.Mul:
                                base.Rows[CurRow].Cells[rule.Dest].Value = Col1Value * Col2Value;
                                break;

                            case ProcType.Div:
                                base.Rows[CurRow].Cells[rule.Dest].Value = Col1Value / Col2Value;
                                break;

                            case ProcType.Mod:
                                base.Rows[CurRow].Cells[rule.Dest].Value = Col1Value % Col2Value;
                                break;

                            case ProcType.Func:
                                rule.Func();
                                break;

                            default:
                                break;
                        }
                    }
                }

                base.OnCellEndEdit(e);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #endregion

        #region 접근제한 메서드 private, protected

        /// <summary>
        /// 셀 스타일 배경색을 설정합니다.
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
        /// 셀 스타일 적용
        /// </summary>
        /// <param name="state"></param>
        private void ApplyCellStyle(ColorState state)
        {
            try
            {
                if (!AllowRowHighlight) return;

                switch (state)
                {
                    case ColorState.Normal:
                        if (PrevRowIndex == base.CurrentCell.RowIndex) return;

                        for (int i = 0; i < base.Columns.Count; i++)
                        {
                            if (!base.Columns[i].ReadOnly)
                                base.Rows[PrevRowIndex].Cells[i].Style.ApplyStyle(NormalStyle); // NormalStyle
                            else
                                base.Rows[PrevRowIndex].Cells[i].Style.ApplyStyle(LockStyle);   // LockStyle
                        }

                        PrevRowIndex = base.CurrentCell.RowIndex;
                        break;

                    case ColorState.Lock:
                        
                        break;

                    case ColorState.Highlight:
                        for (int i = 0; i < base.Columns.Count; i++)
                        {
                            base.Rows[base.CurrentCell.RowIndex].Cells[i].Style.ApplyStyle(HighlightStyle);
                        }
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

        #endregion

        #region 공개 메서드 public
        
        /// <summary>
        /// 그리드 셀 스타일 재 적용
        /// </summary>
        public void RefreshCellStyle()
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

                ApplyCellStyle(ColorState.Highlight);

                PrevRowIndex = base.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
        /// <summary>
        /// 셀 상태 배경색을 지정합니다
        /// </summary>
        /// <param name="state"></param>
        /// <param name="Red"></param>
        /// <param name="Green"></param>
        /// <param name="Blue"></param>
        public void SetBackgroundColorState(ColorState state, byte Red, byte Green, byte Blue)
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
        /// 컬럼 설정
        /// </summary>
        /// <param name="index"></param>
        /// <param name="align"></param>
        public void AlignColumnContent(int index, DataGridViewContentAlignment align)
        {
            base.Columns[index].DefaultCellStyle.Alignment = align;
        }

        /// <summary>
        /// 컬럼헤더 설정
        /// </summary>
        /// <param name="index"></param>
        /// <param name="align"></param>
        public void AlignColumnHeader(int index, DataGridViewContentAlignment align)
        {
            base.Columns[index].HeaderCell.Style.Alignment = align;
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
        /// <param name="Row">행 인덱스</param>
        /// <param name="Col">열 인덱스</param>
        /// <param name="Flag">읽기전용 true, 그 외 false</param>
        public void LockCell(int Row, int Col, bool Flag)
        {
            try
            {
                base.Rows[Row].Cells[Col].ReadOnly = Flag;
                base.Rows[Row].Cells[Col].Style
                    = Flag ? LockStyle : NormalStyle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 컬럼을 읽기전용으로 설정합니다.
        /// </summary>
        /// <param name="Col">열 인덱스</param>
        /// <param name="flag">읽기전용 true, 그 외 false</param>
        public void LockColumn(int Col, bool Flag)
        {
            try
            {
                base.Columns[Col].ReadOnly = Flag;
                base.Columns[Col].DefaultCellStyle
                    = Flag ? LockStyle : NormalStyle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 로우를 읽기전용으로 설정합니다.
        /// </summary>
        /// <param name="Row">행 인덱스</param>
        /// <param name="flag">읽기전용 true, 그 외 false</param>
        public void LockRow(int Row, bool Flag)
        {
            try
            {
                base.Rows[Row].ReadOnly = Flag;
                base.Rows[Row].DefaultCellStyle
                    = Flag ? LockStyle : NormalStyle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 컬럼 설정
        /// </summary>
        /// <param name="ColumnName">컬럼 명</param>
        /// <param name="HeaderText">헤더 제목</param>
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
        /// 상세 컬럼 설정
        /// </summary>
        /// <param name="ColumnName">컬럼 명</param>
        /// <param name="HeaderText">헤더 제목</param>
        /// <param name="AlignHeader">헤더 열 정렬</param>
        /// <param name="AlignColumn">본문 열 정렬</param>
        /// <param name="Lock">셀 잠금</param>
        /// <param name="Hide">셀 숨김</param>
        public void SetColumn(string ColumnName, string HeaderText, DataGridViewContentAlignment AlignHeader, 
            DataGridViewContentAlignment AlignColumn, bool Lock, bool Hide)
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
        /// <param name="flag">정렬 허용 true, 그 외 false</param>
        public void AllowColumnSort(bool Flag)
        {
            try
            {
                for (int i = 0; i < base.Columns.Count; i++)
                {
                    base.Columns[i].SortMode = Flag ?
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
        /// <param name="Col">컬럼 인덱스</param>
        /// <param name="flag">정렬 허용 true, 그 외 false</param>
        public void AllowColumnSort(int Col, bool Flag)
        {
            try
            {
                base.Columns[Col].SortMode = Flag ?
                    DataGridViewColumnSortMode.Automatic :     // true - sortable
                    DataGridViewColumnSortMode.NotSortable;    // false
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 셀 자동처리 규칙을 설정합니다.
        /// </summary>
        /// <param name="Proc">처리 종류</param>
        /// <param name="Dest">결과 열 인덱스</param>
        /// <param name="Col1">열 인덱스1</param>
        /// <param name="Col2">열 인덱스2</param>
        public void AddAutoProcRule(ProcType Proc, int Dest, int Col1, int Col2)
        {
            switch(Proc)
            {
                // 덧셈
                case ProcType.Add:
                    ProcRules.Add(new ProcRule(ProcType.Add, Dest, Col1, Col2));
                    break;

                // 뺄셈
                case ProcType.Sub:
                    ProcRules.Add(new ProcRule(ProcType.Sub, Dest, Col1, Col2));
                    break;

                // 곱셉
                case ProcType.Mul:
                    ProcRules.Add(new ProcRule(ProcType.Mul, Dest, Col1, Col2));
                    break;

                // 나눗셈
                case ProcType.Div:
                    ProcRules.Add(new ProcRule(ProcType.Div, Dest, Col1, Col2));
                    break;

                // 나머지
                case ProcType.Mod:
                    ProcRules.Add(new ProcRule(ProcType.Mod, Dest, Col1, Col2));
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 셀 자동처리 규칙을 설정합니다.
        /// </summary>
        /// <param name="Proc">처리 종류</param>
        /// <param name="Func">함수 명</param>
        /// <param name="Col1">열 인덱스1</param>
        public void AddAutoProcRule(ProcType Proc, Func<bool> Func, int Col1)
        {
            switch(Proc)
            {
                case ProcType.Func:
                    ProcRules.Add(new ProcRule(ProcType.Func, Func, Col1));
                    break;

                default:
                    break;
            }
        }
        
        /// <summary>
        /// 셀 자동계산 규칙을 지웁니다.
        /// </summary>
        public void ClearAutoProcRules()
        {
            ProcRules.Clear();
        }

        #endregion

    }
}
