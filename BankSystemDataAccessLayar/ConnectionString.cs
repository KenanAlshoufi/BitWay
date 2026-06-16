using System;
using System.Configuration;


namespace BankSystemDataAccessLayar
{
    public class ConnectionString
    {
        public static string connectionstring = ConfigurationManager.ConnectionStrings["BitWay"].ConnectionString;
    }
}
