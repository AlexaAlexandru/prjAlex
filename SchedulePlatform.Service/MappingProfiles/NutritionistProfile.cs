using System;
using AutoMapper;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Models.Nutritionist;
using SchedulePlatform.Service.Models.PatchModel;

namespace SchedulePlatform.Service.MappingProfiles
{
	public class NutritionistProfile:Profile
	{
		public NutritionistProfile()
		{
			CreateMap<Nutritionist, NutritionistResponseModel>();
			CreateMap<NutritionistRequestModel, Nutritionist>();
			CreateMap<Nutritionist, UpdateNutritionistResponseModel>();
			CreateMap<UpdateNutritionistRequestModel, Nutritionist>();
			CreateMap<Nutritionist, UpdateNutritionistRequestModel>();
		}
	}
}

