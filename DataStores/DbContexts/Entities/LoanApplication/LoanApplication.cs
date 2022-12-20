using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoanApplicationModel = Simple.Loan.App.Contracts.Models.LoanApplication.LoanApplication;

namespace Simple.Loan.App.DataStores.DbContexts.Entities.LoanApplication
{
    [Index(nameof(CaseNo), IsUnique = true)]
    public class LoanApplication
    {
        public LoanApplication() { }

        public LoanApplication(LoanApplicationModel model)
        {
            Id = model.Id;
            FromDomainModel(model);
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }

        [Required][MaxLength(20)] public string CaseNo { get; set; }

        [Required][MaxLength(20)] public string CurrentStep { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required] public Applicant Applicant { get; set; }

        [Required] public LoanDetail LoanDetail { get; set; }

        [Required] public List<Document> Documents { get; set; }

        public LoanApplicationModel ToDomainModel() =>
            new()
            {
                Id = Id,
                CaseNo = CaseNo,
                CurrentStep = CurrentStep,
                CreatedDate = CreatedDate,
                Applicant = Applicant?.ToDomainModel(),
                LoanDetail = LoanDetail?.ToDomainModel(),
                Documents = Documents?.Select(d => d.ToDomainModel()).ToList()
            };

        public void FromDomainModel(LoanApplicationModel model)
        {
            CaseNo = model.CaseNo;
            CurrentStep = model.CurrentStep;
            CreatedDate = model.CreatedDate;
            Applicant = new Applicant(model.Applicant);
            LoanDetail = new LoanDetail(model.LoanDetail);
            Documents = model.Documents.Select(d => new Document(d)).ToList();
        }
    }
}
