using System;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Models.Entities
{
    public class ServiceProvided : BaseEntity
    {
        public string? Description { get; set; }
        public string? NameServiceProvided { get; set; }
        public Uri? UrlPicture { get; set; }
        public ConsultationType Type { get; set; }
        public double Price { get; set; }
        public List<NutritionistService>? NutritionistService { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}

