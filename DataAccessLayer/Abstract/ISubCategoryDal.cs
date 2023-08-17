using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface ISubCategoryDal : IEntityRepository<SubCategory>
    {
        List<SubCategoryForHomeDTO> GetAllForHome();
        SubCategoryForHomeDTO GetById(int id);
        void Activity(int id);
    }
}
