using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Linq.Expressions;

namespace DataAccessLayer.EntityFramework
{
    public class EFCarColorDal : EfEntityRepositoryBase<CarColor, Context>, ICarColorDal
    {
        public void Activity(int id)
        {
            using (var context = new Context())
            {
                var carColor = context.CarColors.FirstOrDefault(x => x.Id == id);
                if (carColor.Status)
                    carColor.Status = false;
                else
                    carColor.Status = true;

                context.SaveChanges();
            }
        }

        public List<CarColorDTO> GetAllForHome()
        {
          using(var context = new Context())
            {
                List<CarColor> carColors = context.CarColors.ToList();
                List<CarColorDTO> carColorDTOs = new List<CarColorDTO>();

                foreach (var item in carColors)
                {
                    CarColorDTO dto = new CarColorDTO
                    {
                        Id = item.Id,
                        Color = item.Color,
                    };
                    carColorDTOs.Add(dto);
                }
                return carColorDTOs;
            }
        }

        public CarColorDTO GetByIdForHome(int id)
        {
            using(var context = new Context())
            {
                CarColor carColor = context.CarColors.FirstOrDefault(x => x.Id == id);
                CarColorDTO dto = new CarColorDTO
                {
                    Id = carColor.Id,
                    Color = carColor.Color,
                };
                return dto;
            }
        }
    }
}
