using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class CategoryDTO : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
