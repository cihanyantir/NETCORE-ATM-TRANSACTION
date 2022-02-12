using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.IService
{
    public interface IGenericServiceTransfer<T>
    {
        T TransactionEFT(int fromaccount, int toaccount, double amount);
        T TransactionHavale(int fromaccount, int toaccount, double amount);
        bool EftHavaleCheck(int fromaccount, int toaccount);
        bool EnoughBalance(int fromaccount, double amount);
    }
}
