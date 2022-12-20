using System;

namespace Simple.Loan.App.Contracts.Models.LoanApplication
{
    public class LoanDetail
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public int PaymentPeriod { get; set; }

        public int BindingPeriod { get; set; }

        public decimal InterestRate { get; set; }
    }
}
