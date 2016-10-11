using System;
using System.Reflection;

namespace APTManager
{
    public static class Common
    {
        // 세대 기본정보 컬럼 인덱스
        public enum HomeInfo
        {
            [ColumnInfo(0, "home"    )] home,         // "세대"
            [ColumnInfo(1, "name"    )] name,         // "세대주"
            [ColumnInfo(2, "ordernum")] ordernum      // "정렬순서"
        }

        // 관리비(Administrative expenses) 컬럼 인덱스
        public enum AdmExp
        {
            [ColumnInfo(0 , "yyyymm"    )] yyyymm,       // "년월"
            [ColumnInfo(1 , "home"      )] home,         // "세대"
            [ColumnInfo(2 , "name"      )] name,         // "세대주"
            [ColumnInfo(3 , "premonth"  )] premonth,     // "전월지침"
            [ColumnInfo(4 , "nowmonth"  )] nowmonth,     // "당월지침"
            [ColumnInfo(5 , "useamount" )] useamount,    // "사용량"
            [ColumnInfo(6 , "usecost"   )] usecost,      // "사용금액"
            [ColumnInfo(7 , "admexpcost")] admexpcost,   // "관리비"
            [ColumnInfo(8 , "totalcost" )] totalcost,    // "합계"
            [ColumnInfo(9 , "remark"    )] remark,       // "비고"
            [ColumnInfo(10, "ordernum"  )] ordernum      // "정렬순서"
        }

        // 공통코드 컬럼 인덱스
        public enum ComCode
        {
            [ColumnInfo(0, "comgroup" )] comgroup,     // "공통코드종류"
            [ColumnInfo(1, "comcode"  )] comcode,      // "공통코드"
            [ColumnInfo(2, "comname"  )] comname,      // "공통이름"
            [ColumnInfo(3, "comvalue" )] comvalue,     // "값"
            [ColumnInfo(4, "comremark")] comremark     // "비고"
        }

        // 지불 컬럼 인덱스
        public enum Payment
        {
            [ColumnInfo(0, "yyyymm"    )] yyyymm,      // "년월"
            [ColumnInfo(1, "home"      )] home,        // "세대"
            [ColumnInfo(2, "name"      )] name,        // "세대주"
            [ColumnInfo(3, "ordernum"  )] ordernum,    // "정렬순서"
            [ColumnInfo(4, "admexpcost")] admexpcost,  // "관리비"
            [ColumnInfo(5, "pay"       )] pay,         // "납입금"
            [ColumnInfo(6, "prepay"    )] prepay,      // "선납금"
            [ColumnInfo(7, "nonpay"    )] nonpay,      // "미납금"
            [ColumnInfo(8, "totalcost" )] totalcost,   // "차액"
            [ColumnInfo(9, "remark"    )] remark       // "비고"
        }

        // 계산 항목
        public enum Calc
        {
            Sub = 0x00000001,
            Add = 0x00000002
        }

        // 그리드 정렬
        public enum GridAlign
        {
            Center  = 0x00000020,   // 32
            Left    = 0x00000010,   // 16
            Right   = 0x00000040    // 64
        }

        // 컬럼 정보를 담을 객체 설정
        private class ColumnInfo : System.Attribute
        {
            private static int _index;
            private static string _name;

            public ColumnInfo(int index, string name)
            {
                _index = index;
                _name = name;
            }

            public int Index
            {
                get { return _index; }
            }

            public string Name
            {
                get { return _name; }
            }
        }

        // enum 타입의 인덱스는 (int)로 가져올 수 있기에 별 의미는 없다. 일단 형식상 만들어 두자.
        public static int GetIndex(object value)
        {
            int output = -1;

            ColumnInfo[] attrs = _ToAttributeArray(value);

            if (attrs.Length > 0)
            {
                output = attrs[0].Index;
            }

            return output;
        }

        // 문자열 값을 꺼내기 위해서 만듬.
        public static string GetName(object value)
        {
            string output = null;

            ColumnInfo[] attrs = _ToAttributeArray(value);

            if (attrs.Length > 0)
            {
                output = attrs[0].Name;
            }

            return output;
        }

        // 음... 이걸 어떻게 설명하지...
        // 참~ 좋은데, 정말 좋은데, 어떻게 글로 표현을 못하겠네... -_-;;
        private static ColumnInfo[] _ToAttributeArray(object value)
        {
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            ColumnInfo[] attrs = fi.GetCustomAttributes(typeof(ColumnInfo), false) as ColumnInfo[];

            return attrs;
        }

    }
}
