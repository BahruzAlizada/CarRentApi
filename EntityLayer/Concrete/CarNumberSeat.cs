using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class CarNumberSeat  //Oturacaqlarin sayi
    {
        public int Id { get; set; }
        public string NumberSeat { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
