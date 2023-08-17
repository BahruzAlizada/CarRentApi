using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using BusinessLayer.ValidationRules.FluentValidation;
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
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly ISubCategoryDal subCategoryDal;
        private readonly IMapper mapper;
        public SubCategoryManager(ISubCategoryDal subCategoryDal,IMapper mapper)
        {
            this.subCategoryDal = subCategoryDal;
            this.mapper = mapper;
        }

        #region Activity
        public IResult Activity(int id)
        {
            subCategoryDal.Activity(id);
            return new SuccessResult(Message.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(SubCategoryValidator))]
        public IResult Add(SubCategoryDTO subCategoryDTO)
        {
            var result = BusinessRules.Run(CheckIfSubCategoryNameExisted(subCategoryDTO.Name));

            if (result != null)
            {
                return result;
            }

            var subcategory = mapper.Map<SubCategory>(subCategoryDTO);

            subCategoryDal.Add(subcategory);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAll
        public IDataResult<List<SubCategoryForHomeDTO>> GetAll()
        {
            return new SuccessDataResult<List<SubCategoryForHomeDTO>>(subCategoryDal.GetAllForHome(), Message.GetAll);
        }
        #endregion

        #region GetByID
        public IDataResult<SubCategoryForHomeDTO> GetById(int id)
        {
            var result = subCategoryDal.GetById(id);
            return new SuccessDataResult<SubCategoryForHomeDTO>(result, Message.ByFilter);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(SubCategoryValidator))]
        public IResult Update(SubCategoryDTO subCategory)
        {
            var result = BusinessRules.Run(CheckIfSubCategoryNameExistedForUpdate(subCategory.Id, subCategory.Name));
            if (result != null)
            {
                return result;
            }

            var subcthg = mapper.Map<SubCategory>(subCategory);

            subCategoryDal.Update(subcthg);
            return new SuccessResult(Message.Updated);
        }
        #endregion



        #region Business Code
        private IResult CheckIfSubCategoryNameExisted(string name)
        {
            var result = subCategoryDal.GetAll(x=>x.Name==name).Any();
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfSubCategoryNameExistedForUpdate(int id,string name)
        {
            var result = subCategoryDal.GetAll(x=>x.Name==name && x.Id != id).Any();
            if(result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion

    }
}
