using CoreLayer.Entities;
using System;

namespace EntityLayer.DTOs
{
    public class GearBoxDTO : IDto
    {
        public int Id { get; set; }
        public string GearBox { get; set; }
    }
}
