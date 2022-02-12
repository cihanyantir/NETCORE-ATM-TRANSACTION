using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCORE_ATM_TRANSACTION.IService;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : GenericController<Customer>
    {
        public TransactionController(IGenericServiceTransfer<Customer> _IGenericServicetransfer) :base (_IGenericServicetransfer)
        {

        }
    }
}
