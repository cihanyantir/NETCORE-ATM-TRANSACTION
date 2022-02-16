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
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : Controller
    {
        private IGenericServiceTransfer<Account> _IGenericServicetransfer;

        public TransactionController(IGenericServiceTransfer<Account> ıGenericServicetransfer)
        {
            _IGenericServicetransfer = ıGenericServicetransfer;
        }


        [Route("eft/{OriginAccountID}/{TargetAccountID}/{amount}")]
        [HttpPost]

        public IActionResult TransactionEFT(int OriginAccountID, int TargetAccountID, double amount)
        {
            if (_IGenericServicetransfer.EnoughBalance(OriginAccountID, amount) == false)
            {
                ModelState.AddModelError("", "Bakiye Yetersiz");
                //return StatusCode(404, ModelState);
                return BadRequest("Bakiye Yetersiz");
            }
            if (_IGenericServicetransfer.EftHavaleCheck(OriginAccountID, TargetAccountID) == true)
            {
                //ModelState.AddModelError("", "Bu hesaba Havale işlemi yapabilirsiniz.");
                //return StatusCode(404, ModelState);
                return BadRequest("Bu hesaba Havale işlemi yapabilirsiniz.");
            }
            return Ok(_IGenericServicetransfer.Transaction(OriginAccountID, TargetAccountID, amount));
        }
        [Route("havale/{OriginAccountID}/{TargetAccountID}/{amount}")]
        [HttpPost]
        public IActionResult TransactionHavale(int OriginAccountID, int TargetAccountID, double amount)
        {
            if (_IGenericServicetransfer.EnoughBalance(OriginAccountID, amount) == false)
            {
                ModelState.AddModelError("", "Bakiye Yetersiz");
                return StatusCode(404, ModelState);
            }
            if (_IGenericServicetransfer.EftHavaleCheck(OriginAccountID, TargetAccountID) == false)
            {
                ModelState.AddModelError("", "Bu hesaba EFT işlemi yapabilirsiniz.");
                return StatusCode(404, ModelState);
            }
            return Ok(_IGenericServicetransfer.Transaction(OriginAccountID, TargetAccountID, amount));
        }


    }
}
