using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.Services;
using TUBES_KPL_KELOMPOK2.View;
using TUBES_KPL_KELOMPOK2.Views.PengecekanIzinObat;

class Program
{

    private static ObatService _obatService = new ObatService();
    private static PengecekanIzinObatView _pengecekanView = new PengecekanIzinObatView(_obatService);
    private static UserLogin _userLogin = new UserLogin();
    private static UserRegister _userRegister = new UserRegister();
    private static ChatbotView _chatbotService = new ChatbotView();
    private static PembelianObat _pembelianObat = new PembelianObat();
    private static AnalisisPenyakit _analisisPenyakit = new AnalisisPenyakit();

    static async Task Main()
    {
        var mainMenuActions = new Dictionary<string, Func<Task>>
        {
            { "1", async () => await HandleLogin(_userLogin,_pembelianObat,_analisisPenyakit) },
            { "2", async () => _userRegister.Register() },
            { "3", () => Task.Run(() => Environment.Exit(0)) }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Aplikasi Apotek ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Pilih opsi (1/2/3): ");
            string pilihan = Console.ReadLine();

            if (mainMenuActions.ContainsKey(pilihan))
            {
                await mainMenuActions[pilihan]();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
                Console.ReadKey();
            }
        }
    }

    static async Task HandleLogin(UserLogin userlogin,PembelianObat pembelianObat,AnalisisPenyakit analisisPenyakit)
    {
        User? user = userlogin.Login();
        if (user != null)
        {
            Console.WriteLine($"\nSelamat datang, {user.Nama}!");

            if (user.Role == "Admin")
                await ShowRoleMenu("Admin", GetAdminMenuActions(analisisPenyakit));
            else if (user.Role == "Buyer")
                await ShowRoleMenu("Buyer", GetBuyerMenuActions(pembelianObat));
            else
                Console.WriteLine("Role tidak dikenali.");
        }
    }

    static async Task ShowRoleMenu(string role, Dictionary<string, Func<Task>> menuActions)
    {
        string choice = "";
        while (choice != "exit")
        {
            Console.Clear();
            Console.WriteLine($"\n=== Menu {role} ===");
            int index = 1;
            var keyMap = new Dictionary<string, string>();
            foreach (var kvp in menuActions)
            {
                Console.WriteLine($"{index}. {kvp.Key}");
                keyMap[index.ToString()] = kvp.Key;
                index++;
            }
            Console.WriteLine($"{index}. Logout");
            Console.Write("Pilih opsi: ");
            string input = Console.ReadLine();

            if (input == index.ToString())
            {
                Console.WriteLine("Logout berhasil.\n");
                break;
            }
            else if (keyMap.ContainsKey(input))
            {
                Console.Clear();
                await menuActions[keyMap[input]]();


                if (keyMap[input] != "ChatBot")
                {
                    Console.WriteLine("\nTekan sembarang tombol untuk melanjutkan...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
                Console.ReadKey();
            }
        }
    }

    static Dictionary<string, Func<Task>> GetAdminMenuActions(AnalisisPenyakit analisisPenyakit)
    {
        return new Dictionary<string, Func<Task>>
        {
            { "Lihat Stok Obat", () => Task.Run(() => Console.WriteLine("Fitur Lihat Stok Obat belum diimplementasikan.")) },
            { "Management Member Apotek", () => Task.Run(() => Console.WriteLine("Fitur Management Member Apotek belum diimplementasikan.")) },
            { "Management Pemasukan", () => Task.Run(() => Console.WriteLine("Fitur Management Pemasukan belum diimplementasikan.")) },
            { "Pengeluaran Apotek", () => Task.Run(() => Console.WriteLine("Fitur Pengeluaran Apotek belum diimplementasikan.")) },
            { "Analisis Penyakit Bulanan", async () => await analisisPenyakit.TampilkanAnalisisAsync()},
            { "Pengecekan Izin Obat", async () => await _pengecekanView.ShowMenu() },
            { "Management Pegawai", () => Task.Run(() => Console.WriteLine("Fitur Management Pegawai belum diimplementasikan.")) },
            { "Sistem Riwayat Pembelian", () => Task.Run(() => Console.WriteLine("Fitur Sistem Riwayat Pembelian belum diimplementasikan.")) },
        };
    }

    static Dictionary<string, Func<Task>> GetBuyerMenuActions(PembelianObat pembelianObat)
    {
        return new Dictionary<string, Func<Task>>
        {
            { "Lihat Produk", async () =>  pembelianObat.TampilkanDaftarObat()  },
            { "Beli Obat", async () => await pembelianObat.BeliObatAsync() },
            { "ChatBot", RunChatbotAsync },
            { "Sistem Baca Resep - Tampilkan Obat", () => Task.Run(() => BacaResepView.TampilkanObatTerdaftar()) },
            { "Sistem Baca Resep - Cari Obat", () => Task.Run(() => BacaResepView.CariObat()) }
        };
    }

    static async Task RunChatbotAsync()
    {
        Console.WriteLine("=== Chatbot Apotek ===");
        Console.WriteLine("ketik exit jika mau keluar");
        while (true)
        {
            Console.Write("Anda: ");
            var message = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(message) || message.ToLower() == "exit") break;

            try
            {

                var response = await _chatbotService.GetChatbotResponse(message);


                Console.WriteLine($"Bot: {response}\n");
            }
            catch (KeyNotFoundException ex)
            {

                Console.WriteLine("Terjadi kesalahan pada struktur data. Respons dari server tidak sesuai.");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
            }
        }
    }

}
