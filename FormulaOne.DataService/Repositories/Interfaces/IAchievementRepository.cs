using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IAchievementRepository : IGenericRepository<Achievement>
    {
        Task<IEnumerable<Achievement>> GetDriverAchievementsAsync(Guid driverId);
    }
}
