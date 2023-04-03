using System;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Customer;
using SchedulePlatform.Service.Models.Nutritionist;

namespace SchedulePlatform.Api.Mappings
{
	public static class UpdateCustomerMappingExtension
	{
		public static  CustomerResponseModel Map(this CustomerResponseModel customer, CustomerPatchModel model)
		{
            if (!string.IsNullOrEmpty(model.FirstName))
            {
                customer.FirstName = model.FirstName;
            }

            if (!string.IsNullOrEmpty(model.LastName))
            {
                customer.LastName = model.LastName;
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                customer.Email = model.Email;
            }

            if (!string.IsNullOrEmpty(model.Phone))
            {
                customer.Phone = model.Phone;
            }

            if (model.Height.HasValue)
            {
                customer.Height = (decimal)model.Height;
            }

            if (model.Weight.HasValue)
            {
                customer.Weight = (decimal)model.Weight;
            }

            if (model.Age.HasValue)
            {
                customer.Age = model.Age.Value;
            }

            return customer;
        }
	}
}

