using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.IService
{
    public interface IGenericServiceTransfer<T>
    {
        T Transaction(int OriginAccountID, int TargetAccountID, double amount);
        bool EftHavaleCheck(int OriginAccountID, int TargetAccountID);
        bool EnoughBalance(int OriginAccountID, double amount);
    }
}
