using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCustomerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (customer == null) return default;
                _context.Customers.Remove(customer);
                await _context.SaveChanges();
                return customer.Id;
            }
        }
    }
}