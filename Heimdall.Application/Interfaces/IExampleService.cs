using Heimdall.Application.ViewModels;
using Heimdall.Application.ViewModels.Example;

namespace Heimdall.Application.Interfaces;
public interface IExampleService
{
    Task CreateExample(ExampleViewModel exampleViewModel);
    ValueTask<ExampleViewModel> GetExample(Guid id);
    ValueTask<List<ExampleViewModel>> GetAllExamples();
    Task UpdateExample(ExampleViewModel exampleViewModel);
    Task DeleteExample(Guid id);
    Task HardDeleteExample(Guid id);

    ValueTask<PagedResult<ExampleViewModel>> GetExamplesByName(string filterName, int pageNumber, int pageSize);
}