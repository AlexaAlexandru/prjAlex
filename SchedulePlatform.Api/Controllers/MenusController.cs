﻿using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;

namespace SchedulePlatform.Api.Controllers
{
    [Route("Api/[Controller]")]

    [ApiController]

    public class MenusController : ControllerBase
    {
        private readonly IMenuService _service;

        public MenusController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]

        public List<Menu> GetAllMenus()
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

