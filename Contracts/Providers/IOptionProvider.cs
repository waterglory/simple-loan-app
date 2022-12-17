using Simple.Loan.App.Contracts.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Loan.App.Contracts.Providers
{
    public interface IOptionProvider
    {
        Task<IEnumerable<BindingPeriod>> GetBindingPeriods();
    }
}
