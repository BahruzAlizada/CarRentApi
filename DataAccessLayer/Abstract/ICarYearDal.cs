using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.Abstract
{
    public interface ICarYearDal : IEntityRepository<CarYear>
    {
        List<CarYearDTO> GetAllForHome();
        CarYearDTO GetByIdForHome(int id);
        void Activity(int id);
    }
}
