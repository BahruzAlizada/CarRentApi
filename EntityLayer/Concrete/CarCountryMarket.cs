using CoreLayer.Entities;
using System;

namespace EntityLayer.Concrete
{
    public class CarCountryMarket : IEntity //Hansı bazar üçün yığılıb
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
