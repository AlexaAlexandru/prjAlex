using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Service.Models;
using SchedulePlatform.Service.Models.Nutritionist;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]


    public class NutritionistController : ControllerBase
    {
        private readonly INutritionistServiceS _nutritionistService;
        private readonly IMapper _mapper;

        public NutritionistController(INutritionistServiceS service, IMapper mapper)
        {
            _nutritionistService = service;
            _mapper = mapper;
        }

        [HttpGet]

        public ActionResult<IEnumerable<NutritionistResponseModel>> GetAll()
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<NutritionistResponseModel>>.Success(_nutritionistService.GetAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<NutritionistResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPost()]

        public IActionResult Add(NutritionistRequestModel nutritionist)
        {
            try
            {
                return Ok(ApiGenericsResult<NutritionistResponseModel>.Success(_nutritionistService.AddNutritionist(nutritionist)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<NutritionistResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var findNutritionist = _nutritionistService.GetById(id);

            if (findNutritionist == null)
            {
                return NotFound();
            }

            else
            {
                try
                {
                    return Ok(ApiGenericsResult<NutritionistResponseModel>.Success(_nutritionistService.GetById(id)));
                }
                catch (Exception ex)
                {
                    if (_nutritionistService.GetAll().ToList().FirstOrDefault(n => n.Id == id) == null)
                    {
                        return NotFound(ex.Message);
                    }
                    return BadRequest(ex.Message);
                }
            }

        }

        [HttpPatch]

        public IActionResult Update(Guid id, UpdateNutritionistRequestModel model)
        {
            var findNutritionist = _nutritionistService.GetById(id);

            if (findNutritionist == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(ApiGenericsResult<UpdateNutritionistResponseModel>.Success(_nutritionistService.Update(id,model)));
            }
            catch (Exception ex)
            {
                if (findNutritionist == null)
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ApiGenericsResult<UpdateNutritionistResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }

        }

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            var findNutritionist = _nutritionistService.GetById(id);

            if (findNutritionist == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    return Ok(ApiGenericsResult<NutritionistResponseModel>.Success(_nutritionistService.Delete(id)));
                }
                catch (Exception ex)
                {
                    if (findNutritionist == null)
                    {
                        return NotFound(ApiGenericsResult<NutritionistResponseModel>.Failure(new[] { $"{ex.Message}" }));
                    }
                    return BadRequest(ApiGenericsResult<NutritionistResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
            }
        }
    }

}

