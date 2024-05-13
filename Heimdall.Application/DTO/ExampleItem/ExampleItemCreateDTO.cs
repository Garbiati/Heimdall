using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Heimdall.Application.DTO.Example;
public class ExampleItemCreateDTO
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public Guid ExampleId { get; set; }
    [AllowNull]
    public virtual ExampleDTO Example { get; set; }
}