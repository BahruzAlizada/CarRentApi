using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityLayer.Concrete
{
    public class CarEngineCapacity // Mühərrikin həcmi
    {
        public int Id { get; set; }
        public string EngineCapacity { get; set; }
        public bool Status { get; set; }
        public Car Car { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
    }
}
