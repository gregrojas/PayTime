using System.Data;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PayTime.Application.Commands;
using PayTime.Application.Dtos;
using PayTime.Application.Queries;
using PayTime.Core.Constants;

namespace PayTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentController : ControllerBase
    {
        private readonly ILogger<DependentController> _logger;
        private readonly IMediator _mediator;

        public DependentController(ILogger<DependentController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = UserRoles.Groups.Everyone)]
        [Route("Get")]
        public async Task<IActionResult> GetDependentsByEmployeeId(string employeeId)
        {
            try
            {
                var result = await _mediator.Send(new GetDependentsByIdQuery() { EmployeeId = employeeId });

                if (result.IsSuccess)
                    return Ok(result.Value);
                else
                    return BadRequest(result.Error.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }

        [HttpPost]
        //[Authorize(Roles = UserRoles.Groups.Everyone)]
        [Route("Add")]
        public async Task<IActionResult> AddDependent([FromBody] DependentDto dependent)
        {
            try
            {
                var result = await _mediator.Send(new AddDependentCommand() { Dependent = dependent });
                return Ok(result.Value);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }
    }
}
