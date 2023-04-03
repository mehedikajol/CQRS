using CQRS.Core.Entities;
using CQRS.Core.Repositories.Command.Base;

namespace CQRS.Core.Repositories.Command
{
    public interface ICustomerCommandRepository : ICommandRepository<Customer>
    {
    }
}
