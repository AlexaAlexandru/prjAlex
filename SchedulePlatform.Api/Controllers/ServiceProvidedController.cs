using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Service.Models;
using SchedulePlatform.Service.Models.ServiceProvided;

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

        public ActionResult<IEnumerable<ServiceProvidedResponseModel>> GetAll()
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ServiceProvidedResponseModel>>.Success(_serviceProvidedService.GetAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ServiceProvidedResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPost()]

        public IActionResult Add(ServiceProvidedRequestModel serviceP)
        {
            try
            {
                return Ok(ApiGenericsResult<ServiceProvidedResponseModel>.Success(_serviceProvidedService.Add(serviceP)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ServiceProvidedResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            if (_serviceProvidedService.GetById(id) == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(ApiGenericsResult<ServiceProvidedResponseModel>.Success(_serviceProvidedService.GetById(id)));
            }
            catch (Exception ex)
            {
                if (_serviceProvidedService.GetById(id) == null)
                {
                    return NotFound(ApiGenericsResult<ServiceProvidedResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ServiceProvidedResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("all/{nutritionistId}")]

        public ActionResult<IEnumerable<ServiceProvidedResponseModel>> GetAllServicesByNutritionistId(Guid nutritionistId)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ServiceProvidedResponseModel>>.Success(_serviceProvidedService.GetAllServicesByNutritionistId(nutritionistId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ServiceProvidedResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPatch]

        public IActionResult Update(Guid id, UpdateServiceProvidedRequestModel model)
        {
            if (_serviceProvidedService.GetById(id) == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(ApiGenericsResult<UpdateServiceProvidedResponseModel>.Success(_serviceProvidedService.Update(id, model)));
            }
            catch (Exception ex)
            {
                if (_serviceProvidedService.GetById(id) == null)
                {
                    return NotFound(ApiGenericsResult<ServiceProvidedResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ServiceProvidedResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            if (_serviceProvidedService.GetById(id) == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(ApiGenericsResult<ServiceProvidedResponseModel>.Success(_serviceProvidedService.Delete(id)));
            }
            catch (Exception ex)
            {
                if (_serviceProvidedService.GetById(id) == null)
                {
                    return NotFound(ApiGenericsResult<ServiceProvidedResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ServiceProvidedResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

    }
}

