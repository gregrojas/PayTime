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

namespace PayTime.UnitTests.API.Controllers
{
    public class PayrollControllerTest
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly List<PayrollDto> _payroll;
        private readonly Guid payrollId1 = Guid.NewGuid();
        private readonly Guid payrollId2 = Guid.NewGuid();

        public PayrollControllerTest()
        {
            _mockMediator = new Mock<IMediator>();
            _payroll = new List<PayrollDto>
            {
                new PayrollDto()
                {
                    Id = payrollId1,
                    Paychecks = new List<PaycheckDto>
                    {
                        new PaycheckDto()
                        {
                            Id = Guid.NewGuid(),
                            EmployeeId = "A1",
                            NumOfDependents = 2,
                            NumOfDiscounts = 0,
                            NetSalary = 1000D,
                            CreatedDateTime = DateTime.Now,
                            ModifiedDateTime = DateTime.Now
                        },
                        new PaycheckDto()
                        {
                            Id = Guid.NewGuid(),
                            EmployeeId = "A2",
                            NumOfDependents = 1,
                            NumOfDiscounts = 1,
                            NetSalary = 1500D,
                            CreatedDateTime = DateTime.Now,
                            ModifiedDateTime = DateTime.Now
                        }
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                },
                new PayrollDto()
                {
                    Id = payrollId2,
                    Paychecks = new List<PaycheckDto>
                    {
                        new PaycheckDto()
                        {
                            Id = Guid.NewGuid(),
                            EmployeeId = "A1",
                            NumOfDependents = 2,
                            NumOfDiscounts = 0,
                            NetSalary = 1000D,
                            CreatedDateTime = DateTime.Now,
                            ModifiedDateTime = DateTime.Now
                        },
                        new PaycheckDto()
                        {
                            Id = Guid.NewGuid(),
                            EmployeeId = "A2",
                            NumOfDependents = 1,
                            NumOfDiscounts = 1,
                            NetSalary = 1500D,
                            CreatedDateTime = DateTime.Now,
                            ModifiedDateTime = DateTime.Now
                        }
                    },
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                }
            };
        }

        [Fact]
        public async Task CanGetPayroll()
        {
            _mockMediator.Setup(p => p.Send(It.IsAny<GetPayrollByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Result.Success<List<PayrollDto>, Error>(_payroll)));

            var controller = new PayrollController(_mockMediator.Object);

            //Act
            var result = await controller.GetPayrollList(payrollId1);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var payroll = okObjectResult.Value as IReadOnlyCollection<PayrollDto>;
            Assert.NotNull(payroll);
            Assert.Equal(1, payroll.Count);
        }
    }
}
