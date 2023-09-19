using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface IFaqService
    {
        IDataResult<List<Faq>> GetFaqs();
        IDataResult<Faq> GetFaq(int id);
        IResult Add(FaqDTO faqDTO);
        IResult Update(FaqDTO faqDTO);
        IResult Activity(int id);
    }
}
