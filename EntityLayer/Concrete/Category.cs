using CoreLayer.Entities;
using System;


namespace EntityLayer.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public bool Status { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Car> Cars { get; set; }
    }
}
