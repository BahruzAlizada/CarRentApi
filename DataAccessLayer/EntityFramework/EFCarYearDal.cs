using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFCarYearDal : EfEntityRepositoryBase<CarYear, Context>, ICarYearDal
    {
        public void Activity(int id)
        {
           using (var context = new Context())
            {
                var year = context.CarYears.FirstOrDefault(x => x.Id == id);
                if (year.Status)
                    year.Status = false;
                else
                    year.Status = true;

                context.SaveChanges();
            }
        }

        public List<CarYearDTO> GetAllForHome()
        {
           using (var context = new Context())
            {
                List<CarYear> year = context.CarYears.ToList();
                List<CarYearDTO> yearDTOs = new List<CarYearDTO>();

                foreach (var item in year)
                {
                    CarYearDTO dto = new CarYearDTO
                    {
                        Id = item.Id,
                        Year = item.Year,
                    };
                    yearDTOs.Add(dto);
                }
                return yearDTOs;
            }
        }

        public CarYearDTO GetByIdForHome(int id)
        {
            using (var context = new Context())
            {
                var year = context.CarYears.FirstOrDefault(x => x.Id == id);
                CarYearDTO yearDTO = new CarYearDTO
                {
                    Id = year.Id,
                    Year = year.Year,
                };
                return yearDTO;
            }
        }
    }
}
