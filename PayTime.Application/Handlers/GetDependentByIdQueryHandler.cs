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
    public class GetDependentsByIdQueryHandler : HandlerBase<List<DependentDto>>, IRequestHandler<GetDependentsByIdQuery, Result<List<DependentDto>, Error>>
    {
        private readonly ILogger<GetDependentsByIdQueryHandler> _logger;
        private readonly string fileName = "Dependents.json";

        public GetDependentsByIdQueryHandler(ILogger<GetDependentsByIdQueryHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Result<List<DependentDto>, Error>> Handle(GetDependentsByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                using FileStream openStream = File.OpenRead(fileName);
                var dependentsDto = JsonSerializer.Deserialize<List<DependentDto>>(openStream);
                return dependentsDto.Where(d => d.EmployeeId == query.EmployeeId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error during {nameof(GetDependentsByIdQueryHandler)}. {ex.Message}");
                return ToResult(Errors.General.ApplicationError(ex.Message));
            }
        }
    }
}
