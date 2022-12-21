using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BindingPeriodModel = Simple.Loan.App.Contracts.Models.BindingPeriod;

namespace Simple.Loan.App.Providers.Option.Entities
{
    public class BindingPeriod
    {
        [Key][Precision(3)][DatabaseGenerated(DatabaseGeneratedOption.None)] public int Length { get; set; }

        [Precision(8, 5)] public decimal InterestRate { get; set; }

        public BindingPeriodModel ToDomainModel() =>
            new()
            {
                Length = Length,
                InterestRate = InterestRate
            };
    }
}
