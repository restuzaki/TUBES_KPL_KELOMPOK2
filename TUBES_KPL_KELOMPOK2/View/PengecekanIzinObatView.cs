using System;
using System.Threading.Tasks;
using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.Services;

namespace TUBES_KPL_KELOMPOK2.Views.PengecekanIzinObat
{
    public class PengecekanIzinObatView
    {
        private readonly ObatService _layananObat;
        private readonly ObatStateManager _pengelolaStatus;

        public PengecekanIzinObatView(ObatService layananObat)
        {
            _layananObat = layananObat;
            _pengelolaStatus = new ObatStateManager();
        }

        public async Task TampilkanMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== PENGECEKAN IZIN OBAT ===");
                Console.WriteLine("1. Cek Status Obat berdasarkan ID");
                Console.WriteLine("2. Lihat Semua Obat");
                Console.WriteLine("3. Kembali");
                Console.Write("Pilih menu: ");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        await TampilkanStatusObatPerIdAsync();
                        break;
                    case "2":
                        await TampilkanSemuaObatAsync();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        break;
                }

                Console.WriteLine("\nTekan sembarang tombol untuk kembali...");
                Console.ReadKey();
            }
        }

        private async Task TampilkanStatusObatPerIdAsync()
        {
            Console.Write("\nMasukkan ID Obat: ");
            string idObat = Console.ReadLine();

            try
            {
                var obat = await _layananObat.DapatkanObatByIdAsync(idObat);
                if (obat != null)
                {
                    _pengelolaStatus.TampilkanStatus(obat);
                }
                else
                {
                    Console.WriteLine("Obat dengan ID tersebut tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
            }
        }

        private async Task TampilkanSemuaObatAsync()
        {
            try
            {
                var daftarObat = await _layananObat.DapatkanSemuaObatAsync();
                if (daftarObat == null || daftarObat.Count == 0)
                {
                    Console.WriteLine("Data obat kosong.");
                    return;
                }

                Console.WriteLine("\nDAFTAR OBAT:");
                Console.WriteLine("===============================================");
                Console.WriteLine("| ID    | Nama Obat         | Status           |");
                Console.WriteLine("===============================================");

                foreach (var obat in daftarObat)
                {
                    Console.Write($"| {obat.id,-6} | {obat.nama,-17} | ");

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
                        default:
                            Console.ResetColor();
                            break;
                    }

                    Console.WriteLine($"{obat.status,-15} |");
                    Console.ResetColor();
                }

                Console.WriteLine("===============================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
            }
        }
    }
}
