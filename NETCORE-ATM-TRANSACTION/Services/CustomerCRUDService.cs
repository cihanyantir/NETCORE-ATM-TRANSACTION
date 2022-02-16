using Microsoft.EntityFrameworkCore;
using NETCORE_ATM_TRANSACTION.IService;
using NETCORE_ATM_TRANSACTION.Models;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using SinKien.IBAN4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Services
{
    public class CustomerCRUDService :ICustomerCRUDService
    {
        private readonly AtmDbContext _context;

        public CustomerCRUDService(AtmDbContext context)
        {
            _context = context;
        }

        public bool CustomerExists(int id)
        {
            var values = _context.Customers;

            return _context.Customers.Any(x => x.CustomerID == id);
        }

        

        public bool CreateCustomer(Customer Customer)
        {

            Customer.MembershipDate = DateTime.UtcNow;
            _context.Customers.Add(Customer);
            return Save();

        }

        public bool DeleteCustomer(Customer Customer)
        {

            _context.Customers.Remove(Customer);
            return Save();

        }

        public Customer GetCustomer(int CustomerID)
        {

            return _context.Customers.Include(x=>x.Accounts).FirstOrDefault(x => x.CustomerID == CustomerID);

        }

    
        public ICollection<Customer> GetCustomers()
        {

            return _context.Customers.Include(x => x.Accounts).OrderBy(x => x.CustomerID).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;

        }

        public bool UpdateCustomer(Customer Customer)
        {

            _context.Customers.Update(Customer);
            return Save();


        }
    }
}

