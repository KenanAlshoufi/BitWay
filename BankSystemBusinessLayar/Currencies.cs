using BankSystemDataAccessLayar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBusinessLayar
{
    public class Currencies
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string Symbol { get; set; }


        public Currencies(int id, string currencyName, string currencyCode, string symbol)
        {
            Id = id;
            CurrencyName = currencyName;
            CurrencyCode = currencyCode;
            Symbol = symbol;
        }


        public static Currencies FindCurrencyByID(int Id)
        {
            string CurrencyName = "", CurrencyCode = "", Symbol = "";


            if (CurrenciesData.FindCurrencyByID(Id, ref CurrencyName, ref CurrencyCode, ref Symbol))
            {
                return new Currencies(Id, CurrencyName, CurrencyCode, Symbol);
            }
            return null;
        }

        public static Currencies FindCurrencyByName( string CurrencyName)
        {
            int Id = 0; 
            string CurrencyCode = "", Symbol = "";


            if (CurrenciesData.FindCurrencyByName(ref Id,  CurrencyName, ref CurrencyCode, ref Symbol))
            {
                return new Currencies(Id, CurrencyName, CurrencyCode, Symbol);
            }
            return null;

        }


        public static Currencies FindCurrencyByCode(string CurrencyCode)
        {
            int Id = 0;
            string CurrencyName = "", Symbol = "";


            if (CurrenciesData.FindCurrencyByCode(ref Id,ref  CurrencyName,  CurrencyCode, ref Symbol))
            {
                return new Currencies(Id, CurrencyName, CurrencyCode, Symbol);
            }
            return null;

        }

        public static bool IsCurrencyExist(string CurrencyCode)
        {
            return CurrenciesData.IsCurrencyExist(CurrencyCode);
        }

        public static DataTable GetAllCurrencies()
        {
            return CurrenciesData.GetAllCurrencies();
        }

    }
}
