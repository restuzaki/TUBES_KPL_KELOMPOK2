using Apotekku_API.Models;
using System.Text.Json;
using System.Text;

public class PegawaiService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;

    public PegawaiService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5193/api/");
        _jsonOptions = new JsonSerializerOptions();
    }

    public async Task<List<Pegawai>> GetAllPegawaiAsync()
    {
        var response = await _client.GetAsync("pegawai");
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Pegawai>>(json, _jsonOptions);
    }

    public async Task<Pegawai> GetPegawaiByIdAsync(string id)
    {
        var response = await _client.GetAsync($"pegawai/{id}");
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Pegawai>(json, _jsonOptions);
    }

    public async Task CreatePegawaiAsync(Pegawai pegawai)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(pegawai), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("pegawai", jsonContent);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdatePegawaiAsync(Pegawai pegawai)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(pegawai), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"pegawai/{pegawai.id}", jsonContent);
        response.EnsureSuccessStatusCode();
    }

    public async Task<bool> DeletePegawaiAsync(string id)
    {
        var response = await _client.DeleteAsync($"pegawai/{id}");
        return response.IsSuccessStatusCode;
    }
}
