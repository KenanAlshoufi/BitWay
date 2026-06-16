using Bank_System.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_System
{
    public partial class frmReceive : Form
    {
        public frmReceive()
        {
            InitializeComponent();
        }

        private void frmReceive_Load(object sender, EventArgs e)
        {
            lblAddressAccount.Text = clsGlobal.CurrentUser.AccountInformationID;

            if (clsGlobal.CurrentUser.QrAccountID != null || clsGlobal.CurrentUser.QrAccountID !="")
                pbQRCoder.ImageLocation = clsGlobal.CurrentUser.QrAccountID;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void frmReceive_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAddressAccount.Text))
            {
                Clipboard.SetText(lblAddressAccount.Text);
            }
        }
    }
}
