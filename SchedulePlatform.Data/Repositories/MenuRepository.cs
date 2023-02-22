using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
	public class MenuRepository :IMenuRepository
	{
		private readonly SchedulePlatformContext _context;
		private readonly DbSet<Menu> _dbSet;

		public MenuRepository(SchedulePlatformContext context)
		{
			_context = context;
			_dbSet = context.Set<Menu>();
		}

        public Menu[] GetAll()
        {
            return _dbSet.ToArray();
        }

        public Menu AddMenu(Menu menu)
        {
            _dbSet.Add(menu);
            _context.SaveChanges();

            return menu;
        }

        public Menu? GetById(Guid id)
        {
            return _dbSet.FirstOrDefault((Menu m) => m.Id == id);
        }

        public Menu Update(Menu menu)
        {
            _dbSet.Update(menu);
            _context.SaveChanges();

            return menu;
        }

        public Menu Delete(Guid id, Menu menu)
        {
            var findMenu = _dbSet.First( (Menu m) => m.Id == id);

            _dbSet.Remove(findMenu);
            _context.SaveChanges();

            return menu;
        }

    }
}

