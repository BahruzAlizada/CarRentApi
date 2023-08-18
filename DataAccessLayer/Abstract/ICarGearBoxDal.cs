using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface ICarGearBoxDal : IEntityRepository<CarGearBox>
    {
        List<GearBoxDTO> GetAllForHome();
        GearBoxDTO GetByIdForHome(int id);
        void Activity(int id);
    }
}
