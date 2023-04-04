using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Data.Repositories;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Service.Models.ServiceProvided;

namespace SchedulePlatform.Service
{
    public class ServiceProvidedService : IServiceProvidedService
    {
        private readonly IServiceProvidedRepository _serviceRepository;
        private readonly INutritionistServiceRepository _nutritionistServiceRepository;
        private readonly IMapper _mapper;
        public ServiceProvidedService(IServiceProvidedRepository serviceRepository, IMapper mapper, INutritionistServiceRepository nutritionistServiceRepository)
        {
            _serviceRepository = serviceRepository;
            _nutritionistServiceRepository = nutritionistServiceRepository;
            _mapper = mapper;
        }

        public IEnumerable<ServiceProvidedResponseModel> GetAll()
        {
            var allServices = _serviceRepository.GetAll();

            return _mapper.Map<IEnumerable<ServiceProvidedResponseModel>>(allServices);
        }

        public ServiceProvidedResponseModel Add(ServiceProvidedRequestModel serviceP)
        {
            var serviceToAdd = _mapper.Map<ServiceProvided>(serviceP);

            _serviceRepository.Add(serviceToAdd);

            return _mapper.Map<ServiceProvidedResponseModel>(serviceToAdd);
        }

        public ServiceProvidedResponseModel GetById(Guid id)
        {
            var findService = _serviceRepository.GetById(id);

            return _mapper.Map<ServiceProvidedResponseModel>(findService);
        }

        public IEnumerable<ServiceProvidedResponseModel> GetAllServicesByNutritionistId(Guid nutritionistId)
        {
            if (_nutritionistServiceRepository.GetAll().ToList().Find(n=>n.NutritionistId==nutritionistId)==null)
            {
                throw new Exception("The nutrionist has no related services");
            }

            var fullList = _nutritionistServiceRepository.GetAll().ToList();
            var allServices = _nutritionistServiceRepository.GetAll().ToList().Where(n => n.NutritionistId == nutritionistId);
            var tempList = allServices.Select(l => l.ServiceId).ToList();

            var tempListServices = new List<NutritionistService>();

            foreach (var item in fullList)
            {
                foreach (var id in tempList)
                {
                    if (item.ServiceId==id)
                    {
                        tempListServices.Add(item);
                    }
                }
            }

            return _mapper.Map<IEnumerable<ServiceProvidedResponseModel>>(tempListServices);
        }

        public UpdateServiceProvidedResponseModel Update(Guid id, UpdateServiceProvidedRequestModel serviceP)
        {
            var findService = _serviceRepository.GetById(id);

            if (!string.IsNullOrEmpty(serviceP.Description))
            {
                findService.Description = serviceP.Description;
            }

            if (!string.IsNullOrEmpty(serviceP.NameServiceProvided))
            {
                findService.NameServiceProvided = serviceP.NameServiceProvided;
            }

            if (serviceP.UrlPicture != null)
            {
                findService.UrlPicture = serviceP.UrlPicture;
            }

            if (serviceP.Price.HasValue)
            {
                findService.Price = (double)serviceP.Price;
            }

            _serviceRepository.Update(findService);

            return new UpdateServiceProvidedResponseModel
            {
                Id = findService.Id,
                Description = findService.Description,
                NameServiceProvided = findService.NameServiceProvided,
                Price = findService.Price,
                Type = findService.Type,
                UrlPicture = findService.UrlPicture
            };
        }

        public ServiceProvidedResponseModel Delete(Guid id)
        {
            var findService = _serviceRepository.GetById(id);
            _serviceRepository.Delete(findService);

            return _mapper.Map<ServiceProvidedResponseModel>(findService);
        }
    }
}

