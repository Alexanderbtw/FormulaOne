using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(AppDbContext context, ILogger<DriverRepository> logger) : base(context, logger)
        { }

        public override async Task<bool> UpdateAsync(Driver driver)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(d => d.Id == driver.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.DriverNumber = driver.DriverNumber;
                result.FirstName = driver.FirstName;
                result.LastName = driver.LastName;
                result.DateOfBirth = driver.DateOfBirth;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} UpdateAsync function error", typeof(DriverRepository));
                throw;
            }
        }
    }
}
