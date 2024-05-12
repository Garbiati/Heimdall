using System;
using System.Collections.Generic;
using Heimdall.Domain.Entities;

namespace Heimdall.Domain.Interfaces;

public interface IExampleRepository : IBaseRepository<Example>
{
    ValueTask<IReadOnlyCollection<Example>> GetByName(string filterNamename, int pageNumber, int pageSize);
    ValueTask<int> CountByName(string filterName);
}
