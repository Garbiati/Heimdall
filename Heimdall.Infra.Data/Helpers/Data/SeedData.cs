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
            }
        }
    }
}
