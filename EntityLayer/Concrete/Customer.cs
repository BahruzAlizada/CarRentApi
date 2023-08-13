using System;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public bool IsCompany { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
