using CSharpFunctionalExtensions;
using MediatR;
using PayTime.Application.Dtos;
using PayTime.Core.Errors;

namespace PayTime.Application.Queries
{
    public class GetPayrollByIdQuery : IRequest<Result<List<PayrollDto>, Error>>
    {
        public Guid PayrollId { get; set; }
    }
}
