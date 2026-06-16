using Bank_System.Global;
using BankSystemBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bank_System
{
    public partial class Main : Form
    {
        frmLogin _frmlogin;
        AccountInformation _accountInformation;

        public Main(frmLogin login=null)
        {
            InitializeComponent();
            _frmlogin = login;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile();
            profile.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmlogin.Show();
            this.Close();

        }

       

        private void LoadAllAccountInfo()
        {
            _accountInformation = AccountInformation.FindByAccountID(clsGlobal.CurrentUser.AccountID);

            lblTotalAmount.Text = _accountInformation.TotalAmount.ToString();
            cbCurrency.SelectedIndex =cbCurrency.FindString(_accountInformation.CurrencyInfo.CurrencyCode);
            lblCurrancy.Text= _accountInformation.CurrencyInfo.Symbol;
        }

        private async Task LoadAllCurrency()
        {
            DataTable dataTable = await Task.Run (()=> Currencies.GetAllCurrencies());
            foreach (DataRow Row in dataTable.Rows)
            {
                cbCurrency.Items.Add(Row[2]);
            }
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            await  LoadAllCurrency();
            LoadAllAccountInfo();
            
        }

        private void accountVerificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("غير متاح حاليا", "Error", MessageBoxButton.OK);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            frmSend send = new frmSend();
            send.ShowDialog();
            LoadAllAccountInfo();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
           frmReceive receive = new frmReceive();
            receive.ShowDialog();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {

        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //للتطوير عند ربط بأسعار العملات 
            cbCurrency.SelectedIndex = cbCurrency.FindString(clsGlobal.CurrentUser.CurrencyInfo.CurrencyCode);
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmlogin.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmRecord record = new frmRecord();
            record.ShowDialog();
            LoadAllAccountInfo();
        }
    }
}
