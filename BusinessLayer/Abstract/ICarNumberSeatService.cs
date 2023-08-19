using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface ICarNumberSeatService
    {
        IDataResult<List<NumberSeatDTO>> GetAll();
        IDataResult<NumberSeatDTO> GetById(int id);
        IResult Add(NumberSeatDTO numberSeatDTO);
        IResult Update(NumberSeatDTO numberSeatDTO);
        IResult Activity(int id);
    }
}
