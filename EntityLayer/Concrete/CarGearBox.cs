using CoreLayer.Entities;
using System;

namespace EntityLayer.Concrete
{
    public class CarGearBox : IEntity //Sürətlər qutusu
    {
        public int Id { get; set; }
        public string GearBox { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
