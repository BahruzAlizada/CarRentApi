using CoreLayer.Entities;
using System;

namespace EntityLayer.DTOs
{
    public class SubCategoryForHomeDTO : IDto
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeactive { get; set; }
    }
}
