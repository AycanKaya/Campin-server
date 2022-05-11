using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : Account
    {
        public String Phone { get; set; }
        public String Address { get; set; }
    }
}
