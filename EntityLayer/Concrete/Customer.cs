﻿using CoreLayer.Entities;
using System;


namespace EntityLayer.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsCompany { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public List<Car> Cars { get; set; }
    }
}
