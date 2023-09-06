using CoreLayer.Entities;
using System;


namespace EntityLayer.DTOs
{
    public class CarDTO : IDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int BanId { get; set; }
        public int CarYearId { get; set; }
        public int CarColorId { get; set; }
        public int CarCountryMarketId { get; set; }
        public int CarGearBoxId { get; set; }
        public int CarNumberSeatId { get; set; }
        public int CarEngineTypeId { get; set; }
        public int CityId { get; set; }
        public int CustomerId { get; set; }

        public double Km { get; set; }
        public double EnginePower { get; set; }
        public string Description { get; set; }
        public double DailyPrice { get; set; }
        public int seen { get; set; }
        public bool IsNew { get; set; }
        public bool Insurance { get; set; }


        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public bool CustomerIsCompany { get; set; }
    }
}
