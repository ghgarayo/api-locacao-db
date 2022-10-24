﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaLocacao;

#nullable disable

namespace SistemaLocacaoComDB.Migrations.BaseImoveisMigrations
{
    [DbContext(typeof(BaseImoveis))]
    partial class BaseImoveisModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("SistemaLocacao.Imovel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("bairro")
                        .HasColumnType("TEXT");

                    b.Property<string>("cidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("complemento")
                        .HasColumnType("TEXT");

                    b.Property<string>("disponivel")
                        .HasColumnType("TEXT");

                    b.Property<string>("endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("estado")
                        .HasColumnType("TEXT");

                    b.Property<string>("numero")
                        .HasColumnType("TEXT");

                    b.Property<string>("proprietario")
                        .HasColumnType("TEXT");

                    b.Property<string>("valorAluguel")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Imoveis");
                });
#pragma warning restore 612, 618
        }
    }
}
