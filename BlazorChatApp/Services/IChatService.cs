// Services/IChatService.cs
using BlazorChatApp.Models;

namespace BlazorChatApp.Services;

public interface IChatService
{
    Task<string> SendMessageAsync(List<ChatMessage> messages);
}