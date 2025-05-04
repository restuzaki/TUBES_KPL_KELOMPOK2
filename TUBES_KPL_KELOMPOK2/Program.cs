using System;
using System.Collections.Generic;
using Apotekku_API.Models;

class Program
{
    static void Main()
    {
        UserLogin userlogin = new UserLogin();
        UserRegister userregister = new UserRegister();

        var mainMenuActions = new Dictionary<string, Action>
        {
            { "1", () => HandleLogin(userlogin) },
            { "2", () => userregister.Register() },
            { "3", () => Environment.Exit(0) }
        };

        while (true)
        {
            Console.WriteLine("=== Aplikasi Apotek ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Pilih opsi (1/2/3): ");
            string pilihan = Console.ReadLine();

            if (mainMenuActions.ContainsKey(pilihan))
            {
                mainMenuActions[pilihan]();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
            }

            Console.WriteLine();
        }
    }

    static void HandleLogin(UserLogin userlogin)
    {
        User? user = userlogin.Login();
        if (user != null)
        {
            Console.WriteLine($"\nSelamat datang, {user.Nama}!");

            if (user.Role == "admin")
                ShowRoleMenu("Admin", GetAdminMenuActions());
            else if (user.Role == "buyer")
                ShowRoleMenu("Buyer", GetBuyerMenuActions());
            else
                Console.WriteLine("Role tidak dikenali.");
        }
    }

    static void ShowRoleMenu(string role, Dictionary<string, Action> menuActions)
    {
        string choice = "";
        while (choice != "exit")
        {
            Console.WriteLine($"\n=== Menu {role} ===");
            int index = 1;
            var keyMap = new Dictionary<string, string>(); // index to actual key
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
                menuActions[keyMap[input]]();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
            }
        }
    }

    static Dictionary<string, Action> GetAdminMenuActions()
    {
        return new Dictionary<string, Action>
        {
            { "Lihat Stok Obat", () => Console.WriteLine("Fitur Lihat Stok Obat belum diimplementasikan.") },
            { "Management Member Apotek", () => Console.WriteLine("Fitur Management Member Apotek belum diimplementasikan.") },
            { "Management Pemasukan", () => Console.WriteLine("Fitur Management Pemasukan belum diimplementasikan.") },
            { "Pengeluaran Apotek", () => Console.WriteLine("Fitur Pengeluaran Apotek belum diimplementasikan.") },
            { "Analisis Penyakit Bulanan", () => Console.WriteLine("Fitur Analisis Penyakit Bulanan belum diimplementasikan.") },
            { "Pengecekan Izin Obat", () => Console.WriteLine("Fitur Pengecekan Izin Obat belum diimplementasikan.") },
            { "Management Pegawai", () => Console.WriteLine("Fitur Management Pegawai belum diimplementasikan.") },
            { "Sistem Riwayat Pembelian", () => Console.WriteLine("Fitur Sistem Riwayat Pembelian belum diimplementasikan.") },
        };
    }

    static Dictionary<string, Action> GetBuyerMenuActions()
    {
        return new Dictionary<string, Action>
        {
            { "Lihat Produk", () => Console.WriteLine("Fitur Lihat Produk belum diimplementasikan.") },
            { "Beli Obat", () => Console.WriteLine("Fitur Beli Obat belum diimplementasikan.") },
            { "ChatBot", () => Console.WriteLine("Fitur ChatBot belum diimplementasikan.") },
            { "Sistem Baca Resep", () => Console.WriteLine("Fitur Sistem Baca Resep belum diimplementasikan.") },
        };
    }
}
