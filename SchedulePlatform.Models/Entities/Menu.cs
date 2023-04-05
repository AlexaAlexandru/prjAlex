using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Models.Entities
{
    public class Menu : BaseEntity
    {
        public WeekDays Day { get; set; }
        public string? Description { get; set; }
        public Uri? UrlPdf { get; set; }
    }
}

