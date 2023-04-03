using System;
using System.ComponentModel.DataAnnotations;

namespace SchedulePlatform.Service.Models.Customer
{
    public class CustomerCreateModel
    {
        public Guid Id = Guid.NewGuid();
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters")]
        public string? FirstName { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters")]
        public string? LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [Range(1, 2.4, ErrorMessage = "Height should be between 1.0m  and 2.4 m ")]
        public decimal Height { get; set; }
        [Range(1,250,ErrorMessage ="Weight should be higher than 1 kg ")]
        public decimal Weight { get; set; }
        [Range(1,99,ErrorMessage ="Age should be greater than 1 year")]
        public int Age { get; set; }
        [StringLength(150, MinimumLength = 20,ErrorMessage ="Please write more than 20 characters and less than 150")]
        public string? ScopeOfAppointment { get; set; }
    }
}

