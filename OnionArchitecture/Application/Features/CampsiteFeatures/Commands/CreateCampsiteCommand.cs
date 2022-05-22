using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CampsiteFeatures.Commands
{
    public class CreateCampsiteCommand : IRequest<int>
    {

        public int OwnerID { get; set; }
        public int VacationSpotID { get; set; }
        public int AdultPrice { get; set; }
        public int ChildPrice { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonCloseDate { get; set; }


        public class CreateCampsiteHandler : IRequestHandler<CreateCampsiteCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCampsiteHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCampsiteCommand request, CancellationToken cancellationToken)
            {
                var campsite = new Campsite();
                campsite.OwnerID = request.OwnerID;
                campsite.VacationSpotID = request.VacationSpotID;
                campsite.ChildPrice = request.ChildPrice;
                campsite.AdultPrice= request.AdultPrice;
                campsite.SeasonStartDate = request.SeasonStartDate;
                campsite.SeasonCloseDate = request.SeasonCloseDate;
                _context.Campsites.Add(campsite);
                await _context.SaveChanges();
                return campsite.OwnerID;


            }
        }
    }
}
