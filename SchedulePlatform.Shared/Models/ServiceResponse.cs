﻿using System;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Shared.Models
{
    public class ServiceResponse
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? NameServiceProvided { get; set; }
        public Uri? UrlPicture { get; set; }
        public ConsultationType Type { get; set; }
        public double Price { get; set; }
        public List<NutritionistService>? NutritionistService { get; set; }
    }
}

