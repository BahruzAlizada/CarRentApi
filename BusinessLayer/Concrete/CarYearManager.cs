using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Concrete
{
    public class CarYearManager : ICarYearService
    {
        private readonly ICarYearDal carYearDal;
        private readonly IMapper mapper;
        public CarYearManager(ICarYearDal carYearDal,IMapper mapper)
        {
            this.carYearDal = carYearDal;
            this.mapper = mapper;
        }

        #region Activity
        public IResult Activity(int id)
        {
            carYearDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(CarYearValidator))]
        public IResult Add(CarYearDTO carYearDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExisted(carYearDTO.Year));
            if(result != null)
            {
                return result;
            }
            var caryear = mapper.Map<CarYear>(carYearDTO);
            carYearDal.Add(caryear);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAll
        public IDataResult<List<CarYearDTO>> GetAll()
        {
            var result = carYearDal.GetAllForHome();
            return new SuccessDataResult<List<CarYearDTO>>(result, Message.GetAll);
        }
        #endregion

        #region GetByID
        public IDataResult<CarYearDTO> GetById(int id)
        {
            return new SuccessDataResult<CarYearDTO>(carYearDal.GetByIdForHome(id), Message.ByFilter);
        }
        #endregion

        #region Update
        public IResult Update(CarYearDTO carYearDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExistedForUpdate(carYearDTO.Id, carYearDTO.Year));
            if(result != null)
            {
                return result;
            }
            var carYear = mapper.Map<CarYear>(carYearDTO);
            carYearDal.Update(carYear);
            return new SuccessResult(Message.Updated);
        }
        #endregion



        #region Business Code
        private IResult CheckIfNameExisted(string name)
        {
            var result = carYearDal.GetAll().Any(x => x.Year == name);
            if(result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfNameExistedForUpdate(int id,string name)
        {
            var result = carYearDal.GetAll(x=>x.Year==name && x.Id != id).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
