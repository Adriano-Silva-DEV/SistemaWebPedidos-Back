﻿using Microsoft.EntityFrameworkCore;
using SistemaWebPedidos.Core.Entities;
using System.Linq;

namespace SistemaWebPedidos.Infrastructure.Persistence
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        { }
        
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItemPedido> ItensPedidos { get; set;}

        public DbSet<Sobre> Sobre { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Usuario> Sobres { get; set; }    

        public DbSet<Endereco> Enderecos { get; set;}

        public DbSet<MeioPagamento> MeioPagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);

        }

    }
}
