using System;
using System.Linq;
using TUBES_KPL_KELOMPOK2.Services;
using Apotekku_API.Models;

namespace TUBES_KPL_KELOMPOK2.View
{
    public static class BacaResepView
    {
        private static BacaResepService bacaResepService = new BacaResepService();

        public static void TampilkanObatTerdaftar()
        {
            var daftarObat = bacaResepService.GetObatTerdaftar();
            Console.WriteLine("=== Daftar Obat Terdaftar ===");
            foreach (var obat in daftarObat)
            {
                Console.WriteLine($"- {obat.nama} (ID: {obat.id}, Harga: Rp{obat.harga}, Stok: {obat.stok})");
            }
        }

        public static void CariObat()
        {
            var daftarObat = bacaResepService.GetObatTerdaftar();

            Console.WriteLine("\nMasukkan nama atau ID obat yang ingin dicari:");
            string input = Console.ReadLine().Trim().ToLower();

            var hasilPencarian = daftarObat
                .Where(o => o.nama.ToLower().Contains(input) || o.id.ToLower().Equals(input))
                .ToList();

            if (hasilPencarian.Count > 0)
            {
                Console.WriteLine("\n=== Hasil Pencarian ===");
                foreach (var obat in hasilPencarian)
                {
                    Console.WriteLine($"- {obat.nama} (ID: {obat.id}, Harga: Rp{obat.harga}, Stok: {obat.stok})");
                }
            }
            else
            {
                Console.WriteLine("\nObat tidak ditemukan.");
            }
        }
    }
}
