using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OwnerFeatures.Queries
{
    public class GetOwnerQuery : IRequest<Owner>
    {
        public int Id { get; set; }
        public class GetOwnerQueryHandler : IRequestHandler<GetOwnerQuery, Owner>
        {
            private readonly IApplicationDbContext _context;
            public GetOwnerQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Owner> Handle(GetOwnerQuery query, CancellationToken cancellationToken)
            {
                var owner = _context.Owners.Where(a => a.Id == query.Id).FirstOrDefault();
                if (owner == null) return null;
                return owner;
            }
        }
    }
}