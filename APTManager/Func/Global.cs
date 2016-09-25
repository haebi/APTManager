using System.Data;

namespace APTManager
{
    public static class Global
    {
        // 전역 설정 변수들 여기에 보관한다.
        public static DataTable     homeInfoDT      = null;     // 세대 기본정보 데이터
        public static DataTable     admExpDT        = null;     // 관리비(Administration Expenses) 데이터
        public static DataTable     comcodeDT       = null;     // 공통코드 데이터

        // 전역 폼 인스턴스
        public static APTManager_HomeInfo           frmHomeInfo         = null;     // 세대 기본정보 창
        public static APTManager_PrintAdmExp        frmPrintAdmExp      = null;     // 관리비 출력 창
        public static APTManager_Settings           APTManager_Settings = null;     // 환경설정 창
    }
}
