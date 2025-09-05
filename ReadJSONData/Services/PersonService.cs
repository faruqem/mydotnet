using System.Text.Json;
using ReadJSONData.Models;

namespace ReadJSONData.Services
{
    public class PersonService
    {
        private readonly IWebHostEnvironment _env;

        public PersonService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data", "Person.json");
            
            if (!File.Exists(filePath))
                return new List<Person>();

            using var stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<List<Person>>(stream) 
                   ?? new List<Person>();
        }
    }
}