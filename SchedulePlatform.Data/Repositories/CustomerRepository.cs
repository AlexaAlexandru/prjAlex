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
	}
}

