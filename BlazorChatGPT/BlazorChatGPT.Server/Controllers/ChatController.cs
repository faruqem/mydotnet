using Microsoft.AspNetCore.Mvc;
using BlazorChatGPT.Shared;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BlazorChatGPT.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly HttpClient _http;

    public ChatController(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient();
    }

    [HttpPost("send")]
    public async Task<ActionResult<ChatMessage>> SendMessage([FromBody] ChatMessage message)
    {
        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
            return BadRequest("Missing OpenAI API Key");

        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);

        // Prepare request body
        var body = new
        {
            model = "gpt-4o-mini", // or "gpt-4o" etc.
            messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = message.Content }
            }
        };

        var jsonContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

        var response = await _http.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, err);
        }

        using var stream = await response.Content.ReadAsStreamAsync();
        using var doc = await JsonDocument.ParseAsync(stream);

        var reply = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return Ok(new ChatMessage { Role = "assistant", Content = reply ?? "" });
    }
}