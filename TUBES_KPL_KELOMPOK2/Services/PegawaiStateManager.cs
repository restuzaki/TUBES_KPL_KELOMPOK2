using Apotekku_API.Models;
using System;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class PegawaiStateManager
    {
        public void TampilkanStatus(Pegawai pegawai)
        {
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
                    Console.WriteLine("Nonaktif");
                    break;
                default:
                    Console.ResetColor();
                    Console.WriteLine("Tidak diketahui");
                    break;
            }

            Console.ResetColor();
        }
    }
}
