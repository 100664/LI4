﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PitStopAuctions.Server.Data;

#nullable disable

namespace PitStopAuctions.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240123005013_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PitStopAuctions.Shared.Lance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeilaoId")
                        .HasColumnType("int");

                    b.Property<int>("Montante")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeilaoId");

                    b.HasIndex("UtilizadorID");

                    b.ToTable("Lances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hora = new DateTime(2024, 1, 16, 13, 12, 16, 0, DateTimeKind.Unspecified),
                            LeilaoId = 1,
                            Montante = 7000,
                            UtilizadorID = 1
                        },
                        new
                        {
                            Id = 2,
                            Hora = new DateTime(2024, 1, 20, 19, 7, 55, 0, DateTimeKind.Unspecified),
                            LeilaoId = 2,
                            Montante = 6000,
                            UtilizadorID = 2
                        });
                });

            modelBuilder.Entity("PitStopAuctions.Shared.Leilao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data_fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LanceAtualId")
                        .HasColumnType("int");

                    b.Property<int?>("LanceAtualId1")
                        .HasColumnType("int");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PrecoInicial")
                        .HasColumnType("real");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanceAtualId1");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Leiloes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Data_fim = new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Data_inicio = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Mercedes descapotável, modelo de 1988, cor cinzenta, bla bla bla blah blah blah, mais blah blah blah, muito detalhe blah blah blah blah blah bleh ponto final PARAGRAFO",
                            Imagem = "https://www.truck1.pt/img/Maquina_de_outro_Mercedes_Benz_CLK_Klasse_200-xxl-5154/5154_5999637647337.jpg",
                            LanceAtualId = 1,
                            MarcaId = 1,
                            Nome = "Mercedes Benz CLK 200 Kompressor",
                            PrecoInicial = 5000.95f,
                            ProdutoId = 1
                        },
                        new
                        {
                            Id = 2,
                            Data_fim = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Data_inicio = new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "BMW AZUL RAPIDO COMO O VENTO, bla bla bla blah blah blah, mais blah blah blah, muito detalhe blah blah blah blah blah bleh ponto final PARAGRAFO",
                            Imagem = "https://i.pinimg.com/originals/1e/aa/1e/1eaa1e61a3831fb424076c3e4d0362a6.jpg",
                            LanceAtualId = 2,
                            MarcaId = 2,
                            Nome = "BMW VROOOOOOOOOM",
                            PrecoInicial = 5000.95f,
                            ProdutoId = 1
                        });
                });

            modelBuilder.Entity("PitStopAuctions.Shared.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Approved = true,
                            Cidade = "Viana do Castelo",
                            CodPostal = "4904-012",
                            Email = "mercedes-vc@gmail.com",
                            Image = "https://logosmarcas.net/wp-content/uploads/2020/05/Mercedes-Benz-Logo-1989-2009.jpg",
                            Morada = "Viana retail center",
                            Nif = "123456788",
                            Nome = "Mercedes Viana do Castelo",
                            Password = "123passe",
                            Username = "mercedesVC"
                        },
                        new
                        {
                            Id = 2,
                            Approved = true,
                            Cidade = "Viana do Castelo",
                            CodPostal = "4904-012",
                            Email = "bmw-vc@gmail.com",
                            Image = "https://tonimarino.co.uk/wp-content/uploads/2019/10/bmw-Logo-800x533.png",
                            Morada = "Viana retail center",
                            Nif = "123456788",
                            Nome = "BMW Viana do Castelo",
                            Password = "123passe123",
                            Username = "BMW-VC"
                        });
                });

            modelBuilder.Entity("PitStopAuctions.Shared.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<decimal>("Cilindrada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Combustivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmissaoCO2")
                        .HasColumnType("int");

                    b.Property<string>("GarantiaStand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lotacao")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroMudancas")
                        .HasColumnType("int");

                    b.Property<int>("NumeroPortas")
                        .HasColumnType("int");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Potencia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Registo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoCaixa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tracao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Versao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 1999,
                            Cilindrada = 1m,
                            Classe = "classe fixe",
                            Combustivel = "gasolina",
                            Cor = "cinza",
                            EmissaoCO2 = 7128,
                            GarantiaStand = "2 anos",
                            Lotacao = 4,
                            Modelo = " modelo 01239192jasdh-LASD- PRO",
                            NumeroMudancas = 6,
                            NumeroPortas = 3,
                            Origem = "Português",
                            Potencia = 5m,
                            Registo = "MockRegisto",
                            TipoCaixa = "manual",
                            Tracao = "traseiraTT2odlas",
                            Versao = " a versão fixe"
                        },
                        new
                        {
                            Id = 2,
                            Ano = 19919,
                            Cilindrada = 16m,
                            Classe = "classe asdadadfixe",
                            Combustivel = "sd",
                            Cor = "cinzsddda",
                            EmissaoCO2 = 71212318,
                            GarantiaStand = "2 aasdnos",
                            Lotacao = 42,
                            Modelo = " modelo asdadsa01239192jasdh-LASD- PRO",
                            NumeroMudancas = 16,
                            NumeroPortas = 31,
                            Origem = "aaasd",
                            Potencia = 15m,
                            Registo = "MockRegsdsisto",
                            TipoCaixa = "manaaaual",
                            Tracao = "traseiraTadasdadaT2odlas",
                            Versao = " a veasrsão fixe"
                        });
                });

            modelBuilder.Entity("PitStopAuctions.Shared.Utilizador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilizadores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CC = "987654321",
                            Cidade = "Viana do Castelo",
                            CodPostal = "4904-031",
                            Email = "rodrigo@gmail.com",
                            IsAdmin = false,
                            Morada = "Rua da igreja",
                            Nif = "1128",
                            Nome = "Rodrigo Castro",
                            Password = "rodrigo123",
                            Username = "rodrigo12"
                        },
                        new
                        {
                            Id = 2,
                            CC = "123456789",
                            Cidade = "Grimancelos",
                            CodPostal = "4904-018",
                            Email = "leonardo@gmail.com",
                            IsAdmin = false,
                            Morada = "Lopes rua",
                            Nif = "987654321",
                            Nome = "Leonardo Lopes",
                            Password = "leo123",
                            Username = "leonardo"
                        },
                        new
                        {
                            Id = 3,
                            CC = "00000000",
                            Cidade = "Barcelos",
                            CodPostal = "4904-012",
                            Email = "pfernandes@gmail.com",
                            IsAdmin = true,
                            Morada = "Rua dos Reis",
                            Nif = "000000000",
                            Nome = "Pedro Fernandes",
                            Password = "pass123",
                            Username = "admin1"
                        });
                });

            modelBuilder.Entity("PitStopAuctions.Shared.Lance", b =>
                {
                    b.HasOne("PitStopAuctions.Shared.Leilao", null)
                        .WithMany("Lances")
                        .HasForeignKey("LeilaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PitStopAuctions.Shared.Utilizador", null)
                        .WithMany("Lances")
                        .HasForeignKey("UtilizadorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PitStopAuctions.Shared.Leilao", b =>
                {
                    b.HasOne("PitStopAuctions.Shared.Lance", "LanceAtual")
                        .WithMany()
                        .HasForeignKey("LanceAtualId1");

                    b.HasOne("PitStopAuctions.Shared.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PitStopAuctions.Shared.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LanceAtual");

                    b.Navigation("Marca");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("PitStopAuctions.Shared.Leilao", b =>
                {
                    b.Navigation("Lances");
                });

            modelBuilder.Entity("PitStopAuctions.Shared.Utilizador", b =>
                {
                    b.Navigation("Lances");
                });
#pragma warning restore 612, 618
        }
    }
}
