using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using PayTime.API.Controllers;
using PayTime.Application.Dtos;
using PayTime.Application.Queries;
using PayTime.Core.Errors;
using Xunit;
using Microsoft.Extensions.Logging;

namespace PayTime.UnitTests.API.Controllers
{
    public class DependentControllerTest
    {
        private Mock<ILogger<DependentController>> mockLogger;
        private readonly Mock<IMediator> _mockMediator;
        private readonly List<DependentDto> _dependents;
        private readonly string employeeId = "EmpId";

        public DependentControllerTest()
        {
            _mockMediator = new Mock<IMediator>();
            _dependents = new List<DependentDto>
            {
                new DependentDto()
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employeeId,
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Relation = 1
                },
                new DependentDto()
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employeeId,
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Relation = 0
                }
            }; 
        }

        [Fact]
        public async Task CanGetDependents()
        {
            _mockMediator.Setup(p => p.Send(It.IsAny<GetDependentsByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Result.Success<List<DependentDto>, Error>(_dependents)));

            var controller = new DependentController(mockLogger.Object, _mockMediator.Object);

            //Act
            var result = await controller.GetDependentsByEmployeeId(employeeId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var dependent = okObjectResult.Value as List<DependentDto>;
            Assert.NotNull(dependent);
            Assert.Equal(2, dependent.Count);
        }
    }
}
