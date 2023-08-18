using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface ICarGearBoxService
    {
        IDataResult<List<GearBoxDTO>> GetAll();
        IDataResult<GearBoxDTO> GetById(int id);
        IResult Add(GearBoxDTO gearBoxDTO);
        IResult Update(GearBoxDTO gearBoxDTO);
        IResult Activity(int id);
    }
}
