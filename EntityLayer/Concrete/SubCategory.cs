using System;

namespace EntityLayer.Concrete
{
    public class SubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public Category Category { get; set; }
        public List<Car> Cars { get; set; }
    }
}
