using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFCityDal : EfEntityRepositoryBase<City, Context>, ICityDal
    {
        public void Activity(int id)
        {
            using(var context = new Context())
            {
                var city = context.Cities.FirstOrDefault(x => x.Id == id);
                if (city.IsDeactive)
                    city.IsDeactive = false;
                else
                    city.IsDeactive = true;

                context.SaveChanges();
            }
        }

        public List<CityDTO> GetAllForHome()
        {
            using (var context = new Context())
            {
                List<City> cities = context.Cities.ToList();
                List<CityDTO> cityDTOs = new List<CityDTO>();

                foreach (var item in cities)
                {
                    CityDTO dto = new CityDTO
                    {
                        Id = item.Id,
                        CityName = item.CityName
                    };
                    cityDTOs.Add(dto);
                }
                return cityDTOs;
            }
        }

        public CityDTO GetCityById(int id)
        {
            using(var context = new Context())
            {
                City city = context.Cities.FirstOrDefault(x => x.Id == id);
                CityDTO cityDTO = new CityDTO
                {
                    Id = city.Id,
                    CityName = city.CityName
                };
                return cityDTO;
            }
        }
    }
}
