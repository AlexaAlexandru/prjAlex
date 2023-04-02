using System;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Customer;

namespace SchedulePlatform.Service.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);
        Customer GetById(Guid id);
        Customer? Update(Customer customer);
        Customer Delete(Guid id, Customer customer);
    }
}

