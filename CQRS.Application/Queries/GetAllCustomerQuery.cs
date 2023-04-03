using CQRS.Core.Entities;
using MediatR;

namespace CQRS.Application.Queries
{
    public class GetAllCustomerQuery : IRequest<List<Customer>>
    {
    }
}
