using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Apotekku_API.Models;

namespace Apotekku_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PegawaiController : Controller
    {
        private static string jsonFilePath = "Data/Pegawai.json";

       
        private List<Pegawai> GetDataFromFile()
        {
            if (!System.IO.File.Exists(jsonFilePath))
            {
                
                return new List<Pegawai>();
            }

            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            return string.IsNullOrWhiteSpace(jsonString)
                ? new List<Pegawai>()  // Jika JSON kosong, kembalikan list kosong
                : JsonSerializer.Deserialize<List<Pegawai>>(jsonString) ?? new List<Pegawai>();  
        }

        [HttpGet]
        public ActionResult<List<Pegawai>> Get()
        {
            var result = GetDataFromFile();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Pegawai> Get(string id)
        {
            var result = GetDataFromFile();

            
            var pegawai = result.Find(p => p.id == id);

            if (pegawai == null)
            {
                return NotFound("Pegawai tidak ditemukan");
            }

            return Ok(pegawai);
        }

        [HttpPost]
        public ActionResult<Pegawai> Post([FromBody] Pegawai pegawai)
        {
            var result = GetDataFromFile();

           
            if (result.Exists(p => p.id == pegawai.id))
            {
                return Conflict("ID Pegawai sudah ada");
            }

            result.Add(pegawai);

            string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            return CreatedAtAction(nameof(Get), new { id = pegawai.id }, pegawai);
        }

        [HttpPut("{id}")]
        public ActionResult<Pegawai> Put(string id, [FromBody] Pegawai pegawai)
        {
            var result = GetDataFromFile();

            
            var existingPegawai = result.Find(p => p.id == id);
            if (existingPegawai == null)
            {
                return NotFound("Pegawai tidak ditemukan");
            }

            existingPegawai.nama = pegawai.nama;
            existingPegawai.jabatan = pegawai.jabatan;
            existingPegawai.status = pegawai.status;

            string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            return Ok(existingPegawai);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var result = GetDataFromFile();

          
            var pegawaiToDelete = result.Find(p => p.id == id);
            if (pegawaiToDelete == null)
            {
                return NotFound("Pegawai tidak ditemukan");
            }

            result.Remove(pegawaiToDelete);

            string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            return NoContent();
        }
    }
}
