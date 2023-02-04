using System;
using SchedulePlatform.Data.Repositories;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service
{
	public class ServiceProvidedService
	{
		private readonly ServiceProvidedRepository _serviceRepository;

		public ServiceProvidedService(ServiceProvidedRepository serviceRepository)
		{
			_serviceRepository = serviceRepository;
		}

        public ServiceProvided[] GetAll()
        {
			return _serviceRepository.GetAll();
        }

        public ServiceProvided Add( ServiceProvided serviceP)
        {
            return _serviceRepository.Add(serviceP);
        }
    }
}

