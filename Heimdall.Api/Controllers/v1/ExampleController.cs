using Heimdall.Api.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Heimdall.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ExampleController : ApiControllerBase
    {
        private readonly IExampleService _exampleService;
        public ExampleController()
        {
        }
    }
}