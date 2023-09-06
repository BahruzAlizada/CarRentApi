using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface ICityDal : IEntityRepository<City>
    {
        List<CityDTO> GetAllForHome();
        CityDTO GetCityById(int id);
        void Activity(int id);
    }
}
