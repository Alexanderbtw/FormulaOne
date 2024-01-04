using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IDriverRepository Drivers { get; }
        public IAchievementRepository Achievements { get; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;

            Drivers = new DriverRepository(_context, loggerFactory.CreateLogger<DriverRepository>());
            Achievements = new AchievementRepository(_context, loggerFactory.CreateLogger<AchievementRepository>());
        }

        public async Task<bool> CompleteAsync()
        {
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
