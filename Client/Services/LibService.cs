using Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Client.Services
{
    public class LibService : ILibService
    {
        private HttpClient httpClient { get; }

        public LibService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async void CreateBook(BookDTO bookDTO)
        {
            var jsonString = JsonSerializer.Serialize(bookDTO);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync("https://localhost:44333/Lib/CreateBook", httpContent);
            response.EnsureSuccessStatusCode();
        }

        public async void CreateReader(ReaderDTO readerDTO)
        {
            var jsonString = JsonSerializer.Serialize(readerDTO);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync("https://localhost:44333/Lib/CreateReader", httpContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            using var response = await httpClient.GetAsync("https://localhost:44333/Lib/GetBooks");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<BookDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<BookDTO>> GetFreeBooks()
        {
            using var response = await httpClient.GetAsync("https://localhost:44333/Lib/GetFreeBooks");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<BookDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<ReaderDTO> GetReader(int? ReaderId)
        {
            using var response = await httpClient.GetAsync("https://localhost:44333/Lib/GetReader/?ReaderId=" + ReaderId.ToString());
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ReaderDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async void GiveBook(int? BookId, int? ReaderId)
        {
            Dictionary<String, int?> dict = new Dictionary<String, int?>();
            dict["BookId"] = BookId;
            dict["ReaderId"] = ReaderId;
            var obj = JsonConvert.SerializeObject(dict);
            var httpContent = new StringContent(obj, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync($"https://localhost:44333/Lib/GiveBook/", httpContent);
            response.EnsureSuccessStatusCode();
        }

        public async void ReturnBook(int? BookId, int? ReaderId)
        {
            Dictionary<String, int?> dict = new Dictionary<String, int?>();
            dict["BookId"] = BookId;
            dict["ReaderId"] = ReaderId;
            var obj = JsonConvert.SerializeObject(dict);
            var httpContent = new StringContent(obj, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync("https://localhost:44333/Lib/ReturnBook", httpContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
