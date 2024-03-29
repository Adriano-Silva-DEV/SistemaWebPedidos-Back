﻿using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.Interfaces
{
    public interface IProdutoService
    {
        public  Task<ProdutoViewModel> BuscarPorId(Guid id);

        public Task<IEnumerable<ProdutoViewModel>> Buscar(string id);
        public  Task<ProdutoViewModel> Salvar(ProdutoViewModel produtoViewModel);
        public Task<ProdutoViewModel> Atualizar(ProdutoViewModel produtViewModel);
        public Task<List<ProdutoViewModel>> ListarTodos(int skip, int take);
        public Task Remover(ProdutoViewModel produtViewModel);
        public Task<ProdutoViewModel> ObterPorSku(String sku);
        public Task<List<ProdutoViewModel>> ObterPorFornecedor(Guid id);
        public Task<List<ProdutoViewModel>> ObterPorCategoria(Guid id);
        public Task<int> TotalPedidos();


    }
}
