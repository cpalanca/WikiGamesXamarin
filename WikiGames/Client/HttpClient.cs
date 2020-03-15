using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace WikiGames.Client
{
    public class HttpClient
    {
        private Dictionary<string, string> _headers;

        public HttpClient(Dictionary<string, string> headers)
        {
            if (headers != null) _headers = headers;
            else _headers = new Dictionary<string, string>();

        }

        public string this[string key]
        {
            get
            {
                return _headers[key];
            }
            set
            {
                _headers[key] = value;
            }
        }

        /// <summary>
        /// HTTPGET request
        /// </summary>

        public async Task<HttpResponse<T>> GetAsync<T>(string baseUrl, Dictionary<string, object> formdata = null)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.GET);

            // asignar los request a la peticion

            foreach (var header in _headers)
            {
                request.AddHeader(header.Key, header.Value);
            }
            if (formdata != null)
            {
                foreach (var item in formdata)
                {
                    request.AddParameter(item.Key, item.Value);
                }

            }
            IRestResponse response = null;
            Exception ex = null;
            try
            {
                response = await client.ExecuteTaskAsync(request);
            }
            catch (Exception _ex)
            {
                ex = _ex;
            }

            var httpResponse = new HttpResponse<T>
            {
                Response = response
            };

            if (response == null)
            {
                httpResponse.Status = new StatusResponse
                {
                    message = $"no se pudo obtener una respuesta del servidor, stacktrace: {ex.StackTrace}"
                };
                return httpResponse;
            }

            var jsonResult = response.Content;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var tElement = JsonConvert.DeserializeObject<T>(jsonResult);
                httpResponse.Result = tElement;

            }
            else if (response.StatusCode == 0)
            {
                httpResponse.Status = new StatusResponse
                {
                    message = $"no se pudo obtener una respuesta del servidor."
                };
            }
            else
            {

                var status = JsonConvert.DeserializeObject<StatusResponse>(jsonResult);
                httpResponse.Status = status;

            }

            return httpResponse;
        }


    }

}