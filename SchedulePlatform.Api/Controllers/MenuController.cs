using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Api.Models;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;

namespace SchedulePlatform.Api.Controllers
{
    [Route("Api/[Controller]")]

    [ApiController]

    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]

        public Menu[] GetAllMenus()
        {
            return _service.GetAll();
        }

        [HttpPost()]

        public Menu AddMenu(Menu menu)
        {
            return _service.AddMenu(menu);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var menuResult = _service.GetById(id);

            if (menuResult == null)
            {
                return NotFound();
            }

            return Ok(menuResult);
        }

        [HttpPatch]

        public IActionResult Update(Guid id, MenuPatchModel model)
        {
            var menuSearch = _service.GetById(id);
            if (menuSearch == null)
            {
                return NotFound();
            }

            var menuUpdated = menuSearch.Map(model);

            return Ok(_service.Update(menuUpdated));
        }

        [HttpDelete]

        public IActionResult Delete(Guid id, Menu menu)
        {
            var menuSearch = _service.GetById(id);
            if (menuSearch == null)
            {
                return NotFound();
            }

            return Ok(_service.Delete(id, menu));
        }

    }
}

