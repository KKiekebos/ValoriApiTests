using System.Net.Http.Json;
using ValoriApiTests.Models;

namespace ValoriApiTests.Repositories
{
    internal class TvMazeApi
    {
        private readonly HttpClient client;

        public TvMazeApi()
        {
            HttpClientHandler handler = new HttpClientHandler();

            client = new HttpClient(handler, false);
        }

        public async Task<IList<ShowInfo>?> GetShowsByNameAsync(string showName)
        {
            using HttpResponseMessage response = await client.GetAsync($"https://api.tvmaze.com/search/shows?q={showName}");
            var test= response.Content.ReadAsStringAsync();

            return await response.Content.ReadFromJsonAsync<IList<ShowInfo>>();
        }

        public async Task<Show?> GetShowInfoById(string showId)
        {
            using HttpResponseMessage response = await client.GetAsync($"https://api.tvmaze.com/shows/{showId}");
            var result = await response.Content.ReadFromJsonAsync<Show>(); // data is disposed if not stored in variable here
            return result;
        }
    }
}
