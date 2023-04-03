using System;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Customer;

namespace SchedulePlatform.Service.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        CustomerResponseModel AddCustomer(CustomerCreateModel customer);
        CustomerResponseModel GetById(Guid id);
        UpdateCustomerResponseModel? Update(UpdateCustomerRequestModel model);
        CustomerResponseModel Delete(Guid id);
    }
}

