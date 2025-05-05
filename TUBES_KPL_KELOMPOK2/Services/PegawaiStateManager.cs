using Apotekku_API.Models;
using System;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class PegawaiStateManager
    {
        public void TampilkanStatus(Pegawai pegawai)
        {
            try
            {
                if (pegawai == null)
                    throw new ArgumentNullException(nameof(pegawai), "Data pegawai tidak boleh null");

                if (string.IsNullOrWhiteSpace(pegawai.id))
                    throw new ArgumentException("ID pegawai tidak boleh kosong");

                if (string.IsNullOrWhiteSpace(pegawai.nama))
                    throw new ArgumentException("Nama pegawai tidak boleh kosong");

                if (string.IsNullOrWhiteSpace(pegawai.jabatan))
                    throw new ArgumentException("Jabatan pegawai tidak boleh kosong");

                Console.WriteLine($"\nDetail Pegawai:");
                Console.WriteLine($"ID      : {pegawai.id}");
                Console.WriteLine($"Nama    : {pegawai.nama}");
                Console.WriteLine($"Jabatan : {pegawai.jabatan}");
                Console.Write("Status  : ");

                switch (pegawai.status)
                {
                    case PegawaiStatus.Aktif:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Aktif");
                        break;

                    case PegawaiStatus.Cuti:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Cuti");
                        break;

                    case PegawaiStatus.TidakAktif:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tidak Aktif");
                        break;

                    default:
                        Console.WriteLine("Tidak diketahui");
                        break;
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine($"\n[ERROR] {ex.Message}");

            }
        }
    }
}
