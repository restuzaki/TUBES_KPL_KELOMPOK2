using System;
using System.Linq;
using System.Collections.Generic;
using TUBES_KPL_KELOMPOK2.Services;
using Apotekku_API.Models;

namespace TUBES_KPL_KELOMPOK2.View
{
    public static class BacaResepView
    {
        private static readonly BacaResepService bacaResepService = new BacaResepService();

        public static void TampilkanObatTerdaftar()
        {
            var daftarObat = bacaResepService.GetObatTerdaftar();

            if (daftarObat == null)
                throw new InvalidOperationException("Daftar obat tidak boleh null.");

            Console.WriteLine("=== Daftar Obat Terdaftar ===");

            if (!daftarObat.Any())
            {
                Console.WriteLine("Tidak ada obat yang terdaftar.");
                return;
            }

            foreach (var obat in daftarObat)
            {
                ValidasiObat(obat);
                Console.WriteLine($"- {obat.nama} (ID: {obat.id}, Harga: Rp{obat.harga}, Stok: {obat.stok})");
            }
        }

        public static void CariObat()
        {
            var daftarObat = bacaResepService.GetObatTerdaftar();

            if (daftarObat == null)
                throw new InvalidOperationException("Daftar obat tidak boleh null.");

            Console.WriteLine("\nMasukkan nama atau ID obat yang ingin dicari:");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input pencarian tidak boleh kosong.");
                return;
            }

            var hasilPencarian = daftarObat
                .Where(o =>
                    !string.IsNullOrEmpty(o.nama) &&
                    (o.nama.ToLower().Contains(input) || (!string.IsNullOrEmpty(o.id) && o.id.ToLower().Equals(input)))
                )
                .ToList();

            if (hasilPencarian.Any())
            {
                Console.WriteLine("\n=== Hasil Pencarian ===");
                foreach (var obat in hasilPencarian)
                {
                    ValidasiObat(obat);
                    Console.WriteLine($"- {obat.nama} (ID: {obat.id}, Harga: Rp{obat.harga}, Stok: {obat.stok})");
                }
            }
            else
            {
                Console.WriteLine("\nObat tidak ditemukan.");
            }
        }

        private static void ValidasiObat(Obat obat)
        {
            if (obat == null)
                throw new ArgumentNullException(nameof(obat), "Obat tidak boleh null.");

            if (string.IsNullOrWhiteSpace(obat.id))
                throw new InvalidOperationException("Obat harus memiliki ID.");

            if (string.IsNullOrWhiteSpace(obat.nama))
                throw new InvalidOperationException("Obat harus memiliki nama.");

            if (obat.harga < 0)
                throw new InvalidOperationException("Harga obat tidak boleh negatif.");

            if (obat.stok < 0)
                throw new InvalidOperationException("Stok obat tidak boleh negatif.");
        }
    }
}