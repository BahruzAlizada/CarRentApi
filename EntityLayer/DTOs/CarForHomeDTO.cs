using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class CarForHomeDTO : IDto
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Ban { get; set; }
        public string CarYear { get; set; }
        public string CarColor { get; set; }
        public string CarCountryMarket { get; set; }
        public string CarGearBox { get;set; }
        public string CarNumberSeat { get; set; }
        public string CarEngine { get; set; }
        public string City { get; set; }
        public double Km { get; set; }
        public double EnginePower { get; set; }
        public string Description { get; set; }
        public double DailyPrice { get; set; }
        public int seen { get; set; }
        public bool IsNew { get; set; }
        public bool Insurance { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreatedTime { get; set; }


    }
}
