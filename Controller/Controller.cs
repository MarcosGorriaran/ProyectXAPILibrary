

using System.Text.Json;
using ProyectXAPI.Models.DTO;

namespace ProyectXAPILibrary.Controller
{
    public class Controller
    {
        protected HttpClient client { get; private set; }
        protected JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public Controller(HttpClient client)
        {
            this.client = client;
        }
        private ResponseDTO<TValue>? DeserializeResponse<TValue>(string responseDTO)
        {
            return JsonSerializer.Deserialize<ResponseDTO<TValue>>(responseDTO, serializerOptions);
        }
        private async Task<ResponseDTO<TValue>?> DeserializeResponseAsync<TValue>(HttpResponseMessage responseContent)
        {
            string responseDTO = await responseContent.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ResponseDTO<TValue>>(responseDTO, serializerOptions);
        }
        protected ResponseDTO<T> DeserializeResponse<T>(HttpResponseMessage responseContent)
        {
            return DeserializeResponseAsync<T>(responseContent).GetAwaiter().GetResult() ?? new ResponseDTO<T>()
            {
                IsSuccess = false
            };
        }
    }
}
