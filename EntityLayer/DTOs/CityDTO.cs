using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class CityDTO : IDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
    }
}
