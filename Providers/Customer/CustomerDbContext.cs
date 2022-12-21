using Microsoft.EntityFrameworkCore;
using Simple.Loan.App.Providers.Customer.Entities;

namespace Simple.Loan.App.Providers.Customer
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<CustomerInfo> CustomerInfos { get; set; }
    }
}
