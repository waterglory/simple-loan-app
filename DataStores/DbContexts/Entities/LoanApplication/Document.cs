using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DocumentModel = Simple.Loan.App.Contracts.Models.LoanApplication.Document;

namespace Simple.Loan.App.DataStores.DbContexts.Entities.LoanApplication
{
    public class Document
    {
        public Document() { }

        public Document(DocumentModel model)
        {
            Id = model.Id;
            FromDomainModel(model);
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }

        [Required][MaxLength(20)] public string DocumentType { get; set; }

        [Required][MaxLength(100)] public string FileRef { get; set; }

        public DocumentModel ToDomainModel() =>
            new()
            {
                Id = Id,
                DocumentType = DocumentType,
                FileRef = FileRef,
            };

        public void FromDomainModel(DocumentModel model)
        {
            DocumentType = model.DocumentType;
            FileRef = model.FileRef;
        }
    }
}
