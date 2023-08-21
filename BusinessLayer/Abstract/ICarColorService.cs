using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface ICarColorService
    {
        IDataResult<List<CarColorDTO>> GetAll();
        IDataResult<CarColorDTO> GetById(int id);
        IResult Add(CarColorDTO carColorDTO);
        IResult Update(CarColorDTO carColorDTO);
        IResult Activity(int id);
    }
}
