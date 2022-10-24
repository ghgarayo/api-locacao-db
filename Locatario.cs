using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace SistemaLocacao
{
    class Locatario
    {
        public int idLocatario { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }

    }

    class BaseLocatarios : DbContext
    {
        public BaseLocatarios(DbContextOptions<BaseLocatarios> options) : base(options)
        {

        }
        public DbSet<Locatario> Locatarios { get; set; } = null!;

    }


}
