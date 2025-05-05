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
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<Pegawai>> GetAllPegawaiAsync()
    {
        try
        {
            var response = await _client.GetAsync("pegawai");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<Pegawai>>(json, _jsonOptions);
            return data ?? new List<Pegawai>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal mengambil data pegawai: {ex.Message}");
            return new List<Pegawai>();
        }
    }

    public async Task<Pegawai?> GetPegawaiByIdAsync(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID tidak boleh kosong");

            var response = await _client.GetAsync($"pegawai/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[WARNING] Pegawai dengan ID {id} tidak ditemukan");
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pegawai>(json, _jsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal mengambil data pegawai: {ex.Message}");
            return null;
        }
    }

    public async Task CreatePegawaiAsync(Pegawai pegawai)
    {
        try
        {
            if (pegawai == null)
                throw new ArgumentNullException(nameof(pegawai), "Data pegawai tidak boleh null");

            var jsonContent = new StringContent(JsonSerializer.Serialize(pegawai), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("pegawai", jsonContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal membuat data pegawai: {ex.Message}");
        }
    }

    public async Task UpdatePegawaiAsync(Pegawai pegawai)
    {
        try
        {
            if (pegawai == null || string.IsNullOrWhiteSpace(pegawai.id))
                throw new ArgumentException("Data pegawai atau ID tidak valid");

            var jsonContent = new StringContent(JsonSerializer.Serialize(pegawai), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"pegawai/{pegawai.id}", jsonContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal memperbarui data pegawai: {ex.Message}");
        }
    }

    public async Task<bool> DeletePegawaiAsync(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID pegawai tidak boleh kosong");

            var response = await _client.DeleteAsync($"pegawai/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal menghapus pegawai: {ex.Message}");
            return false;
        }
    }
}
