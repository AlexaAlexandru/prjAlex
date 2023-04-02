using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Nutritionist;

namespace SchedulePlatform.Service.Interfaces
{
    public interface INutritionistServiceS
    {
        NutritionistResponseModel AddNutritionist(NutritionistRequestModel nutritionist);
        IEnumerable<NutritionistResponseModel> GetAll();
        NutritionistResponseModel GetById(Guid id);
        UpdateNutritionistResponseModel Update(UpdateNutritionistRequestModel nutritionist);
        NutritionistResponseModel Delete(Guid id);
    }
}