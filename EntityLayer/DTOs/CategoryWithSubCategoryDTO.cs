using CoreLayer.Entities;
using System;

namespace EntityLayer.DTOs
{
	public class CategoryWithSubCategoryDTO : IDto
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }
		public List<string>? SubCategories { get; set; }
	}
}
