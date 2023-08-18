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
    public class CarCountryMarketManager : ICarCountryMarketService
    {
        private readonly ICarCountryMarketDal carCountryMarketDal;
        private readonly IMapper mapper;
        public CarCountryMarketManager(ICarCountryMarketDal carCountryMarketDal,IMapper mapper)
        {
            this.carCountryMarketDal=carCountryMarketDal;
            this.mapper = mapper;
        }

        #region Activtiy
        public IResult Activity(int id)
        {
            carCountryMarketDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(CountryMarketValidator))]
        public IResult Add(CountryMarketDTO countryMarketDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExisted(countryMarketDTO.Country));
            if(result != null)
            {
                return result;
            }
            var countryMarket = mapper.Map<CarCountryMarket>(countryMarketDTO);
            carCountryMarketDal.Add(countryMarket);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAll
        public IDataResult<List<CountryMarketDTO>> GetAll()
        {
            var result = carCountryMarketDal.GetAllForHome();
            return new SuccessDataResult<List<CountryMarketDTO>>(result, Message.GetAll);
        }
        #endregion

        #region GetById
        public IDataResult<CountryMarketDTO> GetById(int id)
        {
            return new SuccessDataResult<CountryMarketDTO>(carCountryMarketDal.GetByIdForHome(id), Message.ByFilter);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(CountryMarketValidator))]
        public IResult Update(CountryMarketDTO countryMarketDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExistedForUpdated(countryMarketDTO.Id, countryMarketDTO.Country));
            if(result != null)
            {
                return result;
            }
            var countryMarket = mapper.Map<CarCountryMarket>(countryMarketDTO);
            carCountryMarketDal.Update(countryMarket);
            return new SuccessResult(Message.Updated);
        }
        #endregion

        #region BusinessCode
        private IResult CheckIfNameExisted(string name)
        {
            var result = carCountryMarketDal.GetAll(x=>x.Country==name).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfNameExistedForUpdated(int id,string name)
        {
            var result = carCountryMarketDal.GetAll(x => x.Country == name && x.Id!=id).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
