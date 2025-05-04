using System;
using System.Threading.Tasks;
using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.Services;

namespace TUBES_KPL_KELOMPOK2.Views.PengecekanIzinObat
{
    public class PengecekanIzinObatView
    {
        private readonly ObatService _obatService;
        private readonly ObatStateManager _stateManager;

        public PengecekanIzinObatView(ObatService obatService)
        {
            _obatService = obatService;
            _stateManager = new ObatStateManager();
        }

        public async Task ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== PENGECEKAN IZIN OBAT ===");
                Console.WriteLine("1. Cek Status Obat by ID");
                Console.WriteLine("2. Lihat Semua Obat");
                Console.WriteLine("3. Kembali");
                Console.Write("Pilih: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await CheckSingleObat();
                        break;
                    case "2":
                        await CheckAllObat();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Input tidak valid!");
                        break;
                }

                Console.WriteLine("\nTekan sembarang tombol...");
                Console.ReadKey();
            }
        }

        private async Task CheckSingleObat()
        {
            Console.Write("\nMasukkan ID Obat: ");
            var id = Console.ReadLine();

            try
            {
                var obat = await _obatService.GetObatByIdAsync(id);
                if (obat != null)
                {
                    _stateManager.CheckStatus(obat);
                }
                else
                {
                    Console.WriteLine("Obat tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task CheckAllObat()
        {
            try
            {
                var allObat = await _obatService.GetAllObatAsync();
                if (allObat == null || allObat.Count == 0)
                {
                    Console.WriteLine("Tidak ada data obat");
                    return;
                }

                Console.WriteLine("\nDAFTAR OBAT:");
                Console.WriteLine("==========================================");
                Console.WriteLine("| ID    | Nama Obat         | Status        |");
                Console.WriteLine("==========================================");

                foreach (var obat in allObat)
                {
                    Console.Write($"| {obat.id,-5} | {obat.nama,-16} | ");

                    switch (obat.status)
                    {
                        case ObatStatus.Terdaftar:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case ObatStatus.TidakTerdaftar:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case ObatStatus.Kadaluarsa:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }

                    Console.WriteLine($"{obat.status,-12} |");
                    Console.ResetColor();
                }

                Console.WriteLine("==========================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}