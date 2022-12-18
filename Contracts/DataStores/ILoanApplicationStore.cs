using Simple.Loan.App.Contracts.Models.Loan;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Loan.App.Contracts.DataStores
{
    public interface ILoanApplicationStore
    {
        Task<Guid> SaveLoanApplication(LoanApplication model);
        Task<LoanApplication> GetOngoingLoanApplication(string organizationNo, params string[] ongoingSteps);
        Task<IEnumerable<LoanApplication>> GetAllLoanApplications();
        Task<Document> GetDocument(Guid documentId);
    }
}
