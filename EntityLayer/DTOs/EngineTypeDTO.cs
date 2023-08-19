using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class EngineTypeDTO : IDto
    {
        public int Id { get; set; }
        public string EngineType { get; set; }
    }
}
