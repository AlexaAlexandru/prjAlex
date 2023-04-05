using System;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Service.Interfaces
{
    public interface IMenuService
    {
        Menu AddMenu(Menu menu);
        List<Menu> GetAll();
        Menu? GetById(Guid id);
        Menu Update(Menu menu);
        Menu Delete(Guid id, Menu menu);

    }
}

