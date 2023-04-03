using CQRS.Application.Queries;
using CQRS.Core.Entities;
using MediatR;

namespace CQRS.Application.Handlers.QueryHandlers
{
    internal class GetCustomerByEmailHandler : IRequestHandler<GetCustomerByEmailQuery, Customer>
    {
        private readonly IMediator _mediator;

        public GetCustomerByEmailHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Customer> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new GetAllCustomerQuery());
            var selectedCustomer = customers.FirstOrDefault(x => x.Email.ToLower() == request.Email.ToLower());
            return selectedCustomer;
        }
    }
}
