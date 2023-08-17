using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFSubcategoryDal : EfEntityRepositoryBase<SubCategory, Context>, ISubCategoryDal
    {
        public void Activity(int id)
        {
            using (var context = new Context())
            {
                var sbct = context.SubCategories.FirstOrDefault(x=>x.Id== id);

                if(sbct.IsDeactive)
                    sbct.IsDeactive=false;
                else
                    sbct.IsDeactive=true;

                context.SaveChanges();
            }
        }

        public List<SubCategoryForHomeDTO> GetAllForHome()
        {
            using (var context = new Context())
            {
                List<SubCategory> subCategories = context.SubCategories.Include(x => x.Category).ToList();
                List<SubCategoryForHomeDTO> subCategoryForHomeDTOs = new List<SubCategoryForHomeDTO>();

                foreach (var item in subCategoryForHomeDTOs)
                {
                    SubCategoryForHomeDTO dto = new SubCategoryForHomeDTO
                    {
                        Id = item.Id,
                        SubCategoryName = item.SubCategoryName,
                        CategoryName = item.CategoryName,
                        IsDeactive=item.IsDeactive
                    };
                    subCategoryForHomeDTOs.Add(dto);
                }
                return subCategoryForHomeDTOs;
            }
        }

        public SubCategoryForHomeDTO GetById(int id)
        {
            using (var context=new Context())
            {
                SubCategory subCategory = context.SubCategories.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
                SubCategoryForHomeDTO subCategoryForHomeDTO = new SubCategoryForHomeDTO
                {
                    Id = subCategory.Id,
                    SubCategoryName = subCategory.Name,
                    CategoryName = subCategory.Category.Name
                };

                return subCategoryForHomeDTO;
            }
        }
    }
}
