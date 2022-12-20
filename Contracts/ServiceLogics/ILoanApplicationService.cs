using Simple.Loan.App.Contracts.Models;
using Simple.Loan.App.Contracts.Models.LoanApplication;
using Simple.Loan.App.Contracts.ServiceLogics.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Loan.App.Contracts.ServiceLogics
{
    public interface ILoanApplicationService
    {
        Task<string> CheckOngoingApplication(string organizationNo);
        Task<LoanApplicationSubmissionResult> SubmitLoanApplication(LoanApplication loanApplication);
        Task<IEnumerable<LoanApplication>> GetAllLoanApplications();
        Task<File> GetDocumentContent(Guid documentId);
    }
}
