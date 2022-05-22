using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.OwnerFeatures.Commands
{
    public class CreateOwnerCommand : IRequest<int>
    {

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public class CreateOwnerHandler : IRequestHandler<CreateOwnerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateOwnerHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
            {
                var owner = new Owner();
                owner.Name = request.Name;
                owner.Username = request.UserName;
                owner.Email = request.Email;
                owner.Surname = request.Surname;
                owner.Password = request.Password;
                owner.Phone = request.Phone;
                _context.Owners.Add(owner);
                await _context.SaveChanges();
                return owner.Id;


            }
        }
    }
}
