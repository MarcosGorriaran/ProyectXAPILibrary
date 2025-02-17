using System.Net.Http.Json;
using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using ProyectXAPILibrary.Controller.DAO;

namespace ProyectXAPILibrary.Controller
{
    public class AcountController : Controller, ICreateAsync<Acount>
    {
        const string CheckLoginPath = "CheckLogin";
        const string AddCountPath = "AddAcount";
        public AcountController(HttpClient client) : base(client) { }
        public async Task<ResponseDTO<Acount>> CheckLogin(Acount checkAcount)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(CheckLoginPath, checkAcount).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return DeserializeResponse<Acount>(response);
        }
        public async Task<ResponseDTO<object>> CreateAsync(Acount modelElement)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(AddCountPath, modelElement).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return DeserializeResponse<object>(response);
        }
    }
}
