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
using PayTime.Application.Responses;
using PayTime.Core.Errors;
using PayTime.Application.Commands;

namespace PayTime.Application.Handlers
{
    public class AddDependentCommandHandler : HandlerBase<AddDependentResponse>, IRequestHandler<AddDependentCommand, Result<AddDependentResponse, Error>>
    {
        private readonly ILogger<AddDependentCommandHandler> _logger;
        private readonly string fileName = "Dependents.json";
        private FileStream stream;

        public AddDependentCommandHandler(ILogger<AddDependentCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Result<AddDependentResponse, Error>> Handle(AddDependentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                command.Dependent.Id = Guid.NewGuid();

                if (File.Exists(fileName))
                    stream = File.Open(fileName, FileMode.Append);
                else
                    stream = File.Create(fileName);
                
                await JsonSerializer.SerializeAsync(stream, command);
                await stream.DisposeAsync();

                var newDependentResponse = new AddDependentResponse { DependentId = command.Dependent.Id };
                return newDependentResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error during {nameof(AddDependentCommandHandler)}. {ex.Message}");
                return ToResult(Errors.General.ApplicationError(ex.Message));
            }
        }
    }
}
