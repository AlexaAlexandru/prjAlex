using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
	public class ServiceProvidedRepository
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
            var serviceAdd = new ServiceProvided
            {
                Id = Guid.NewGuid(),
                Description = serviceP.Description,
                NameServiceProvided = serviceP.NameServiceProvided,
                UrlPicture = serviceP.UrlPicture,
                Type=serviceP.Type,
                Price=serviceP.Price
            };

            _dbSet.Add(serviceAdd);
            _context.SaveChanges();

            return serviceAdd;
        }
    }
}

