using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OwnerFeatures.Commands
{
    public class UpdateOwnerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
       
        public string Email { get; set; }
        public string Phone { get; set; }
        public class UpdateOwnerHandler : IRequestHandler<UpdateOwnerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateOwnerHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateOwnerCommand command, CancellationToken cancellationToken)
            {
                var owner = _context.Owners.Where(a => a.Id == command.Id).FirstOrDefault();

                if (owner == null)
                {
                    return default;
                }
                else
                {
                    owner.Username = command.UserName;
                    owner.Name = command.Name;
                    owner.Surname = command.Surname;
                    owner.Email = command.Email;
                    owner.Phone=command.Phone;
                   
                    await _context.SaveChanges();
                    return owner.Id;
                }
            }
        }
    }
}