using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories
{
    public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(AppDbContext context, ILogger logger) : base(context, logger)
        { }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(a => a.DriverId == driverId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetDriverAchievementAsync function error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<IEnumerable<Achievement>> GetAllAsync()
        {
            try
            {
                return await _dbSet.Where(a => a.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(a => a.AddedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAllAsync function error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(a => a.Id == id);

                if (result == null)
                    return false;

                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} DeleteAsync function error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<bool> UpdateAsync(Achievement achievement)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(a => a.Id == achievement.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.FastestLap = achievement.FastestLap;
                result.PolePositions = achievement.PolePositions;
                result.RaceWins = achievement.RaceWins;
                result.WorldChampionship = achievement.WorldChampionship;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} UpdateAsync function error", typeof(AchievementRepository));
                throw;
            }
        }
    }
}
