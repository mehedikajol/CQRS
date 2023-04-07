using CQRS.Core.Entities;
using CQRS.Core.Repositories.Command;
using CQRS.Infrastructure.Data;
using CQRS.Infrastructure.Repositories.Command.Base;

namespace CQRS.Infrastructure.Repositories.Command
{
    public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
