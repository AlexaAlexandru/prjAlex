using System;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
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
            
            _dbSet.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer? GetById(Guid id)
        {
            return _dbSet.FirstOrDefault((Customer customer) => customer.Id == id);
        }

        public Customer Update(Customer customer)
        {
            _dbSet.Update(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer Delete(Guid id,Customer customer)
        {
            var findCustomer = _dbSet.First((Customer c) => c.Id == id);

            _dbSet.Remove(findCustomer);
            _context.SaveChanges();

            return customer;
        }

    }
}

