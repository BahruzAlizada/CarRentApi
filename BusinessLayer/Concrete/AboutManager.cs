using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal aboutDal;
        private readonly IMapper mapper;
        public AboutManager(IAboutDal aboutDal,IMapper mapper)
        {
            this.aboutDal = aboutDal;
            this.mapper = mapper;
        }


        #region GetAbout
        public IDataResult<About> GetAbout()
        {
            var value = aboutDal.Get();
            return new SuccessDataResult<About>(value, Message.ByFilter);
        }
        #endregion

        #region GetAboutById
        public IDataResult<About> GetAboutById(int id)
        {
            var value = aboutDal.Get(x => x.Id == id);
            return new SuccessDataResult<About>(value, Message.ByFilter);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(AboutValidator))]
        public IResult Update(AboutDTO aboutDTO)
        {
            About about = mapper.Map<About>(aboutDTO);
            aboutDal.Update(about);
            return new SuccessResult(Message.Updated);
        }
        #endregion
    }
}
