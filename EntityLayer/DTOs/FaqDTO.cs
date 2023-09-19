using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class FaqDTO : IDto
    {
        public int Id { get; set; }
        public string Quetsion { get; set; }
        public string Answer { get; set; }
    }
}
