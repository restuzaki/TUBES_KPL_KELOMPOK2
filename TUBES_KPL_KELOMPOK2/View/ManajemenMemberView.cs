using Apotekku_API.Models;

public class ManajemenMemberView
{
    private readonly MemberService _service = new();

    public async Task ShowMenu()
    {
        string? input;
        do
        {
            Console.Clear();
            Console.WriteLine("=== Menu Member Apotek ===");
            Console.WriteLine("1. Lihat Semua Member");
            Console.WriteLine("2. Tambah Member");
            Console.WriteLine("3. Edit Member");
            Console.WriteLine("4. Hapus Member");
            Console.WriteLine("0. Kembali");
            Console.Write("Pilih: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    await TampilkanSemuaMember();
                    break;
                case "2":
                    await TambahMember();
                    break;
                case "3":
                    await EditMember();
                    break;
                case "4":
                    await HapusMember();
                    break;
            }

            if (input != "0")
            {
                Console.WriteLine("\nTekan ENTER untuk lanjut...");
                Console.ReadLine();
            }

        } while (input != "0");
    }

    private async Task TampilkanSemuaMember()
    {
        var list = await _service.GetAllMemberAsync();
        Console.WriteLine("\n=== Daftar Member ===");
        foreach (var m in list)
        {
            Console.WriteLine($"ID: {m.Id}, Nama: {m.Nama}, Telp: {m.NomorTelepon}, Poin: {m.Poin}");
        }
    }

    private async Task TambahMember()
    {
        var member = new Member();

        Console.Write("ID Member: ");
        member.Id = Console.ReadLine()!;
        Console.Write("Nama: ");
        member.Nama = Console.ReadLine()!;
        Console.Write("Alamat: ");
        member.Alamat = Console.ReadLine()!;
        Console.Write("Tanggal Lahir (yyyy-MM-dd): ");
        member.TanggalLahir = Console.ReadLine()!;
        Console.Write("Nomor Telepon: ");
        member.NomorTelepon = Console.ReadLine()!;
        Console.Write("Poin Awal: ");
        member.Poin = int.Parse(Console.ReadLine()!);

        await _service.TambahMemberAsync(member);
        Console.WriteLine("✅ Member berhasil ditambahkan.");
    }

    private async Task EditMember()
    {
        Console.Write("Masukkan ID Member yang ingin diubah: ");
        string id = Console.ReadLine()!;

        var list = await _service.GetAllMemberAsync();
        var member = list.FirstOrDefault(m => m.Id == id);

        if (member == null)
        {
            Console.WriteLine(" Member tidak ditemukan.");
            return;
        }

        Console.Write("Nama Baru: ");
        member.Nama = Console.ReadLine()!;
        Console.Write("Alamat Baru: ");
        member.Alamat = Console.ReadLine()!;
        Console.Write("No. Telepon Baru: ");
        member.NomorTelepon = Console.ReadLine()!;
        Console.Write("Poin Baru: ");
        member.Poin = int.Parse(Console.ReadLine()!);

        await _service.UpdateMemberAsync(member);
        Console.WriteLine(" Data member berhasil diperbarui.");
    }

    private async Task HapusMember()
    {
        Console.Write("Masukkan ID Member: ");
        string id = Console.ReadLine()!;
        bool sukses = await _service.HapusMemberAsync(id);

        if (sukses)
            Console.WriteLine(" Member berhasil dihapus.");
        else
            Console.WriteLine(" Gagal hapus member.");
    }
}
