using System;
namespace SchedulePlatform.Models.Entities
{
    public class NutritionistService : BaseEntity
    {
        public Guid NutritionistId { get; set; }
        public Nutritionist Nutritionist { get; set; }
        public Guid ServiceId { get; set; }
        public ServiceProvided Service { get; set; }
    }
}

