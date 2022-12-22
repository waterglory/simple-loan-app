using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Loan.App.Contracts.Providers;

namespace Simple.Loan.App.Providers.Customer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomerEFCoreProvider(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<CustomerDbContext>(o =>
                    o.UseSqlServer(configuration.GetConnectionString("CustomerConnection")))
                .AddScoped<ICustomerProvider, CustomerEFCoreProvider>();

    }
}
