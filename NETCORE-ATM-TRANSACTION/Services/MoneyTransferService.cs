

using Microsoft.EntityFrameworkCore;
using NETCORE_ATM_TRANSACTION.IService;
using NETCORE_ATM_TRANSACTION.Models;
using NETCORE_ATM_TRANSACTION.Repository;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using NETCORE_ATM_TRANSACTION.Utilities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Services
{
    public class MoneyTransferService : IGenericServiceTransfer<Customer>
    {
     
        //private Account GetAccountWithTransactions(int accountNumber) => _context.Accounts.Include(x => x.Transactions).First(x => x.AccountID == accountNumber);

        private Account GetAccountWithTransactions(int fromaccount)
        {

            using (var context = new AtmDbContext())
            {
               

                return context.Accounts.Include(x => x.Transactions).First(x => x.AccountID == fromaccount);
            }
        }

        readonly TransferMethod trf = new TransferMethod();

        private int GenerateUniqueTransactionID()
        {
            int uniqueID;
            using var context = new AtmDbContext();
            do
            {
               
                uniqueID = Convert.ToInt32(UtilityFunctions.GenerateStringID(4));
            }
            // check generated ID doesn't exist in database already


            while (context.Transactionss.Find(uniqueID) != null);

            return uniqueID;
        }

        public Customer TransactionEFT(int fromaccount, int toaccount, double amount)
        {
          

                    trf.Transfer(fromaccount, toaccount, amount);

                    var account = GetAccountWithTransactions(fromaccount);
                    using (var context = new AtmDbContext())
                    {

                    

                    context.Transactionss.Add(new Transaction
                    {
                        TransactionID = GenerateUniqueTransactionID(),
                        TransactionType = (char)TransactionType.Withdrawal,
                        AccountID = account.AccountID,
                        Amount = amount,
                        ModifyDate = DateTime.UtcNow
                    });
                    context.SaveChanges();
                 
                  
             


              
            }   using (var c = new AtmDbContext())
                    {
                           return c.Customers.FirstOrDefault(x => x.CustomerID == fromaccount);
                    }
          

        }


        public Customer TransactionHavale(int fromaccount, int toaccount, double amount)
        {
            if (EftHavale.Efthavale(fromaccount, toaccount) == false)
            {
                if (MoneyService.Enough(fromaccount, amount))
                {
                    trf.Transfer(fromaccount, toaccount, amount);

                }
              
            }
           
            using (var c = new AtmDbContext())
            {
                return c.Customers.Where(x => x.CustomerID == fromaccount).SingleOrDefault(); //Doldurulacak
            }

        }

        public bool EftHavaleCheck(int fromaccount, int toaccount)
        {
            AtmDbContext c = new AtmDbContext();
           
            if (c.Customers.Where(x => x.CustomerID == fromaccount).Select(p => p.BankID).First() == c.Customers.Where(x => x.CustomerID == toaccount).Select(p => p.BankID).First())
            {
                return true;
            }
            return false;
        }

        public bool EnoughBalance(int fromaccount, double amount)
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
