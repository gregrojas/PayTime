using System.Data;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayTime.Application.Commands;
using PayTime.Application.Dtos;
using PayTime.Application.Queries;
using PayTime.Core.Constants;

namespace PayTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PayrollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = UserRoles.Groups.Changer)]
        [Route("Get")]
        public async Task<IActionResult> GetPayrollList(Guid payrollId)
        {
            try
            {
                var result = await _mediator.Send(new GetPayrollByIdQuery() { PayrollId = payrollId });

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
        //[Authorize(Roles = UserRoles.Groups.Changer)]
        [Route("Create")]
        public async Task<IActionResult> CreatePayroll([FromBody] PayrollDto payroll)
        {
            try
            {
                var result = await _mediator.Send(new CreatePayrollCommand() { Payroll = payroll });

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
    }
}
