using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Apotekku_API.Models;

public class PembelianObat
{
    private List<Obat> daftarObatConfig;
    private List<Obat> pembelianUser;

    public PembelianObat()
    {
        daftarObatConfig = FetchMedicinesFromConfig();
        pembelianUser = new List<Obat>();
    }

    private List<Obat> FetchMedicinesFromConfig()
    {
        string path = "Data\\Obat.json";

        if (!File.Exists(path))
        {
            Console.WriteLine("File konfigurasi obat tidak ditemukan.");
            return new List<Obat>();
        }

        var json = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var medicines = JsonSerializer.Deserialize<List<Obat>>(json, options);
        return medicines ?? new List<Obat>();
    }

    public async Task<bool> IsObatValidAsync(string nama)
    {
        return await Task.FromResult(daftarObatConfig.Any(o => o.nama.Equals(nama, StringComparison.OrdinalIgnoreCase)));
    }

    public void TambahObat(string nama, int jumlah, int harga, DateTime tanggal)
    {
        if (string.IsNullOrWhiteSpace(nama)) throw new ArgumentException("Nama obat tidak boleh kosong.");
        if (jumlah <= 0) throw new ArgumentException("Jumlah harus lebih dari 0.");
        if (harga <= 0) throw new ArgumentException("Harga harus lebih dari 0.");

        pembelianUser.Add(new Obat
        {
            nama = nama,
            stok = jumlah,
            harga = harga
        });
    }

    public int GetHargaObat(string namaObat)
    {
        var obat = daftarObatConfig.FirstOrDefault(o => o.nama.Equals(namaObat, StringComparison.OrdinalIgnoreCase));
        return obat?.harga ?? 0;
    }

    public IEnumerable<Obat> GetObats()
    {
        return pembelianUser;
    }

    public void TampilkanDaftarObat()
    {
        Console.WriteLine("=== Daftar Obat yang Dibeli ===");
        foreach (var obat in pembelianUser)
        {
            Console.WriteLine($"Nama: {obat.nama}, Harga: {obat.harga}, Jumlah: {obat.stok}");
        }
    }

    public void TampilkanRiwayatPembelian()
    {
        Console.WriteLine("=== Riwayat Pembelian ===");
        if (pembelianUser.Count == 0)
        {
            Console.WriteLine("Belum ada obat yang dibeli.");
            return;
        }

        foreach (var obat in pembelianUser)
        {
            int total = obat.harga * obat.stok;
            Console.WriteLine($"- {obat.nama} x {obat.stok} = Rp{total}");
        }
    }

    public IEnumerable<Obat> GetObatsFromAPI()
    {
        return daftarObatConfig;
    }

    public async Task BeliObatAsync()
    {
        Console.Write("Nama obat: ");
        string nama = Console.ReadLine();

        if (!await IsObatValidAsync(nama))
        {
            Console.WriteLine("Obat tidak ditemukan di daftar.");
            return;
        }

        Console.Write("Jumlah: ");
        if (!int.TryParse(Console.ReadLine(), out int jumlah) || jumlah <= 0)
        {
            Console.WriteLine("Jumlah tidak valid.");
            return;
        }

        int harga = GetHargaObat(nama);
        int totalHarga = harga * jumlah;

        Console.WriteLine($"Total harga: Rp{totalHarga}");

        TambahObat(nama, jumlah, harga, DateTime.Now);
        Console.WriteLine("Obat berhasil ditambahkan ke riwayat pembelian.");
    }
}
