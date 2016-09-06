using System.Data;

namespace APTManager
{
    public static class Global
    {
        // 전역 설정 변수들 여기에 보관한다.
        public static DataTable     homeInfoDT      = null;     // 세대 기본정보 데이터
        public static DataTable     admExpDT        = null;     // 관리비(Administration Expenses) 데이터

        public static frmHomeInfo   frmHomeInfo     = null;     // 세대 기본정보 창

        // 관리비(Administrative expenses) 컬럼 인덱스
        public enum AdmExp
        {
            [intValue(0)]  yyyymm,       // "년월"
            [intValue(1)]  home,         // "세대"
            [intValue(2)]  name,         // "세대주"
            [intValue(3)]  premonth,     // "전월지침"
            [intValue(4)]  nowmonth,     // "당월지침"
            [intValue(5)]  useamount,    // "사용량"
            [intValue(6)]  usecost,      // "사용금액"
            [intValue(7)]  admexpcost,   // "관리비"
            [intValue(8)]  totalcost,    // "합계"
            [intValue(9)]  remark,       // "비고"
            [intValue(10)] ordernum      // "정렬순서"
        }

        // 열거형에 int값 설정... (근데 열거형에 원래 속성이 int 잖아? 필요 없을거 같기도 한데...)
        private class intValue : System.Attribute
        {
            private static int _value;

            public intValue(int value)
            {
                _value = value;
            }

            public int Value
            {
                get { return _value; }
            }
        }

        // 계산 항목
        public enum Calc
        {
            Sub = 0x1,
            Add = 0x2
        }
    }
}
