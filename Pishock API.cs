using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Pishock
{
    public class Pishock_API
    {

        public async Task Shock(int intensity, int duration)
        {
            var requestData = new
            {
                Username = ModContent.GetInstance<Config>().username,
                Name = ModContent.GetInstance<Config>().senderName,
                Code = ModContent.GetInstance<Config>().code,
                Intensity = intensity,
                Duration = duration,
                Apikey = ModContent.GetInstance<Config>().apiKey,
                Op = 0,
            };

            await SendRequest(requestData);
        }

        public async Task Vibrate(int intensity, int duration)
        {
            var requestData = new
            {
                Username = ModContent.GetInstance<Config>().username,
                Name = ModContent.GetInstance<Config>().senderName,
                Code = ModContent.GetInstance<Config>().code,
                Intensity = intensity,
                Duration = duration,
                Apikey = ModContent.GetInstance<Config>().apiKey,
                Op = 1,
            };

            await SendRequest(requestData);
        }

        public async Task Beep(int duration)
        {
            var requestData = new
            {
                Username = ModContent.GetInstance<Config>().username,
                Name = ModContent.GetInstance<Config>().senderName,
                Code = ModContent.GetInstance<Config>().code,
                Duration = duration,
                Apikey = ModContent.GetInstance<Config>().apiKey,
                Op = 2,
            };

            await SendRequest(requestData);
        }


        private async Task SendRequest(object requestData)
        {
            using HttpClient client = new();

            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

            using HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(ModContent.GetInstance<Config>().apiEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Request sent successfully.");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");

                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Content: {responseContent}");
            }
        }


    }
}