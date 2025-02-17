using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;

namespace ProyectXAPILibrary.Controller.DAO
{
    public interface ICreateAsync<T> where T : Model
    {
        public Task<ResponseDTO<Object>> CreateAsync(T modelElement);
    }
}
