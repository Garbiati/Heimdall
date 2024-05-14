using Heimdall.Application.DTO.Example;
using Heimdall.Application.Interfaces;
using Heimdall.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Heimdall.Api.Controllers.Shared;

[ApiController]
[Route("api/Heimdall/v{version:apiVersion}/[controller]")]
public class ApiControllerBase<TEntity, TDto, TCreateDto, TUpdateDto> : ControllerBase
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    where TEntity : class
{
    protected readonly IServiceBase<TEntity, TDto, TCreateDto, TUpdateDto> _service;
    public ApiControllerBase(IServiceBase<TEntity, TDto, TCreateDto, TUpdateDto> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TDto>>> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TDto>> GetById(Guid id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<TDto>> Create([FromBody] TCreateDto createDto)
    {
        var item = await _service.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = ((dynamic)item).Id }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] TUpdateDto updateDto)
    {
        try
        {
            await _service.UpdateAsync(updateDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}