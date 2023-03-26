using System;
using System.Data;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Interfaces
{
    public class AppointmentService : IAppointmentService
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

        public IEnumerable<DateTime> GetFreeSlots(DateTime date)
        {
            var bookedAppointments = _appointmentRepository
                .GetAll()
                .Where(a => a.StartDate == date)
                .ToList();

            var startHour = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
            var endHour = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0);
            var currentSlot = startHour;
            var availableSlots = new List<DateTime>();

            while (currentSlot + TimeSpan.FromHours(1) <= endHour)
            {
                var isAvailable = true;

                foreach (var item in bookedAppointments)
                {
                    if (currentSlot >= item.StartDate && currentSlot < item.StartDate)
                    {
                        isAvailable = false;
                        break;
                    }
                }

                if (isAvailable)
                {
                    availableSlots.Add(currentSlot);
                }

                currentSlot += TimeSpan.FromHours(1);
            }

            return availableSlots;
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

