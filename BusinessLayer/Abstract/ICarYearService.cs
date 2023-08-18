using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface ICarYearService
    {
        IDataResult<List<CarYearDTO>> GetAll();
        IDataResult<CarYearDTO> GetById(int id);
        IResult Add(CarYearDTO carYearDTO);
        IResult Update(CarYearDTO carYearDTO);
        IResult Activity(int id);
    }
}
