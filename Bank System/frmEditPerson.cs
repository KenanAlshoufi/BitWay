using Bank_System.Properties;
using BankSystemBusinessLayar;
using Driving_License_Management;
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
    public partial class frmEditPerson : Form
    {
        AccountInformation accountinformation;
        public frmEditPerson(AccountInformation accountinformation)
        {
            InitializeComponent();
            this.accountinformation = accountinformation;
           
        }

        private async Task _FillCountriesInComoboBox()
        {
            DataTable AllCountries= await Task.Run(() => Countries.GetAllCountries()); 

            foreach (DataRow Row in AllCountries.Rows)
            {
                cbNationalty.Items.Add(Row["CountryName"].ToString());
            }
        }


        private bool _HandlePersonImage()
        {
            if (pbImage.ImageLocation != accountinformation.PersonInfo.PersonPhoto)
            {
                if (accountinformation.PersonInfo.PersonPhoto != "")
                {
                    try
                    {
                        File.Delete(accountinformation.PersonInfo.PersonPhoto);
                    }
                    catch (IOException)
                    {

                    }
                }

                if (pbImage.ImageLocation != null)
                {
                    string SourseImageFile=pbImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourseImageFile))
                    {
                        pbImage.ImageLocation= SourseImageFile;
                       return  true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void _SelectPicture()
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

        private void LoadYourInfo()
        {
            if (accountinformation == null)
            {
                MessageBox.Show("There is an error in your data. Please try again later.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }

            txtFirstname.Text=accountinformation.PersonInfo.FirstName;
            txtlastname.Text=accountinformation.PersonInfo.LastName;
            txtPhone.Text=accountinformation.PersonInfo.Phone;
            txtSecondname.Text=accountinformation.PersonInfo.SecondName;
            txtThirdname.Text=accountinformation.PersonInfo.ThirdName;
            txtEmail.Text=accountinformation.PersonInfo.Email;
            cbNationalty.SelectedIndex = cbNationalty.FindString(accountinformation.PersonInfo.InfoCountries.NameCountry);

            if (accountinformation.PersonInfo.PersonPhoto != "")
            {
                pbImage.ImageLocation = accountinformation.PersonInfo.PersonPhoto;
            }
            else
            {
                _SelectPicture();
            }


            lLDeleteImage.Visible = (accountinformation.PersonInfo.PersonPhoto != "");

        }

        private async void frmEditPerson_Load(object sender, EventArgs e)
        {


           await _FillCountriesInComoboBox();


           LoadYourInfo();


        }
        private void ValidateEmptyTextbox(object sender, CancelEventArgs e)
        {
            TextBox temp = ((TextBox)sender);

            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This Filed Is requir !");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }

        private void lLSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void lLDeleteImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            _SelectPicture();
            lLDeleteImage.Visible = false;
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

            People newpeople= accountinformation.PersonInfo;

            newpeople.FirstName=txtFirstname.Text.Trim();
            newpeople.LastName=txtlastname.Text.Trim();
            newpeople.SecondName=txtSecondname.Text.Trim();
            newpeople.ThirdName = string.IsNullOrEmpty(txtThirdname.Text) ? null : txtThirdname.Text.Trim(); 
            newpeople.Email= string.IsNullOrEmpty(txtEmail.Text)? null : txtEmail.Text.Trim();
            newpeople.Phone=txtPhone.Text.Trim();
            newpeople.Nationality=Countries.FindCountryByName( cbNationalty.Text.Trim()).CountryID;

            if (pbImage.Image != Resources.user__1_ && pbImage.Image != Resources.female)
            {
                newpeople.PersonPhoto = pbImage.ImageLocation;
            }
            else
            {
                newpeople.PersonPhoto = null;
            }
          
            if (newpeople.Save())
            {
                MessageBox.Show("Your information has been added.", "Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);



                return;
            }
            else
            {
                MessageBox.Show("There is an error in entering your Inforamtion","Error",MessageBoxButtons.OK
                    ,MessageBoxIcon.Error);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
