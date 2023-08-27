using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<CategoryWithSubCategoryDTO>> GetAllWithSubCategories();
        IDataResult<CategoryWithSubCategoryDTO> GetByIdWithSubCategories(int id);
        IDataResult<List<CategoryDTO>> GetAllJustCategory();
        IDataResult<CategoryDTO> GetByIdJustCategory(int id);
        IResult Activity(int id);
        IResult Add(CategoryDTO categoryDTO);
        IResult Update(CategoryDTO categoryDTO);
    }
}
