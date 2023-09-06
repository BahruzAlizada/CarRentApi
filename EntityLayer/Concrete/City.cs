using CoreLayer.Entities;
using System;


namespace EntityLayer.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public bool IsDeactive { get; set; }=false;
        public List<Car> Cars { get; set; }
    }
}
