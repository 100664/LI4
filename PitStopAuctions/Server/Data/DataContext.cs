namespace PitStopAuctions.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Id = 1,
                    Origem = "Português",
                    Registo = "MockRegisto",
                    GarantiaStand = "2 anos",
                    EmissaoCO2 = 7128,
                    Tracao = "traseiraTT2odlas",
                    Classe = "classe fixe",
                    Lotacao = 4,
                    NumeroPortas = 3,
                    NumeroMudancas = 6,
                    TipoCaixa = "manual",
                    Cor = "cinza",
                    Potencia= 5,
                    Cilindrada =1,
                    Ano= 1999,
                    Combustivel = "gasolina",
                    Versao = " a versão fixe",
                    Modelo = " modelo 01239192jasdh-LASD- PRO",
                },

                new Produto
                {
                    Id = 2,
                    Origem = "aaasd",
                    Registo = "MockRegsdsisto",
                    GarantiaStand = "2 aasdnos",
                    EmissaoCO2 = 71212318,
                    Tracao = "traseiraTadasdadaT2odlas",
                    Classe = "classe asdadadfixe",
                    Lotacao = 42,
                    NumeroPortas = 31,
                    NumeroMudancas = 16,
                    TipoCaixa = "manaaaual",
                    Cor = "cinzsddda",
                    Potencia = 15,
                    Cilindrada = 16,
                    Ano = 19919,
                    Combustivel = "sd",
                    Versao = " a veasrsão fixe",
                    Modelo = " modelo asdadsa01239192jasdh-LASD- PRO",
                }
            );

            modelBuilder.Entity<Utilizador>().HasData(
                new Utilizador
                {
                    Id = 1,
                    IsAdmin = false,
                    Nome = "Rodrigo Castro",
                    Nif = "1128",
                    Morada = "Rua da igreja",
                    Cidade = "Viana do Castelo",
                    CodPostal = "4904-031",
                    Username = "rodrigo12",
                    Email = "rodrigo@gmail.com",
                    Password = "rodrigo123",
                    CC = "987654321",

                },

                new Utilizador
                {
                    Id = 2,
                    IsAdmin = false,
                    Nome = "Leonardo Lopes",
                    Nif = "987654321",
                    Morada = "Lopes rua",
                    Cidade = "Grimancelos",
                    CodPostal = "4904-018",
                    Username = "leonardo",
                    Email = "leonardo@gmail.com",
                    Password = "leo123",
                    CC = "123456789",
                },

                new Utilizador
                {
                    Id = 3,
                    IsAdmin = true,
                    Nome = "Pedro Fernandes",
                    Nif = "000000000",
                    Morada = "Rua dos Reis",
                    Cidade = "Barcelos",
                    CodPostal = "4904-012",
                    Username = "admin1",
                    Email = "pfernandes@gmail.com",
                    Password = "pass123",
                    CC = "00000000",
                }
            );

            modelBuilder.Entity<Lance>().HasData(
               new Lance
               {
                   Id = 1,
                   Hora = new DateTime(2024, 01, 16, 13,12,16),
                   Montante = 7000,
                   UtilizadorID = 1,
                   LeilaoId=1,
               },

               new Lance
               {
                   Id = 2,
                   Hora = new DateTime(2024, 01, 20, 19, 7, 55),
                   Montante = 6000,
                   UtilizadorID = 2,
                   LeilaoId=2,
               }
           );

            modelBuilder.Entity<Marca>().HasData(
                new Marca
                {
                    Approved = true,
                    Id = 1,
                    Nome = "Mercedes Viana do Castelo",
                    Nif = "123456788",
                    Morada = "Viana retail center",
                    Cidade = "Viana do Castelo",
                    CodPostal = "4904-012",
                    Username = "mercedesVC",
                    Email = "mercedes-vc@gmail.com",
                    Password = "123passe",
                    Image = "https://logosmarcas.net/wp-content/uploads/2020/05/Mercedes-Benz-Logo-1989-2009.jpg",
                },

                new Marca
                {
                    Approved = true,
                    Id = 2,
                    Nome = "BMW Viana do Castelo",
                    Nif = "123456788",
                    Morada = "Viana retail center",
                    Cidade = "Viana do Castelo",
                    CodPostal = "4904-012",
                    Username = "BMW-VC",
                    Email = "bmw-vc@gmail.com",
                    Password = "123passe123",
                    Image = "https://tonimarino.co.uk/wp-content/uploads/2019/10/bmw-Logo-800x533.png",
                }
            );

            modelBuilder.Entity<Leilao>().HasData(
                new Leilao
                {
                    Id = 1,
                    Nome = "Mercedes Benz CLK 200 Kompressor",
                    Descricao = "Mercedes descapotável, modelo de 1988, cor cinzenta, bla bla bla" +
                    " blah blah blah, mais blah blah blah, muito detalhe blah blah blah" +
                    " blah blah bleh ponto final PARAGRAFO",
                    Data_inicio = new DateTime(2024, 01, 15),
                    Data_fim = new DateTime(2024, 02, 28),
                    PrecoInicial = 5000.95f,
                    Imagem = "https://www.truck1.pt/img/Maquina_de_outro_Mercedes_Benz_CLK_Klasse_200-xxl-5154/5154_5999637647337.jpg",
                    MarcaId = 1,
                    LanceAtualId = 1,
                    ProdutoId = 1,
                },

                new Leilao
                {
                    Id = 2,
                    Nome = "BMW VROOOOOOOOOM",
                    Descricao = "BMW AZUL RAPIDO COMO O VENTO, bla bla bla" +
                    " blah blah blah, mais blah blah blah, muito detalhe blah blah blah" +
                    " blah blah bleh ponto final PARAGRAFO",
                    Data_inicio = new DateTime(2024, 01, 19),
                    Data_fim = new DateTime(2024, 03, 1),
                    PrecoInicial = 5000.95f,
                    Imagem = "https://i.pinimg.com/originals/1e/aa/1e/1eaa1e61a3831fb424076c3e4d0362a6.jpg",
                    MarcaId = 2,
                    LanceAtualId = 2,
                    ProdutoId = 1,
                }
            );
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Lance> Lances { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Leilao> Leiloes { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }
    }
}
