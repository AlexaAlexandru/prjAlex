using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Service.Models.Appointment
{
	public class AppointmentRequestModel
    {
        public DateTime? StartDate { get; set; }
        public Boolean IsOnSite { get; set; } = true;
        public TypeAppointment Type { get; set; } = TypeAppointment.ToDo;
        public Guid NutritionistId { get; set; }
        public Guid CustomerId { get; set; }

    }
}

