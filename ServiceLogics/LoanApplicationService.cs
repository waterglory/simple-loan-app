using Simple.Loan.App.Commons.OrganizationNo;
using Simple.Loan.App.Contracts.Models;
using Simple.Loan.App.Contracts.Models.LoanApplication;
using Simple.Loan.App.Contracts.Providers;
using Simple.Loan.App.Contracts.ServiceLogics;
using Simple.Loan.App.Contracts.ServiceLogics.Results;
using Simple.Loan.App.Contracts.DataStores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Loan.App.ServiceLogics
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly IEnumerable<ILoanApplicationValidator> _loanApplicationValidators;

        private readonly ICustomerProvider _customerProvider;
        private readonly IFileStoreProvider _fileStoreProvider;

        public LoanApplicationService(
            ILoanApplicationRepository loanApplicationRepository,
            IEnumerable<ILoanApplicationValidator> loanApplicationValidators,
            ICustomerProvider customerProvider,
            IFileStoreProvider fileStoreProvider)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _loanApplicationValidators = loanApplicationValidators;

            _customerProvider = customerProvider;
            _fileStoreProvider = fileStoreProvider;
        }

        private string GenerateCaseNo() => DateTime.UtcNow.ToString("MMhhyymmddss000fff");

        private List<string> Validate(LoanApplication loanApplication)
        {
            var reasons = new List<string>();
            foreach (var validator in _loanApplicationValidators)
            {
                if (!validator.Validate(loanApplication, out var reason))
                    reasons.Add(reason);
            }
            return reasons;
        }

        private async Task UpdateCustomer(Applicant applicant)
        {
            try
            {
                await _customerProvider.MergeCustomer(new Customer
                {
                    OrganizationNo = applicant.OrganizationNo,
                    FirstName = applicant.FirstName,
                    Surname = applicant.Surname,
                    Email = applicant.Email,
                    PhoneNo = applicant.PhoneNo,
                    Address = applicant.Address,
                    IncomeLevel = applicant.IncomeLevel,
                    IsPoliticallyExposed = applicant.IsPoliticallyExposed,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<string> CheckOngoingApplication(string organizationNo)
        {
            var ongoingApplication = await _loanApplicationRepository.GetOngoingLoanApplication(organizationNo.CleanUpOrganizationNo(), LoanApplicationStep.Verification);
            return ongoingApplication?.CaseNo;
        }

        /// <summary>
        /// Register a new loan application.
        /// </summary>
        /// <param name="loanApplication">The submitted loan application data.</param>
        /// <returns>An object containing the result of the operation.</returns>
        public async Task<LoanApplicationSubmissionResult> SubmitLoanApplication(LoanApplication loanApplication)
        {
            if (loanApplication == null) throw new ArgumentNullException("LoanApplication");
            if (loanApplication.Applicant == null) throw new ArgumentNullException(nameof(loanApplication.Applicant));
            if (loanApplication.LoanDetail == null) throw new ArgumentNullException(nameof(loanApplication.LoanDetail));
            if (loanApplication.Documents == null) throw new ArgumentNullException(nameof(loanApplication.Documents));

            loanApplication.CleanUpOrganizationNo();

            var validationMessages = Validate(loanApplication);
            if (validationMessages.Count > 0)
                return new LoanApplicationSubmissionResult { ValidationMessages = validationMessages };

            var ongoingCaseNo = await CheckOngoingApplication(loanApplication.Applicant.OrganizationNo);
            if (ongoingCaseNo != null)
                return new LoanApplicationSubmissionResult { OngoingCaseNo = ongoingCaseNo };

            loanApplication.Id = Guid.Empty;
            loanApplication.CaseNo = GenerateCaseNo();
            loanApplication.CurrentStep = LoanApplicationStep.Verification;
            await _loanApplicationRepository.SaveLoanApplication(loanApplication);

            await UpdateCustomer(loanApplication.Applicant);

            return new LoanApplicationSubmissionResult { CaseNo = loanApplication.CaseNo };
        }

        public Task<IEnumerable<LoanApplication>> GetAllLoanApplications() =>
            _loanApplicationRepository.GetAllLoanApplications();

        public async Task<File> GetDocumentContent(Guid documentId)
        {
            var document = await _loanApplicationRepository.GetDocument(documentId);
            return await _fileStoreProvider.GetFile(document.FileRef);
        }
    }
}
