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
    private static DataObatView _dataObatView = new DataObatView();

    static async Task Main()
    {
        var mainMenuActions = new Dictionary<string, Func<Task>>
        {
            { "1", async () => await HandleLogin(_userLogin, _pembelianObat, _analisisPenyakit) },
            { "2", async () =>
                {
                    try { _userRegister.Register(); }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Terjadi kesalahan saat register: {ex.Message}");
                    }
                    Console.WriteLine("Tekan tombol apapun untuk kembali ke menu...");
                    Console.ReadKey();
                }
            },
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
            string pilihan = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(pilihan))
            {
                Console.WriteLine("Input tidak boleh kosong.");
                Console.ReadKey();
                continue;
            }

            if (mainMenuActions.TryGetValue(pilihan, out var action))
            {
                await action();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
                Console.ReadKey();
            }
        }
    }

    static async Task HandleLogin(UserLogin userLogin, PembelianObat pembelianObat, AnalisisPenyakit analisisPenyakit)
    {
        try
        {
            User? user = userLogin.Login();
            if (user != null)
            {
                Console.WriteLine($"\nSelamat datang, {user.Nama}!");

                if (user.Role == "Admin")
                {
                    var keuanganService = new KeuanganService();
                    var keuanganManagement = new KeuanganView(keuanganService);
                    await ShowRoleMenu("Admin", GetAdminMenuActions(analisisPenyakit, keuanganManagement));
                }
                else if (user.Role == "Buyer")
                {
                    await ShowRoleMenu("Buyer", GetBuyerMenuActions(pembelianObat));
                }
                else
                {
                    Console.WriteLine("Role tidak dikenali.");
                }
            }
            else
            {
                Console.WriteLine("Login gagal. Pastikan username dan password benar.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan saat login: {ex.Message}");
            Console.ReadKey();
        }
    }

    static async Task ShowRoleMenu(string role, Dictionary<string, Func<Task>> menuActions)
    {
        while (true)
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
            string input = Console.ReadLine()?.Trim();

            if (input == index.ToString())
            {
                Console.WriteLine("Logout berhasil.");
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
                Console.WriteLine("Pilihan tidak valid.");
                Console.ReadKey();
            }
        }
    }

    static Dictionary<string, Func<Task>> GetAdminMenuActions(AnalisisPenyakit analisisPenyakit, KeuanganView keuanganView)
    {
        return new Dictionary<string, Func<Task>>
        {
            { "Lihat Stok Obat", async () => await new StokObatView().MenuStokObat() },
            { "Management Member Apotek", async () => await new ManajemenMemberView().ShowMenu() },
            { "Manajemen Keuangan", async () => await Task.Run(() => keuanganView.TampilkanMenuKeuangan()) },
            { "Analisis Penyakit Bulanan", async () => await analisisPenyakit.TampilkanAnalisisAsync() },
            { "Pengecekan Izin Obat", async () => await _pengecekanView.ShowMenu() },
            { "Management Pegawai", async () => await new ManajemenPegawaiView(new PegawaiService()).ShowMenu() },
            { "Sistem Riwayat Pembelian", () => Task.Run(() => Console.WriteLine("Fitur Sistem Riwayat Pembelian belum diimplementasikan.")) },
        };
    }


    static Dictionary<string, Func<Task>> GetBuyerMenuActions(PembelianObat pembelianObat)
    {
        return new Dictionary<string, Func<Task>>
        {
            { "Lihat Produk", async () => await _dataObatView.TampilkanDaftarObatAsync() },
            { "Beli Obat", async () => await pembelianObat.BeliObatAsync() },
            { "ChatBot", RunChatbotAsync },
            { "Sistem Baca Resep - Tampilkan Obat", () => Task.Run(() => BacaResepView.TampilkanObatTerdaftar()) },
            { "Sistem Baca Resep - Cari Obat", () => Task.Run(() => BacaResepView.CariObat()) },
            { "Lihat Riwayat Pembelian", () => Task.Run(() => pembelianObat.TampilkanRiwayatPembelian()) },
        };
    }

    static async Task RunChatbotAsync()
    {
        Console.WriteLine("=== Chatbot Apotek ===");
        Console.WriteLine("Ketik 'exit' untuk keluar");

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
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Terjadi kesalahan struktur data. Respon dari server tidak sesuai.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
            }
        }
    }
}
