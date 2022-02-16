using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Repository.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public int BankID { get; set; }
        public virtual List<Account> Accounts { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
