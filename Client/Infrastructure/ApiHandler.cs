using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public class ApiHandler : HttpClient
    {
        public readonly Uri _baseUrl;
        public ApiHandler(Uri baseUrl)
        {
            _baseUrl = baseUrl;
        }


        public async Task<T> ExecuteRequestAsync<T>(string controller, string httpMethod, string jsonContent)
        {
            string url = $"{_baseUrl}/{controller}";
            string content = await getContent(url, httpMethod, jsonContent);
            return JsonConvert.DeserializeObject<T>(content);
        }

        private async Task<string> getContent(string url, string httpMethod, string jsonContent)
        {
            var request = new HttpRequestMessage(new HttpMethod(httpMethod), url);
            if (jsonContent != null) 
            {
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            }

            using (HttpResponseMessage resp = await base.SendAsync(request))
            {
                if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception();
                }
                return await resp.Content.ReadAsStringAsync();
            }
        }
    }
}
