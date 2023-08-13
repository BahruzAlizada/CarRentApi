using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ban
    {
        public int Id { get; set; }
        public string BanName { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
