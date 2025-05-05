namespace  Apotekku_API.Models

{
    public class Member
    {
        public string Id { get; set; } = string.Empty;
        public string Nama { get; set; } = string.Empty;
        public string Alamat { get; set; } = string.Empty;
        public string TanggalLahir { get; set; } = string.Empty; 
        public string NomorTelepon { get; set; } = string.Empty;
        public int Poin { get; set; }
    }
}
