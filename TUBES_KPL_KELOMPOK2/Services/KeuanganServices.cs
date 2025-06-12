using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class KeuanganService
    {
        private List<TransaksiKeuangan> _transaksiKeuangan = new List<TransaksiKeuangan>();
        public string State { get; private set; } = "Idle"; // State-based 
        private string _jsonPath = @"APOTEKKU_API_Kelompok2\Data\Keuangan.json";

        public async Task TambahTransaksiAsync(TransaksiKeuangan transaksi)
        {
            // Precondition: Validasi input transaksi
            if (transaksi == null)
            {
                Console.WriteLine("Transaksi tidak boleh null.");
                return;
            }
            if (string.IsNullOrEmpty(transaksi.JenisTransaksi) ||
                (transaksi.JenisTransaksi != "Pemasukan" && transaksi.JenisTransaksi != "Pengeluaran"))
            {
                Console.WriteLine("Jenis transaksi harus 'Pemasukan' atau 'Pengeluaran'.");
                return;
            }
            if (transaksi.Jumlah <= 0)
            {
                Console.WriteLine("Jumlah transaksi harus lebih besar dari 0.");
                return;
            }

            if (State != "Idle")
            {
                Console.WriteLine("Sistem sedang sibuk. Tidak dapat menambahkan transaksi saat ini.");
                return;
            }

            try
            {
                State = "Processing";
                Console.WriteLine("Sedang memproses transaksi...");
                await Task.Delay(2000); // Simulasi proses yang memakan waktu
                _transaksiKeuangan.Add(transaksi);
                State = "Idle";
                Console.WriteLine("Transaksi berhasil ditambahkan.");
            }
            catch
            {
                State = "Error";
                Console.WriteLine("Terjadi kesalahan saat menambahkan transaksi.");
            }
        }

        public IEnumerable<TransaksiKeuangan> GetSemuaTransaksi()
        {
            // Precondition: Sistem dalam keadaan idle
            if (State == "Processing")
            {
                Console.WriteLine("Sistem sedang memproses. Tidak dapat mengambil data transaksi saat ini.");
                return Enumerable.Empty<TransaksiKeuangan>();
            }

            if (State == "Error")
            {
                Console.WriteLine("Sistem dalam keadaan error. Tidak dapat mengambil data transaksi.");
                return Enumerable.Empty<TransaksiKeuangan>();
            }

            // Postcondition: Mengembalikan daftar transaksi yang valid
            return _transaksiKeuangan;
        }

        public int HitungTotalPemasukan()
        {
            // Precondition: Sistem dalam keadaan idle
            if (State == "Processing")
            {
                Console.WriteLine("Sistem sedang memproses. Tidak dapat menghitung pemasukan saat ini.");
                return 0;
            }

            if (State == "Error")
            {
                Console.WriteLine("Sistem dalam keadaan error. Tidak dapat menghitung pemasukan.");
                return 0;
            }

            // Postcondition: Mengembalikan total pemasukan yang valid
            return _transaksiKeuangan
                .Where(t => t.JenisTransaksi == "Pemasukan")
                .Sum(t => t.Jumlah);
        }

        public int HitungTotalPengeluaran()
        {
            // Precondition: Sistem dalam keadaan idle
            if (State == "Processing")
            {
                Console.WriteLine("Sistem sedang memproses. Tidak dapat menghitung pengeluaran saat ini.");
                return 0;
            }

            if (State == "Error")
            {
                Console.WriteLine("Sistem dalam keadaan error. Tidak dapat menghitung pengeluaran.");
                return 0;
            }

            // Postcondition: Mengembalikan total pengeluaran yang valid
            return _transaksiKeuangan
                .Where(t => t.JenisTransaksi == "Pengeluaran")
                .Sum(t => t.Jumlah);
        }

        public void SimulasikanError()
        {
            // Precondition: Hanya bisa disimulasikan jika sistem dalam keadaan Idle
            if (State != "Idle")
            {
                Console.WriteLine("Tidak dapat mensimulasikan error saat sistem tidak dalam keadaan Idle.");
                return;
            }
            State = "Error";
            Console.WriteLine("Sistem telah disimulasikan dalam keadaan error.");
        }

        public void ResetState()
        {
            // Precondition: Sistem harus dalam keadaan error untuk melakukan reset
            if (State == "Error")
            {
                State = "Idle";
                Console.WriteLine("Sistem telah direset ke keadaan Idle.");
            }
            else
            {
                Console.WriteLine("Sistem tidak dalam keadaan error. Tidak perlu direset.");
            }
        }
    }

    public class TransaksiKeuangan
    {
        public string JenisTransaksi { get; set; } // "Pemasukan" atau "Pengeluaran"
        public string Keterangan { get; set; }
        public int Jumlah { get; set; }
        public DateTime Tanggal { get; set; }

        public TransaksiKeuangan(string jenisTransaksi, string keterangan, int jumlah, DateTime tanggal)
        {
            // Precondition: Memastikan transaksi valid
            if (string.IsNullOrEmpty(jenisTransaksi) || (jenisTransaksi != "Pemasukan" && jenisTransaksi != "Pengeluaran"))
            {
                throw new ArgumentException("Jenis transaksi harus 'Pemasukan' atau 'Pengeluaran'.");
            }
            if (jumlah <= 0)
            {
                throw new ArgumentException("Jumlah transaksi harus lebih besar dari 0.");
            }

            JenisTransaksi = jenisTransaksi;
            Keterangan = keterangan;
            Jumlah = jumlah;
            Tanggal = tanggal;
        }
    }
}
