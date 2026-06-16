using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBusinessLayar.Generate_ID
{
    public class GenerateID
    {
        public static string ID() 
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
