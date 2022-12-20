using Microsoft.EntityFrameworkCore;
using Simple.Loan.App.DataStores.DbContexts.Entities.LoanApplication;

namespace Simple.Loan.App.DataStores.DbContexts
{
    public class LoanApplicationDbContext : DbContext
    {
        public LoanApplicationDbContext(DbContextOptions<LoanApplicationDbContext> options) : base(options) { }

        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
