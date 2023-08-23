using CoreLayer.Entities;
using System;


namespace EntityLayer.Concrete
{
    public class Newsletter : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
