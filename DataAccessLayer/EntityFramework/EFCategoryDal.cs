using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFCategoryDal : EfEntityRepositoryBase<Category, Context>, ICategoryDal
    {
        public void Activity(int id)
        {
            using (var context = new Context())
            {
                var category = context.Categories.SingleOrDefault(c => c.Id == id);
                if (category.Status)
                    category.Status = false;
                category.Status = true;

                context.SaveChanges();
            }
        }

        public List<CategoryDTO> GetAllJustCategory()
        {
           using(var context = new Context())
            {
                List<Category> categories = context.Categories.ToList();
                List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

                foreach (var item in categories)
                {
                    CategoryDTO dto = new CategoryDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                    };
                    categoryDTOs.Add(dto);
                }
                return categoryDTOs;
            }
        }

        public CategoryDTO GetByIdJustCategory(int id)
        {
            using(var context = new Context())
            {
                Category category = context.Categories.FirstOrDefault(x => x.Id == id);
                CategoryDTO categoryDTO = new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name
                };
                return categoryDTO;
            }
        }
    }
}
