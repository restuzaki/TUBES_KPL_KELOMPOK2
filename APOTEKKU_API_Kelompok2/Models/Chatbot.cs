namespace APOTEKKU_API_Kelompok2.Models
{
    public class Chatbot
    {
        public string Role { get; set; } = "bot";
        public string Content { get; set; } = "";
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("o");
    }
}
