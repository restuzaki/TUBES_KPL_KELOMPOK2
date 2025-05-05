using Apotekku_API.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

public class StokObatView
{
    private readonly StokObatService _service;

    public StokObatView()
    {
        _service = new StokObatService();
    }

    public async Task MenuStokObat()
    {
        string? pilihan;
        do
        {
            Console.Clear();
            Console.WriteLine("=== Menu Stok Obat ===");
            Console.WriteLine("1. Lihat semua stok");
            Console.WriteLine("2. Tambah obat baru");
            Console.WriteLine("3. Update stok obat");
            Console.WriteLine("4. Hapus obat");
            Console.WriteLine("0. Kembali");
            Console.Write("Pilih menu: ");
            pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    await TampilkanSemuaObat();
                    break;
                case "2":
                    await TambahObatBaru();
                    break;
                case "3":
                    await UpdateStokObat();
                    break;
                case "4":
                    await HapusObat();
                    break;
            }

            if (pilihan != "0")
            {
                Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
                Console.ReadLine();
            }

        } while (pilihan != "0");
    }

    private async Task TampilkanSemuaObat()
    {
        var daftarObat = await _service.GetAllObatAsync();
        Console.WriteLine("\n--- Daftar Obat ---");

        if (daftarObat.Count == 0)
        {
            Console.WriteLine("Tidak ada data obat.");
            return;
        }

        foreach (var obat in daftarObat)
        {
            Console.WriteLine($"Kode: {obat.id}, Nama: {obat.nama}, Stok: {obat.stok}, Expired: {obat.kadaluarsa}");
        }
    }

    private async Task TambahObatBaru()
    {
        Console.Write("Kode Obat: ");
        string kode = Console.ReadLine()!;
        Console.Write("Nama Obat: ");
        string nama = Console.ReadLine()!;
        Console.Write("Stok: ");
        int stok = int.Parse(Console.ReadLine()!);
        Console.Write("Tanggal Expired (yyyy-MM-dd): ");
        string expired = Console.ReadLine()!;

        var obat = new Obat
        {
            id = kode,
            nama = nama,
            stok = stok,
            kadaluarsa = expired
        };

        await _service.TambahObatAsync(obat);
        Console.WriteLine("Obat berhasil ditambahkan.");
    }

    private async Task UpdateStokObat()
    {
        Console.Write("Masukkan kode obat: ");
        string kode = Console.ReadLine()!;
        Console.Write("Stok baru: ");
        int stokBaru = int.Parse(Console.ReadLine()!);

        await _service.UpdateStokAsync(kode, stokBaru);
        Console.WriteLine("Stok berhasil diperbarui.");
    }

    private async Task HapusObat()
    {
        Console.Write("Masukkan kode obat yang akan dihapus: ");
        string kode = Console.ReadLine()!;

        bool sukses = await _service.HapusObatAsync(kode);
        if (sukses)
            Console.WriteLine("Obat berhasil dihapus.");
        else
            Console.WriteLine("Gagal menghapus obat.");
    }
}
