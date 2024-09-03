using PitStopAuctions.Shared;

namespace PitStopAuctions.Client.Services.LeilaoService
{
    public interface ILeilaoService
    {
        List<Leilao> Leiloes { get; set; }
        Task GetLeiloes();
        Task<Leilao> GetLeilao(int id);
        Task CriarLeilao(Leilao leilao);
        Task UpdateLeilao(Leilao lei);
    }
}
