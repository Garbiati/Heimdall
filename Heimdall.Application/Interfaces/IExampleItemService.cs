using Heimdall.Application.DTO.Example;
using Heimdall.Application.Interfaces;
using Heimdall.Domain.Entities;

public interface IExampleItemService : IServiceBase<ExampleItem, ExampleItemDTO, ExampleItemCreateDTO, ExampleItemUpdateDTO>
{

}