using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OwnerFeatures.Commands
{
    public class DeleteOwnerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteOwnerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteOwnerCommand command, CancellationToken cancellationToken)
            {
                var owner = await _context.Owners.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (owner == null) return default;
                _context.Owners.Remove(owner);
                await _context.SaveChanges();
                return owner.Id;
            }
        }
    }
}