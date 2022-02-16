using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.IService
{
   public interface IGenericServiceDepositWithdraw<T>
    {
        T WithDrawProcess(int OriginAccountID, double amount);
        T DepositProcess(int OriginAccountID, double amount);
        bool EnoughBalance(int OriginAccountID, double amount);
    }
}
