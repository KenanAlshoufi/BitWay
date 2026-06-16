using Bank_System.Global;
using Bank_System.Properties;
using BankSystemBusinessLayar;
using Driving_License_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Bank_System
{
    public partial class frmCreateAccount : Form
    {
      
        public frmCreateAccount()
        {
            InitializeComponent();
            
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        private void btnContinue_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            InfrmationPanel.Visible = true;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               btnContinue.Enabled = true;
            }
        }

        private async Task _FillCountriesInComoboBox()
        {
            DataTable AllCountries = await Task.Run(() => Countries.GetAllCountries());

            foreach (DataRow Row in AllCountries.Rows)
            {
                cbCountries.Items.Add(Row["CountryName"].ToString());
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

        private async void frmCreateAccount_Load(object sender, EventArgs e)
        {
            // InfrmationPanel.Visible = false;
             btnContinue.Enabled = false;

            await _FillCountriesInComoboBox();
            await LoadAllCurrency();



        }

        private void llSetPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ofdSelectImage.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.gif; *.bmp";
            ofdSelectImage.FilterIndex = 1;
            ofdSelectImage.RestoreDirectory = true;

            if (ofdSelectImage.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file 
                string selectedFilePath = ofdSelectImage.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath); 

                pbImage.ImageLocation = selectedFilePath;
                lLDeleteImage.Visible = true;

            }
        }

        private void lLDeleteImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            rbMale_CheckedChanged(null, null);
            lLDeleteImage.Visible = false;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbImage.Image = Resources.user__1_;
            }
            else
            {
                pbImage.Image = Resources.female;
            }
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            cbCurrency.SelectedIndex = cbCurrency.FindString("USD");
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private bool _HandlePersonImage()
        {
            if (pbImage.ImageLocation != null)
            {
                string SourseImageFile = pbImage.ImageLocation.ToString();
                if (clsUtil.CopyImageToProjectImagesFolder(ref SourseImageFile))
                {
                    pbImage.ImageLocation = SourseImageFile;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            if (!_HandlePersonImage())
            {
                return;
            }

            People people = new People();

            people.FirstName = txtFirstName.Text.Trim();
            people.SecondName = txtSecondName.Text.Trim();
            people.ThirdName = string.IsNullOrEmpty(txtThridName.Text.Trim()) ? null : txtThridName.Text.Trim();
            people.LastName = txtLastName.Text.Trim();
            people.NationalNo = txtNationalty.Text.Trim();
            people.Gendor = (short)(rbMale.Checked ? 0 : 1);
            people.Phone = txtPhone.Text.Trim();
            people.Email = string.IsNullOrEmpty(txtEmail.Text.Trim()) ? null : txtEmail.Text.Trim();
            people.DateOfBirth = dtpDateofBirth.Value;
            people.Nationality = Countries.FindCountryByName(cbCountries.Text).CountryID;
            if (pbImage.Image != Resources.user__1_ && pbImage.Image != Resources.female)
            {
                people.PersonPhoto = pbImage.ImageLocation;
            }
            else
            {
                people.PersonPhoto = null;
            }

            //They need to be developed and made functional within the business layer.
            if (people.Save())
            {
                AccountInformation accountInformation = new AccountInformation();
                accountInformation.PersonID = people.PersonID;
                accountInformation.Username = txtUsername.Text.Trim();
                accountInformation.Password = txtPassword.Text.Trim();
                accountInformation.TotalAmount = 400;
                accountInformation.Currency = Currencies.FindCurrencyByCode(cbCurrency.Text).Id;

                if (accountInformation.Save())
                {

                    clsGlobal.CurrentUser = AccountInformation.FindByUsername(accountInformation.Username);

                   
                    Main main = new Main();
                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is an Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There is an Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCurrency.SelectedIndex = cbCurrency.FindString("USD");
        }

        private void ValidateEmptyTextbox(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(temp.Text.Trim()))
            {
                errorProvider1.SetError(temp, "There is something required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(temp, null);

            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidation.IsValidEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                errorProvider1.SetError(txtUsername, "This Filed Is required!");
                e.Cancel = true;
            }
            else if (AccountInformation.IsUserNameExist(txtUsername.Text.Trim()))
            {
                errorProvider1.SetError(txtUsername, "The username is duplicated !");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void txtConfirmpassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmpassword.Text.Trim()) && 
                txtPassword.Text.Trim() == txtConfirmpassword.Text.Trim())
            {
                errorProvider1.SetError(txtPassword, "This Filed Is required!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "This Filed Is required!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this. Close();
        }

        private void frmCreateAccount_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}

