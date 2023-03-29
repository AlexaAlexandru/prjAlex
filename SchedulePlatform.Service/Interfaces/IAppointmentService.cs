using System;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Appointment;

namespace SchedulePlatform.Service.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentResponseModel> GetAll();
        AppointmentResponseModel Add(AppointmentRequestModel appointment);
        Appointment GetById(Guid id);
        Appointment Update(Appointment appointment);
        Appointment Delete(Guid id, Appointment appointment);
        List<DateTime> GetFreeSlots(DateTime date);
        IEnumerable<AppointmentResponseModel>GetAllByDate(Guid nutritionistId, DateTime date);
    }
}

