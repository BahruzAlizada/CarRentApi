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
    public class FaqManager : IFaqService
    {
        private readonly IFaqDal faqDal;
        private readonly IMapper mapper;
        public FaqManager(IFaqDal faqDal,IMapper mapper)
        {
            this.faqDal=faqDal;
            this.mapper=mapper;
        }


       #region Activity
        public IResult Activity(int id)
        {
            faqDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(FaqValidator))]
        public IResult Add(FaqDTO faqDTO)
        {
            var faq = mapper.Map<Faq>(faqDTO);
            faqDal.Add(faq);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetFaq
        public IDataResult<Faq> GetFaq(int id)
        {
            var value = faqDal.Get(x => x.Id == id);
            return new SuccessDataResult<Faq>(value,Message.ByFilter);
        }
        #endregion

        #region GetFaqs
        public IDataResult<List<Faq>> GetFaqs()
        {
            var values = faqDal.GetAll();
            return new SuccessDataResult<List<Faq>>(values, Message.GetAll);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(FaqValidator))]
        public IResult Update(FaqDTO faqDTO)
        {
            var faq = mapper.Map<Faq>(faqDTO);
            faqDal.Update(faq);
            return new SuccessResult(Message.Added);
        }
        #endregion


        #region Business Rules

        #endregion
    }
}
