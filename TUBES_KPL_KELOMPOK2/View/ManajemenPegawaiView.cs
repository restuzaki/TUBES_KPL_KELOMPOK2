using Apotekku_API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TUBES_KPL_KELOMPOK2.Services;

namespace TUBES_KPL_KELOMPOK2.View
{
    public class ManajemenPegawaiView
    {
        private readonly PegawaiService _layananPegawai;
        private readonly PegawaiStateManager _pengelolaStatus;

        public ManajemenPegawaiView(PegawaiService layananPegawai)
        {
            _layananPegawai = layananPegawai;
            _pengelolaStatus = new PegawaiStateManager();
        }

        public async Task TampilkanMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU MANAJEMEN PEGAWAI ===");
                Console.WriteLine("1. Cek Status Pegawai berdasarkan ID");
                Console.WriteLine("2. Lihat Seluruh Data Pegawai");
                Console.WriteLine("3. Tambah Pegawai");
                Console.WriteLine("4. Ubah Data Pegawai");
                Console.WriteLine("5. Hapus Pegawai");
                Console.WriteLine("6. Kembali");
                Console.Write("Pilihan Anda: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await CekPegawaiByIdAsync();
                        break;
                    case "2":
                        await TampilkanSeluruhPegawaiAsync();
                        break;
                    case "3":
                        await TambahPegawaiAsync();
                        break;
                    case "4":
                        await UbahPegawaiAsync();
                        break;
                    case "5":
                        await HapusPegawaiAsync();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("❌ Input tidak valid!");
                        break;
                }

                Console.WriteLine("\nTekan sembarang tombol untuk melanjutkan...");
                Console.ReadKey();
            }
        }

        private async Task CekPegawaiByIdAsync()
        {
            Console.Write("\nMasukkan ID Pegawai: ");
            var id = Console.ReadLine();

            try
            {
                var pegawai = await _layananPegawai.AmbilPegawaiByIdAsync(id);
                if (pegawai != null)
                {
                    _pengelolaStatus.TampilkanStatus(pegawai);
                }
                else
                {
                    Console.WriteLine("❌ Pegawai tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error: {ex.Message}");
            }
        }

        private async Task TampilkanSeluruhPegawaiAsync()
        {
            try
            {
                var daftarPegawai = await _layananPegawai.AmbilSemuaPegawaiAsync();
                if (daftarPegawai == null || daftarPegawai.Count == 0)
                {
                    Console.WriteLine("⚠️ Tidak ada data pegawai.");
                    return;
                }

                Console.WriteLine("\n=== DAFTAR PEGAWAI ===");
                Console.WriteLine("============================================");
                Console.WriteLine("| ID    | Nama Pegawai      | Status       |");
                Console.WriteLine("============================================");

                foreach (var pegawai in daftarPegawai)
                {
                    Console.Write($"| {pegawai.id,-5} | {pegawai.nama,-18} | ");
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

                Console.WriteLine("============================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error: {ex.Message}");
            }
        }

        private async Task TambahPegawaiAsync()
        {
            Console.WriteLine("\n=== TAMBAH DATA PEGAWAI ===");
            Console.Write("ID Pegawai: ");
            var id = Console.ReadLine();

            Console.Write("Nama Pegawai: ");
            var nama = Console.ReadLine();

            Console.Write("Jabatan Pegawai: ");
            var jabatan = Console.ReadLine();

            Console.Write("Status Pegawai (Aktif, Cuti, TidakAktif): ");
            var statusInput = Console.ReadLine();

            var pegawaiBaru = new Pegawai
            {
                id = id,
                nama = nama,
                jabatan = jabatan,
                status = Enum.TryParse(statusInput, true, out PegawaiStatus status) ? status : PegawaiStatus.Aktif
            };

            try
            {
                await _layananPegawai.TambahPegawaiAsync(pegawaiBaru);
                Console.WriteLine("✅ Pegawai berhasil ditambahkan.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error: {ex.Message}");
            }
        }

        private async Task UbahPegawaiAsync()
        {
            Console.Write("\nMasukkan ID Pegawai yang ingin diubah: ");
            var id = Console.ReadLine();

            try
            {
                var pegawai = await _layananPegawai.AmbilPegawaiByIdAsync(id);
                if (pegawai == null)
                {
                    Console.WriteLine("❌ Pegawai tidak ditemukan.");
                    return;
                }

                Console.WriteLine($"Nama Saat Ini: {pegawai.nama}");
                Console.Write("Nama Baru: ");
                pegawai.nama = Console.ReadLine();

                Console.WriteLine($"Jabatan Saat Ini: {pegawai.jabatan}");
                Console.Write("Jabatan Baru: ");
                pegawai.jabatan = Console.ReadLine();

                Console.WriteLine($"Status Saat Ini: {pegawai.status}");
                Console.Write("Status Baru (Aktif, Cuti, TidakAktif): ");
                var statusBaru = Console.ReadLine();
                pegawai.status = Enum.TryParse(statusBaru, true, out PegawaiStatus statusParsed) ? statusParsed : pegawai.status;

                await _layananPegawai.PerbaruiPegawaiAsync(pegawai);
                Console.WriteLine("✅ Data pegawai berhasil diperbarui.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error: {ex.Message}");
            }
        }

        private async Task HapusPegawaiAsync()
        {
            Console.Write("\nMasukkan ID Pegawai yang ingin dihapus: ");
            var id = Console.ReadLine();

            try
            {
                var berhasil = await _layananPegawai.HapusPegawaiAsync(id);
                Console.WriteLine(berhasil ? "✅ Pegawai berhasil dihapus." : "❌ Pegawai tidak ditemukan.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error: {ex.Message}");
            }
        }
    }
}
