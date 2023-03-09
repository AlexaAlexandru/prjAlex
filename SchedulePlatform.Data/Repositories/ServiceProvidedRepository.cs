using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
    public class ServiceProvidedRepository : BaseRepository<ServiceProvided>, IServiceProvidedRepository
    {
        private readonly SchedulePlatformContext _context;
        private readonly DbSet<ServiceProvided> _dbSet;

        public ServiceProvidedRepository(SchedulePlatformContext context):base (context)
        {
            _context = context;
            _dbSet = context.Set<ServiceProvided>();
        }
    }
}

