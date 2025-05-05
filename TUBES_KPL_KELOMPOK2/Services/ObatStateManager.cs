using Apotekku_API.Models;

public class ObatStateManager
{
    public void CheckStatus(Obat obat)
    {
        try
        {
            if (obat == null)
                throw new ArgumentNullException(nameof(obat), "Objek obat tidak boleh null");

            if (string.IsNullOrWhiteSpace(obat.id) || string.IsNullOrWhiteSpace(obat.nama))
                throw new ArgumentException("ID atau Nama obat tidak boleh kosong");

            if (obat.harga < 0 || obat.stok < 0)
                throw new ArgumentOutOfRangeException("Harga atau stok tidak boleh negatif");

            Console.WriteLine($"\n=== DETAIL OBAT {obat.id} ===");
            Console.WriteLine($"Nama: {obat.nama}");
            Console.WriteLine($"Harga: Rp {obat.harga:N0}");
            Console.WriteLine($"Stok: {obat.stok}");

            switch (obat.status)
            {
                case ObatStatus.Terdaftar:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nSTATUS: TERDAFTAR (Legal)");
                    Console.ResetColor();
                    Console.WriteLine($"Tanggal Kadaluarsa: {obat.kadaluarsa}");
                    Console.WriteLine("Sah untuk dijual");
                    break;

                case ObatStatus.TidakTerdaftar:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSTATUS: TIDAK TERDAFTAR");
                    Console.ResetColor();
                    Console.WriteLine("DILARANG DIJUAL!");
                    Console.WriteLine("Alasan: Obat ilegal/tidak terdaftar BPOM");
                    break;

                case ObatStatus.Kadaluarsa:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nSTATUS: KADALUARSA");
                    Console.ResetColor();
                    Console.WriteLine($"Tanggal Kadaluarsa: {obat.kadaluarsa}");
                    Console.WriteLine("DILARANG DIJUAL!");
                    Console.WriteLine("Alasan: Melewati tanggal kadaluarsa");
                    break;

                default:
                    throw new InvalidOperationException("Status obat tidak dikenali");
            }

            Console.WriteLine("==============================");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERROR] {ex.Message}");
            Console.ResetColor();
        }
    }
}
