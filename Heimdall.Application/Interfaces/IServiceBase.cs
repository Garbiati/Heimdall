using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Heimdall.Application.Interfaces
{
    public interface IServiceBase<TEntity, TDTO, TCreateDTO, TUpdateDTO>
        where TEntity : class
    {
        //Create
        Task<TDTO> CreateAsync(TCreateDTO createDto);

        Task CreateRangeAsync(IEnumerable<TCreateDTO> createDtos);

        //Read
        Task<IEnumerable<TDTO>> GetAllAsync();
        ValueTask<TDTO> GetByIdAsync(Guid id);

        //Update
        Task UpdateAsync(TUpdateDTO updateDto);

        Task UpdateRangeAsync(IEnumerable<TUpdateDTO> updateDtos);

        //Delete
        Task DeleteAsync(Guid id);

        Task DeleteRangeAsync(IEnumerable<Guid> ids);

        //Paging
        Task<(IEnumerable<TDTO> Items, int TotalCount, int TotalPages)> GetPagedAsync(
            Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize);

        //Exists
        Task<bool> ExistsAsync(Guid id);
    }
}
