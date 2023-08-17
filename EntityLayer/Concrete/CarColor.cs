using CoreLayer.Entities;
using System;

namespace EntityLayer.Concrete
{
    public class CarColor : IEntity
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
