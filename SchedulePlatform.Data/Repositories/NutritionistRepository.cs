using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
	public class NutritionistRepository: BaseRepository<Nutritionist>, INutritionistRepository
    {
        private readonly SchedulePlatformContext _context;
        private readonly DbSet<Customer> _dbSet;

        public NutritionistRepository(SchedulePlatformContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Customer>();
        }

    }

}

