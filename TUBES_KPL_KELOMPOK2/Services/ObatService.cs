using Apotekku_API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class ObatService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public ObatService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5193/api/");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                // Converters = { new ObatStatusConverter() } 
            };
        }

        public async Task<List<Obat>> DapatkanSemuaObatAsync()
        {
            try
            {
                var response = await _client.GetAsync("obat");

                if (!response.IsSuccessStatusCode)
                {

                    return new List<Obat>();
                }

                var json = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<List<Obat>>(json, _jsonOptions);
                return result ?? new List<Obat>();
            }
            catch (HttpRequestException)
            {

                return new List<Obat>();
            }
            catch (JsonException)
            {

                return new List<Obat>();
            }
        }

        public async Task<Obat> DapatkanObatByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            try
            {
                var response = await _client.GetAsync($"obat/{id}");

                if (!response.IsSuccessStatusCode)
                {

                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<Obat>(json, _jsonOptions);
                return result;
            }
            catch (HttpRequestException)
            {
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
