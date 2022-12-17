using Simple.Loan.App.Contracts.Service.Models;
using System.Threading.Tasks;

namespace Simple.Loan.App.Contracts.Providers
{
    public interface ICustomerProvider
    {
        Task MergeCustomer(Customer model);
        Task<Customer> GetCustomer(string organizationNo);
    }
}
