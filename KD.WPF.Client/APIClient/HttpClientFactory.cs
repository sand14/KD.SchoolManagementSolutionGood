using System.Net.Http;

namespace KD.WPF.Client.APIClient
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient GetHttpClient()
        {
            return new HttpClient();
        }
    }
}
