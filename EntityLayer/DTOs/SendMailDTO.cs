using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class SendMailDTO : IDto
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
