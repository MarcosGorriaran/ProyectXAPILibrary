using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using ProyectXAPILibrary.Controller;
using System.Text;
using System.Text.Json;

namespace ProyectXAPILibrary.Test
{
    public class ProfileTest : Test
    {
        private ProfileTest() { }

        public static string ShowOutputTests(Profile testProfile, string profileNewName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(TestAddProfile(testProfile));
            testProfile.ProfileName = profileNewName;
            testProfile.Id = 0;
            sb.AppendLine(TestUpdateProfile(testProfile));
            sb.AppendLine(TestDeleteProfile(testProfile));

            return sb.ToString();
        }

        private static string TestAddProfile(Profile profile)
        {
            ProfileController controller = new ProfileController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<object> response = controller.CreateAsync(profile).GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestUpdateProfile(Profile profile)
        {
            ProfileController controller = new ProfileController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<object> response = controller.UpdateAsync(profile).GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestDeleteProfile(Profile profile)
        {
            ProfileController controller = new ProfileController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<object> response = controller.DeleteAsync(profile).GetAwaiter().GetResult();

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}
