using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface INewsletterService
    {
        public Task<IResult> Subscribe(Newsletter newsletter);
        IDataResult<List<Newsletter>> GetAll();

    }
}
