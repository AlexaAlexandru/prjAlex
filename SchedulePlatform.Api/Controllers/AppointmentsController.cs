using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Service.Models.AppointmentModel;
using SchedulePlatform.Service.Models;
using AutoMapper;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("allApp/{nutritionistId}")]

        public ActionResult<IEnumerable<AppointmentResponseModel>> GetAppoinmentByNutritionist(Guid nutritionistId)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<AppointmentResponseModel>>.Success(_service.GetAppointmentByNutritionist(nutritionistId)));
            }
            catch (Exception ex)
            {
                if (_service.GetAll().ToList().FirstOrDefault(n => n.NutritionistId == nutritionistId) == null)
                {
                    return NotFound(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("all/{customerId}")]

        public ActionResult<IEnumerable<AppointmentResponseModel>> GetAppointmentByCustomer(Guid customerId)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<AppointmentResponseModel>>.Success(_service.GetAppointmentByCustomer(customerId)));
            }
            catch (Exception ex)
            {
                if (_service.GetAll().ToList().FirstOrDefault(c => c.CustomerId == customerId) == null)
                {
                    return NotFound(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet]

        public ActionResult<IEnumerable<AppointmentResponseModel>> GetAppointments()
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<AppointmentResponseModel>>.Success(_service.GetAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<IEnumerable<AppointmentResponseModel>>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPost]

        public IActionResult AddAppointment(AppointmentRequestModel requestappointment)
        {
            try
            {
                return Ok(ApiGenericsResult<AppointmentResponseModel>.Success(_service.Add(requestappointment)));
            }
            catch (Exception ex)
            {

                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            if (_service.GetById(id)==null)
            {
                return NotFound();
            }
            try
            {
                return Ok(ApiGenericsResult<AppointmentResponseModel>.Success(_service.GetById(id)));
            }
            catch (Exception ex)
            {
                if (_service.GetById(id)==null)
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]

        public IActionResult Update(Guid id, AppointmentPatchModel model)
        {
            var appointmentSearch = _service.GetById(id);

            if (appointmentSearch == null)
            {
                return NotFound();
            }

            var appointmentUpdated = appointmentSearch.Map(model);

            try
            {
                return Ok(ApiGenericsResult<AppointmentResponseModel>.Success(_service.Update(appointmentUpdated)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            if (_service.GetById(id)==null)
            {
                return NotFound();
            }

            try
            {
                return Ok(ApiGenericsResult<AppointmentResponseModel>.Success(_service.Delete(id)));
            }
            catch (Exception ex)
            {
                if (_service.GetAll().ToList().First(a => a.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }

                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("free/{date}")]

        public ActionResult<List<DateTime>> GetFreeSlots(DateTime date,Guid nutritionistId)
        {
            if (_service.GetAll().ToList().FirstOrDefault(n=>n.NutritionistId==nutritionistId)==null)
            {
                return NotFound();
            }
            return _service.GetFreeSlots(date,nutritionistId);
        }
    }
}

