using System;

namespace Simple.Loan.App.Contracts.Models.Loan
{
    public class Document
    {
        public Guid Id { get; set; }

        public string DocumentType { get; set; }

        public string FileRef { get; set; }
    }
}
