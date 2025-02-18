using ProyectXAPI.Models.DTO;
using ProyectXAPI.Models;
using ProyectXAPILibrary.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectXAPILibrary.Test
{
    public class AcountTest : Test
    {
        private AcountTest() { }
        public static string ShowOutputTests(Acount addAcount, Acount deleteAcount, ChangePassword acountPasswordInfo)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(AcountTest.TestCheckLogin());
            result.AppendLine(AcountTest.TestCheckAcountProfiles(new Acount()
            {
                Username = "ME",
                Password = "YOU"
            }));
            result.AppendLine(AcountTest.TestAddAcount(addAcount));
            result.AppendLine(AcountTest.TestDeleteAcount(deleteAcount));
            result.AppendLine(AcountTest.TestUpdateAcount(acountPasswordInfo));
            return result.ToString();
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
            });
        }
        private static string TestCheckAcountProfiles(Acount acount)
        {
            AcountController acountController = new AcountController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<Profile[]> response = acountController.GetAcountProfiles(acount).GetAwaiter().GetResult();
            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestDeleteAcount(Acount acount)
        {
            AcountController acountController = new AcountController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<object> response = acountController.DeleteAsync(acount).GetAwaiter().GetResult();
            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        private static string TestUpdateAcount(ChangePassword acountPasswordInfo)
        {
            AcountController acountController = new AcountController(new HttpClient()
            {
                BaseAddress = new Uri(APIURL)
            });
            ResponseDTO<object> response = acountController.UpdatePassword(acountPasswordInfo, acountPasswordInfo.NewPassword).GetAwaiter().GetResult();
            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}
