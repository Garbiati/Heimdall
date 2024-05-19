using Heimdall.Application.DTO.Example;
using Heimdall.Application.Interfaces;
using Heimdall.Domain.Entities;

public interface IExampleService : IServiceBase<Example, ExampleDTO, ExampleCreateDTO, ExampleUpdateDTO>
{

}