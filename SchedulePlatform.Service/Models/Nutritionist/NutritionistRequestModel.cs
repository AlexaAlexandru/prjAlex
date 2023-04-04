using System;
using System.ComponentModel.DataAnnotations;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Models.Nutritionist
{
    public class NutritionistRequestModel
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
        [MaxLength(250, ErrorMessage = "The description of the nutritionist should have less than 250 characters")]
        public string? Biography { get; set; }
        public Uri? PictureUrl { get; set; }
        public string? Address { get; set; }
        public List<NutritionistService> NutritionistService = new List<NutritionistService>();
    }
}

