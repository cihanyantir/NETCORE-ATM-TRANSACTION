using NETCORE_ATM_TRANSACTION.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Repository.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
