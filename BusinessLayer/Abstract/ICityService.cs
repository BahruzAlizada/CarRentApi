using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface ICityService
    {
        IDataResult<List<CityDTO>> GetAll();
        IDataResult<CityDTO> GetById(int id);
        IResult Add(CityDTO cityDTO);
        IResult Update(CityDTO cityDTO);
        IResult Activity(int id);
    }
}
