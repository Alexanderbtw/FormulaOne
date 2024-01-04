using FormulaOne.API.Commands;
using FormulaOne.API.Queries;
using FormulaOne.Entities.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    public class AchievementController : BaseController
    {
        public AchievementController(IMediator mediator) : base(mediator)
        { }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            var query = new GetDriverAchievementsQuery(driverId);
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new CreateAchievementCommand(achievement);
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateAchievementCommand(achievement);
            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        [Route("{achieveId:guid}")]
        public async Task<IActionResult> DeleteAchievement(Guid achieveId)
        {
            var command = new DeleteAchievementCommand(achieveId);
            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }
    }
}
