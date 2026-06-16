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
using System.Windows.Forms;

namespace Bank_System
{
    public partial class frmRecord : Form
    {
        public frmRecord()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task LoadAllAccountAccountoperations()
        {
            DataTable GetAllUsers = await Task.Run(() => AccountTransation.
                    GetAllAccountTransation(clsGlobal.CurrentUser.AccountID));
            dgvOperationAccount.DataSource = GetAllUsers;
            int RowCount = dgvOperationAccount.Rows.Count;


            if (RowCount > 0)
            {
                dgvOperationAccount.Columns[0].HeaderText = "Account Transations ID";
                dgvOperationAccount.Columns[0].Width = 100;

                dgvOperationAccount.Columns[1].HeaderText = "Affected Account";
                dgvOperationAccount.Columns[1].Width = 100;

                dgvOperationAccount.Columns[2].HeaderText = "Transation Type";
                dgvOperationAccount.Columns[2].Width = 100;

                dgvOperationAccount.Columns[3].HeaderText = "Amount";
                dgvOperationAccount.Columns[3].Width = 100;


                dgvOperationAccount.Columns[4].HeaderText = "Code Currency";
                dgvOperationAccount.Columns[4].Width = 100;

                dgvOperationAccount.Columns[5].HeaderText = "Date";
                dgvOperationAccount.Columns[5].Width = 100;
            }

        }
        private async void frmRecord_Load(object sender, EventArgs e)
        {
            await LoadAllAccountAccountoperations();
        }
    }
}
