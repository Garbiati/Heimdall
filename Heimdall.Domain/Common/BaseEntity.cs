using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Heimdall.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public DateTimeOffset CreatedAt { get; set; }
    [Required]
    public DateTimeOffset? UpdatedAt { get; set; }
    [Required]
    [DefaultValue(false)]
    public bool IsDeleted { get; set; } = false;
    [Required]
    public DateTimeOffset? DeletedAt { get; set; }
}