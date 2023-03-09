using System;
using SchedulePlatform.Api.Models;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Api.Mappings
{
	public static class MenuMappingExtension
	{
		public static Menu Map(this Menu menu,MenuPatchModel model)
		{
			if (model.Day.HasValue)
			{
				menu.Day = (SchedulePlatform.Models.Enums.WeekDays)model.Day;
			}

			if (!string.IsNullOrEmpty(model.Description))
			{
				menu.Description = model.Description;
			}

			if (model.UrlPdf!=null)
			{
				menu.UrlPdf = model.UrlPdf;
			}

			return menu;
		}
	}
}

