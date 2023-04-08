using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
    public class NutritionistRepository : BaseRepository<Nutritionist>, INutritionistRepository
    {
        private readonly SchedulePlatformContext _context;
        private readonly DbSet<Nutritionist> _dbSet;

        public NutritionistRepository(SchedulePlatformContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Nutritionist>();

            var listServices = _context.NutritionistServices
                .Include(s => s.Nutritionist)
                .ToList();

            var listAppointments = _context.Appointments
                .Include(a => a.Nutritionist)
                .ToList();
        }

    }

}

