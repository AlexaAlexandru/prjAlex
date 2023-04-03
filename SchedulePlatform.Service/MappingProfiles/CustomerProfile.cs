using System;
using AutoMapper;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Customer;

namespace SchedulePlatform.Service.MappingProfiles
{
	public class CustomerProfile : Profile
    {
		public CustomerProfile()
		{
			CreateMap<Customer, CustomerResponseModel>();
			CreateMap<CustomerCreateModel, Customer>();
			CreateMap<CustomerResponseModel, UpdateCustomerRequestModel>();
			CreateMap<UpdateCustomerRequestModel, Customer>();
			CreateMap<Customer, UpdateCustomerResponseModel>();
		}
	}
}

