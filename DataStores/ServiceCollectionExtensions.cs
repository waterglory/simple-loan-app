using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Loan.App.Contracts.DataStores;
using Simple.Loan.App.DataStores.DbContexts;
using Simple.Loan.App.DataStores.Repositories;

namespace Simple.Loan.App.DataStores
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataStores(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<LoanApplicationDbContext>(o => 
                    o.UseSqlServer(configuration.GetConnectionString("LoanApplicationConnection")))
                .AddScoped<ILoanApplicationRepository, LoanApplicationRepository>();
    }
}
