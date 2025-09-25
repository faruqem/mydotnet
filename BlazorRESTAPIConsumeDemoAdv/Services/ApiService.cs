using System.Net.Http.Json;
using BlazorRESTAPIConsumeDemo.Models;

namespace BlazorRESTAPIConsumeDemo.Services;

public class ApiService
{
    private readonly HttpClient _http;

    public ApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        return await _http.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts")
               ?? new List<Post>();
    }
    /*    
        public async Task<Post?> GetPostByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");
        }
    */

    //Updated to handle exception gracefully
    public async Task<Post?> GetPostByIdAsync(int id)
    {
        try
        {
            return await _http.GetFromJsonAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}
