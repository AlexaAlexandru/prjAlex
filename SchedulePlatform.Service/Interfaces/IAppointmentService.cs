using System;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Appointment;

namespace SchedulePlatform.Service.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentResponseModel> GetAll();
        AppointmentResponseModel Add(AppointmentRequestModel appointment);
        AppointmentResponseModel GetById(Guid id);
        AppointmentResponseModel Update(AppointmentResponseModel appointment);
        AppointmentResponseModel Delete(Guid id);
        List<DateTime> GetFreeSlots(DateTime date);
        IEnumerable<AppointmentResponseModel> GetAppointmentByNutritionist(Guid nutritionistId);
        IEnumerable<AppointmentResponseModel> GetAppointmentByCustomer(Guid customerId);
    }
}

