using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.Abstract
{
    public interface ICarColorDal : IEntityRepository<CarColor>
    {
        List<CarColorDTO> GetAllForHome();
        CarColorDTO GetByIdForHome(int id);
        void Activity(int id);
    }
}
