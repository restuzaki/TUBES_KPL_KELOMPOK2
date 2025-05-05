using Apotekku_API.Models;
using System.Text.Json;
using System.Text;

public class StokObatService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly string jsonFilePath = "stok_obat.json";

    public StokObatService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5193/api/");
        _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<Obat>> GetAllObatAsync()
    {
        try
        {
            var response = await _client.GetAsync("obat");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<Obat>>(json, _jsonOptions);

            if (data != null)
                await File.WriteAllTextAsync(jsonFilePath, JsonSerializer.Serialize(data));

            return data ?? new List<Obat>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal mengambil data obat dari API: {ex.Message}");

            if (File.Exists(jsonFilePath))
            {
                var localJson = await File.ReadAllTextAsync(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<Obat>>(localJson, _jsonOptions);
                return data ?? new List<Obat>();
            }

            return new List<Obat>();
        }
    }

    public async Task TambahObatAsync(Obat obat)
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(obat), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("obat", content);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal menambahkan obat: {ex.Message}");
        }
    }

    public async Task<bool> HapusObatAsync(string id)
    {
        try
        {
            var response = await _client.DeleteAsync($"obat/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal menghapus obat: {ex.Message}");
            return false;
        }
    }

    public async Task UpdateStokAsync(string id, int stokBaru)
    {
        try
        {
            var obat = await GetObatByIdAsync(id);
            if (obat == null) return;

            obat.stok = stokBaru;
            var content = new StringContent(JsonSerializer.Serialize(obat), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"obat/{id}", content);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal mengupdate stok obat: {ex.Message}");
        }
    }

    public async Task<Obat?> GetObatByIdAsync(string id)
    {
        try
        {
            var response = await _client.GetAsync($"obat/{id}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Obat>(json, _jsonOptions);
        }
        catch
        {
            return null;
        }
    }
}
