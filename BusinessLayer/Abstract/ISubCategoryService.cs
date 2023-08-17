using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface ISubCategoryService
    {
        IDataResult<List<SubCategoryForHomeDTO>> GetAll();
        IDataResult<SubCategoryForHomeDTO> GetById(int id);
        IResult Add(SubCategoryDTO subCategoryDTO);
        IResult Update(SubCategoryDTO subCategory);
        IResult Activity(int id);
    }
}
