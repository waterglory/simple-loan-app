using System.ComponentModel.DataAnnotations;
using File = Simple.Loan.App.Contracts.Models.File;

namespace Simple.Loan.App.Providers.FileStore.Entities
{
    public class FileRecord
    {
        public FileRecord() { }

        public FileRecord(File model)
        {
            FileRef = model.FileRef;
            FromDomainModel(model);
        }

        [Key][MaxLength(100)] public string FileRef { get; set; }

        [Required][MaxLength(100)] public string FileName { get; set; }

        [Required][MaxLength(100)] public string ContentType { get; set; }

        [Required] public byte[] Content { get; set; }

        [Required][MaxLength(20)] public string FileType { get; set; }

        public File ToDomainModel() =>
            new()
            {
                FileRef = FileRef,
                FileName = FileName,
                ContentType = ContentType,
                Content = Content,
                FileType = FileType
            };

        public void FromDomainModel(File model)
        {
            FileName = model.FileName;
            ContentType = model.ContentType;
            Content = model.Content;
            FileType = model.FileType;
        }
    }
}
