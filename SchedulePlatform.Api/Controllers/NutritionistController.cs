using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Api.Models;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service;
using SchedulePlatform.Service.Interfaces;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    
    public class NutritionistController : ControllerBase
    {
        private readonly INutritionistServiceS _nutritionistService;

        public NutritionistController(INutritionistServiceS service)
        {
            _nutritionistService = service;
        }

        [HttpGet]

        public Nutritionist[] GetAll()
        {
            return _nutritionistService.GetAll();
        }

        [HttpPost()]

        public Nutritionist Add(Nutritionist nutritionist)
        {
            return _nutritionistService.AddNutritionist(nutritionist);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var nutritionistFound = _nutritionistService.GetById(id);

            if (nutritionistFound == null)
            {
                NotFound();
            }

            return Ok(nutritionistFound);
        }

        [HttpPatch]

        public IActionResult Update(Guid id, NutritionistPatchModel model)
        {
            var findNutritionist = _nutritionistService.GetById(id);

            if (findNutritionist == null)
            {
                return NotFound();
            }

            var nutritionistUpdated = findNutritionist.Map(model);

            return Ok(_nutritionistService.Update(nutritionistUpdated));
        }

        [HttpDelete]

        public IActionResult Delete(Guid id, Nutritionist nutritionist)
        {
            var findNutritionist = _nutritionistService.GetById(id);

            if (findNutritionist == null)
            {
                return NotFound();
            }

            return Ok(_nutritionistService.Delete(id,nutritionist));
        }
    }

}

