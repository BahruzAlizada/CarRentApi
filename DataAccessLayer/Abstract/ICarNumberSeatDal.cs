using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface ICarNumberSeatDal : IEntityRepository<CarNumberSeat>
    {
        List<NumberSeatDTO> GetAllForHome();
        NumberSeatDTO GetByIdForHome(int id);
        void Activity(int id);
    }
}
