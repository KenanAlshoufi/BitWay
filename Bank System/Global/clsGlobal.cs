using BankSystemBusinessLayar;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bank_System.Global
{
    public class clsGlobal
    {
        public static AccountInformation CurrentUser;

        private static string KeyPath= @"HKEY_CURRENT_USER\SOFTWARE\Bitway_Login";
        private static string UsernameOrEmail = "UsernameOrEmail";
        private static string password = "Password";

        public static bool RegistryUsernameAndPassword(string Username,string Password)
        {
            try
            {
                Registry.SetValue(KeyPath, UsernameOrEmail, Username, RegistryValueKind.String);
                Registry.SetValue(KeyPath, password, Password, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username,ref string Password)
        {
            try
            {
                Username=(string) Registry.GetValue(KeyPath, UsernameOrEmail, RegistryValueKind.String);
                Password = (string)  Registry.GetValue(KeyPath, password, RegistryValueKind.String);

                if (Username != null && Password != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
               
                return false;
            }

        }


    }
}
