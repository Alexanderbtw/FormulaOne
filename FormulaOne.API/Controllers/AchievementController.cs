using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    public class AchievementController : BaseController
    {
        public AchievementController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);

            if (driverAchievements == null)
            {
                return NotFound("Achievements not found");
            }

            var result = _mapper.Map<DriverAchievementResponse>(driverAchievements);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _mapper.Map<Achievement>(achievement);

            await _unitOfWork.Achievements.AddAsync(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _mapper.Map<Achievement>(achievement);

            await _unitOfWork.Achievements.UpdateAsync(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
