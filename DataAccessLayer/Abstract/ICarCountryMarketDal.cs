using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.Abstract
{
    public interface ICarCountryMarketDal : IEntityRepository<CarCountryMarket>
    {
        List<CountryMarketDTO> GetAllForHome();
        CountryMarketDTO GetByIdForHome(int id);
        void Activity(int id);
    }
}
