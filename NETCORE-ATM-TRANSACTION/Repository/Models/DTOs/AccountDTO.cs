using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Repository.Models.DTOs
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
       public CustomerDTO Customer { get; set; }
        public double Balance { get; set; }
        public DateTime CreateDate { get; set; }
       
        public string IBAN { get; set; }
    }
}
