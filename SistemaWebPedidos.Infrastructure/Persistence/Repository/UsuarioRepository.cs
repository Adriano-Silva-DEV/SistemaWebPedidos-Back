﻿using Microsoft.EntityFrameworkCore;
using SistemaWebPedidos.Core.Entities;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Infrastructure.Persistence.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
         public UsuarioRepository(ApiDbContext apiDbContext) : base(apiDbContext)
        {

        }

        public async Task<Usuario> ObterPorIdIdentity(Guid id)
        {
            return await _apiDbContext.Sobres.AsNoTracking().FirstOrDefaultAsync(p => p.IdIdentity == id);

        }
    }
}
