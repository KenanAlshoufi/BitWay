using Bank_System.Global;
using BankSystemBusinessLayar;
using Driving_License_Management;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        static string username = "";
        static string password = "";


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void llCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCreateAccount createAccount = new frmCreateAccount();
            this.Hide();
            createAccount.ShowDialog();
            this.Show();
            
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            if (btnContinue.Text == "Login")
            {
                password = txtUsername.Text;

                if (!username.Contains("@"))
                {
                    if (AccountInformation.LogIn(username, password))
                    {
                        clsGlobal.RegistryUsernameAndPassword(username, password);
                        clsGlobal.CurrentUser = AccountInformation.FindByUsername(username);

                        this.Hide();

                        Main main = new Main(this);
                        main.Show();
                    }
                }
                else
                {
                    if (AccountInformation.LogInByEmail(username, password))
                    {
                        clsGlobal.RegistryUsernameAndPassword(username, password);
                        clsGlobal.CurrentUser = AccountInformation.FindByPersonID(People.FindByEmail(username).PersonID);

                        this.Hide();

                        Main main = new Main(this);
                        main.Show();
                    }
                }

                return;
            }

            username = txtUsername.Text;
            btnContinue.Text = "Login";
            lblType.Text = "كلمة السر :";

            if (password == "")
            {
                txtUsername.NameTextBox = "Password";
            }
            else
            {
                txtUsername.Text = password;
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            clsFormat.SetRoundedRegion(txtUsername, 10);
            clsFormat.SetRoundedRegion(this, 60);
            clsFormat.SetRoundedRegion(btnContinue, 15);

        }


        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "user name is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            lblNumberofusers.Text = AccountInformation.Numberofusers().ToString();

            if (clsGlobal.GetStoredCredential(ref username, ref password))
            {
                txtUsername.Text = username;
            }

        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
