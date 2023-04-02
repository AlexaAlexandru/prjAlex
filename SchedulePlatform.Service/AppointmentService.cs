using System;
using System.Data;
using AutoMapper;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Appointment;

namespace SchedulePlatform.Service.Interfaces
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository repository, IMapper mapper)
        {
            _appointmentRepository = repository;
            _mapper = mapper;
        }

        public AppointmentResponseModel Add(AppointmentRequestModel appointmentRequest)
        {
            var appointmentToAdd = _mapper.Map<Appointment>(appointmentRequest);
            _appointmentRepository.Add(appointmentToAdd);

            return _mapper.Map<AppointmentResponseModel>(appointmentToAdd);
        }

        public List<DateTime> GetFreeSlots(DateTime date)
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
            return _appointmentRepository.Delete(appointment);
        }

        public IEnumerable<AppointmentResponseModel> GetAll()
        {
            var allAppointments= _appointmentRepository.GetAll();

            return _mapper.Map<IEnumerable<AppointmentResponseModel>>(allAppointments);
        }

        public Appointment? GetById(Guid id)
        {
            return _appointmentRepository.GetById(id);
        }

        public Appointment Update(Appointment appointment)
        {
            return _appointmentRepository.Update(appointment);
        }

        public IEnumerable<AppointmentResponseModel> GetAllByDate(Guid nutritionistId, DateTime date)
        {
            var appointmentsByDate = _appointmentRepository.GetAll().Where(a => a.NutritionistId == nutritionistId && a.StartDate == date);
            return _mapper.Map<IEnumerable<AppointmentResponseModel>>(appointmentsByDate);
        }
    }
}

