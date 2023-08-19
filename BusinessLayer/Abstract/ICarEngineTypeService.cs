using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface ICarEngineTypeService
    {
        IDataResult<List<EngineTypeDTO>> GetAll();
        IDataResult<EngineTypeDTO> GetById(int id);
        IResult Add(EngineTypeDTO engineTypeDTO);
        IResult Update(EngineTypeDTO engineTypeDTO);
        IResult Activity(int id);
    }
}
