

using ProyectXAPI.Models.DTO;
using ProyectXAPI.Models;
using ProyectXAPILibrary.Controller;
using System.Text.Json;
using System.Text;
using System.Data;

namespace ProyectXAPILibrary.Test
{
    public class SessionDataTest : Test
    {
        private SessionDataTest() { }

        public static string ShowOutputTests(int checkProfileID, string checkCreatorName, int checkSessionId, params SessionData[] dataSetsToAdd)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(TestAddSessionData(dataSetsToAdd));
            sb.AppendLine(TestGetAllSessionData());
            sb.AppendLine(TestGetProfileSessionData(checkProfileID,checkCreatorName));
            sb.AppendLine(TestGetSessionDataInfo(checkSessionId));
            sb.AppendLine(TestGetSessionData(checkProfileID,checkCreatorName,checkSessionId));

            return sb.ToString();
        }
        private static string TestAddSessionData(params SessionData[] dataSets)
        {
            SessionDataController controller = new SessionDataController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<object> response = controller.CreateMultipleAsync(dataSets).GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestGetAllSessionData()
        {
            SessionDataController controller = new SessionDataController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<SessionData[]> response = controller.ReadAllAsync().GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestGetProfileSessionData(int profileID, string creatorName)
        {
            SessionDataController controller = new SessionDataController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<SessionData[]> response = controller.ReadProfileSessionDataAsync(profileID,creatorName).GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestGetSessionDataInfo(int sessionID)
        {
            SessionDataController controller = new SessionDataController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<SessionData[]> response = controller.ReadSessionDataInfo(sessionID).GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestGetSessionData(int profileID, string creatorName, int sessionID)
        {
            SessionDataController controller = new SessionDataController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<SessionData> response = controller.ReadSessionData(profileID,creatorName,sessionID).GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}
