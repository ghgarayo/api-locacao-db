using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaLocacao
{
    class Imovel
    {
        public int idImovel { get; set; }
        public string? endereco { get; set; }
        public string? numero { get; set; }
        public string? complemento { get; set; }
        public string? bairro { get; set; }
        public string? cidade { get; set; }
        public string? estado { get; set; }
        public string? proprietario { get; set; }
        public string? valorAluguel { get; set; }
        public string? disponivel { get; set; }

    }

    class BaseImoveis : DbContext
    {
        public BaseImoveis(DbContextOptions<BaseImoveis> options) : base(options)
        {
        }

        public DbSet<Imovel> Imoveis { get; set; } = null!;

    }
}