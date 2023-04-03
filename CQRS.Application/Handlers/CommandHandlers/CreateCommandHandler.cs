using CQRS.Application.Commands;
using CQRS.Application.Mapper;
using CQRS.Application.Responses;
using CQRS.Core.Entities;
using CQRS.Core.Repositories.Command;
using MediatR;

namespace CQRS.Application.Handlers.CommandHandlers
{
    public class CreateCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerCommandRepository _commandRepository;
        public CreateCommandHandler(ICustomerCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = CustomerMapper.Mapper.Map<Customer>(request);
            if (customerEntity == null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newCustomer = await _commandRepository.AddAsync(customerEntity);
            var customerResponse = CustomerMapper.Mapper.Map<CustomerResponse>(newCustomer);
            return customerResponse;
        }
    }
}
