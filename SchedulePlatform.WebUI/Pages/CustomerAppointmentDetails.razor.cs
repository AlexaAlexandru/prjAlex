using System;
using System.ComponentModel.DataAnnotations;
using SchedulePlatform.WebUI.Validations;
namespace SchedulePlatform.WebUI.Pages
{
    public partial class Customer
    {
        [Required]
        [FirstLastNameLength(Value = 3, ErrorMessage = "First name should be at least 3 characters")]
        public string? FirstName { get; set; }
        [Required]
        [FirstLastNameLength(Value = 3, ErrorMessage = "Last name should have at least 3 characters")]
        public string? LastName { get; set; }
        [Required]
        [EmailLength(Value = 3, ErrorMessage = "The email should at least 3 characters")]
        public string? Email { get; set; }
        [Required]
        [PhoneLength(Value = 9, ErrorMessage = "Phone number should be 10 digits")]
        public string? Phone { get; set; }
        [Required]
        public decimal? Height { get; set; }
        [Required]
        public decimal? Weight { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        [ScopeOfAppointmentMinLength(Value = 20, ErrorMessage = "Please write more than 20 characters")]
        [ScopeOfAppointmentMaxLength(Value = 150, ErrorMessage = "Please write less than 150 characters")]
        public string? ScopeOfAppointment { get; set; }
        [Required]
        public List<Appointment>? Appointments { get; set; }
    }
}

