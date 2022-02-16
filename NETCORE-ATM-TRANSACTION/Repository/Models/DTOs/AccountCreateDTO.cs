using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Repository.Models.DTOs
{
    public class AccountCreateDTO
    {
       
        public int CustomerID { get; set; }
        public double Balance { get; set; }
       
    }
}
