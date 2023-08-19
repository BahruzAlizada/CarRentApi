using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class NumberSeatDTO : IDto
    {
        public int Id { get; set; }
        public string NumberSeat { get; set; }
    }
}
