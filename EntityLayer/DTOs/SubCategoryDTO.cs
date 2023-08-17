using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class SubCategoryDTO : IDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
