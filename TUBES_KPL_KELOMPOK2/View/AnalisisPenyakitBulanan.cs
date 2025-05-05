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
}