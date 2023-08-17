using CoreLayer.Entities;
using System;

namespace EntityLayer.Concrete
{
    public class CarNumberSeat : IEntity  //Oturacaqlarin sayi
    {
        public int Id { get; set; }
        public string NumberSeat { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
