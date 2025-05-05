using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Apotekku_API.Models;

public class PembelianObat
{
    private readonly List<Obat> daftarObatConfig;
    private readonly List<Obat> pembelianUser;

    public PembelianObat()
    {
        try
        {
            daftarObatConfig = FetchMedicinesFromConfig() ?? new List<Obat>();
            pembelianUser = new List<Obat>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error inisialisasi PembelianObat: {ex.Message}");
            daftarObatConfig = new List<Obat>();
            pembelianUser = new List<Obat>();
        }
    }

    private List<Obat> FetchMedicinesFromConfig()
    {
        try
        {
            string path = "Data\\Obat.json";

            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path), "Path file tidak boleh kosong");

            if (!File.Exists(path))
                throw new FileNotFoundException($"File konfigurasi obat tidak ditemukan di: {path}");

            var json = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(json))
                throw new InvalidDataException("File konfigurasi obat kosong");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
                ReadCommentHandling = JsonCommentHandling.Skip
            };

            var medicines = JsonSerializer.Deserialize<List<Obat>>(json, options);
            return medicines ?? new List<Obat>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error membaca konfigurasi obat: {ex.Message}");
            return new List<Obat>();
        }
    }

    public async Task<bool> IsObatValidAsync(string nama)
    {
        if (string.IsNullOrWhiteSpace(nama))
        {
            Console.WriteLine("Nama obat tidak boleh kosong");
            return await Task.FromResult(false);
        }

        if (daftarObatConfig == null || !daftarObatConfig.Any())
        {
            Console.WriteLine("Daftar obat kosong");
            return await Task.FromResult(false);
        }

        return await Task.FromResult(
            daftarObatConfig.Exists(o =>
                !string.IsNullOrWhiteSpace(o.nama) &&
                o.nama.Equals(nama, StringComparison.OrdinalIgnoreCase))
        );
    }

    public void TambahObat(string nama, int jumlah, int harga, DateTime tanggal)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(nama))
                throw new ArgumentException("Nama obat tidak boleh kosong.");

            if (jumlah <= 0)
                throw new ArgumentOutOfRangeException(nameof(jumlah), "Jumlah harus lebih dari 0.");

            if (harga <= 0)
                throw new ArgumentOutOfRangeException(nameof(harga), "Harga harus lebih dari 0.");

            var obat = new Obat
            {
                nama = nama?.Trim(),
                stok = jumlah,
                harga = harga
            };

            // Validasi duplikat obat
            if (pembelianUser.Any(o =>
                o.nama.Equals(nama, StringComparison.OrdinalIgnoreCase) &&
                o.harga == harga))
            {
                throw new InvalidOperationException($"Obat {nama} sudah ada dalam daftar pembelian");
            }

            pembelianUser.Add(obat);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Gagal menambah obat: {ex.Message}");
            throw; // Re-throw untuk penanganan di level yang lebih tinggi
        }
    }

    public int GetHargaObat(string namaObat)
    {
        if (string.IsNullOrWhiteSpace(namaObat))
        {
            Console.WriteLine("Nama obat tidak valid");
            return 0;
        }

        if (daftarObatConfig == null || !daftarObatConfig.Any())
        {
            Console.WriteLine("Daftar obat kosong");
            return 0;
        }

        var obat = daftarObatConfig.FirstOrDefault(o =>
            !string.IsNullOrWhiteSpace(o.nama) &&
            o.nama.Equals(namaObat, StringComparison.OrdinalIgnoreCase));

        return obat?.harga ?? 0;
    }

    public IEnumerable<Obat> GetObats()
    {
        // Return copy untuk mencegah modifikasi langsung
        return new List<Obat>(pembelianUser);
    }

    public void TampilkanDaftarObat()
    {
        try
        {
            Console.WriteLine("=== Daftar Obat yang Dibeli ===");

            if (pembelianUser == null || !pembelianUser.Any())
            {
                Console.WriteLine("Belum ada obat yang dibeli.");
                return;
            }

            foreach (var obat in pembelianUser)
            {
                Console.WriteLine($"Nama: {obat.nama ?? "Tidak diketahui"}, " +
                                  $"Harga: {obat.harga}, " +
                                  $"Jumlah: {obat.stok}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error menampilkan daftar obat: {ex.Message}");
        }
    }

    public void TampilkanRiwayatPembelian()
    {
        try
        {
            Console.WriteLine("=== Riwayat Pembelian ===");

            if (pembelianUser == null || !pembelianUser.Any())
            {
                Console.WriteLine("Belum ada obat yang dibeli.");
                return;
            }

            foreach (var obat in pembelianUser)
            {
                if (obat == null) continue;

                int total = obat.harga * obat.stok;
                Console.WriteLine($"- {obat.nama ?? "Obat tidak diketahui"} " +
                                  $"x {obat.stok} = Rp{total}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error menampilkan riwayat: {ex.Message}");
        }
    }

    public IEnumerable<Obat> GetObatsFromAPI()
    {
        // Return copy untuk mencegah modifikasi langsung
        return new List<Obat>(daftarObatConfig);
    }

    public async Task BeliObatAsync()
    {
        try
        {
            Console.Write("Nama obat: ");
            string nama = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nama))
            {
                Console.WriteLine("Nama obat tidak boleh kosong");
                return;
            }

            if (!await IsObatValidAsync(nama))
            {
                Console.WriteLine("Obat tidak ditemukan di daftar.");
                return;
            }

            Console.Write("Jumlah: ");
            string inputJumlah = Console.ReadLine();

            if (!int.TryParse(inputJumlah, out int jumlah) || jumlah <= 0)
            {
                Console.WriteLine("Jumlah harus angka positif");
                return;
            }

            int harga = GetHargaObat(nama);
            if (harga <= 0)
            {
                Console.WriteLine("Harga obat tidak valid");
                return;
            }

            int totalHarga = harga * jumlah;
            Console.WriteLine($"Total harga: Rp{totalHarga}");

            TambahObat(nama, jumlah, harga, DateTime.Now);
            Console.WriteLine("Obat berhasil ditambahkan ke riwayat pembelian.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error dalam proses pembelian: {ex.Message}");
        }
    }
}