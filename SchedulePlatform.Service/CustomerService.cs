using System;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Data.Repositories;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;

namespace SchedulePlatform.Service
{
	public class CustomerService: ICustomerService 
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService( ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

        public Customer[] GetAllCustomers()
		{
			return _customerRepository.GetAll();
		}

        public Customer AddCustomer(Customer customer)
        {
            var customerToAdd = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Age = customer.Age,
                Email = customer.Email,
                Phone = customer.Phone,
                Height = customer.Height,
                Weight = customer.Weight,
                ScopeOfAppointment = customer.ScopeOfAppointment
            };

            return _customerRepository.AddCustomer(customerToAdd);
        }

        public Customer? GetById(Guid id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public Customer Delete(Guid id,Customer customer)
        {
            return _customerRepository.Delete(id,customer);
        }
    }
}

