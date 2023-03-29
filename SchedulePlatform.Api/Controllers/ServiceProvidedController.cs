using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service;
using SchedulePlatform.Service.Interfaces;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class ServiceProvidedController : ControllerBase
    {
        private readonly IServiceProvidedService _serviceProvidedService;

        public ServiceProvidedController(IServiceProvidedService service)
        {
            _serviceProvidedService = service;
        }

        [HttpGet]

        public ServiceProvided[] GetAll()
        {
            return _serviceProvidedService.GetAll();
        }

        [HttpPost()]

        public ServiceProvided Add(ServiceProvided serviceP)
        {
            return _serviceProvidedService.Add(serviceP);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var serviceResult = _serviceProvidedService.GetById(id);

            if (serviceResult == null)
            {
                NotFound();
            }

            return Ok(serviceResult);
        }

        [HttpPatch]

        public IActionResult Update(Guid id, ServiceProvidedPatchModel model)
        {
            var findService = _serviceProvidedService.GetById(id);

            if (findService == null)
            {
                return NotFound();
            }

            var serviceUpdated = findService.Map(model);

            return Ok(_serviceProvidedService.Update(serviceUpdated));
        }

        [HttpDelete]

        public IActionResult Delete(Guid id, ServiceProvided serviceP)
        {
            var findService = _serviceProvidedService.GetById(id);

            if (findService == null)
            {
                return NotFound();
            }

            return Ok(_serviceProvidedService.Delete(id, serviceP));
        }

    }
}

