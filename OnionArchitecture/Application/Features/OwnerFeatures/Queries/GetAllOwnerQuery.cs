using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OwnerFeatures.Queries
{
    public class GetAllOwnerQuery : IRequest<IEnumerable<Owner>>
    {

        public class GetAllOwnerQueryHandler : IRequestHandler<GetAllOwnerQuery, IEnumerable<Owner>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllOwnerQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Owner>> Handle(GetAllOwnerQuery query, CancellationToken cancellationToken)
            {
                var ownerList = await _context.Owners.ToListAsync();
                if (ownerList == null)
                {
                    return null;
                }
                return ownerList.AsReadOnly();
            }
        }
    }
}