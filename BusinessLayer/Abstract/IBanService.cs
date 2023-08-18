using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface IBanService
    {
        IDataResult<List<BanDTO>> GetAll();
        IDataResult<BanDTO> GetById(int id);
        IResult Add(BanDTO banDTO);
        IResult Update(BanDTO banDTO);
        IResult Activity(int id);
    }
}
