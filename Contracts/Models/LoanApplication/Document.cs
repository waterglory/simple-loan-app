using System;

namespace Simple.Loan.App.Contracts.Models.LoanApplication
{
    public class Document
    {
        public Guid Id { get; set; }

        public string DocumentType { get; set; }

        public string FileRef { get; set; }
    }
}
