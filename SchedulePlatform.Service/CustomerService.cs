using System;
using SchedulePlatform.Data.Repositories;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service
{
	public class CustomerService
	{
		private readonly CustomerRepository _customerRepository;

		public CustomerService( CustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

        public Customer[] GetAllCustomers()
		{
			return _customerRepository.GetAll();
		}

        public Customer AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public Customer GetById(Guid id)
        {
            return _customerRepository.GetById(id);
        }
    }
}

