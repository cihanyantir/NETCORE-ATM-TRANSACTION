using NETCORE_ATM_TRANSACTION.Models;
using NETCORE_ATM_TRANSACTION.Repository;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Services
{
    public class MoneyService
    {
       
        static public bool Enough(int fromaccount, double amount)

        {
            AtmDbContext c = new AtmDbContext();
         
            if (amount < c.Customers.Where(x => x.CustomerID == fromaccount).Select(p => p.Balance).First())
            {
                return true;

               
                }
            return false;
            

        }
        
        
        
    }
}
