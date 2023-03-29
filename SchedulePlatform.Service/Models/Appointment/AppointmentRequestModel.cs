using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Service.Models.Appointment
{
	public class AppointmentRequestModel
    {
        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public Guid NutritionistId { get; set; }
        public Guid CustomerId { get; set; }
    }
}

