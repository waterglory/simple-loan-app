using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Loan.App.Contracts.Providers;

namespace Simple.Loan.App.Providers.Option
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOptionEFCoreProvider(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<OptionDbContext>(o =>
                    o.UseSqlServer(configuration.GetConnectionString("OptionConnection")))
                .AddScoped<IOptionProvider, OptionEFCoreProvider>();

    }
}
