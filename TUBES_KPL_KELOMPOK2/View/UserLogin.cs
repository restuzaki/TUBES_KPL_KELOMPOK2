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
        Console.WriteLine("\n=== Login User ===");

        Console.Write("Masukkan nama: ");
        string nama = Console.ReadLine()?.Trim();

        
        if (string.IsNullOrWhiteSpace(nama))
        {
            Console.WriteLine("Nama tidak boleh kosong.");
            return null;
        }

        Console.Write("Masukkan password: ");
        string password = Console.ReadLine()?.Trim();

        
        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Password tidak boleh kosong.");
            return null;
        }

        var users = LoadUsers();

       
        var user = users.FirstOrDefault(u =>
            u.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password
        );

        if (user != null)
        {
            Console.WriteLine($"Login berhasil. Selamat datang, {user.Nama} !");
            
        }
        else
        {
            Console.WriteLine("Nama atau password salah.");
            
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
