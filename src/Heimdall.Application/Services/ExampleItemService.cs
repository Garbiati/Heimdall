using Heimdall.Application.DTO.Example;
using Heimdall.Domain.Entities;
using Heimdall.Application.Interfaces;
using Heimdall.Domain.Interfaces;
using AutoMapper;

namespace Heimdall.Application.Services;

public class ExampleItemService : ServiceBase<ExampleItem, ExampleItemDTO, ExampleItemCreateDTO, ExampleItemUpdateDTO>, IExampleItemService
{
    public ExampleItemService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}

