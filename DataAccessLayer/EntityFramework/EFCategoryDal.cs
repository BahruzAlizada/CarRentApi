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
		#region Activity
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
		#endregion

		#region GetAllWithSubCategories
		public List<CategoryWithSubCategoryDTO> GetAllWithSubCategories()
		{
			using(var context = new Context())
			{
				List<Category> categories = context.Categories.ToList();
				List<CategoryWithSubCategoryDTO> categoryWithSubCategoryDTOs = new List<CategoryWithSubCategoryDTO>();

				foreach (var item in categories)
				{
					CategoryWithSubCategoryDTO dto = new CategoryWithSubCategoryDTO
					{
						Id = item.Id,
						CategoryName = item.Name,
						SubCategories = item.SubCategories.Where(x => x.CategoryId == item.Id).
						Select(x => x.Name).ToList(),
					};
					categoryWithSubCategoryDTOs.Add(dto);
				}
				return categoryWithSubCategoryDTOs;
			}
		}
		#endregion

		#region GetByIdWithSubCategories
		public CategoryWithSubCategoryDTO GetByIdwithSubCategories(int id)
		{
			using (var context = new Context())
			{
				var category = context.Categories.SingleOrDefault(x => x.Id == id);
				CategoryWithSubCategoryDTO categoryWithSubCategoryDTO = new CategoryWithSubCategoryDTO
				{
					Id = category.Id,
					CategoryName = category.Name,
					SubCategories = category.SubCategories.Where(x => x.CategoryId == id).
					Select(x => x.Name).ToList()
				};
				return categoryWithSubCategoryDTO;
			}
		}
		#endregion

		#region GetAllWithCategories
		public List<CategoryDTO> GetAllJustCategory()
		{
			using (var context = new Context())
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
		#endregion

		#region GetByIdJustCategory
		public CategoryDTO GetByIdJustCategory(int id)
		{
			using (var context = new Context())
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
		#endregion
	}
}
