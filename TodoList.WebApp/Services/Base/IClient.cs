using System.Net.Http;

namespace TodoList.WebApp.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
