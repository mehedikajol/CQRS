using CQRS.Application.Responses;
using MediatR;

namespace CQRS.Application.Commands
{
    public class EditCustomerCommand : IRequest<CustomerResponse>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
