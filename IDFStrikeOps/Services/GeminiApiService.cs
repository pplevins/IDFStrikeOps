using System.Text;
using System.Text.Json;

namespace IDFStrikeOps.Services;

internal class GeminiApiService
{
    private static readonly string _apiKey = Environment.GetEnvironmentVariable("GeminiApiKey") 
        ?? throw new NullReferenceException("No API key existed in your system.");
    private static readonly HttpClient _httpClient = new();

    public static async Task<string?> AskGeminiAsync(string prompt)
    {
        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = prompt }
                    }
                }
            }
        };

        string jsonRequest = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";

        HttpResponseMessage response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            string error = await response.Content.ReadAsStringAsync();
            throw new Exception($"API call failed: {error}");
        }

        string responseJson = await response.Content.ReadAsStringAsync();

        // Parse the response (assuming basic structure)
        using JsonDocument doc = JsonDocument.Parse(responseJson);
        string? generatedText = doc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();

        return generatedText;
    }

    public static async Task TalkToGeminiAsync()
    {
        string input = "";
        while (input.ToLower() != "exit")
        {
            Console.Write(">>> Ask Gemini something (type 'exit' to stop): ");
            input = Console.ReadLine() ?? throw new ArgumentNullException("No prompt has entered.");

            try
            {
                string result = await AskGeminiAsync(input) ?? throw new NullReferenceException("Nothing returned from Gemini!");
                Console.WriteLine("\nGemini says:");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
