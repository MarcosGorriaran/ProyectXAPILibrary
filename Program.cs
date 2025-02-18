using System.Text.Json;
using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using ProyectXAPILibrary.Controller;
using ProyectXAPILibrary.Test;

namespace ProyectXAPILibrary
{
    public class Program
    {
        public static void Main()
        {
            /*Console.WriteLine("Test Acount");
            Console.WriteLine(AcountTest.ShowOutputTests(new Acount()
            {
                Username = Console.ReadLine() ?? String.Empty,
                Password = Console.ReadLine() ?? String.Empty
            },
            new Acount()
            {
                Username = Console.ReadLine() ?? String.Empty,
                Password = Console.ReadLine() ?? String.Empty
            },
            new ChangePassword()
            {
                Username = Console.ReadLine() ?? String.Empty,
                Password = Console.ReadLine() ?? String.Empty,
                NewPassword = Console.ReadLine() ?? String.Empty
            }));*/
            Console.WriteLine("Test Profile");
            Console.WriteLine(ProfileTest.ShowOutputTests(new Profile()
            {
                Creator = new Acount()
                {
                    Username = "ME",
                    Password = "ME"
                },
                ProfileName = "SomeRandomName",
                
            },"Bla bla bla"));
            Console.WriteLine("Test Session");
            Console.WriteLine(SessionTest.ShowOutputTests(new Session()));
        }

    }
}
