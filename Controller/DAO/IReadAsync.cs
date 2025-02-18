using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectXAPILibrary.Controller.DAO
{
    public interface IReadAsync<T> where T : Model
    {
        public Task<ResponseDTO<T>> ReadAsync(string id);
    }
}
