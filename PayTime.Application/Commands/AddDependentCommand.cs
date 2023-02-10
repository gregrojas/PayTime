using CSharpFunctionalExtensions;
using MediatR;
using PayTime.Application.Dtos;
using PayTime.Application.Responses;
using PayTime.Core.Errors;

namespace PayTime.Application.Commands
{
    public class AddDependentCommand : IRequest<Result<AddDependentResponse, Error>>
    {
        public DependentDto Dependent { get; set; }
    }
}
