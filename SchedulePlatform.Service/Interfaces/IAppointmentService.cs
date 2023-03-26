using System;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Interfaces
{
    public interface IAppointmentService
    {
        Appointment[] GetAll();
        Appointment Add(Appointment appointment);
        Appointment? GetById(Guid id);
        Appointment Update(Appointment appointment);
        Appointment Delete(Guid id, Appointment appointment);
        IEnumerable<DateTime> GetFreeSlots(DateTime date);
    }
}

