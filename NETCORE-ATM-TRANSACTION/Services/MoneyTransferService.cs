


using Microsoft.EntityFrameworkCore;
using NETCORE_ATM_TRANSACTION.IService;
using NETCORE_ATM_TRANSACTION.Models;
using NETCORE_ATM_TRANSACTION.Repository;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using NETCORE_ATM_TRANSACTION.Utilities;
using SinKien.IBAN4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Services
{
    public class MoneyTransferService : IGenericServiceTransfer<Account>
    {

        private readonly AtmDbContext context;

        public MoneyTransferService(AtmDbContext context)
        {
            this.context = context;
        }

        private Account GetAccountWithTransactions(int OriginAccountID)
        {

           


                return context.Accounts.Include(x => x.Transactions).First(x => x.AccountID == OriginAccountID);
            
        }

        public void Transfer(int OriginAccountID, int TargetAccountID, double amount)
        {

           

            Account Sender = context.Accounts.First(x => x.AccountID == OriginAccountID);
            //var values =context.Accounts.Include(x => x.Customer).Where(x => x.AccountID == OriginAccountID).FirstOrDefault();
            //int cls = values.Customer.BankID;
                Account Receiver = context.Accounts.First(x => x.AccountID == TargetAccountID);
                Sender.Balance -= amount;
                Receiver.Balance += amount;
                context.SaveChanges();
            
        }




        private int GenerateUniqueTransactionID()
        {
            int uniqueID;
           
            do
            {

                uniqueID = Convert.ToInt32(UtilityFunctions.GenerateStringID(4));
            }



            while (context.Transactionss.Find(uniqueID) != null);

            return uniqueID;
        }

        public Account Transaction(int OriginAccountID, int TargetAccountID, double amount)
        {


            Transfer(OriginAccountID, TargetAccountID, amount);

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


            
           
                return context.Accounts.Include(x => x.Transactions).Where(x => x.AccountID == OriginAccountID).FirstOrDefault();
                //return c.Accounts.FirstOrDefault(x => x.AccountID == OriginAccountID);
           


        }




        public bool EftHavaleCheck(int OriginAccountID, int TargetAccountID)
        {
           

            

            if (context.Customers.Where(x => x.CustomerID == OriginAccountID).Select(p => p.BankID).First() == context.Customers.Where(x => x.CustomerID == TargetAccountID).Select(p => p.BankID).First())
            {
                return true;
            }
            return false;
        }

        public bool EnoughBalance(int OriginAccountID, double amount)
        {
          

            if (amount < context.Accounts.Where(x => x.AccountID == OriginAccountID).Select(p => p.Balance).First())
            {
                return true;


            }
            return false;

        }
    }
}
