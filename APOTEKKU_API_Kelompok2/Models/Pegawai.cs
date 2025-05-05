namespace Apotekku_API.Models
{
    public enum PegawaiStatus
    {
        Aktif,
        TidakAktif,
        Cuti,
    }
    public class Pegawai
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string jabatan { get; set; }
        public PegawaiStatus status { get; set; }

       

    }
}