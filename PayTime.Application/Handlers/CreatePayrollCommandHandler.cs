using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PayTime.Application.Commands;
using PayTime.Application.Dtos;
using PayTime.Application.Queries;
using PayTime.Application.Responses;
using PayTime.Core.Errors;

namespace PayTime.Application.Handlers
{
    public class CreatePayrollCommandHandler : HandlerBase<CreatePayrollResponse>, IRequestHandler<CreatePayrollCommand, Result<CreatePayrollResponse, Error>>
    {
        private readonly ILogger<CreatePayrollCommandHandler> _logger;
        private readonly string fileName = "Payroll.json";
        private FileStream stream;

        public CreatePayrollCommandHandler(ILogger<CreatePayrollCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Result<CreatePayrollResponse, Error>> Handle(CreatePayrollCommand command, CancellationToken cancellationToken)
        {
            try
            {
                command.Payroll.Id = Guid.NewGuid();

                if (File.Exists(fileName))
                    stream = File.Open(fileName, FileMode.Append);
                else
                    stream = File.Create(fileName);

                await JsonSerializer.SerializeAsync(stream, command);
                await stream.DisposeAsync();

                var createPayrollResponse = new CreatePayrollResponse { PayrollId = command.Payroll.Id };
                return createPayrollResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error during {nameof(CreatePayrollCommandHandler)}. {ex.Message}");
                return ToResult(Errors.General.ApplicationError(ex.Message));
            }
        }
    }
}
