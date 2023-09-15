using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using CoreLayer.Aspects.Autofac.Caching;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal carDal;
        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        #region Activity
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Activity(int id)
        {
            carDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

      
        public IResult Add(CarDTO cardto)
        {
            throw new NotImplementedException();
        }
       

        #region Delete
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(int id)
        {
            var value = carDal.Get(x => x.Id == id);
            carDal.Delete(value);
            return new SuccessResult(Message.Deleted);
        }
        #endregion

        #region GetByIdCars
        public IDataResult<CarForHomeDTO> GetByIdCar(int id)
        {
            var value = carDal.GetByIdForHome(id);
            return new SuccessDataResult<CarForHomeDTO>(value,Message.ByFilter);
        }
        #endregion

        #region GetCars
        [CacheAspect]
        public IDataResult<List<CarForHomeDTO>> GetCars()
        {
            var values = carDal.GetAllForHome();
            return new SuccessDataResult<List<CarForHomeDTO>>(values,Message.GetAll);
        }
        #endregion

        public IResult Update(CarDTO cardto)
        {
            throw new NotImplementedException();
        }
    }
}
