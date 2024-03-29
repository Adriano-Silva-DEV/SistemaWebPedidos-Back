﻿using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.Interfaces
{
    public interface IEnderecoService
    {

       Task<EnderecoViewModel> ObterPorId(Guid id);

        Task<EnderecoViewModel> Editar(EnderecoViewModel endereco, Guid id);

    }
}
