using Apotekku_API.Models;
using System.Text.Json;
using System.Text;

public class MemberService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly string _jsonFile = "member_data.json";

    public MemberService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5193/api/");
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
    }

    public async Task<List<Member>> GetAllMemberAsync()
    {
        try
        {
            var response = await _client.GetAsync("member");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<Member>>(json, _jsonOptions) ?? new List<Member>();

            await File.WriteAllTextAsync(_jsonFile, JsonSerializer.Serialize(data, _jsonOptions));
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal ambil data API, ambil dari file: {ex.Message}");
            if (File.Exists(_jsonFile))
            {
                var json = await File.ReadAllTextAsync(_jsonFile);
                return JsonSerializer.Deserialize<List<Member>>(json, _jsonOptions) ?? new List<Member>();
            }
            return new List<Member>();
        }
    }

    public async Task TambahMemberAsync(Member member)
    {
        try
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(member), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("member", jsonContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal tambah member: {ex.Message}");
        }
    }

    public async Task UpdateMemberAsync(Member member)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(member.Id))
                throw new Exception("ID member kosong!");

            var jsonContent = new StringContent(JsonSerializer.Serialize(member), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"member/{member.Id}", jsonContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal update member: {ex.Message}");
        }
    }

    public async Task<bool> HapusMemberAsync(string id)
    {
        try
        {
            var response = await _client.DeleteAsync($"member/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal hapus member: {ex.Message}");
            return false;
        }
    }
}
