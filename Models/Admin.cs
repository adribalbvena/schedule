﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp_nt1.Models
{
    public class Admin : User
    {
        public override Role Role => Role.Administrador;
    }
}
