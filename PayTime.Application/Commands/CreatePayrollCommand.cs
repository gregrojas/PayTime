using CSharpFunctionalExtensions;
using MediatR;
using PayTime.Application.Dtos;
using PayTime.Application.Responses;
using PayTime.Core.Errors;

namespace PayTime.Application.Commands
{
    public class CreatePayrollCommand : IRequest<Result<CreatePayrollResponse, Error>>
    {     
        public PayrollDto Payroll{ get; set; }
    }
}
