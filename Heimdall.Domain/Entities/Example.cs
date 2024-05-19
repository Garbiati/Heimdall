namespace Heimdall.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Heimdall.Domain.Common;
using Heimdall.Domain.Enums;

public class Example : BaseEntity
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
    public DateTime DateTimeExample { get; set; }

    public DateTime? DateTimeNullableExample { get; set; }

    [Required]
    public int IntExample { get; set; }

    public int? IntNullExample { get; set; }

    [Required]
    public decimal DecimalExample { get; set; }

    public decimal? DecimalNullExample { get; set; }

    public long LongExample { get; set; }

    public long? LongNullExample { get; set; }

    [Required]
    public ExampleEnum EnumExample { get; set; }

    public virtual ICollection<ExampleItem>? ExampleItems { get; set; }
}
