using BankSystemDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBusinessLayar
{
    public class AccountTransation
    {

        public static DataTable GetAllAccountTransation(int UserAccountID)
        {
            return AccountTransationData.GetAllAccountTransation(UserAccountID);
        }
    }
}
