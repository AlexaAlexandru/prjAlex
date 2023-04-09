using System;
using AutoMapper;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.AppointmentModel;

namespace SchedulePlatform.Service.MappingProfiles
{
	public class AppointmentProfile: Profile
	{
		public AppointmentProfile()
		{
			CreateMap<Appointment, AppointmentResponseModel>();
			CreateMap<AppointmentRequestModel, Appointment>();
		}
	}
}

