using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Apotekku_API.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Apotekku_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private const string JsonFilePath = "Data/User.json";

        private List<User> LoadUsers()
        {
            try
            {
                string jsonString = System.IO.File.ReadAllText(JsonFilePath);
                return JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
            }
            catch
            {
                return new List<User>();
            }
        }

        private void SaveUsers(List<User> users)
        {
            string updatedJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(JsonFilePath, updatedJson);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = LoadUsers();
            return Ok(users);
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            var users = LoadUsers();

            if (users.Any(u => u.Nama == newUser.Nama))
                return BadRequest("User sudah ada");

            newUser.Role ??= "Buyer";
            newUser.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;

            users.Add(newUser);
            SaveUsers(users);

            return Ok(newUser);
        }

        [HttpPost("login")]
        public IActionResult Login(User login)
        {
            var users = LoadUsers();
            var user = users.FirstOrDefault(u => u.Nama == login.Nama && u.Password == login.Password);

            if (user == null)
                return Unauthorized("Nama atau password salah");

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User updatedUser)
        {
            var users = LoadUsers();
            var index = users.FindIndex(u => u.Id == id);

            if (index == -1)
                return NotFound("User tidak ditemukan");

            updatedUser.Id = id;
            users[index] = updatedUser;
            SaveUsers(users);

            return Ok(updatedUser);
        }
    }
}
