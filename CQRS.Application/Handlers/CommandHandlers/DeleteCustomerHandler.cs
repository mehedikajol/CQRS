using CQRS.Application.Commands;
using CQRS.Core.Repositories.Command;
using CQRS.Core.Repositories.Query;
using MediatR;

namespace CQRS.Application.Handlers.CommandHandlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, string>
    {
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly ICustomerQueryRepository _queryRepository;

        public DeleteCustomerHandler(
            ICustomerCommandRepository commandRepository,
            ICustomerQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }


        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customerEntity = await _queryRepository.GetCustomerByIdAsync(request.Id);
                await _commandRepository.DeleteAsync(customerEntity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return "Customer has been deleted successfully.";
        }
    }
}
