﻿using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Interfaces.Repositories
{
    public  interface ISobreRepository : IRepository<Sobre>
    {
        public Task<Sobre> Obter();
    }
}
