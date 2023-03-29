using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        private readonly SchedulePlatformContext _context;
        private readonly DbSet<Appointment> _dbSet;

        public AppointmentRepository(SchedulePlatformContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Appointment>();
        }

        public List<Appointment> GetAllByDate(Guid nutritionistId, DateTime date)
        {
            return (List<Appointment>)_dbSet.ToList()
                .Where(n => n.NutritionistId == nutritionistId)
                .Where(n => n.StartDate == date);
        }
    }
}

