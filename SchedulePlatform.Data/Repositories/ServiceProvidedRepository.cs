using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
    public class ServiceProvidedRepository : IServiceProvidedRepository
    {
        private readonly SchedulePlatformContext _context;
        private readonly DbSet<ServiceProvided> _dbSet;

        public ServiceProvidedRepository(SchedulePlatformContext context)
        {
            _context = context;
            _dbSet = context.Set<ServiceProvided>();
        }

        public ServiceProvided[] GetAll()
        {
            return _dbSet.ToArray();
        }

        public ServiceProvided Add(ServiceProvided serviceP)
        {
            _dbSet.Add(serviceP);
            _context.SaveChanges();

            return serviceP;
        }

        public ServiceProvided? GetById(Guid id )
        {
            return _dbSet.FirstOrDefault((ServiceProvided s) => s.Id == id);
        }

        public ServiceProvided Update(ServiceProvided serviceP)
        {
            _dbSet.Update(serviceP);
            _context.SaveChanges();

            return serviceP;
        }

        public ServiceProvided Delete(Guid id, ServiceProvided serviceP)
        {
            var findService = _dbSet.First((ServiceProvided s) => s.Id == id);
            _dbSet.Remove(findService);
            _context.SaveChanges();

            return serviceP;
        }
    }
}

