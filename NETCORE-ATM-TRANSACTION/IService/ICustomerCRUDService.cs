using NETCORE_ATM_TRANSACTION.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.IService
{
    public interface ICustomerCRUDService
    {

        ICollection<Customer> GetCustomers();
        Customer GetCustomer(int CustomerID);
        bool CustomerExists(int id);
        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);     
        bool Save();
    }
}
