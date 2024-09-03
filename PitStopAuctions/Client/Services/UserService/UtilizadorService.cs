using Microsoft.AspNetCore.Components;
using PitStopAuctions.Shared;
using System.Net.Http.Json;

namespace PitStopAuctions.Client.Services.UserService
{
    public class UtilizadorService : IUtilizadorService
    {
        public List<Utilizador> Users { get; set; } = new List<Utilizador>();
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public UtilizadorService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }
        public async Task CriarUser(Utilizador user)
        {
            var result = await _httpClient.PostAsJsonAsync("api/utilizador", user);

            if (result.IsSuccessStatusCode)
            {
                await SetUsers(result);
            }
            else
            {
                var errorResponse = await result.Content.ReadAsStringAsync();
                throw new Exception($"Failed to create user. Status Code: {result.StatusCode}, Response: {errorResponse}");
            }
        }


        private async Task SetUsers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Utilizador>>();
            Users = response;
            _navigationManager.NavigateTo("/"); // pagina de login dps?
        }

        public async Task<Utilizador> GetUser(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Utilizador>($"api/utilizador/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Utilizador não foi encontrado");
        }

        public async Task<Utilizador> GetUserByUsername(string username)
        {
            var result = await _httpClient.GetFromJsonAsync<Utilizador>($"api/utilizador/by-username/{username}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Utilizador não foi encontrado");
        }

        public async Task GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Utilizador>>("api/utilizador");
            if (result != null)
            {
                Users = result;
            }
        }
    }
}
