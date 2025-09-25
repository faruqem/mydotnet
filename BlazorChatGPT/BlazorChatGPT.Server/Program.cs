namespace BlazorChatGPT.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        // Allow Blazor WASM to call API
        app.UseCors(policy =>
            policy.WithOrigins("https://localhost:7061") // adjust if needed
                .AllowAnyMethod()
                .AllowAnyHeader());

        app.MapControllers();

        app.Run();
    }
}


