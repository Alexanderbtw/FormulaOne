using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    public class DriverController : BaseController
    {
        public DriverController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var drivers = await _unitOfWork.Drivers.GetAllAsync();

            var result = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);

            return Ok(result);
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetAsync(driverId);

            if (driver == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetDriverResponse>(driver);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _mapper.Map<Driver>(driver);

            await _unitOfWork.Drivers.AddAsync(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _mapper.Map<Driver>(driver);

            await _unitOfWork.Drivers.UpdateAsync(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var result = await _unitOfWork.Drivers.DeleteAsync(driverId);
            if (!result)
            {
                NotFound();
            }

            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
