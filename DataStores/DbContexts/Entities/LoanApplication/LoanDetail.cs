using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using LoanDetailModel = Simple.Loan.App.Contracts.Models.LoanApplication.LoanDetail;

namespace Simple.Loan.App.DataStores.DbContexts.Entities.LoanApplication
{
    public class LoanDetail
    {
        public LoanDetail() { }

        public LoanDetail(LoanDetailModel model)
        {
            Id = model.Id;
            FromDomainModel(model);
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }

        [Precision(14, 2)] public decimal Amount { get; set; }

        [Precision(4)] public int PaymentPeriod { get; set; }

        [Precision(3)] public int BindingPeriod { get; set; }

        [Precision(8, 5)] public decimal InterestRate { get; set; }

        public LoanDetailModel ToDomainModel() =>
            new()
            {
                Id = Id,
                Amount = Amount,
                PaymentPeriod = PaymentPeriod,
                BindingPeriod = BindingPeriod,
                InterestRate = InterestRate
            };

        public void FromDomainModel(LoanDetailModel model)
        {
            Amount = model.Amount;
            PaymentPeriod = model.PaymentPeriod;
            BindingPeriod = model.BindingPeriod;
            InterestRate = model.InterestRate;
        }
    }
}
