using Microsoft.EntityFrameworkCore;
using Simple.Loan.App.Contracts.Providers;
using Simple.Loan.App.Providers.Customer.Entities;
using CustomerModel = Simple.Loan.App.Contracts.Models.Customer;

namespace Simple.Loan.App.Providers.Customer
{
    public class CustomerEFCoreProvider : ICustomerProvider
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerEFCoreProvider(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerModel> GetCustomer(string organizationNo)
        {
            if (string.IsNullOrWhiteSpace(organizationNo))
                throw new ArgumentException($"Argument '{organizationNo}' is null or empty.");

            var customer = await _dbContext.CustomerInfos
                .FirstOrDefaultAsync(c => c.OrganizationNo == organizationNo);

            return customer?.ToDomainModel();
        }

        public async Task MergeCustomer(CustomerModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var existingCustomer = await _dbContext.CustomerInfos.FirstOrDefaultAsync(c => c.OrganizationNo == model.OrganizationNo);
            if (existingCustomer == null)
                _dbContext.Add(new CustomerInfo(model));
            else
                existingCustomer.FromDomainModel(model);

            await _dbContext.SaveChangesAsync();
        }
    }
}
