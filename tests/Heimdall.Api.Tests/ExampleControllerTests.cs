using Heimdall.Api.Controllers.v1;
using Heimdall.Application.DTO.Example;
using Heimdall.Application.Interfaces;
using Heimdall.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Heimdall.Tests
{
    public class ExampleControllerTests
    {
        private readonly Mock<IServiceBase<Example, ExampleDTO, ExampleCreateDTO, ExampleUpdateDTO>> _serviceMock;
        private readonly ExampleController _controller;

        public ExampleControllerTests()
        {
            _serviceMock = new Mock<IServiceBase<Example, ExampleDTO, ExampleCreateDTO, ExampleUpdateDTO>>();
            _controller = new ExampleController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfExamples()
        {
            // Arrange
            _serviceMock.Setup(service => service.GetAllAsync(false)).ReturnsAsync(GetTestExamples());

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<ExampleDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WithExample()
        {
            // Arrange
            var testId = Guid.NewGuid();
            _serviceMock.Setup(service => service.GetByIdAsync(testId, false)).ReturnsAsync(GetTestExample(testId));

            // Act
            var result = await _controller.GetById(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ExampleDTO>(okResult.Value);
            Assert.Equal(testId, returnValue.Id);
        }

        [Fact]
        public async Task GetById_ReturnsNotFoundResult()
        {
            // Arrange
            var testId = Guid.NewGuid();
            _serviceMock.Setup(service => service.GetByIdAsync(testId, false));

            // Act
            var result = await _controller.GetById(testId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var exampleCreateDto = new ExampleCreateDTO { Id = Guid.NewGuid(), StringExample = "Example" };
            var exampleDto = new ExampleDTO { Id = exampleCreateDto.Id, StringExample = "Example" };
            _serviceMock.Setup(service => service.CreateAsync(exampleCreateDto)).ReturnsAsync(exampleDto);

            // Act
            var result = await _controller.Create(exampleCreateDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<ExampleDTO>(createdAtActionResult.Value);
            Assert.Equal(exampleCreateDto.Id, returnValue.Id);
        }

        [Fact]
        public async Task Update_ReturnsNoContentResult()
        {
            // Arrange
            var testId = Guid.NewGuid();
            var exampleUpdateDto = new ExampleUpdateDTO { StringExample = "Updated Example" };

            _serviceMock.Setup(service => service.UpdateAsync(testId, exampleUpdateDto)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(testId, exampleUpdateDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_ReturnsNotFoundResult()
        {
            // Arrange
            var testId = Guid.NewGuid();
            var exampleUpdateDto = new ExampleUpdateDTO { StringExample = "Updated Example" };

            _serviceMock.Setup(service => service.UpdateAsync(testId, exampleUpdateDto)).Throws<KeyNotFoundException>();

            // Act
            var result = await _controller.Update(testId, exampleUpdateDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContentResult()
        {
            // Arrange
            var testId = Guid.NewGuid();

            _serviceMock.Setup(service => service.DeleteAsync(testId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(testId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundResult()
        {
            // Arrange
            var testId = Guid.NewGuid();

            _serviceMock.Setup(service => service.DeleteAsync(testId)).Throws<KeyNotFoundException>();

            // Act
            var result = await _controller.Delete(testId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        private List<ExampleDTO> GetTestExamples()
        {
            return new List<ExampleDTO>
            {
                new ExampleDTO { Id = Guid.NewGuid(), StringExample = "Example 1" },
                new ExampleDTO { Id = Guid.NewGuid(), StringExample = "Example 2" }
            };
        }

        private ExampleDTO GetTestExample(Guid id)
        {
            return new ExampleDTO { Id = id, StringExample = "Example" };
        }
    }
}
