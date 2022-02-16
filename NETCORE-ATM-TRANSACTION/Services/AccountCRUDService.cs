using Microsoft.EntityFrameworkCore;
using NETCORE_ATM_TRANSACTION.IService;
using NETCORE_ATM_TRANSACTION.Models;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using SinKien.IBAN4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Services
{
    public class AccountCRUDService : IAccountCRUDService
    {
        
        private readonly AtmDbContext _context ;

        public AccountCRUDService(AtmDbContext context)
        {
            _context = context;
        }

        public bool AccountExists(int id)
        {
            var values = _context.Accounts;
            
                return _context.Accounts.Any(x => x.AccountID == id);      }

        public bool AccountExists(string IBAN)
        {
            bool value = _context.Accounts.Any(x => x.IBAN.ToLower().Trim() == IBAN.ToLower().Trim());
            return value;
        }

        public void AddIBAN(Account account)
        {
            Iban iban = new IbanBuilder()
                  .CountryCode(CountryCode.GetCountryCode("CZ"))
                  .BankCode("0800")
                  .AccountNumberPrefix("000019")
                  .AccountNumber((account.AccountID).ToString())
                  .Build();
            account.IBAN = iban.ToString();
            _context.SaveChanges();
            
        }

        public bool CreateAccount(Account account)
        {
               
            account.CreateDate = DateTime.UtcNow;
            _context.Accounts.Add(account);
                return Save();
          
        }



        public bool DeleteAccount(Account account)
        {
          
                _context.Accounts.Remove(account);
                return Save();
        
        }

        public Account GetAccount(int AccountID)
        {
           
                return _context.Accounts.Include(x=>x.Customer).FirstOrDefault(x => x.AccountID == AccountID);
         
        }

        public ICollection<Account> GetAccountByCustomer(int id)
        {

            //var values = _context.Accounts.Include(x => x.Customer).Where(x => x.AccountID == OriginAccountID).FirstOrDefault();
            return _context.Accounts.Include(x => x.Customer).Where(x => x.Customer.CustomerID==id).ToList();
        
        }

        public ICollection<Account> GetAccounts()
        {
          
               return _context.Accounts.Include(x=>x.Customer).OrderBy(x => x.AccountID).ToList();           
        }

        public bool Save()
        {
                        return _context.SaveChanges() >= 0 ? true : false;
           
        }

        public bool UpdateAccount(Account account)
        {
                        
            _context.Accounts.Update(account);
                return Save();

            
        }
    }
}
