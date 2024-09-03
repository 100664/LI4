using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PitStopAuctions.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Versao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Combustivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Cilindrada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Potencia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCaixa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroMudancas = table.Column<int>(type: "int", nullable: false),
                    NumeroPortas = table.Column<int>(type: "int", nullable: false),
                    Lotacao = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmissaoCO2 = table.Column<int>(type: "int", nullable: false),
                    GarantiaStand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montante = table.Column<int>(type: "int", nullable: false),
                    UtilizadorID = table.Column<int>(type: "int", nullable: false),
                    LeilaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lances_Utilizadores_UtilizadorID",
                        column: x => x.UtilizadorID,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leiloes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecoInicial = table.Column<float>(type: "real", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanceAtualId1 = table.Column<int>(type: "int", nullable: true),
                    LanceAtualId = table.Column<int>(type: "int", nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiloes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leiloes_Lances_LanceAtualId1",
                        column: x => x.LanceAtualId1,
                        principalTable: "Lances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leiloes_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leiloes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Approved", "Cidade", "CodPostal", "Email", "Image", "Morada", "Nif", "Nome", "Password", "Username" },
                values: new object[,]
                {
                    { 1, true, "Viana do Castelo", "4904-012", "mercedes-vc@gmail.com", "https://logosmarcas.net/wp-content/uploads/2020/05/Mercedes-Benz-Logo-1989-2009.jpg", "Viana retail center", "123456788", "Mercedes Viana do Castelo", "123passe", "mercedesVC" },
                    { 2, true, "Viana do Castelo", "4904-012", "bmw-vc@gmail.com", "https://tonimarino.co.uk/wp-content/uploads/2019/10/bmw-Logo-800x533.png", "Viana retail center", "123456788", "BMW Viana do Castelo", "123passe123", "BMW-VC" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ano", "Cilindrada", "Classe", "Combustivel", "Cor", "EmissaoCO2", "GarantiaStand", "Lotacao", "Modelo", "NumeroMudancas", "NumeroPortas", "Origem", "Potencia", "Registo", "TipoCaixa", "Tracao", "Versao" },
                values: new object[,]
                {
                    { 1, 1999, 1m, "classe fixe", "gasolina", "cinza", 7128, "2 anos", 4, " modelo 01239192jasdh-LASD- PRO", 6, 3, "Português", 5m, "MockRegisto", "manual", "traseiraTT2odlas", " a versão fixe" },
                    { 2, 19919, 16m, "classe asdadadfixe", "sd", "cinzsddda", 71212318, "2 aasdnos", 42, " modelo asdadsa01239192jasdh-LASD- PRO", 16, 31, "aaasd", 15m, "MockRegsdsisto", "manaaaual", "traseiraTadasdadaT2odlas", " a veasrsão fixe" }
                });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "CC", "Cidade", "CodPostal", "Email", "IsAdmin", "Morada", "Nif", "Nome", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "987654321", "Viana do Castelo", "4904-031", "rodrigo@gmail.com", false, "Rua da igreja", "1128", "Rodrigo Castro", "rodrigo123", "rodrigo12" },
                    { 2, "123456789", "Grimancelos", "4904-018", "leonardo@gmail.com", false, "Lopes rua", "987654321", "Leonardo Lopes", "leo123", "leonardo" },
                    { 3, "00000000", "Barcelos", "4904-012", "pfernandes@gmail.com", true, "Rua dos Reis", "000000000", "Pedro Fernandes", "pass123", "admin1" }
                });

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new[] { "Id", "Data_fim", "Data_inicio", "Descricao", "Imagem", "LanceAtualId", "LanceAtualId1", "MarcaId", "Nome", "PrecoInicial", "ProdutoId" },
                values: new object[] { 1, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes descapotável, modelo de 1988, cor cinzenta, bla bla bla blah blah blah, mais blah blah blah, muito detalhe blah blah blah blah blah bleh ponto final PARAGRAFO", "https://www.truck1.pt/img/Maquina_de_outro_Mercedes_Benz_CLK_Klasse_200-xxl-5154/5154_5999637647337.jpg", 1, null, 1, "Mercedes Benz CLK 200 Kompressor", 5000.95f, 1 });

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new[] { "Id", "Data_fim", "Data_inicio", "Descricao", "Imagem", "LanceAtualId", "LanceAtualId1", "MarcaId", "Nome", "PrecoInicial", "ProdutoId" },
                values: new object[] { 2, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMW AZUL RAPIDO COMO O VENTO, bla bla bla blah blah blah, mais blah blah blah, muito detalhe blah blah blah blah blah bleh ponto final PARAGRAFO", "https://i.pinimg.com/originals/1e/aa/1e/1eaa1e61a3831fb424076c3e4d0362a6.jpg", 2, null, 2, "BMW VROOOOOOOOOM", 5000.95f, 1 });

            migrationBuilder.InsertData(
                table: "Lances",
                columns: new[] { "Id", "Hora", "LeilaoId", "Montante", "UtilizadorID" },
                values: new object[] { 1, new DateTime(2024, 1, 16, 13, 12, 16, 0, DateTimeKind.Unspecified), 1, 7000, 1 });

            migrationBuilder.InsertData(
                table: "Lances",
                columns: new[] { "Id", "Hora", "LeilaoId", "Montante", "UtilizadorID" },
                values: new object[] { 2, new DateTime(2024, 1, 20, 19, 7, 55, 0, DateTimeKind.Unspecified), 2, 6000, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Lances_LeilaoId",
                table: "Lances",
                column: "LeilaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lances_UtilizadorID",
                table: "Lances",
                column: "UtilizadorID");

            migrationBuilder.CreateIndex(
                name: "IX_Leiloes_LanceAtualId1",
                table: "Leiloes",
                column: "LanceAtualId1");

            migrationBuilder.CreateIndex(
                name: "IX_Leiloes_MarcaId",
                table: "Leiloes",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Leiloes_ProdutoId",
                table: "Leiloes",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lances_Leiloes_LeilaoId",
                table: "Lances",
                column: "LeilaoId",
                principalTable: "Leiloes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lances_Leiloes_LeilaoId",
                table: "Lances");

            migrationBuilder.DropTable(
                name: "Leiloes");

            migrationBuilder.DropTable(
                name: "Lances");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
