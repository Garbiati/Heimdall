using Heimdall.Api.Controllers.Shared;
using Heimdall.Application.DTO.Example;
using Heimdall.Application.Interfaces;
using Heimdall.Domain.Entities;

namespace Heimdall.Api.Controllers.v1;
public class ExampleItemsController : ApiControllerBase<ExampleItem, ExampleItemDTO, ExampleItemCreateDTO, ExampleItemUpdateDTO>
{
    public ExampleItemsController(IServiceBase<ExampleItem, ExampleItemDTO, ExampleItemCreateDTO, ExampleItemUpdateDTO> service) : base(service)
    {
    }
}
