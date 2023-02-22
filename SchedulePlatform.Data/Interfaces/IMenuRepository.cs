using System;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Interfaces
{
	public interface IMenuRepository
	{
        Menu AddMenu(Menu menu);
        Menu[] GetAll();
        Menu? GetById(Guid id);
        Menu Update(Menu menu);
        Menu Delete(Guid id, Menu menu);
    }
}

