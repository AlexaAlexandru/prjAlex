using System;
using System.Runtime.CompilerServices;
using SchedulePlatform.Api.Models;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Api.Mappings
{
    public static class NutritionistMappingExtension
    {
        public static Nutritionist Map(this Nutritionist nutritionist, NutritionistPatchModel model)
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

