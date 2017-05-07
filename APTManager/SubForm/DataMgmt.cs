using APTManager.Query;
using Haebi.Util;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace APTManager.SubForm
{
    public partial class DataMgmt : UserControl
    {
        public DataMgmt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 데이터를 조회하여 변수에 담는다.
        /// </summary>
        /// <param name="table_name">테이블 이름</param>
        /// <param name="dt">데이터가 들어있는 데이터 테이블</param>
        /// <param name="sb">데이터를 담을 곳</param>
        /// <returns></returns>
        private StringBuilder _exportTable(string table_name, DataTable dt, StringBuilder sb)
        {
            // each row
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                //테이블 명칭 저장
                sb.Append(table_name);

                // each col
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    // 2번재 항목 부터 구분자 , 를 붙임
                    sb.Append(",");
                    sb.Append(dt.Rows[i][j].ToString());
                }

                // row 가 끝날 때 마다 줄바꿈
                sb.Append(Environment.NewLine);
            }

            return sb;
        }

        /// <summary>
        /// csv 내보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportAdmExp_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Csv|*.csv";
            sfd.Title = "Save an Csv File";
            sfd.ShowDialog();

            // 취소 검사
            if (sfd.FileName != "")
            {
                StringBuilder export_data = new StringBuilder();

                // 내보낼 데이터 조회
                DataTable dt_homeinfo   = HomeInfoQuery.GetHomeInfo();  // 세대정보
                DataTable dt_comcode    = ComCodeQuery.GetComCode();    // 공통코드
                DataTable dt_admexp     = AdmExpQuery.GetAdmExp();      // 관리비

                // 조회된 데이터를 변수에 담는다
                export_data = _exportTable("homeinfo", dt_homeinfo, export_data);
                export_data = _exportTable("comcode" , dt_comcode , export_data);
                export_data = _exportTable("admexp"  , dt_admexp  , export_data);

                // 쓰기 스트림 생성
                StreamWriter file = new StreamWriter(sfd.FileName);

                // 파일에 쓰기
                file.Write(export_data);

                // 파일 닫기
                file.Close();

                // 작업완료 안내
                HBMessageBox.Show("내보내기 완료");
            }
        }

        /// <summary>
        /// csv 복원
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportAdmExp_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Csv|*.csv";
            ofd.Title = "Save an Csv File";
            ofd.ShowDialog();

            // 취소가 아닌 경우 진행
            if (ofd.FileName != "")
            {
                // 읽기 스트림 생성
                StreamReader file = new StreamReader(ofd.FileName);

                DataTable impDT = new DataTable();

                impDT.Columns.Add("01");
                impDT.Columns.Add("02");
                impDT.Columns.Add("03");
                impDT.Columns.Add("04");
                impDT.Columns.Add("05");
                impDT.Columns.Add("06");
                impDT.Columns.Add("07");
                impDT.Columns.Add("08");
                impDT.Columns.Add("09");
                impDT.Columns.Add("10");
                impDT.Columns.Add("11");
                impDT.Columns.Add("12");
                impDT.Columns.Add("13");
                impDT.Columns.Add("14");

                string line = "";
                int col = 0;

                // 파일의 끝까지 줄단위로 읽어들인다
                while ((line = file.ReadLine()) != null)
                {
                    col = 0;

                    DataRow dr = impDT.NewRow();

                    // 읽어들인 라인을 , 단위로 쪼개서 분리
                    string[] rowData = line.Split(',');

                    // 쪼개진 데이터 개별 처리
                    foreach (string str in rowData)
                    {
                        dr[col] = str;
                        col++;
                    }

                    impDT.Rows.Add(dr);

                    dr = null;
                }

                // 파일 닫기
                file.Close();

                // 데이터 저장
                // [미구현]
                                
                // 완료 메시지 표시
                HBMessageBox.Show("복원 완료");
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            StringBuilder sb_export = new StringBuilder();

            sb_export.Append("* 데이터를 백업 합니다");
            sb_export.Append(Environment.NewLine);
            sb_export.Append("* 안전한 데이터의 보존을 위해 주기적으로 백업하여 주시기 바랍니다.");
            sb_export.Append(Environment.NewLine);
            sb_export.Append("* 백업은 CSV (쉼표로 구분) 포맷으로 저장 됩니다.");
            sb_export.Append(Environment.NewLine);
            sb_export.Append("  엑셀(권장) 또는 메모장에서 열어서 확인이 가능합니다.");

            lblExport.Text = sb_export.ToString();

            StringBuilder sb_import = new StringBuilder();

            sb_import.Append("* 데이터를 복원 합니다");
            sb_import.Append(Environment.NewLine);
            sb_import.Append("* 복원 중 기존 데이터는 모두 지우고 복원이 진행됩니다.");

            lblImport.Text = sb_import.ToString();

        }
    }
}
