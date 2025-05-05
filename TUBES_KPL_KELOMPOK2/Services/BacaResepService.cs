using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using Apotekku_API.Models;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class BacaResepService
    {
        private readonly string filePath = "Data/Obat.json";

        public List<Obat> GetObatTerdaftar()
        {
            if (!File.Exists(filePath))
                return new List<Obat>();

            var jsonData = File.ReadAllText(filePath);
            var obatList = JsonSerializer.Deserialize<List<Obat>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return obatList?.Where(o => o.status == ObatStatus.Terdaftar).ToList() ?? new List<Obat>();
        }
    }
}