using System.Text;
using Newtonsoft.Json;

namespace Ejercicio1.Api.ServiceCall
{
    public class HttpBase : IHttpBase
    {
        private readonly HttpClient _httpClient;

        protected HttpBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Llamada Get a un servicio
        /// </summary>
        /// <typeparam name="R">Tipo de parámetro de salida</typeparam>
        /// <param name="uri">URL</param>
        /// <returns></returns>
        public async Task<R> Get<R>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<R>(responseStream);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new ArgumentException("NoContent");
            }
            else
            {
                throw new Exception($"Error to get the query {uri} Status:{response.StatusCode} Content:{response.Content}");
            }
        }

        /// <summary>
        /// Llamada post
        /// </summary>
        /// <typeparam name="S">Tipo de dato enviado</typeparam>
        /// <typeparam name="R">Tipo de dato devuelto</typeparam>
        /// <param name="uri">url ws</param>
        /// <param name="Element">Elemento del tipo enviado</param>
        /// <returns></returns>
        public async Task<R> Post<R, S>(string uri, S Element, int ent)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(Element), Encoding.UTF8, "application/json");
            string url = $"{uri}/{ent}";
            var response = await _httpClient.PostAsync(url, content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<R>(responseStream);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
        }

        /// <summary>
        /// Llamada put
        /// </summary>
        /// <typeparam name="S">Tipo de dato enviado</typeparam>
        /// <typeparam name="R">Tipo de dato devuelto</typeparam>
        /// <param name="uri">url ws</param>
        /// <param name="Element">Elemento del tipo enviado</param>
        /// <returns></returns>
        public async Task<R> Put<R, S>(string uri, S Element)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(Element), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content);

            response.EnsureSuccessStatusCode();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<R>(responseStream);
            }
            else
            {
                throw new Exception($"Error to get the query {uri} Status:{response.StatusCode} Content:{response.Content}");
            }
        }

        /// <summary>
        /// Llamada Delete a un servicio
        /// </summary>
        /// <typeparam name="R">Tipo de parámetro de salida</typeparam>
        /// <param name="uri">URL</param>
        /// <returns></returns>
        public async Task<R> Delete<R>(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<R>(responseStream);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new ArgumentException("NoContent");
            }
            else
            {
                throw new Exception($"Error to get the query {uri} Status:{response.StatusCode} Content:{response.Content}");
            }
        }
    }
}

