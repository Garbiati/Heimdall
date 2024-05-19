using Heimdall.Api.Controllers.Shared;
using Heimdall.Application.DTO.Example;
using Heimdall.Application.Interfaces;
using Heimdall.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Heimdall.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ExampleController : ApiControllerBase<Example, ExampleDTO, ExampleCreateDTO, ExampleUpdateDTO>
    {
        public ExampleController(IServiceBase<Example, ExampleDTO, ExampleCreateDTO, ExampleUpdateDTO> service) : base(service)
        {
        }
    }
}