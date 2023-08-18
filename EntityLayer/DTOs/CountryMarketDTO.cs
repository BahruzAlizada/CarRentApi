using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class CountryMarketDTO : IDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
    }
}
