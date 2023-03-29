using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Api.Models.Appointment
{
    public class AppointmentResponseModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public TypeAppointment Type { get; set; }
        public Guid NutritionistId { get; set; }
        public Guid CustomerId { get; set; }
    }
}

