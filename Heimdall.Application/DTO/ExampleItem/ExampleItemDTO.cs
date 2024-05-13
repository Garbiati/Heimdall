using System.ComponentModel.DataAnnotations;

namespace Heimdall.Application.DTO.Example;
public class ExampleItemDTO
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public Guid ExampleId { get; set; }
    public virtual ExampleDTO? Example { get; set; }
}