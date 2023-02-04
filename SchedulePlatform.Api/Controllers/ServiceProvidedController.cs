using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class ServiceProvidedController: ControllerBase
	{
		private readonly ServiceProvidedService _serviceProvided;

		public ServiceProvidedController(ServiceProvidedService service)
		{
			_serviceProvided = service;
		}

		[HttpGet]

		public ServiceProvided[] GetAll()
		{
			return _serviceProvided.GetAll();
		}

		[HttpPost("Add")]

		public ServiceProvided Add( ServiceProvided serviceP)
		{
			return _serviceProvided.Add(serviceP);
		}
	}
}

