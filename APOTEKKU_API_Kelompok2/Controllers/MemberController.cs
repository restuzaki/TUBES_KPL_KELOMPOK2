using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Apotekku_API.Models;

namespace Apotekku_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private static readonly string jsonFilePath = "Data/MemberData.json";

        private List<Member> BacaDataMember()
        {
            if (!System.IO.File.Exists(jsonFilePath))
                return new List<Member>();

            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<Member>>(jsonString) ?? new List<Member>();
        }

        private void SimpanDataMember(List<Member> data)
        {
            string updatedJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);
        }

        [HttpGet]
        public ActionResult<List<Member>> Get()
        {
            var result = BacaDataMember();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Member> Get(string id)
        {
            var result = BacaDataMember();
            var member = result.FirstOrDefault(m => m.Id == id);
            if (member == null) return NotFound("Member tidak ditemukan");
            return Ok(member);
        }

        [HttpPost]
        public ActionResult<Member> Post([FromBody] Member member)
        {
            var result = BacaDataMember();
            if (result.Any(m => m.Id == member.Id))
                return Conflict("Member dengan ID tersebut sudah ada.");

            result.Add(member);
            SimpanDataMember(result);
            return CreatedAtAction(nameof(Get), new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public ActionResult<Member> Put(string id, [FromBody] Member member)
        {
            var result = BacaDataMember();
            var existing = result.FirstOrDefault(m => m.Id == id);
            if (existing == null) return NotFound("Member tidak ditemukan");

            existing.Nama = member.Nama;
            existing.Alamat = member.Alamat;
            existing.TanggalLahir = member.TanggalLahir;
            existing.NomorTelepon = member.NomorTelepon;
            existing.Poin = member.Poin;

            SimpanDataMember(result);
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var result = BacaDataMember();
            var memberToDelete = result.FirstOrDefault(m => m.Id == id);
            if (memberToDelete == null) return NotFound("Member tidak ditemukan");

            result.Remove(memberToDelete);
            SimpanDataMember(result);
            return NoContent();
        }
    }
}
