namespace Heimdall.Domain.Entities;
using System;
using Heimdall.Domain.Common;

public class ExampleItem : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
    public Guid ExampleId { get; set; }
    public virtual Example? Example { get; set; }
}
