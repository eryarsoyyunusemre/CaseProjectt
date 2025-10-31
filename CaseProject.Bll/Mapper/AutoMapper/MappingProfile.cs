using AutoMapper;
using CaseProject.Entities.Dto;
using CaseProject.Entities.Models;

namespace CaseProject.Bll.Mapper.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, DtoProduct>().ReverseMap();
        CreateMap<Company, DtoCompany>().ReverseMap();
    }

}