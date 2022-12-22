using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Loan.App.Contracts.Providers;

namespace Simple.Loan.App.Providers.FileStore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFileStoreEFCoreProvider(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<FileDbContext>(o =>
                    o.UseSqlServer(configuration.GetConnectionString("FileConnection")))
                .AddScoped<IFileStoreProvider, FileStoreEFCoreProvider>();

    }
}
