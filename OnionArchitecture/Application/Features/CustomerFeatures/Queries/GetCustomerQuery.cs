using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetCustomerQuery : IRequest<Customer>
    {
        public int Id { get; set; }
        public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
        {
            private readonly IApplicationDbContext _context;
            public GetCustomerQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Customer> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
            {
                var customer = _context.Customers.Where(a => a.Id == query.Id).FirstOrDefault();
                if (customer == null) return null;
                return customer;
            }
        }
    }
}