using System;
using System.Windows.Forms;

namespace Haebi.Util
{
    public static class HBMessageBox
    {
        // 메시지 폼
        private static HBMessageBox_Main messageBox = new HBMessageBox_Main();

        // 리턴 값
        public static DialogResult dr;

        public static DialogResult Show(string Message)
        {
            dr = DialogResult.None;
            messageBox.StartPosition = FormStartPosition.CenterParent;

            // 버튼 설정
            messageBox.SetButtons(MessageBoxButtons.OK);

            // 다이얼로그 공통 처리
            return common_process(Message, "");
        }

        public static DialogResult Show(string Message, string Title)
        {
            dr = DialogResult.None;
            messageBox.StartPosition = FormStartPosition.CenterParent;

            // 버튼 설정
            messageBox.SetButtons(MessageBoxButtons.OK);

            // 다이얼로그 공통 처리
            return common_process(Message, Title);
        }

        public static DialogResult Show(string Message, string Title, MessageBoxButtons buttons)
        {
            dr = DialogResult.None;
            messageBox.StartPosition = FormStartPosition.CenterParent;

            // 버튼 설정
            messageBox.SetButtons(buttons);

            // 다이얼로그 공통 처리
            return common_process(Message, Title);
        }

        public static DialogResult Show(string Message, string Title, MessageBoxButtons buttons, FormStartPosition startPos)
        {
            dr = DialogResult.None;
            messageBox.StartPosition = startPos;

            // 다이얼로그 공통 처리
            return common_process(Message, Title);
        }

        public static DialogResult Show(string Message, string Title, MessageBoxButtons buttons, int Left, int Top)
        {
            dr = DialogResult.None;
            messageBox.StartPosition = FormStartPosition.Manual;
            messageBox.SetLocation(Left, Top);

            // 다이얼로그 공통 처리
            return common_process(Message, Title);
        }
        
        /// <summary>
        /// 다이얼로그 공통 처리
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Title"></param>
        /// <returns></returns>
        private static DialogResult common_process(string Message, string Title)
        {
            // 제목 설정
            messageBox.Text = Title;

            // 내용 설정
            messageBox.SetMessage(Message);

            // 포커스 설정
            //messageBox.WindowState = FormWindowState.Minimized;
            //messageBox.Shown += delegate (Object sender, EventArgs e) {
            //    ((Form)sender).WindowState = FormWindowState.Normal;
            //};

            // 다이얼로그 출력
            messageBox.ShowDialog();
            
            return dr;
        }

    }
}
