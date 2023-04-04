using System;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Nutritionist;

namespace SchedulePlatform.Api.Mappings
{
    public static class UpdateNutritionistMappingExtension
    {
        public static NutritionistResponseModel Map(this NutritionistResponseModel nutritionist, UpdateNutritionistPatchModel model)
        {
            if (!string.IsNullOrEmpty(model.Address))
            {
                nutritionist.Address = model.Address;
            }
            if (!string.IsNullOrEmpty(model.Biography))
            {
                nutritionist.Biography = model.Biography;
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                nutritionist.Email = model.Email;
            }
            if (!string.IsNullOrEmpty(model.FirstName))
            {
                nutritionist.FirstName = model.FirstName;
            }
            if (!string.IsNullOrEmpty(model.LastName))
            {
                nutritionist.LastName = model.LastName;
            }
            if (!string.IsNullOrEmpty(model.Phone))
            {
                nutritionist.Phone = model.Phone;
            }

            return nutritionist;
        }
    }
}

