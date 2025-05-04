using Apotekku_API.Models;
using System;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class ObatStateManager
    {
        public void CheckStatus(Obat obat)
        {
            Console.WriteLine($"\n=== DETAIL OBAT {obat.id} ===");
            Console.WriteLine($"Nama: {obat.nama}");
            Console.WriteLine($"Harga: Rp {obat.harga:N0}");
            Console.WriteLine($"Stok: {obat.stok}");

            switch (obat.status)
            {
                case ObatStatus.Terdaftar:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nSTATUS: TERDAFTAR (Legal)");
                    Console.ResetColor();
                    Console.WriteLine($"Tanggal Kadaluarsa: {obat.kadaluarsa}");
                    Console.WriteLine("Sah untuk dijual");
                    break;

                case ObatStatus.TidakTerdaftar:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSTATUS: TIDAK TERDAFTAR");
                    Console.ResetColor();
                    Console.WriteLine("❌ DILARANG DIJUAL!");
                    Console.WriteLine("Alasan: Obat ilegal/tidak terdaftar BPOM");
                    break;

                case ObatStatus.Kadaluarsa:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nSTATUS: KADALUARSA");
                    Console.ResetColor();
                    Console.WriteLine($"Tanggal Kadaluarsa: {obat.kadaluarsa}");
                    Console.WriteLine("DILARANG DIJUAL!");
                    Console.WriteLine("Alasan: Melewati tanggal kadaluarsa");
                    break;
            }

            Console.WriteLine("==============================");
        }
    }
}