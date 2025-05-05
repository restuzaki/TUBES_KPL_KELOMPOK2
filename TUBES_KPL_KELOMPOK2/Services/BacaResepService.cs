using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Apotekku_API.Models;
using System;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class BacaResepService
    {
        private readonly string filePath = "Data/Obat.json";

        public List<Obat> GetObatTerdaftar()
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new InvalidOperationException("Path file JSON tidak valid.");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[WARNING] File tidak ditemukan: {filePath}");
                return new List<Obat>();
            }

            try
            {
                var jsonData = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(jsonData))
                {
                    Console.WriteLine("[WARNING] File JSON kosong.");
                    return new List<Obat>();
                }

                var obatList = JsonSerializer.Deserialize<List<Obat>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (obatList == null)
                {
                    Console.WriteLine("[WARNING] Gagal parsing JSON ke daftar obat.");
                    return new List<Obat>();
                }

                var terdaftar = obatList.Where(o => o.status == ObatStatus.Terdaftar).ToList();

                foreach (var obat in terdaftar)
                    ValidasiObat(obat);

                return terdaftar;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[ERROR] Gagal parsing JSON: {ex.Message}");
                return new List<Obat>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Kesalahan tak terduga: {ex.Message}");
                return new List<Obat>();
            }
        }

        private void ValidasiObat(Obat obat)
        {
            if (obat == null)
                throw new InvalidDataException("Data obat tidak boleh null.");

            if (string.IsNullOrWhiteSpace(obat.id))
                throw new InvalidDataException("Obat harus memiliki ID.");

            if (string.IsNullOrWhiteSpace(obat.nama))
                throw new InvalidDataException("Obat harus memiliki nama.");

            if (obat.harga < 0)
                throw new InvalidDataException("Harga obat tidak boleh negatif.");

            if (obat.stok < 0)
                throw new InvalidDataException("Stok obat tidak boleh negatif.");
        }
    }
}