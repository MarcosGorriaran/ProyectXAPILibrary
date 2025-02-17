using System.Text.Json;
using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using ProyectXAPILibrary.Controller;

namespace ProyectXAPILibrary
{
    public class Program
    {
        const string APIURL = "http://localhost:5000";
        public static void Main()
        {

        }
        private static string TestCheckLogin()
        {
            Acount acount = new Acount()
            {
                Username = "ME",
                Password = "ME"
            };
            AcountController acountController = new AcountController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<Acount> responseDTO = acountController.CheckLogin(acount).GetAwaiter().GetResult();
            return JsonSerializer.Serialize(responseDTO,new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}
