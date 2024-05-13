using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Heimdall.Domain.Interfaces;
using Heimdall.Infra.Data.Context;
using Heimdall.Domain.Exceptions;

namespace Heimdall.Infra.Data.Repositories;
public class Repository<T> : IRepository<T>
where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
        => _context = context;

    //Create
    public virtual async Task CreateAsync(T entity)
        => await _context.Set<T>().AddAsync(entity);

    public virtual async Task CreateRangeAsync(IEnumerable<T> entities)
        => await _context.Set<T>().AddRangeAsync(entities);

    // Read
    public virtual async Task<IEnumerable<T>> ReadAllAsync()
        => await _context.Set<T>().ToListAsync();

    public virtual async ValueTask<T> ReadByIdAsync(Guid id)
        => await _context.Set<T>().FindAsync(id)
            ?? throw new NotFoundException(typeof(T).Name, id);

    // Update
    public virtual void Update(T entity)
        => _context.Set<T>().Update(entity);


    public virtual void UpdateRange(IEnumerable<T> entities)
        => _context.Set<T>().UpdateRange(entities);

    // Delete
    public virtual void Remove(T entity)
        => _context.Set<T>().Remove(entity);

    public virtual void RemoveRange(IEnumerable<T> entities)
        => _context.Set<T>().RemoveRange(entities);

    // Where
    public virtual async Task<IEnumerable<T>> ReadWhereAsync(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().Where(predicate).ToListAsync();

    public virtual async Task<IEnumerable<T>> ReadWhereWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        => await includeProperties.Aggregate(_context.Set<T>().Where(predicate), (current, includeProperty)
            => current.Include(includeProperty)).ToListAsync();

    //Count
    public virtual async ValueTask<int> CountAsync(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().CountAsync(predicate);

    public virtual async ValueTask<int> CountWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        => await includeProperties.Aggregate(_context.Set<T>().Where(predicate), (current, includeProperty)
            => current.Include(includeProperty)).CountAsync();

    //Skip and Take
    public virtual async Task<List<T>> ReadPagedAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize)
        => await _context.Set<T>()
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

    public virtual async Task<List<T>> ReadPagedWithIncludeAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<T, object>>[] includeProperties)
        => await includeProperties.Aggregate(_context.Set<T>().Where(predicate), (current, includeProperty)
            => current.Include(includeProperty))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

    // First
    public virtual async ValueTask<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().FirstOrDefaultAsync(predicate)
            ?? throw new NotFoundException(typeof(T).Name);

    public virtual async ValueTask<T> FirstOrDefaultWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        => await includeProperties.Aggregate(_context.Set<T>().Where(predicate), (current, includeProperty)
            => current.Include(includeProperty)).FirstOrDefaultAsync()
                ?? throw new NotFoundException(typeof(T).Name);

    //Exists
    public virtual async ValueTask<bool> HasAnyAsync()
        => await _context.Set<T>().AnyAsync();

    public virtual async ValueTask<bool> HasAnyAsync(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().AnyAsync(predicate);

    public virtual async ValueTask<bool> HasAnyWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        => await includeProperties.Aggregate(_context.Set<T>().Where(predicate), (current, includeProperty)
            => current.Include(includeProperty)).AnyAsync();
}