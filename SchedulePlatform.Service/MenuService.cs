using System;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;

namespace SchedulePlatform.Service
{
	public class MenuService : IMenuService
	{
		private readonly IMenuRepository _menuRepository;

		public MenuService(IMenuRepository menuRepository)
		{
			_menuRepository = menuRepository;
		}

        public Menu[] GetAll()
        {
            return _menuRepository.GetAll();
        }

        public Menu AddMenu(Menu menu)
        {
            var menuToAdd = new Menu
            {
                Id = Guid.NewGuid(),
                Day = menu.Day,
                Description = menu.Description,
                UrlPdf = menu.UrlPdf
            };

            return _menuRepository.AddMenu(menuToAdd);
        }

        public Menu? GetById(Guid id)
        {
            return _menuRepository.GetById(id);
        }

        public Menu Update(Menu menu)
        {
            return _menuRepository.Update(menu);
        }

        public Menu Delete(Guid id, Menu menu)
        {
            return _menuRepository.Delete(id,menu);
        }

    }
}

