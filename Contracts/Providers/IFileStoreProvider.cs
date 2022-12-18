using Simple.Loan.App.Contracts.Models;
using System.Threading.Tasks;

namespace Simple.Loan.App.Contracts.Providers
{
    public interface IFileStoreProvider
    {
        Task<File> GetFile(string fileRef);
        Task<string> SaveFile(string documentType, string fileFullName, string contentType, byte[] content);
    }
}
