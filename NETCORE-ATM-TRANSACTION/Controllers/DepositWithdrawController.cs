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
    [Route("api/depositwithdraw")]
    [ApiController]
    public class DepositWithdrawController : Controller
    {

        private IGenericServiceDepositWithdraw<Account> _IGenericServiceDepositWithdraw;

        public DepositWithdrawController(IGenericServiceDepositWithdraw<Account> ıGenericServicetransfer)
        {
            _IGenericServiceDepositWithdraw = ıGenericServicetransfer;
        }
        

        [Route("deposit/{OriginAccountID}/{amount}")]
        [HttpPost]

        public IActionResult Deposit(int OriginAccountID, double amount)
        {


            return Ok(_IGenericServiceDepositWithdraw.DepositProcess(OriginAccountID, amount));
        }



        [Route("withdrawal/{OriginAccountID}/{amount}")]
        [HttpPost]

        public IActionResult WithDrawal(int OriginAccountID, double amount)
        {

            if (_IGenericServiceDepositWithdraw.EnoughBalance(OriginAccountID, amount) == false)
            {
                ModelState.AddModelError("", "Bakiye Yetersiz");
                return StatusCode(404, ModelState);
            }


            return Ok(_IGenericServiceDepositWithdraw.WithDrawProcess(OriginAccountID, amount));
        }

    }
}

