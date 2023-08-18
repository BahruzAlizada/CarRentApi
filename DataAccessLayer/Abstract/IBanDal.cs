using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IBanDal : IEntityRepository<Ban>
    {
        List<BanDTO> GetAllForHome();
        BanDTO GetByIdForHome(int id);
        void Activity(int id);
    }
}
