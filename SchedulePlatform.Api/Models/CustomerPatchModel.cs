using System;
namespace SchedulePlatform.Api.Models
{
	public class CustomerPatchModel
	{
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int? Age { get; set; }
        public string? ScopeOfAppointment { get; set; }

    }
}

