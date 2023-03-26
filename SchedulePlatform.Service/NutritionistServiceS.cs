using System;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;

namespace SchedulePlatform.Service
{
    public class NutritionistServiceS : INutritionistServiceS
    {
        private readonly INutritionistRepository _nutritionistRepository;

        public NutritionistServiceS(INutritionistRepository baseRepository)
        {
            _nutritionistRepository = baseRepository;
        }

        public Nutritionist AddNutritionist(Nutritionist nutritionist)
        {
            var newNutritionist = new Nutritionist()
            {
                Address = nutritionist.Address,
                Appointments = nutritionist.Appointments,
                Biography = nutritionist.Biography,
                Email = nutritionist.Email,
                FirstName = nutritionist.FirstName,
                Id = Guid.NewGuid(),
                LastName = nutritionist.LastName,
                NutritionistService = nutritionist.NutritionistService,
                Phone = nutritionist.Phone,
                PictureUrl = nutritionist.PictureUrl
            };

            return _nutritionistRepository.Add(newNutritionist);
        }

        public Nutritionist Delete(Guid id, Nutritionist nutritionist)
        {
            return _nutritionistRepository.Delete(id, nutritionist);
        }

        public Nutritionist[] GetAll()
        {
            return _nutritionistRepository.GetAll();
        }

        public Nutritionist? GetById(Guid id)
        {
            return _nutritionistRepository.GetById(id);
        }

        public Nutritionist Update(Nutritionist nutritionist)
        {
            return _nutritionistRepository.Update(nutritionist);
        }
    }
}

