using Simple.Loan.App.Contracts.Service.Models.Loan;

namespace Simple.Loan.App.Contracts.Service.Logics
{
    public interface ILoanApplicationValidator
    {
        bool Validate(LoanApplication loanApplication, out string reason);
    }
}
