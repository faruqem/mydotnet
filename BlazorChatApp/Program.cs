using BlazorChatApp.Services;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register OpenAI client with API key from configuration
builder.Services.AddSingleton<OpenAIClient>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var apiKey = configuration["OpenAI:ApiKey"];
    
    if (string.IsNullOrWhiteSpace(apiKey))
    {
        throw new InvalidOperationException("OpenAI API key is not configured. Please set the OpenAI:ApiKey configuration value.");
    }
    
    return new OpenAIClient(apiKey);
});

// Register chat service
builder.Services.AddScoped<IChatService, ChatService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();