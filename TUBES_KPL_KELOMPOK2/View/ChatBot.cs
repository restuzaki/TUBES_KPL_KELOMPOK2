using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class ChatbotView
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public ChatbotView()
        {
            _httpClient = new HttpClient();
            _apiUrl = "http://localhost:5193/api/ChatDokter/send"; 
        }

        public async Task<string> GetChatbotResponse(string message)
        {
            var payload = new { message = message };
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_apiUrl, payload);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

               
               

                try
                {
                    using var doc = JsonDocument.Parse(content);

                    if (doc.RootElement.TryGetProperty("content", out var contentProp))
                    {
                        return contentProp.GetString() ?? "Bot tidak memberikan jawaban.";
                    }
                    else
                    {
                        return "Respons dari API tidak memiliki properti 'content'.";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Kesalahan saat parsing JSON: {ex.Message}");
                    return "Terjadi kesalahan saat memproses respons dari chatbot.";
                }
            }

            return "Gagal menghubungi chatbot. Status code: " + response.StatusCode;
        }
    }
}





