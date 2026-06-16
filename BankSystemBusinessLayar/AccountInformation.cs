using BankSystemBusinessLayar.QR;
using BankSystemBusinessLayar.Security;
using BankSystemDataAccessLayar;
using System;
using System.Data;
 


namespace BankSystemBusinessLayar
{
    public class AccountInformation
    {
        public int AccountID { get; set; }
        public string AccountInformationID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal TotalAmount { get; set; }
        public int Currency { get; set; }
        public bool IsAccountVerified { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string QrAccountID {  get; set; }

        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public Currencies CurrencyInfo;

        public People PersonInfo;

        public AccountInformation()
        {
            AccountID = -1;
            AccountInformationID = "";
            PersonID = -1;
            Username = "";
            Password = "";
            TotalAmount = 0;
            Currency = 0;
            IsAccountVerified = false;
            AccountCreationDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private AccountInformation(int accountID, string accountInformationID, int personID, string username,
            string password, decimal totalAmount, int currency, bool isAccountVerified, DateTime accountCreationDate
            , string qrAccountID)
        {
            AccountID = accountID;
            AccountInformationID = accountInformationID;
            PersonID = personID;
            Username = username;
            Password = password;
            TotalAmount = totalAmount;
            Currency = currency;
            IsAccountVerified = isAccountVerified;
            AccountCreationDate = accountCreationDate;
            QrAccountID=qrAccountID;


            PersonInfo = People.FindByPersonID(PersonID);
            CurrencyInfo = Currencies.FindCurrencyByID(currency);
            Mode = enMode.Update;
        }


        public static DataTable GetAllAccountInformation()
        {
            return AccountInforamtionData.GetAllAccountInformation();
        }


        private bool _UpdateAccountInformation()
        {
            return AccountInforamtionData.UpdateAccountInformation(AccountID, Username, 
                HashService.ComuteHash(Password),
                TotalAmount, Currency, IsAccountVerified, QrAccountID);
        }


        private bool _AddAccountInformation()
        {
            AccountInformationID = Generate_ID.GenerateID.ID();
            QrAccountID = IDQRCoder.QR(AccountInformationID);

            this.AccountID = AccountInforamtionData.AddAccountInformation(AccountInformationID, PersonID, Username,
                HashService.ComuteHash( Password),
                TotalAmount, Currency, false, DateTime.Now, QrAccountID);

            return (this.AccountID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddAccountInformation())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    return (_UpdateAccountInformation());

            }
            return false;
        }

        public static bool LogIn(string Username, string Password)
        {
            return AccountInforamtionData.LogIn(Username, HashService.ComuteHash(Password));
        }


        public static bool LogInByEmail(string Email, string Password)
        {
            return AccountInforamtionData.LogInByEmail(Email, HashService.ComuteHash(Password));
        }

        public static bool AccountVerified(int AccountID)
        {
            return AccountInforamtionData.AccountVerified(AccountID);
        }

        public static AccountInformation FindByAccountID(int AccountID)
        {
            string AccountInformationID = "";
            int PersonID = -1;
            string Username = "";
            string Password = "";
            decimal TotalAmount = 0;
            int Currency = -1;
            bool IsAccountVerified = false;
            DateTime AccountCreationDate = DateTime.Now;
            string QrAccountID = "";

            if (AccountInforamtionData.FindByAccountID(AccountID, ref AccountInformationID, ref PersonID, ref Username
           , ref Password,
           ref TotalAmount, ref Currency, ref IsAccountVerified, ref AccountCreationDate,ref QrAccountID))
            {
                return new AccountInformation(AccountID, AccountInformationID, PersonID, Username
                        , Password,TotalAmount, Currency, IsAccountVerified, AccountCreationDate, QrAccountID);
            }
            return null;
        }

        public static AccountInformation FindByPersonID(int PersonID)
        {
            string AccountInformationID = "";
            int AccountID = -1;
            string Username = "";
            string Password = "";
            decimal TotalAmount = 0;
            int Currency = -1;
            bool IsAccountVerified = false;
            DateTime AccountCreationDate = DateTime.Now;
            string QrAccountID = "";

            if (AccountInforamtionData.FindByPersonID(PersonID,ref AccountID, ref AccountInformationID, ref Username
           , ref Password,
           ref TotalAmount, ref Currency, ref IsAccountVerified, ref AccountCreationDate,ref QrAccountID))
            {
                return new AccountInformation(AccountID, AccountInformationID, PersonID, Username
                        , Password, TotalAmount, Currency, IsAccountVerified, AccountCreationDate, QrAccountID);
            }
            return null;
        }

        public static AccountInformation FindByUsername(string Username)
        {
            string AccountInformationID = "";
            int AccountID = -1;
            int PersonID = -1;
            string Password = "";
            decimal TotalAmount = 0;
            int Currency = -1;
            bool IsAccountVerified = false;
            DateTime AccountCreationDate = DateTime.Now;
            string QrAccountID = "";

            if (AccountInforamtionData.FindByUsername( Username, ref AccountID, ref AccountInformationID, ref PersonID
           , ref Password,
           ref TotalAmount, ref Currency, ref IsAccountVerified, ref AccountCreationDate,ref QrAccountID))
            {
                return new AccountInformation(AccountID, AccountInformationID, PersonID, Username
                        , Password, TotalAmount, Currency, IsAccountVerified, AccountCreationDate, QrAccountID);
            }
            return null;
        }

        public static AccountInformation FindByAccountInformationID(string AccountInformationID)
        {
            string Username = "";
            int AccountID = -1;
            int PersonID = -1;
            string Password = "";
            decimal TotalAmount = 0;
            int Currency = -1;
            bool IsAccountVerified = false;
            DateTime AccountCreationDate = DateTime.Now;
            string QrAccountID = "";

            if (AccountInforamtionData.FindByAccountInformationID(AccountInformationID, ref AccountID, ref Username, ref PersonID
           , ref Password,
           ref TotalAmount, ref Currency, ref IsAccountVerified, ref AccountCreationDate,ref QrAccountID))
            {
                return new AccountInformation(AccountID, AccountInformationID, PersonID, Username
                        , Password, TotalAmount, Currency, IsAccountVerified, AccountCreationDate, QrAccountID);
            }
            return null;
        }


        public static int Numberofusers()
        {
            return AccountInforamtionData.Numberofusers();
        }


        public static bool IsUserNameExist(string Username)
        {
            return AccountInforamtionData.IsUserNameExist(Username);
        }


    }
}
