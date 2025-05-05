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
            if (obats == null)
                throw new ArgumentNullException(nameof(obats), "Daftar obat tidak boleh null.");

            if (!obats.Any())
                throw new ArgumentException("Daftar obat tidak boleh kosong.", nameof(obats));

            if (tanggal > DateTime.Now)
                throw new ArgumentException("Tanggal pembelian tidak boleh di masa depan.", nameof(tanggal));

            Tanggal = tanggal;
            Obats = obats;

            if (Tanggal != tanggal || Obats != obats)
                throw new InvalidOperationException("Objek RiwayatPembelian gagal dibuat dengan benar.");
        }

        public void ValidateState()
        {
            if (Obats == null || !Obats.Any())
                throw new InvalidOperationException("Riwayat pembelian harus memiliki minimal satu obat.");

            if (Tanggal > DateTime.Now)
                throw new InvalidOperationException("Tanggal tidak valid (masa depan).");
        }
    }
}