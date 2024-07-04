
namespace Ejercicio1.Api.ServiceCall
{
    public interface IHttpBase
    {
        Task<R> Delete<R>(string uri);
        Task<R> Get<R>(string uri);
        Task<R> Post<R, S>(string uri, S Element, int ent);
        Task<R> Put<R, S>(string uri, S Element);
    }
}