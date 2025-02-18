using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using ProyectXAPILibrary.Controller.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectXAPILibrary.Controller
{
    public class SessionController : Controller, IReadAsync<Session>, IReadListAsync<Session>,ICreateAsync<Session>
    {
        const string SessionIDName = "sessionId=";

        const string GetSessionsPath = "GetSessions";
        const string GetSessionPath = "GetSession";
        const string AddSessionPath = "AddSession";
        public SessionController(HttpClient client) : base(client) { }

        public async Task<ResponseDTO<Session[]>> ReadAllAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, GetSessionsPath);
            HttpResponseMessage response = await SendRequest(request);

            return DeserializeResponse<Session[]>(response);
        }
        public async Task<ResponseDTO<Session>> ReadAsync(string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, GetSessionPath + "?" + SessionIDName + id);
            HttpResponseMessage response = await SendRequest(request);

            return DeserializeResponse<Session>(response);
        }
        public async Task<ResponseDTO<object>> CreateAsync(Session addedSession)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, AddSessionPath);
            HttpResponseMessage response = await SendRequest(request, addedSession);

            return DeserializeResponse<object>(response);
        }
    }
}
