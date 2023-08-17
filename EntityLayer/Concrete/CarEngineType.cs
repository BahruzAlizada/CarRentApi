using CoreLayer.Entities;
using System;

namespace EntityLayer.Concrete
{
    public class CarEngineType : IEntity //Benzin dizel və s
    {
        public int Id { get; set; }
        public string EngineType { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
