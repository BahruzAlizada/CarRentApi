using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class CarYearDTO : IDto
    {
        public int Id { get; set; }
        public string Year { get; set; }
    }
}
