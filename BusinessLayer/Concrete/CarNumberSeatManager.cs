using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Concrete
{
    public class CarNumberSeatManager : ICarNumberSeatService
    {
        private readonly ICarNumberSeatDal carNumberSeatDal;
        private readonly IMapper mapper;
        public CarNumberSeatManager(ICarNumberSeatDal carNumberSeatDal,IMapper mapper)
        {
            this.carNumberSeatDal = carNumberSeatDal;
            this.mapper = mapper;
        }

        #region Activtiy
        public IResult Activity(int id)
        {
            carNumberSeatDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(NumberSeatValidator))]
        public IResult Add(NumberSeatDTO numberSeatDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExisted(numberSeatDTO.NumberSeat));
            if (result != null)
            {
                return result;
            }
            var countryMarket = mapper.Map<CarNumberSeat>(numberSeatDTO);
            carNumberSeatDal.Add(countryMarket);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAll
        public IDataResult<List<NumberSeatDTO>> GetAll()
        {
            var result = carNumberSeatDal.GetAllForHome();
            return new SuccessDataResult<List<NumberSeatDTO>>(result, Message.GetAll);
        }
        #endregion

        #region GetById
        public IDataResult<NumberSeatDTO> GetById(int id)
        {
            return new SuccessDataResult<NumberSeatDTO>(carNumberSeatDal.GetByIdForHome(id), Message.ByFilter);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(NumberSeatValidator))]
        public IResult Update(NumberSeatDTO numberSeatDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExistedForUpdated(numberSeatDTO.Id, numberSeatDTO.NumberSeat));
            if (result != null)
            {
                return result;
            }
            var numberSeat = mapper.Map<CarNumberSeat>(numberSeatDTO);
            carNumberSeatDal.Update(numberSeat);
            return new SuccessResult(Message.Updated);
        }
        #endregion

        #region BusinessCode
        private IResult CheckIfNameExisted(string name)
        {
            var result = carNumberSeatDal.GetAll(x => x.NumberSeat == name).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfNameExistedForUpdated(int id, string name)
        {
            var result = carNumberSeatDal.GetAll(x => x.NumberSeat == name && x.Id != id).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
