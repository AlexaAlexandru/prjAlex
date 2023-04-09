using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Shared.Models
{
	public class AppointmentRequest
	{
        public Guid Id = Guid.NewGuid();
        public string? StartDate { get; set; }
        public Boolean? IsOnSite { get; set; } = true;
        public TypeAppointment Type { get; set; } = TypeAppointment.ToDo;
        public Guid NutritionistId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ServiceProvidedId { get; set; }
    }
}

