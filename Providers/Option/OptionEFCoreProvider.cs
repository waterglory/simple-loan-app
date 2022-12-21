using Microsoft.EntityFrameworkCore;
using Simple.Loan.App.Contracts.Models;
using Simple.Loan.App.Contracts.Providers;

namespace Simple.Loan.App.Providers.Option
{
    public class OptionEFCoreProvider : IOptionProvider
    {
        private readonly OptionDbContext _dbContext;

        public OptionEFCoreProvider(OptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<BindingPeriod>> GetBindingPeriods() =>
            _dbContext.BindingPeriods.Select(bp => bp.ToDomainModel()).ToListAsync();
    }
}
