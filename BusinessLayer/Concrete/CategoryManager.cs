using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Caching;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        private readonly IMapper mapper;
        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
            this.categoryDal = categoryDal;
            this.mapper = mapper;
        }

        #region Activity
        public IResult Activity(int id)
        {
            categoryDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(CategoryDTO categoryDTO)
        {
            var result = BusinessRules.Run(CheckNameIfExisted(categoryDTO.Name));
            if (result != null)
            {
                return result;
            }
            var category = mapper.Map<Category>(categoryDTO);
            category.Image = "1";
            categoryDal.Add(category);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAllWithSubCategories
        [CacheAspect]
		public IDataResult<List<CategoryWithSubCategoryDTO>> GetAllWithSubCategories()
		{
			var values = categoryDal.GetAllWithSubCategories();
            return new SuccessDataResult<List<CategoryWithSubCategoryDTO>>(values, Message.GetAll);
		}
		#endregion

		#region GetByidWithSubCategories
		public IDataResult<CategoryWithSubCategoryDTO> GetByIdWithSubCategories(int id)
		{
            var value = categoryDal.GetByIdwithSubCategories(id);
            return new SuccessDataResult<CategoryWithSubCategoryDTO>(value, Message.ByFilter);
		}
		#endregion

		#region GetAllJustCategory
		public IDataResult<List<CategoryDTO>> GetAllJustCategory()
        {
            return new SuccessDataResult<List<CategoryDTO>>(categoryDal.GetAllJustCategory(), Message.GetAll);
        }
		#endregion

		#region GetByIdJustCategory
		public IDataResult<CategoryDTO> GetByIdJustCategory(int id)
        {
            return new SuccessDataResult<CategoryDTO>(categoryDal.GetByIdJustCategory(id), Message.ByFilter);
        }
		#endregion

		#region Update
		[ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(CategoryDTO categoryDTO)
        {
            var result = BusinessRules.Run(CheckNameIfExistedForUpdated(categoryDTO.Id, categoryDTO.Name));
            if(result != null)
            {
                return result;
            }
            var category = mapper.Map<Category>(categoryDTO);
            category.Image = "2";
            categoryDal.Update(category);
            return new SuccessResult(Message.Updated);
        }
        #endregion



        #region BusinessCode
        private IResult CheckNameIfExisted(string name)
        {
            var result = categoryDal.GetAll(x=>x.Name==name).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }


        private IResult CheckNameIfExistedForUpdated(int id,string name)
        {
            var result = categoryDal.GetAll(x => x.Name == name && x.Id!=id).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
