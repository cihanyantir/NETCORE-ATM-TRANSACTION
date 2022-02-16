using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCORE_ATM_TRANSACTION.IService;
using NETCORE_ATM_TRANSACTION.Models;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using NETCORE_ATM_TRANSACTION.Repository.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AtmDbContext _context;
        private readonly IAccountCRUDService _accountCRUDService;
        private readonly IMapper _mapper;

        public AccountController(IAccountCRUDService accountCRUDService,IMapper mapper,AtmDbContext context)
        {
            _accountCRUDService = accountCRUDService;
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAccounts()
        {
            var objList = _accountCRUDService.GetAccounts();
            var objdto = new List<AccountDTO>();
            foreach (var obj in objList)
            {
                objdto.Add(_mapper.Map<AccountDTO>(obj));

            }
            return Ok(objdto);
        }


        [HttpGet("{AccountID:int}",Name ="GetAccount")]
        public IActionResult GetAccount(int AccountID)
        {
            var obj = _accountCRUDService.GetAccount(AccountID);
            if (obj == null)
            {
                return NotFound();
            }
            var objdto = _mapper.Map<AccountDTO>(obj); //no foreach needed just 1 column
            return Ok(objdto);
        }


        [HttpPost]
        public IActionResult CreateAccount([FromBody] AccountCreateDTO accountdto)
        {
            if (accountdto == null)
                return BadRequest(ModelState);
            //if (_accountCRUDService.AccountExists(accountdto.AccountID))
            //{
            //    ModelState.AddModelError("", "Account Exist");
            //    return StatusCode(404, ModelState);
            //             }
            var accountobj = _mapper.Map<Account>(accountdto);
            if (!_accountCRUDService.CreateAccount(accountobj))
            {
                ModelState.AddModelError("", $"Eklerken bir şeyler ters gitti  {accountobj.AccountID}");
                return StatusCode(500, ModelState);
            }
            _accountCRUDService.AddIBAN(accountobj);
            return CreatedAtRoute("GetAccount", new {AccountID=accountobj.AccountID }, accountobj);
        }

            [HttpDelete("{AccountID:int}", Name = "DeleteAccount")]
        public IActionResult DeleteAccount(int AccountID)
        { 
            if(!_accountCRUDService.AccountExists(AccountID))
            {
                return NotFound();
            }
            var AccountObj = _accountCRUDService.GetAccount(AccountID);
            if (!_accountCRUDService.DeleteAccount(AccountObj))
                {
                ModelState.AddModelError("", $"Silerken bir şeyler ters gitti  {AccountObj.AccountID}");
                return StatusCode(500, ModelState);

            }
            return NoContent();
                
               
            
           
        }

        [HttpPatch("{AccountID:int}", Name = "UpdateAccount")]
        public IActionResult UpdateAccount(int AccountID,[FromBody] AccountUpdateDTO accountDTO)
        {
            if(accountDTO==null || AccountID!=accountDTO.AccountID)
            {
                return BadRequest(ModelState);
            }
            var accountobj = _mapper.Map<Account>(accountDTO);
           
            if (!_accountCRUDService.UpdateAccount(accountobj))
            {
                ModelState.AddModelError("", $"Guncellerken bir şeyler ters gitti  {accountobj.AccountID}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
           
        }

        [HttpGet("[action]/{CustomerID:int}")]
        public IActionResult GetAccountInCustomer(int CustomerID)
        {
            var obj = _accountCRUDService.GetAccountByCustomer(CustomerID);
            if (obj == null)
            {
                return NotFound();
            }
            var objdto = new List<AccountDTO>();

            foreach (var item in obj)
            {
                objdto.Add(_mapper.Map<AccountDTO>(item));
            }

            return Ok(objdto);
        }
    }
}

