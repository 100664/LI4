using Microsoft.AspNetCore.Components;
using PitStopAuctions.Shared;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace PitStopAuctions.Client.Services.LeilaoService
{
    public class LeilaoService : ILeilaoService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public LeilaoService(HttpClient http, NavigationManager navigationManager) { 
            _httpClient = http;
            _navigationManager = navigationManager;
        }
        public List<Leilao> Leiloes { get ; set ; } = new List<Leilao>();

        public async Task CriarLeilao(Leilao leilao)
        {
            var result = await _httpClient.PostAsJsonAsync("api/leilao", leilao);
            await SetLeiloes(result);
        }

        private async Task SetLeiloes(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Leilao>>();
            Leiloes = response;
            //_navigationManager.NavigateTo("leiloes");
        }

        public async Task<Leilao> GetLeilao(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Leilao>($"api/leilao/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Leilão não foi encontrado");
        }

        public async Task GetLeiloes()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Leilao>>("api/leilao");
            if (result != null)
            {
                Leiloes = result;
            }
        }


        public async Task UpdateLeilao(Leilao lei)
        {

            var result = await _httpClient.PutAsJsonAsync($"api/leilao/{lei.Id}", lei);

            // Check if the request was successful (status code 2xx)
            result.EnsureSuccessStatusCode();

            await SetLeiloes(result);
        }
    }
}
