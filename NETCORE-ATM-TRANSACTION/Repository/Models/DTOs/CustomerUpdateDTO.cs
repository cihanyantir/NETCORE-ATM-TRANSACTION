using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Repository.Models.DTOs
{
    public class CustomerUpdateDTO
    {
        public int CustomerID { get; set; }
        public int BankID { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
