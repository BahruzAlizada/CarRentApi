using CoreLayer.Entities;
using System;

namespace EntityLayer.Concrete
{
    public class SubCategory : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsDeactive { get; set; }
        public Category Category { get; set; }
        public List<Car> Cars { get; set; }
    }
}
