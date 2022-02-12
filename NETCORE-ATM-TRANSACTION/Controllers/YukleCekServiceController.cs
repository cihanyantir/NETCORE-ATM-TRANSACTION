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
    public class YukleCekServiceController : GenericController<Customer>
    {
        public YukleCekServiceController(IGenericServiceYukleCek<Customer> _IGenericServicetransfer) : base(_IGenericServicetransfer)
        {

        }
    }
}
