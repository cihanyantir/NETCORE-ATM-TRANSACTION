using Microsoft.EntityFrameworkCore;
using NETCORE_ATM_TRANSACTION.Models;
using NETCORE_ATM_TRANSACTION.Repository;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Services
{
    public class TransferMethod
    {
      


        public void Transfer(int fromaccount, int toaccount, double amount)
        {
         

            using (var context = new AtmDbContext())
            {

                
                Customer Sender = context.Customers.First(x => x.CustomerID == fromaccount);
                Sender.Balance -= amount;
                context.SaveChanges();
            }
        }
       
    }
}
