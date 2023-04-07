using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Commands
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public DeleteCustomerCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
