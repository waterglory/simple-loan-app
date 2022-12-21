using Microsoft.EntityFrameworkCore;
using Simple.Loan.App.Providers.FileStore.Entities;

namespace Simple.Loan.App.Providers.FileStore
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options) { }

        public DbSet<FileRecord> FileRecords { get; set; }
    }
}
