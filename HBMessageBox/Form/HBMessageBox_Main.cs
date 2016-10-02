using System;
using System.Windows.Forms;

namespace Haebi.Util
{
    internal partial class HBMessageBox_Main : Form
    {
        /// <summary>
        /// 창 종료 버튼 비활성화
        /// </summary>
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CP_NOCLOSE_BUTTON;
                return cp;
            }
        }

        public HBMessageBox_Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 기본 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HBMessageBox_Main_Load(object sender, EventArgs e)
        {
            // 창 스타일 지정
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        /// <summary>
        /// 메시지 설정
        /// </summary>
        /// <param name="message"></param>
        public void SetMessage(string message)
        {
            this.lblMessage.Text = message;
        }

        /// <summary>
        /// 위치 설정
        /// </summary>
        /// <param name="Left"></param>
        /// <param name="Top"></param>
        public void SetLocation(int Left, int Top)
        {
            this.Left = Left;
            this.Top = Top;
        }

        /// <summary>
        /// 버튼 설정
        /// </summary>
        public void SetButtons(MessageBoxButtons buttons)
        {
            btnOK.Visible   = false;
            btnYES.Visible  = false;
            btnNO.Visible   = false;

            switch (buttons) { 
                case MessageBoxButtons.OK:
                    btnOK.Visible = true;
                    break;

                case MessageBoxButtons.YesNo:
                    btnYES.Visible  = true;
                    btnNO.Visible   = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 확인 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 예 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYES_Click(object sender, EventArgs e)
        {
            HBMessageBox.dr = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// 아니오 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNO_Click(object sender, EventArgs e)
        {
            HBMessageBox.dr = DialogResult.No;
            this.Close();
        }
    }
}
