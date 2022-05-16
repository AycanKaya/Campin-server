using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCustomerHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = _context.Customers.Where(a => a.Id == command.Id).FirstOrDefault();

                if (customer == null)
                {
                    return default;
                }
                else
                {
                    customer.Username = command.UserName;
                    customer.Name = command.Name;
                    customer.Email = command.Email;
                    customer.Address = command.Address;
                    await _context.SaveChangesAsync();
                    return customer.Id;
                }
            }
        }
    }
}