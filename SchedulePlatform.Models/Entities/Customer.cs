using System.ComponentModel.DataAnnotations;

namespace SchedulePlatform.Models.Entities
{
    public class Customer: BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string? ScopeOfAppointment { get; set; }
        public List<Appointment> Appointments { get; set; }

    }

}

