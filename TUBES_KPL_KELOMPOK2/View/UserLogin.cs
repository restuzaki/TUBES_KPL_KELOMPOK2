using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Apotekku_API.Models;

public class UserLogin
{
    private readonly string jsonFilePath = "Data/User.json";

    public User Login()
    {
        Console.Write("Masukkan nama: ");
        string nama = Console.ReadLine()?.Trim();

        Console.Write("Masukkan password: ");
        string password = Console.ReadLine()?.Trim();

        var users = LoadUsers();

        var user = users.FirstOrDefault(u =>
            u.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase) &&
            u.Password.Trim() == password
        );

        if (user != null)
        {
            Console.WriteLine($"Login berhasil. Selamat datang, {user.Nama} !");
            Console.WriteLine("\nTekan sembarang tombol untuk  ke menu Toko...");
        }
        else
        {
            Console.WriteLine("Nama atau password salah.");
            Console.WriteLine("\nTekan sembarang tombol untuk kembali ke menu login...");
        }

        Console.ReadKey();

        return user;
    }

    private List<User> LoadUsers()
    {
        try
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Gagal membaca file JSON: " + ex.Message);
            return new List<User>();
        }
    }
}
