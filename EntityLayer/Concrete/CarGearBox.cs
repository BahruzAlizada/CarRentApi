using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CarGearBox //Sürətlər qutusu
    {
        public int Id { get; set; }
        public string GearBox { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
