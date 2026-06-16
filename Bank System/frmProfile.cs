using Bank_System.Global;
using Bank_System.Properties;
using BankSystemBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_System
{
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
        }
        AccountInformation accountinformation ;

        private void SelectPicture()
        {
            if (accountinformation.PersonInfo.Gendor == 0)
            {
                pbImage.Image = Resources.user__1_;
            }
            else
            {
                pbImage.Image = Resources.female;
            }
        }

        private void _LoadPersonImage()
        {

            string ImagePath = accountinformation.PersonInfo.PersonPhoto;

            if (ImagePath != "")
            {

                if (File.Exists(ImagePath))
                    pbImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not Find this Image = " + ImagePath, "Erorr", MessageBoxButtons.OK);
            }
            else
            {
                SelectPicture();
            }

        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            accountinformation =AccountInformation.FindByAccountID( clsGlobal.CurrentUser.AccountID);

            if (accountinformation == null)
            {
                MessageBox.Show("User Is not Exists","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }


            lblID.Text = accountinformation.AccountInformationID;
            lblEmail.Text=accountinformation.PersonInfo.Email;
            lblDateofBirth.Text = accountinformation.PersonInfo.DateOfBirth.ToString();
            lblPhone.Text = accountinformation.PersonInfo.Phone;
            lblIsVerified.Text=accountinformation.IsAccountVerified.ToString();
            lblName.Text=accountinformation.PersonInfo.FullName;
            lblCurrency.Text=accountinformation.CurrencyInfo.CurrencyCode.ToString();

            _LoadPersonImage();

            if (accountinformation.IsAccountVerified)
            {
                pbVerified.Visible = true;
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            frmEditPerson editPerson = new frmEditPerson(accountinformation);
            editPerson.ShowDialog();
            frmProfile_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
