using Microsoft.AspNetCore.Components;
using PitStopAuctions.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace PitStopAuctions.Client.Services.MarcaService
{
    public class MarcaService : IMarcaService
    {
        public List<Marca> Marcas { get; set; } = new List<Marca>();
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public MarcaService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }
        public async Task CriarMarca(Marca marca)
        {
            var result = await _httpClient.PostAsJsonAsync("api/marca", marca);

            if (result.IsSuccessStatusCode)
            {
                await SetMarcas(result);
            }
            else
            {
                var errorResponse = await result.Content.ReadAsStringAsync();
                throw new Exception($"Failed to create user. Status Code: {result.StatusCode}, Response: {errorResponse}");
            }
        }

        private async Task SetMarcas(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Marca>>();
            Marcas = response;
            _navigationManager.NavigateTo("/"); // pagina de marcas todas?
        }

        public async Task GetMarcas()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Marca>>("api/marca");
            if (result != null)
            {
                Marcas = result;
            }
        }

        public async Task<Marca> GetMarcaByUsername(string username)
        {
            var result = await _httpClient.GetFromJsonAsync<Marca>($"api/marca/by-username/{username}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Marca não foi encontrado");
        }

        public async Task<Marca> GetMarca(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Marca>($"api/marca/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Marca não foi encontrado");
        }

        public async Task UpdateMarca(Marca marca)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/marca/{marca.Id}", marca);

            if (result.IsSuccessStatusCode)
            {
                await SetMarcas(result);
            }
            else
            {
                var errorResponse = await result.Content.ReadAsStringAsync();
                throw new Exception($"Failed to create user. Status Code: {result.StatusCode}, Response: {errorResponse}");
            }
        }
    }
}
