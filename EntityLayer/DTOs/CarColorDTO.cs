using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class CarColorDTO : IDto
    {
        public int Id { get; set; }
        public string Color { get; set; }
    }
}
