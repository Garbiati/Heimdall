using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Heimdall.Domain.Enums;

namespace Heimdall.Application.DTO.Example;

public class ExampleUpdateDTO
{
    [Required]
    public string StringExample { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string StringExampleWithMaxLenght { get; set; } = string.Empty;
    public string? StringNullableExample { get; set; } = null;
    public string? TextExample { get; set; } = null;
    [Required]
    public DateTimeOffset DateTimeOffsetExample { get; set; }
    public DateTimeOffset? DateTimeOffsetNullableExample { get; set; }
    [Required]
    public decimal DecimalExample { get; set; }
    [Required]
    public ExampleEnum EnumExample { get; set; }
    [AllowNull]
    public virtual ICollection<ExampleItemDTO> ExampleItems { get; set; }
}
