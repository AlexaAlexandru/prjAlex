using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Interfaces
{
    public interface INutritionistServiceS
    {
        Nutritionist AddNutritionist(Nutritionist nutritionist);
        Nutritionist[] GetAll();
        Nutritionist? GetById(Guid id);
        Nutritionist Update(Nutritionist nutritionist);
        Nutritionist Delete(Guid id, Nutritionist nutritionist);
    }
}