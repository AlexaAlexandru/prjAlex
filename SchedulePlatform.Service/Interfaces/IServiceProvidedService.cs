using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Interfaces
{
    public interface IServiceProvidedService
    {
        ServiceProvided Add(ServiceProvided serviceP);
        ServiceProvided[] GetAll();
        ServiceProvided? GetById(Guid id);
        ServiceProvided Update(ServiceProvided serviceP);
        ServiceProvided Delete(Guid id, ServiceProvided serviceP);
    }
}