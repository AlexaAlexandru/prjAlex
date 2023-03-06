using System;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Interfaces
{
	public interface IAppointmentService
	{
		Appointment[] GetAllAppointments();
		Appointment AddAppointment(Appointment appointment);
		Appointment? GetById(Guid id);
		Appointment Update(Appointment appointment);
		Appointment Delete(Guid id, Appointment appointment);
    }
}

