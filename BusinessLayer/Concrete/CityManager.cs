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
    public class CityManager : ICityService
    {
        private readonly ICityDal cityDal;
        private readonly IMapper mapper;
        public CityManager(ICityDal cityDal,IMapper mapper)
        {
            this.cityDal = cityDal;
            this.mapper = mapper;
        }

        #region Activity
        public IResult Activity(int id)
        {
            cityDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(CityValidator))]
        public IResult Add(CityDTO cityDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExisted(cityDTO.CityName));
            if(result != null)
            {
                return result;
            }
            City city = mapper.Map<City>(cityDTO);
            cityDal.Add(city);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAll
        public IDataResult<List<CityDTO>> GetAll()
        {
            var cities = cityDal.GetAllForHome();
            return new SuccessDataResult<List<CityDTO>>(cities, Message.GetAll);
        }
        #endregion

        #region GetById
        public IDataResult<CityDTO> GetById(int id)
        {
            var city = cityDal.GetCityById(id);
            return new SuccessDataResult<CityDTO>(city, Message.ByFilter);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(CityValidator))]
        public IResult Update(CityDTO cityDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExistedForUpdated(cityDTO.Id,cityDTO.CityName));
            if (result != null)
            {
                return result;
            }
            City city = mapper.Map<City>(cityDTO);
            cityDal.Update(city);
            return new SuccessResult(Message.Updated);
        }
        #endregion


        #region BusinessCode
        private IResult CheckIfNameExisted(string name)
        {
            var result = cityDal.GetAll().Any(x => x.CityName == name);
            if(result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfNameExistedForUpdated(int id, string name)
        {
            var result = cityDal.GetAll().Any(x => x.CityName == name && x.Id != id);
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion

    }
}
