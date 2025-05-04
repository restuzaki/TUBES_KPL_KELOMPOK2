using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apotekku_API.Models;

namespace TUBES_KPL_KELOMPOK2.View
{
    public class RiwayatPembelian
    {
        public DateTime Tanggal { get; set; }
        public List<Obat> Obats { get; set; }

        public RiwayatPembelian(DateTime tanggal, List<Obat> obats)
        {
            Tanggal = tanggal;
            Obats = obats;
        }
    }

}
