using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;

namespace ProyectXAPILibrary.Controller.DAO
{
    public interface IDeleteAsync<T> where T : Model
    {
        public Task<ResponseDTO<object>> DeleteAsync(T entity);
    }
}
