using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories
{
    public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(AppDbContext context, ILogger<AchievementRepository> logger) : base(context, logger)
        { }

        public async Task<IEnumerable<Achievement>> GetDriverAchievementsAsync(Guid driverId)
        {
            try
            {
                return await _dbSet.Where(a => a.DriverId == driverId && a.Status == 1).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetDriverAchievementAsync function error", typeof(AchievementRepository));
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
