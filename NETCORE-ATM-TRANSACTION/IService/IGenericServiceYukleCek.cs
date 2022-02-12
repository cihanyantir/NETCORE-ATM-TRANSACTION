using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.IService
{
   public interface IGenericServiceYukleCek<T>
    {
        T TransactionYukle(int fromaccount, double amount);
        T TransactionCek(int fromaccount, double amount);
    }
}
