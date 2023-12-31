﻿using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace DataAccessLayer.Mappers.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
            CreateMap<CarYear, CarYearDTO>().ReverseMap();
            CreateMap<CarCountryMarket,CountryMarketDTO>().ReverseMap();
            CreateMap<CarGearBox,GearBoxDTO>().ReverseMap();
            CreateMap<Ban,BanDTO>().ReverseMap();
            CreateMap<CarEngineType,EngineTypeDTO>().ReverseMap();
            CreateMap<CarNumberSeat,NumberSeatDTO>().ReverseMap();
            CreateMap<CarColor,CarColorDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<City,CityDTO>().ReverseMap();
            CreateMap<Car,CarDTO>().ReverseMap();
            CreateMap<Customer,CompanyDTO>().ReverseMap();
            CreateMap<Customer,PersonDTO>().ReverseMap();
            CreateMap<Faq,FaqDTO>().ReverseMap();
            CreateMap<About,AboutDTO>().ReverseMap();
            CreateMap<Slider,SliderDTO>().ReverseMap();
        }
    }
}
