﻿using System;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.AppointmentModel;

namespace SchedulePlatform.Service.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentResponseModel> GetAll();
        AppointmentResponseModel Add(AppointmentRequestModel appointment);
        AppointmentResponseModel GetById(Guid id);
        AppointmentResponseModel Update(AppointmentResponseModel appointment);
        AppointmentResponseModel Delete(Guid id);
        List<DateTime> GetFreeSlots(DateTime date,Guid nutritionistId);
        IEnumerable<AppointmentResponseModel> GetAppointmentByNutritionist(Guid nutritionistId);
        IEnumerable<AppointmentResponseModel> GetAppointmentByCustomer(Guid customerId);
    }
}

