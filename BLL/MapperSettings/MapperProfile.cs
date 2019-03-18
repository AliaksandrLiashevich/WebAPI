using AutoMapper;
using BLL.Interfaces.Models;
using DAL.Interfaces.Entities;

namespace BLL.MapperSettings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DataAccessCategory, Category>();
            CreateMap<DataAccessProduct, Product>();
            CreateMap<CreateCategory, DataAccessCategory>()
                .ForMember(dc => dc.Id, opt => opt.Ignore())
                .ForMember(dc => dc.Products, opt => opt.Ignore());
            CreateMap<CreateProduct, DataAccessProduct>()
                .ForMember(dp => dp.Id, opt => opt.Ignore())
                .ForMember(dp => dp.Category, opt => opt.Ignore()); ;
        }
    }
}
