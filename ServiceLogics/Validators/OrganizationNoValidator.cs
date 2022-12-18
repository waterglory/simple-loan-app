using Simple.Loan.App.Contracts.Models.Loan;
using Simple.Loan.App.Contracts.ServiceLogics;

namespace Nordax.Bank.Recruitment.Domain.Validators
{
    public class OrganizationNoValidator : ILoanApplicationValidator
    {
        public bool Validate(LoanApplication loanApplication, out string reason)
        {
            reason = null;
            return true;
        }
    }
}
