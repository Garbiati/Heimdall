using Heimdall.Application.DTO.Example;
using Heimdall.Domain.Entities;
using Heimdall.Application.Interfaces;
using Heimdall.Domain.Interfaces;
using AutoMapper;

namespace Heimdall.Application.Services;

public class ExampleService : ServiceBase<Example, ExampleDTO, ExampleCreateDTO, ExampleUpdateDTO>, IExampleService
{
    public ExampleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}

