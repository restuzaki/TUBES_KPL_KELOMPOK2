
using System;
using System.Collections.Generic;
using System.Linq;
using Apotekku_API.Models;

namespace TUBES_KPL_KELOMPOK2.View
{
    public class RiwayatPembelian
    {
        public DateTime Tanggal { get; private set; }
        public List<Obat> Obats { get; private set; }

        public RiwayatPembelian(DateTime tanggal, List<Obat> obats)
        {
            if (tanggal > DateTime.Now)
                throw new ArgumentException("Tanggal pembelian tidak boleh di masa depan.");

            if (obats == null)
                throw new ArgumentNullException(nameof(obats), "Daftar obat tidak boleh null.");

            if (!obats.Any())
                throw new ArgumentException("Daftar obat tidak boleh kosong.");

            foreach (var obat in obats)
            {
                ValidasiObat(obat);
            }

            Tanggal = tanggal;
            Obats = obats;
        }

        private void ValidasiObat(Obat obat)
        {
            if (obat == null)
                throw new ArgumentException("Obat tidak boleh null.");

            if (string.IsNullOrWhiteSpace(obat.id))
                throw new ArgumentException("Obat harus memiliki ID.");

            if (string.IsNullOrWhiteSpace(obat.nama))
                throw new ArgumentException("Obat harus memiliki nama.");

            if (obat.harga < 0)
                throw new ArgumentException("Harga obat tidak boleh negatif.");

            if (obat.stok < 0)
                throw new ArgumentException("Stok obat tidak boleh negatif.");
        }
    }
}