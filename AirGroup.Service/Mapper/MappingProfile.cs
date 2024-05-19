using AirGroup.Domain.Entity;
using AirGroup.Service.DTOS.AccountDtos;
using AirGroup.Service.DTOS.ProductDto;
using AirGroup.Service.DTOS.ProductDtos;
using AutoMapper;

namespace AirGroup.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, RegisterUserDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductEditDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            
        }
    }
}
