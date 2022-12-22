using Microsoft.Extensions.DependencyInjection;
using Nordax.Bank.Recruitment.Domain.Validators;
using Simple.Loan.App.Contracts.ServiceLogics;

namespace Simple.Loan.App.ServiceLogics
{
    public static class ServiceCollectionExtensions
    {
        private static IServiceCollection AddValidator<TValidator>(this IServiceCollection services)
            where TValidator : class, ILoanApplicationValidator =>
            services.AddSingleton<ILoanApplicationValidator, TValidator>();

        public static IServiceCollection AddServiceLogics(this IServiceCollection services) =>
            services
                .AddScoped<ILoanApplicationService, LoanApplicationService>()
                .AddValidator<AgeValidator>()
                .AddValidator<BindingPeriodValidator>()
                .AddValidator<DocumentsValidator>()
                .AddValidator<EmailValidator>()
                .AddValidator<LoanAmountValidator>()
                .AddValidator<NameValidator>()
                .AddValidator<OrganizationNoValidator>()
                .AddValidator<PhoneValidator>();
    }
}
