using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Api.Models.Patch
{
    public class ServiceProvidedPatchModel
    {
        public string? Description { get; set; }
        public string? NameServiceProvided { get; set; }
        public Uri? UrlPicture { get; set; }
        public ConsultationType? Type { get; set; }
        public double? Price { get; set; }
    }
}

