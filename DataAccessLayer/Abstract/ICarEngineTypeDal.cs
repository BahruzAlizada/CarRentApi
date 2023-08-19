using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface ICarEngineTypeDal : IEntityRepository<CarEngineType>
    {
        List<EngineTypeDTO> GetAllForHome();
        EngineTypeDTO GetById(int id);
        void Activity(int id);
    }
}
