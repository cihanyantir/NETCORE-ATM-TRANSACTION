using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCORE_ATM_TRANSACTION.IService;
using NETCORE_ATM_TRANSACTION.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T>: Controller where T:class


    {
        private IGenericServiceYukleCek<T> _IGenericServiceYukleCek;
        private IGenericServiceTransfer<T> _IGenericServicetransfer;
        public GenericController(IGenericServiceTransfer<T> genericServicetransfer)
        {
            _IGenericServicetransfer = genericServicetransfer;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        public GenericController(IGenericServiceYukleCek<T> genericServiceYukleCek)
        {
            _IGenericServiceYukleCek = genericServiceYukleCek;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
       
        public IActionResult TransactionEFT(int fromaccount, int toaccount, double amount)
        {
            if (_IGenericServicetransfer.EnoughBalance(fromaccount,amount)==false)
            {
                ModelState.AddModelError("" ,"Bakiye Yetersiz");
                return StatusCode(404, ModelState);
            }
            if(_IGenericServicetransfer.EftHavaleCheck(fromaccount, toaccount)==false)
            {
                ModelState.AddModelError("", "Bu hesaba EFT işlemi yapabilirsiniz.");
                return StatusCode(404, ModelState);
            }
            return Ok(_IGenericServicetransfer.TransactionEFT(fromaccount,toaccount, amount));
        }


    }
}
