using FormulaOne.API.Commands;
using FormulaOne.API.Queries;
using FormulaOne.Entities.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    public class DriverController : BaseController
    {
        public DriverController(IMediator mediator) : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDriversQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var query = new GetDriverQuery(driverId);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new CreateDriverCommand(driver);
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateDriverCommand(driver);
            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var command = new DeleteDriverCommand(driverId);
            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }
    }
}
