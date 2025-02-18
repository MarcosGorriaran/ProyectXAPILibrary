

using ProyectXAPI.Models.DTO;
using ProyectXAPI.Models;
using ProyectXAPILibrary.Controller;
using System.Text;
using System.Text.Json;

namespace ProyectXAPILibrary.Test
{
    public class SessionTest : Test
    {
        private SessionTest() { }

        public static string ShowOutputTests(Session testSession)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(TestAddSession(testSession));
            sb.AppendLine(TestGetSession("0"));
            sb.AppendLine(TestGetSessions());

            return sb.ToString();
        }

        private static string TestGetSessions()
        {
            SessionController controller = new SessionController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO <Session[]> response = controller.ReadAllAsync().GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestGetSession(string id)
        {
            SessionController controller = new SessionController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<Session> response = controller.ReadAsync(id).GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestAddSession(Session session)
        {
            SessionController controller = new SessionController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<object> response = controller.CreateAsync(session).GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}
