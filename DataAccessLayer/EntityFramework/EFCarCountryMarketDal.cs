using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFCarCountryMarketDal : EfEntityRepositoryBase<CarCountryMarket, Context>, ICarCountryMarketDal
    {
        public void Activity(int id)
        {
            using (var context = new Context())
            {
                var countryMarket = context.CarCountryMarkets.FirstOrDefault(x => x.Id == id);
                if (countryMarket.Status)
                    countryMarket.Status = false;
                else
                    countryMarket.Status = true;

                context.SaveChanges();
            }
        }

        public List<CountryMarketDTO> GetAllForHome()
        {
            using (var context = new Context())
            {
                List<CarCountryMarket> countryMarkets = context.CarCountryMarkets.ToList();
                List<CountryMarketDTO> countryMarketDTOs = new List<CountryMarketDTO>();

                foreach (var item in countryMarketDTOs)
                {
                    CountryMarketDTO dto = new CountryMarketDTO
                    {
                        Id = item.Id,
                        Country = item.Country,
                    };
                    countryMarketDTOs.Add(dto);
                }
                return countryMarketDTOs;
            }
        }

        public CountryMarketDTO GetByIdForHome(int id)
        {
            using (var context = new Context())
            {
                var countryMarkets = context.CarCountryMarkets.FirstOrDefault(x => x.Id == id);
                CountryMarketDTO countryDTO = new CountryMarketDTO
                {
                    Id = countryMarkets.Id,
                    Country = countryMarkets.Country,
                };
                return countryDTO;
            }
        }
    }
}
