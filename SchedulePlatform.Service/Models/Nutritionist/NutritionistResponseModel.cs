using System;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Models.Nutritionist
{
	public class NutritionistResponseModel
	{
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Biography { get; set; }
        public Uri? PictureUrl { get; set; }
        public string? Address { get; set; }
        public List<NutritionistService>? NutritionistService = new List<NutritionistService>();
    }
}

