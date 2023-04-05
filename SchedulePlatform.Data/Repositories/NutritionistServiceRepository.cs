using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Data.Migrations;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
	public class NutritionistServiceRepository : BaseRepository<NutritionistService>, INutritionistServiceRepository
	{
		private readonly SchedulePlatformContext _context;
		private readonly DbSet<NutritionistService> _dbSet;
		public NutritionistServiceRepository(SchedulePlatformContext context) :base(context)
		{
			_context = context;
			_dbSet = context.Set<NutritionistService>();
		}
	}
}

