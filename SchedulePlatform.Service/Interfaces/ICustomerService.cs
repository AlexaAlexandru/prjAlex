using System;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);
        Customer? GetById(Guid id);
        Customer Update(Customer customer);
        Customer Delete(Guid id, Customer customer);
    }
}

