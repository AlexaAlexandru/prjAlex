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

        public List<Appointment> GetAppoinmentsByDate(Guid nutritionistId, DateTime date)
        {
            return _service.GetAllByDate(nutritionistId, date);

        }

        [HttpGet]

        public Appointment[] GetAppointments()
        {
            return _service.GetAll();
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
                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] {$"{ex.Message}"}));
            }
        }

        [HttpGet("{Id}")]

        public IActionResult GetById(Guid id)
        {
            var appointmentResult = _service.GetById(id);

            if (appointmentResult == null)
            {
                return NotFound();
            }
            return Ok(appointmentResult);
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

        public IActionResult Delete(Guid id, Appointment appointment)
        {
            var appointmentSearch = _service.GetById(id);

            if (appointmentSearch == null)
            {
                return NotFound();
            }

            return Ok(_service.Delete(id, appointment));
        }

        [HttpGet("[action]{Date}")]

        public List<DateTime> GetFreeSlots(DateTime date)
        {
            return _service.GetFreeSlots(date);
        }
    }
}

