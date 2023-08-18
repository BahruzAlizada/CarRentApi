using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface ICarCountryMarketService
    {
        IDataResult<List<CountryMarketDTO>> GetAll();
        IDataResult<CountryMarketDTO> GetById(int id);
        IResult Add(CountryMarketDTO countryMarketDTO);
        IResult Update(CountryMarketDTO countryMarketDTO);
        IResult Activity(int id);
    }
}
