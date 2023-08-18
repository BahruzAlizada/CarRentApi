using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Security.Cryptography.X509Certificates;

namespace BusinessLayer.Concrete
{
    public class BanManager : IBanService
    {
        private readonly IBanDal banDal;
        private readonly IMapper mapper;
        public BanManager(IBanDal banDal,IMapper mapper)
        {
            this.banDal = banDal;
            this.mapper = mapper;
        }

        #region Activtiy
        public IResult Activity(int id)
        {
            banDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        public IResult Add(BanDTO banDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExisted(banDTO.BanName));
            if (result != null)
            {
                return result;
            }
            var ban = mapper.Map<Ban>(banDTO);
            banDal.Add(ban);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAll
        public IDataResult<List<BanDTO>> GetAll()
        {
            return new SuccessDataResult<List<BanDTO>>(banDal.GetAllForHome(), Message.GetAll);
        }
        #endregion

        #region GetById
        public IDataResult<BanDTO> GetById(int id)
        {
           return new SuccessDataResult<BanDTO>(banDal.GetByIdForHome(id),Message.ByFilter);
        }
        #endregion

        #region Update
        public IResult Update(BanDTO banDTO)
        {
            var result = BusinessRules.Run(CheckIfNameExisted(banDTO.Id,banDTO.BanName));
            if (result != null)
            {
                return result;
            }
            var ban = mapper.Map<Ban>(banDTO);
            banDal.Update(ban);
            return new SuccessResult(Message.Updated);
        }
        #endregion


        #region BusinessCode
        private IResult CheckIfNameExisted(string name)
        {
            var result = banDal.GetAll(x => x.BanName == name).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }


        private IResult CheckIfNameExisted(int id,string name)
        {
            var result = banDal.GetAll(x => x.BanName == name && x.Id!=id).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
