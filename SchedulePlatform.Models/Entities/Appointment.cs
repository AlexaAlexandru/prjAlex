using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Models.Entities
{
	public class Appointment:BaseEntity
	{
		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public Boolean IsOnSite { get; set; }

		public TypeAppointment Type { get; set; }

		public Guid NutritionistId { get; set; }

		public Nutritionist Nutritionist { get; set; }

		public Guid CustomerId { get; set; }

		public Customer Customer { get; set; }
	}
}

