using NETCORE_ATM_TRANSACTION.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Repository.Models
{
    public class Account
    {[Key]
        public int AccountID { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        public double Balance { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
        public string IBAN { get; set; }
    }
}
