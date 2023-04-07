using CQRS.Core.Entities;
using MediatR;

namespace CQRS.Application.Queries
{
    public class GetCustomerByEmailQuery : IRequest<Customer>
    {
        public string Email { get; set; }

        public GetCustomerByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
