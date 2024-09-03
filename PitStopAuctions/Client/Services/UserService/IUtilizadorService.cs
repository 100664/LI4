using PitStopAuctions.Shared;

namespace PitStopAuctions.Client.Services.UserService
{
    public interface IUtilizadorService
    {
        List<Utilizador> Users { get; set; }
        Task GetUsers();
        Task<Utilizador> GetUser (int id);
        Task<Utilizador> GetUserByUsername(string username);
        Task CriarUser(Utilizador user);
    }
}
