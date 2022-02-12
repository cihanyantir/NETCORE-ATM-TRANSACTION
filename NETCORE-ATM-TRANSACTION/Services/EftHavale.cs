using NETCORE_ATM_TRANSACTION.Models;
using NETCORE_ATM_TRANSACTION.Repository;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Services
{
    public class EftHavale
    {
      
         public static bool Efthavale(int fromaccount, int toaccount)
        {  AtmDbContext c = new AtmDbContext();
            bool b = false;
            if(c.Customers.Where(x => x.CustomerID == fromaccount).Select(p => p.BankID).FirstOrDefault()== c.Customers.Where(x => x.CustomerID == toaccount).Select(p => p.BankID).FirstOrDefault())
            {
                return true;
            }
            return b;
        }
    }
}
