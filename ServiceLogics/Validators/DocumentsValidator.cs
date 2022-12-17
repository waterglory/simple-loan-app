using Simple.Loan.App.Contracts.Service.Logics;
using Simple.Loan.App.Contracts.Service.Models.Loan;

namespace Nordax.Bank.Recruitment.Domain.Validators
{
    public class DocumentsValidator : ILoanApplicationValidator
    {
        public bool Validate(LoanApplication loanApplication, out string reason)
        {
            reason = null;
            return true;
        }
    }
}
