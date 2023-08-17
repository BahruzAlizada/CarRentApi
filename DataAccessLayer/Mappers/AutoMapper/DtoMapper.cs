using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace DataAccessLayer.Mappers.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
        }
    }
}
