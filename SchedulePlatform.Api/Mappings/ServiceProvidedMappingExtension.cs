using System;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Api.Mappings
{
    public static class ServiceProvidedMappingExtension
    {
        public static ServiceProvided Map(this ServiceProvided service, ServiceProvidedPatchModel model)
        {
            if (!string.IsNullOrEmpty(model.Description))
            {
                service.Description = model.Description;
            }

            if (!string.IsNullOrEmpty(model.NameServiceProvided))
            {
                service.NameServiceProvided = model.NameServiceProvided;
            }

            if (model.UrlPicture != null)
            {
                service.UrlPicture = model.UrlPicture;
            }

            if (model.Price.HasValue)
            {
                service.Price = (double)model.Price;
            }

            return service;

        }
    }
}

