using System;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Interfaces
{
	public class AppointmentService: IAppointmentService
	{
        private IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _appointmentRepository = repository;
        }

        public Appointment Add(Appointment appointment)
        {
            var appointmentToAdd = new Appointment
            {
                Id = Guid.NewGuid(),
                StartDate = appointment.StartDate,
                EndDate = appointment.EndDate,
                IsOnSite = appointment.IsOnSite,
                Type = appointment.Type,
                NutritionistId = appointment.NutritionistId,
                CustomerId = appointment.CustomerId
            };

            return _appointmentRepository.Add(appointmentToAdd);
        }

        public Appointment Delete(Guid id, Appointment appointment)
        {
            return _appointmentRepository.Delete(id, appointment);
        }

        public Appointment[] GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment? GetById(Guid id)
        {
            return _appointmentRepository.GetById(id);
        }

        public Appointment Update(Appointment appointment)
        {
            return _appointmentRepository.Update(appointment);
        }
    }
}

