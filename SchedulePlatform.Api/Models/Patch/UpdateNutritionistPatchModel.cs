using System;
namespace SchedulePlatform.Api.Models.Patch
{
	public class UpdateNutritionistPatchModel
	{
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Biography { get; set; }
        public string? Address { get; set; }
        public Uri? PictureUrl { get; set; }
        public Guid? newNutritionServiceId { get; set; }
    }
}

