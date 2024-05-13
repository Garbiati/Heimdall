using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Heimdall.Domain.Entities;

namespace Heimdall.Infra.Data.EntitiesConfiguration;

public class ExampleConfiguration : IEntityTypeConfiguration<Example>
{
       public void Configure(EntityTypeBuilder<Example> builder)
       {
              builder.HasKey(e => e.Id);
              builder.Property(e => e.StringExample).IsRequired();
              builder.Property(e => e.StringExampleWithMaxLenght).HasMaxLength(100).IsRequired();
              builder.Property(e => e.StringNullableExample);
              builder.Property(e => e.TextExample);
              builder.Property(e => e.DateTimeOffsetExample).IsRequired();
              builder.Property(e => e.DateTimeOffsetNullableExample);
              builder.Property(e => e.DecimalExample).IsRequired();
              builder.Property(e => e.EnumExample).IsRequired();
              builder.Property(e => e.CreatedAt).IsRequired();
              builder.Property(e => e.UpdatedAt);
              builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
              builder.Property(e => e.DeletedAt);
              builder.HasMany(e => e.ExampleItems).WithOne(e => e.Example).HasForeignKey(e => e.ExampleId);
       }
}
