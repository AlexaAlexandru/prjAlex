using System;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Api.Models.Patch
{
    public class MenuPatchModel
    {
        public WeekDays? Day { get; set; }
        public string? Description { get; set; }
        public Uri? UrlPdf { get; set; }
    }
}

