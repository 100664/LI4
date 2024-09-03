using Microsoft.AspNetCore.Components;
using PitStopAuctions.Shared;
using System.Net.Http.Json;
using System.Numerics;
using static System.Net.WebRequestMethods;

namespace PitStopAuctions.Client.Services.LanceService
{
    public class LanceService : ILanceService
    {
        public List<Lance> Lances { get; set; } = new List<Lance>();
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public LanceService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }
        public async Task<Lance> CriarLance(Lance lance)
        {
            // Make a POST request to create the Lance
            var result = await _httpClient.PostAsJsonAsync("api/lance", lance);

            // Check if the request was successful (status code 2xx)
            result.EnsureSuccessStatusCode();

            // Deserialize the response content to get the list of Lances
            var lanceList = await result.Content.ReadFromJsonAsync<List<Lance>>();

            // Assuming you have a way to uniquely identify the newly created Lance,
            // you can find it in the list (replace the condition with your logic)
            var createdLance = lanceList.FirstOrDefault(l => l.Hora == lance.Hora);

            // Return the created Lance
            return createdLance;
        }
        private async Task SetLances(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Lance>>();
            Lances = response;
            //_navigationManager.NavigateTo("leiloes");
        }
        public async Task<Lance> GetLance(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Lance>($"api/lance/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Lance não foi encontrado");
        }

        public async Task GetLances()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Lance>>("api/lance");
            if (result != null)
            {
                Lances = result;
            }
        }

        public async Task UpdateLance(Lance lance)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/lance/{lance.Id}", lance);
            await SetLances(result);
        }
    }
}
