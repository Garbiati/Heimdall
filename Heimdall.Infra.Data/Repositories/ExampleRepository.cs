using System;
using System.Collections.Generic;
using Heimdall.Persistence.Repositories;
using Heimdall.Domain.Entities;
using Heimdall.Domain.Interfaces;
using Heimdall.Domain.Validations;
using Heimdall.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Heimdall.Infra.Data.Repositories;

public class ExampleRepository : BaseRepository<Example>, IExampleRepository
{
    public ExampleRepository(ApplicationDbContext context) : base(context) { }

    public async ValueTask<IReadOnlyCollection<Example>> GetByName(string filterName, int pageNumber, int pageSize)
    {
        if (string.IsNullOrWhiteSpace(filterName))
        {
            throw new ArgumentNullException(nameof(filterName));
        }

        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber));
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize));
        }

        return await Context.Examples
            .Where(x => x.StringExample.Contains(filterName))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async ValueTask<int> CountByName(string filterName)
    {
        if (string.IsNullOrWhiteSpace(filterName))
        {
            throw new ArgumentNullException(nameof(filterName));
        }

        return await Context.Examples
            .Where(x => x.StringExample.Contains(filterName))
            .CountAsync();
    }
}
