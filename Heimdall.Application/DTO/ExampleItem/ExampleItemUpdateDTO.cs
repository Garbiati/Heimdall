using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Heimdall.Application.DTO.Example;
public class ExampleItemUpdateDTO
{
    [AllowNull]
    public string Name { get; set; } = string.Empty;
    [AllowNull]
    public string Description { get; set; } = string.Empty;
    [AllowNull]
    public int Quantity { get; set; } = 0;
}