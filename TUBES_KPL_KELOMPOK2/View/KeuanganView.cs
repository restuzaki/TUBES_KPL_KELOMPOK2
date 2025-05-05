using TUBES_KPL_KELOMPOK2.Services;

namespace TUBES_KPL_KELOMPOK2.View
{
    public class KeuanganView

    {
        private readonly KeuanganService _keuanganService;

        public KeuanganView(KeuanganService keuanganService)
        {
            _keuanganService = keuanganService;
        }

        public void KelolaPemasukan()
        {
            if (_keuanganService.State != "Idle")
            {
                Console.WriteLine("Sistem sedang sibuk. Tidak dapat mengelola pemasukan saat ini.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("=== Management Pemasukan ===");
            Console.Write("Masukkan keterangan pemasukan: ");
            string keterangan = Console.ReadLine();
            Console.Write("Masukkan jumlah pemasukan: ");
            if (int.TryParse(Console.ReadLine(), out int jumlah))
            {
                var transaksi = new TransaksiKeuangan("Pemasukan", keterangan, jumlah, DateTime.Now);
                _keuanganService.TambahTransaksiAsync(transaksi).Wait(); // Panggil metode async
            }
            else
            {
                Console.WriteLine("Jumlah tidak valid.");
            }
            Console.WriteLine("\nTekan sembarang tombol untuk kembali...");
            Console.ReadKey();
        }

        public void KelolaPengeluaran()
        {
            if (_keuanganService.State != "Idle")
            {
                Console.WriteLine("Sistem sedang sibuk. Tidak dapat mengelola pengeluaran saat ini.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("=== Management Pengeluaran ===");
            Console.Write("Masukkan keterangan pengeluaran: ");
            string keterangan = Console.ReadLine();
            Console.Write("Masukkan jumlah pengeluaran: ");
            if (int.TryParse(Console.ReadLine(), out int jumlah))
            {
                var transaksi = new TransaksiKeuangan("Pengeluaran", keterangan, jumlah, DateTime.Now);
                _keuanganService.TambahTransaksiAsync(transaksi).Wait(); // Panggil metode async
            }
            else
            {
                Console.WriteLine("Jumlah tidak valid.");
            }
            Console.WriteLine("\nTekan sembarang tombol untuk kembali...");
            Console.ReadKey();
        }



        public void TampilkanLaporanKeuangan()
        {
            if (_keuanganService.State == "Error")
            {
                Console.WriteLine("Sistem dalam keadaan error. Tidak dapat menampilkan laporan keuangan.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("=== Laporan Keuangan ===");
            foreach (var transaksi in _keuanganService.GetSemuaTransaksi())
            {
                Console.WriteLine($"{transaksi.Tanggal:yyyy-MM-dd} | {transaksi.JenisTransaksi} | {transaksi.Keterangan} | Rp{transaksi.Jumlah}");
            }

            Console.WriteLine($"\nTotal Pemasukan: Rp{_keuanganService.HitungTotalPemasukan()}");
            Console.WriteLine($"Total Pengeluaran: Rp{_keuanganService.HitungTotalPengeluaran()}");
            Console.WriteLine($"Saldo: Rp{_keuanganService.HitungTotalPemasukan() - _keuanganService.HitungTotalPengeluaran()}");
            Console.WriteLine("\nTekan sembarang tombol untuk kembali...");
            Console.ReadKey();
        }
        public void TampilkanMenuKeuangan()
        {
            var menuActions = new Dictionary<string, Action>
            {
                { "1", KelolaPemasukan },
                { "2", KelolaPengeluaran },
                { "3", TampilkanLaporanKeuangan },
                { "4", () => { return; } }, // Kembali
                { "5", _keuanganService.SimulasikanError }, // Simulasi Error
                { "6", _keuanganService.ResetState } // Reset State
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Manajemen Keuangan ===");
                Console.WriteLine($"Sistem dalam keadaan: {_keuanganService.State}"); // Tampilkan state
                Console.WriteLine("1. Kelola Pemasukan");
                Console.WriteLine("2. Kelola Pengeluaran");
                Console.WriteLine("3. Lihat Laporan Keuangan");
                Console.WriteLine("4. Kembali");
                Console.WriteLine("5. Simulasikan Error"); // Tambahkan opsi Simulasikan Error
                Console.WriteLine("6. Reset State"); // Tambahkan opsi Reset State
                Console.Write("Pilih opsi: ");
                string pilihan = Console.ReadLine();

                if (menuActions.TryGetValue(pilihan, out var action))
                {
                    action();
                    if (pilihan == "4") break; // Keluar dari menu
                }
                else
                {
                    Console.WriteLine("Pilihan tidak valid, coba lagi.");
                    Console.ReadKey();
                }
            }
        }
    }
}
