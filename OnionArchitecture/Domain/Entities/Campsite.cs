using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Campsite
    {
        
        public int OwnerID { get; set; }
        public int VacationSpotID { get; set; }

        public int AdultPrice { get; set; }
        public int ChildPrice { get; set; }
        public DateTime SeasonStartDate { get; set;  }
        public DateTime SeasonCloseDate { get; set; }

    }
}
