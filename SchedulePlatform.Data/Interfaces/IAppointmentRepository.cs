using System;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Interfaces
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        List<Appointment> GetAllByDate(Guid nutritionistId, DateTime date);
    }
}

