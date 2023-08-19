using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFCarEngineTypeDal : EfEntityRepositoryBase<CarEngineType, Context>, ICarEngineTypeDal
    {
        public void Activity(int id)
        {
            using (var context = new Context())
            {
                CarEngineType carEngineType = context.CarEngineTypes.FirstOrDefault(x=>x.Id == id);
                if (carEngineType.Status)
                    carEngineType.Status = false;
                else
                    carEngineType.Status = true;

                context.SaveChanges();
            }
        }

        public List<EngineTypeDTO> GetAllForHome()
        {
            using (var context = new Context())
            {
                List<CarEngineType> carEngineTypes = context.CarEngineTypes.ToList();
                List<EngineTypeDTO> engineTypeDTOs = new List<EngineTypeDTO>();

                foreach (var item in carEngineTypes)
                {
                    EngineTypeDTO dto = new EngineTypeDTO
                    {
                        Id = item.Id,
                        EngineType = item.EngineType
                    };
                    engineTypeDTOs.Add(dto);
                }
                return engineTypeDTOs;
            }
            
        }

        public EngineTypeDTO GetById(int id)
        {
            using (var context = new Context())
            {
                var engineType = context.CarEngineTypes.FirstOrDefault(x=>x.Id == id);
                EngineTypeDTO engineTypeDTO = new EngineTypeDTO
                {
                    Id = engineType.Id,
                    EngineType = engineType.EngineType
                };
                return engineTypeDTO;
            }
        }
    }
}
