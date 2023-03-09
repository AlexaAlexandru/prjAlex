using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
	public class MenuRepository :BaseRepository<Menu>,IMenuRepository
	{
		private readonly SchedulePlatformContext _context;
		private readonly DbSet<Menu> _dbSet;

		public MenuRepository(SchedulePlatformContext context) :base (context)
		{
			_context = context;
			_dbSet = context.Set<Menu>();
		}
    }
}

