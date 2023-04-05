using System;
namespace SchedulePlatform.Service.Models.Customer
{
	public class UpdateCustomerResponseModel
	{
        public Guid? Id { get; set; }
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

