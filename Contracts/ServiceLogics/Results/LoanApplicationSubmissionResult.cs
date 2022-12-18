using System.Collections.Generic;

namespace Simple.Loan.App.Contracts.ServiceLogics.Results
{
    public class LoanApplicationSubmissionResult
    {
        public List<string> ValidationMessages { get; set; }
        public string OngoingCaseNo { get; set; }
        public string CaseNo { get; set; }
    }
}
