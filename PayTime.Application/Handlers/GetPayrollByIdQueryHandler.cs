using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PayTime.Application.Dtos;
using PayTime.Application.Queries;
using PayTime.Core.Errors;

namespace PayTime.Application.Handlers
{
    public class GetPayrollByIdQueryHandler : HandlerBase<List<PayrollDto>>, IRequestHandler<GetPayrollByIdQuery, Result<List<PayrollDto>, Error>>
    {
        private readonly ILogger<GetPayrollByIdQueryHandler> _logger;
        private readonly string fileName = "Payroll.json";

        public GetPayrollByIdQueryHandler(ILogger<GetPayrollByIdQueryHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Result<List<PayrollDto>, Error>> Handle(GetPayrollByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                using FileStream openStream = File.OpenRead(fileName);
                var payrollDto = await JsonSerializer.DeserializeAsync<List<PayrollDto>>(openStream);
                return payrollDto.Where(d => d.Id == query.PayrollId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error during {nameof(GetPayrollByIdQueryHandler)}. {ex.Message}");
                return ToResult(Errors.General.ApplicationError(ex.Message));
            }
        }
    }
}
