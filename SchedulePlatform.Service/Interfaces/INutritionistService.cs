using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Nutritionist;
using SchedulePlatform.Service.Models.PatchModel;

namespace SchedulePlatform.Service.Interfaces
{
    public interface INutritionistServiceS
    {
        NutritionistResponseModel AddNutritionist(NutritionistRequestModel nutritionist);
        IEnumerable<NutritionistResponseModel> GetAll();
        NutritionistResponseModel GetById(Guid id);
        UpdateNutritionistResponseModel Update(Guid id,UpdateNutritionistRequestModel nutritionist);
        NutritionistResponseModel Delete(Guid id);
    }
}