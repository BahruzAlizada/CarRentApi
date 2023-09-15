using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarForHomeDTO>> GetCars();
        IDataResult<CarForHomeDTO> GetByIdCar(int id);
        IResult Add(CarDTO cardto);
        IResult Update(CarDTO cardto);
        IResult Delete(int id);
        IResult Activity(int id);
    }
}
