using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Heimdall.Application.Interfaces
{
    public interface IServiceBase<TEntity, TDTO, TCreateDTO, TUpdateDTO>
        where TEntity : class
    {
        Task<IEnumerable<TDTO>> GetAllAsync();
        ValueTask<TDTO> GetByIdAsync(Guid id);
        Task<TDTO> CreateAsync(TCreateDTO createDto);
        Task UpdateAsync(TUpdateDTO updateDto);
        Task DeleteAsync(Guid id);
        Task<(IEnumerable<TDTO> Items, int TotalCount, int TotalPages)> GetPagedAsync(
            Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize);
    }
}
