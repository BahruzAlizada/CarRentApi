using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class CarColor
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
