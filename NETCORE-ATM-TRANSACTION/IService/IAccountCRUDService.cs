using NETCORE_ATM_TRANSACTION.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.IService
{
    public interface IAccountCRUDService
    {
        ICollection<Account> GetAccounts();
        Account GetAccount(int AccountID);
        bool AccountExists(int id);
        bool AccountExists(string IBAN);
        bool CreateAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(Account account);
        ICollection<Account> GetAccountByCustomer(int id);
        void AddIBAN(Account account);
        bool Save();
    }
}
