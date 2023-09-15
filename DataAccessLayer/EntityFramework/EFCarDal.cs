using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        #region Activity
        public void Activity(int id)
        {
            using var context = new Context();
            Car car = context.Cars.FirstOrDefault(c => c.Id == id);
            if (car.Status)
                car.Status = false;
            else
                car.Status = true;

            context.SaveChanges();
        }
        #endregion

        #region GetAll
        public List<CarForHomeDTO> GetAllForHome()
        {
            using var context = new Context();
            List<Car> cars = context.Cars.Include(x => x.Category).Include(x => x.SubCategory).
                Include(x => x.Ban).
                Include(x => x.CarYear).Include(x => x.CarEngineType).Include(x => x.CarColor).
                Include(x => x.CarGearBox).
                Include(x => x.CarNumberSeat).Include(x=>x.CarCountryMarket)
                .Include(x => x.City).Include(x => x.Customer).ToList();

            List<CarForHomeDTO> carForHomeDTOs = new List<CarForHomeDTO>();

            foreach (var item in cars)
            {
                CarForHomeDTO dto = new CarForHomeDTO
                {
                    Id = item.Id,
                    Model = item.SubCategory.Name,
                    Marka = item.Category.Name,
                    Ban = item.Ban.BanName,
                    CarColor = item.CarColor.Color,
                    CarCountryMarket = item.CarCountryMarket.Country,
                    CarNumberSeat = item.CarNumberSeat.NumberSeat,
                    CarYear=item.CarYear.Year,
                    CarEngine=item.CarEngineType.EngineType,
                    CarGearBox=item.CarGearBox.GearBox,
                    City=item.City.CityName,
                    CustomerName=item.Customer.Name,
                    CustomerEmail = item.Customer.Email,
                    CreatedTime=item.CreatedTime,
                    DailyPrice=item.DailyPrice,
                    Description=item.Description,
                    EnginePower = item.EnginePower,
                    Insurance = item.Insurance,
                    IsNew = item.IsNew,
                    Km = item.Km,
                    seen = item.seen
                };
                carForHomeDTOs.Add(dto);
            }

            return carForHomeDTOs;
        }
        #endregion

        #region GetById
        public CarForHomeDTO GetByIdForHome(int id)
        {
            using var context = new Context();
           Car car = context.Cars.Include(x => x.Category).Include(x => x.SubCategory).
                Include(x => x.Ban).
                Include(x => x.CarYear).Include(x => x.CarEngineType).Include(x => x.CarColor).
                Include(x => x.CarGearBox).
                Include(x => x.CarNumberSeat).Include(x => x.CarCountryMarket)
                .Include(x => x.City).Include(x => x.Customer).FirstOrDefault(x=>x.Id==id);

            CarForHomeDTO carForHomeDTO = new CarForHomeDTO
            {
                Id = car.Id,
                Model = car.SubCategory.Name,
                Marka = car.Category.Name,
                Ban = car.Ban.BanName,
                CarColor = car.CarColor.Color,
                CarCountryMarket = car.CarCountryMarket.Country,
                CarNumberSeat = car.CarNumberSeat.NumberSeat,
                CarYear = car.CarYear.Year,
                CarEngine = car.CarEngineType.EngineType,
                CarGearBox = car.CarGearBox.GearBox,
                City = car.City.CityName,
                CustomerName = car.Customer.Name,
                CustomerEmail = car.Customer.Email,
                CreatedTime = car.CreatedTime,
                DailyPrice = car.DailyPrice,
                Description = car.Description,
                EnginePower = car.EnginePower,
                Insurance = car.Insurance,
                IsNew = car.IsNew,
                Km = car.Km,
                seen = car.seen
            };

            return carForHomeDTO;
        }
        #endregion
    }
}
