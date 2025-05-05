using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Apotekku_API.Models;
using System;
using System.IO;

namespace Apotekku_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BacaResepController : ControllerBase
    {
        private static readonly string filePath = "Data/Obat.json";

        [HttpGet]
        public ActionResult<List<Obat>> GetAllObat()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath))
                {
                    return StatusCode(500, "Path file tidak ditemukan.");
                }

                var data = BacaResep.AmbilDataObat(filePath);

                if (data == null || data.Count == 0)
                {
                    return NotFound("Data obat tidak ditemukan atau kosong.");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Terjadi kesalahan saat mengambil data obat: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Obat> GetObatById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    return BadRequest("ID obat tidak boleh kosong.");
                }

                var data = BacaResep.AmbilDataObat(filePath);

                if (data == null)
                {
                    return StatusCode(500, "Gagal mengambil data obat.");
                }

                var obat = data.Find(o => o.id == id);

                if (obat == null)
                {
                    return NotFound($"Obat dengan ID '{id}' tidak ditemukan.");
                }

                return Ok(obat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Terjadi kesalahan saat mencari obat: {ex.Message}");
            }
        }
    }
}
