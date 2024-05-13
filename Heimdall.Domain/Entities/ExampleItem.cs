namespace Heimdall.Domain.Entities;
using System;

public class ExampleItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid ExampleId { get; set; }
    public virtual Example? Example { get; set; }
}
