
using System.Linq.Expressions;
using AutoMapper;
using Heimdall.Application.Interfaces;
using Heimdall.Domain.Interfaces;

namespace Heimdall.Application.Services;
public class ServiceBase<TEntity, TDTO, TCreateDTO, TUpdateDTO> : IServiceBase<TEntity, TDTO, TCreateDTO, TUpdateDTO>
    where TEntity : class
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public ServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
    {
        var entities = await _unitOfWork.GetRepository<TEntity>().ReadAllAsync();
        return _mapper.Map<IEnumerable<TDTO>>(entities);
    }

    public virtual async ValueTask<TDTO> GetByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.GetRepository<TEntity>().ReadByIdAsync(id);
        return _mapper.Map<TDTO>(entity);
    }

    public virtual async Task<TDTO> CreateAsync(TCreateDTO createDto)
    {
        var entity = _mapper.Map<TEntity>(createDto);
        await _unitOfWork.GetRepository<TEntity>().CreateAsync(entity);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<TDTO>(entity);
    }

    public virtual async Task UpdateAsync(TUpdateDTO updateDto)
    {
        var entity = _mapper.Map<TEntity>(updateDto);
        _unitOfWork.GetRepository<TEntity>().Update(entity);
        await _unitOfWork.CompleteAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _unitOfWork.GetRepository<TEntity>().ReadByIdAsync(id);
        if (entity == null)
            throw new InvalidOperationException("Entity not found");

        _unitOfWork.GetRepository<TEntity>().Remove(entity);
        await _unitOfWork.CompleteAsync();
    }

    public virtual async Task<(IEnumerable<TDTO> Items, int TotalCount, int TotalPages)> GetPagedAsync(
        Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize)
    {
        int totalCount = await _unitOfWork.GetRepository<TEntity>().CountAsync(predicate);
        int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        List<TEntity> pageData = await _unitOfWork.GetRepository<TEntity>().ReadPagedAsync(predicate, pageNumber, pageSize);
        IEnumerable<TDTO> mappedData = _mapper.Map<IEnumerable<TDTO>>(pageData);

        return (mappedData, totalCount, totalPages);
    }

}