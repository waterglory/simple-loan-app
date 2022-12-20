using Simple.Loan.App.Contracts.Models.LoanApplication;

namespace Simple.Loan.App.Contracts.ServiceLogics
{
    public interface ILoanApplicationValidator
    {
        bool Validate(LoanApplication loanApplication, out string reason);
    }
}
