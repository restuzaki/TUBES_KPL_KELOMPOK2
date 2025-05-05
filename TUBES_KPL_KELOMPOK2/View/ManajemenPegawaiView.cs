using Apotekku_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUBES_KPL_KELOMPOK2.Services;

namespace TUBES_KPL_KELOMPOK2.View
{
    public class ManajemenPegawaiView
    {
        private readonly PegawaiService _pegawaiService;
        private readonly PegawaiStateManager _stateManager;

        public ManajemenPegawaiView(PegawaiService pegawaiService)
        {
            _pegawaiService = pegawaiService;
            _stateManager = new PegawaiStateManager();
        }

        public async Task ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MANAJEMEN PEGAWAI ===");
                Console.WriteLine("1. Cek Status Pegawai by ID");
                Console.WriteLine("2. Lihat Semua Pegawai");
                Console.WriteLine("3. Tambah Pegawai");
                Console.WriteLine("4. Update Pegawai");
                Console.WriteLine("5. Hapus Pegawai");
                Console.WriteLine("6. Kembali");
                Console.Write("Pilih: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await CheckSinglePegawai();
                        break;
                    case "2":
                        await CheckAllPegawai();
                        break;
                    case "3":
                        await CreatePegawai();
                        break;
                    case "4":
                        await UpdatePegawai();
                        break;
                    case "5":
                        await DeletePegawai();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Input tidak valid!");
                        break;
                }

                Console.WriteLine("\nTekan sembarang tombol...");
                Console.ReadKey();
            }
        }

        private async Task CheckSinglePegawai()
        {
            Console.Write("\nMasukkan ID Pegawai: ");
            var id = Console.ReadLine();

            try
            {
                var pegawai = await _pegawaiService.GetPegawaiByIdAsync(id);
                if (pegawai != null)
                {
                    _stateManager.TampilkanStatus(pegawai);
                }
                else
                {
                    Console.WriteLine("Pegawai tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task CheckAllPegawai()
        {
            try
            {
                var allPegawai = await _pegawaiService.GetAllPegawaiAsync();
                if (allPegawai == null || allPegawai.Count == 0)
                {
                    Console.WriteLine("Tidak ada data pegawai");
                    return;
                }

                Console.WriteLine("\nDAFTAR PEGAWAI:");
                Console.WriteLine("==========================================");
                Console.WriteLine("| ID    | Nama Pegawai      | Status        |");
                Console.WriteLine("==========================================");

                foreach (var pegawai in allPegawai)
                {
                    Console.Write($"| {pegawai.id,-5} | {pegawai.nama,-16} | ");

                    switch (pegawai.status)
                    {
                        case PegawaiStatus.Aktif:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case PegawaiStatus.Cuti:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case PegawaiStatus.TidakAktif:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                    }

                    Console.WriteLine($"{pegawai.status,-12} |");
                    Console.ResetColor();
                }

                Console.WriteLine("==========================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Create Pegawai
        private async Task CreatePegawai()
        {
            Console.WriteLine("\n=== TAMBAH PEGAWAI ===");
            Console.Write("Masukkan ID Pegawai: ");
            var id = Console.ReadLine();

            Console.Write("Masukkan Nama Pegawai: ");
            var nama = Console.ReadLine();

            Console.Write("Masukkan Jabatan Pegawai: ");
            var jabatan = Console.ReadLine();

            Console.Write("Masukkan Status Pegawai (Aktif, Cuti, TidakAktif): ");
            var status = Console.ReadLine();

            try
            {
                var pegawai = new Pegawai
                {
                    id = id,
                    nama = nama,
                    jabatan = jabatan,
                    status = Enum.TryParse(status, out PegawaiStatus parsedStatus) ? parsedStatus : PegawaiStatus.Aktif
                };

                await _pegawaiService.CreatePegawaiAsync(pegawai);
                Console.WriteLine("Pegawai berhasil ditambahkan!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Update Pegawai
        private async Task UpdatePegawai()
        {
            Console.Write("\nMasukkan ID Pegawai yang ingin diupdate: ");
            var id = Console.ReadLine();

            try
            {
                var pegawai = await _pegawaiService.GetPegawaiByIdAsync(id);
                if (pegawai != null)
                {
                    Console.WriteLine($"Nama Pegawai: {pegawai.nama} (current)");
                    Console.Write("Masukkan Nama Pegawai baru: ");
                    pegawai.nama = Console.ReadLine();

                    Console.WriteLine($"Jabatan Pegawai: {pegawai.jabatan} (current)");
                    Console.Write("Masukkan Jabatan Pegawai baru: ");
                    pegawai.jabatan = Console.ReadLine();

                    Console.WriteLine($"Status Pegawai: {pegawai.status} (current)");
                    Console.Write("Masukkan Status Pegawai baru (Aktif, Cuti, Nonaktif): ");
                    var status = Console.ReadLine();
                    pegawai.status = Enum.TryParse(status, out PegawaiStatus parsedStatus) ? parsedStatus : pegawai.status;

                    await _pegawaiService.UpdatePegawaiAsync(pegawai);
                    Console.WriteLine("Pegawai berhasil diupdate!");
                }
                else
                {
                    Console.WriteLine("Pegawai tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Delete Pegawai
        private async Task DeletePegawai()
        {
            Console.Write("\nMasukkan ID Pegawai yang ingin dihapus: ");
            var id = Console.ReadLine();

            try
            {
                var result = await _pegawaiService.DeletePegawaiAsync(id);
                if (result)
                {
                    Console.WriteLine("Pegawai berhasil dihapus!");
                }
                else
                {
                    Console.WriteLine("Pegawai tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
