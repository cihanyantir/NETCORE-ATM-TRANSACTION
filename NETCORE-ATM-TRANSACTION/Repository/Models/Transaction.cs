using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Repository.Models
{

    public enum TransactionType
    {
        Deposit = 'D',
        Withdrawal = 'W',
        Transfer = 'T'
    }

    public class Transaction

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransactionID { get; set; }
        public virtual Account Account { get; set; }
        public int AccountID { get; set; }
        public char TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}