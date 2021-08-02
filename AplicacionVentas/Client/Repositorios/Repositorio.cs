using AplicacionVentas.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AplicacionVentas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient;

        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private JsonSerializerOptions OpcionesPorDefectoJSON =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<T>(responseHTTP, OpcionesPorDefectoJSON);
                return new HttpResponseWrapper<T>(response, false, responseHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, true, responseHTTP);
            }
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<TResponse>(responseHttp, OpcionesPorDefectoJSON);
                return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, true, responseHttp);
            }
        }

        public List<EntidadEvidencia> ObtenerEvidencias()
        {
            return new List<EntidadEvidencia>()
            {
                    new EntidadEvidencia(){ EvidenciaId=1, FechaCaptura=DateTime.Now, 
                        Foto="https://localhost:44355/evidencias/eb641387-3a53-4d83-a360-c165de63a968.jpg", EmpleadoId= 1},
                    new EntidadEvidencia(){ EvidenciaId=2, FechaCaptura=DateTime.Now,
                        Foto="https://localhost:44355/evidencias/0fe0d9c7-6f5c-4ee8-b526-a5d11e1ed7ea.jpg", EmpleadoId= 2},
                    new EntidadEvidencia(){ EvidenciaId=3, FechaCaptura=DateTime.Now,
                        Foto="https://localhost:44355/evidencias/cc9ac050-b622-40cb-8ce2-624324457ee9.jpg", EmpleadoId= 3},
                    new EntidadEvidencia(){ EvidenciaId=2, FechaCaptura=DateTime.Now,
                        Foto="https://localhost:44355/evidencias/0fe0d9c7-6f5c-4ee8-b526-a5d11e1ed7ea.jpg", EmpleadoId= 2},
                    new EntidadEvidencia(){ EvidenciaId=3, FechaCaptura=DateTime.Now,
                        Foto="https://localhost:44355/evidencias/cc9ac050-b622-40cb-8ce2-624324457ee9.jpg", EmpleadoId= 3},
                    new EntidadEvidencia(){ EvidenciaId=2, FechaCaptura=DateTime.Now,
                        Foto="https://localhost:44355/evidencias/0fe0d9c7-6f5c-4ee8-b526-a5d11e1ed7ea.jpg", EmpleadoId= 2},
                    new EntidadEvidencia(){ EvidenciaId=3, FechaCaptura=DateTime.Now,
                        Foto="https://localhost:44355/evidencias/cc9ac050-b622-40cb-8ce2-624324457ee9.jpg", EmpleadoId= 3}

            };
        }

    }
}
