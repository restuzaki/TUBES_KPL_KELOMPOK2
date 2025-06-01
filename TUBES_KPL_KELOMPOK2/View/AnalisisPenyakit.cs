using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Apotekku_API.Models;

public class AnalisisPenyakit
{
    private readonly List<PenyakitAnalisis> diseaseAnalyses;

    public AnalisisPenyakit()
    {
        try
        {
            // Validasi path file
            string filePath = "Data\\PenyakitAnalisis.Json";
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "Path file tidak boleh kosong");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File tidak ditemukan: {filePath}");
            }

            // Membaca file dengan penanganan error
            var configJson = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(configJson))
            {
                throw new InvalidDataException("File JSON kosong atau tidak valid");
            }

            // Deserialisasi dengan penanganan error
            diseaseAnalyses = JsonSerializer.Deserialize<List<PenyakitAnalisis>>(configJson)
                ?? throw new JsonException("Gagal melakukan deserialisasi data penyakit");
        }
        catch (Exception ex)
        {
            // Log error dan inisialisasi dengan list kosong sebagai fallback
            Console.Error.WriteLine($"Error inisialisasi AnalisisPenyakit: {ex.Message}");
            diseaseAnalyses = new List<PenyakitAnalisis>();
        }
    }

    public IEnumerable<PenyakitAnalisis> GetDiseaseAnalyses()
    {
        // Return copy untuk mencegah modifikasi langsung pada list internal
        return new List<PenyakitAnalisis>(diseaseAnalyses);
    }

    public async Task TampilkanAnalisisAsync()
    {
        try
        {
            if (diseaseAnalyses == null || diseaseAnalyses.Count == 0)
            {
                Console.WriteLine("Tidak ada data penyakit yang tersedia.");
                return;
            }

            Console.WriteLine("\n--- Analisis Penyakit Bulanan ---");

            foreach (var penyakit in diseaseAnalyses)
            {
                // Validasi null untuk properti penyakit
                string nama = penyakit.NamaPenyakit ?? "Nama tidak tersedia";
                int jumlahKasus = penyakit.JumlahKasus;

                Console.WriteLine($"Nama: {nama}, Jumlah Kasus: {jumlahKasus}");
            }

            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error menampilkan analisis: {ex.Message}");
        }
    }
    public async Task TambahPenyakitAsync(PenyakitAnalisis penyakitBaru)
    {
        if (penyakitBaru == null)
        {
            Console.Error.WriteLine("Data penyakit tidak boleh null.");
            return;
        }

        // Tambah ke list internal
        diseaseAnalyses.Add(penyakitBaru);
        await SimpanKeFileAsync();
    }

    private async Task SimpanKeFileAsync()
    {
        try
        {
            string filePath = "Data\\PenyakitAnalisis.Json";

            // Buat direktori jika belum ada
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory!);
            }

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(diseaseAnalyses, jsonOptions);
            await File.WriteAllTextAsync(filePath, jsonString);

            Console.WriteLine("Data berhasil disimpan ke file JSON.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Gagal menyimpan data ke file: {ex.Message}");
        }
    }
    public async Task<bool> HapusPenyakitAsync(string namaPenyakit)
    {
        if (string.IsNullOrWhiteSpace(namaPenyakit))
        {
            Console.Error.WriteLine("Nama penyakit tidak boleh kosong.");
            return false;
        }

        var penyakitYangDihapus = diseaseAnalyses
            .Find(p => string.Equals(p.NamaPenyakit, namaPenyakit, StringComparison.OrdinalIgnoreCase));

        if (penyakitYangDihapus == null)
        {
            Console.WriteLine($"Penyakit dengan nama '{namaPenyakit}' tidak ditemukan.");
            return false;
        }

        diseaseAnalyses.Remove(penyakitYangDihapus);
        await SimpanKeFileAsync();

        Console.WriteLine($"Penyakit '{namaPenyakit}' berhasil dihapus.");
        return true;
    }

}