// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tessitura.Service.Client.CRM;

namespace SearchConstituent
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = MainAsync();
            t.Wait();
        }
        private static async Task MainAsync()
        {
            const string credentials = "mfaruqe:itsadmin:nbc-mf-452:P!nkP@nther12#$";
            const string baseUri = "https://tessitest.ballet.ca/tessitura/api/Docs/";
            const string constituentSearchUri = baseUri + "CRM/Constituents/549704";

            var authHeaderString = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(credentials));
            var httpClient = new System.Net.Http.HttpClient {Timeout = new TimeSpan(0, 0, 5000)};
            httpClient.DefaultRequestHeaders.Add("Accept", "text/json");
            httpClient.DefaultRequestHeaders.Add("Authorization", authHeaderString);
            try
            {
                var response = await httpClient.GetAsync(constituentSearchUri);
                var responseString = await response.Content.ReadAsStringAsync();
                if (((int) response.StatusCode >= 200 && (int) response.StatusCode < 300))
                {
                    var constituentSearchResult = JsonConvert.DeserializeObject<ConstituentSearchResponse>(responseString);
                    foreach (var constituentSummary in constituentSearchResult.ConstituentSummaries)
                    {
                        Console.WriteLine(constituentSummary.DisplayName + " Id: " + constituentSummary.Id);
                    }
                }
                else
                {
                    Console.WriteLine(responseString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}