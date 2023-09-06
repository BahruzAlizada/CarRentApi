using CoreLayer.Entities;
using System;

namespace EntityLayer.Concrete
{
    public class Car : IEntity
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
        public bool Status { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
       

        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public Ban Ban { get; set; }
        public List<CarImage> Images { get; set; }
        public CarYear CarYear { get; set; }
        public CarColor CarColor { get; set; }
        public CarCountryMarket CarCountryMarket { get; set; }
        public CarGearBox CarGearBox { get; set; }
        public CarNumberSeat CarNumberSeat { get; set; }
        public CarEngineType CarEngineType { get; set; }
        public City City { get; set; }
        public Customer Customer { get; set; }
    }
}
