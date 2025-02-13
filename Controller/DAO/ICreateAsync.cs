using ProyectXAPI.Models;

namespace ProyectXAPILibrary.Controller.DAO
{
    public interface ICreateAsync<T> where T : Model
    {
        public Task<Uri> CreateAsync(T modelElement);
    }
}
