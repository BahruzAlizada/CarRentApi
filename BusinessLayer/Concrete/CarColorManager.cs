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
    public class CarColorManager : ICarColorService
    {
        private readonly ICarColorDal carColorDal;
        private readonly IMapper mapper;
        public CarColorManager(ICarColorDal carColorDal,IMapper mapper)
        {
            this.carColorDal = carColorDal;
            this.mapper = mapper;
        }

        #region Activity
        public IResult Activity(int id)
        {
            carColorDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(CarColorValidator))]
        public IResult Add(CarColorDTO carColorDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExist(carColorDTO.Color));
            if(result != null)
            {
                return result;
            }
            var carColor = mapper.Map<CarColor>(carColorDTO);
            carColorDal.Add(carColor);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAll
        public IDataResult<List<CarColorDTO>> GetAll()
        {
            return new SuccessDataResult<List<CarColorDTO>>(carColorDal.GetAllForHome(), Message.GetAll);
        }
        #endregion

        #region GetById
        public IDataResult<CarColorDTO> GetById(int id)
        {
            return new SuccessDataResult<CarColorDTO>(carColorDal.GetByIdForHome(id),Message.ByFilter);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(CarColorValidator))]
        public IResult Update(CarColorDTO carColorDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExistForUpdated(carColorDTO.Id,carColorDTO.Color));
            if (result != null)
            {
                return result;
            }
            var carColor = mapper.Map<CarColor>(carColorDTO);
            carColorDal.Update(carColor);
            return new SuccessResult(Message.Updated);
        }
        #endregion


        #region BusinessCode
        private IResult CheckIfNameExist(string name)
        {
            var result = carColorDal.GetAll(x => x.Color == name).Any();
            if(result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }


        private IResult CheckIfNameExistForUpdated(int id,string name)
        {
            var result = carColorDal.GetAll(x => x.Color == name && x.Id != id).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
