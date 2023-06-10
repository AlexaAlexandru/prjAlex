using System;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly SchedulePlatformContext _context;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(SchedulePlatformContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Customer>();

            _context.Appointments
                .Include(a => a.Customer)
                .ToList();
        }

    }
}

