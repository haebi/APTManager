using System.Data;

namespace APTManager
{
    public static class Global
    {
        // 전역 설정 변수들 여기에 보관한다.
        public static DataTable     homeInfoDT      = null;     // 세대 기본정보 데이터
        public static frmHomeInfo   frmHomeInfo     = null;     // 세대 기본정보 창

        public static DataTable     manageFeeDT     = null;     // 관리비 데이터
    }
}
