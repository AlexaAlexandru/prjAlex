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
	}
}

