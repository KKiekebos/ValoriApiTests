using ValoriApiTests.Models;

namespace ValoriApiTests.Repositories
{
    internal class OpenWeatherApi
    {
        private readonly HttpClient client;

        public OpenWeatherApi()
        {
            HttpClientHandler handler = new HttpClientHandler();

            client = new HttpClient(handler, false);
        }

        public async Task<ApiResult> GetWeatherByCityNameAsync(string cityName, string appId)
        {
            using HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={appId}");
            return new ApiResult
            {
                Body = await response.Content.ReadAsStringAsync(),
                StatusCode = response.StatusCode,
            };
        }
    }
}
