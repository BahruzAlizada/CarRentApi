using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarForHomeDTO> GetAllForHome();
        CarForHomeDTO GetByIdForHome(int id);
        void Activity(int id);
    }
}
