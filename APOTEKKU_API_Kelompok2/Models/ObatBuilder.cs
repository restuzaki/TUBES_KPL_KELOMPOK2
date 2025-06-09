using System;

namespace Apotekku_API.Models
{
    public class ObatBuilder
    {
        private readonly Obat _obat;

        public ObatBuilder()
        {
            _obat = new Obat();
        }

        public ObatBuilder AturId(string id)
        {
            _obat.id = id;
            return this;
        }

        public ObatBuilder AturNama(string nama)
        {
            _obat.nama = nama;
            return this;
        }

        public ObatBuilder AturStatus(ObatStatus status)
        {
            _obat.status = status;
            return this;
        }

        public ObatBuilder AturHarga(int harga)
        {
            _obat.harga = harga;
            return this;
        }

        public ObatBuilder AturKadaluarsa(string kadaluarsa)
        {
            _obat.kadaluarsa = kadaluarsa;
            return this;
        }

        public ObatBuilder AturStok(int stok)
        {
            _obat.stok = stok;
            return this;
        }

        public Obat Bangun()
        {
            return _obat;
        }
    }
}