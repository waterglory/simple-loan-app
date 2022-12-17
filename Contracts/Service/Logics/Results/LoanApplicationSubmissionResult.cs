using System.Collections.Generic;

namespace Simple.Loan.App.Contracts.Service.Logics.Results
{
    public class LoanApplicationSubmissionResult
    {
        public List<string> ValidationMessages { get; set; }
        public string OngoingCaseNo { get; set; }
        public string CaseNo { get; set; }
    }
}
