using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Customer AddCustomer(Customer customer);
        Customer[] GetAll();
        Customer? GetById(Guid id);
        Customer Update(Customer customer);
        Customer Delete(Guid id,Customer customer);
    }
}