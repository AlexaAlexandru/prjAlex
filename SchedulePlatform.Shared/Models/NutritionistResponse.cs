using System;
namespace SchedulePlatform.Shared.Models
{
    public class NutritionistResponse
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Biography { get; set; }
        public Uri? PictureUrl { get; set; }
        public string? Address { get; set; }
    }
}

