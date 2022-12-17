using Simple.Loan.App.Contracts.Service.Logics.Results;
using Simple.Loan.App.Contracts.Service.Models;
using Simple.Loan.App.Contracts.Service.Models.Loan;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Loan.App.Contracts.Service.Logics
{
    public interface ILoanApplicationService
    {
        Task<string> CheckOngoingApplication(string organizationNo);
        Task<LoanApplicationSubmissionResult> SubmitLoanApplication(LoanApplication loanApplication);
        Task<IEnumerable<LoanApplication>> GetAllLoanApplications();
        Task<File> GetDocumentContent(Guid documentId);
    }
}
