using CoreLayer.Entities;
using System;

namespace EntityLayer.Concrete
{
    public class Ban : IEntity
    {
        public int Id { get; set; }
        public string BanName { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
