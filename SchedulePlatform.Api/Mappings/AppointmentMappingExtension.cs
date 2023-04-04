using System;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Appointment;

namespace SchedulePlatform.Api.Mappings
{
    public static class AppointmentMappingExtension
    {
        public static AppointmentResponseModel Map(this AppointmentResponseModel appointment, AppointmentPatchModel model)
        {
            if (model.StartDate.HasValue)
            {
                appointment.StartDate = (DateTime)model.StartDate;
            }
            if (model.Type != null)
            {
                appointment.Type = (SchedulePlatform.Models.Enums.TypeAppointment)model.Type;
            }
            if (model.IsOnSite != null)
            {
                appointment.IsOnSite = (bool)model.IsOnSite;
            }

            return appointment;
        }
    }
}

