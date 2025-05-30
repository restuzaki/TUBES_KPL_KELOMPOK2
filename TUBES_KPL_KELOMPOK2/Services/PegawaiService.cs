using Apotekku_API.Models;
using System.Text.Json;
using System.Text;

/// <summary>
/// Layanan untuk mengelola data pegawai dari API.
/// </summary>
public class PegawaiService
{
    private readonly HttpClient _klienHttp;
    private readonly JsonSerializerOptions _opsiJson;

    public PegawaiService()
    {
        _klienHttp = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5193/api/")
        };

        _opsiJson = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    /// <summary>
    /// Mengambil semua data pegawai.
    /// </summary>
    public async Task<List<Pegawai>> AmbilSemuaPegawaiAsync()
    {
        try
        {
            var respon = await _klienHttp.GetAsync("pegawai");
            respon.EnsureSuccessStatusCode();

            var json = await respon.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Pegawai>>(json, _opsiJson) ?? new List<Pegawai>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[KESALAHAN] Gagal mengambil data pegawai: {ex.Message}");
            return new List<Pegawai>();
        }
    }

    /// <summary>
    /// Mengambil data pegawai berdasarkan ID.
    /// </summary>
    public async Task<Pegawai?> AmbilPegawaiByIdAsync(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID tidak boleh kosong");

            var respon = await _klienHttp.GetAsync($"pegawai/{id}");
            if (!respon.IsSuccessStatusCode)
            {
                Console.WriteLine($"[PERINGATAN] Pegawai dengan ID {id} tidak ditemukan");
                return null;
            }

            var json = await respon.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pegawai>(json, _opsiJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[KESALAHAN] Gagal mengambil data pegawai: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Menambahkan data pegawai baru.
    /// </summary>
    public async Task TambahPegawaiAsync(Pegawai pegawai)
    {
        try
        {
            if (pegawai == null)
                throw new ArgumentNullException(nameof(pegawai), "Data pegawai tidak boleh kosong");

            var isiJson = new StringContent(JsonSerializer.Serialize(pegawai), Encoding.UTF8, "application/json");
            var respon = await _klienHttp.PostAsync("pegawai", isiJson);
            respon.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[KESALAHAN] Gagal menambahkan pegawai: {ex.Message}");
        }
    }

    /// <summary>
    /// Memperbarui data pegawai.
    /// </summary>
    public async Task PerbaruiPegawaiAsync(Pegawai pegawai)
    {
        try
        {
            if (pegawai == null || string.IsNullOrWhiteSpace(pegawai.id))
                throw new ArgumentException("Data pegawai atau ID tidak valid");

            var isiJson = new StringContent(JsonSerializer.Serialize(pegawai), Encoding.UTF8, "application/json");
            var respon = await _klienHttp.PutAsync($"pegawai/{pegawai.id}", isiJson);
            respon.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[KESALAHAN] Gagal memperbarui pegawai: {ex.Message}");
        }
    }

    /// <summary>
    /// Menghapus data pegawai berdasarkan ID.
    /// </summary>
    public async Task<bool> HapusPegawaiAsync(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID pegawai tidak boleh kosong");

            var respon = await _klienHttp.DeleteAsync($"pegawai/{id}");
            return respon.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[KESALAHAN] Gagal menghapus pegawai: {ex.Message}");
            return false;
        }
    }
}
