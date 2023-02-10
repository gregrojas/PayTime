using CSharpFunctionalExtensions;
using MediatR;
using PayTime.Application.Dtos;
using PayTime.Core.Errors;

namespace PayTime.Application.Queries
{
    public class GetDependentsByIdQuery : IRequest<Result<List<DependentDto>, Error>>
    {
        public string EmployeeId { get; set; }
    }
}
