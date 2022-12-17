using System;
using System.Collections.Generic;

namespace Simple.Loan.App.Contracts.Service.Models.Loan
{
    public class LoanApplication
    {
        public Guid Id { get; set; }

        public string CaseNo { get; set; }

        public string CurrentStep { get; set; }

        public DateTime CreatedDate { get; set; }

        public Applicant Applicant { get; set; }

        public LoanInfo Loan { get; set; }

        public List<Document> Documents { get; set; }
    }
}
