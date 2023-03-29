using System;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Data.Repositories;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;

namespace SchedulePlatform.Service
{
    public class ServiceProvidedService : IServiceProvidedService
    {
        private readonly IServiceProvidedRepository _serviceRepository;

        public ServiceProvidedService(IServiceProvidedRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public List<ServiceProvided> GetAll()
        {
            return _serviceRepository.GetAll();
        }

        public ServiceProvided Add(ServiceProvided serviceP)
        {
            var serviceToAdd = new ServiceProvided
            {
                Id = Guid.NewGuid(),
                Description = serviceP.Description,
                NameServiceProvided = serviceP.NameServiceProvided,
                Price = serviceP.Price,
                Type = serviceP.Type,
                UrlPicture = serviceP.UrlPicture
            };

            return _serviceRepository.Add(serviceToAdd);
        }

        public ServiceProvided? GetById(Guid id)
        {
            return _serviceRepository.GetById(id);
        }

        public ServiceProvided Update(ServiceProvided serviceP)
        {
            return _serviceRepository.Update(serviceP);
        }

        public ServiceProvided Delete(Guid id, ServiceProvided serviceP)
        {
            return _serviceRepository.Delete(id, serviceP);
        }

    }
}

