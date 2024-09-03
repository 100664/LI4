using PitStopAuctions.Shared;

namespace PitStopAuctions.Client.Services.MarcaService
{
    public interface IMarcaService
    {
        List<Marca> Marcas { get; set; }
        Task GetMarcas();
        Task<Marca> GetMarca(int id);
        Task<Marca> GetMarcaByUsername(string username);
        Task UpdateMarca(Marca marca);
        Task CriarMarca(Marca marca);
    }
}
