using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFCarNumberSeatDal : EfEntityRepositoryBase<CarNumberSeat, Context>, ICarNumberSeatDal
    {
        public void Activity(int id)
        {
            using (var context = new Context())
            {
                var numberseat = context.CarNumberSeats.FirstOrDefault(x=>x.Id == id);
                if (numberseat.Status)
                    numberseat.Status = false;
                else
                    numberseat.Status = true;

                context.SaveChanges();
            }
        }

        public List<NumberSeatDTO> GetAllForHome()
        {
            using (var context = new Context())
            {
                List<CarNumberSeat> carNumbers = context.CarNumberSeats.ToList();
                List<NumberSeatDTO> numberSeatDTOs = new List<NumberSeatDTO>();

                foreach (var item in carNumbers)
                {
                    NumberSeatDTO dto = new NumberSeatDTO
                    {
                        Id = item.Id,
                        NumberSeat = item.NumberSeat
                    };
                    numberSeatDTOs.Add(dto);
                }
                return numberSeatDTOs;
            }
        }

        public NumberSeatDTO GetByIdForHome(int id)
        {
            using (var context = new Context())
            {
                CarNumberSeat carNumbers = context.CarNumberSeats.FirstOrDefault(x=>x.Id==id);
                NumberSeatDTO numberSeatDTO = new NumberSeatDTO
                {
                    Id = carNumbers.Id,
                    NumberSeat = carNumbers.NumberSeat
                };
                return numberSeatDTO;
            }
        }
    }
}
