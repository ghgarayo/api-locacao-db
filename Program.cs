using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemaLocacao
{

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionStringLocatario = builder.Configuration.GetConnectionString("Locatarios") ?? "Data Source=Locatarios.db";
            builder.Services.AddSqlite<BaseLocatarios>(connectionStringLocatario);
            var connectionStringImovel = builder.Configuration.GetConnectionString("Imoveis") ?? "Data Source=Imoveis.db";
            builder.Services.AddSqlite<BaseImoveis>(connectionStringImovel);
            var connectionStringLocacao = builder.Configuration.GetConnectionString("Locacoes") ?? "Data Source=Locacoes.db";
            builder.Services.AddSqlite<BaseLocacoes>(connectionStringLocacao);


            var app = builder.Build();

            // =============== CREATE =============== 

            // Locatario - ok 
            app.MapPost("/locatario/cadastrar", (BaseLocatarios baseLocatarios, Locatario locatario) =>
            {
                baseLocatarios.Locatarios.Add(locatario);
                baseLocatarios.SaveChanges();
                return $"Locatario {locatario.nome} cadastrado!";
            });

            // Imovel - ok 
            app.MapPost("/imovel/cadastrar", (BaseImoveis baseImoveis, Imovel imovel) =>
            {
                baseImoveis.Imoveis.Add(imovel);
                baseImoveis.SaveChanges();
                return $"Imóvel de {imovel.proprietario} cadastrado!";
            });

            // Locacao - ok
            app.MapPost("/locacao/cadastrar", (BaseLocacoes baseLocacoes, Locacao locacao, BaseLocatarios baseLocatarios, BaseImoveis baseImoveis) =>
            {
                Imovel? buscaImovel = baseImoveis.Imoveis.FirstOrDefault(imovel => imovel.proprietario.Equals(locacao.proprietarioImovel));
                locacao.idImovel = buscaImovel.idImovel;

                if (buscaImovel.disponivel.Equals("não"))
                {
                    return $"Imóvel {buscaImovel.idImovel} indisponível.";
                }

                Locatario? buscaLocatario = baseLocatarios.Locatarios.FirstOrDefault(locatario => locatario.email.Equals(locacao.emailLocatario));
                locacao.idLocatario = buscaLocatario.idLocatario;
                buscaImovel.disponivel = "não";
                baseLocacoes.Locacoes.Add(locacao);
                baseImoveis.SaveChanges();
                baseLocacoes.SaveChanges();

                return $"Contrato de locação nº {locacao.idLocacao} gerado!";
            });

            // =============== READ =============== 

            // Locatario por email - ok
            app.MapGet("/locatario/{email}", (BaseLocatarios baseLocatarios, string email) =>
            {
                return baseLocatarios.Locatarios.FirstOrDefault(locatario => locatario.email.Equals(email));
            });

            // Lista completa locatarios - ok
            app.MapGet("/locatario/lista", (BaseLocatarios baseLocatarios) =>
            {
                return baseLocatarios.Locatarios.ToList();
            });

            // Imovel por proprietario - ok
            app.MapGet("/imovel/{nomeProprietario}", (BaseImoveis baseImoveis, string nomeProprietario) =>
            {
                return baseImoveis.Imoveis.Where(imovel => imovel.proprietario.Equals(nomeProprietario)).ToList();
            });

            // Lista completa de imoveis - ok
            app.MapGet("/imovel/lista", (BaseImoveis baseImoveis) =>
            {
                return baseImoveis.Imoveis.ToList();
            });

            // Locacao por locatário - ok 
            app.MapGet("/locacao/locatario/{emailLocatario}", (BaseLocacoes baseLocacoes, string emailLocatario) =>
            {
                return baseLocacoes.Locacoes.Where(locacao => locacao.emailLocatario.Equals(emailLocatario)).ToList();
            });

            // Locacao por proprietário - ok
            app.MapGet("/locacao/proprietario/{nomeProprietario}", (BaseLocacoes baseLocacoes, string nomeProprietario) =>
            {
                return baseLocacoes.Locacoes.Where(locacao => locacao.proprietarioImovel.Equals(nomeProprietario)).ToList();
            });

            // Lista completa de locacao - ok
            app.MapGet("/locacao/lista", (BaseLocacoes baseLocacoes) =>
            {
                return baseLocacoes.Locacoes.ToList();
            });

            // =============== UPDATE =============== 

            // UPDATE nome ou email locatário
            app.MapPut("/locatario/atualizar", (BaseLocatarios baseLocatarios, Locatario atualizacaoLocatario, int idLocatario) =>
            {
                string auxNome = "";
                string auxEmail = "";
                Locatario encontraLocatario = baseLocatarios.Locatarios.Find(idLocatario);

                if (encontraLocatario.nome != null && encontraLocatario.email != null)
                {
                    auxNome = encontraLocatario.nome;
                    encontraLocatario.nome = atualizacaoLocatario.nome;
                    auxEmail = encontraLocatario.email;
                    encontraLocatario.email = atualizacaoLocatario.email;
                    baseLocatarios.SaveChanges();
                    return $"Nome alterado de {auxNome} para {encontraLocatario.nome}.\nEmail alterado de {auxEmail} para {encontraLocatario.email}.";
                }
                else if (encontraLocatario.nome != null)
                {
                    auxNome = encontraLocatario.nome;
                    encontraLocatario.nome = atualizacaoLocatario.nome;
                    baseLocatarios.SaveChanges();
                    return $"Nome alterado de {auxNome} para {encontraLocatario.nome}.";
                }
                else if (encontraLocatario.email != null)
                {
                    auxEmail = encontraLocatario.email;
                    encontraLocatario.email = atualizacaoLocatario.email;
                    baseLocatarios.SaveChanges();
                    return $"Email alterado de {auxEmail} para {encontraLocatario.email}.";
                }
                else
                {
                    return "Nenhum locatário encontrado!";
                }
            });

            // UPDATE Imovel valor do aluguel e nome do Proprietario.
            app.MapPut("/imovel/atualizar", (BaseImoveis baseImoveis, Imovel atualizacaoImovel, int idImovel) =>
            {
                string auxAluguel = "";
                string auxProprietario = "";

                Imovel encontraImovel = baseImoveis.Imoveis.Find(idImovel);

                if (atualizacaoImovel.valorAluguel != null)
                {
                    auxAluguel = encontraImovel.valorAluguel;
                    encontraImovel.valorAluguel = atualizacaoImovel.valorAluguel;
                    baseImoveis.SaveChanges();
                    return $"Valor do aluguel alterado de R${auxAluguel} para R${encontraImovel.valorAluguel}.";

                }
                else if (atualizacaoImovel.proprietario != null)
                {
                    auxProprietario = encontraImovel.proprietario;
                    encontraImovel.proprietario = atualizacaoImovel.proprietario;
                    baseImoveis.SaveChanges();
                    return $"Proprietário do imóvel alterado de {auxProprietario} para {encontraImovel.proprietario}.";
                }
                else
                {
                    return "Nenhum imóvel encontrado!";
                }
            });

            // UPDATE locacao, tempo de contrato
            app.MapPut("/locacao/atualizar", (BaseLocacoes baseLocacoes, Locacao atualizaLocacao, int idLocacao) => 
            {
                Locacao encontraLocacao = baseLocacoes.Locacoes.Find(idLocacao);
                encontraLocacao.tempoContrato = atualizaLocacao.tempoContrato;
                encontraLocacao.dataLocacao = atualizaLocacao.dataLocacao;
                baseLocacoes.SaveChanges();
                return $"Contrato de locação {encontraLocacao.idLocacao} extendido por {encontraLocacao.tempoContrato} à partir de {encontraLocacao.dataLocacao}.";
            });



            // =============== DELETE =============== 

            // 

            app.Run();
        }
    }

}