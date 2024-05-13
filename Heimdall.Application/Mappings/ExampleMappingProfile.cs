using AutoMapper;
using Heimdall.Application.DTO.Example;
using Heimdall.Domain.Entities;

namespace Heimdall.Application.Mappings
{
    public class ExampleMappingProfile : Profile
    {
        public ExampleMappingProfile()
        {
            CreateMap<ExampleDTO, Example>();
            CreateMap<Example, ExampleDTO>();

            CreateMap<ExampleCreateDTO, Example>();
            CreateMap<Example, ExampleCreateDTO>();

            CreateMap<ExampleUpdateDTO, Example>();
            CreateMap<Example, ExampleUpdateDTO>();
        }
    }
}