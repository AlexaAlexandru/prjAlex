using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Api.Models.Patch
{
    public class AppointmentPatchModel
    {
        public DateTime? StartDate { get; set; }
        public Boolean? IsOnSite { get; set; }
        public TypeAppointment? Type { get; set; }
    }
}

