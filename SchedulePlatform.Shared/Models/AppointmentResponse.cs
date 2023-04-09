using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Shared.Models
{
	public class AppointmentResponse
	{
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public Boolean? IsOnSite { get; set; }
        public TypeAppointment Type { get; set; }
        public Guid NutritionistId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ServiceProvidedId { get; set; }
    }
}

