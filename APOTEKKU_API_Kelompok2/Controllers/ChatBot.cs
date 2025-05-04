using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using APOTEKKU_API_Kelompok2.Models;

namespace APOTEKKU_API_Kelompok2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatDokterController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent";

        private static List<Chatbot> _chatHistory = new List<Chatbot>();

        public ChatDokterController()
        {
            _httpClient = new HttpClient();
            _apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY") ?? "";

            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new Exception("GEMINI_API_KEY belum dikonfigurasi di config.env");
            }
        }

        public class ChatRequest
        {
            public string Message { get; set; } = string.Empty;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest("Pesan tidak boleh kosong.");
            }

            var fullMessage = "Kamu adalah chatbot kesehatan yang hanya menjawab tentang obat obatan karena kamu seorang farmasi. Tolong jangan jawab pertanyaan di luar topik ini.\n\n" + request.Message;

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[] { new { text = fullMessage } }
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync($"{_apiUrl}?key={_apiKey}", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("=== Gemini Response JSON ===");
                Console.WriteLine(responseBody);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, new Chatbot
                    {
                        Content = "Terjadi kesalahan saat menghubungi server."
                    });
                }

                using var doc = JsonDocument.Parse(responseBody);

                if (doc.RootElement.TryGetProperty("candidates", out var candidates) &&
                    candidates.ValueKind == JsonValueKind.Array &&
                    candidates.GetArrayLength() > 0)
                {
                    var botText = candidates[0]
                        .GetProperty("content")
                        .GetProperty("parts")[0]
                        .GetProperty("text")
                        .GetString();

                    var chatResponse = new Chatbot
                    {
                        Content = botText ?? "Maaf, saya tidak bisa menjawab itu."
                    };

                    _chatHistory.Add(chatResponse);
                    return Ok(chatResponse);
                }
                else
                {
                    return StatusCode(500, new Chatbot
                    {
                        Content = "Respons dari server tidak sesuai format yang diharapkan."
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Chatbot
                {
                    Content = "Terjadi kesalahan: " + ex.Message
                });
            }
        }

        [HttpGet("history")]
        public IActionResult GetChatHistory()
        {
            if (_chatHistory.Count == 0)
            {
                return NotFound("Belum ada percakapan.");
            }

            return Ok(_chatHistory);
        }

        [HttpGet("history/{index}")]
        public IActionResult GetChatbotResponse(int index)
        {
            if (index < 0 || index >= _chatHistory.Count)
            {
                return NotFound("Percakapan tidak ditemukan.");
            }

            return Ok(_chatHistory[index]);
        }
    }


}
