using Heimdall.Domain.Entities;

namespace Heimdall.Domain.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IRepository<T> GetRepository<T>() where T : class;

    IRepository<Example> Examples { get; }

    Task<int> CompleteAsync();
}