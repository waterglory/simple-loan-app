using Microsoft.EntityFrameworkCore;
using Simple.Loan.App.Contracts.DataStores;
using Simple.Loan.App.DataStores.DbContexts;
using Simple.Loan.App.DataStores.DbContexts.Entities.LoanApplication;
using DocumentModel = Simple.Loan.App.Contracts.Models.LoanApplication.Document;
using LoanApplicationModel = Simple.Loan.App.Contracts.Models.LoanApplication.LoanApplication;

namespace Simple.Loan.App.DataStores.Repositories
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        private readonly LoanApplicationDbContext _dbContext;

        public LoanApplicationRepository(LoanApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> SaveLoanApplication(LoanApplicationModel model)
        {
            if (model == null) throw new ArgumentNullException();

            var loanApplication = new LoanApplication(model);
            loanApplication.CreatedDate = DateTime.Now;
            var newLoanApplication = _dbContext.Add(loanApplication);
            await _dbContext.SaveChangesAsync();

            return newLoanApplication.Entity.Id;
        }

        public async Task<IEnumerable<LoanApplicationModel>> GetAllLoanApplications() =>
            await _dbContext.LoanApplications
                .Include(la => la.Applicant)
                .Include(la => la.LoanDetail)
                .Include(la => la.Documents)
                .Select(la => la.ToDomainModel())
                .ToListAsync();

        public async Task<DocumentModel> GetDocument(Guid documentId)
        {
            var document = await _dbContext.Documents.FirstOrDefaultAsync(d => d.Id == documentId);
            return document?.ToDomainModel();
        }

        public async Task<LoanApplicationModel> GetOngoingLoanApplication(string organizationNo, params string[] ongoingSteps) =>
            (await _dbContext.LoanApplications.FirstOrDefaultAsync(la =>
                la.Applicant.OrganizationNo == organizationNo
                && ongoingSteps.Contains(la.CurrentStep)))?.ToDomainModel();
    }
}
