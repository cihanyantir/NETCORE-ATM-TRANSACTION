using Microsoft.EntityFrameworkCore;
using NETCORE_ATM_TRANSACTION.IService;
using NETCORE_ATM_TRANSACTION.Models;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using NETCORE_ATM_TRANSACTION.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Services
{
    public class DepositWithDrawService : IGenericServiceDepositWithdraw<Account>
    {

        private readonly AtmDbContext context;

        public DepositWithDrawService(AtmDbContext context)
        {
            this.context = context;
        }

        private Account GetAccountWithTransactions(int OriginAccountID)
        {
            

          

                return context.Accounts.Include(x => x.Transactions).First(x => x.AccountID == OriginAccountID);
            
        }
        public void WithDrawal(int OriginAccountID, double amount)
        {
         
                Account User = context.Accounts.First(x => x.AccountID == OriginAccountID);
                User.Balance -= amount;
                context.SaveChanges();
            
        }


        public  void Deposit(int OriginAccountID, double amount)
        {
           
                Account User = context.Accounts.First(x => x.AccountID == OriginAccountID);
                User.Balance += amount;
                context.SaveChanges();
            
        }

        private int GenerateUniqueTransactionID()
        {
            int uniqueID;
          
            do
            {

                uniqueID = Convert.ToInt32(UtilityFunctions.GenerateStringID(4));
            }
            // check generated ID doesn't exist in database already


            while (context.Transactionss.Find(uniqueID) != null);

            return uniqueID;
        }

        public Account WithDrawProcess(int OriginAccountID, double amount)
        {

            WithDrawal(OriginAccountID, amount);

            var account = GetAccountWithTransactions(OriginAccountID);
          

                context.Transactionss.Add(new Transaction
                {
                    TransactionID = GenerateUniqueTransactionID(),
                    TransactionType = (char)TransactionType.Withdrawal,
                    AccountID = account.AccountID,
                    Amount = amount,
                    ModifyDate = DateTime.UtcNow
                });
                context.SaveChanges();


            
          
               return context.Accounts.FirstOrDefault(x => x.AccountID == OriginAccountID);
            
       }

        public bool EnoughBalance(int OriginAccountID, double amount)
        {
           
            if (amount < context.Accounts.Where(x => x.AccountID == OriginAccountID).Select(p => p.Balance).First())
            {
                return true;


            }
            return false;

        }

        public Account DepositProcess(int OriginAccountID, double amount)
        {
            Deposit(OriginAccountID, amount);

            var account = GetAccountWithTransactions(OriginAccountID);
         



                context.Transactionss.Add(new Transaction
                {
                    TransactionID = GenerateUniqueTransactionID(),
                    TransactionType = (char)TransactionType.Deposit,
                    AccountID = account.AccountID,
                    Amount = amount,
                    ModifyDate = DateTime.UtcNow
                });
                context.SaveChanges();

            
         
                return context.Accounts.Include(x => x.Transactions).Where(x => x.AccountID == OriginAccountID).FirstOrDefault();
                //return c.Accounts.FirstOrDefault(x => x.AccountID == OriginAccountID);
            

        }
    }
}
