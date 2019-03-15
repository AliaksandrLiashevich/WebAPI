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
            CreateMap<Category, DataAccessCategory>();
            CreateMap<DataAccessProduct, Product>();
            CreateMap<Product, DataAccessProduct>();
        }
    }
}
