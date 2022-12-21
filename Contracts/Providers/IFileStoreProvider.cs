using Simple.Loan.App.Contracts.Models;
using Simple.Loan.App.Contracts.Providers.Results;
using System.Threading.Tasks;

namespace Simple.Loan.App.Contracts.Providers
{
    public interface IFileStoreProvider
    {
        Task<File> GetFile(string fileRef);
        Task<SaveFileResult> SaveFile(string documentType, string fileFullName, string contentType, byte[] content, bool force = false);
    }
}
