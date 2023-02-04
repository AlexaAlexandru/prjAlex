using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
	public class CustomerRepository
    {
        private readonly SchedulePlatformContext _context;
		private readonly DbSet<Customer> _dbSet;

		public CustomerRepository(SchedulePlatformContext context)
		{
			_context = context;
			_dbSet = context.Set<Customer>();
		}
	
		public Customer[] GetAll()
		{
			return _dbSet.ToArray();
        }

        public Customer AddCustomer(Customer customer)
        {
            var customerToAdd = new Customer
            {
                Id= Guid.NewGuid(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Age = customer.Age,
                Email = customer.Email,
                Phone = customer.Phone,
                Height = customer.Height,
                Weight= customer.Weight,
                ScopeOfAppointment= customer.ScopeOfAppointment
            };

            _dbSet.Add(customerToAdd);
            _context.SaveChanges();
            return customerToAdd;
        }

        public Customer GetById(Guid id)
        {
            return _dbSet.FirstOrDefault((Customer customer) => customer.Id==id);
        }
    }
}

