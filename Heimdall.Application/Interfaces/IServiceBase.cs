using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Heimdall.Application.Interfaces
{
    public interface IServiceBase<TDto, TEntity, TCreateDto, TUpdateDto>
        where TEntity : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(Guid id);
        Task<TDto> CreateAsync(TCreateDto createDto);
        Task UpdateAsync(TUpdateDto updateDto);
        Task DeleteAsync(Guid id);
        Task<(IEnumerable<TDto> Items, int TotalCount, int TotalPages)> GetPagedAsync(
            Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize);
    }
}
