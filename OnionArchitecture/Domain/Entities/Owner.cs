﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;


namespace Domain.Entities
{
    public class Owner : Account
    {
        public String Phone { get; set; }
    }
}
