using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace BusinessLayer.Concrete
{
    public class CarGearBoxManager : ICarGearBoxService
    {
        private readonly ICarGearBoxDal carGearBoxDal;
        private readonly IMapper mapper;
        public CarGearBoxManager(ICarGearBoxDal carGearBoxDal,IMapper mapper)
        {
            this.carGearBoxDal= carGearBoxDal;
            this.mapper = mapper;
        }

        #region Activity
        public IResult Activity(int id)
        {
            carGearBoxDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        public IResult Add(GearBoxDTO gearBoxDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExisted(gearBoxDTO.GearBox));
            if (result != null)
            {
                return result;
            }
            var gearBox = mapper.Map<CarGearBox>(gearBoxDTO);
            carGearBoxDal.Add(gearBox);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAll
        public IDataResult<List<GearBoxDTO>> GetAll()
        {
            return new SuccessDataResult<List<GearBoxDTO>>(carGearBoxDal.GetAllForHome(),Message.GetAll);
        }
        #endregion

        #region GetById
        public IDataResult<GearBoxDTO> GetById(int id)
        {
            return new SuccessDataResult<GearBoxDTO>(carGearBoxDal.GetByIdForHome(id), Message.ByFilter);
        }
        #endregion

        #region Update
        public IResult Update(GearBoxDTO gearBoxDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExistedForUpdated(gearBoxDTO.Id,gearBoxDTO.GearBox));
            if (result != null)
            {
                return result;
            }
            var gearBox = mapper.Map<CarGearBox>(gearBoxDTO);
            carGearBoxDal.Update(gearBox);
            return new SuccessResult(Message.Added);
        }
        #endregion


        #region BusinessCode
        private IResult CheckIfNameExisted(string name)
        {
            var result = carGearBoxDal.GetAll(x => x.GearBox == name).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfNameExistedForUpdated(int id,string name)
        {
            var result = carGearBoxDal.GetAll(x => x.GearBox == name && x.Id!=id).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
