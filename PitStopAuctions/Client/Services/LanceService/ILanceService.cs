using PitStopAuctions.Shared;

namespace PitStopAuctions.Client.Services.LanceService
{
    public interface ILanceService
    {
        List<Lance> Lances { get; set; }
        Task GetLances();
        Task<Lance> GetLance(int id);
        Task<Lance> CriarLance(Lance lance);
        Task UpdateLance(Lance lance);
    }
}

