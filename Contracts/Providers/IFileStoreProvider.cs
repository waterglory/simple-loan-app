using Simple.Loan.App.Contracts.Service.Models;
using System.Threading.Tasks;

namespace Simple.Loan.App.Contracts.Providers
{
    public interface IFileStoreProvider
    {
        Task<File> GetFile(string fileRef);
        Task<string> SaveFile(string documentType, string fileFullName, string contentType, byte[] content);
    }
}
