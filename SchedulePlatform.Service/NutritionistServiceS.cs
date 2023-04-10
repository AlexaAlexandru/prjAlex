using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Service.Models.Nutritionist;

namespace SchedulePlatform.Service
{
    public class NutritionistServiceS : INutritionistServiceS
    {
        private readonly INutritionistRepository _nutritionistRepository;
        private readonly IMapper _mapper;
        private readonly INutritionistServiceRepository _nutritionistServiceRepository;
        public NutritionistServiceS(INutritionistRepository baseRepository, IMapper mapper, INutritionistServiceRepository service)
        {
            _nutritionistRepository = baseRepository;
            _mapper = mapper;
            _nutritionistServiceRepository = service;
        }

        public NutritionistResponseModel AddNutritionist(NutritionistRequestModel nutritionist)
        {
            nutritionist.NutritionistService.Add(new NutritionistService
            {
                NutritionistId = nutritionist.Id,
                ServiceId = Guid.Parse("8ae65e63-5f09-4cf2-8a33-b92f72dcaf08")
            });

            var newNutritionist = _mapper.Map<Nutritionist>(nutritionist);
            _nutritionistRepository.Add(newNutritionist);

            return _mapper.Map<NutritionistResponseModel>(newNutritionist);
        }

        public NutritionistResponseModel Delete(Guid id)
        {
            var findNutritionist = _nutritionistRepository.GetById(id);
            _nutritionistRepository.Delete(findNutritionist);

            return _mapper.Map<NutritionistResponseModel>(findNutritionist);
        }

        public IEnumerable<NutritionistResponseModel> GetAll()
        {
            var allNutritionists = _nutritionistRepository.GetAll();
            return _mapper.Map<IEnumerable<NutritionistResponseModel>>(allNutritionists);
        }

        public NutritionistResponseModel GetById(Guid id)
        {
            var findNutritionist = _nutritionistRepository.GetById(id);
            return _mapper.Map<NutritionistResponseModel>(findNutritionist);
        }

        public UpdateNutritionistResponseModel Update(Guid id,UpdateNutritionistRequestModel nutritionist)
        {
            var updatedNutritionist = _nutritionistRepository.GetById(id);

            if (!string.IsNullOrEmpty(nutritionist.Address))
            {
                updatedNutritionist.Address = nutritionist.Address;
            }
            if (!string.IsNullOrEmpty(nutritionist.Biography))
            {
                updatedNutritionist.Biography = nutritionist.Biography;
            }
            if (!string.IsNullOrEmpty(nutritionist.Email))
            {
                updatedNutritionist.Email = nutritionist.Email;
            }
            if (!string.IsNullOrEmpty(nutritionist.FirstName))
            {
                updatedNutritionist.FirstName = nutritionist.FirstName;
            }
            if (!string.IsNullOrEmpty(nutritionist.LastName))
            {
                updatedNutritionist.LastName = nutritionist.LastName;
            }
            if (!string.IsNullOrEmpty(nutritionist.Phone))
            {
                updatedNutritionist.Phone = nutritionist.Phone;
            }
            if (nutritionist.PictureUrl!=null)
            {
                updatedNutritionist.PictureUrl = nutritionist.PictureUrl;
            }
            if (nutritionist.newNutritionServiceId.HasValue)
            {
                _nutritionistServiceRepository.Add(new NutritionistService
                {
                    Id = Guid.NewGuid(),
                    ServiceId = (Guid)nutritionist.newNutritionServiceId,
                    NutritionistId = updatedNutritionist.Id
                });
            }
            _nutritionistRepository.Update(updatedNutritionist);

            return _mapper.Map<UpdateNutritionistResponseModel>(updatedNutritionist);
        }
    }
}

