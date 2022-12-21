using Microsoft.EntityFrameworkCore;
using Simple.Loan.App.Contracts.Providers;
using Simple.Loan.App.Contracts.Providers.Results;
using Simple.Loan.App.Providers.FileStore.Entities;
using System.Reflection.Metadata.Ecma335;
using File = Simple.Loan.App.Contracts.Models.File;

namespace Simple.Loan.App.Providers.FileStore
{
    public class FileStoreEFCoreProvider : IFileStoreProvider
    {
        private readonly FileDbContext _dbContext;

        public FileStoreEFCoreProvider(FileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static (string, string) ExtractFilenameAndExtension(string fileFullName)
        {
            var dotIdx = fileFullName.LastIndexOf('.');
            var fileName = fileFullName[..dotIdx];
            var fileExt = fileFullName[(dotIdx + 1)..];
            return (fileName, fileExt);
        }

        public async Task<File> GetFile(string fileRef)
        {
            var file = await _dbContext.FileRecords.FirstOrDefaultAsync(f => f.FileRef == fileRef);
            return file?.ToDomainModel();
        }

        public async Task<SaveFileResult> SaveFile(string documentType, string fileFullName, string contentType, byte[] content, bool force = false)
        {
            if (string.IsNullOrWhiteSpace(documentType))
                throw new ArgumentException($"Argument '{documentType}' is null or empty.");
            if (string.IsNullOrWhiteSpace(fileFullName))
                throw new ArgumentException($"Argument '{fileFullName}' is null or empty.");
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            (var fileName, var fileExt) = ExtractFilenameAndExtension(fileFullName);
            var fileModel = new File
            {
                FileRef = $"{documentType}/{Guid.NewGuid()}",
                FileName = fileName,
                ContentType = contentType,
                Content = content,
                FileType = fileExt
            };

            var existingFile = await _dbContext.FileRecords.FirstOrDefaultAsync(f => f.FileRef == fileModel.FileRef);
            if (existingFile == null)
                _dbContext.Add(new FileRecord(fileModel));
            else if (force)
                existingFile.FromDomainModel(fileModel);
            else return new SaveFileResult { Conflict = true };

            await _dbContext.SaveChangesAsync();

            return new SaveFileResult { FileRef = fileModel.FileRef };
        }
    }
}
