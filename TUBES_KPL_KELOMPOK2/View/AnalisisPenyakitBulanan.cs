using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Apotekku_API.Models;
public class AnalisisPenyakit
{
    private List<PenyakitAnalisis> diseaseAnalyses;
    public AnalisisPenyakit()
    {
        var configJson = File.ReadAllText("Data\\PenyakitAnalisis.Json");
        diseaseAnalyses = JsonSerializer.Deserialize<List<PenyakitAnalisis>>(configJson);
    }

    public IEnumerable<PenyakitAnalisis> GetDiseaseAnalyses()
    {
        return diseaseAnalyses; 
    }
    public async Task TampilkanAnalisisAsync()
    {
        Console.WriteLine("\n--- Analisis Penyakit Bulanan ---");

        foreach (var penyakit in diseaseAnalyses)
        {
            Console.WriteLine($"Nama: {penyakit.NamaPenyakit}, Jumlah Kasus: {penyakit.JumlahKasus}");
        }

        await Task.CompletedTask; // agar tetap async-compatible
    }

}