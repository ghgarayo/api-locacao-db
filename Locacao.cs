using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace SistemaLocacao
{
    class Locacao
    {
        public int idLocacao { get; set; }
        public int idImovel { get; set; }
        public int idLocatario { get; set; }
        public string? dataLocacao { get; set; }
        public string? tempoContrato { get; set; }
        public string? proprietarioImovel { get; set; }
        public string? emailLocatario { get; set; }
    }


    class BaseLocacoes : DbContext
    {
        public BaseLocacoes(DbContextOptions<BaseLocacoes> options) : base(options)
        {
        }

        public DbSet<Locacao> Locacoes { get; set; } = null!;

    }



}