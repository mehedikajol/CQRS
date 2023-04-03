using CQRS.Application.Commands;
using CQRS.Application.Mapper;
using CQRS.Application.Responses;
using CQRS.Core.Entities;
using CQRS.Core.Repositories.Command;
using CQRS.Core.Repositories.Query;
using MediatR;

namespace CQRS.Application.Handlers.CommandHandlers
{
    public class EditCustomerHandler : IRequestHandler<EditCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly ICustomerQueryRepository _queryRepository;

        public EditCustomerHandler(
            ICustomerCommandRepository commandRepository,
            ICustomerQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<CustomerResponse> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = CustomerMapper.Mapper.Map<Customer>(request);
            if (customerEntity == null)
            {
                throw new ApplicationException("There is a problem in mapper.");
            }

            try
            {
                await _commandRepository.UpdateAsync(customerEntity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            var modifiedCustomer = await _queryRepository.GetCustomerByIdAsync(request.Id);
            var customerResponse = CustomerMapper.Mapper.Map<CustomerResponse>(modifiedCustomer);

            return customerResponse;
        }
    }
}
