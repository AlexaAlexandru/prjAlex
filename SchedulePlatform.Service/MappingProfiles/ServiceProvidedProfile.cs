using System;
using AutoMapper;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.ServiceProvided;

namespace SchedulePlatform.Service.MappingProfiles
{
	public class ServiceProvidedProfile:Profile
	{
		public ServiceProvidedProfile()
		{
			CreateMap<ServiceProvided, ServiceProvidedResponseModel>();
			CreateMap<ServiceProvidedRequestModel, ServiceProvided>();
		}
	}
}

