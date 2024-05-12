using AutoMapper;
using Heimdall.Application.ViewModels.Example;
using Heimdall.Domain.Entities;

namespace Heimdall.Application.Mappings
{
    public class ExampleMappingProfile : Profile
{
    public ExampleMappingProfile()
    {
        CreateMap<ExampleViewModel, Example>();
        CreateMap<Example, ExampleViewModel>();
    }
}
}