using Bank_System.Global;
using BankSystemBusinessLayar;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Bank_System
{
    public partial class frmSend : Form
    {
        public frmSend()
        {
            InitializeComponent();
        }

        int RecipientAccountID;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            if (MessageBox.Show("Are you sure Transfer to Other Account!.", "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            AccountOperations accountOperations = new AccountOperations();

            accountOperations.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
            accountOperations.SenderAccount = clsGlobal.CurrentUser.AccountID;
            accountOperations.RecipientAccount = RecipientAccountID;
            accountOperations.CurrencyID = Currencies.FindCurrencyByCode(cbCurrency.Text).Id;

            if (accountOperations.AddNewAccountOperations())
            {
                MessageBox.Show("The amount has been transferred to the account", "Successfuly", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("The amount is not enough.", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
            return;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if ( clsGlobal.CurrentUser.AccountInformationID== txtAddressAccount.Text.Trim())
            {
                MessageBox.Show("This Account is not exist, Please Confirm the Address Account And try again.",
                   "error", MessageBoxButtons.OK);
                return;
            }

           AccountInformation accountInformation=
                AccountInformation.FindByAccountInformationID(txtAddressAccount.Text.Trim());


            if (accountInformation !=null )
            {
                tabControl1.SelectedIndex = 1;

                RecipientAccountID=accountInformation.AccountID;

                pbVerified.Visible=  accountInformation.IsAccountVerified ;
                lblFullName.Text=accountInformation.PersonInfo.FullName;
                lblAccountAddress.Text=txtAddressAccount.Text.Trim();
                lblNationality.Text=accountInformation.PersonInfo.InfoCountries.NameCountry;
                lblAccountCreationDate.Text=accountInformation.AccountCreationDate.ToString();
            }
            else
            {
                MessageBox.Show("This Account is not exist, Please Confirm the Address Account And try again.",
                    "error", MessageBoxButtons.OK);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void txtAddressAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddressAccount.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddressAccount, "This Filed Is requir !");
            }
            else
            {
                errorProvider1.SetError(txtAddressAccount, null);
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar!='.')
            {
                e.Handled = true;
            }
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddressAccount.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddressAccount, "This Filed Is requir !");
            }
            else
            {
                errorProvider1.SetError(txtAddressAccount, null);
            }

            if (clsGlobal.CurrentUser.TotalAmount < Convert.ToDecimal(txtAmount.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddressAccount, "The amount is not enough.");
            }
            else
            {
                errorProvider1.SetError(txtAddressAccount, null);
            }
        }

        private async Task LoadAllCurrency()
        {
            DataTable dataTable = await Task.Run(() => Currencies.GetAllCurrencies());
            foreach (DataRow Row in dataTable.Rows)
            {
                cbCurrency.Items.Add(Row[2]);
            }
        }
        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCurrency.SelectedIndex = cbCurrency.FindString("USD");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

       

       
        private void tabPage1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmSend_Load(object sender, EventArgs e)
        {
            await LoadAllCurrency();
            cbCurrency.SelectedIndex = cbCurrency.FindString("USD");
        }
    }
}
