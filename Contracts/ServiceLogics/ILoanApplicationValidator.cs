using Simple.Loan.App.Contracts.Models.Loan;

namespace Simple.Loan.App.Contracts.ServiceLogics
{
    public interface ILoanApplicationValidator
    {
        bool Validate(LoanApplication loanApplication, out string reason);
    }
}
