using CQRS.Application.Queries;
using CQRS.Core.Entities;
using CQRS.Core.Repositories.Query;
using MediatR;

namespace CQRS.Application.Handlers.QueryHandlers
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<Customer>>
    {
        private readonly ICustomerQueryRepository _queryRepository;

        public GetAllCustomerHandler(ICustomerQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            return (List<Customer>)await _queryRepository.GetAllCustomersAsync();
        }
    }
}
