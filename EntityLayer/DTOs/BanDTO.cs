using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class BanDTO : IDto
    {
        public int Id { get; set; }
        public string BanName { get; set; }
    }
}
