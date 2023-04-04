using System;
using System.Data;
using AutoMapper;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Exceptions;
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
            var endHour = new DateTime(date.Year, date.Month, date.Day, 18, 0, 0);
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


        public AppointmentResponseModel Delete(Guid id)
        {
            var findAppointment = _appointmentRepository.GetById(id);

            _appointmentRepository.Delete(findAppointment);

            return _mapper.Map<AppointmentResponseModel>(findAppointment);
        }

        public IEnumerable<AppointmentResponseModel> GetAll()
        {
            var allAppointments = _appointmentRepository.GetAll();

            return _mapper.Map<IEnumerable<AppointmentResponseModel>>(allAppointments);
        }

        public AppointmentResponseModel GetById(Guid id)
        {
            var findAppointment = _appointmentRepository.GetById(id);
            return _mapper.Map<AppointmentResponseModel>(findAppointment);
        }

        public AppointmentResponseModel Update(AppointmentResponseModel appointment)
        {
            var findAppointment = _appointmentRepository.GetById(appointment.Id);

            if (findAppointment == null)
            {
                throw new NotFoundException("The appointment was not found");
            }

            findAppointment.StartDate = appointment.StartDate;
            findAppointment.IsOnSite = (bool)appointment.IsOnSite;
            findAppointment.Type = appointment.Type;

            _appointmentRepository.Update(findAppointment);

            return new AppointmentResponseModel
            {
                CustomerId = findAppointment.Id,
                IsOnSite = findAppointment.IsOnSite,
                NutritionistId = findAppointment.NutritionistId,
                StartDate = findAppointment.StartDate,
                Type = findAppointment.Type
            };
        }

        public IEnumerable<AppointmentResponseModel> GetAppointmentByNutritionist(Guid nutritionistId)
        {
            var appointmentsByNutritionist = _appointmentRepository.GetAll().Where(a => a.NutritionistId == nutritionistId);
            return _mapper.Map<IEnumerable<AppointmentResponseModel>>(appointmentsByNutritionist);
        }

        public IEnumerable<AppointmentResponseModel> GetAppointmentByCustomer(Guid customerId)
        {
            var appointmentsByCustomer = _appointmentRepository.GetAll().Where(a => a.CustomerId == customerId);
            return _mapper.Map<IEnumerable<AppointmentResponseModel>>(appointmentsByCustomer);
        }
    }
}

