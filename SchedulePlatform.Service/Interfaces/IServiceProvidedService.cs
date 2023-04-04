using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.ServiceProvided;

namespace SchedulePlatform.Service.Interfaces
{
    public interface IServiceProvidedService
    {
        ServiceProvidedResponseModel Add(ServiceProvidedRequestModel serviceP);
        IEnumerable<ServiceProvidedResponseModel> GetAll();
        ServiceProvidedResponseModel GetById(Guid id);
        IEnumerable<ServiceProvidedResponseModel> GetAllServicesByNutritionistId(Guid nutritionistId);
        UpdateServiceProvidedResponseModel Update(Guid id,UpdateServiceProvidedRequestModel serviceP);
        ServiceProvidedResponseModel Delete(Guid id);
    }
}