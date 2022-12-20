using System;
using System.Collections.Generic;

namespace Simple.Loan.App.Contracts.Models.LoanApplication
{
    public class LoanApplication
    {
        public Guid Id { get; set; }

        public string CaseNo { get; set; }

        public string CurrentStep { get; set; }

        public DateTime CreatedDate { get; set; }

        public Applicant Applicant { get; set; }

        public LoanDetail LoanDetail { get; set; }

        public List<Document> Documents { get; set; }
    }
}
