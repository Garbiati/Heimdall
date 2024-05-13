using AutoMapper;
using Heimdall.Application.DTO.Example;
using Heimdall.Domain.Entities;

namespace Heimdall.Application.Mappings
{
    public class ExampleItemMappingProfile : Profile
    {
        public ExampleItemMappingProfile()
        {
            CreateMap<ExampleItemDTO, ExampleItem>();
            CreateMap<ExampleItem, ExampleItemDTO>();

            CreateMap<ExampleItemCreateDTO, ExampleItem>();
            CreateMap<ExampleItem, ExampleItemCreateDTO>();

            CreateMap<ExampleItemUpdateDTO, ExampleItem>();
            CreateMap<ExampleItem, ExampleItemUpdateDTO>();
        }
    }
}