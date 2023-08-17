using CoreLayer.Entities;
using System;

namespace EntityLayer.Concrete
{
    public class CarYear : IEntity
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
