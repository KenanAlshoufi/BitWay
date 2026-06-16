using BankSystemDataAccessLayar;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBusinessLayar
{
    public class AccountOperations
    {
     
        public int UserAccountoperationsID { get; set; }
        public decimal Amount { get; set; }
        public int SenderAccount { get; set; }
        public int RecipientAccount { get; set; }
        public int CurrencyID { get; set; }
        public DateTime DateofOperation { get; set; }

        public Currencies currencies;

        public AccountOperations()
        {
            UserAccountoperationsID = -1;
            Amount = -1;
            SenderAccount = -1;
            RecipientAccount = -1;
            CurrencyID = -1;
            DateofOperation = DateTime.Now;
        }
        private AccountOperations(int userAccountoperationsID, decimal amount, int senderAccount, 
            int recipientAccount, int currencyID, DateTime dateofOperation)
        {
            UserAccountoperationsID = userAccountoperationsID;
            Amount = amount;
            SenderAccount = senderAccount;
            RecipientAccount = recipientAccount;
            CurrencyID = currencyID;
            DateofOperation = dateofOperation;

            currencies = Currencies.FindCurrencyByID(currencyID);
        }

        public static DataTable GetAllAccountOperations(int UserAccountID)
        {
            return AccountOperationsData.GetAllAccountOperations(UserAccountID);
        }

        public  bool AddNewAccountOperations()
        {
            this.UserAccountoperationsID = AccountOperationsData.AddNewAccountOperations
                (Amount, SenderAccount, RecipientAccount, CurrencyID);

            return this.UserAccountoperationsID !=-1;
        }


        

        public static AccountOperations FindAccountOperationsByID(int UserAccountoperationsID)
        {
            decimal Amount = -1;
            int SenderAccount = -1;
             int RecipientAccount= -1;
                int CurrencyID=-1;
              DateTime DateofOperation =DateTime.Now;

            if (AccountOperationsData.FindAccountOperationsByID(UserAccountoperationsID, ref Amount, ref SenderAccount,
            ref RecipientAccount, ref CurrencyID, ref DateofOperation))
            {
                return new AccountOperations(UserAccountoperationsID, Amount, SenderAccount, RecipientAccount,
               CurrencyID, DateofOperation);
            }
            else
            {
                return null;
            }
           

        }



    }
}
