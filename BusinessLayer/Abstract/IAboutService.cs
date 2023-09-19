using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        IDataResult<About> GetAbout();
        IDataResult<About> GetAboutById(int id);  
        IResult Update(AboutDTO aboutDTO);
    }
}
