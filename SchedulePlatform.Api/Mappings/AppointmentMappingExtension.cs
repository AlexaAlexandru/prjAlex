using System;
using SchedulePlatform.Api.Models;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Api.Mappings
{
    public static class AppointmentMappingExtension
    {
        public static Appointment Map(this Appointment appointment, AppointmentPatchModel model)
        {
            if (model.StartDate.HasValue)
            {
                appointment.StartDate = (DateTime)model.StartDate;
            }
            if (model.EndDate.HasValue)
            {
                appointment.EndDate = (DateTime)model.EndDate;
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

