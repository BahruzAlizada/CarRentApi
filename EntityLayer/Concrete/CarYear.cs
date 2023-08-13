using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class CarYear
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
