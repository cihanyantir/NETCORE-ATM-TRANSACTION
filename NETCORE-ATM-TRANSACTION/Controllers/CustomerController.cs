using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCORE_ATM_TRANSACTION.IService;
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
    public class CustomerController : ControllerBase
    {

 
       
        private readonly ICustomerCRUDService _customerCRUDService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerCRUDService customerCRUDService, IMapper mapper )
        {
            _customerCRUDService = customerCRUDService;
            _mapper = mapper;
           
        }


        [HttpGet]
        public IActionResult GetCustomers()
        {
            var objList = _customerCRUDService.GetCustomers();
            var objdto = new List<CustomerDTO>();
            foreach (var obj in objList)
            //objlistteki veriler mapper.csda maplanan classa dtodan üretilen nesneyle ekleniyor.
            //veriler dtodan çekilmiş oluyor.
            {
                objdto.Add(_mapper.Map<CustomerDTO>(obj));

            }
            return Ok(objdto);
        }


        [HttpGet("{CustomerID:int}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int CustomerID)
        {
            var objlist = _customerCRUDService.GetCustomer(CustomerID);
            if (objlist == null)
            { return NotFound(); }
            return Ok(objlist);
        }


        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerCreateDTO customerdto)
        {
            if (customerdto == null)
                return BadRequest(ModelState);
            //if (_customerCRUDService.CustomerExists(customerdto.CustomerID))
            //{
            //    ModelState.AddModelError("", "Customer Exist");
            //    return StatusCode(404, ModelState);
            //             }
            var customerobj = _mapper.Map<Customer>(customerdto);
            if (!_customerCRUDService.CreateCustomer(customerobj))
            {
                ModelState.AddModelError("", $"Eklerken bir şeyler ters gitti  {customerobj.CustomerID}");
                return StatusCode(500, ModelState);
            }
           
            return CreatedAtRoute("GetCustomer", new { CustomerID = customerobj.CustomerID }, customerobj);
        }

        [HttpDelete("{CustomerID:int}", Name = "DeleteCustomer")]
        public IActionResult DeleteCustomer(int CustomerID)
        {
            if (!_customerCRUDService.CustomerExists(CustomerID))
            {
                return NotFound();
            }
            var CustomerObj = _customerCRUDService.GetCustomer(CustomerID);
            if (!_customerCRUDService.DeleteCustomer(CustomerObj))
            {
                ModelState.AddModelError("", $"Silerken bir şeyler ters gitti  {CustomerObj.CustomerID}");
                return StatusCode(500, ModelState);

            }
            return NoContent();




        }

        [HttpPatch("{CustomerID:int}", Name = "UpdateCustomer")]
        public IActionResult UpdateCustomer(int CustomerID, [FromBody] CustomerUpdateDTO customerDTO)
        {
            if (customerDTO == null || CustomerID != customerDTO.CustomerID)
            {
                return BadRequest(ModelState);
            }
            var customerobj = _mapper.Map<Customer>(customerDTO);

            if (!_customerCRUDService.UpdateCustomer(customerobj))
            {
                ModelState.AddModelError("", $"Guncellerken bir şeyler ters gitti  {customerobj.CustomerID}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

       
    }
}

