using System.Net.Http;

namespace TodoList.WebApp.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get 
            {
                return _httpClient;
            }
        }
    }
}
