using CoreLayer.Entities;
using System;


namespace EntityLayer.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsCompany { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
    }
}
