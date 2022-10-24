﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaLocacao;

#nullable disable

namespace SistemaLocacaoComDB.Migrations.BaseLocacoesMigrations
{
    [DbContext(typeof(BaseLocacoes))]
    [Migration("20220920202959_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("SistemaLocacao.Locacao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("dataLocacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("emailLocatario")
                        .HasColumnType("TEXT");

                    b.Property<int>("idImovel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("idLocatario")
                        .HasColumnType("INTEGER");

                    b.Property<string>("proprietarioImovel")
                        .HasColumnType("TEXT");

                    b.Property<string>("tempoContrato")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Locacoes");
                });
#pragma warning restore 612, 618
        }
    }
}