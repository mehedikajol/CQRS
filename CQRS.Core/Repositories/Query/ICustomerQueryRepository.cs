using CQRS.Core.Entities;
using CQRS.Core.Repositories.Query.Base;

namespace CQRS.Core.Repositories.Query
{
    public interface ICustomerQueryRepository : IQueryRepository<Customer>
    {
        Task<IReadOnlyList<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<Customer> GetCustomerByEmailAsync(string email);
    }
}
