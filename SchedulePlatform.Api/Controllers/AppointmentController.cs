using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Models;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;

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

		[HttpGet]

		public Appointment[] GetAppointments()
		{
			return _service.GetAllAppointments();
		}

		[HttpPost]

		public Appointment AddAppointment(Appointment appointment)
		{
			return _service.AddAppointment(appointment);
		}

		[HttpGet("{id}")]

		public IActionResult GetById(Guid id)
		{
			var appointmentResult = _service.GetById(id);

			if (appointmentResult==null)
			{
				return NotFound();
			}
			return Ok(appointmentResult);
		}

		[HttpPatch]

		public IActionResult Update(Guid id, AppointmentPatchModel model)
		{
			var appointmentSearch = _service.GetById(id);

			if (appointmentSearch==null)
			{
				return NotFound();
			}

			var appointmentUpdated = appointmentSearch.Map(model);

			return Ok(_service.Update(appointmentUpdated));
		}

		[HttpDelete]

		public IActionResult Delete(Guid id,Appointment appointment)
		{
			var appointmentSearch = _service.GetById(id);

			if (appointmentSearch==null)
			{
				return NotFound();
			}

			return Ok(_service.Delete(id, appointment));
		}
	}
}

