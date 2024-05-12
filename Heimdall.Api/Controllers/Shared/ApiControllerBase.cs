using Microsoft.AspNetCore.Mvc;

namespace Heimdall.Api.Controllers.Shared;

[ApiController]
[Route("api/Heimdall/v{version:apiVersion}/[controller]")]
public class ApiControllerBase : ControllerBase { }