using System;
using AutoMapper;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Service.Mappings;
using SchedulePlatform.Service.Models.Nutritionist;
using SchedulePlatform.Service.Models.PatchModel;

namespace SchedulePlatform.Service
{
    public class NutritionistServiceS : INutritionistServiceS
    {
        private readonly INutritionistRepository _nutritionistRepository;
        private readonly IMapper _mapper;
        public NutritionistServiceS(INutritionistRepository baseRepository, IMapper mapper)
        {
            _nutritionistRepository = baseRepository;
            _mapper = mapper;
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

        public UpdateNutritionistResponseModel Update(Guid id, UpdateNutritionistRequestModel nutritionist)
        {
            var findNutritionist = _nutritionistRepository.GetById(id);

            var mappendNutritionsit = _mapper.Map<UpdateNutritionistRequestModel>(findNutritionist);

            var updateNutritionist = findNutritionist.Map(mappendNutritionsit);

            return _mapper.Map<UpdateNutritionistResponseModel>(updateNutritionist);
        }
    }
}

