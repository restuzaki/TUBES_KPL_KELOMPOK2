using DotNetEnv;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Load .env file
DotNetEnv.Env.Load("config.env");

// Tambahkan environment variable ke konfigurasi
builder.Configuration.AddEnvironmentVariables();

// Validasi GEMINI_API_KEY harus ada
var apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
if (string.IsNullOrWhiteSpace(apiKey))
{
    throw new Exception("GEMINI_API_KEY tidak ditemukan di config.env. Mohon isi terlebih dahulu.");
}

// Tambahkan layanan ke container
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Optional: untuk mengabaikan casing saat serialisasi
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Konfigurasi middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
