using CQRS.Core.Repositories.Query.Base;
using CQRS.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace CQRS.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {
        protected QueryRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
