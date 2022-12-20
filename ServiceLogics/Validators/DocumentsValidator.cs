using Simple.Loan.App.Contracts.Models.LoanApplication;
using Simple.Loan.App.Contracts.ServiceLogics;

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
