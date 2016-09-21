using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APTManager
{
    public partial class frmPrintAdmExp : Form
    {
        public frmPrintAdmExp()
        {
            InitializeComponent();
        }

        private void frmPrintAdmExp_Load(object sender, EventArgs e)
        {

            ReportViewer_AdmExp.PageCountMode = PageCountMode.Actual;
            
            ReportDataSource rDS = new ReportDataSource("AdmExpDT", Global.admExpDT);
            this.ReportViewer_AdmExp.LocalReport.DataSources.Clear();
            this.ReportViewer_AdmExp.LocalReport.DataSources.Add(rDS);
            this.ReportViewer_AdmExp.LocalReport.Refresh();

            // 마진 설정
            System.Drawing.Printing.PageSettings ps = ReportViewer_AdmExp.GetPageSettings();
            ps.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.ReportViewer_AdmExp.SetPageSettings(ps);

            // 타이틀에 사용할 년월 정보를 조회된 데이터로 부터 가져온다.
            string YYYY = Global.admExpDT.Rows[0][(int)Common.AdmExp.yyyymm].ToString().Substring(0, 4);
            string MM = Global.admExpDT.Rows[0][(int)Common.AdmExp.yyyymm].ToString().Substring(4, 2);

            // 타이틀 설정
            ReportParameter[] rp = new ReportParameter[1];
            rp[0] = new ReportParameter("TITLE", string.Format("XX아파트 관리비({0}년 {1}월)", YYYY, MM ));
            this.ReportViewer_AdmExp.LocalReport.SetParameters(rp);

            // 미리보기 설정
            this.ReportViewer_AdmExp.SetDisplayMode(DisplayMode.PrintLayout);
            
            this.ReportViewer_AdmExp.RefreshReport();
        }
    }
}
