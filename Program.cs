using System.Text.Json;
using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using ProyectXAPILibrary.Controller;

namespace ProyectXAPILibrary
{
    public class Program
    {
        const string APIURL = "https://localhost:7086";
        public static void Main()
        {
            
            Console.WriteLine(TestCheckLogin());
            Console.WriteLine(TestAddAcount(new Acount()
            {
                Username = Console.ReadLine() ?? String.Empty,
                Password = Console.ReadLine() ?? String.Empty
            }));
        }
        private static string TestCheckLogin()
        {
            Acount acount = new Acount()
            {
                Username = "ME",
                Password = "ME"
            };
            return TestCheckLogin(acount);
        }
        private static string TestCheckLogin(Acount acount)
        {
            AcountController acountController = new AcountController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<Acount> responseDTO = acountController.CheckLogin(acount).GetAwaiter().GetResult();
            return JsonSerializer.Serialize(responseDTO, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestAddAcount(Acount acount)
        {
            AcountController acountController = new AcountController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<object> response = acountController.CreateAsync(acount).GetAwaiter().GetResult();
            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            }); ;
        }
    }
}
