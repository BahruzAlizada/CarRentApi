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
    public class CarEngineTypeManager : ICarEngineTypeService
    {
        private readonly ICarEngineTypeDal carEngineTypeDal;
        private readonly IMapper mapper;
        public CarEngineTypeManager(ICarEngineTypeDal carEngineTypeDal,IMapper mapper)
        {
            this.carEngineTypeDal = carEngineTypeDal;
            this.mapper = mapper;
        }

        #region Activity
        public IResult Activity(int id)
        {
            carEngineTypeDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(CarEngineTypeValidator))]
        public IResult Add(EngineTypeDTO engineTypeDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExisted(engineTypeDTO.EngineType));
            if(result != null)
            {
                return result;
            }
            var engineType = mapper.Map<CarEngineType>(engineTypeDTO);
            carEngineTypeDal.Add(engineType);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAll
        public IDataResult<List<EngineTypeDTO>> GetAll()
        {
            return new SuccessDataResult<List<EngineTypeDTO>>(carEngineTypeDal.GetAllForHome(),Message.GetAll);
        }
        #endregion

        #region GetById
        public IDataResult<EngineTypeDTO> GetById(int id)
        {
            return new SuccessDataResult<EngineTypeDTO>(carEngineTypeDal.GetById(id), Message.ByFilter);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(CarEngineTypeValidator))]
        public IResult Update(EngineTypeDTO engineTypeDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExistedForUpdated(engineTypeDTO.Id,engineTypeDTO.EngineType));
            if (result != null)
            {
                return result;
            }
            var engineType = mapper.Map<CarEngineType>(engineTypeDTO);
            carEngineTypeDal.Update(engineType);
            return new SuccessResult(Message.Updated);
        }
        #endregion


        #region BusinessCode
        private IResult CheckIfNameExisted(string name)
        {
            var result = carEngineTypeDal.GetAll(x=>x.EngineType==name).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfNameExistedForUpdated(int id,string name)
        {
            var result = carEngineTypeDal.GetAll(x => x.EngineType == name && x.Id!=id).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
