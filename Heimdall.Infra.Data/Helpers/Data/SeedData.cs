using Heimdall.Domain.Entities;
using Heimdall.Infra.Data.Context;
using System;

namespace Heimdall.Infra.Data.Helpers.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Examples.Any())
            {
                context.Add(new Example
                {
                    Id = Guid.NewGuid(),
                    StringExample = "Example 1",
                    DateTimeOffsetExample = DateTimeOffset.Now,
                    DecimalExample = 1.1m,
                    EnumExample = Domain.Enums.ExampleEnum.Value1,
                    StringExampleWithMaxLenght = "Example 1",
                    TextExample = "Example 1",
                    StringNullableExample = null,
                    DateTimeOffsetNullableExample = null,
                    ExampleItems = new List<ExampleItem>
                    {
                        new ExampleItem
                        {
                            Name = "Example Item 1",
                            Description = "Description of Example Item 1"
                        },
                        new ExampleItem
                        {
                            Name = "Example Item 2",
                            Description = "Description of Example Item 2"
                        }
                    }
                });

                context.SaveChanges();


                context.Add(new Example
                {
                    Id = Guid.NewGuid(),
                    StringExample = "Example 2",
                    DateTimeOffsetExample = DateTimeOffset.Now,
                    DecimalExample = 2.2m,
                    EnumExample = Domain.Enums.ExampleEnum.Value2,
                    StringExampleWithMaxLenght = "Example 2",
                    TextExample = "Example 2",
                    StringNullableExample = null,
                    DateTimeOffsetNullableExample = null,
                    ExampleItems = new List<ExampleItem>
                    {
                        new ExampleItem
                        {
                            Name = "Example Item 3",
                            Description = "Description of Example Item 3"
                        },
                        new ExampleItem
                        {
                            Name = "Example Item 4",
                            Description = "Description of Example Item 4"
                        }
                    }
                });

                context.SaveChanges();

                context.Add(new Example
                {
                    Id = Guid.NewGuid(),
                    StringExample = "Example 3",
                    DateTimeOffsetExample = DateTimeOffset.Now,
                    DecimalExample = 3.3m,
                    EnumExample = Domain.Enums.ExampleEnum.Value3,
                    StringExampleWithMaxLenght = "Example 3",
                    TextExample = "Example 3",
                    StringNullableExample = null,
                    DateTimeOffsetNullableExample = null,
                    ExampleItems = new List<ExampleItem>
                    {
                        new ExampleItem
                        {
                            Name = "Example Item 5",
                            Description = "Description of Example Item 5"
                        },
                        new ExampleItem
                        {
                            Name = "Example Item 6",
                            Description = "Description of Example Item 6"
                        }
                    }
                });

                context.SaveChanges();

                context.Add(new Example
                {
                    Id = Guid.NewGuid(),
                    StringExample = "Example 4",
                    DateTimeOffsetExample = DateTimeOffset.Now,
                    DecimalExample = 4.4m,
                    EnumExample = Domain.Enums.ExampleEnum.Value2,
                    StringExampleWithMaxLenght = "Example 4",
                    TextExample = "Example 4",
                    StringNullableExample = null,
                    DateTimeOffsetNullableExample = null,
                    ExampleItems = new List<ExampleItem>
                    {
                        new ExampleItem
                        {
                            Name = "Example Item 7",
                            Description = "Description of Example Item 7"
                        },
                        new ExampleItem
                        {
                            Name = "Example Item 8",
                            Description = "Description of Example Item 8"
                        }
                    }
                });

                context.SaveChanges();

                context.Add(new Example
                {
                    Id = Guid.NewGuid(),
                    StringExample = "Example 5",
                    DateTimeOffsetExample = DateTimeOffset.Now,
                    DecimalExample = 5.5m,
                    EnumExample = Domain.Enums.ExampleEnum.Value3,
                    StringExampleWithMaxLenght = "Example 5",
                    TextExample = "Example 5",
                    StringNullableExample = null,
                    DateTimeOffsetNullableExample = null,
                    ExampleItems = new List<ExampleItem>
                    {
                        new ExampleItem
                        {
                            Name = "Example Item 9",
                            Description = "Description of Example Item 9"
                        },
                        new ExampleItem
                        {
                            Name = "Example Item 10",
                            Description = "Description of Example Item 10"
                        }
                    }
                });

            }
        }
    }
}
