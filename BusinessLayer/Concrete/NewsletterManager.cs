using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Helper;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class NewsletterManager : INewsletterService
    {
        private readonly INewsletterDal newsletterDal;
        public NewsletterManager(INewsletterDal newsletterDal)
        {
            this.newsletterDal = newsletterDal;
        }

        #region GetAll
        public IDataResult<List<Newsletter>> GetAll()
        {
            return new SuccessDataResult<List<Newsletter>>(newsletterDal.GetAll(), Message.GetAll);
        }
        #endregion

        #region Subscripe
        [ValidationAspect(typeof(NewsletterValidator))]
        public async Task<IResult> Subscribe(Newsletter newsletter)
        {
            var result = BusinessRules.Run(CheckIfEmailAdressExisted(newsletter.Email));
            if(result != null)
            {
                return result;
            }

            string subject = "Uğurla Abunə olundu";
            string message = "Artığ ən yeni xəbərlər endirim və kampaniyalardan ən birinci sənin xəbərin olacaq";
            await SendMail.SendMailAsync(subject, message, newsletter.Email);

            await newsletterDal.Subscribe(newsletter);
            return new SuccessResult(Message.Subscribed);
        }
        #endregion


        #region BusinessCode
        private IResult CheckIfEmailAdressExisted(string email)
        {
            var result = newsletterDal.GetAll(x => x.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Message.CheckEmail);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
