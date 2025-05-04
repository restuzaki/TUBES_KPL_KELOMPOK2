using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
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
        var json = File.ReadAllText("Data\\Obat.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // agar tidak case-sensitive terhadap nama property
        };
        var medicines = JsonSerializer.Deserialize<List<Obat>>(json, options);
        return medicines;
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

        int countBefore = pembelianUser.Count;

        pembelianUser.Add(new Obat
        {
            nama = nama,
            stok = jumlah,
            harga = harga,
        });
    }
    public int GetHargaObat(string namaObat)
    {
        var obat = daftarObatConfig.FirstOrDefault(o => o.nama.Equals(namaObat, StringComparison.OrdinalIgnoreCase));
        return obat.harga;
    }
    public IEnumerable<Obat> GetObats()
    {
        return pembelianUser;
    }
    public void TampilkanDaftarObat()
    {
        var obats = GetObats();
        foreach (var obat in obats)
        {
            Console.WriteLine($"Nama: {obat.nama}, Harga: {obat.harga}, Stok: {obat.stok}");
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
            Console.WriteLine("Obat tidak ditemukan di daftar konfigurasi.");
            return;
        }

        Console.Write("Jumlah: ");
        int jumlah = int.Parse(Console.ReadLine());
        int harga = GetHargaObat(nama);
        if (jumlah <= 0)
        {
            Console.WriteLine("Jumlah harus lebih dari 0.");
            return;
        }
        int totalHarga = harga * jumlah;
        Console.WriteLine($"Total harga untuk {jumlah} {nama} adalah: {totalHarga}");

        TambahObat(nama, jumlah, harga, DateTime.Now);
        Console.WriteLine("Obat berhasil ditambahkan ke pembelian.");
    }

}
