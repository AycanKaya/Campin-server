using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CustomerFeatures.Commands
{
    public class CreateCustomerCommand : IRequest<int>
    {
    
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCustomerHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = new Customer();
                customer.Name = request.Name;
                customer.Username = request.UserName;
                customer.Email = request.Email;
                customer.Address = request.Address; 
                customer.Surname = request.Surname; 
                customer.Password = request.Password;
                customer.Phone = request.Phone;
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return customer.Id;


            }
        }
    }
}
