using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Service.Models.Appointment;
using SchedulePlatform.Service.Models;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet("{NutritionistId}/{DateOfAppoitments}")]

        public ActionResult<IEnumerable<AppointmentResponseModel>> GetAppoinmentsByDate(Guid nutritionistId, DateTime date)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<AppointmentResponseModel>>.Success(_service.GetAllByDate(nutritionistId, date)));
            }
            catch (Exception ex)
            {
                if (_service.GetAll().ToList().First(a=> a.NutritionistId==nutritionistId)==null)
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

        [HttpGet("{Id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<Appointment>.Success(_service.GetById(id)));
            }
            catch (Exception ex)
            {
                if (_service.GetAll().ToList().First(a => a.Id == id) == null)
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

            return Ok(_service.Update(appointmentUpdated));
        }

        [HttpDelete]

        public IActionResult Delete(Guid id, Appointment appointmentResponse)
        {
            try
            {
                return Ok(ApiGenericsResult<Appointment>.Success(_service.Delete(id, appointmentResponse)));
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

        [HttpGet("[action]{Date}")]

        public List<DateTime> GetFreeSlots(DateTime date)
        {
            return _service.GetFreeSlots(date);
        }
    }
}

