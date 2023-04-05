using System;
using System.Reflection.Metadata.Ecma335;

namespace SchedulePlatform.Models.Entities
{
    public class Nutritionist : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Biography { get; set; }
        public Uri? PictureUrl { get; set; }
        public string? Address { get; set; }
        public List<NutritionistService>? NutritionistService { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}

