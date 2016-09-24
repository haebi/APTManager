
namespace APTManager
{
    public static class Common
    {
        // 세대 기본정보 컬럼 인덱스
        public enum HomeInfo
        {
            [intValue(0)] home,         // "세대"
            [intValue(1)] name,         // "세대주"
            [intValue(2)] ordernum      // "정렬순서"
        }

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

        // 공통코드 컬럼 인덱스
        public enum ComCode
        {
            [intValue(0)] comgroup,     // "공통코드종류"
            [intValue(1)] comcode,      // "공통코드"
            [intValue(2)] comvalue,     // "값"
            [intValue(3)] comremark     // "비고"
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
            Sub = 0x00000001,
            Add = 0x00000002
        }
    }
}
